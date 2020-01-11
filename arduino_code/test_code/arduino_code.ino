void setup()
{
  Serial.begin(38400);
}

void loop()
{
  float value[] = {analogRead(0), analogRead(1), analogRead(2), analogRead(3)};
  Serial.print(map(value[0], 0, 1023, 0, 359));
  Serial.print(",");
  Serial.print(map(value[1], 0, 1023, 0, 359));
  Serial.print(",");
  Serial.print(map(value[2], 0, 1023, 0, 359));
  Serial.print(",");
  Serial.print(map(value[3], 0, 1023, 0, 359));
  Serial.println();
  Serial.flush();
  delay(25);
}
