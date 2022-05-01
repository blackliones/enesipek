#include <EEPROM.h>
#include <SPI.h>
#include <Adafruit_GFX.h>
#include <Adafruit_PCD8544.h>
#include <IRremote.h>
#define null ""
/*// 1 TEXT İÇİN GEREKENLER
Screen.setCursor(0,0);
Screen.setTextColor(BTACK,WHITE);
Screen.print("MERHABA");
Screen.display();
 */
Adafruit_PCD8544 Screen = Adafruit_PCD8544( 49, 48, 47, 46, 45);//UNO: 7,6,5,4,3 , MEGA CORE MİNİ: 49,48,47,46,45
byte BT = 2;//Top Button
byte BM = 3; //Middle Button
byte BB = 5; //Bot Button
char irval;
char irprev[2]="";
bool irLoop;
bool irState;
//pageVal=0 Null
//pageVal=1 startingScreen
//pageVal=2 mainMenu
//pageVal=3 
//---------------------------------------------------------
//Byte>1 byte > 8 bit = 0-225
//Short>2 byte = -32 768 - +32 768  
//Integer>4 byte = -2 147 483 648.. - +2 147 483 648..
//Long>8 byte
//Float 4byte ||Double 8byte
//---------------------------------------------------------
//EEPROM ADDRESS
//Addr: 1 - PASSWORD PCLENGTH SAVİNG
//Addr: 0 - LOCKSTATE SAVİNG
//i+3 password char saving
String data;
unsigned long sleeptime,defsleeptime;//0,millis()
int pageVal;
int selectedItem;

int RECV_PIN = 4;

IRrecv irrecv(RECV_PIN);

decode_results results;

byte r1 = 30;
byte r2 = 31;
byte r3 = 32;
byte r4 = 33;
byte r5 = 34;
byte s1 = 35;//SWITCH FOR LAMP(r2)
int bgled = 6;
int leavelooping;
//Login System
char passChar[5];
String password;
String newpassword;
char passbg;
int pcLength;
bool lockstate;
bool lockreal;
bool dire;
//
String items[5]={"","","","",""};//alet durum isimleri
//TOOLS & ITEMS
bool itemstatus[5]={0,0,0,0,0};//alet durumları 
bool isinchildren[5];//item statuslar için looptan çıkarmak için falan kullanıcam
bool s1st;
bool sleepingMode;
bool changenewPass;
void setup() {
    Screen.begin();
        Serial.begin(9600);
        irrecv.enableIRIn();
               pinMode(BT,INPUT);
     pinMode(BM,INPUT);
      pinMode(BB,INPUT);
      pinMode(r1,OUTPUT);
      pinMode(r2,OUTPUT);
      pinMode(r3,OUTPUT);
      pinMode(r4,OUTPUT);
           pinMode(r5,OUTPUT);
           pinMode(s1,INPUT_PULLUP);
      pinMode(bgled,OUTPUT);
      irState=EEPROM.read(5);
      leavelooping = 0;
      irval=' ';
          sleeptime=0;
           lockstate=EEPROM.read(0);
             lockreal=lockstate;
      pcLength = EEPROM.read(1);
           for(int i = 0; i<pcLength;i++){
      passChar[i]=EEPROM.read(i+3);
   password +=passChar[i]; 
  
     }
    
      Screen.setContrast(50);
    Screen.clearDisplay();
      Screen.setRotation(2);
                 pageVal=1;   
                 startingScreen();
    for(int i = 0; i<5; i++){
      isinchildren[i]=itemstatus[i];
    }
    
}
void loop() {
      infrared();
   defsleeptime = millis();   
 tools();
 serialData();
 if(pageVal==0){
     
 }
 //BUTTONS
  if(digitalRead(BT)||digitalRead(BM)||digitalRead(BB)||irval!=' '){
    if(pageVal==0&&lockreal){
if(digitalRead(BT)||irprev[0]=='r'||irLoop&&irprev[0]=='r'&&irprev[1]==' '){
    if(selectedItem<16){
      selectedItem++;
    }
        else if(selectedItem==16){
      selectedItem=1;
        
    }
    Screen.clearDisplay();
     loginScreen();
      }
      else if(digitalRead(BB)||irprev[0]=='L'||irLoop&&irprev[0]=='L'&&irprev[1]==' '){
    if(selectedItem>1){
      selectedItem--; 
    }
    else if(selectedItem==1){
      selectedItem=16;
    }
    Screen.clearDisplay();
    loginScreen();
      }
 if(sleepingMode) {//LOCKED WİTH BUTTONS
  sleepingMode=false;
  Screen.clearDisplay();
    loginScreen();
 }
    }
  if(sleepingMode&&(pageVal==2||pageVal==3||pageVal==4||pageVal==5)){
      sleepingMode=false;
sleeptime = defsleeptime;
Screen.clearDisplay();
if(pageVal==2){
mainMenu();
}
else if(pageVal==3){
settingsScreen();
}
else if(pageVal==4){
deviceSettings();
}
else if(pageVal==5){
  commandstate();
}
 }
 }
     if(digitalRead(BT)||irprev[0]=='d'||irLoop&&irprev[0]=='d'&&irprev[1]==' '){
                        delay(100);
if(!sleepingMode){
if(pageVal!=3&&pageVal!=4&&pageVal!=0&&pageVal!=5){
if(selectedItem<8){
  selectedItem++;
}
else if(selectedItem==8){
  selectedItem=1;
}
mainMenu();
  }
  else if(pageVal==3||pageVal==4){
  if(selectedItem<4){
    selectedItem++;
  }
  else if(selectedItem==4){
    selectedItem=1;
      }
      if(pageVal==3)
      settingsScreen();
      else
      deviceSettings();
}
else if(pageVal==5){
  if(selectedItem<2){
    selectedItem++;
  }
  else if(selectedItem>=2){
    selectedItem=1;
  }
  Screen.clearDisplay();
  commandstate();
}
}
}
if(digitalRead(BM)||irprev[0]=='o'){
     delay(100);
 if(!sleepingMode){
 if(pageVal!=3&&pageVal!=4&&pageVal!=0&&pageVal!=5){
  switch(selectedItem){
    case 1:
itemstatus[0]=!itemstatus[0];
isinchildren[0]=true;
Screen.clearDisplay();
mainMenu();
    break;
    case 2:
itemstatus[1]=!itemstatus[1];
isinchildren[1]=true;
Screen.clearDisplay();
mainMenu();
    break;
    case 3:
    itemstatus[2]=!itemstatus[2];
isinchildren[2]=true;
Screen.clearDisplay();
mainMenu();
    break;
  case 4:
  itemstatus[3]=!itemstatus[3];
  isinchildren[3]=true;
  Screen.clearDisplay();
mainMenu();
  break;
  case 5:
  itemstatus[4]=!itemstatus[4];
  isinchildren[4]=true;
Screen.clearDisplay();
mainMenu();
  break;
case 6:
Serial.println("SAYFA1");
break;
case 7:
 Serial.println("SAYFA2");
break;
case 8: 
 if(pageVal!=3){
     pageVal=3;
       selectedItem=1;
     settingsScreen();
}
break;
  }
  }
  if(pageVal==3){
    if(selectedItem==1){
    
        }
    else if(selectedItem==2){
          pageVal=5;
      selectedItem=1;
      Screen.clearDisplay();
     commandstate();
        }
      else if(selectedItem==3){
        Screen.clearDisplay();
        pageVal=4;
       selectedItem=1;
      deviceSettings();
      
    }
      else if(selectedItem==4){//GO BACK 
      pageVal=2;
        selectedItem = 8;
           mainMenu();
    
    }  
  }
 else if(pageVal==4){//DEVİCESCREEN KONTROLÜ BUTTON MIDDLE
  if(selectedItem==1&&lockstate){//CHANGE PASSWORD
    changenewPass=true;
lockreal=true;
    selectedItem=1;
    pageVal=0;
    Screen.clearDisplay();
    loginScreen();
  }
  else if(selectedItem==2){//LOCK SCREEN
    if(lockstate){
    pageVal=0;
    changenewPass=false;
    lockreal=true;
    Screen.clearDisplay();
    selectedItem=1;
    loginScreen();
    }
  }
else if(selectedItem==3){//PASSWORD ON OFF
lockstate=!lockstate;
EEPROM.write(0,lockstate);
Screen.clearDisplay();
deviceSettings();

}
else if(selectedItem==4){//GO BACK
  Screen.clearDisplay();
  pageVal=3;
  selectedItem=3;
  settingsScreen();
}
}
 else if(pageVal==5){//ENTER IRSTATE SET
  if(selectedItem==1){
     irState=!irState;
     Screen.clearDisplay();
     commandstate();     
      }
      else if(selectedItem==2){
        EEPROM.write(5,irState);
          Screen.clearDisplay();
                  pageVal=3;
        selectedItem=2;
      settingsScreen();
      }
   }
 else if(pageVal==0){
   if(lockreal){
     if(selectedItem==15){//ENTER
      if(!changenewPass){
  if(newpassword==password){
      Serial.println("UNLOCKED");
      newpassword="";
      lockreal=false;
      pageVal=2;
      selectedItem=1;
      Screen.clearDisplay();
      mainMenu();
    }
    else{//HATALI SIFRE
      Screen.clearDisplay();
      Screen.setTextColor(BLACK,WHITE);
      menuSlot("WRONG!",12,5,2);
      delay(250);
      Screen.setTextColor(WHITE,BLACK);
      menuSlot("PASSWORD",18,25,1);
      delay(1000);
      Screen.clearDisplay();
      Screen.setTextColor(WHITE,BLACK);
      menuSlot("WRONG!",12,5,2);
      Screen.setTextColor(BLACK,WHITE);
      menuSlot("PASSWORD",18,25,1);
      Screen.clearDisplay();
      delay(1000);
      selectedItem=1;
      newpassword="";
      loginScreen();
             }
      }
      else{
        changenewPass=false;
  if(newpassword!=""){
        password = "";
      for(int i = 0; i<newpassword.length(); i++){
    passChar[i] = newpassword.charAt(i);
    Serial.println(passChar[i]);
         EEPROM.write(i+3,passChar[i]);
      password += passChar[i];
         }
           pcLength=newpassword.length();
              EEPROM.write(1,pcLength);
                     lockreal=false;
       Screen.clearDisplay();
      Screen.setTextColor(BLACK,WHITE);
      menuSlot("SUCCESS",0,12,2);
      delay(1000);
               pageVal=4;
          selectedItem=1;
          Screen.clearDisplay();
          deviceSettings();
newpassword="";
                     }
              else{
                      lockreal=false;
           pageVal=4;
          selectedItem=1;
          Screen.clearDisplay();
          deviceSettings();
              }
              }
    }
    else if(selectedItem==16){//DELETE
    if(newpassword.length()>0){
newpassword = newpassword.substring(0,newpassword.length()-1);
Screen.clearDisplay();
loginScreen();
    }
}
      else if(selectedItem!=15&&selectedItem!=16){
if(newpassword.length()<6){
        newpassword+=passbg;
    Screen.clearDisplay();
loginScreen();
 }
      }
      }
}
 }
}
if(digitalRead(BB)||irprev[0]=='u'||irLoop&&irprev[0]=='u'&&irprev[1]==' '){
 delay(100);
if(!sleepingMode){
if(pageVal!=3&&pageVal!=4&&pageVal!=0&&pageVal!=5){
if(selectedItem>1){
  selectedItem--;
}
else if(selectedItem==1){
  selectedItem=8;
}
mainMenu();
}
if(pageVal==3||pageVal==4){
  if(selectedItem>1){
    selectedItem--;
  }
  else if(selectedItem==1){
    selectedItem=4;
      }
      if(pageVal==3)
      settingsScreen();
else if(pageVal==4)
deviceSettings();
}
if(pageVal==5){
  if(selectedItem>1){
    selectedItem--;
  }
  else if(selectedItem<=1){
    selectedItem=2;
  }
  Screen.clearDisplay();
  commandstate();
  }
}
}

 // EKRANLAR YÖNETİMİ
 if(pageVal==1){// Başlangıç ekranı
    startingScreen();
  }
  if(defsleeptime-sleeptime>10000&&!sleepingMode){//Type of ms sleep timer with millis
    sleepingMode=true;
 sleeptime=defsleeptime;
  }
  else if(defsleeptime-sleeptime>5000&&sleepingMode){
  analogWrite(bgled,0);
   sleeptime=defsleeptime;
  }
  
if(sleepingMode){
  sleepingModeScreen();
  }
else{
  analogWrite(bgled,250);
}
}
void commandstate(){
       Screen.setTextColor(WHITE,BLACK);
    menuSlot("IR Command St.",0,0,1);
       Screen.drawRect(18,10,50,25,1); 
        if(selectedItem==1){
     Screen.setTextColor(WHITE,BLACK);
     if(irState)
     menuSlot("ON",30,15,2);
     else
      menuSlot("OFF",25,15,2);
      Screen.setTextColor(BLACK,WHITE);
    menuSlot("BACK",30,40,1);
     }
     else if(selectedItem==2){
        Screen.setTextColor(BLACK,WHITE);
        if(irState)
     menuSlot("ON",30,15,2);
      else
      menuSlot("OFF",25,15,2);
      Screen.setTextColor(WHITE,BLACK);
     menuSlot("BACK",30,40,1);
     }
         Screen.display();
}
void infrared(){
  if(irState){
  if(irprev[1]=='*'){
    
  if(irprev[0]=='1'){//R1 KONTROL
    
           if(!itemstatus[0])
    itemstatus[0]=true;
    else
    itemstatus[0]=false;
    isinchildren[0]=true;
    irprev[0]=' ';
    irprev[1]=' ';
     Screen.clearDisplay();
    mainMenu();
   }
  else if(irprev[0]=='2'){//R1 KONTROL
     
           if(!itemstatus[1])
    itemstatus[1]=true;
    else
    itemstatus[1]=false;
    isinchildren[1]=true;
    irprev[0]=' ';
    irprev[1]=' ';
     Screen.clearDisplay();
    mainMenu();
   }
    else if(irprev[0]=='3'){//R1 KONTROL
       
           if(!itemstatus[2])
    itemstatus[2]=true;
    else
    itemstatus[2]=false;
    isinchildren[2]=true;
    irprev[0]=' ';
    irprev[1]=' ';
     Screen.clearDisplay();
    mainMenu();
   }
    else if(irprev[0]=='4'){//R1 KONTROL
        
           if(!itemstatus[3])
    itemstatus[3]=true;
    else
    itemstatus[3]=false;
    isinchildren[3]=true;
    irprev[0]=' ';
    irprev[1]=' ';
     Screen.clearDisplay();
    mainMenu();
   }
    else if(irprev[0]=='5'){//R1 KONTROL

           if(!itemstatus[4])
    itemstatus[4]=true;
    else
    itemstatus[4]=false;
    isinchildren[4]=true;
    irprev[0]=' ';
    irprev[1]=' ';
     Screen.clearDisplay();
    mainMenu();
   }
  }
  if(irrecv.decode(&results)) {
      //Serial.println(results.value,HEX);    
           switch(results.value)
      {
        delay(100);
        case 0xFF6897:irval= '1';break; // Button 1
        case 0xFF9867:irval= '2'; break; // Button 2
        case 0xFFB04F:irval= '3';break; // Button 3
        case 0xFF30CF:irval= '4';break; // Button 4
        case 0xFF18E7:irval= '5'; break; // Button 5
        case 0xFF7A85:irval= '6'; break; // Button 6
        case 0xFF10EF:irval= '7'; break; // Button 7
        case 0xFF38C7:irval= '8';break; // Button 8
        case 0xFF5AA5:irval= '9'; break; // Button 9
        case 0xFF4AB5:irval= '0'; break; // Button 0          
        case 0xFF629D:irval= 'u';break;// UPArrow  
        case 0xFF22DD:irval= 'L'; break; // LArrow
        case 0xFF02FD:irval= 'o'; break; // OK
        case 0xFFC23D:irval= 'r'; break; // RArrow
        case 0xFFA857:irval= 'd';break; // DARROW
        case 0xFF42BD:irprev[1]='*';break; // Star
        case 0xFF52AD:irprev[1]='#';break; // Square
        case 0xFFFFFFFF: irLoop=true; break;//Loop
                    }
      irprev[0]=irval;    
               irrecv.resume(); // Receive the next value  
  }
  else {
    if(irprev[1]==' ')
         irLoop=false;
   irprev[0]=' ';
   irval = ' ';
      }
  }
}
void deviceSettings(){
  Screen.clearDisplay();
  String lockstr;
 if(lockstate){lockstr="[ON]";} else{lockstr="[OFF]";}
    Screen.setTextColor(WHITE,BLACK);
  menuSlot("Security Set",10,0,1);
  switch (selectedItem){
    case 1:
 Screen.setTextColor(WHITE,BLACK);
menuSlot("PASS:"+password,7,10,1);
  Screen.setTextColor(BLACK,WHITE);
menuSlot("LOCK SCREEN",5,20,1);
menuSlot("LOCK St:"+lockstr,5,30,1);
menuSlot("BACK",50,40,1);
    break;
    case 2:
  Screen.setTextColor(WHITE,BLACK);
menuSlot("LOCK SCREEN",7,20,1);
    Screen.setTextColor(BLACK,WHITE);
menuSlot("PASS:"+password,5,10,1);
menuSlot("LOCK St:"+lockstr,5,30,1);
menuSlot("BACK",50,40,1);
    break;
    case 3:
 Screen.setTextColor(WHITE,BLACK);
menuSlot("LCK St:"+lockstr,7,30,1);
    Screen.setTextColor(BLACK,WHITE);
menuSlot("PASS:"+password,5,10,1);
menuSlot("LOCK SCREEN",5,20,1);
menuSlot("BACK",50,40,1);
    break;
    case 4:
  Screen.setTextColor(WHITE,BLACK);
menuSlot("BACK",50,40,1);
    Screen.setTextColor(BLACK,WHITE);
menuSlot("PASS:"+password,5,10,1);
menuSlot("LOCK SCREEN",5,20,1);
menuSlot("LOCK St:"+lockstr,5,30,1);
    break;
  }
}
void loginScreen(){
  Screen.setTextColor(BLACK,WHITE);
  if(lockreal){
  if(!changenewPass)
  menuSlot("LOCK",28,2,1);
  else
  menuSlot("NEW PASS",20,2,1);
  
   menuSlot("Pass:"+newpassword,2,11,1);
  Screen.drawRect(20,0,45,10,1);//Locked Çerçeve
  Screen.setTextColor(BLACK,WHITE);//TM
  menuSlot("JazzCorp",15,40,1);
  
//LINES
Screen.drawLine(0,20,84,20,1);//(X1,Y1,X2,Y2)// Horizontal Line 1
Screen.drawLine(0,30,84,30,1); //Horizontal Line 2
Screen.drawLine(0,40,84,40,1); //Horizontal Line 3
Screen.drawLine(0,47,84,47,1);//Horizontal Line 4
Screen.drawLine(10,20,10,40,1);// Vertical Line 1
Screen.drawLine(20,20,20,40,1);// Vertical Line 2
Screen.drawLine(30,20,30,40,1);// Vertical Line 3
Screen.drawLine(40,20,40,40,1);// Vertical Line 4
Screen.drawLine(50,20,50,40,1);// Vertical Line 5
Screen.drawLine(60,20,60,40,1);// Vertical Line 6
Screen.drawLine(70,20,70,40,1);// Vertical Line 7
Screen.drawLine(84,20,84,40,1);// Vertical Line 8
Screen.display();
switch (selectedItem)
{
case 1:
Screen.setTextColor(WHITE,BLACK);
menuSlot("1",2,22,1);//1
passbg = '1';
 Screen.setTextColor(BLACK,WHITE);
menuSlot("2",12,22,1);//2
menuSlot("3",22,22,1);//3
menuSlot("4",32,22,1);//4
menuSlot("5",42,22,1);//5
menuSlot("6",52,22,1);//6
menuSlot("7",62,22,1);//7
menuSlot("8",2,32,1);//8
//Generals
menuSlot("A",12,32,1);//A
menuSlot("B",22,32,1);//B
menuSlot("C",32,32,1);//C
menuSlot("D",42,32,1);//D
menuSlot("W",52,32,1);//W
menuSlot("0",62,32,1);//0
//Controls
menuSlot(">",74,22,1);//Enter
menuSlot("<",74,32,1);//Delete
break;
case 2:
Screen.setTextColor(WHITE,BLACK);
menuSlot("2",12,22,1);//2
passbg = '2';
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("3",22,22,1);//3
menuSlot("4",32,22,1);//4
menuSlot("5",42,22,1);//5
menuSlot("6",52,22,1);//6
menuSlot("7",62,22,1);//7
menuSlot("8",2,32,1);//8
//Generals
menuSlot("A",12,32,1);//A
menuSlot("B",22,32,1);//B
menuSlot("C",32,32,1);//C
menuSlot("D",42,32,1);//D
menuSlot("W",52,32,1);//W
menuSlot("0",62,32,1);//0
//Controls
menuSlot(">",74,22,1);//Enter
menuSlot("<",74,32,1);//Delete
break;
case 3:
  Screen.setTextColor(WHITE,BLACK);
menuSlot("3",22,22,1);//3
passbg = '3';
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("2",12,22,1);//2
menuSlot("4",32,22,1);//4
menuSlot("5",42,22,1);//5
menuSlot("6",52,22,1);//6
menuSlot("7",62,22,1);//7
menuSlot("8",2,32,1);//8
//Generals
menuSlot("A",12,32,1);//A
menuSlot("B",22,32,1);//B
menuSlot("C",32,32,1);//C
menuSlot("D",42,32,1);//D
menuSlot("W",52,32,1);//W
menuSlot("0",62,32,1);
menuSlot(">",74,22,1);//Enter
menuSlot("<",74,32,1);//Delete
break;
case 4:
 Screen.setTextColor(WHITE,BLACK);
menuSlot("4",32,22,1);//4
passbg = '4';
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("2",12,22,1);//2
menuSlot("3",22,22,1);//3
menuSlot("5",42,22,1);//5
menuSlot("6",52,22,1);//6
menuSlot("7",62,22,1);//7
menuSlot("8",2,32,1);//8
//Generals
menuSlot("A",12,32,1);//A
menuSlot("B",22,32,1);//B
menuSlot("C",32,32,1);//C
menuSlot("D",42,32,1);//D
menuSlot("W",52,32,1);//W
menuSlot("0",62,32,1);//0
//Controls
menuSlot(">",74,22,1);//Enter
menuSlot("<",74,32,1);//Delete
break;
case 5:
 Screen.setTextColor(WHITE,BLACK);
menuSlot("5",42,22,1);//5
passbg = '5';
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("2",12,22,1);//2
menuSlot("3",22,22,1);//3
menuSlot("4",32,22,1);//4
menuSlot("6",52,22,1);//6
menuSlot("7",62,22,1);//7
menuSlot("8",2,32,1);//8
//Generals
menuSlot("A",12,32,1);//A
menuSlot("B",22,32,1);//B
menuSlot("C",32,32,1);//C
menuSlot("D",42,32,1);//D
menuSlot("W",52,32,1);//W
menuSlot("0",62,32,1);
menuSlot(">",74,22,1);//Enter
menuSlot("<",74,32,1);//Delete
break;
case 6:
  Screen.setTextColor(WHITE,BLACK);
menuSlot("6",52,22,1);//6
passbg = '6';
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("2",12,22,1);//2
menuSlot("3",22,22,1);//3
menuSlot("5",42,22,1);//5
menuSlot("4",32,22,1);//4
menuSlot("7",62,22,1);//7
menuSlot("8",2,32,1);//8
//Generals
menuSlot("A",12,32,1);//A
menuSlot("B",22,32,1);//B
menuSlot("C",32,32,1);//C
menuSlot("D",42,32,1);//D
menuSlot("W",52,32,1);//W
menuSlot("0",62,32,1);//0
//Controls
menuSlot(">",74,22,1);//Enter
menuSlot("<",74,32,1);//Delete
break;
case 7:
 Screen.setTextColor(WHITE,BLACK);
menuSlot("7",62,22,1);//7
passbg = '7';
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("2",12,22,1);//2
menuSlot("3",22,22,1);//3
menuSlot("5",42,22,1);//5
menuSlot("6",52,22,1);//6
menuSlot("4",32,22,1);//4
menuSlot("8",2,32,1);//8
//Generals
menuSlot("A",12,32,1);//A
menuSlot("B",22,32,1);//B
menuSlot("C",32,32,1);//C
menuSlot("D",42,32,1);//D
menuSlot("0",62,32,1);//Q
//Controls
menuSlot(">",74,22,1);//Enter
menuSlot("<",74,32,1);//Delete
break;
case 8:
  Screen.setTextColor(WHITE,BLACK);
menuSlot("8",2,32,1);//8
passbg = '8';
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("2",12,22,1);//2
menuSlot("3",22,22,1);//3
menuSlot("5",42,22,1);//5
menuSlot("6",52,22,1);//6
menuSlot("7",62,22,1);//7
menuSlot("4",32,22,1);//4
//Generals
menuSlot("A",12,32,1);//A
menuSlot("B",22,32,1);//B
menuSlot("C",32,32,1);//C
menuSlot("D",42,32,1);//D
menuSlot("W",52,32,1);//W
menuSlot("0",62,32,1);//Q
menuSlot(">",74,22,1);//Enter
menuSlot("<",74,32,1);//Delete
break;
case 9:
 Screen.setTextColor(WHITE,BLACK);
menuSlot("A",12,32,1);//A
passbg = 'A';
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("2",12,22,1);//2
menuSlot("3",22,22,1);//3
menuSlot("5",42,22,1);//5
menuSlot("6",52,22,1);//6
menuSlot("7",62,22,1);//7
menuSlot("8",2,32,1);//8
menuSlot("4",32,22,1);//4
//Generals
menuSlot("B",22,32,1);//B
menuSlot("C",32,32,1);//C
menuSlot("D",42,32,1);//D
menuSlot("W",52,32,1);//W
menuSlot("0",62,32,1);//0
//Controls
menuSlot(">",74,22,1);//Enter
menuSlot("<",74,32,1);//Delete
break;
case 10:
 Screen.setTextColor(WHITE,BLACK);
menuSlot("B",22,32,1);//B
passbg = 'B';
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("2",12,22,1);//2
menuSlot("3",22,22,1);//3
menuSlot("5",42,22,1);//5
menuSlot("6",52,22,1);//6
menuSlot("7",62,22,1);//7
menuSlot("8",2,32,1);//8
menuSlot("4",32,22,1);//4
//Generals
menuSlot("A",12,32,1);//A
menuSlot("C",32,32,1);//C
menuSlot("D",42,32,1);//D
menuSlot("W",52,32,1);//W
menuSlot("0",62,32,1);//0
//Controls
menuSlot(">",74,22,1);//Enter
menuSlot("<",74,32,1);//Delete
break;
case 11:
  Screen.setTextColor(WHITE,BLACK);
menuSlot("C",32,32,1);//C
passbg = 'C';
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("2",12,22,1);//2
menuSlot("3",22,22,1);//3
menuSlot("5",42,22,1);//5
menuSlot("6",52,22,1);//6
menuSlot("7",62,22,1);//7
menuSlot("8",2,32,1);//8
menuSlot("4",32,22,1);//4
//Generals
menuSlot("A",12,32,1);//A
menuSlot("B",22,32,1);//B
menuSlot("D",42,32,1);//D
menuSlot("W",52,32,1);//W
menuSlot("0",62,32,1);//0
//Controls
menuSlot(">",74,22,1);//Enter
menuSlot("<",74,32,1);//Delete
break;
case 12:
  Screen.setTextColor(WHITE,BLACK);
  menuSlot("D",42,32,1);//D
passbg = 'D';
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("2",12,22,1);//2
menuSlot("3",22,22,1);//3
menuSlot("5",42,22,1);//5
menuSlot("6",52,22,1);//6
menuSlot("7",62,22,1);//7
menuSlot("8",2,32,1);//8
menuSlot("4",32,22,1);//4
//Generals
menuSlot("A",12,32,1);//A
menuSlot("B",22,32,1);//B
menuSlot("C",32,32,1);//C

menuSlot("W",52,32,1);//W
menuSlot("0",62,32,1);//Q
//Controls
menuSlot(">",74,22,1);//Enter
menuSlot("<",74,32,1);//Delete
break;
case 13:
 Screen.setTextColor(WHITE,BLACK);
passbg = 'W';
menuSlot("W",52,32,1);//W
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("2",12,22,1);//2
menuSlot("3",22,22,1);//3
menuSlot("5",42,22,1);//5
menuSlot("6",52,22,1);//6
menuSlot("7",62,22,1);//7
menuSlot("8",2,32,1);//8
menuSlot("4",32,22,1);//4
//Generals
menuSlot("A",12,32,1);//A
menuSlot("B",22,32,1);//B
menuSlot("C",32,32,1);//C
menuSlot("D",42,32,1);//D
menuSlot("0",62,32,1);//Q
//Controls
menuSlot(">",74,22,1);//Enter
menuSlot("<",74,32,1);//Delete
break;
case 14:
 Screen.setTextColor(WHITE,BLACK);
menuSlot("0",62,32,1);//Q
passbg = '0';
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("2",12,22,1);//2
menuSlot("3",22,22,1);//3
menuSlot("5",42,22,1);//5
menuSlot("6",52,22,1);//6
menuSlot("7",62,22,1);//7
menuSlot("8",2,32,1);//8
menuSlot("4",32,22,1);//4
//Generals
menuSlot("A",12,32,1);//A
menuSlot("B",22,32,1);//B
menuSlot("C",32,32,1);//C
menuSlot("D",42,32,1);//D
menuSlot("W",52,32,1);//W

//Controls
menuSlot(">",74,22,1);//Enter
menuSlot("<",74,32,1);//Delete
break;
case 15:
Screen.setTextColor(WHITE,BLACK);
menuSlot(">",74,22,1);//Enter
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("2",12,22,1);//2
menuSlot("3",22,22,1);//3
menuSlot("5",42,22,1);//5
menuSlot("6",52,22,1);//6
menuSlot("7",62,22,1);//7
menuSlot("8",2,32,1);//8
menuSlot("4",32,22,1);//4
//Generals
menuSlot("A",12,32,1);//A
menuSlot("B",22,32,1);//B
menuSlot("C",32,32,1);//C
menuSlot("D",42,32,1);//D
menuSlot("W",52,32,1);//W
menuSlot("0",62,32,1);//Q
//Controls
menuSlot("<",74,32,1);//Delete
break;
case 16:
  Screen.setTextColor(WHITE,BLACK);
menuSlot("<",74,32,1);//Delete
 Screen.setTextColor(BLACK,WHITE);
menuSlot("1",2,22,1);//1
menuSlot("2",12,22,1);//2
menuSlot("3",22,22,1);//3
menuSlot("5",42,22,1);//5
menuSlot("6",52,22,1);//6
menuSlot("7",62,22,1);//7
menuSlot("8",2,32,1);//8
menuSlot("4",32,22,1);//4
//Generals
menuSlot("A",12,32,1);//A
menuSlot("B",22,32,1);//B
menuSlot("C",32,32,1);//C
menuSlot("D",42,32,1);//D
menuSlot("W",52,32,1);//W
menuSlot("0",62,32,1);//Q
//Controls
menuSlot(">",74,22,1);//Enter
break;
}
  }
  else{
    if(!changenewPass){
    Screen.setTextColor(BLACK,WHITE);
  menuSlot("UNLOCKED",20,20,1);
 delay(1000);
 pageVal=2;
 Screen.clearDisplay();
 selectedItem=1;
 mainMenu();
    }
     }
}
void settingsScreen(){
  Screen.clearDisplay();
    Screen.setTextColor(WHITE,BLACK);
  menuSlot("SETTINGS",20,0,1);
switch (selectedItem){
   case 1:
   menuSlot("Option 1",7,10,1);
  Screen.setTextColor(BLACK,WHITE);
  menuSlot("Option 2",5,20,1);
  menuSlot("Security Set",5,30,1);
  menuSlot("BACK",50,40,1);
break;
  case 2:
  menuSlot("Option 2",7,20,1);
  Screen.setTextColor(BLACK,WHITE);
  menuSlot("Option 1",5,10,1);
  menuSlot("Security Set",5,30,1);
  menuSlot("BACK",50,40,1);
  break;
  case 3:
  menuSlot("Security Set",7,30,1);
  Screen.setTextColor(BLACK,WHITE);
  menuSlot("Option 1",5,10,1);
  menuSlot("Option 2",5,20,1);
  menuSlot("BACK",50,40,1);
  break;
   case 4:
    menuSlot("BACK",50,40,1);
  Screen.setTextColor(BLACK,WHITE);
   menuSlot("Option 1",5,10,1);
  menuSlot("Option 2",5,20,1);
  menuSlot("Security Set",5,30,1);
    break;
}
  Screen.display();
}
void sleepingModeScreen(){
  Screen.clearDisplay();
 delay(1);
  menuSlot("SLEEPING",20,10,1);
  Screen.setTextColor(WHITE,BLACK);
delay(1);
  menuSlot("MODE",20,20,2);
  Screen.setTextColor(BLACK,WHITE);
  Screen.display();
}
void serialData(){
    if(Serial.available()){
    data = Serial.readString();
          if(data=="R1ON"){
    itemstatus[0]=true;
    isinchildren[0]=true;
             }
   if(data=="R1OFF"){
    itemstatus[0]=false;
    isinchildren[0]=true;
      }
    if(data=="R2ON"){
   itemstatus[1]=true;
   isinchildren[1]=true;
       }
    if(data=="R2OFF"){
 itemstatus[1]=false;
 isinchildren[1]=true;
          }
   if(data=="R3ON"){
   itemstatus[2]=true;
   isinchildren[2]=true;
     }
    if(data=="R3OFF"){
 itemstatus[2]=false;
 isinchildren[2]=true;
    }
       if(data=="R4ON"){
   itemstatus[3]=true;
   isinchildren[3]=true;
       }
   if(data=="R4OFF"){
 itemstatus[3]=false;
 isinchildren[3]=true;
     }
       if(data=="R5ON"){
   itemstatus[4]=true;
   isinchildren[4]=true;
       }
    if(data=="R5OFF"){
 itemstatus[4]=false;
 isinchildren[4]=true;
    }
    if(!lockreal){
       Screen.clearDisplay();
      mainMenu();
    }
  }
}
void startingScreen(){  
  analogWrite(bgled,250);
   Screen.clearDisplay();
    Screen.setCursor(13,5);
    Screen.setTextSize(2);
    Screen.setTextColor(BLACK,WHITE);
    Screen.print("HOUSE");
    Screen.setTextSize(1);
    Screen.setCursor(23,20);
    Screen.print("CONTROL");
    Screen.display();
   delay(500);
   Screen.setCursor(30,40);
    Screen.setTextSize(1);
   Screen.setTextColor(BLACK,WHITE);
   Screen.print("Jazz Corp");
    Screen.display();
   delay(1000);
   sleepingMode=false;  
    selectedItem=1;
   if(lockstate){
    if(password==""){
       pageVal=2;
    Screen.clearDisplay();
      mainMenu();
    }
    else{
   pageVal=0;
         Screen.clearDisplay();
   loginScreen();
    }
   }
   else{
    pageVal=2;
    Screen.clearDisplay();
      mainMenu();
       }
          

}
void mainMenu(){
  Screen.clearDisplay();
items[0]="R1:";
items[1]="R2:"; 
items[2]="R3:";
items[3]="R4:";
items[4]="R5:";
if(itemstatus[0]){items[0]+="ON";}else{items[0]+="OFF";}
if(itemstatus[1]){items[1]+="ON";}else{items[1]+="OFF";}
if(itemstatus[2]){items[2]+="ON";}else{items[2]+="OFF";}
if(itemstatus[3]){items[3]+="ON";}else{items[3]+="OFF";}
if(itemstatus[4]){items[4]+="ON";}else{items[4]+="OFF";}
switch (selectedItem){
  case 1:
Screen.setCursor(15,0);
Screen.setTextSize(1);
Screen.setTextColor(BLACK,WHITE);
Screen.print("[STATUS]");
Screen.drawRect(0,10,84,38,1);
Screen.drawLine(0,20,84,20,1);//(X1,Y1,X2,Y2)
Screen.drawLine(0,30,84,30,1);
Screen.drawLine(42,30,42,20,1);
Screen.drawLine(42,48,42,30,1);
Screen.setTextColor(WHITE,BLACK);
menuSlot(items[0],1,11,1);
Screen.setTextColor(BLACK);
menuSlot(items[1],2,22,1);
Screen.setTextColor(BLACK);
menuSlot(items[2],44,22,1);
Screen.setTextColor(BLACK);
menuSlot(items[3],2,33,1);
Screen.setTextColor(BLACK);
menuSlot(items[4],44,33,1);
Screen.display();
  break;
   case 2:
  Screen.setCursor(15,0);
Screen.setTextSize(1);
Screen.setTextColor(BLACK,WHITE);
Screen.print("[STATUS]");
Screen.drawRect(0,10,84,38,1);
Screen.drawLine(0,20,84,20,1);//(X1,Y1,X2,Y2)
Screen.drawLine(0,30,84,30,1);
Screen.drawLine(42,30,42,20,1);
Screen.drawLine(42,48,42,30,1);
Screen.setTextColor(BLACK);
menuSlot(items[0],1,11,1);
Screen.setTextColor(WHITE,BLACK);
menuSlot(items[1],2,22,1);
Screen.setTextColor(BLACK);
menuSlot(items[2],44,22,1);
Screen.setTextColor(BLACK);
menuSlot(items[3],2,33,1);
Screen.setTextColor(BLACK);
menuSlot(items[4],44,33,1);
Screen.display();
  break;
   case 3:
 Screen.setCursor(15,0);
Screen.setTextSize(1);
Screen.setTextColor(BLACK,WHITE);
Screen.print("[STATUS]");
Screen.drawRect(0,10,84,38,1);
Screen.drawLine(0,20,84,20,1);//(X1,Y1,X2,Y2)
Screen.drawLine(0,30,84,30,1);
Screen.drawLine(42,30,42,20,1);
Screen.drawLine(42,48,42,30,1);
Screen.setTextColor(BLACK);
menuSlot(items[0],1,11,1);
Screen.setTextColor(BLACK);
menuSlot(items[1],2,22,1);
Screen.setTextColor(WHITE,BLACK);
menuSlot(items[2],44,22,1);
Screen.setTextColor(BLACK);
menuSlot(items[3],2,33,1);
Screen.setTextColor(BLACK);
menuSlot(items[4],44,33,1);
Screen.display();
  break;
   case 4:
  Screen.setCursor(15,0);
Screen.setTextSize(1);
Screen.setTextColor(BLACK,WHITE);
Screen.print("[STATUS]");
Screen.drawRect(0,10,84,38,1);
Screen.drawLine(0,20,84,20,1);//(X1,Y1,X2,Y2)
Screen.drawLine(0,30,84,30,1);
Screen.drawLine(42,30,42,20,1);
Screen.drawLine(42,48,42,30,1);
Screen.setTextColor(BLACK);
menuSlot(items[0],1,11,1);
Screen.setTextColor(BLACK);
menuSlot(items[1],2,22,1);
Screen.setTextColor(BLACK);
menuSlot(items[2],44,22,1);
Screen.setTextColor(WHITE,BLACK);
menuSlot(items[3],2,33,1);
Screen.setTextColor(BLACK);
menuSlot(items[4],44,33,1);
Screen.display();
  break;
   case 5:
 Screen.setCursor(15,0);
Screen.setTextSize(1);
Screen.setTextColor(BLACK,WHITE);
Screen.print("[STATUS]");
Screen.drawRect(0,10,84,38,1);
Screen.drawLine(0,20,84,20,1);//(X1,Y1,X2,Y2)
Screen.drawLine(0,30,84,30,1);
Screen.drawLine(42,30,42,20,1);
Screen.drawLine(42,48,42,30,1);
Screen.setTextColor(BLACK);
menuSlot(items[0],1,11,1);
Screen.setTextColor(BLACK);
menuSlot(items[1],2,22,1);
Screen.setTextColor(BLACK);
menuSlot(items[2],44,22,1);
Screen.setTextColor(BLACK);
menuSlot(items[3],2,33,1);
Screen.setTextColor(WHITE,BLACK);
menuSlot(items[4],44,33,1);
Screen.display();
  break;
   case 6:
 Screen.drawRect(0,10,84,48,1);
  Screen.setCursor(15,0);
Screen.setTextSize(1);
Screen.setTextColor(BLACK,WHITE);
Screen.print("[OPTIONS]");
Screen.display();
Screen.setTextColor(WHITE,BLACK);
menuSlot("SLOT1",7,15,1);
Screen.setTextColor(BLACK,WHITE);
menuSlot("SLOT2",5,25,1);
Screen.setTextColor(BLACK,WHITE);
menuSlot("Settings",5,35,1);
  break;
   case 7:
 Screen.drawRect(0,10,84,48,1);
  Screen.setCursor(15,0);
Screen.setTextSize(1);
Screen.setTextColor(BLACK,WHITE);
Screen.print("[OPTIONS]");
Screen.display();
  Screen.setTextColor(BLACK,WHITE);
menuSlot("SLOT1",5,15,1);
Screen.setTextColor(WHITE,BLACK);
menuSlot("SLOT2",7,25,1);
Screen.setTextColor(BLACK,WHITE);
menuSlot("Settings",5,35,1);
  break;
   case 8:
 Screen.drawRect(0,10,84,48,1);
  Screen.setCursor(15,0);
Screen.setTextSize(1);
Screen.setTextColor(BLACK,WHITE);
Screen.print("[OPTIONS]");
Screen.display();
  Screen.setTextColor(BLACK,WHITE);
menuSlot("SLOT1",5,15,1);
Screen.setTextColor(BLACK,WHITE);
menuSlot("SLOT2",5,25,1);
Screen.setTextColor(WHITE,BLACK);
menuSlot("Settings",7,35,1);
  break;
  default:
  selectedItem=1;
  return mainMenu();
}
}
void tools(){//isinchildren ile açıp kapatma olayı yapılıyor looptan çıkarılıyor yani. + itemstatuslada açık olup olmadıgını anlıyoruz
s1st = !digitalRead(s1); //buton ters geldiğinden tersledim
     delay(100);
      if(itemstatus[0]&&isinchildren[0]){//PC 
    isinchildren[0]=false;
    Serial.println("r1 ON");
    digitalWrite(r1,HIGH);
    delay(1000);
    digitalWrite(r1,LOW);
       }
    rly2void();//role 2// ODA LAMBASI
 
  if(itemstatus[2]){//RÖLE 3 SLİM RÖLELER // OMRON SSR
    isinchildren[2]=false;
    digitalWrite(r3,HIGH);
  }
  else{
     isinchildren[2]=false;
    digitalWrite(r3,LOW);
  }
     if(s1st&&leavelooping==0){ 
       if(!itemstatus[1]){
       leavelooping = 1;
         digitalWrite(r2,HIGH);
       itemstatus[1]=true;
      if(!lockreal){
       pageVal = 2;
   Screen.clearDisplay();
    mainMenu();
            }
       }
        else {
          itemstatus[1]=false;
                        }
                  }
      else if(leavelooping == 1){
        if(!s1st){
     leavelooping = 0;
     if(itemstatus[1]){
      digitalWrite(r2,LOW);
         itemstatus[1]=false;
          if(!lockreal){
       pageVal = 2;
   Screen.clearDisplay();
    mainMenu();
            }
         }
        }
        else{//s1st == 1
                  if(isinchildren[1]){
          isinchildren[1]=false;
       if(itemstatus[1]){
          digitalWrite(r2,HIGH);
                                              }
          else{
            digitalWrite(r2,LOW);
                                                 }
              if(!lockreal){
       pageVal = 2;
   Screen.clearDisplay();
    mainMenu();
            }
             }
         
        }
                   }
          else if(!s1st&&!itemstatus[1]){//ANAHTAR AÇIK, RÖLE AÇIK
        digitalWrite(r2,LOW);
        isinchildren[1]=false;
        itemstatus[1]=false;
        leavelooping = 0;
                      }
  else if(!s1st){// ANAHTAR AÇIK,RÖLE KAPALI
                if(isinchildren[1]){//BM Butonuna basıldıgında
                  isinchildren[1]=false;
      if(itemstatus[1]){
       digitalWrite(r2,HIGH);
    
      }
      else{
          digitalWrite(r2,LOW);
             }
      leavelooping = 0;
              }
            }
                  if(isinchildren[1]){//BM Butonuna basıldıgında
                  isinchildren[1]=false;
      if(itemstatus[1]){
       digitalWrite(r2,HIGH);
    
      }
      else{
          digitalWrite(r2,LOW);
             }
      leavelooping = 0;
              }
            
            }
            void rly2void(){
              Serial.println(digitalRead(r2));
   if(s1st&&leavelooping==0){ 
       if(!itemstatus[1]){
       leavelooping = 1;
         digitalWrite(r2,HIGH);
       itemstatus[1]=true;
      if(!lockreal){
       pageVal = 2;
   Screen.clearDisplay();
    mainMenu();
            }
       }
        else {
          itemstatus[1]=false;
                        }
                  }
      else if(leavelooping == 1){//
        if(!s1st){
     leavelooping = 0;
     if(itemstatus[1]){
      digitalWrite(r2,LOW);
         itemstatus[1]=false;
          if(!lockreal){
       pageVal = 2;
   Screen.clearDisplay();
    mainMenu();
            }
         }
        }
        else{//s1st == 1
                  if(isinchildren[1]){
          isinchildren[1]=false;
       if(itemstatus[1]){
          digitalWrite(r2,HIGH);
                                              }
          else{
            digitalWrite(r2,LOW);
                                                 }
              if(!lockreal){
       pageVal = 2;
   Screen.clearDisplay();
    mainMenu();
            }
             }
         
        }
                   }
          else if(!s1st&&!itemstatus[1]){//ANAHTAR AÇIK, RÖLE AÇIK
        digitalWrite(r2,LOW);
        isinchildren[1]=false;
        itemstatus[1]=false;
        leavelooping = 0;
                      }
  else if(!s1st){// ANAHTAR AÇIK,RÖLE KAPALI
                if(isinchildren[1]){//BM Butonuna basıldıgında
                  isinchildren[1]=false;
      if(itemstatus[1]){
       digitalWrite(r2,HIGH);
    
      }
      else{
          digitalWrite(r2,LOW);
             }
      leavelooping = 0;
              }
            }
                  if(isinchildren[1]){//BM Butonuna basıldıgında
                  isinchildren[1]=false;
      if(itemstatus[1]){
       digitalWrite(r2,HIGH);
    
      }
      else{
          digitalWrite(r2,LOW);
             }
      leavelooping = 0;
              }
            }
void menuSlot(String text,int x,int y,int tSize){//Created TEXT (menuSlot("EXAMPLE",0,0,1))
delay(1);
  Screen.setCursor(x,y);
  Screen.setTextSize(tSize);
  Screen.print(text);
  Screen.display();
}
