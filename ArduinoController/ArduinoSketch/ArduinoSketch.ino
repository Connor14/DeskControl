#include <Adafruit_NeoPixel.h>
//Code taken from: https://learn.adafruit.com/multi-tasking-the-arduino-part-3/deconstructing-the-loop

// Pattern types supported:
enum  pattern { NONE, SOLID_COLOR, RAINBOW_CYCLE, THEATER_CHASE, COLOR_WIPE, SCANNER, FADE, RAINBOW_FADE };
// Patern directions supported:
enum  direction { FORWARD, REVERSE };

// NeoPattern Class - derived from the Adafruit_NeoPixel class
class NeoPatterns : public Adafruit_NeoPixel
{
public:

	// Member Variables:  
	pattern  ActivePattern;  // which pattern is running
	direction Direction = FORWARD;     // direction to run the pattern

	unsigned long Interval;   // milliseconds between updates
	unsigned long lastUpdate; // last update of position

	uint32_t Color1, Color2;  // What colors are in use
	uint16_t TotalSteps;  // total number of steps in the pattern
	uint16_t Index;  // current step within the pattern

	void(*OnComplete)();  // Callback on completion of pattern

						  // Constructor - calls base-class constructor to initialize strip
	NeoPatterns(uint16_t pixels, uint8_t pin, uint8_t type, void(*callback)()) : Adafruit_NeoPixel(pixels, pin, type)
	{
		OnComplete = callback;
	}

	// Update the pattern
	void Update()
	{
		if ((millis() - lastUpdate) > Interval) // time to update
		{
			lastUpdate = millis();
			switch (ActivePattern)
			{
			case SOLID_COLOR:
				ColorSet(Color1);
				show();
				break;
			case RAINBOW_CYCLE:
				RainbowCycleUpdate();
				break;
			case THEATER_CHASE:
				TheaterChaseUpdate();
				break;
			case COLOR_WIPE:
				ColorWipeUpdate();
				break;
			case SCANNER:
				ScannerUpdate();
				break;
			case FADE:
				FadeUpdate();
				break;
			case RAINBOW_FADE:
				RainbowFadeUpdate();
				break;
			default:
				break;
			}
		}
	}

	// Increment the Index and reset at the end
	void Increment()
	{
		if (Direction == FORWARD)
		{
			Index++;
			if (Index >= TotalSteps)
			{
				Index = 0;
				if (OnComplete != NULL)
				{
					OnComplete(); // call the comlpetion callback
				}
			}
		}
		else // Direction == REVERSE
		{
			--Index;
			if (Index <= 0)
			{
				Index = TotalSteps - 1;
				if (OnComplete != NULL)
				{
					OnComplete(); // call the comlpetion callback
				}
			}
		}
	}

	// Reverse pattern direction
	void Reverse()
	{
		if (Direction == FORWARD)
		{
			Direction = REVERSE;
			Index = TotalSteps - 1;
		}
		else
		{
			Direction = FORWARD;
			Index = 0;
		}
	}

	// Initialize for a RainbowCycle
	void RainbowCycle(uint8_t interval, direction dir = FORWARD)
	{
		ActivePattern = RAINBOW_CYCLE;
		Interval = interval;
		TotalSteps = 255;
		Index = 0;
		Direction = dir;
	}

	// Update the Rainbow Cycle Pattern
	void RainbowCycleUpdate()
	{
		for (int i = 0; i< numPixels(); i++)
		{
			setPixelColor(i, Wheel(((i * 256 / numPixels()) + Index) & 255));
		}
		show();
		Increment();
	}

	// Initialize for a Theater Chase
	void TheaterChase(uint32_t color1, uint32_t color2, uint8_t interval, direction dir = FORWARD)
	{
		ActivePattern = THEATER_CHASE;
		Interval = interval;
		TotalSteps = numPixels();
		Color1 = color1;
		Color2 = color2;
		Index = 0;
		Direction = dir;
	}

	// Update the Theater Chase Pattern
	void TheaterChaseUpdate()
	{
		for (int i = 0; i< numPixels(); i++)
		{
			if ((i + Index) % 3 == 0)
			{
				setPixelColor(i, Color1);
			}
			else
			{
				setPixelColor(i, Color2);
			}
		}
		show();
		Increment();
	}

	// Initialize for a ColorWipe
	void ColorWipe(uint32_t color, uint8_t interval, direction dir = FORWARD)
	{
		ActivePattern = COLOR_WIPE;
		Interval = interval;
		TotalSteps = numPixels();
		Color1 = color;
		if (dir == FORWARD)
			Index = 0;
		else
			Index = numPixels() - 1;
		Direction = dir;
	}

	// Update the Color Wipe Pattern
	void ColorWipeUpdate()
	{
		setPixelColor(Index, Color1);
		show();
		Increment();
	}

	// Initialize for a SCANNNER
	void Scanner(uint32_t color1, uint8_t interval)
	{
		ActivePattern = SCANNER;
		Interval = interval;
		TotalSteps = (numPixels() - 1) * 2;
		Color1 = color1;
		Index = 0;
	}

	// Update the Scanner Pattern
	void ScannerUpdate()
	{
		for (int i = 0; i < numPixels(); i++)
		{
			if (i == Index)  // Scan Pixel to the right
			{
				setPixelColor(i, Color1);
			}
			else if (i == TotalSteps - Index) // Scan Pixel to the left
			{
				setPixelColor(i, Color1);
			}
			else // Fading tail
			{
				setPixelColor(i, DimColor(getPixelColor(i)));
			}
		}
		show();
		Increment();
	}

	// Initialize for a Fade
	void Fade(uint32_t color1, uint32_t color2, uint16_t steps, uint8_t interval, direction dir = FORWARD)
	{
		ActivePattern = FADE;
		Interval = interval;
		TotalSteps = steps;
		Color1 = color1;
		Color2 = color2;
		Index = 0;
		Direction = dir;
	}

	// Update the Fade Pattern
	void FadeUpdate()
	{
		// Calculate linear interpolation between Color1 and Color2
		// Optimise order of operations to minimize truncation error
		uint8_t red = ((Red(Color1) * (TotalSteps - Index)) + (Red(Color2) * Index)) / TotalSteps;
		uint8_t green = ((Green(Color1) * (TotalSteps - Index)) + (Green(Color2) * Index)) / TotalSteps;
		uint8_t blue = ((Blue(Color1) * (TotalSteps - Index)) + (Blue(Color2) * Index)) / TotalSteps;

		ColorSet(Color(red, green, blue));
		show();
		Increment();
	}

	void RainbowFade(uint8_t interval, direction dir = FORWARD, uint16_t steps = 256) {
		ActivePattern = RAINBOW_FADE;
		Interval = interval;
		TotalSteps = steps;
		Index = 0;
		Direction = dir;
	}

	void RainbowFadeUpdate() {
		ColorSet(Wheel(Index));
		show();
		Increment();
	}

	// Calculate 50% dimmed version of a color (used by ScannerUpdate)
	uint32_t DimColor(uint32_t color)
	{
		// Shift R, G and B components one bit to the right
		uint32_t dimColor = Color(Red(color) >> 1, Green(color) >> 1, Blue(color) >> 1);
		return dimColor;
	}

	// Set all pixels to a color (synchronously)
	void ColorSet(uint32_t color)
	{
		for (int i = 0; i < numPixels(); i++)
		{
			setPixelColor(i, color);
		}
		show();
	}

	// Returns the Red component of a 32-bit color
	uint8_t Red(uint32_t color)
	{
		return (color >> 16) & 0xFF;
	}

	// Returns the Green component of a 32-bit color
	uint8_t Green(uint32_t color)
	{
		return (color >> 8) & 0xFF;
	}

	// Returns the Blue component of a 32-bit color
	uint8_t Blue(uint32_t color)
	{
		return color & 0xFF;
	}

	// Input a value 0 to 255 to get a color value.
	// The colours are a transition r - g - b - back to r.
	uint32_t Wheel(byte WheelPos)
	{
		WheelPos = 255 - WheelPos;
		if (WheelPos < 85)
		{
			return Color(255 - WheelPos * 3, 0, WheelPos * 3);
		}
		else if (WheelPos < 170)
		{
			WheelPos -= 85;
			return Color(0, WheelPos * 3, 255 - WheelPos * 3);
		}
		else
		{
			WheelPos -= 170;
			return Color(WheelPos * 3, 255 - WheelPos * 3, 0);
		}
	}
};

void StripComplete();
void SticksComplete();

// Define some NeoPatterns for the two rings and the stick
//  as well as some completion routines
NeoPatterns Strip(60, 6, NEO_GRB + NEO_KHZ800, &StripComplete);
//NeoPatterns Strip2(60, 9, NEO_GRB + NEO_KHZ800, &Strip2Complete); //if we want to control 2 strips on different pins
NeoPatterns Sticks(16, 10, NEO_GRB + NEO_KHZ800, &SticksComplete);

int lightMode = -1;
uint16_t interval = 50;
uint32_t color1 = 0;
uint32_t color2 = 0;
uint8_t brightness = 255;
uint16_t steps = 10;

// Initialize everything and prepare to start
void setup()
{
	Serial.begin(9600);

	//pinMode(8, INPUT_PULLUP); //to use a pin as a button input.
	pinMode(8, OUTPUT); // Toggle lights
	pinMode(12, OUTPUT); // Toggle fans

						 // Initialize all the pixelStrips
	Strip.begin();
	Sticks.begin();
}

// Main loop
void loop()
{
	// Update the strip.
	Strip.Update();
	Sticks.Update();
}

/*
SerialEvent occurs whenever a new data comes in the
hardware serial RX.  This routine is run between each
time loop() runs, so using delay inside loop can delay
response.  Multiple bytes of data may be available.
*/
String inputString = "";
void serialEvent() {
	while (Serial.available()) {
		// get the new byte:
		char inChar = (char)Serial.read();

		if (inChar == '\n') { //the string is complete. parse it.
			int commaIndex = inputString.indexOf(',');

			if (commaIndex == -1) { //we must have ONLY a command. Like for LIGHTS_ON or FANS_ON
				String inputCommand = inputString;
				ParseCommandOnly(inputCommand);
				inputString = "";
			}
			else { //we have a comma so we should expect more parameters.
				int secondCommaIndex = inputString.indexOf(',', commaIndex + 1);

				if (secondCommaIndex == -1) { //only one comma
					String inputCommand = inputString.substring(0, commaIndex);
					String inputParameter = inputString.substring(commaIndex + 1);

					ParseCommandWithOneParameter(inputCommand, inputParameter);
					inputString = "";
				}
				else {
					int thirdCommaIndex = inputString.indexOf(',', secondCommaIndex + 1);
					int fourthCommaIndex = inputString.indexOf(',', thirdCommaIndex + 1);
					int fifthCommaIndex = inputString.indexOf(',', fourthCommaIndex + 1);
					int sixthCommaIndex = inputString.indexOf(',', fifthCommaIndex + 1);
					int seventhCommaIndex = inputString.indexOf(',', sixthCommaIndex + 1);

					String inputCommand = inputString.substring(0, commaIndex);
					String inputLightMode = inputString.substring(commaIndex + 1, secondCommaIndex);
					String inputColor1 = inputString.substring(secondCommaIndex + 1, thirdCommaIndex);
					String inputColor2 = inputString.substring(thirdCommaIndex + 1, fourthCommaIndex);
					String inputBrightness = inputString.substring(fourthCommaIndex + 1, fifthCommaIndex);
					String inputInterval = inputString.substring(fifthCommaIndex + 1, sixthCommaIndex);
					String inputSteps = inputString.substring(sixthCommaIndex + 1, seventhCommaIndex);
					String inputDirection = inputString.substring(seventhCommaIndex + 1);

					ParseCommandWithParameters(inputCommand, inputLightMode, inputColor1, inputColor2, inputBrightness, inputInterval, inputSteps, inputDirection);
					inputString = "";
				}
			}
		}
		else {
			inputString += inChar;
		}
	}
}

//------------------------------------------------------------
//Completion Routines - get called on completion of a pattern
//------------------------------------------------------------

// Ring1 Completion Callback
bool colorWipeSecondaryColor = false;
void StripComplete()
{
	if (Strip.ActivePattern == FADE) {
		Strip.Reverse();
	}
	else if (Strip.ActivePattern == COLOR_WIPE) {
		if (colorWipeSecondaryColor) {
			colorWipeSecondaryColor = false;
			Strip.ColorWipe(color2, interval, Strip.Direction);
		}
		else {
			colorWipeSecondaryColor = true;
			Strip.ColorWipe(color1, interval, Strip.Direction);
		}
	}
	else {
		SelectLightModeStrip();
	}

	//Strip.Reverse();
	//if (digitalRead(9) == LOW)  // Button #2 pressed
	//{
	//	// Alternate color-wipe patterns with Ring2
	//	Ring2.Interval = 40;
	//	Ring1.Color1 = Ring1.Wheel(random(255));
	//	Ring1.Interval = 20000;
	//}
	//else  // Retrn to normal
	//{
	//	Ring1.Reverse();
	//}
}

bool colorWipeSecondaryColorSticks = false;
void SticksComplete()
{
	if (Sticks.ActivePattern == FADE) {
		Sticks.Reverse();
	}
	else if (Sticks.ActivePattern == COLOR_WIPE) {
		if (colorWipeSecondaryColorSticks) {
			colorWipeSecondaryColorSticks = false;
			Sticks.ColorWipe(color2, interval, Sticks.Direction);
		}
		else {
			colorWipeSecondaryColorSticks = true;
			Sticks.ColorWipe(color1, interval, Sticks.Direction);
		}
	}
	else {
		SelectLightModeSticks();
	}
}

//------------------------------------------------------------
//Custom utilities
//------------------------------------------------------------

void SelectLightModeStrip() {
	switch (lightMode)
	{
	case 0:
		Strip.Color1 = color1;
		Strip.ActivePattern = SOLID_COLOR;
		Strip.ColorSet(color1);
		break;
	case 1:
		Strip.RainbowCycle(interval, Strip.Direction);
		break;
	case 2:
		Strip.TheaterChase(color1, color2, interval, Strip.Direction);
		break;
	case 3:
		Strip.ColorWipe(color1, interval, Strip.Direction);
		break;
	case 4:
		Strip.Scanner(color1, interval);
		break;
	case 5:
		Strip.Fade(color1, color2, steps, interval, Strip.Direction);
		break;
	case 6:
		Strip.RainbowFade(interval, Strip.Direction, steps);
		break;
	default: //-1
		Strip.ActivePattern = NONE;
		Strip.clear();
		break;
	}

	if (lightMode >= 0) {
		digitalWrite(8, HIGH);
	}
	else {
		digitalWrite(8, LOW);
	}

	//Serial.println("SelectLightMode");

}

void SelectLightModeSticks() {
	switch (lightMode)
	{
	case 0:
		Sticks.Color1 = color1;
		Sticks.ActivePattern = SOLID_COLOR;
		Sticks.ColorSet(color1);
		break;
	case 1:
		Sticks.RainbowCycle(interval, Sticks.Direction);
		break;
	case 2:
		Sticks.TheaterChase(color1, color2, interval, Sticks.Direction);
		break;
	case 3:
		Sticks.ColorWipe(color1, interval, Sticks.Direction);
		break;
	case 4:
		Sticks.Scanner(color1, interval);
		break;
	case 5:
		Sticks.Fade(color1, color2, steps, interval, Sticks.Direction);
		break;
	case 6:
		Sticks.RainbowFade(interval, Sticks.Direction, steps);
		break;
	default: //-1
		Sticks.ActivePattern = NONE;
		Sticks.clear();
		break;
	}

	if (lightMode >= 0) {
		digitalWrite(8, HIGH);
	}
	else {
		digitalWrite(8, LOW);
	}

	//Serial.println("SelectLightMode");

}

void ParseCommandOnly(String inputCommand) {
	if (inputCommand == "FANS_ON") {
		digitalWrite(12, HIGH);
	}
	else if (inputCommand == "FANS_OFF") {
		digitalWrite(12, LOW);
	}
	else if (inputCommand == "ALL_OFF") { //turn everything off and reset everything
		Strip.ActivePattern = NONE;
		Strip.clear();

		Sticks.ActivePattern = NONE;
		Sticks.clear();

		lightMode = -1;
		digitalWrite(8, LOW);
		digitalWrite(12, LOW);

		SelectLightModeStrip();
		SelectLightModeSticks();
	}
	//Serial.println("BEGIN CONFIRM: COMMAND: " + inputCommand + " END CONFIRM.");
}

void ParseCommandWithOneParameter(String inputCommand, String parameter) {

	if (inputCommand == "CHANGE_COLOR_1") {
		uint32_t r1 = Strip.Red((uint32_t)parameter.toInt());
		uint32_t g1 = Strip.Green((uint32_t)parameter.toInt());
		uint32_t b1 = Strip.Blue((uint32_t)parameter.toInt());
		uint32_t newColor1 = Strip.Color(r1, g1, b1);
		color1 = newColor1;

		Strip.Color1 = color1;
		Sticks.Color1 = color1;
	}
	else if (inputCommand == "CHANGE_COLOR_2") {
		uint32_t r2 = Strip.Red((uint32_t)parameter.toInt());
		uint32_t g2 = Strip.Green((uint32_t)parameter.toInt());
		uint32_t b2 = Strip.Blue((uint32_t)parameter.toInt());
		uint32_t newColor2 = Strip.Color(r2, g2, b2);
		color2 = newColor2;

		Strip.Color2 = color2;
		Sticks.Color2 = color2;
	}
	else if (inputCommand == "CHANGE_BRIGHTNESS") {
		uint8_t newBrightness = (uint8_t)parameter.toInt();
		brightness = newBrightness;

		Strip.setBrightness(brightness);
		Sticks.setBrightness(brightness);
	}
	else if (inputCommand == "CHANGE_INTERVAL") {
		uint16_t newInterval = (uint16_t)parameter.toInt();
		interval = newInterval;

		Strip.Interval = interval;
		Sticks.Interval = interval;
	}
	else if (inputCommand == "CHANGE_STEPS") {
		if (Strip.ActivePattern == FADE) {
			uint16_t newSteps = (uint16_t)parameter.toInt();
			steps = newSteps;

			Strip.TotalSteps = steps;
			Sticks.TotalSteps = steps;
		}
	}
	else if (inputCommand == "CHANGE_DIRECTION") {
		pattern pat = Strip.ActivePattern;
		if (pat == RAINBOW_FADE || pat == RAINBOW_CYCLE || pat == THEATER_CHASE || pat == COLOR_WIPE) {
			Strip.Reverse();
			Sticks.Reverse();
		}
	}

	//Serial.println("BEGIN CONFIRM: COMMAND WITH ONE PARAMETER: " + inputCommand + " " + lightMode + " " + interval + " " + steps + " " + " END CONFIRM.");
}

void ParseCommandWithParameters(String inputCommand, String inputLightMode, String inputColor1, String inputColor2, String inputBrightness, String inputInterval, String inputSteps, String inputDirection) {

	int newLightMode = (int)inputLightMode.toInt();
	uint16_t newInterval = (uint16_t)inputInterval.toInt();
	uint16_t newSteps = (uint16_t)inputSteps.toInt();
	uint8_t newBrightness = (uint8_t)inputBrightness.toInt();

	uint32_t r1 = Strip.Red((uint32_t)inputColor1.toInt());
	uint32_t g1 = Strip.Green((uint32_t)inputColor1.toInt());
	uint32_t b1 = Strip.Blue((uint32_t)inputColor1.toInt());
	uint32_t newColor1 = Strip.Color(r1, g1, b1);

	uint32_t r2 = Strip.Red((uint32_t)inputColor2.toInt());
	uint32_t g2 = Strip.Green((uint32_t)inputColor2.toInt());
	uint32_t b2 = Strip.Blue((uint32_t)inputColor2.toInt());
	uint32_t newColor2 = Strip.Color(r2, g2, b2);

	String newForwardReverse = inputDirection;

	if (inputCommand == "LIGHT_MODE") {
		Strip.ActivePattern = NONE;
		Strip.clear();

		Sticks.ActivePattern = NONE;
		Sticks.clear();

		lightMode = newLightMode;
		interval = newInterval;
		steps = newSteps;
		color1 = newColor1;
		color2 = newColor2;
		brightness = newBrightness;

		//forwardReverse = inputDirection;
		if (inputDirection == "FORWARD") {
			Strip.Direction = FORWARD;
			Sticks.Direction = FORWARD;
		}
		else
		{
			Strip.Direction = REVERSE;
			Sticks.Direction = REVERSE;
		}

		Strip.setBrightness(brightness);
		Sticks.setBrightness(brightness);
		SelectLightModeStrip();
		SelectLightModeSticks();
	}

	//Serial.println("BEGIN CONFIRM: COMMAND WITH PARAMETERS: " + inputCommand + " " + lightMode + " " + interval + " " + steps + " " + " END CONFIRM.");
}