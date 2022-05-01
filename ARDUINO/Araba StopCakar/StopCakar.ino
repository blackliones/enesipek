
#include <EEPROM.h>
int modeChangeButton = 2;
int cakmaSayiButton = 4;
int currentMode;
int maxMode;
int minMode;
int minSayi;
int maxSayi;
int cakmaSayi;
int delaySpeed;
bool modStart,modEnd;
int i;
int lightPin =3;
void setup() {
 pinMode(modeChangeButton,INPUT);
 pinMode(cakmaSayiButton,INPUT);
 pinMode(lightPin,OUTPUT);
 maxMode = 4;
 minMode = 1;
 minSayi = 1;
 maxSayi = 10;
 currentMode = EEPROM.read(0);
 cakmaSayi = EEPROM.read(1);
Serial.begin(9600);
 modStart=true;
 modEnd=false;
 i=0;
   Serial.print("Cakma Sayisi: ");
         Serial.println(cakmaSayi);
             Serial.print("Current Mode: ");
         Serial.println(currentMode);
 }
void loop() {
if(modStart){
if(i<cakmaSayi){
  delay(500);
  i++;
}
     else if(i>=cakmaSayi){
      modStart=false;
      modEnd=true;
      i=0;
      }
       digitalWrite(lightPin,HIGH);
    delay(delaySpeed);
    digitalWrite(lightPin,LOW);
    delay(delaySpeed);
       digitalWrite(lightPin,HIGH);
    delay(delaySpeed);
    digitalWrite(lightPin,LOW);
}
else if(modEnd){
  digitalWrite(lightPin,HIGH);
}
if(digitalRead(cakmaSayiButton)==HIGH){
       delay(500);
         Serial.print("Cakma Sayisi: ");
         Serial.println(cakmaSayi);
                      EEPROM.write(1,cakmaSayi);
                       if(cakmaSayi<maxSayi){
   cakmaSayi +=1;
        }
           else if(cakmaSayi>=maxSayi){
          cakmaSayi=minSayi;
        }
  }
  if(digitalRead(modeChangeButton)==HIGH){
    delay(500);
      EEPROM.write(0,currentMode);
                             Serial.print("Current Mode: ");
         Serial.println(currentMode);
                           if(currentMode<4){
    currentMode +=1;
       }
           else if(currentMode>=maxMode){
          currentMode=minMode;
        }
    
  }
  if(currentMode == 1){
    delaySpeed = 50;
   }
  else if(currentMode == 2){
    delaySpeed = 100;
       }
   else if(currentMode == 3){
    delaySpeed = 250;
   }
  else if(currentMode == 4){
    delaySpeed = 500;
  }      
      }
