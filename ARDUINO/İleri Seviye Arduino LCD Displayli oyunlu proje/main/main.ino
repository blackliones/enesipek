#include <LCD5110_Graph.h>//V1.0
#include <dht11.h>
#include "Wire.h"
#include <EEPROM.h>
#define DS3231_I2C_ADDRESS 0x68
dht11 DHT11;
#define DHT11PIN 2 //dht pin 2
//SCK-MOSI-DC-RST-CS
LCD5110 myGLCD(8,9,10,11,12); 
static const byte glyph[] = { B00010000, B00110100, B00110000, B00110100, B00010000 };
String fname;
byte decToBcd(byte val)
{
  return ( (val / 10 * 16) + (val % 10) );
}
// Convert binary coded decimal to normal decimal numbers
byte bcdToDec(byte val) 
{
  return ( (val / 16 * 10) + (val % 16) );
}
extern unsigned char SmallFont[];
extern unsigned char BigNumbers[];
extern unsigned char MediumNumbers[];
extern unsigned char TinyFont[];
extern uint8_t gemi[];
extern uint8_t plane[];
extern uint8_t bullet[];
extern uint8_t enemy[];
extern uint8_t changeleftmusic[];
extern uint8_t changerightmusic[];
extern uint8_t playbtnchange[];
extern uint8_t changeleftpaused[];
extern uint8_t changerightpaused[];
extern uint8_t pausedbgorj[];
extern uint8_t dogrusicaklikbmp[];
extern uint8_t yanlissicaklikbmp[];
extern uint8_t upvolume[];
extern uint8_t downvolume[];
extern uint8_t man1[];
extern uint8_t man2[];
extern uint8_t man3[];
extern uint8_t man4[];
extern uint8_t man5[];
extern uint8_t man6[];
extern uint8_t man7[];
extern uint8_t parlaklik0[];
extern uint8_t parlaklik10[];
extern uint8_t parlaklik20[];
extern uint8_t parlaklik30[];
extern uint8_t parlaklik40[];
extern uint8_t parlaklik50[];
extern uint8_t parlaklik60[];
extern uint8_t parlaklik70[];
extern uint8_t parlaklik80[];
extern uint8_t parlaklik90[];
extern uint8_t parlaklik100[];
byte bottombtn = 14;
byte  enterbuton = 9;
byte backbuton = 8;
byte topbuton = 13;
bool sleep;
bool anaekranbool=false;
bool settime;
bool mute;
String musicstr;
int musicval=0;
//GAME CONTROLS
int Planemaxscore=0;
int Defendermaxscore=0;
int targetscore;
int minx,miny;
int maxx,maxy;
int level;
int score;
unsigned long  lastTime= 0,presentTime=0;
int delayTime=0;
int gameonled=35;
int timePlane;
bool borned;
bool enemymove;
//Buttons Control
bool tbtn, bbtn, exbtn, enbtn;
//Buttons Gaming
bool gtopbool,gbotbool,grightbool,gleftbool;
bool Planebool;
bool ates;
bool Defenderbool;
bool bossstate;
bool paused;
//Plane KOORDİNATLAR
int Planex;
int Planey;
int kalanx1,kalany1;
int kalanx2,kalany2;
int kalanx3,kalany3;
//Defender Gemi Koordinatlar
int gemix;
int bulletx;
int bullety;
int enemyx;
int enemyy;
int defkalanx1,defkalany1;
//---------------------
int adress, value, lightlevel, lightbarval;
static int brightness;
static int specialvalue;
static int sayi = 2;
static int setsayi;
bool gunayarbool;
int gunxpos;
int buzzer = 12;
//GAMİNG BUTTON'S D31right,D32left,D33bot,D34top
int grightbtn=31;
int gleftbtn=32;
int gbotbtn=33;
int gtopbtn=34;
int speground ;
int targetx1,targety1;
int targetx2,targety2;
int targetbossx,targetbossy;
String gun;
int mselect;
int dk;
int sn;
int st;
int gn;
int ay;
int yl;
int currentDayval;
int melodypage;
String mutetext;

String currentDay;
bool sdcardstate;
const int background = 44;
//GAME VALUES
String gamename="NULL GAME";
void setup() {
 Planex=84/2;
  Planey=48/2;
   Planebool=false;
    Wire.begin();
  // put your setup code here, to run once:
  Serial.begin(9600);
  myGLCD.InitLCD();
 myGLCD.setContrast(55);
  myGLCD.setFont(SmallFont);
  pinMode(bottombtn, INPUT);
  pinMode(enterbuton, INPUT);
  pinMode(backbuton, INPUT);
   pinMode(topbuton, INPUT);
       pinMode(gtopbtn,INPUT);
  pinMode(gbotbtn,INPUT);
   pinMode(grightbtn,INPUT);
   borned=false;
  pinMode(gleftbtn,INPUT);
   pinMode(buzzer , OUTPUT);
   enemymove=false;
   musicstr="NULL";
      bossstate=false;
      musicval=0;
   minx=0;
  miny=0;
  ates=false;
maxx=84;
maxy=44;
paused=false;
  score=0;
  level=0;
  pinMode(gameonled,OUTPUT);
      brightness = EEPROM.read(1);
  mute = EEPROM.read(2);
  Planemaxscore=EEPROM.read(3);
  Defendermaxscore=EEPROM.read(4);
  mselect = 0;
  tbtn = true;
  exbtn = true;
  enbtn = true;
  bbtn = true;
  gtopbool=false;
  gbotbool=false;
  gleftbool=false;
  grightbool=false;
  digitalWrite(gameonled,LOW);
  start();
  
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
void displayTime() {
  byte second, minute, hour, dayOfWeek, dayOfMonth, month, year;
  // retrieve data from DS3231
  readDS3231time(&second, &minute, &hour, &dayOfWeek, &dayOfMonth, &month,
                 &year);
  // send it to the serial monitor
  if (mselect == 2) {
     myGLCD.drawLine(0, 24, 84, 24);
      myGLCD.print("SAAT", 30, 2);
         myGLCD.drawRect(25, 0, 58, 10);
    myGLCD.print("TARIH", 27, 27);
       myGLCD.drawRect(25, 25, 60, 35);
 
    if (hour < 10) {
      myGLCD.print("0", 11, 15);
      myGLCD.printNumI(hour, 17, 15);
    }
    else if (hour >= 10) {
      myGLCD.printNumI(hour, 11, 15);
    }
    myGLCD.print(":", 25, 15);

    if (minute < 10)
    {
      myGLCD.print("0", 34, 15);
      myGLCD.printNumI(minute, 40, 15);
    }
    else if (minute >= 10) {
      myGLCD.printNumI(minute, 35, 15);
    }
    myGLCD.print(":", 50, 15);
    if (second < 10)
    {
      myGLCD.print("0", 58, 15);
      myGLCD.printNumI(second, 64, 15);
    }
    else if (second >= 10) {
      myGLCD.printNumI(second, 58, 15);
    }
    myGLCD.printNumI(dayOfMonth, 11, 38);
    myGLCD.print("/", 25, 38);
    myGLCD.printNumI(month, 35, 38);
    myGLCD.print("/", 51, 38);
    myGLCD.printNumI(year, 60, 38);
  }
  if (mselect == -1) {
    myGLCD.setFont(SmallFont);
    myGLCD.print("O", 40, 7);
    myGLCD.print("O", 40, 17);
    myGLCD.setFont(BigNumbers);

    if (hour < 10) {
      myGLCD.print("0", 10, 3);
      myGLCD.printNumI(hour, 25, 3);
    }
    else if (hour >= 10) {
      myGLCD.printNumI(hour, 7, 3);
    }
    if (minute < 10) {
      myGLCD.print("0", 50, 3);
      myGLCD.printNumI(minute, 65, 3);
    }
    else if (minute >= 10) {
      myGLCD.printNumI(minute, 50, 3);
    }
    myGLCD.setFont(SmallFont);
    myGLCD.drawRect(5, 0, 80, 30);
    switch (dayOfWeek) {
   case 1:
     myGLCD.print("PAZAR", 26, 35);
    myGLCD.drawRect(24, 32, 58, 45);
        currentDay="PAZAR";
        break;
      case 2:
        myGLCD.print("PAZARTESI", 14, 35);
       currentDay="PAZARTESI";
     myGLCD.drawRect(12, 32, 70, 45);
        break;
      case 3:
        myGLCD.print("SALI", 28, 35);
      currentDay="SALI";
      myGLCD.drawRect(24, 32, 56, 45);
        break;
      case 4:
        myGLCD.print("CARSAMBA", 16, 35);
        currentDay="CARSAMBA";
        myGLCD.drawRect(13, 32, 69, 45);
        break;
      case 5:
        myGLCD.print("PERSEMBE", 16, 35);
      currentDay="PERSEMBE";
      myGLCD.drawRect(13, 32, 69, 45);
        break;
      case 6:
        myGLCD.print("*CUMA*", 24, 35);
        currentDay="*CUMA*";
        myGLCD.drawRect(22, 32, 62, 45);
        break;
      case 7:
        myGLCD.print("CUMARTESI", 14, 35);
       currentDay="CUMARTESI";
       myGLCD.drawRect(12, 32, 70, 45);
       break;
        }
  }
  myGLCD.update();
}
void loop() {
     if(mselect==16){
    myGLCD.clrScr();
    
  if(musicval==1){
    musicstr="Meaux-Green";
           }
      else if(musicval==2){
        musicstr="Mario";
      }
        else if(musicval==3){
        musicstr="GameOfThrones";
      }
        else if(musicval==4){
        musicstr="X1";
      }
        else if(musicval==5){
        musicstr="X2";
      }
        else if(musicval==6){
        musicstr="X3";
      }
           melodyplayer();
      myGLCD.update();
  }
     byte second, minute, hour, dayOfWeek, dayOfMonth, month, year;
  readDS3231time(&second, &minute, &hour, &dayOfWeek, &dayOfMonth, &month,
                 &year);
  EEPROM.write(1, brightness);
  EEPROM.write(2, mute);
  if(Planebool){
    EEPROM.write(3,Planemaxscore);
    kalanx1 = Planex - targetx1;
    kalany1 = Planey - targety1;
    kalanx2 = Planex - targetx2;
    kalany2 = Planey - targety2;
    kalanx3 = Planex - targetbossx;
    kalany3 = Planey - targetbossy;
            if(score>Planemaxscore){
      Planemaxscore=score;
    }
         if(timePlane==0){
               Planebool=false;
            myGLCD.clrScr();
        gameover();
    myGLCD.update();
                     }
                     if(timePlane>0&&score>=targetscore)
                     {
                      level+=1;
                          Planelevelcontrol();
                     }
            
              if(timePlane>0){ 
          myGLCD.clrScr();
       Planegame();
      myGLCD.update();
              }
                presentTime = millis();
                 if(presentTime-lastTime>=delayTime){
      lastTime=presentTime;
      if(timePlane>=0)
    timePlane--;
       }
       if((kalanx1>-5&&kalanx1<7)&&(kalany1>-8&&kalany1<0)){//TARGET1 SCORE
        targetx1= random(minx,maxx);
   targety1= random(miny+26,maxy);
   score+=1;
    }
        if((kalanx2>-5&&kalanx2<7)&&(kalany2>-8&&kalany2<0)){//TARGET2 SCORE
        targetx2= random(minx,maxx);
   targety2= random(miny+26,maxy);
   score+=2;
    }
        if(bossstate&&(kalanx3>-5&&kalanx3<7)&&(kalany3>-8&&kalany3<0)){//TARGET3 BOSS SCORE
        targetbossx= random(minx,maxx);
   targetbossy= random(miny+26,maxy);
    score+=10;
    }
         
      if(Planex<maxx){
delay(1);
Planex+=3;
}
else if(Planex>=maxx){
Planex=minx;
}
                     if(gtopbool){
      if(digitalRead(gtopbtn)){
         if (Planey>miny+22)
  Planey-=2;
                }
      } 
               if(gbotbool){
    if(digitalRead(gbotbtn)){
      if(Planey<maxy)
  Planey+=2;
    }
   }
  }
 if(Defenderbool){
  EEPROM.write(4,Defendermaxscore);
  if(score>Defendermaxscore){
    Defendermaxscore=score;
  }
  
   myGLCD.clrScr();
 defendergame();
 myGLCD.update();
 defkalanx1= bulletx-enemyx;
 defkalany1= bullety-enemyy;
 if(enemyy>=35){
 Defenderbool=false; 
  myGLCD.clrScr();
  gameover();
  myGLCD.update();
 
 }
 if(enemymove){
  enemyy++;
 }
   if(ates&&(defkalanx1>-3&&defkalanx1<7&&defkalany1>-2&&defkalany1<3)){
                        bulletx=gemix+6;  
                        score+=random(3,10);
  bullety=30;
   enemyx=random(5,64);
    enemyy=8;
     enemymove=true;
        
               }
 if(ates){
  if(bullety>miny+10)
  bullety-=5;
 }
 else{
  bulletx=gemix+6;
 }
 if(bullety<=10){
  ates=false;
  bulletx=gemix+6;  
  bullety=30;
 }
   if(grightbool){
          if(digitalRead(grightbtn)){
    if(gemix<=63)
    gemix+=5;        
     
                   }
      if(gtopbool){
      if(digitalRead(gtopbtn)){
     ates=true;
      } 
      }
                     if(gleftbool){
    if(digitalRead(gleftbtn)){
     if(gemix>=0)
      gemix-=2.5f;
                  }
                   }
                            }
 }
 
  if (brightness != 0) {
    lightlevel = brightness / 2;
  }
  else if (brightness == 0) {
    lightlevel = 0;
  }
  if(mselect==-1&&!sleep){
    anaekranbool=true;
        }
  else if(mselect !=-1||sleep){
    anaekranbool=false;
     }
  if(anaekranbool){
    myGLCD.clrScr();
    delay(1);
    displayTime();
  }
  if(gunayarbool){
    gunayarbool=false;
     if(setsayi==1){
              myGLCD.clrScr();
          GunAyar();
          myGLCD.invertText(true);
          myGLCD.print(gun,gunxpos,20);
          myGLCD.invertText(false);
        }
        else if(setsayi==2){
                 myGLCD.clrScr();
          GunAyar();
          myGLCD.invertText(true);
          myGLCD.print("Kaydet",42,40);
          myGLCD.invertText(false);
        }
        myGLCD.update();
  }
  if (brightness < 0)
    brightness = 0;
  else if (brightness > 200)
    brightness = 200;
  if (mselect == 4) {
  lightbar();
    lightbarval = lightlevel / 10;//OZEL
     brightvoid();
    myGLCD.printNumI(lightlevel, 30, 16);
  
    myGLCD.update();
  }
   
  if (sleep) {
        analogWrite(background, 0);
  }
  else if (!sleep) {
    analogWrite(background, brightness);
  }
  if (enbtn) {
    if (digitalRead(enterbuton) == HIGH) {
       if (mselect == 7) {
        delay(100);
        if (sayi == 15) {
          if (!mute) {
            myGLCD.clrScr();
            Ayarlarmn();
            myGLCD.invertText(true);
            myGLCD.print("Sessiz(ON)", 11, 15);
            myGLCD.invertText(false);
            mute =  true;

            myGLCD.update();
          }
          else {
            myGLCD.clrScr();
            Ayarlarmn();
            myGLCD.invertText(true);
            myGLCD.print("Sessiz(OFF)", 11, 15);
            myGLCD.invertText(false);
            mute = false;
            myGLCD.update();
          }
        }
      }
      if (mselect == 11 && setsayi == 4) {
        delay(200);
        myGLCD.clrScr();
        displayTime();
        mselect = 2;
        specialvalue = 3;
        setDS3231time(sn, dk, st, dayOfWeek, dayOfMonth, month, year);
      }
      else if (mselect == 12 && setsayi == 4) {
        delay(200);
        myGLCD.clrScr();
        displayTime();
        mselect = 2;
        specialvalue = 3;
        setDS3231time(second, minute, hour, dayOfWeek, gn, ay, yl);
               }
           else if(mselect ==13&&setsayi==2){
            delay(200);
            myGLCD.clrScr();
            displayTime();
            mselect=2;
            specialvalue=3;
             setDS3231time(second, minute, hour, currentDayval, dayOfMonth, month, year);    
                                 currentDay = gun;
                   }
      if (!sleep) {
        enter();
      }
      if (mselect == -1) {
        myGLCD.setFont(SmallFont);
        delay(200);
        myGLCD.clrScr();
        myGLCD.invert(false);
        mselect = 0;
        mainmenu();
        sayi = 10;
        myGLCD.invertText(true);
        myGLCD.print("Sicaklik", 0, 10);
        myGLCD.invertText(false);
        myGLCD.update();
      }
      if (mselect != 4 && mselect != 1) {
        if (!sleep) {
          if (!mute) {
            digitalWrite(buzzer,HIGH);
            delay(100);
            digitalWrite(buzzer, LOW);
          }
          else {
            delay(100);
          }
        }
      }
    }
  }
  if (specialvalue == 1 ) {
    myGLCD.clrScr();
    delay(250);
    isi();
  }
 else if (specialvalue == 2) {
    speselect();
  }
  else if (specialvalue == 3) {
    myGLCD.clrScr();
    delay(300);
    displayTime();
  }
    delay(100);
  if (tbtn) {
    if (digitalRead(topbuton) == HIGH) {
        topbtn(); 
      speselect();
      if (mselect == 7) {
        delay(100);
        if (sayi == 15) {
          sayi = 25;
          myGLCD.clrScr();
          Ayarlarmn();
          myGLCD.invertText(true);
          myGLCD.print("Saat&Tarih", 11, 25);
          myGLCD.invertText(false);
          if (!mute) {
            myGLCD.print("Sessiz(OFF)", 11, 15);
          }
          else if (mute) {
            myGLCD.print("Sessiz(ON)", 11, 15);
          }
        }
        else if (sayi == 25) {
          sayi = 15;
          myGLCD.clrScr();
          Ayarlarmn();
          myGLCD.invertText(true);
          if (mute) {
            myGLCD.print("Sessiz(ON)", 11, 15);
          }
          else {
            myGLCD.print("Sessiz(OFF)", 11, 15);
          }
          myGLCD.invertText(false);
        }
        myGLCD.update();
      }
       else if(mselect == 5){
      //TOP5
      myGLCD.clrScr();
      if(sayi>15){
        sayi-=10;
      }
      else if(sayi==15){
                     sayi=35;
      if(melodypage==1){
             melodypage=2;
      }
      else if(melodypage==2){
               melodypage=1;
              }
            }
    Melodiler();
    myGLCD.update();
         }  
         if(mselect==16){
          myGLCD.clrScr();
      if(sayi>15){
        sayi-=10;
      }
      else if(sayi<=15){
              sayi=55;
              if(melodypage==1){
                    melodypage=2;
                   }
                   else if(melodypage==2){
                    melodypage=1;
                   }
                       }    
                        melodyplayer(); 
          myGLCD.update(); 
         }
      if (mselect == 11 || mselect == 12) {
        delay(100);
        if (!settime) {
          setsayi += 1;
          if (setsayi > 4) {
            setsayi = 1;
          }
        }
              }
      if (mselect == 11) {
        if (setsayi == 1) {
          myGLCD.clrScr();
          SaatAyar();
          myGLCD.invertText(true);
          myGLCD.printNumI(st, 11, 25);
          myGLCD.invertText(false);
        }
        else if (setsayi == 2) {
          myGLCD.clrScr();
          SaatAyar();
          myGLCD.invertText(true);
          myGLCD.printNumI(dk, 35, 25);
          myGLCD.invertText(false);
        }
        else if (setsayi == 3) {
          myGLCD.clrScr();
          SaatAyar();
          myGLCD.invertText(true);
          myGLCD.printNumI(sn, 58, 25);
          myGLCD.invertText(false);
        }
        else if (setsayi == 4) {
          myGLCD.clrScr();
          SaatAyar();
          myGLCD.invertText(true);
          myGLCD.print("Kaydet", 42, 40);
          myGLCD.invertText(false);
        }
      }
      else  if (mselect == 12) {
        if (setsayi == 1) {
          myGLCD.clrScr();
          TarihAyar();
          myGLCD.invertText(true);
          myGLCD.printNumI(gn, 11, 25);
          myGLCD.invertText(false);
        }
        else if (setsayi == 2) {
          myGLCD.clrScr();
          TarihAyar();
          myGLCD.invertText(true);
          myGLCD.printNumI(ay, 35, 25);
          myGLCD.invertText(false);
        }
        else if (setsayi == 3) {
          myGLCD.clrScr();
          TarihAyar();
          myGLCD.invertText(true);
          myGLCD.printNumI(yl, 58, 25);
          myGLCD.invertText(false);
        }
        else if (setsayi == 4) {
          myGLCD.clrScr();
          TarihAyar();
          myGLCD.invertText(true);
          myGLCD.print("Kaydet", 42, 40);
          myGLCD.invertText(false);
        }
      }
      else if(mselect ==13){
        if(!settime){
          setsayi+=1;
          if(setsayi>2){
            setsayi=1;
          }
        }
       gunayarbool=true;
      }
      if (mselect == 10) {
        if (setsayi == 20) {
          myGLCD.clrScr();
          dateSet();
          setsayi = 30;
          myGLCD.invertText(true);
          myGLCD.print("Saat Ayari", 12, 25);
          myGLCD.invertText(false);
        }
        else if (setsayi == 30) {
          myGLCD.clrScr();
          dateSet();
          setsayi = 40;
          myGLCD.invertText(true);
          myGLCD.print("Gun Ayari", 13, 15);
          myGLCD.invertText(false);
        }
        else if (setsayi == 40)
        {
          myGLCD.clrScr();
          dateSet();
          setsayi = 20;
          myGLCD.invertText(true);
          myGLCD.print("Tarih Ayari", 10, 35);
          myGLCD.invertText(false);
        }
        myGLCD.update();
      }
      if (mselect != 4 && mselect != 1 && mselect != -1) {
        if (!mute) {
          digitalWrite(buzzer, HIGH);
          delay(100);
          digitalWrite(buzzer, LOW);
        }
        else {
          delay(100);
        }
      }
      if (mselect == 4) {
        if (brightness < 200) {
          delay(100);
          brightness += 20;
          myGLCD.clrScr();
          brightvoid();
        }
      }

      myGLCD.update();
    }
  }
  if (bbtn) {
    if (digitalRead(bottombtn) == HIGH) {
      speselect();
      bottombuton();
      if (mselect == 7) {
        delay(100);
        if (sayi == 15) {
          sayi = 25;
          myGLCD.clrScr();
          Ayarlarmn();
          myGLCD.invertText(true);
          myGLCD.print("Saat&Tarih", 11, 25);
          myGLCD.invertText(false);
          if (!mute) {
            myGLCD.print("Sessiz(OFF)", 11, 15);
          }
          else if (mute) {
            myGLCD.print("Sessiz(ON)", 11, 15);
          }
        }
        else if (sayi == 25) {
          sayi = 15;
          myGLCD.clrScr();
          Ayarlarmn();
          myGLCD.invertText(true);
          if (mute) {
            myGLCD.print("Sessiz(ON)", 11, 15);
          }
          else {
            myGLCD.print("Sessiz(OFF)", 11, 15);
          }
          myGLCD.invertText(false);
          myGLCD.update();
        }
      }
       if(mselect == 5){//BOT5
    myGLCD.clrScr();
    if(sayi<35){
      sayi+=10;
          }
    else if(sayi>=35){
       myGLCD.clrScr();
       sayi=15;
      if(melodypage==1){
             melodypage=2;
      }
      else if(melodypage==2){
               melodypage=1;
              }
            }
    Melodiler();
    myGLCD.update();
  }
    if(mselect==16){
          myGLCD.clrScr();
      if(sayi<55){
        sayi+=10;
      }
      else if(sayi>=55){
        sayi=15;
              if(melodypage==1){
                    melodypage=2;
                   }
                   else if(melodypage==2){
                    melodypage=1;
                   }
                         }
                            melodyplayer();
                   myGLCD.update();
         }
      if (mselect == 11 || mselect == 12) {
        delay(100);
        if (!settime) {
          setsayi -= 1;
          if (setsayi < 1) {
            setsayi = 4;
          }
        }
              }
             else if(mselect ==13){
        if(!settime){
          setsayi-=1;
          if(setsayi<1){
            setsayi=2;
          }
        }
       gunayarbool=true;
      }
      if (mselect == 11) {
        if (setsayi == 1) {
          myGLCD.clrScr();
          SaatAyar();
          myGLCD.invertText(true);
          myGLCD.printNumI(st, 11, 25);
          myGLCD.invertText(false);
        }
        else if (setsayi == 2) {
          myGLCD.clrScr();
          SaatAyar();
          myGLCD.invertText(true);
          myGLCD.printNumI(dk, 35, 25);
          myGLCD.invertText(false);
        }
        else if (setsayi == 3) {
          myGLCD.clrScr();
          SaatAyar();
          myGLCD.invertText(true);
          myGLCD.printNumI(sn, 58, 25);
          myGLCD.invertText(false);
        }
        else if (setsayi == 4) {
          myGLCD.clrScr();
          SaatAyar();
          myGLCD.invertText(true);
          myGLCD.print("Kaydet", 42, 40);
          myGLCD.invertText(false);
        }
      }
      else  if (mselect == 12) {
        if (setsayi == 1) {
          myGLCD.clrScr();
          TarihAyar();
          myGLCD.invertText(true);
          myGLCD.printNumI(gn, 11, 25);
          myGLCD.invertText(false);
        }
        else if (setsayi == 2) {
          myGLCD.clrScr();
          TarihAyar();
          myGLCD.invertText(true);
          myGLCD.printNumI(ay, 35, 25);
          myGLCD.invertText(false);
        }
        else if (setsayi == 3) {
          myGLCD.clrScr();
          TarihAyar();
          myGLCD.invertText(true);
          myGLCD.printNumI(yl, 58, 25);
          myGLCD.invertText(false);
        }
        else if (setsayi == 4) {
          myGLCD.clrScr();
          TarihAyar();
          myGLCD.invertText(true);
          myGLCD.print("Kaydet", 42, 40);
          myGLCD.invertText(false);
        }
      }
      if (mselect == 10) {
        if (setsayi == 20) {
          myGLCD.clrScr();
          dateSet();
          setsayi = 40;
          myGLCD.invertText(true);
          myGLCD.print("Gun Ayari", 13, 15);
          myGLCD.invertText(false);
        }
        else if (setsayi == 30) {
          myGLCD.clrScr();
          dateSet();
          setsayi = 20;
          myGLCD.invertText(true);
          myGLCD.print("Tarih Ayari", 12, 35);
          myGLCD.invertText(false);
        }
        else if (setsayi == 40)
        {
          myGLCD.clrScr();
          dateSet();
          setsayi = 30;
          myGLCD.invertText(true);
          myGLCD.print("Saat Ayari", 12, 25);
          myGLCD.invertText(false);
        }
        myGLCD.update();
      }
      if (mselect != 4 && mselect != 1 && mselect != -1) {
        if (!mute) {
          digitalWrite(buzzer, HIGH);
          delay(100);
          digitalWrite(buzzer, LOW);
        }
        else {
          delay(100);
        }
      }
      if (mselect == 4) {
        if (brightness > 0) {
          delay(100);
          brightness -= 20;
          myGLCD.clrScr();
          brightvoid();
        }
      }
      myGLCD.update();
    }
  }
  if (exbtn) {
    if (digitalRead(backbuton) == HIGH) {
      delay(100);
      backbtn();
      if (mselect == 10) {
        specialvalue = 0;
        myGLCD.clrScr();
        mselect = 7;
        sayi=25;
        Ayarlarmn();
                 myGLCD.invertText(true);
        myGLCD.print("Saat&Tarih", 11, 25);//stayr
        myGLCD.invertText(false);
       myGLCD.update();
            }
      if (mselect == 11) {
        delay(200);
        myGLCD.clrScr();
        specialvalue = 0;
        mselect = 10;
        setsayi = 30;
        dateSet();
        myGLCD.invertText(true);
        myGLCD.print("Saat Ayari", 12, 25);
        myGLCD.invertText(false);
         myGLCD.update();
      }
      else    if (mselect == 12) {
        delay(200);
        myGLCD.clrScr();
        specialvalue = 0;
        mselect = 10;
        setsayi = 20;
        dateSet();
        myGLCD.invertText(true);
        myGLCD.print("Tarih Ayari", 12, 35);
        myGLCD.invertText(false);
         myGLCD.update();
      }
      else if (mselect == 13) {
        delay(200);
        myGLCD.clrScr();
        specialvalue = 0;
               mselect = 10;
        setsayi = 40;
        dateSet();
        myGLCD.invertText(true);
        myGLCD.print("Gun Ayari", 13, 15);
        myGLCD.invertText(false);
         myGLCD.update();
      }
      myGLCD.update();
      if (mselect != 4 && mselect != 1 && mselect != 5 && mselect != 6) {
        if (!mute) {
          digitalWrite(buzzer, HIGH);
          delay(100);
          digitalWrite(buzzer, LOW);
        }
        else {
          delay(100);
        }
      }
    }
  }
}
void mainmenu() {
  myGLCD.drawLine(0, 9, 84, 9);
  myGLCD.print("[1/2]", 55, 0);
  myGLCD.print("Sicaklik", 0, 10);
  myGLCD.print("Saat&Tarih", 0, 18);
  myGLCD.print("Oyunlar", 0, 26);
  myGLCD.print("Parlaklik", 0, 34);
  myGLCD.update();
}
void menu2() {
  myGLCD.drawLine(0, 9, 84, 9);
  myGLCD.print("[2/2]", 55, 0);
  myGLCD.print("Melodiler", 0, 11);
  myGLCD.print("Bos4", 0, 19);
  myGLCD.print("Ayarlar", 0, 27);
  myGLCD.update();
}
void isi () {
      int chk = DHT11.read(DHT11PIN);
  if (chk == 0) {
    myGLCD.clrScr();
    myGLCD.drawBitmap(0,0,dogrusicaklikbmp,84,48);
  }
  if (chk < 0) {
    myGLCD.clrScr();
    myGLCD.drawBitmap(0,0,yanlissicaklikbmp,84,48);
  }
    myGLCD.print("Deger", 0, 0);
  myGLCD.invertText(true);
  myGLCD.print("Sicaklik", 10, 12);
  myGLCD.print("Nem", 26, 30);
  myGLCD.invertText(false);
  myGLCD.printNumF((float)DHT11.humidity, 2, 18, 40);
  myGLCD.printNumF((float)DHT11.temperature, 2, 18, 22);
  myGLCD.print("C", 51, 22);
  myGLCD.update();
}
/*                           *BlackLion*                           */
/* -------------------------VOID BUTON KISMI-------------------------*/
void bottombuton() {
  specialvalue = 2;
  if (settime) {
    if (mselect == 11) {
      if (setsayi == 1) {
        myGLCD.clrScr();
        SaatAyar();
        for (st; st >= 0;) {
          st -= 1;
          break;
        }
        if (st < 0) {
          st = 23;
        }
      }
      else if (setsayi == 2) {
        myGLCD.clrScr();
        SaatAyar();
        for (dk; dk >= 0;) {
          dk -= 1;
          break;
        }
        if (dk < 0) {
          dk = 59;
        }
      }
      else if (setsayi == 3) {
        myGLCD.clrScr();
        SaatAyar();
        for (sn; sn >= 0;) {
          sn -= 1;
          break;
        }
        if (sn < 0) {
          sn = 59;
        }
      }
    }
        else if(mselect==13){
          if(setsayi==1){
            myGLCD.clrScr();
            GunAyar();
            for(currentDayval; currentDayval >=0;){
              currentDayval-=1;
              break;
            }
            if(currentDayval==0){
              currentDayval=7;    
            }
                       if(currentDayval==1){
   gun="PAZAR";
  }
  else if(currentDayval==2){
    gun="PAZARTESI";
  }
  else if(currentDayval==3){
    gun="SALI";
  }
  else if(currentDayval==4){
    gun="CARSAMBA";
      }
 else if(currentDayval==5){
  gun="PERSEMBE";
   }
 else if(currentDayval==6){
  gun="*CUMA*";
 }
 else if(currentDayval==7){
  gun="CUMARTESI";
 }
              }
      }
    else if (mselect == 12) {//özelyer2
      if (setsayi == 1) {
        myGLCD.clrScr();
        TarihAyar();
        for (gn; gn >= 0;) {
          gn -= 1;
          break;
        }
        if (gn < 0) {
          gn = 31;
        }
      }
      else if (setsayi == 2) {
        myGLCD.clrScr();
        TarihAyar();
        for (ay; ay >= 0;) {
          ay -= 1;
          break;
        }
        if (ay < 0) {
          ay = 12;
        }
      }
      else if (setsayi == 3) {
        myGLCD.clrScr();
        TarihAyar();
        for (yl; yl >= 0;) {
          yl -= 1;
          break;
        }
        if (yl < 0) {
          yl = 99;
        }
      }
    }
    myGLCD.update();
  }
  if ((mselect == 0) && (sayi == 2 || sayi == 10 | sayi == 18 || sayi == 26 || sayi == 34 || sayi == 42)) {
    sayi = sayi + 8;
    mainmenu();
    if (sayi == 42) {
      myGLCD.clrScr();
      menu2();
      sayi = 3;
    }
  }
  if ((mselect == 0) && (sayi == 3 || sayi == 11 || sayi == 19 || sayi == 27)) {
    sayi = sayi + 8;
    myGLCD.clrScr();
    menu2();
    if (sayi == 35) {
      myGLCD.clrScr();
      mainmenu();
      sayi = 10;
    }
  }
  if ((mselect == 3 ) && (sayi == 10 || sayi == 18 || sayi == 26 || sayi == 34)) {
    sayi = sayi + 8;
    myGLCD.clrScr();
    gamemenu();
    speselect();
    if (sayi == 34){
      sayi = 18;
    }
  }
      if(mselect == 14){
 if(sayi==1){
  sayi=2;
  myGLCD.clrScr();
  gameinmenu();
    gtopbool=true;
  gbotbool=true;
  gleftbool=true;
  grightbool=true;
    myGLCD.invertText(true);
        myGLCD.print("SKOR TAB..",16,28);
 myGLCD.invertText(false);
 }
 else if(sayi==2){
  sayi=1;
  myGLCD.clrScr();
  gameinmenu();
        myGLCD.invertText(true);
    myGLCD.print("OYNA!",29,18);
 myGLCD.invertText(false);
 }
 myGLCD.update();
}
if(mselect == 15){
 if(sayi==1){
  sayi=2;
  myGLCD.clrScr();
  gameinmenu();
    myGLCD.invertText(true);
        myGLCD.print("SKOR TAB..",16,28);
 myGLCD.invertText(false);
 }
 else if(sayi==2){
  sayi=1;
  myGLCD.clrScr();
  gameinmenu();
     myGLCD.invertText(true);
    myGLCD.print("OYNA!",29,18);
 myGLCD.invertText(false);
 }
 myGLCD.update();
}

}
void enter() {
  byte second, minute, hour, dayOfWeek, dayOfMonth, month, year;
  readDS3231time(&second, &minute, &hour, &dayOfWeek, &dayOfMonth, &month,
                 &year);
  delay(100);
  if (mselect == 11 || mselect == 12) {
    if (setsayi != 4) {
      if (settime) {
        delay(200);
        settime = false;
      }
      else {
        delay(200);
        settime = true;
      }
    }
    }
if(mselect==13){
  delay(200);
  if(setsayi==1){
      if(!settime)
      settime=true;
  else 
    settime=false;
  }
}
if(mselect == 14&&sayi==1){
  digitalWrite(gameonled,HIGH);
  myGLCD.clrScr();
  Planegame();
  myGLCD.update();
      targetx1= random(minx,maxx);
   targety1= random(miny+26,maxy);
   targetx2= random(minx,maxx);
   targety2= random(miny+26,maxy);
   targetbossx= random(minx,maxx);
   targetbossy= random(miny+26,maxy);
   level=1;
   Planelevelcontrol();
      score=0;
     delayTime=1000;
     gtopbool=true;
Planebool=true;
   gbotbool=true;
    gleftbool=false;
  grightbool=false;
      tbtn=false;
    bbtn=false;
    exbtn=true;
    enbtn=false;
}
if(mselect==14&&sayi==2){
  myGLCD.clrScr();
  scoretab();
  myGLCD.update();
  gtopbool=false;
    gbotbool=false;
    gleftbool=false;
  grightbool=false;
      tbtn=false;
    bbtn=false;
    exbtn=true;
    enbtn=false;
  }
  if(mselect == 15&&sayi==2){
    myGLCD.clrScr();
    scoretab();
   myGLCD.update();
    gtopbool=false;
    gbotbool=false;
    gleftbool=false;
  grightbool=false;
      tbtn=false;
    bbtn=false;
    exbtn=true;
    enbtn=false;
  }
if(mselect == 15&&sayi==1){
  myGLCD.clrScr();
  defendergame();
  myGLCD.update();
  bullety=30;
 enemyy=8;
  delayTime = 1000;
  score=0;
  enemymove=true;
  gtopbool=true;
   gbotbool=false;
    gleftbool=true;
  grightbool=true;
      tbtn=false;
    bbtn=false;
    exbtn=true;
    enbtn=false;
Defenderbool=true;
}
 if(mselect == 3&&sayi == 18){ 
   myGLCD.clrScr();
      sayi=1;
         mselect = 14;
  gamename = "Plane";
      gameinmenu();
   myGLCD.invertText(true);
   myGLCD.print("OYNA!",29,18);
   myGLCD.invertText(false);
      myGLCD.update();
      }
  else if(mselect ==3&&sayi==26){
    myGLCD.clrScr();
       mselect = 15;
    gamename = "Defender";
    gameinmenu();
       sayi=1;
   myGLCD.invertText(true);
   myGLCD.print("OYNA!",29,18);
   myGLCD.invertText(false);
      myGLCD.update();
  }
    if (mselect == 10) {
    myGLCD.clrScr();
    settime = false;
    if (setsayi == 30) {
      mselect = 11;
      setsayi = 1;
      st = hour;
      dk = minute;
      sn = second;
      SaatAyar();
      myGLCD.invertText(true);
      myGLCD.printNumI(st, 11, 25);
      myGLCD.invertText(false);
    }
    else if (setsayi == 20) {
          mselect = 12;
      setsayi = 1;
      gn = dayOfMonth;
      ay = month;
      yl = year;
      TarihAyar();
      myGLCD.invertText(true);
      myGLCD.printNumI(gn, 11, 25);
      myGLCD.invertText(false);
    }
    else if (setsayi == 40) {
      mselect = 13;
      setsayi=1;
currentDayval=dayOfWeek;
       gun=currentDay;
             GunAyar();
   myGLCD.invertText(true);
   myGLCD.print(gun,gunxpos,20);
   myGLCD.invertText(false);
    }
    myGLCD.update();
  }
  if (mselect == 7&&sayi==25) {
    delay(200);
    myGLCD.clrScr();
    mselect = 10;
    setsayi = 40;
    dateSet();
    myGLCD.invertText(true);
    myGLCD.print("Gun Ayari", 13, 15);
    myGLCD.invertText(false);
    specialvalue = 0;
    myGLCD.update();

  }
  if (sayi == 10 && mselect == 0) { //SECENEK 1
    mselect = 1;
    myGLCD.clrScr();
    isi();
    specialvalue = 1;
  }
  if (sayi == 18 && mselect == 0) { //SECENEK 2
    mselect = 2;
    myGLCD.clrScr();
    displayTime();
    specialvalue = 3;
  }
  if (sayi == 26 && mselect == 0) { //SECENEK 3
    mselect = 3;
    sayi = 18;
    specialvalue = 0;
    delay(1);
    myGLCD.clrScr();
    gamemenu();
    speselect();
  }
  if (sayi == 34 && mselect == 0) { //SECENEK 4
    mselect = 4;
    specialvalue = 0;
    myGLCD.clrScr();
    brightvoid();
    myGLCD.update();
  }
  if (sayi == 11 && mselect == 0) { //MLDENTER
    mselect = 5;
    sayi=15;
        tbtn=true;
    bbtn=true;
    exbtn=true;
    enbtn=true;
    specialvalue = 0;
      melodypage=1;
    myGLCD.clrScr();
    Melodiler();
        myGLCD.update();
  }
 else if(mselect==5){
    myGLCD.clrScr();
    melodyplayer();
    sayi=15;
    mselect=16;
    myGLCD.update();
  }
  else if(mselect==16){//MENTER
    myGLCD.clrScr();
    melodyplayer();
      if(sayi==15){
            if(musicval<6){
        musicval+=1;  
      }
      }
       else if(sayi==35){
            if(musicval>0){
        musicval-=1;  
      }
                  }
                  else if(sayi==25){
                    if(paused){
                      paused=false;
                    }
                    else{
                      paused=true;
                                          }
                  }
                  myGLCD.update();
  }
  if (sayi == 19 && mselect == 0) { //SECENEK 6
    mselect = 6;
    tbtn = false;
    bbtn = false;
    specialvalue = 0;
    myGLCD.clrScr();
    myGLCD.print("NONE",10,20);
    myGLCD.update();
  }
  if (sayi == 27 && mselect == 0) { //SECENEK 7
    mselect = 7;
    sayi = 15;
    specialvalue = 0;
    myGLCD.clrScr();
    Ayarlarmn();
    myGLCD.invertText(true);
     if (mute) {
      myGLCD.print("Sessiz(ON)", 11, 15);
    }
    else if (!mute) {
      myGLCD.print("Sessiz(OFF)", 11, 15);
    }
    myGLCD.invertText(false);
    myGLCD.update();
  }
 }
void Ayarlarmn() {
  myGLCD.invertText(true);
  myGLCD.print("AYARLAR", 18, 2);
  myGLCD.invertText(false);
   if (mute) {
      myGLCD.print("Sessiz(ON)", 11, 15);
    }
    else if (!mute) {
      myGLCD.print("Sessiz(OFF)", 11, 15);
    }
  myGLCD.print("Saat&Tarih", 11, 25);
  myGLCD.drawLine(0, 10, 84, 10);
  myGLCD.update();
}
void backbtn() {
  specialvalue = 0;
  if (mselect == 0) {
    delay(200);
    myGLCD.clrScr();
    mselect = -1;
    anaekran();
    sleep = true;
  }

  if (mselect == -1) {
    if (sleep) {
      delay(200);
      sleep = false;
      myGLCD.disableSleep();
      myGLCD.invert(true);
    }
    else if (!sleep) {
      delay(200);
      sleep = true;
      myGLCD.enableSleep();
      myGLCD.invert(false);
    }
  }

  if (mselect == 1) {
    myGLCD.clrScr();
    mainmenu();
    myGLCD.invertText(true);
    myGLCD.print("Sicaklik", 0, 10);
      mselect = 0;
    sayi = 10;

  }
  if (mselect == 2) {
      myGLCD.clrScr();
    mainmenu();
    myGLCD.invertText(true);
    myGLCD.print("Saat&Tarih", 0, 18);
       mselect = 0;
    sayi = 18;
  }
  if (mselect == 3) {
    myGLCD.clrScr();
    mainmenu();
    myGLCD.invertText(true);
    myGLCD.print("Oyunlar", 0, 26);
     mselect = 0;
    sayi = 26;
  }
  if (mselect == 4) {
    myGLCD.clrScr();
    mainmenu();
    myGLCD.invertText(true);
    myGLCD.print("Parlaklik", 0, 34);
     mselect = 0;
    sayi = 34;
  }
  if (mselect == 5) {
    tbtn = true;
    bbtn = true;
    myGLCD.clrScr();
    menu2();
    myGLCD.invertText(true);
    myGLCD.print("Melodiler", 0, 11);
        mselect = 0;
    sayi = 11;
  }
 else if(mselect==16){
  myGLCD.clrScr();
mselect=5;
sayi=15;
Melodiler();
myGLCD.update();
}
  if (mselect == 6) {
    tbtn = true;
    bbtn = true;
    myGLCD.clrScr();
    menu2();
    myGLCD.invertText(true);
    myGLCD.print("Bos4", 0, 19);
        mselect = 0;
    sayi = 19;
  }
  if (mselect == 7) {
    tbtn = true;
    bbtn = true;
    myGLCD.clrScr();
    menu2();
    myGLCD.invertText(true);
    myGLCD.print("Ayarlar", 0, 27);
      mselect = 0;
    sayi = 27;
  }
   if(mselect == 14){
   myGLCD.clrScr();
   myGLCD.setFont(SmallFont);
           gamemenu();
            digitalWrite(gameonled,LOW);
       myGLCD.invertText(true);
       myGLCD.print("Plane",20,18);
   mselect = 3;
    sayi = 18;
      gtopbool=false;
  gbotbool=false;
  gleftbool=false;
  grightbool=false;
  bbtn=true;
  enbtn=true;
  Planebool=false;
      exbtn=true;
      tbtn=true;
      }
  else if(mselect == 15){//Defender EXIT
   myGLCD.clrScr();
    myGLCD.setFont(SmallFont);
    digitalWrite(gameonled,LOW);
         gamemenu();
       myGLCD.invertText(true);
       myGLCD.print("Defender",20,26);
   mselect = 3;
  sayi = 26;
  enbtn=true;
  exbtn=true;
  bbtn=true;
  tbtn=true;
  Defenderbool=false;
   gtopbool=false;
  gbotbool=false;
  gleftbool=false;
  grightbool=false;
      }
    myGLCD.invertText(false);
    myGLCD.update();
}
void lightbar() {
   if(lightbarval==0){
       myGLCD.drawBitmap(0,0,parlaklik0,84,48);
  }
  if (lightbarval == 1) {
   myGLCD.drawBitmap(0,0,parlaklik10,84,48);

  }
  else if (lightbarval == 2) {
     myGLCD.drawBitmap(0,0,parlaklik20,84,48);

  }
  else if (lightbarval == 3) {
   myGLCD.drawBitmap(0,0,parlaklik30,84,48);
  }
  else if (lightbarval == 4) {
     myGLCD.drawBitmap(0,0,parlaklik40,84,48);
  }
  else if (lightbarval == 5) {
      myGLCD.drawBitmap(0,0,parlaklik50,84,48);
  }
  else if (lightbarval == 6) {
      myGLCD.drawBitmap(0,0,parlaklik60,84,48);
  }
  else if (lightbarval == 7) {
      myGLCD.drawBitmap(0,0,parlaklik70,84,48);
  }
  else if (lightbarval == 8) {
      myGLCD.drawBitmap(0,0,parlaklik80,84,48);
  }
  else if (lightbarval == 9) {
      myGLCD.drawBitmap(0,0,parlaklik90,84,48);
  }
  else if (lightbarval == 10) {
      myGLCD.drawBitmap(0,0,parlaklik100,84,48);

  }
  }
void dateSet() {
   myGLCD.drawRect(15, 0, 68, 10);
  myGLCD.print("AYARLAR", 20, 2);
  myGLCD.print("Gun Ayari", 13, 15);
  myGLCD.print("Saat Ayari", 12, 25);
  myGLCD.print("Tarih Ayari", 10, 35);
  myGLCD.update();
}
void SaatAyar() { // SAAT VOİD
  myGLCD.print("SAAT AYARLAMA", 3, 2);
  myGLCD.drawRect(0, 0, 82, 10);
  myGLCD.print(":", 25, 25);
  myGLCD.print(":", 50, 25); 
    myGLCD.print("St/ Dk /Sn", 10, 15);
    myGLCD.printNumI(st, 11, 25);
    myGLCD.printNumI(dk, 35, 25);
    myGLCD.printNumI(sn, 58, 25);
    myGLCD.print("Kaydet", 42, 40);
    myGLCD.update();
}
void TarihAyar() { // TARİH VOİD
  myGLCD.print("TARIH AYARLAMA", 0, 2);
  myGLCD.drawRect(0, 0, 82, 10);
  myGLCD.print("/", 25, 25);
  myGLCD.print("/", 50, 25);
  myGLCD.print("Gn/ Ay /Yl", 10, 15);
  myGLCD.printNumI(gn, 11, 25);
  myGLCD.printNumI(ay, 35, 25);
  myGLCD.printNumI(yl, 58, 25);
  myGLCD.print("Kaydet", 42, 40);
}
void GunAyar() {
    if(currentDayval==1){
    gunxpos = 25;
  }
  else if(currentDayval==2){
      gunxpos = 12;
  }
  else if(currentDayval==3){
       gunxpos=27;
  }
  else if(currentDayval==4){
        gunxpos = 13;
      }
 else if(currentDayval==5){
   gunxpos = 13;
   }
 else if(currentDayval==6){
    gunxpos = 23;
 }
 else if(currentDayval==7){
    gunxpos=12;
 }
                myGLCD.print("GUN AYARLAMA", 5, 2);
  myGLCD.drawRect(0, 0, 82, 10);
  myGLCD.print(gun,gunxpos,20);
  myGLCD.print("Kaydet", 42, 40);
  myGLCD.update();
}
void brightvoid() {
  myGLCD.print("Parlaklik", 13, 0);
  myGLCD.drawLine(0, 10, 84, 10);
//  myGLCD.drawRect(0, 36, 82, 25);*/
   myGLCD.print("%", 50, 16);

  myGLCD.update();
}
void topbtn () {
  specialvalue = 2;
  if (settime) {
    if (mselect == 11) {
      if (setsayi == 1) {
        myGLCD.clrScr();
        SaatAyar();
        for (st; st < 24;) {
          st += 1;
          break;
        }
        if (st == 24) {
          st = 0;
        }
      }
      else if (setsayi == 2) {
        myGLCD.clrScr();
        SaatAyar();
        for (dk; dk < 60;) {
          dk += 1;
          break;
        }
        if (dk == 60) {
          dk = 0;
        }
      }
      else if (setsayi == 3) {
        myGLCD.clrScr();
        SaatAyar();
        for (sn; sn < 60;) {
          sn += 1;
          break;
        }
        if (sn == 60) {
          sn = 0;
        }
      }
    }
           else if(mselect == 13){
     
          if(setsayi==1){
                        myGLCD.clrScr();
            GunAyar();
            for(currentDayval;currentDayval<8;){
              currentDayval+=1;
              break;
            }
            if(currentDayval==8){
              currentDayval=1;    
            }
                              if(currentDayval==1){
   gun="PAZAR";
    }
  else if(currentDayval==2){
    gun="PAZARTESI";
     }
  else if(currentDayval==3){
    gun="SALI";
     }
  else if(currentDayval==4){
    gun="CARSAMBA";
          }
 else if(currentDayval==5){
  gun="PERSEMBE";
     }
 else if(currentDayval==6){
  gun="*CUMA*";
 }
 else if(currentDayval==7){
  gun="CUMARTESI";
  }
              }
        }
 if (mselect == 12) {//özelyer
  
           if (setsayi == 1) {
                  myGLCD.clrScr();
        TarihAyar();
                     for (gn; gn < 31;) {
          gn += 1;
          break;
        }
        if (gn == 31) {
          gn = 1;
        }
      }
      else if (setsayi == 2) {
        myGLCD.clrScr();
        TarihAyar();
               for (ay; ay <= 12;) {
          ay += 1;
          break;
        }
        if (ay > 12) {
          ay = 1;
        }
      }
      else if (setsayi == 3) {
        myGLCD.clrScr();
        TarihAyar();
             for (yl; yl < 99;) {
          yl += 1;
          break;
        }
        if (yl == 99) {
          yl = 1;
        }
      }
         myGLCD.update();
        }
        
            }
   
  
  if ((mselect == 3) && (sayi==10||sayi == 18 || sayi == 26 || sayi == 34)) {
    sayi = sayi - 8;
    myGLCD.clrScr();
    gamemenu();
       if (sayi == 10) {
      sayi = 26;
    }
  }
  if ((mselect == 0) && (sayi == 34 || sayi == 26 || sayi == 18 || sayi == 10)) {
    sayi = sayi - 8;
    myGLCD.clrScr();
    mainmenu();
    if (sayi == 2) {
      myGLCD.clrScr();
      menu2();
      sayi = 35;
    }
  }


  if ((mselect == 0) && (sayi == 35 || sayi == 27 || sayi == 19 || sayi == 11)) {
    sayi = sayi - 8;
    myGLCD.clrScr();
    menu2();
    if (sayi == 3) {
      myGLCD.clrScr();
      mainmenu();
      sayi = 34;
    }
  }
  if(mselect == 14||mselect==15){
 if(sayi==1){
  sayi=2;
  myGLCD.clrScr();
  gameinmenu();
    myGLCD.invertText(true);
        myGLCD.print("SKOR TAB..",16,28);
 myGLCD.invertText(false);
 }
 else if(sayi==2){
  sayi=1;
  myGLCD.clrScr();
  gameinmenu();
     myGLCD.invertText(true);
    myGLCD.print("OYNA!",29,18);
 myGLCD.invertText(false);
 }
 myGLCD.update();
}
}
void speselect() {
   if (sayi == 10 && mselect == 0) {
    myGLCD.invertText(true);
    myGLCD.print("Sicaklik", 0, 10);
  }
  if (sayi == 18 && mselect == 0) {
    myGLCD.invertText(true);
    myGLCD.print("Saat&Tarih", 0, 18);
  }
  if (sayi == 26 && mselect == 0) {
    myGLCD.invertText(true);
    myGLCD.print("Oyunlar", 0, 26);
     }
  if (sayi == 34 && mselect == 0) {
    myGLCD.invertText(true);
    myGLCD.print("Parlaklik", 0, 34);
    }
  if (sayi == 11 && mselect == 0) {
    myGLCD.invertText(true);
    myGLCD.print("Melodiler", 0, 11);
     }
  if (sayi == 19 && mselect == 0) {
    myGLCD.invertText(true);
    myGLCD.print("Bos4", 0, 19);
      }
  if (sayi == 27 && mselect == 0) {
    myGLCD.invertText(true);
    myGLCD.print("Ayarlar", 0, 27);
      }
  if (sayi == 18 && mselect == 3) {
    myGLCD.invertText(true);
    myGLCD.print("Plane", 20, 18);
    }
  if (sayi == 26 && mselect == 3) {
    myGLCD.invertText(true);
    myGLCD.print("Defender", 20, 26);
  }
  myGLCD.invertText(false);
  myGLCD.update();
}

void start () {
  analogWrite(background,250);
   myGLCD.clrScr();
    myGLCD.drawBitmap(0,0,man1,84,48);
  myGLCD.update();
  delay(1000);
   myGLCD.clrScr();
    myGLCD.drawBitmap(0,0,man2,84,48);
  myGLCD.update();
  delay(1000);
   myGLCD.clrScr();
    myGLCD.drawBitmap(0,0,man3,84,48);
  myGLCD.update();
  delay(1000);
   myGLCD.clrScr();
    myGLCD.drawBitmap(0,0,man4,84,48);
  myGLCD.update();
  delay(1000);
   myGLCD.clrScr();
    myGLCD.drawBitmap(0,0,man5,84,48);
  myGLCD.update();
  delay(1000);
   myGLCD.clrScr();
    myGLCD.drawBitmap(0,0,man6,84,48);
  myGLCD.update();
  delay(1000);
  myGLCD.clrScr();
  myGLCD.drawBitmap(0,0,man7,84,48);
  myGLCD.update();
delay(1000);
    myGLCD.print("CREATED BY", CENTER, 0);
  myGLCD.drawLine(0, 10, 84, 10);
  myGLCD.print("Enes Ipek", CENTER, 10);
  myGLCD.print("WELCOME", CENTER, 30);
   gunayarbool=false;
    myGLCD.update();
    delay(1000);
     myGLCD.clrScr();
  specialvalue = 0;
  mselect = -1;
  anaekran();
  myGLCD.update();
}
void gamemenu () {
  myGLCD.drawLine(6,0,19,13);//sag
  myGLCD.drawLine(78,0,65,13);//sol
  myGLCD.drawLine(19,13,65,13);//altdüz
 myGLCD.drawLine(6,0,79,0);//üstdüz
 myGLCD.print("OYUNLAR",20,3);
  myGLCD.print("Plane", 20, 18);
  myGLCD.print("Defender", 20, 26);
   myGLCD.update();
}


void anaekran() {
  myGLCD.invert(true);
  displayTime();
}

void Melodiler() {
    myGLCD.print("Melodiler", 17, 0);
  if(melodypage==1){
        if(sayi==15){
      myGLCD.invertText(true);
     myGLCD.print("Meaux-Green",CENTER,15);
         myGLCD.invertText(false);
          myGLCD.print("Mario",CENTER,25);
          myGLCD.print("GameOfThrones",CENTER,35);
        musicval=1;
             }
    else if(sayi==25){
  myGLCD.invertText(true);
    myGLCD.print("Mario",CENTER,25);
        myGLCD.invertText(false);
    myGLCD.print("GameOfThrones",CENTER,35);
     myGLCD.print("Meaux-Green",CENTER,15);
    musicval=2;
    }
    else if(sayi==35){
  myGLCD.invertText(true);
  myGLCD.print("GameOfThrones",CENTER,35);
      myGLCD.invertText(false);
          myGLCD.print("Mario",CENTER,25);
          myGLCD.print("Meaux-Green",CENTER,15);
      musicval=3;
      }
  }
  else if(melodypage==2){
       if(sayi==15){
      myGLCD.invertText(true);
     myGLCD.print("X1",CENTER,15);
         myGLCD.invertText(false);
          myGLCD.print("X2",CENTER,25);
          myGLCD.print("X3",CENTER,35);
             musicval=4;
             }
    else if(sayi==25){
  myGLCD.invertText(true);
    myGLCD.print("X2",CENTER,25);
        myGLCD.invertText(false);
    myGLCD.print("X3",CENTER,35);
     myGLCD.print("X1",CENTER,15);
   musicval=5; 
    }
    else if(sayi==35){
  myGLCD.invertText(true);
  myGLCD.print("X3",CENTER,35);
      myGLCD.invertText(false);
          myGLCD.print("X2",CENTER,25);
          myGLCD.print("X1",CENTER,15);
            musicval=6;
            }
  }
  myGLCD.drawLine(0, 10, 84, 10);
  myGLCD.update();
}
void melodyplayer(){
  if(!paused){
  if(sayi==15){
   myGLCD.drawBitmap(0,0,changeleftmusic,84,48);
  }
  else if(sayi==25){
   myGLCD.drawBitmap(0,0,playbtnchange,84,48);
  }
  else if(sayi==35){
    myGLCD.drawBitmap(0,0,changerightmusic,84,48);
  }
  else if(sayi==45){
    myGLCD.drawBitmap(0,0,downvolume,84,48);
      }
  else if(sayi==55){
    myGLCD.drawBitmap(0,0,upvolume,84,48);
  }
  }
  if(paused){
     if(sayi==15){
   myGLCD.drawBitmap(0,0,changeleftpaused,84,48);
  }
  else if(sayi==25){
   myGLCD.drawBitmap(0,0,pausedbgorj,84,48);
  }
  else if(sayi==35){
    myGLCD.drawBitmap(0,0,changerightpaused,84,48);
  }
  }
  myGLCD.print(musicstr,CENTER,20);
  myGLCD.update();
}

