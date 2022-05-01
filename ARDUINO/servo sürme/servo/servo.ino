#include <Servo.h>
Servo servo;
Servo servo2;
byte val ;
byte mal;
byte val1;
byte mal1;
boolean mk;
boolean ml;
boolean mk1;
boolean ml1;
void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  servo.attach(A0);
  servo2.attach(A1);
  val = 0;
  mal = 0;
  servo.write(80);
  servo2.write(60);
  mk = true;
  ml = true;
}

void loop() {
 if (mal >= 180) {
    mk = false;
  }
  else {
    mk = true;
  }
  if (mal == 0) {
    ml = false;
  }
  else {
    ml = true;
  }
  if (mal1 >= 180) {
    mk1 = false;
  }
  else {
    mk1 = true;
  }
  if (mal1 == 0) {
    ml1 = false;
  }
  else {
    ml1 = true;
  }
  if(Serial.available()){
    delay(3);
  int serial = Serial.read();
  // put your main code here, to run repeatedly:
  if (serial == '1'&& mk == true) {
    mal = mal + 10;
    if (mal == 180) {
      mal = 180;
      mk = false;

    }
  }
  if (serial  == '2' && ml == true) {
    mal = mal - 10;
    if (mal == 0) {
      mal = 0;
      ml = false;
    }
  }
    if (serial == '3'&& mk1 == true) {
    mal1 = mal1 + 10;
    if (mal1 == 180) {
      mal1 = 180;
      mk1 = false;

    }
  }
  if (serial  == '4' && ml1 == true) {
    mal1 = mal1 - 10;
    if (mal1 == 0) {
      mal1 = 0;
      ml1 = false;
 
    }
  }
  
  delay(100);
  servo.write(mal);
  servo2.write(mal1);
  }
}
