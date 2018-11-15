# DeskControl
Arduino controlled laptop cooling fans and desk lighting

<img src="https://github.com/Connor14/DeskControl/raw/master/Showcase/showcase_rgb.jpg" width="250" />

See the project in action: https://imgur.com/gallery/r6DBH

### ArduinoController
A Windows Forms application written in C# that communicates over USB (serial) to the Arduino UNO to control the lighting and the fans. 

The Arduino code is also contained in the Visual Studio solution. Most of the code was sourced from Adafruit and then customized.

### PCB
A custom designed PCB designed to act as a hub for Adafruit NeoPixel LED strips.

The PCB was designed using 123D Circuits which shutdown in August, 2018. My original design files are gone due to the 123D Circuits shutdown, so OSH Park managed to send me my production data files.

The PCBs were printed through a company called OSH Park.

PCB images:

<img src="https://github.com/Connor14/DeskControl/raw/master/PCB/pcb_front.png" width="250" />

<img src="https://github.com/Connor14/DeskControl/raw/master/PCB/pcb_back.png" width="250" />

### Inventor
The set of 3D models used for 3D printing my laptop cooling stand. 

The Inventor .ipt files were exported as STL models for 3D printing. 