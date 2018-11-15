namespace ArduinoController
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.radioButtonNONE = new System.Windows.Forms.RadioButton();
            this.radioButtonSolidColor = new System.Windows.Forms.RadioButton();
            this.radioButtonRainbowCycle = new System.Windows.Forms.RadioButton();
            this.radioButtonTheaterChase = new System.Windows.Forms.RadioButton();
            this.radioButtonScanner = new System.Windows.Forms.RadioButton();
            this.radioButtonFade = new System.Windows.Forms.RadioButton();
            this.radioButtonColorWipe = new System.Windows.Forms.RadioButton();
            this.radioButtonRainbowFade = new System.Windows.Forms.RadioButton();
            this.buttonFansOn = new System.Windows.Forms.Button();
            this.buttonFansOff = new System.Windows.Forms.Button();
            this.groupBoxLightMode = new System.Windows.Forms.GroupBox();
            this.groupBoxFanControl = new System.Windows.Forms.GroupBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.textBoxR1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxG1 = new System.Windows.Forms.TextBox();
            this.textBoxB1 = new System.Windows.Forms.TextBox();
            this.groupBoxColor1 = new System.Windows.Forms.GroupBox();
            this.hueColorSlider = new Cyotek.Windows.Forms.HueColorSlider();
            this.panelColor1 = new System.Windows.Forms.Panel();
            this.buttonApplyColor1 = new System.Windows.Forms.Button();
            this.groupBoxColor2 = new System.Windows.Forms.GroupBox();
            this.hueColorSlider2 = new Cyotek.Windows.Forms.HueColorSlider();
            this.panelColor2 = new System.Windows.Forms.Panel();
            this.buttonApplyColor2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxR2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxG2 = new System.Windows.Forms.TextBox();
            this.textBoxB2 = new System.Windows.Forms.TextBox();
            this.groupBoxBrightness = new System.Windows.Forms.GroupBox();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.labelPortStatus = new System.Windows.Forms.Label();
            this.groupBoxInterval = new System.Windows.Forms.GroupBox();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.buttonInterval = new System.Windows.Forms.Button();
            this.groupBoxSteps = new System.Windows.Forms.GroupBox();
            this.textBoxSteps = new System.Windows.Forms.TextBox();
            this.buttonSteps = new System.Windows.Forms.Button();
            this.buttonReverseDirection = new System.Windows.Forms.Button();
            this.comboBoxMicrophoneSource = new System.Windows.Forms.ComboBox();
            this.labelAudioStatus = new System.Windows.Forms.Label();
            this.timerBeats = new System.Windows.Forms.Timer(this.components);
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textBoxTimerInterval = new System.Windows.Forms.TextBox();
            this.buttonApplyTimerInterval = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.labelSensitivity = new System.Windows.Forms.Label();
            this.textBoxSensitivity = new System.Windows.Forms.TextBox();
            this.buttonApplySensitivity = new System.Windows.Forms.Button();
            this.buttonCancelSensitivity = new System.Windows.Forms.Button();
            this.groupBoxMusic = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonFrameSize = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxFrameSize = new System.Windows.Forms.TextBox();
            this.buttonBuffer = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxBuffer = new System.Windows.Forms.TextBox();
            this.groupBoxLightMode.SuspendLayout();
            this.groupBoxFanControl.SuspendLayout();
            this.groupBoxColor1.SuspendLayout();
            this.groupBoxColor2.SuspendLayout();
            this.groupBoxBrightness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            this.groupBoxInterval.SuspendLayout();
            this.groupBoxSteps.SuspendLayout();
            this.groupBoxMusic.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.PortName = "COM4";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // radioButtonNONE
            // 
            this.radioButtonNONE.AutoSize = true;
            this.radioButtonNONE.Checked = true;
            this.radioButtonNONE.Location = new System.Drawing.Point(8, 23);
            this.radioButtonNONE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonNONE.Name = "radioButtonNONE";
            this.radioButtonNONE.Size = new System.Drawing.Size(52, 20);
            this.radioButtonNONE.TabIndex = 5;
            this.radioButtonNONE.TabStop = true;
            this.radioButtonNONE.Text = "OFF";
            this.radioButtonNONE.UseVisualStyleBackColor = true;
            this.radioButtonNONE.CheckedChanged += new System.EventHandler(this.radioButtonNONE_CheckedChanged);
            // 
            // radioButtonSolidColor
            // 
            this.radioButtonSolidColor.AutoSize = true;
            this.radioButtonSolidColor.Location = new System.Drawing.Point(8, 74);
            this.radioButtonSolidColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonSolidColor.Name = "radioButtonSolidColor";
            this.radioButtonSolidColor.Size = new System.Drawing.Size(92, 20);
            this.radioButtonSolidColor.TabIndex = 6;
            this.radioButtonSolidColor.Text = "Solid Color";
            this.radioButtonSolidColor.UseVisualStyleBackColor = true;
            this.radioButtonSolidColor.CheckedChanged += new System.EventHandler(this.radioButtonSolidColor_CheckedChanged);
            // 
            // radioButtonRainbowCycle
            // 
            this.radioButtonRainbowCycle.AutoSize = true;
            this.radioButtonRainbowCycle.Location = new System.Drawing.Point(8, 103);
            this.radioButtonRainbowCycle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonRainbowCycle.Name = "radioButtonRainbowCycle";
            this.radioButtonRainbowCycle.Size = new System.Drawing.Size(116, 20);
            this.radioButtonRainbowCycle.TabIndex = 7;
            this.radioButtonRainbowCycle.Text = "Rainbow Cycle";
            this.radioButtonRainbowCycle.UseVisualStyleBackColor = true;
            this.radioButtonRainbowCycle.CheckedChanged += new System.EventHandler(this.radioButtonRainbowCycle_CheckedChanged);
            // 
            // radioButtonTheaterChase
            // 
            this.radioButtonTheaterChase.AutoSize = true;
            this.radioButtonTheaterChase.Location = new System.Drawing.Point(8, 133);
            this.radioButtonTheaterChase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonTheaterChase.Name = "radioButtonTheaterChase";
            this.radioButtonTheaterChase.Size = new System.Drawing.Size(115, 20);
            this.radioButtonTheaterChase.TabIndex = 8;
            this.radioButtonTheaterChase.Text = "Theater Chase";
            this.radioButtonTheaterChase.UseVisualStyleBackColor = true;
            this.radioButtonTheaterChase.CheckedChanged += new System.EventHandler(this.radioButtonTheaterChase_CheckedChanged);
            // 
            // radioButtonScanner
            // 
            this.radioButtonScanner.AutoSize = true;
            this.radioButtonScanner.Location = new System.Drawing.Point(7, 190);
            this.radioButtonScanner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonScanner.Name = "radioButtonScanner";
            this.radioButtonScanner.Size = new System.Drawing.Size(76, 20);
            this.radioButtonScanner.TabIndex = 9;
            this.radioButtonScanner.Text = "Scanner";
            this.radioButtonScanner.UseVisualStyleBackColor = true;
            this.radioButtonScanner.CheckedChanged += new System.EventHandler(this.radioButtonScanner_CheckedChanged);
            // 
            // radioButtonFade
            // 
            this.radioButtonFade.AutoSize = true;
            this.radioButtonFade.Location = new System.Drawing.Point(7, 219);
            this.radioButtonFade.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonFade.Name = "radioButtonFade";
            this.radioButtonFade.Size = new System.Drawing.Size(58, 20);
            this.radioButtonFade.TabIndex = 10;
            this.radioButtonFade.Text = "Fade";
            this.radioButtonFade.UseVisualStyleBackColor = true;
            this.radioButtonFade.CheckedChanged += new System.EventHandler(this.radioButtonFade_CheckedChanged);
            // 
            // radioButtonColorWipe
            // 
            this.radioButtonColorWipe.AutoSize = true;
            this.radioButtonColorWipe.Location = new System.Drawing.Point(7, 161);
            this.radioButtonColorWipe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonColorWipe.Name = "radioButtonColorWipe";
            this.radioButtonColorWipe.Size = new System.Drawing.Size(93, 20);
            this.radioButtonColorWipe.TabIndex = 11;
            this.radioButtonColorWipe.Text = "Color Wipe";
            this.radioButtonColorWipe.UseVisualStyleBackColor = true;
            this.radioButtonColorWipe.CheckedChanged += new System.EventHandler(this.radioButtonColorWipe_CheckedChanged);
            // 
            // radioButtonRainbowFade
            // 
            this.radioButtonRainbowFade.AutoSize = true;
            this.radioButtonRainbowFade.Location = new System.Drawing.Point(7, 247);
            this.radioButtonRainbowFade.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonRainbowFade.Name = "radioButtonRainbowFade";
            this.radioButtonRainbowFade.Size = new System.Drawing.Size(114, 20);
            this.radioButtonRainbowFade.TabIndex = 12;
            this.radioButtonRainbowFade.Text = "Rainbow Fade";
            this.radioButtonRainbowFade.UseVisualStyleBackColor = true;
            this.radioButtonRainbowFade.CheckedChanged += new System.EventHandler(this.radioButtonRainbowFade_CheckedChanged);
            // 
            // buttonFansOn
            // 
            this.buttonFansOn.Location = new System.Drawing.Point(8, 23);
            this.buttonFansOn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFansOn.Name = "buttonFansOn";
            this.buttonFansOn.Size = new System.Drawing.Size(100, 28);
            this.buttonFansOn.TabIndex = 13;
            this.buttonFansOn.Text = "Fans On";
            this.buttonFansOn.UseVisualStyleBackColor = true;
            this.buttonFansOn.Click += new System.EventHandler(this.buttonFansOn_Click);
            // 
            // buttonFansOff
            // 
            this.buttonFansOff.Location = new System.Drawing.Point(116, 23);
            this.buttonFansOff.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFansOff.Name = "buttonFansOff";
            this.buttonFansOff.Size = new System.Drawing.Size(100, 28);
            this.buttonFansOff.TabIndex = 14;
            this.buttonFansOff.Text = "Fans Off";
            this.buttonFansOff.UseVisualStyleBackColor = true;
            this.buttonFansOff.Click += new System.EventHandler(this.buttonFansOff_Click);
            // 
            // groupBoxLightMode
            // 
            this.groupBoxLightMode.Controls.Add(this.radioButtonNONE);
            this.groupBoxLightMode.Controls.Add(this.radioButtonSolidColor);
            this.groupBoxLightMode.Controls.Add(this.radioButtonRainbowCycle);
            this.groupBoxLightMode.Controls.Add(this.radioButtonRainbowFade);
            this.groupBoxLightMode.Controls.Add(this.radioButtonTheaterChase);
            this.groupBoxLightMode.Controls.Add(this.radioButtonColorWipe);
            this.groupBoxLightMode.Controls.Add(this.radioButtonScanner);
            this.groupBoxLightMode.Controls.Add(this.radioButtonFade);
            this.groupBoxLightMode.Enabled = false;
            this.groupBoxLightMode.Location = new System.Drawing.Point(16, 15);
            this.groupBoxLightMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLightMode.Name = "groupBoxLightMode";
            this.groupBoxLightMode.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLightMode.Size = new System.Drawing.Size(225, 356);
            this.groupBoxLightMode.TabIndex = 15;
            this.groupBoxLightMode.TabStop = false;
            this.groupBoxLightMode.Text = "Light Mode";
            // 
            // groupBoxFanControl
            // 
            this.groupBoxFanControl.Controls.Add(this.buttonFansOn);
            this.groupBoxFanControl.Controls.Add(this.buttonFansOff);
            this.groupBoxFanControl.Enabled = false;
            this.groupBoxFanControl.Location = new System.Drawing.Point(16, 575);
            this.groupBoxFanControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxFanControl.Name = "groupBoxFanControl";
            this.groupBoxFanControl.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxFanControl.Size = new System.Drawing.Size(225, 65);
            this.groupBoxFanControl.TabIndex = 16;
            this.groupBoxFanControl.TabStop = false;
            this.groupBoxFanControl.Text = "Fan Control";
            // 
            // textBoxR1
            // 
            this.textBoxR1.Location = new System.Drawing.Point(12, 41);
            this.textBoxR1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxR1.MaxLength = 3;
            this.textBoxR1.Name = "textBoxR1";
            this.textBoxR1.Size = new System.Drawing.Size(53, 22);
            this.textBoxR1.TabIndex = 17;
            this.textBoxR1.Text = "255";
            this.textBoxR1.TextChanged += new System.EventHandler(this.textBoxColors1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Green";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Blue";
            // 
            // textBoxG1
            // 
            this.textBoxG1.Location = new System.Drawing.Point(75, 41);
            this.textBoxG1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxG1.MaxLength = 3;
            this.textBoxG1.Name = "textBoxG1";
            this.textBoxG1.Size = new System.Drawing.Size(53, 22);
            this.textBoxG1.TabIndex = 18;
            this.textBoxG1.Text = "0";
            this.textBoxG1.TextChanged += new System.EventHandler(this.textBoxColors1_TextChanged);
            // 
            // textBoxB1
            // 
            this.textBoxB1.Location = new System.Drawing.Point(137, 41);
            this.textBoxB1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxB1.MaxLength = 3;
            this.textBoxB1.Name = "textBoxB1";
            this.textBoxB1.Size = new System.Drawing.Size(53, 22);
            this.textBoxB1.TabIndex = 19;
            this.textBoxB1.Text = "0";
            this.textBoxB1.TextChanged += new System.EventHandler(this.textBoxColors1_TextChanged);
            // 
            // groupBoxColor1
            // 
            this.groupBoxColor1.Controls.Add(this.hueColorSlider);
            this.groupBoxColor1.Controls.Add(this.panelColor1);
            this.groupBoxColor1.Controls.Add(this.buttonApplyColor1);
            this.groupBoxColor1.Controls.Add(this.label1);
            this.groupBoxColor1.Controls.Add(this.label3);
            this.groupBoxColor1.Controls.Add(this.textBoxR1);
            this.groupBoxColor1.Controls.Add(this.label2);
            this.groupBoxColor1.Controls.Add(this.textBoxG1);
            this.groupBoxColor1.Controls.Add(this.textBoxB1);
            this.groupBoxColor1.Enabled = false;
            this.groupBoxColor1.Location = new System.Drawing.Point(249, 15);
            this.groupBoxColor1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxColor1.Name = "groupBoxColor1";
            this.groupBoxColor1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxColor1.Size = new System.Drawing.Size(432, 129);
            this.groupBoxColor1.TabIndex = 23;
            this.groupBoxColor1.TabStop = false;
            this.groupBoxColor1.Text = "Color 1";
            // 
            // hueColorSlider
            // 
            this.hueColorSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hueColorSlider.Location = new System.Drawing.Point(12, 75);
            this.hueColorSlider.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hueColorSlider.Name = "hueColorSlider";
            this.hueColorSlider.Size = new System.Drawing.Size(408, 46);
            this.hueColorSlider.TabIndex = 13;
            this.hueColorSlider.ValueChanged += new System.EventHandler(this.hueColorSlider_ValueChanged);
            this.hueColorSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hueColorSlider_MouseUp);
            // 
            // panelColor1
            // 
            this.panelColor1.BackColor = System.Drawing.Color.Red;
            this.panelColor1.Location = new System.Drawing.Point(203, 14);
            this.panelColor1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelColor1.Name = "panelColor1";
            this.panelColor1.Size = new System.Drawing.Size(109, 57);
            this.panelColor1.TabIndex = 25;
            // 
            // buttonApplyColor1
            // 
            this.buttonApplyColor1.Location = new System.Drawing.Point(320, 41);
            this.buttonApplyColor1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonApplyColor1.Name = "buttonApplyColor1";
            this.buttonApplyColor1.Size = new System.Drawing.Size(100, 28);
            this.buttonApplyColor1.TabIndex = 24;
            this.buttonApplyColor1.Text = "Apply";
            this.buttonApplyColor1.UseVisualStyleBackColor = true;
            this.buttonApplyColor1.Click += new System.EventHandler(this.buttonApplyColor1_Click);
            // 
            // groupBoxColor2
            // 
            this.groupBoxColor2.Controls.Add(this.hueColorSlider2);
            this.groupBoxColor2.Controls.Add(this.panelColor2);
            this.groupBoxColor2.Controls.Add(this.buttonApplyColor2);
            this.groupBoxColor2.Controls.Add(this.label4);
            this.groupBoxColor2.Controls.Add(this.label5);
            this.groupBoxColor2.Controls.Add(this.textBoxR2);
            this.groupBoxColor2.Controls.Add(this.label6);
            this.groupBoxColor2.Controls.Add(this.textBoxG2);
            this.groupBoxColor2.Controls.Add(this.textBoxB2);
            this.groupBoxColor2.Enabled = false;
            this.groupBoxColor2.Location = new System.Drawing.Point(249, 153);
            this.groupBoxColor2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxColor2.Name = "groupBoxColor2";
            this.groupBoxColor2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxColor2.Size = new System.Drawing.Size(432, 130);
            this.groupBoxColor2.TabIndex = 24;
            this.groupBoxColor2.TabStop = false;
            this.groupBoxColor2.Text = "Color 2";
            // 
            // hueColorSlider2
            // 
            this.hueColorSlider2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hueColorSlider2.Location = new System.Drawing.Point(12, 76);
            this.hueColorSlider2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hueColorSlider2.Name = "hueColorSlider2";
            this.hueColorSlider2.Size = new System.Drawing.Size(408, 46);
            this.hueColorSlider2.TabIndex = 26;
            this.hueColorSlider2.Value = 240F;
            this.hueColorSlider2.ValueChanged += new System.EventHandler(this.hueColorSlider2_ValueChanged);
            this.hueColorSlider2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hueColorSlider2_MouseUp);
            // 
            // panelColor2
            // 
            this.panelColor2.BackColor = System.Drawing.Color.Blue;
            this.panelColor2.Location = new System.Drawing.Point(203, 15);
            this.panelColor2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelColor2.Name = "panelColor2";
            this.panelColor2.Size = new System.Drawing.Size(109, 57);
            this.panelColor2.TabIndex = 26;
            // 
            // buttonApplyColor2
            // 
            this.buttonApplyColor2.Location = new System.Drawing.Point(320, 44);
            this.buttonApplyColor2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonApplyColor2.Name = "buttonApplyColor2";
            this.buttonApplyColor2.Size = new System.Drawing.Size(100, 28);
            this.buttonApplyColor2.TabIndex = 26;
            this.buttonApplyColor2.Text = "Apply";
            this.buttonApplyColor2.UseVisualStyleBackColor = true;
            this.buttonApplyColor2.Click += new System.EventHandler(this.buttonApplyColor2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Red";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Blue";
            // 
            // textBoxR2
            // 
            this.textBoxR2.Location = new System.Drawing.Point(12, 41);
            this.textBoxR2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxR2.MaxLength = 3;
            this.textBoxR2.Name = "textBoxR2";
            this.textBoxR2.Size = new System.Drawing.Size(53, 22);
            this.textBoxR2.TabIndex = 17;
            this.textBoxR2.Text = "0";
            this.textBoxR2.TextChanged += new System.EventHandler(this.textBoxColors2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Green";
            // 
            // textBoxG2
            // 
            this.textBoxG2.Location = new System.Drawing.Point(75, 41);
            this.textBoxG2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxG2.MaxLength = 3;
            this.textBoxG2.Name = "textBoxG2";
            this.textBoxG2.Size = new System.Drawing.Size(53, 22);
            this.textBoxG2.TabIndex = 18;
            this.textBoxG2.Text = "0";
            this.textBoxG2.TextChanged += new System.EventHandler(this.textBoxColors2_TextChanged);
            // 
            // textBoxB2
            // 
            this.textBoxB2.Location = new System.Drawing.Point(137, 41);
            this.textBoxB2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxB2.MaxLength = 3;
            this.textBoxB2.Name = "textBoxB2";
            this.textBoxB2.Size = new System.Drawing.Size(53, 22);
            this.textBoxB2.TabIndex = 19;
            this.textBoxB2.Text = "255";
            this.textBoxB2.TextChanged += new System.EventHandler(this.textBoxColors2_TextChanged);
            // 
            // groupBoxBrightness
            // 
            this.groupBoxBrightness.Controls.Add(this.trackBarBrightness);
            this.groupBoxBrightness.Enabled = false;
            this.groupBoxBrightness.Location = new System.Drawing.Point(249, 290);
            this.groupBoxBrightness.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxBrightness.Name = "groupBoxBrightness";
            this.groupBoxBrightness.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxBrightness.Size = new System.Drawing.Size(432, 81);
            this.groupBoxBrightness.TabIndex = 25;
            this.groupBoxBrightness.TabStop = false;
            this.groupBoxBrightness.Text = "Brightness: 255";
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.Location = new System.Drawing.Point(12, 23);
            this.trackBarBrightness.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBarBrightness.Maximum = 255;
            this.trackBarBrightness.Minimum = 1;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(408, 45);
            this.trackBarBrightness.TabIndex = 0;
            this.trackBarBrightness.Value = 255;
            this.trackBarBrightness.Scroll += new System.EventHandler(this.trackBarBrightness_Scroll);
            this.trackBarBrightness.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarBrightness_MouseUp);
            // 
            // labelPortStatus
            // 
            this.labelPortStatus.AutoSize = true;
            this.labelPortStatus.Location = new System.Drawing.Point(249, 624);
            this.labelPortStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPortStatus.Name = "labelPortStatus";
            this.labelPortStatus.Size = new System.Drawing.Size(135, 16);
            this.labelPortStatus.TabIndex = 26;
            this.labelPortStatus.Text = "Serial Port Status: n/a";
            // 
            // groupBoxInterval
            // 
            this.groupBoxInterval.Controls.Add(this.textBoxInterval);
            this.groupBoxInterval.Controls.Add(this.buttonInterval);
            this.groupBoxInterval.Enabled = false;
            this.groupBoxInterval.Location = new System.Drawing.Point(249, 379);
            this.groupBoxInterval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxInterval.Name = "groupBoxInterval";
            this.groupBoxInterval.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxInterval.Size = new System.Drawing.Size(191, 62);
            this.groupBoxInterval.TabIndex = 27;
            this.groupBoxInterval.TabStop = false;
            this.groupBoxInterval.Text = "Interval (ms)";
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(8, 23);
            this.textBoxInterval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxInterval.MaxLength = 5;
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(61, 22);
            this.textBoxInterval.TabIndex = 1;
            this.textBoxInterval.Text = "100";
            // 
            // buttonInterval
            // 
            this.buttonInterval.Location = new System.Drawing.Point(80, 21);
            this.buttonInterval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonInterval.Name = "buttonInterval";
            this.buttonInterval.Size = new System.Drawing.Size(100, 28);
            this.buttonInterval.TabIndex = 0;
            this.buttonInterval.Text = "Apply";
            this.buttonInterval.UseVisualStyleBackColor = true;
            this.buttonInterval.Click += new System.EventHandler(this.buttonInterval_Click);
            // 
            // groupBoxSteps
            // 
            this.groupBoxSteps.Controls.Add(this.textBoxSteps);
            this.groupBoxSteps.Controls.Add(this.buttonSteps);
            this.groupBoxSteps.Enabled = false;
            this.groupBoxSteps.Location = new System.Drawing.Point(447, 379);
            this.groupBoxSteps.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSteps.Name = "groupBoxSteps";
            this.groupBoxSteps.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSteps.Size = new System.Drawing.Size(191, 62);
            this.groupBoxSteps.TabIndex = 28;
            this.groupBoxSteps.TabStop = false;
            this.groupBoxSteps.Text = "Steps (#)";
            // 
            // textBoxSteps
            // 
            this.textBoxSteps.Location = new System.Drawing.Point(8, 23);
            this.textBoxSteps.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSteps.MaxLength = 5;
            this.textBoxSteps.Name = "textBoxSteps";
            this.textBoxSteps.Size = new System.Drawing.Size(61, 22);
            this.textBoxSteps.TabIndex = 1;
            this.textBoxSteps.Text = "100";
            // 
            // buttonSteps
            // 
            this.buttonSteps.Location = new System.Drawing.Point(80, 21);
            this.buttonSteps.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSteps.Name = "buttonSteps";
            this.buttonSteps.Size = new System.Drawing.Size(100, 28);
            this.buttonSteps.TabIndex = 0;
            this.buttonSteps.Text = "Apply";
            this.buttonSteps.UseVisualStyleBackColor = true;
            this.buttonSteps.Click += new System.EventHandler(this.buttonSteps_Click);
            // 
            // buttonReverseDirection
            // 
            this.buttonReverseDirection.Enabled = false;
            this.buttonReverseDirection.Location = new System.Drawing.Point(249, 448);
            this.buttonReverseDirection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonReverseDirection.Name = "buttonReverseDirection";
            this.buttonReverseDirection.Size = new System.Drawing.Size(191, 28);
            this.buttonReverseDirection.TabIndex = 2;
            this.buttonReverseDirection.Text = "Reverse Direction";
            this.buttonReverseDirection.UseVisualStyleBackColor = true;
            this.buttonReverseDirection.Click += new System.EventHandler(this.buttonReverseDirection_Click);
            // 
            // comboBoxMicrophoneSource
            // 
            this.comboBoxMicrophoneSource.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxMicrophoneSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMicrophoneSource.FormattingEnabled = true;
            this.comboBoxMicrophoneSource.Location = new System.Drawing.Point(9, 36);
            this.comboBoxMicrophoneSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxMicrophoneSource.Name = "comboBoxMicrophoneSource";
            this.comboBoxMicrophoneSource.Size = new System.Drawing.Size(205, 24);
            this.comboBoxMicrophoneSource.TabIndex = 14;
            // 
            // labelAudioStatus
            // 
            this.labelAudioStatus.AutoSize = true;
            this.labelAudioStatus.Location = new System.Drawing.Point(9, 18);
            this.labelAudioStatus.Name = "labelAudioStatus";
            this.labelAudioStatus.Size = new System.Drawing.Size(86, 16);
            this.labelAudioStatus.TabIndex = 29;
            this.labelAudioStatus.Text = "Audio Status:";
            // 
            // timerBeats
            // 
            this.timerBeats.Interval = 50;
            this.timerBeats.Tick += new System.EventHandler(this.timerBeats_Tick);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.Control;
            this.buttonStart.Location = new System.Drawing.Point(9, 66);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100, 28);
            this.buttonStart.TabIndex = 30;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(116, 66);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(100, 28);
            this.buttonStop.TabIndex = 31;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // textBoxTimerInterval
            // 
            this.textBoxTimerInterval.Location = new System.Drawing.Point(73, 105);
            this.textBoxTimerInterval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTimerInterval.MaxLength = 5;
            this.textBoxTimerInterval.Name = "textBoxTimerInterval";
            this.textBoxTimerInterval.Size = new System.Drawing.Size(35, 22);
            this.textBoxTimerInterval.TabIndex = 1;
            this.textBoxTimerInterval.Text = "50";
            // 
            // buttonApplyTimerInterval
            // 
            this.buttonApplyTimerInterval.Location = new System.Drawing.Point(116, 102);
            this.buttonApplyTimerInterval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonApplyTimerInterval.Name = "buttonApplyTimerInterval";
            this.buttonApplyTimerInterval.Size = new System.Drawing.Size(100, 28);
            this.buttonApplyTimerInterval.TabIndex = 0;
            this.buttonApplyTimerInterval.Text = "Apply";
            this.buttonApplyTimerInterval.UseVisualStyleBackColor = true;
            this.buttonApplyTimerInterval.Click += new System.EventHandler(this.buttonApplyTimerInterval_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 32;
            this.label7.Text = "Tick (ms)";
            // 
            // labelSensitivity
            // 
            this.labelSensitivity.AutoSize = true;
            this.labelSensitivity.Location = new System.Drawing.Point(9, 138);
            this.labelSensitivity.Name = "labelSensitivity";
            this.labelSensitivity.Size = new System.Drawing.Size(71, 16);
            this.labelSensitivity.TabIndex = 35;
            this.labelSensitivity.Text = "Sensitivity:";
            // 
            // textBoxSensitivity
            // 
            this.textBoxSensitivity.Location = new System.Drawing.Point(13, 158);
            this.textBoxSensitivity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSensitivity.MaxLength = 5;
            this.textBoxSensitivity.Name = "textBoxSensitivity";
            this.textBoxSensitivity.Size = new System.Drawing.Size(95, 22);
            this.textBoxSensitivity.TabIndex = 34;
            this.textBoxSensitivity.Text = "1.5";
            // 
            // buttonApplySensitivity
            // 
            this.buttonApplySensitivity.Location = new System.Drawing.Point(116, 158);
            this.buttonApplySensitivity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonApplySensitivity.Name = "buttonApplySensitivity";
            this.buttonApplySensitivity.Size = new System.Drawing.Size(100, 28);
            this.buttonApplySensitivity.TabIndex = 33;
            this.buttonApplySensitivity.Text = "Apply";
            this.buttonApplySensitivity.UseVisualStyleBackColor = true;
            this.buttonApplySensitivity.Click += new System.EventHandler(this.buttonApplySensitivity_Click);
            // 
            // buttonCancelSensitivity
            // 
            this.buttonCancelSensitivity.Location = new System.Drawing.Point(116, 194);
            this.buttonCancelSensitivity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancelSensitivity.Name = "buttonCancelSensitivity";
            this.buttonCancelSensitivity.Size = new System.Drawing.Size(100, 28);
            this.buttonCancelSensitivity.TabIndex = 36;
            this.buttonCancelSensitivity.Text = "Auto";
            this.buttonCancelSensitivity.UseVisualStyleBackColor = true;
            this.buttonCancelSensitivity.Click += new System.EventHandler(this.buttonCancelSensitivity_Click);
            // 
            // groupBoxMusic
            // 
            this.groupBoxMusic.Controls.Add(this.label10);
            this.groupBoxMusic.Controls.Add(this.buttonFrameSize);
            this.groupBoxMusic.Controls.Add(this.label9);
            this.groupBoxMusic.Controls.Add(this.textBoxFrameSize);
            this.groupBoxMusic.Controls.Add(this.buttonBuffer);
            this.groupBoxMusic.Controls.Add(this.label8);
            this.groupBoxMusic.Controls.Add(this.textBoxBuffer);
            this.groupBoxMusic.Controls.Add(this.labelAudioStatus);
            this.groupBoxMusic.Controls.Add(this.buttonCancelSensitivity);
            this.groupBoxMusic.Controls.Add(this.comboBoxMicrophoneSource);
            this.groupBoxMusic.Controls.Add(this.labelSensitivity);
            this.groupBoxMusic.Controls.Add(this.buttonStart);
            this.groupBoxMusic.Controls.Add(this.textBoxSensitivity);
            this.groupBoxMusic.Controls.Add(this.buttonStop);
            this.groupBoxMusic.Controls.Add(this.buttonApplySensitivity);
            this.groupBoxMusic.Controls.Add(this.buttonApplyTimerInterval);
            this.groupBoxMusic.Controls.Add(this.label7);
            this.groupBoxMusic.Controls.Add(this.textBoxTimerInterval);
            this.groupBoxMusic.Enabled = false;
            this.groupBoxMusic.Location = new System.Drawing.Point(760, 15);
            this.groupBoxMusic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxMusic.Name = "groupBoxMusic";
            this.groupBoxMusic.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxMusic.Size = new System.Drawing.Size(227, 356);
            this.groupBoxMusic.TabIndex = 37;
            this.groupBoxMusic.TabStop = false;
            this.groupBoxMusic.Text = "Color from Music";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 335);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 16);
            this.label10.TabIndex = 43;
            this.label10.Text = "WARNING: UNCHECKED inputs";
            // 
            // buttonFrameSize
            // 
            this.buttonFrameSize.Location = new System.Drawing.Point(116, 299);
            this.buttonFrameSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFrameSize.Name = "buttonFrameSize";
            this.buttonFrameSize.Size = new System.Drawing.Size(100, 28);
            this.buttonFrameSize.TabIndex = 40;
            this.buttonFrameSize.Text = "Apply";
            this.buttonFrameSize.UseVisualStyleBackColor = true;
            this.buttonFrameSize.Click += new System.EventHandler(this.buttonFrameSize_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 282);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 42;
            this.label9.Text = "Frame Size";
            // 
            // textBoxFrameSize
            // 
            this.textBoxFrameSize.Location = new System.Drawing.Point(13, 302);
            this.textBoxFrameSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFrameSize.MaxLength = 5;
            this.textBoxFrameSize.Name = "textBoxFrameSize";
            this.textBoxFrameSize.Size = new System.Drawing.Size(95, 22);
            this.textBoxFrameSize.TabIndex = 41;
            this.textBoxFrameSize.Text = "5000";
            // 
            // buttonBuffer
            // 
            this.buttonBuffer.Location = new System.Drawing.Point(116, 247);
            this.buttonBuffer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBuffer.Name = "buttonBuffer";
            this.buttonBuffer.Size = new System.Drawing.Size(100, 28);
            this.buttonBuffer.TabIndex = 37;
            this.buttonBuffer.Text = "Apply";
            this.buttonBuffer.UseVisualStyleBackColor = true;
            this.buttonBuffer.Click += new System.EventHandler(this.buttonBuffer_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 16);
            this.label8.TabIndex = 39;
            this.label8.Text = "Buffer";
            // 
            // textBoxBuffer
            // 
            this.textBoxBuffer.Location = new System.Drawing.Point(73, 250);
            this.textBoxBuffer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxBuffer.MaxLength = 5;
            this.textBoxBuffer.Name = "textBoxBuffer";
            this.textBoxBuffer.Size = new System.Drawing.Size(35, 22);
            this.textBoxBuffer.TabIndex = 38;
            this.textBoxBuffer.Text = "43";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 654);
            this.Controls.Add(this.groupBoxMusic);
            this.Controls.Add(this.buttonReverseDirection);
            this.Controls.Add(this.groupBoxSteps);
            this.Controls.Add(this.groupBoxInterval);
            this.Controls.Add(this.labelPortStatus);
            this.Controls.Add(this.groupBoxBrightness);
            this.Controls.Add(this.groupBoxColor2);
            this.Controls.Add(this.groupBoxColor1);
            this.Controls.Add(this.groupBoxFanControl);
            this.Controls.Add(this.groupBoxLightMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Arduino Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxLightMode.ResumeLayout(false);
            this.groupBoxLightMode.PerformLayout();
            this.groupBoxFanControl.ResumeLayout(false);
            this.groupBoxColor1.ResumeLayout(false);
            this.groupBoxColor1.PerformLayout();
            this.groupBoxColor2.ResumeLayout(false);
            this.groupBoxColor2.PerformLayout();
            this.groupBoxBrightness.ResumeLayout(false);
            this.groupBoxBrightness.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            this.groupBoxInterval.ResumeLayout(false);
            this.groupBoxInterval.PerformLayout();
            this.groupBoxSteps.ResumeLayout(false);
            this.groupBoxSteps.PerformLayout();
            this.groupBoxMusic.ResumeLayout(false);
            this.groupBoxMusic.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.RadioButton radioButtonNONE;
        private System.Windows.Forms.RadioButton radioButtonSolidColor;
        private System.Windows.Forms.RadioButton radioButtonRainbowCycle;
        private System.Windows.Forms.RadioButton radioButtonTheaterChase;
        private System.Windows.Forms.RadioButton radioButtonScanner;
        private System.Windows.Forms.RadioButton radioButtonFade;
        private System.Windows.Forms.RadioButton radioButtonColorWipe;
        private System.Windows.Forms.RadioButton radioButtonRainbowFade;
        private System.Windows.Forms.Button buttonFansOn;
        private System.Windows.Forms.Button buttonFansOff;
        private System.Windows.Forms.GroupBox groupBoxLightMode;
        private System.Windows.Forms.GroupBox groupBoxFanControl;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.TextBox textBoxR1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxG1;
        private System.Windows.Forms.TextBox textBoxB1;
        private System.Windows.Forms.GroupBox groupBoxColor1;
        private System.Windows.Forms.GroupBox groupBoxColor2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxR2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxG2;
        private System.Windows.Forms.TextBox textBoxB2;
        private System.Windows.Forms.GroupBox groupBoxBrightness;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.Button buttonApplyColor1;
        private System.Windows.Forms.Button buttonApplyColor2;
        private System.Windows.Forms.Panel panelColor1;
        private System.Windows.Forms.Panel panelColor2;
        private System.Windows.Forms.Label labelPortStatus;
        private System.Windows.Forms.GroupBox groupBoxInterval;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.Button buttonInterval;
        private System.Windows.Forms.GroupBox groupBoxSteps;
        private System.Windows.Forms.TextBox textBoxSteps;
        private System.Windows.Forms.Button buttonSteps;
        private System.Windows.Forms.Button buttonReverseDirection;
        private System.Windows.Forms.ComboBox comboBoxMicrophoneSource;
        private System.Windows.Forms.Label labelAudioStatus;
        private System.Windows.Forms.Timer timerBeats;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBoxTimerInterval;
        private System.Windows.Forms.Button buttonApplyTimerInterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelSensitivity;
        private System.Windows.Forms.TextBox textBoxSensitivity;
        private System.Windows.Forms.Button buttonApplySensitivity;
        private System.Windows.Forms.Button buttonCancelSensitivity;
        private System.Windows.Forms.GroupBox groupBoxMusic;
        private System.Windows.Forms.Button buttonBuffer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxBuffer;
        private System.Windows.Forms.Button buttonFrameSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxFrameSize;
        private Cyotek.Windows.Forms.HueColorSlider hueColorSlider;
        private Cyotek.Windows.Forms.HueColorSlider hueColorSlider2;
        private System.Windows.Forms.Label label10;
    }
}

