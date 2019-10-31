#include <Wire.h>


const int sampleWindow = 50; // Sample window width in milliseconds
int bendPin = A0;
int ledPin = 9;
int bendval;

void setup() {
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);
  pinMode(bendPin, INPUT);

}
void loop() {

  unsigned long start = millis(); // Start of sample window
  unsigned int peakToPeak = 0;   // peak-to-peak level
  unsigned int signalMax = 0;
  unsigned int signalMin = 1024;

  // collect data for 50 miliseconds
  while (millis() - start < sampleWindow)
  {
    bendval = analogRead(bendPin);
    if (bendval < 1024)  //This is the max of the 10-bit ADC so this loop will include all readings
    {
      if (bendval > signalMax)
      {
        signalMax = bendval;  // save just the max levels
      }
      else if (bendval < signalMin)
      {
        signalMin = bendval;  // save just the min levels
      }
    }
  }
  peakToPeak = signalMax - signalMin;  // max - min = peak-peak amplitude
  double volts = (peakToPeak * 3.3) / 1024;  // convert to volts


  //Mic troubleshoot with LED
  //Serial.println(volts);
  if (volts >= 1.0)
  {
    digitalWrite(ledPin, HIGH);
    delay(50);
  }
  else
  {
    digitalWrite(ledPin, LOW);
  }
  if (bendval >= 980)
  {
    Serial.write(1); 
    Serial.flush();
    delay (20);
  }
  else 
  {
    Serial.write(2);
    Serial.flush();
    delay(20);
  }
    
   //   Serial.println(bendval);
}
