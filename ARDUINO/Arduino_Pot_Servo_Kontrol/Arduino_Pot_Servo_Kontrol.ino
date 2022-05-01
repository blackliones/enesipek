#include <Servo_Hardware_PWM.h>

#define IN_POT1 A0;//potansiyometre 1 pin def 
#define IN_POT2 A1;//potansiyometre 2 pin def 
#define OUT_SERVO1 5;// Servo pwm pin 1
#define OUT_SERVO2 6;// Servo pwm pin 2

Servo servo1;
Servo servo2;

int pot1Deg=0;
int pot2Deg=0;

void setup() {
servo1.attach(OUT_SERVO1);
servo2.attach(OUT_SERVO2);

}

void loop() {
pot1Deg = map(analogRead(IN_POT1),0,1023,0,180);
pot2Deg = map(analogRead(IN_POT2,0,1023,0,180);
servo1.write(pot1Deg);
servo2.write(pot2Deg);
}
