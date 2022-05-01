 /*********************************************************************
This is an example sketch for our Monochrome Nokia 5110 LCD Displays

  Pick one up today in the adafruit shop!
  ------> http://www.adafruit.com/products/338

These displays use SPI to communicate, 4 or 5 pins are required to
interface

Adafruit invests time and resources providing this open source code,
please support Adafruit and open-source hardware by purchasing
products from Adafruit!

Written by Limor Fried/Ladyada  for Adafruit Industries.
BSD license, check license.txt for more information
All text above, and the splash screen must be included in any redistribution
*********************************************************************/

#include <SPI.h>
#include <Adafruit_GFX.h>
#include <Adafruit_PCD8544.h>
// Software SPI (slower updates, more flexible pin options):
Adafruit_PCD8544 display = Adafruit_PCD8544(7, 6, 5, 4, 3);

//buttons: buton1-7/buton2-6/buton3-4
//buzzer: - si 5.pin
//led: pin3
//
int button1= 2;   
int button2= 11;
int button3 = 10;
int sayi = 7;
int buzzer = 5;      
int m1led = 9;     
int sayi2 = 5;

void setup()   {
  pinMode(button1, INPUT);
  pinMode(buzzer, OUTPUT);
  pinMode(button2, INPUT);
  pinMode(button3, INPUT);
  pinMode(m1led, OUTPUT);
     Serial.begin(9600);
   display.begin();
    display.setContrast(40);
    display.clearDisplay();
    display.setRotation(0);
    starting();
          digitalWrite(buzzer, 1);
            delay(1000);
            digitalWrite(buzzer, LOW);
            delay(5000);
            mainmenu();
            Serial.println("Light");
Serial.println("menu2");
Serial.println("menu3");
Serial.println("About..");
            }
void loop () {

       if(digitalRead(button1) == HIGH ){
   sayi = sayi +8;
            display.setCursor(70,sayi);
display.setTextColor(BLACK,WHITE);
display.println("<");
Serial.println(sayi);
if (sayi == 7&15&23&31&39){
sayi = 7;
    display.clearDisplay();
      delay(100);
       mainmenu();
 }
if (sayi == 8&16&24){
   sayi = 8;
  display.clearDisplay();
delay(100);
    m1menu();
             }
if (sayi == 40){
   display.clearDisplay();
   m1menu();
    sayi = 8;
 }
  if (sayi == 47){
     display.clearDisplay();
    mainmenu();
       sayi = 7;
    
}
  
 digitalWrite(buzzer,1);
delay(100);
digitalWrite(buzzer, LOW);
  delay(150);
display.display();
  }
if (digitalRead(button2) == HIGH){
mainmenu();
sayi = 7;
}
if (digitalRead(button3) == HIGH){
if (sayi == 15){
 display.clearDisplay();
           delay(100);
m1menu();
Serial.println("OPENED LIGHT MENU");
    sayi = 8;
      }
  if (sayi == 23){
  Serial.println("MENU2 TAMAM");
  }
if (sayi == 31){
 
  Serial.println("MENU3 TAMAM");
  }
 if (sayi == 39){
 starting();
  Serial.println("Opened ABOUT ");
}  
      if (sayi == 16){
             delay(500);
           analogWrite(m1led, 50);
  Serial.println("Light ON(L)");
                       }
           if (sayi == 24){
            delay(500);
        analogWrite(m1led, 255);
    Serial.println("Light ON(H)");
   }
   if (sayi == 32){
            delay(500);
        digitalWrite(m1led, LOW);
    Serial.println("Light OFF");
   }
  }
}
     void mainmenu() {
      display.clearDisplay();
      delay(200);
                display.setTextSize(1);
      display.setTextColor(BLACK);
    display.setCursor(27,15);
           display.println("Light");
      display.setTextSize(1);
      display.setTextColor(BLACK);
      display.setCursor(27,23);
      display.println("Menu2");
      display.setTextSize(1);
      display.setTextColor(BLACK);
      display.setCursor(27, 31);
      display.println("Menu3");
      display.setTextSize(1);
      display.setTextColor(BLACK);
      display.setCursor(27,39);
      display.println("About..");
      display.setTextSize(1);
       display.setTextColor(WHITE,BLACK);
  display.setCursor(30,0);
  display.println("Menu");
  display.display();
      display.display();
      }
     void m1menu() {
            display.setTextSize(1);
      display.setTextColor(WHITE,BLACK);
    display.setCursor(25,0);
           display.println("LIGHT");
      display.setTextSize(1);
      display.setTextColor(BLACK);
    display.setCursor(5,16);
           display.println("Light ON(L)");
                   display.setTextSize(1);
      display.setTextColor(BLACK);
    display.setCursor(5,24);
           display.println("Light ON(H)");
       display.display();
                     display.setTextSize(1);
      display.setTextColor(BLACK);
    display.setCursor(5,32);
           display.println("Light OFF");
       display.display();
       
      }
      void starting () {
   display.clearDisplay();
        delay(500);
         sayi2 = sayi2 ++;
        display.setTextSize(1);
        display.setTextColor(BLACK);
        display.setCursor(13,0);
        display.println("|-WELCOME-|");
                 display.setTextSize(1);
        display.setTextColor(BLACK);
        display.setCursor(15,15);
        display.println("|Maker By|");
             display.setTextSize(1);
        display.setTextColor(BLACK);
        display.setCursor(15,22);
        display.println("|        |");
                      display.setTextSize(1);
        display.setTextColor(BLACK);
        display.setCursor(15,30);
             display.println("|        |");
                      display.setTextSize(1);
        display.setTextColor(WHITE,BLACK);
        display.setCursor(12,30);
              display.println("*BLACKLION*");
                        display.setTextSize(1);
        display.setTextColor(BLACK);
        display.setCursor(10,38);
              display.println("|-________-|");
                               display.display();
              
               }
              
