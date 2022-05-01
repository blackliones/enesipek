#include <SPI.h>
#include <Wire.h>
#include <Adafruit_SSD1306.h>
#include <EEPROM.h>
#include <IRremote.h>
#include <oledIIC.h>
Adafruit_SSD1306 display(4);
#define BT 2//Top Button
#define BM 3//Middle Button
#define BB 5 //Bot Button

unsigned long mtime,sleeptime,mildelay;
byte pageVal,selectedItem;
bool buttonsactive;
char* items[5]={"","","","",""};
void setup() {
  Serial.begin(9600);
  pinMode(BT,INPUT_PULLUP);
  pinMode(BM,INPUT_PULLUP);
  pinMode(BB,INPUT_PULLUP);
display.begin(SSD1306_SWITCHCAPVCC, 0x3C);
display.clearDisplay();
display.setTextColor(WHITE);
 startingsc();
}

void loop() {
mtime=millis();
if(buttonsactive){
  if(digitalRead(BB)&&mtime-mildelay>500){
   if(selectedItem<10){
    selectedItem++;
   }
   else if(selectedItem>=10){
    selectedItem=1;
   }
  mildelay=mtime;
   display.clearDisplay();
    mainMenu();
  }
   else if(digitalRead(BM)&&mtime-mildelay>500){
         mildelay=mtime;
         mbutton();
  }
 else if(digitalRead(BT)&&mtime-mildelay>500){
       if(selectedItem>1){
    selectedItem--;
   }
   else if(selectedItem<=1){
    selectedItem=10;
   }
    mildelay=mtime;
    display.clearDisplay();
    mainMenu();
  }
}

}
void startingsc(){
  display.clearDisplay();
swText("WELCOME TO",35,0,1,'b');
swText("|SMART HOME|",28,15,1,'b');
swText("Made BY:Jazz Corp",12,24,1,'b');
delay(1000);
pageVal=1;
selectedItem=1;
sleeptime=0;
mildelay=0;
buttonsactive=true;
mainMenu();
}
// swText(string,x,y,tsize,tcolor('b'/'w'));
void swText(char * text,float x,float y,int tsize,char tcolor){//X: 0-120, Y: 0-7
display.setTextSize(1);
if(tcolor=='b'){
display.setTextColor(WHITE,BLACK);
}
else{
  display.setTextColor(BLACK,WHITE);
}
  display.setCursor(x,y);
  display.print(text);
  display.display();
}
void mainMenu(){
 display.clearDisplay();
items[0]="Q1:";
items[1]="Q2:"; 
items[2]="Q3:";
items[3]="Q4:";
items[4]="Q5:";
items[5]="Q6:";
/*if(itemstatus[0]){items[0]+="ON";}else{items[0]+="OFF";}
if(itemstatus[1]){items[1]+="ON";}else{items[1]+="OFF";}
if(itemstatus[2]){items[2]+="ON";}else{items[2]+="OFF";}
if(itemstatus[3]){items[3]+="ON";}else{items[3]+="OFF";}
if(itemstatus[4]){items[4]+="ON";}else{items[4]+="OFF";}*/
  if(pageVal==1){
       display.fillRect(0,0,120,8,WHITE);
  switch(selectedItem){
    case 1:
    swText("PAGE:1",2,0.8f,1,'b');
    swText("STATUS",90,0.8f,1,'w');
     display.drawFastVLine(0, 8, 40,WHITE);
    display.drawFastVLine(39, 8, 40,WHITE);
    display.drawFastVLine(79, 8, 40,WHITE);
      display.drawFastHLine(0, 20, 120,WHITE);
      swText(items[0],2,10,1,'w');
   swText(items[1],2,23,1,'b');
    swText(items[2],42,10,1,'b');
     swText(items[3],42,23,1,'b');
      swText(items[4],82,10,1,'b');
          swText(items[5],82,23,1,'b');
 break;
  case 2:
  swText("PAGE:1",2,0.8f,1,'b');
swText("STATUS",90,0.8f,1,'w');
   display.drawFastVLine(0, 8, 40,WHITE);
    display.drawFastVLine(39, 8, 40,WHITE);
    display.drawFastVLine(79, 8, 40,WHITE);
      display.drawFastHLine(0, 20, 120,WHITE);
       swText(items[0],2,10,1,'wb');
   swText(items[1],2,23,1,'w');
    swText(items[2],42,10,1,'b');
     swText(items[3],42,23,1,'b');
      swText(items[4],82,10,1,'b');
          swText(items[5],82,23,1,'b');
 break;
  case 3:
  swText("PAGE:1",2,0.8f,1,'b');
  swText("STATUS",90,0.8f,1,'w');
   display.drawFastVLine(0, 8, 40,WHITE);
    display.drawFastVLine(39, 8, 40,WHITE);
    display.drawFastVLine(79, 8, 40,WHITE);
      display.drawFastHLine(0, 20, 120,WHITE);
    
  swText(items[0],2,10,1,'b');
   swText(items[1],2,23,1,'b');
    swText(items[2],42,10,1,'w');
     swText(items[3],42,23,1,'b');
      swText(items[4],82,10,1,'b');
          swText(items[5],82,23,1,'b');
 break;
  case 4:
  swText("PAGE:1",2,0.8f,1,'b');
  swText("STATUS",90,0.8f,1,'w');
   display.drawFastVLine(0, 8, 40,WHITE);
    display.drawFastVLine(39, 8, 40,WHITE);
    display.drawFastVLine(79, 8, 40,WHITE);
      display.drawFastHLine(0, 20, 120,WHITE);
      swText(items[0],2,10,1,'b');
   swText(items[1],2,23,1,'b');
    swText(items[2],42,10,1,'b');
     swText(items[3],42,23,1,'w');
      swText(items[4],82,10,1,'b');
          swText(items[5],82,23,1,'b');
 break;
  case 5:
  swText("PAGE:1",2,0.8f,1,'b');
  swText("STATUS",90,0.8f,1,'w');
   display.drawFastVLine(0, 8, 40,WHITE);
    display.drawFastVLine(39, 8, 40,WHITE);
    display.drawFastVLine(79, 8, 40,WHITE);
      display.drawFastHLine(0, 20, 120,WHITE);
     swText(items[0],2,10,1,'b');
   swText(items[1],2,23,1,'b');
    swText(items[2],42,10,1,'b');
     swText(items[3],42,23,1,'b');
      swText(items[4],82,10,1,'w');
          swText(items[5],82,23,1,'b');
 break;
  case 6:
  swText("PAGE:1",2,0.8f,1,'b');
  swText("STATUS",90,0.8f,1,'w');
   display.drawFastVLine(0, 8, 40,WHITE);
    display.drawFastVLine(39, 8, 40,WHITE);
    display.drawFastVLine(79, 8, 40,WHITE);
      display.drawFastHLine(0, 20, 120,WHITE);
     
  swText(items[0],2,10,1,'b');
   swText(items[1],2,23,1,'b');
    swText(items[2],42,10,1,'b');
     swText(items[3],42,23,1,'b');
      swText(items[4],82,10,1,'b');
          swText(items[5],82,23,1,'w');
 break;
 case 7:
 swText("OPTIONS",85,0.8f,1,'w');
  display.drawFastVLine(42, 8, 40,WHITE);
  display.drawFastHLine(0, 20, 120,WHITE);
 swText("PAGE:2",2,0.8f,1,'b');
  swText("ITEM-1",2,10,1,'w');
   swText("ITEM-2",2,23,1,'b');
       swText("ITEM-3",55,10,1,'b');
        swText("SETTINGS",55,23,1,'b');
  break;
 case 8:
 swText("OPTIONS",85,0.8f,1,'w');
   display.drawFastVLine(42, 8, 40,WHITE);
  display.drawFastHLine(0, 20, 120,WHITE);
 swText("PAGE:2",2,0.8f,1,'b');
  swText("ITEM-1",2,10,1,'b');
   swText("ITEM-2",2,23,1,'w');
    swText("ITEM-3",55,10,1,'b');
     swText("SETTINGS",55,23,1,'b');
 break;
 case 9:
 swText("OPTIONS",85,0.8f,1,'w');
   display.drawFastVLine(42, 8, 40,WHITE);
  display.drawFastHLine(0, 20, 120,WHITE);
 swText("PAGE:2",2,0.8f,1,'b');
  swText("ITEM-1",2,10,1,'b');
   swText("ITEM-2",2,23,1,'b');
    swText("ITEM-3",55,10,1,'w');
     swText("SETTINGS",55,23,1,'b');
     break;
      case 10:
      swText("OPTIONS",85,0.8f,1,'w');
        display.drawFastVLine(42, 8, 40,WHITE);
  display.drawFastHLine(0, 20, 120,WHITE);
 swText("PAGE:2",2,0.8f,1,'b');
  swText("ITEM-1",2,10,1,'b');
   swText("ITEM-2",2,23,1,'b');
    swText("ITEM-3",55,10,1,'b');
     swText("SETTINGS",55,23,1,'w');
     break;
 }
}
}
void mbutton(){
  
  }
