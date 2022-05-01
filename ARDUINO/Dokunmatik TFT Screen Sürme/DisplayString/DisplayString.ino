#include <Adafruit_GFX.h>    // Core graphics library
#include <Adafruit_TFTLCD.h> // Hardware-specific library
#include <TouchScreen.h>
#define LCD_RESET A4
#define LCD_CS A3 // Chip Select goes to Analog 3
#define LCD_CD A2 // Command/Data goes to Analog 2
#define LCD_WR A1 // LCD Write goes to Analog 1
#define LCD_RD A0 // LCD Read goes to Analog 0

#define YP A3  // must be an analog pin, use "An" notation!
#define XM A2  // must be an analog pin, use "An" notation!
#define YM 9   // can be a digital pin
#define XP 8   // can be a digital pin

#define TS_MINX 150
#define TS_MINY 120
#define TS_MAXX 920
#define TS_MAXY 940

TouchScreen ts = TouchScreen(XP, YP, XM, YM, 300);

#define LCD_RESET A4 // Can alternately just connect to Arduino's reset pin
#define	BLACK   0x0000
#define	BLUE    0x001F
#define	RED     0xF800
#define	GREEN   0x07E0
#define CYAN    0x07FF
#define MAGENTA 0xF81F
#define YELLOW  0xFFE0
#define WHITE   0xFFFF
byte spec;
int menustate;
Adafruit_TFTLCD tft(LCD_CS, LCD_CD, LCD_WR, LCD_RD, LCD_RESET);
Adafruit_GFX_Button buttons[15];
 uint16_t identifier = tft.readID();
void setup(void) {
  Serial.begin(9600);
  tft.reset();
  if(identifier==0x0101)
      identifier=0x9341;
  tft.begin(identifier);
menustate =0;
  tft.setRotation(2);
starter();
 spec = 0;
}

#define MINPRESSURE 10
#define MAXPRESSURE 1000
void loop(void) {
  digitalWrite(13, HIGH);
     TSPoint p = ts.getPoint();
     digitalWrite(13, LOW); 
          pinMode(XM, OUTPUT);
  pinMode(YP, OUTPUT);
    if (p.z > MINPRESSURE && p.z < MAXPRESSURE) {
      // scale from 0->1023 to tft.width
    p.x = map(p.x, TS_MINX, TS_MAXX, tft.width(), 0);
    p.y = map(p.y, TS_MINY, TS_MAXY, tft.height(), 0);
    delay(1000);
    Serial.print("("); Serial.print(p.x);
    Serial.print(", "); Serial.print(p.y);
    Serial.println(")"); 
   }
   if(menustate==0){
    if((p.x>129&&p.x<234)&&(p.y>10 &&p.y<38)){
     tft.reset();
   tft.begin(identifier);
   menustate=1;
   mainmenu();
      }
   }
   else if(menustate==1){
 if((p.y > 23 && p.y < 67) && spec == 0)
   {
                tft.fillRect(10,260,220,30,YELLOW);   
                        delay(1);
               tft.setCursor(50,270);
  tft.setTextColor(RED);
  tft.setTextSize(2);
  tft.println("Maker BY");
    Serial.println("Maker BY basildi");
    tft.reset();
   tft.begin(identifier);
  maker();
 spec = 1;
      }    
      else if((p.y >241 && p.y<260)&&(p.x>52 && p.x<190)){
        Serial.println("GO BACK");
        tft.reset();
        tft.begin(identifier);
         menustate=0;
         tft.setRotation(2);
        starter();
                      }
   else if((p.y >74 && p.y < 108)&& spec == 0){
                    tft.fillRect(10,220,220,30,YELLOW);   
                                        delay(1);
                 tft.setCursor(50,230);
  tft.setTextColor(RED);
  tft.setTextSize(2);
  tft.println("Bos2");
  Serial.println("Bos2 basildi");
        }
     else if((p.y >117 && p.y < 148)&& spec == 0){
               tft.fillRect(10,180,220,30,YELLOW);   
                             delay(1);
                 tft.setCursor(50,190);
  tft.setTextColor(RED);
  tft.setTextSize(2);
  tft.println("Bos1");
  Serial.println("Bos1 basildi");
                }
      else if((p.y >155 && p.y < 184)&& spec == 0){
         tft.fillRect(10,140,220,30,YELLOW);   
                      delay(1);
              tft.setCursor(50,150);
  tft.setTextColor(RED);
  tft.setTextSize(2);
  tft.println("Date&Time");
  Serial.println("Date&Time basildi");
        }
     else if((p.y >=194 && p.y <= 224) && spec == 0){
    tft.fillRect(10,100,220,30,YELLOW);                
       delay(1);
            tft.setCursor(50,110);
  tft.setTextColor(RED);
  tft.setTextSize(2);
  tft.println("Temperature");        
  Serial.println("Temp basildi");

        }
      else if ((p.y>=0 && p.y <=90)&&(p.x >= 10 && p.x <= 60 )&&spec == 1){
          tft.reset();
          tft.begin(identifier);
          mainmenu();
          spec = 0;
          } 
   }
    }
void mainmenu() {
  tft.setRotation(2);
  draw();
  tft.setCursor(100,70);
  tft.setTextColor(GREEN);
  tft.setTextSize(2);
  tft.println("BACK");
  tft.setCursor(75,18);
  tft.setTextColor(WHITE);
  tft.setTextSize(4);
  tft.println("MENU");
  tft.setCursor(50,110);
  tft.setTextColor(RED);
  tft.setTextSize(2);
  tft.println("Temperature");
   tft.setCursor(50,150);
  tft.setTextColor(RED);
  tft.setTextSize(2);
  tft.println("Date&Time");
   tft.setCursor(50,190);
  tft.setTextColor(RED);
  tft.setTextSize(2);
  tft.println("Bos1");
   tft.setCursor(50,230);
  tft.setTextColor(RED);
  tft.setTextSize(2);
  tft.println("Bos2");
 tft.setCursor(50,270);
  tft.setTextColor(RED);
  tft.setTextSize(2);
  tft.println("Maker BY");
  
  }
  void draw(){
   tft.fillRect(60,60,130,30,BLACK);
    tft.drawRect(60,60,130,30,GREEN);
    tft.fillRect(10,10,220,40,BLACK);
      tft.drawRect(10,10,220,40,RED);
 tft.fillRect(10,100,220,30,BLACK); 
      tft.drawRect(10,100,220,30,GREEN);
   tft.fillRect(10,140,220,30,BLACK); 
    tft.drawRect(10,140,220,30,GREEN);
     tft.fillRect(10,180,220,30,BLACK); 
    tft.drawRect(10,180,220,30,GREEN);
     tft.fillRect(10,220,220,30,BLACK); 
    tft.drawRect(10,220,220,30,GREEN);
      tft.fillRect(10,260,220,30,BLACK); 
    tft.drawRect(10,260,220,30,GREEN);
    }
    void starter(){
  tft.drawRect(10,20,220,30,WHITE);
   tft.setCursor(85,30);
  tft.setTextColor(WHITE);
  tft.setTextSize(2);
  tft.println("FIRST");
                     tft.setCursor(150,310);
        tft.setTextColor(GREEN);
        tft.setTextSize(1); 
 tft.println("Jazz Corp-Tech.");
 tft.drawRect(10,290,100,30,RED);
                           tft.setCursor(30,300);
                           tft.setTextColor(RED);
                           tft.setTextSize(2);
                           tft.println("ENTER");                           
                   }
    void maker(){
        tft.setRotation(2);
      tft.fillRect(10,20,220,120,BLACK);
    tft.drawRect(10,20,220,120,BLACK);
    tft.setCursor(30,40);
tft.setTextColor(BLUE);
      tft.setTextSize(4);
            tft.println("MAKER BY");
            tft.setCursor(180,280);
            tft.setTextColor(RED);
            tft.setTextSize(2);
            tft.println("BACK");
            tft.setCursor(20,100);
            tft.setTextColor(WHITE);
            tft.setTextSize(4);
            tft.println("Enes Ipek");
            tft.setTextColor(RED);
               tft.setTextSize(3);
                  tft.setCursor(50,160);
                tft.println("FACEBOOK");
                tft.setTextSize(2);
                tft.setTextColor(BLACK);
                               tft.println(" Facebook:liveenes");
                                    tft.setTextColor(RED);
      tft.setTextSize(3);
        tft.println("   NUMBER");
              tft.setTextColor(BLACK);
              tft.setTextSize(2);
              tft.println("  0(542) 479 1753");
              }
