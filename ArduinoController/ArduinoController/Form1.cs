using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using Accord.Audio;
using Accord.Audition.Beat;
using Accord.DirectSound;
using Cyotek.Windows.Forms;

//Use this to change modes in the ArduinoSketch.ino:
//https://learn.adafruit.com/multi-tasking-the-arduino-part-3/deconstructing-the-loop

namespace ArduinoController
{
    public partial class Form1 : Form
    {

        private NotifyIcon trayIcon;

        DateTime LastUpdate = DateTime.Now;
        double minimumTimeBetweenUpdates = 50; //ms
        double timeRemaining = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = this.Icon,
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Show Application", TrawShowApplication),
                    new MenuItem("Exit", TrayExit)
                }),
                Visible = true
            };

            string comPort = AutodetectArduinoPort();
            if(comPort == null)
            {
                labelPortStatus.Text = "Serial Port Status: ARDUINO NOT FOUND";
            }
            else
            {
                labelPortStatus.Text = "Serial Port Status: OPEN on " + comPort;
                serialPort.PortName = comPort;
                serialPort.Open();

                timeRemaining = minimumTimeBetweenUpdates;

                //Set up audio
                var audioDevices = new AudioDeviceCollection(AudioDeviceCategory.Capture);

                foreach (AudioDeviceInfo device in audioDevices)
                {
                    comboBoxMicrophoneSource.Items.Add(device);
                }

                if (comboBoxMicrophoneSource.Items.Count == 0)
                {
                    comboBoxMicrophoneSource.Items.Add("No local capture devices");
                    comboBoxMicrophoneSource.Enabled = false;
                }

                comboBoxMicrophoneSource.SelectedIndex = 0;

                groupBoxLightMode.Enabled = true;
                groupBoxFanControl.Enabled = true;
            }


        }

        private string AutodetectArduinoPort()
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Arduino"))
                    {
                        return deviceId;
                    }
                }
            }
            catch (ManagementException e)
            {
                /* Do Nothing */
            }

            return null;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (this.Visible)
                {
                    DialogResult result = MessageBox.Show("Minimize to tray?", "Closing", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        this.Hide();
                        e.Cancel = true;
                    }
                    else if (result == DialogResult.No)
                    {
                        SafeClose();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    SafeClose();
                }
            }
        }

        void SafeClose()
        {
            if (source != null)
            {
                source.SignalToStop();
                source.Stop();
            }

            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("ALL_OFF"); //turn everything off
                serialPort.Close();
            }

            trayIcon.Visible = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void TrawShowApplication(object sender, EventArgs e)
        {
            this.Show();
        }

        private void TrayExit(object sender, EventArgs e)
        {
            this.Close();
        }

        string data = "";
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                data = "";

                SerialPort sp = (SerialPort)sender;
                sp.NewLine = "\n";

                data = sp.ReadLine();
                Debug.WriteLine(data);
            }
        }

        void SendLightMode(string command, int lightMode, Color? color1, Color? color2, int brightness, int interval, int steps, string direction) // or REVERSE
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine(String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", command, lightMode, color1?.ToArgb(), color2?.ToArgb(), brightness, interval, steps, direction));
            }
        }

        void SendCommandWithOneParameter(string command, string parameter, bool checkTiming = true)
        {
            DateTime now = DateTime.Now;
            TimeSpan difference = now - LastUpdate;
            if(difference.TotalMilliseconds > minimumTimeBetweenUpdates || !checkTiming)
            {
                LastUpdate = now;
                if (serialPort.IsOpen)
                {
                    serialPort.WriteLine(String.Format("{0},{1}", command, parameter));
                }
                timeRemaining = minimumTimeBetweenUpdates;
            }
            else
            {
                timeRemaining -= difference.TotalMilliseconds;
            }
        }

        //LISTENERS FOR THE RADIO BUTTONS
        #region RadioButtons
        private void radioButtonNONE_CheckedChanged(object sender, EventArgs e)
        {
            string command = "LIGHT_MODE";
            int lightMode = -1;
            Color? color1 = GetColorFromTextBoxes(1);
            Color? color2 = GetColorFromTextBoxes(2);
            int brightness = trackBarBrightness.Value;
            int interval = int.Parse(textBoxInterval.Text);
            int steps = int.Parse(textBoxSteps.Text);
            string direction = "FORWARD";

            groupBoxColor1.Enabled = false;
            groupBoxColor2.Enabled = false;
            groupBoxBrightness.Enabled = false;
            groupBoxInterval.Enabled = false;
            groupBoxSteps.Enabled = false;
            buttonReverseDirection.Enabled = false;
            groupBoxMusic.Enabled = false;

            SendLightMode(command, lightMode, color1, color2, brightness, interval, steps, direction);
        }

        private void radioButtonSolidColor_CheckedChanged(object sender, EventArgs e)
        {
            trackBarBrightness.Value = 255;

            string command = "LIGHT_MODE"; //yes
            int lightMode = 0; //yes
            Color? color1 = GetColorFromTextBoxes(1); //yes
            Color? color2 = GetColorFromTextBoxes(2);
            int brightness = trackBarBrightness.Value; //yes
            int interval = int.Parse(textBoxInterval.Text);
            int steps = int.Parse(textBoxSteps.Text);
            string direction = "FORWARD";

            groupBoxColor1.Enabled = true;
            groupBoxColor2.Enabled = false;
            groupBoxBrightness.Enabled = true;
            groupBoxInterval.Enabled = false;
            groupBoxSteps.Enabled = false;
            buttonReverseDirection.Enabled = false;
            groupBoxMusic.Enabled = true;
            if (source != null)
                source.SignalToStop();

            SendLightMode(command, lightMode, color1, color2, brightness, interval, steps, direction);
        }

        private void radioButtonRainbowCycle_CheckedChanged(object sender, EventArgs e)
        {
            trackBarBrightness.Value = 255;
            textBoxInterval.Text = "100";

            string command = "LIGHT_MODE"; //yes
            int lightMode = 1; //yes
            Color? color1 = GetColorFromTextBoxes(1);
            Color? color2 = GetColorFromTextBoxes(2);
            int brightness = trackBarBrightness.Value; //yes
            int interval = int.Parse(textBoxInterval.Text);//yes
            int steps = int.Parse(textBoxSteps.Text);
            string direction = "FORWARD";//yes

            groupBoxColor1.Enabled = false;
            groupBoxColor2.Enabled = false;
            groupBoxBrightness.Enabled = true;
            groupBoxInterval.Enabled = true;
            groupBoxSteps.Enabled = false;
            buttonReverseDirection.Enabled = true;
            groupBoxMusic.Enabled = false;
            if (source != null)
                source.SignalToStop();

            SendLightMode(command, lightMode, color1, color2, brightness, interval, steps, direction);
        }

        private void radioButtonTheaterChase_CheckedChanged(object sender, EventArgs e)
        {
            trackBarBrightness.Value = 255;
            textBoxInterval.Text = "100";

            string command = "LIGHT_MODE"; //yes
            int lightMode = 2; //yes
            Color? color1 = GetColorFromTextBoxes(1);//yes
            Color? color2 = GetColorFromTextBoxes(2);//yes
            int brightness = trackBarBrightness.Value; //yes
            int interval = int.Parse(textBoxInterval.Text);//yes
            int steps = int.Parse(textBoxSteps.Text);
            string direction = "FORWARD";//yes

            groupBoxColor1.Enabled = true;
            groupBoxColor2.Enabled = true;
            groupBoxBrightness.Enabled = true;
            groupBoxInterval.Enabled = true;
            groupBoxSteps.Enabled = false;
            buttonReverseDirection.Enabled = true;
            groupBoxMusic.Enabled = true;
            if (source != null)
                source.SignalToStop();

            SendLightMode(command, lightMode, color1, color2, brightness, interval, steps, direction);
        }

        private void radioButtonColorWipe_CheckedChanged(object sender, EventArgs e)
        {
            trackBarBrightness.Value = 255;
            textBoxInterval.Text = "25";

            string command = "LIGHT_MODE"; //yes
            int lightMode = 3; //yes
            Color? color1 = GetColorFromTextBoxes(1);//yes
            Color? color2 = GetColorFromTextBoxes(2);//yes
            int brightness = trackBarBrightness.Value; //yes
            int interval = int.Parse(textBoxInterval.Text);//yes
            int steps = int.Parse(textBoxSteps.Text);
            string direction = "FORWARD";//yes

            groupBoxColor1.Enabled = true;
            groupBoxColor2.Enabled = true;
            groupBoxBrightness.Enabled = true;
            groupBoxInterval.Enabled = true;
            groupBoxSteps.Enabled = false;
            buttonReverseDirection.Enabled = true;
            groupBoxMusic.Enabled = true;
            if (source != null)
                source.SignalToStop();

            SendLightMode(command, lightMode, color1, color2, brightness, interval, steps, direction);
        }

        private void radioButtonScanner_CheckedChanged(object sender, EventArgs e)
        {
            trackBarBrightness.Value = 255;
            textBoxInterval.Text = "10";

            string command = "LIGHT_MODE"; //yes
            int lightMode = 4; //yes
            Color? color1 = GetColorFromTextBoxes(1);//yes
            Color? color2 = GetColorFromTextBoxes(2);
            int brightness = trackBarBrightness.Value; //yes
            int interval = int.Parse(textBoxInterval.Text);//yes
            int steps = int.Parse(textBoxSteps.Text);
            string direction = "FORWARD";

            groupBoxColor1.Enabled = true;
            groupBoxColor2.Enabled = false;
            groupBoxBrightness.Enabled = true;
            groupBoxInterval.Enabled = true;
            groupBoxSteps.Enabled = false;
            buttonReverseDirection.Enabled = false;
            groupBoxMusic.Enabled = true;
            if (source != null)
                source.SignalToStop();

            SendLightMode(command, lightMode, color1, color2, brightness, interval, steps, direction);
        }

        private void radioButtonFade_CheckedChanged(object sender, EventArgs e)
        {
            trackBarBrightness.Value = 255;
            textBoxInterval.Text = "50";
            textBoxSteps.Text = "100";

            string command = "LIGHT_MODE"; //yes
            int lightMode = 5; //yes
            Color? color1 = GetColorFromTextBoxes(1);//yes
            Color? color2 = GetColorFromTextBoxes(2);//yes
            int brightness = trackBarBrightness.Value; //yes
            int interval = int.Parse(textBoxInterval.Text);//yes
            int steps = int.Parse(textBoxSteps.Text);
            string direction = "FORWARD";

            groupBoxColor1.Enabled = true;
            groupBoxColor2.Enabled = true;
            groupBoxBrightness.Enabled = true;
            groupBoxInterval.Enabled = true;
            groupBoxSteps.Enabled = true;
            buttonReverseDirection.Enabled = false;
            groupBoxMusic.Enabled = false;
            if (source != null)
                source.SignalToStop();

            SendLightMode(command, lightMode, color1, color2, brightness, interval, steps, direction);
        }

        private void radioButtonRainbowFade_CheckedChanged(object sender, EventArgs e)
        {
            trackBarBrightness.Value = 255;
            textBoxInterval.Text = "50";

            string command = "LIGHT_MODE"; //yes
            int lightMode = 6; //yes
            Color? color1 = GetColorFromTextBoxes(1);
            Color? color2 = GetColorFromTextBoxes(2);
            int brightness = trackBarBrightness.Value; //yes
            int interval = int.Parse(textBoxInterval.Text);//yes
            int steps = 255;//REQUIRED
            string direction = "FORWARD";//yes

            groupBoxColor1.Enabled = false;
            groupBoxColor2.Enabled = false;
            groupBoxBrightness.Enabled = true;
            groupBoxInterval.Enabled = true;
            groupBoxSteps.Enabled = false;
            buttonReverseDirection.Enabled = true;
            groupBoxMusic.Enabled = false;
            if (source != null)
                source.SignalToStop();

            SendLightMode(command, lightMode, color1, color2, brightness, interval, steps, direction);
        }
        #endregion

        #region Color
        private void buttonApplyColor1_Click(object sender, EventArgs e)
        {
            Color? color = GetColorFromTextBoxes(1);

            if(color != null)
                SendCommandWithOneParameter("CHANGE_COLOR_1", color?.ToArgb().ToString(), false);

        }

        private void buttonApplyColor2_Click(object sender, EventArgs e)
        {
            Color? color = GetColorFromTextBoxes(2);

            if(color != null)
                SendCommandWithOneParameter("CHANGE_COLOR_2", color?.ToArgb().ToString(), false);
        }

        private void hueColorSlider_ValueChanged(object sender, EventArgs e)
        {

            if (hueColorSlider.Focused)
            {
                HslColor color = new HslColor(hueColorSlider.Value, 1, .5);
                panelColor1.BackColor = color.ToRgbColor();

                Color rgb = color.ToRgbColor();

                textBoxR1.Text = (rgb.R).ToString();
                textBoxG1.Text = (rgb.G).ToString();
                textBoxB1.Text = (rgb.B).ToString();

                SendCommandWithOneParameter("CHANGE_COLOR_1", rgb.ToArgb().ToString(), true);
            }
        }

        private void hueColorSlider2_ValueChanged(object sender, EventArgs e)
        {
            if (hueColorSlider2.Focused)
            {
                HslColor color = new HslColor(hueColorSlider2.Value, 1, .5);
                panelColor2.BackColor = color.ToRgbColor();

                Color rgb = color.ToRgbColor();

                textBoxR2.Text = (rgb.R).ToString();
                textBoxG2.Text = (rgb.G).ToString();
                textBoxB2.Text = (rgb.B).ToString();

                SendCommandWithOneParameter("CHANGE_COLOR_2", rgb.ToArgb().ToString(), true);
            }
        }

        private void hueColorSlider_MouseUp(object sender, MouseEventArgs e)
        {
            HslColor color = new HslColor(hueColorSlider.Value, 1, .5);
            panelColor1.BackColor = color.ToRgbColor();

            Color rgb = color.ToRgbColor();

            textBoxR1.Text = (rgb.R).ToString();
            textBoxG1.Text = (rgb.G).ToString();
            textBoxB1.Text = (rgb.B).ToString();

            SendCommandWithOneParameter("CHANGE_COLOR_1", rgb.ToArgb().ToString(), false);
        }

        private void hueColorSlider2_MouseUp(object sender, MouseEventArgs e)
        {
            HslColor color = new HslColor(hueColorSlider2.Value, 1, .5);
            panelColor2.BackColor = color.ToRgbColor();

            Color rgb = color.ToRgbColor();

            textBoxR2.Text = (rgb.R).ToString();
            textBoxG2.Text = (rgb.G).ToString();
            textBoxB2.Text = (rgb.B).ToString();

            SendCommandWithOneParameter("CHANGE_COLOR_2", rgb.ToArgb().ToString(), false);
        }

        private void textBoxColors1_TextChanged(object sender, EventArgs e)
        {
            GetColorFromTextBoxes(1);
        }

        private void textBoxColors2_TextChanged(object sender, EventArgs e)
        {
            GetColorFromTextBoxes(2);
        }

        Color? GetColorFromTextBoxes(int colorSet)
        {
            try
            {
                if (colorSet == 1)
                {
                    Color color = Color.FromArgb(int.Parse(textBoxR1.Text), int.Parse(textBoxG1.Text), int.Parse(textBoxB1.Text));
                    panelColor1.BackColor = color;
                    HslColor hsl = new HslColor(color);
                    hueColorSlider.Value = (float)hsl.H;
                    return color;
                }
                else if (colorSet == 2)
                {
                    Color color = Color.FromArgb(int.Parse(textBoxR2.Text), int.Parse(textBoxG2.Text), int.Parse(textBoxB2.Text));
                    panelColor2.BackColor = color;
                    HslColor hsl = new HslColor(color);
                    hueColorSlider2.Value = (float)hsl.H;
                    return color;
                }
                else
                {
                    return Color.White;
                }
            }
            catch (Exception exception)
            {
                //the textbox was empty of contains letters
                return null;
            }
        }

        //Used by the detector_Beat method
        void CoordinateColorInputs(int colorSet, Color color)
        {
            if (colorSet == 1)
            {
                panelColor1.BackColor = color;
                HslColor hsl = new HslColor(color);
                hueColorSlider.Value = (float)hsl.H;

                textBoxR1.Text = (color.R).ToString();
                textBoxG1.Text = (color.G).ToString();
                textBoxB1.Text = (color.B).ToString();
            }
            else if (colorSet == 2)
            {
                panelColor2.BackColor = color;
                HslColor hsl = new HslColor(color);
                hueColorSlider2.Value = (float)hsl.H;

                textBoxR2.Text = (color.R).ToString();
                textBoxG2.Text = (color.G).ToString();
                textBoxB2.Text = (color.B).ToString();
            }
        }
        #endregion

        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            SendCommandWithOneParameter("CHANGE_BRIGHTNESS", trackBar.Value.ToString(), true);
            groupBoxBrightness.Text = "Brightness: " + trackBar.Value;
        }

        private void trackBarBrightness_MouseUp(object sender, MouseEventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            SendCommandWithOneParameter("CHANGE_BRIGHTNESS", trackBar.Value.ToString(), false);
            groupBoxBrightness.Text = "Brightness: " + trackBar.Value;
        }

        private void buttonInterval_Click(object sender, EventArgs e)
        {
            string intervalString = textBoxInterval.Text;
            int interval;
            if(intervalString.Length > 0 && int.TryParse(intervalString, out interval))
            {
                SendCommandWithOneParameter("CHANGE_INTERVAL", interval.ToString(), false);
            }

        }

        private void buttonSteps_Click(object sender, EventArgs e)
        {
            string stepsString = textBoxSteps.Text;
            int steps;
            if (stepsString.Length > 0 && int.TryParse(stepsString, out steps))
            {
                SendCommandWithOneParameter("CHANGE_STEPS", steps.ToString(), false);
            }
        }

        private void buttonReverseDirection_Click(object sender, EventArgs e)
        {
            SendCommandWithOneParameter("CHANGE_DIRECTION", "NONE", false);
        }

        #region Audio
        //Capture from music 
        private IAudioSource source;
        private EnergyBeatDetector detector;
        private Signal current;

        private bool initializing = true;

        private int lastRandomNum = -1;

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                AudioDeviceInfo info = comboBoxMicrophoneSource.SelectedItem as AudioDeviceInfo;

                if (info == null)
                {
                    MessageBox.Show("No audio devices available.");
                    return;
                }


                source = new AudioCaptureDevice(info.Guid);
                initializing = true;
                labelAudioStatus.Text = "Audio Status: Waiting for soundcard...";
                source = new AudioCaptureDevice(info.Guid);
                source.SampleRate = 44100;
                source.DesiredFrameSize = 5000;
                source.NewFrame += Source_NewFrame;

                detector = new EnergyBeatDetector(43);//changed from 43 //could change this to make is longer or shorter segments that are analyzed.
                detector.Beat += new EventHandler(Detector_Beat);

                source.Start();
            });
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if(source != null)
            {
                source.SignalToStop();
                source.Stop();
            }

        }

        private void Source_NewFrame(object sender, NewFrameEventArgs e)
        {
            current = e.Signal;
            
            detector.Detect(current);

            if (initializing)
            {
                initializing = false;
                labelAudioStatus.Invoke((MethodInvoker)delegate ()
                {
                    //label1.Text = "Frame duration (ms): " + current.Duration;
                    labelAudioStatus.Text = "Audio Status: Ready";
                });
            }
        }

        private void Detector_Beat(object sender, EventArgs e)
        {
            try
            {
                //invoke on main thread.
                labelAudioStatus.Invoke((MethodInvoker)delegate ()
                {
                    labelSensitivity.Text = "Sensitivity: " + detector.Sensitivity;

                    if (timerBeats.Enabled == false)
                    {
                        buttonStart.BackColor = Color.LightGreen;

                        Color[] availableColors = new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.FromArgb(0,255,0), Color.Blue, Color.Purple, Color.Magenta };

                        Random randomGen = new Random();
                        int newRandom = randomGen.Next(availableColors.Length);

                        while(newRandom == lastRandomNum)
                        {
                            newRandom = randomGen.Next(availableColors.Length);
                        }

                        lastRandomNum = newRandom;
                        Color randomColor = availableColors[newRandom];

                        CoordinateColorInputs(1, randomColor);
                        SendCommandWithOneParameter("CHANGE_COLOR_1", randomColor.ToArgb().ToString(), false);

                        timerBeats.Start();
                    }
                    else
                    {
                        timerBeats.Stop();
                        timerBeats.Start();
                    }
                });
            }
            catch (Exception exception)
            {
                //crash.
            }
        }

        private void timerBeats_Tick(object sender, EventArgs e)
        {
            timerBeats.Stop();
            buttonStart.BackColor = SystemColors.Control;
        }

        private void buttonApplyTimerInterval_Click(object sender, EventArgs e)
        {
            timerBeats.Interval = int.Parse(textBoxTimerInterval.Text);
        }

        private void buttonApplySensitivity_Click(object sender, EventArgs e)
        {
            detector.AutoSensitivity = false;
            detector.Sensitivity = double.Parse(textBoxSensitivity.Text);
        }

        private void buttonCancelSensitivity_Click(object sender, EventArgs e)
        {
            detector.AutoSensitivity = true;
        }

        private void buttonBuffer_Click(object sender, EventArgs e)
        {
            detector = new EnergyBeatDetector(int.Parse(textBoxBuffer.Text));
            detector.Beat += new EventHandler(Detector_Beat);
        }

        private void buttonFrameSize_Click(object sender, EventArgs e)
        {
            source.DesiredFrameSize = int.Parse(textBoxFrameSize.Text);
        }

        #endregion

        private void buttonFansOn_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("FANS_ON");
            }
        }

        private void buttonFansOff_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("FANS_OFF");
            }
        }
    }
}