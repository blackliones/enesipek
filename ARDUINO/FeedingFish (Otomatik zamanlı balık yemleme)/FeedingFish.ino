#include <Servo.h>
#define DS3231_I2C_ADDRESS 0x68
#include "Wire.h"
Servo servo;
bool feeding;
//Time 
float butMil,butRate,curMil,serialMil,startMil,countRate;//count rate sayma aralıgı 1 saniyede 1 saysın gibi
bool timer;
int sn,dk,st,dayofmonth,ay,yl,dayofweek;
int feedTime;//Type of hour
int resButton= 10;
int openGateTime;
byte decToBcd(byte val)
{
  return ( (val / 10 * 16) + (val % 10) );
}
// Convert binary coded decimal to normal decimal numbers
byte bcdToDec(byte val)
{
  return ( (val / 16 * 10) + (val % 16) );
}

void setup() {
  // put your setup code here, to run once:
  Wire.begin();
  Serial.begin(9600);
  /*sn=0;
  dk=8;
  st=0;
   setDS3231time(sn,dk,st,5,17,8,18);
*/
servo.attach(9);
feeding=false;
   servo.write(0);

startMil=millis();
butMil=millis();
serialMil=millis();
countRate=1000;//1000
butRate=500;
feedTime = 2;//Hour
openGateTime=430;
}
void setDS3231time(byte second, byte minute, byte hour, byte dayOfWeek, byte dayOfMonth, byte month, byte year) {
  // sets time and date data to DS3231
  Wire.beginTransmission(DS3231_I2C_ADDRESS);
  Wire.write(0); // set next input to start at the seconds register
  Wire.write(decToBcd(second)); // set seconds
  Wire.write(decToBcd(minute)); // set minutes
  Wire.write(decToBcd(hour)); // set hours
  Wire.write(decToBcd(dayOfWeek)); // set day of week (1=Sunday, 7=Saturday)
  Wire.write(decToBcd(dayOfMonth)); // set date (1 to 31)
  Wire.write(decToBcd(month)); // set month
  Wire.write(decToBcd(year)); // set year (0 to 99)
  Wire.endTransmission();
}
void readDS3231time(byte *second,
                    byte *minute,
                    byte *hour,
                    byte *dayOfWeek,
                    byte *dayOfMonth,
                    byte *month,
                    byte *year)
{
  Wire.beginTransmission(DS3231_I2C_ADDRESS);
  Wire.write(0); // set DS3231 register pointer to 00h
  Wire.endTransmission();
  Wire.requestFrom(DS3231_I2C_ADDRESS, 7);
  // request seven bytes of data from DS3231 starting from register 00h
  *second = bcdToDec(Wire.read() & 0x7f);
  *minute = bcdToDec(Wire.read());
  *hour = bcdToDec(Wire.read() & 0x3f);
  *dayOfWeek = bcdToDec(Wire.read());
  *dayOfMonth = bcdToDec(Wire.read());
  *month = bcdToDec(Wire.read());
  *year = bcdToDec(Wire.read());
}

               
void loop() {
    byte second, minute, hour, dayOfWeek, dayOfMonth, month, year;
  readDS3231time(&second, &minute, &hour, &dayOfWeek, &dayOfMonth, &month,
                 &year);
                 serialYaz();
                 if(hour==19&&minute==30&&second==1){
                 feeding=true;
                 }
                 
  curMil=millis();
  if(digitalRead(resButton)){
    if(curMil-butMil>=butRate){
    Serial.println("TIME RESET");
    butMil=curMil;
      feeding=true;
  }
  }
   
if(feeding){
     servo.write(180);
  delay(openGateTime);
     servo.write(0);
feeding=false;
}
}
  void serialYaz(){
      byte second, minute, hour, dayOfWeek, dayOfMonth, month, year;
  readDS3231time(&second, &minute, &hour, &dayOfWeek, &dayOfMonth, &month,
                 &year);
                 if(curMil-serialMil>=1000)
                 serialMil=curMil;
                  Serial.print(second);
                  Serial.print(",");
                  Serial.print(minute);
                  Serial.print(",");
                  Serial.println(hour);
                                delay(1000);
                 }
