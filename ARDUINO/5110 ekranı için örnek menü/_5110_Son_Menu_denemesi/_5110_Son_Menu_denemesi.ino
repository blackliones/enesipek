
//#include <Time.h>
#include <Wire.h> 
#include <OneWire.h> 
#include <EEPROM.h>
#include <SPI.h>
#include <Adafruit_GFX.h>
#include <Adafruit_PCD8544.h>
#include <DS1307RTC.h>
#include<CountUpDownTimer.h>


Adafruit_PCD8544 display = Adafruit_PCD8544(3, 4, 5, 6, 7); // Ekrani tanimliyoruz

CountUpDownTimer T(DOWN);                                     
CountUpDownTimer C(DOWN);                                     
CountUpDownTimer D(DOWN);                                     
CountUpDownTimer E(DOWN);                                     
CountUpDownTimer HA1(DOWN);                                   


int DS18S20_Pin = 2;                                          
OneWire ds(DS18S20_Pin);                                      
#define led1 3                                                
int buzzer = 4;                                               
int buton1 = 5;                                               
int buton2 = 6;                                               
int buton3 = 7;                                               
int okbuton;                                                  
int okdurum = 0;
int temperature;                                              
int mainmenuid=0;                                             
int ayarmenuid=0;                                             
int manuelmenuid=0;                                           
int adim1menuid=0;                                            
int adim2menuid=0;                                            
int adim3menuid=0;                                            
int adim4menuid=0;                                            
int manuelmenu1id=0;                                          
int tarifmenuid=0;                                            
int birayapmenuid=0;                                          
int bira1menuid=0;                                            
int mashmenuid=0;                                             
int stp1menuid=0;                                             
int stp2menuid=0;                                             
int stp3menuid=0;                                             
int boilmenuid=0;                                             
int hopmenuid=0;                                              
volatile byte dgr = 0;                                        
int counter = 1;                                              
int counter1 = 1;                                             
int SETm;                                                     
int SET1;                                                     
int SET2;                                                     
int SET3;                                                     
int SETb;                                                     
int ZMNm;                                                     
int ZMN1;                                                     
int ZMN2;                                                     
int ZMN3;                                                     
int ZMNb;                                                     
int ZMNha1;                                                   
int ZMNha2;                                                   
int ZMNha3;                                                   


void setup(void) 
{
  pinMode(buzzer,OUTPUT);                                     
  pinMode(led1,OUTPUT);                                       
  pinMode(buton1, INPUT);                                     
  pinMode(buton2, INPUT);                                     
  pinMode(buton3, INPUT);                                     
  pinMode(8, OUTPUT);                                         
  SETm = EEPROM.read(0);                                      
  SET1 = EEPROM.read(1);                                      
  SET2 = EEPROM.read(2);                                      
  SET3 = EEPROM.read(3);                                      
  SETb = 33;                                        
  ZMNm = EEPROM.read(5);                            
  ZMN1 = EEPROM.read(6);                            
  ZMN2 = EEPROM.read(7);                            
  ZMN3 = EEPROM.read(8);                            
  ZMNb = EEPROM.read(9);                            
  ZMNha1 = EEPROM.read(10);                         
  ZMNha2 = EEPROM.read(11);                         
  ZMNha3 = EEPROM.read(12);                         
  dgr = EEPROM.read(13);                            

  T.SetTimer(ZMN1*60);                              
  T.StartTimer();
  C.SetTimer(ZMN2*60);                              
  C.StartTimer();
  D.SetTimer(ZMN3*60);                                               
  D.StartTimer();
  E.SetTimer(ZMNb*60);                                               
  E.StartTimer();
  HA1.SetTimer(ZMNha1*60);                                           
  HA1.StartTimer();
  display.begin();                                              
  display.setRotation(2);                                       
  display.setContrast(60);                                     
  digitalWrite(8,HIGH);                                        
  display.display();                                           
  delay(2000);                                                 
  display.clearDisplay();                                      
}

void loop(void) 
{
  display.display();                                           
  ana_ekran();                                                 
}

//////////////////Ds18B20 SENSORUNDEN GELEN DEGERI DERECE CINSINE CEVIRIYORUZ//////////////////
float getTemp()                                                
{
  byte data[12];
  byte addr[8];

  if ( !ds.search(addr)) 
  {
    ds.reset_search();
    return -1000;
  }

  if ( OneWire::crc8( addr, 7) != addr[7]) 
  {
    display.setCursor(0,1);
    display.print("CRC is not valid!");
    return -1000;
  }

  if ( addr[0] != 0x10 && addr[0] != 0x28) 
  {
    display.setCursor(0,1);
    display.print("Device is not recognized");
    return -1000;
  }

  ds.reset();
  ds.select(addr);
  ds.write(0x44,1); 

  byte present = ds.reset();
  ds.select(addr);    
  ds.write(0xBE); // Read Scratchpad

  for (int i = 0; i < 9; i++) { // we need 9 bytes
    data[i] = ds.read();
  }

  ds.reset_search();

  byte MSB = data[1];
  byte LSB = data[0];

  float tempRead = ((MSB << 8) | LSB); 
  float TemperatureSum = tempRead / 16;

  return TemperatureSum;

}

void ana_ekran()
{
  while(1)
  { display.display();
    analogoku();
    display.clearDisplay();
    temperature = getTemp();
    display.setTextSize(1);
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("ANA MENU");
    display.setCursor(55, 0);
    display.print(temperature);
    display.drawCircle(69,2,1, BLACK);
    display.setCursor(73, 0);
    display.print("C");
    display.drawFastHLine(0,7,84,BLACK); // 1.  yatay çizgi
    display.drawFastVLine(0,7,40,BLACK); // Soldaki dikey çizgi
    display.drawFastHLine(0,27,84,BLACK); // 3. yatay çizgi
    display.drawFastHLine(0,17,84,BLACK); // 2. yatay çizgi
    display.drawFastHLine(0,37,84,BLACK); // 4. yatay çizgi
    display.drawFastHLine(0,47,84,BLACK); // 5. yatay çizgi
    display.drawFastVLine(83,7,40,BLACK); // Sağdaki dikey çizgi   
    
    if(mainmenuid==1) 
    {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 9);
    display.print("Ayarlar");
    if(digitalRead(buton3)==HIGH) 
    {
    okbuton=1; ayarlar(); } }
    else  
    { 
    display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 9);
    display.print("Ayarlar"); }

    if(mainmenuid==2) 
    {
    display.setTextColor(WHITE, BLACK);
        display.setCursor(5, 19);
    display.print("Manuel");
    if(digitalRead(buton3)==HIGH)
    { 
    okbuton=1; manuel(); } }
    else {
    display.setTextColor(BLACK, WHITE);
    display.setCursor(5, 19);
    display.print("Manuel"); }
    
    if(mainmenuid==3) 
    {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 29);
    display.print("Tarifler"); 
    if(digitalRead(buton3)==HIGH)
    { 
    okbuton=1; tarifler(); } }
    else {
    display.setTextColor(BLACK, WHITE);
    display.setCursor(5, 29);
    display.print("Tarifler"); }
    
    if(mainmenuid==4) 
    {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 39);
    display.print("Bira Yap");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; birayap();} }
    else {   display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 39);
    display.print("Bira Yap"); }
    
  }}
int analogoku()
{
if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(100);
    mainmenuid++;
    delay(100); 
      if(mainmenuid==5)
      {mainmenuid=1;}}
     if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(100);
    mainmenuid--;
    delay(100);
      if(mainmenuid==0){  mainmenuid=4;}}
 //return menuitem;
 }

void kont(){
  display.clearDisplay();
  while(1){
  display.display();
  display.setTextSize(1);
  display.clearDisplay();
  display.setTextColor(BLACK, WHITE);
  display.setCursor(15, 0);
  display.print("KONTRAST");
  display.drawFastHLine(0,10,83,BLACK);
  display.setTextSize(3);
  display.setCursor(25, 13);
  display.print(dgr);
  display.setContrast(dgr);

  if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(100);
    dgr++;
    delay(100);  
  }
  if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(100);
    dgr--;
    delay(100);
  }

    if(digitalRead(buton3)==HIGH)
    { 
      tone(buzzer, 4000, 100);
    delay(100);
      okbuton++;
      delay(100);
  }
  if(okbuton>3){
    tone(buzzer, 4000, 100);
    delay(100);
    okbuton=1;
    display.clearDisplay();
    delay(100);
  ana_ekran();
    }
  EEPROM.write(13, dgr); // burada set değerini eproma kaydediyoruz
 }}

void saat() {
 ana_ekran();

}
void dil() {
 ana_ekran();

}

void tarif1() {
 ana_ekran();

}
void tarif2() {
 ana_ekran();

}
void tarif3() {
 ana_ekran();

}
void tarif4() {
 ana_ekran();

}

void basladik() {
 display.clearDisplay();
  while(1){
  display.display();
  birayapoku();
//delay(10);
    display.setTextSize(1);
    display.clearDisplay();
     temperature = getTemp();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(8, 0);
    display.print("SET    ACT");
    display.drawFastHLine(0,8,83,BLACK);
    display.setCursor(5, 10);
    display.setTextSize(1);
    display.print(SETm);
    display.setCursor(55, 10);
    display.print(temperature);
    display.setCursor(5, 20);
    display.print("BASLADI");
 if(digitalRead(buton3)==HIGH)     {
    counter++;
    delay(100);
    }
    if(counter % 2 == 0)
    {
    if(temperature<SETm)
    {
    digitalWrite(led1,HIGH);
    delay(1000);
    }
    if(temperature>=SETm)
    {
    digitalWrite(led1, LOW);
    display.clearDisplay();
    display.display();
    display.setTextColor(  BLACK,WHITE);
    display.setCursor(5, 10);
    display.print("Su Hazir");
    display.setCursor(5, 20);
    display.print("Sicaklik");
    display.setCursor(55, 20);
    display.print(temperature);
    display.drawCircle(69,20,1, BLACK);
    display.setCursor(73, 20);
    display.print("C");
                   if(birayapmenuid==1) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 40);
    display.print("Devam");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1;  basla1(); delay(100);} }
  else  { display.setTextColor(BLACK,WHITE);
        display.setCursor(5, 40);
    display.print("Devam"); }

     if(birayapmenuid==2) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(50, 40);
    display.print("Iptal");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; ana_ekran(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(50, 40);
    display.print("Iptal"); }
    }
    else
    {
    digitalWrite(led1,HIGH);
    }
    }

}}
void basla1() {
 display.clearDisplay();
  while(1){
  display.display();
  bira1menuidoku();
//delay(10);
    display.setTextSize(1);
    display.clearDisplay();
     temperature = getTemp();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(8, 0);
    display.print("SET    ACT");
    display.drawFastHLine(0,8,83,BLACK);
    display.setCursor(5, 10);
    display.setTextSize(1);
    display.print(SETm);
    display.setCursor(55, 10);
    display.print(temperature);
    display.setCursor(5, 20);
    display.print("Malt Ok?");

if(bira1menuid==1) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 40);
    display.print("Basla");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; adim1kont(); delay(100);} }
  else  { display.setTextColor(BLACK,WHITE);
        display.setCursor(5, 40);
    display.print("Devam"); }

     if(bira1menuid==2) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(50, 40);
    display.print("Iptal");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; ana_ekran(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(50, 40);
    display.print("Iptal"); }
 

}}
void adim1kont() {
 display.clearDisplay();
  while(1){
  display.display();
  birayapoku();
//delay(10);
    display.setTextSize(1);
    display.clearDisplay();
     temperature = getTemp();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(25, 0);
    display.print("SET  ACT");
    display.drawFastHLine(0,8,83,BLACK);
    display.setCursor(0, 10);
    display.setTextSize(1);
    display.print("ISI");
    display.setCursor(27, 10);
    display.setTextSize(1);
    display.print(SET1);
    display.setCursor(58, 10);
    display.print(temperature);
    
    if(ZMNha1>=1){    
    display.setCursor(0, 30);
    display.print(HA1.ShowHours());
    display.println("h");
    display.setCursor(30, 30);
    display.print(HA1.ShowMinutes());
    display.println("m");
    display.setCursor(45, 30);
    display.print(HA1.ShowSeconds());
    display.println("s");
    }
 else
 {
  display.setCursor(0, 30);
  display.print("Hop 1 Ayarlanmadi");
 }
    if(temperature<SET1)
    {
    digitalWrite(led1,HIGH);
    delay(1000);
    }
    else
    {
    digitalWrite(led1, LOW);
    }
    
   T.Timer();
   HA1.Timer();
   if(temperature<SET1)
    {T.PauseTimer();
    HA1.PauseTimer();
 display.setCursor(0, 20);
    display.setTextSize(1);
    display.print("ZMN");
    display.setCursor(30, 20);
    display.setTextSize(1);
    display.print(ZMN1);
    display.setCursor(45, 20);
display.print(T.ShowHours());
display.setCursor(50, 20);
    display.print(":");
display.setCursor(55, 20);
    display.print(T.ShowMinutes());
display.setCursor(60, 20);
    display.print(":");    
display.setCursor(65, 20);
    display.print(T.ShowSeconds());
    }
else{
    T.ResumeTimer();
    HA1.ResumeTimer();
 display.setCursor(0, 20);
    display.setTextSize(1);
    display.print("ZMN");
    display.setCursor(30, 20);
    display.setTextSize(1);
    display.print(ZMN1);
    display.setCursor(45, 20);
display.print(T.ShowHours());
display.setCursor(50, 20);
    display.print(":");
display.setCursor(55, 20);
    display.print(T.ShowMinutes());
display.setCursor(60, 20);
    display.print(":");    
display.setCursor(65, 20);
    display.print(T.ShowSeconds());
    
    }

if(HA1.TimeCheck(0,0,0)){
      
}
  
if(T.TimeCheck(0,0,0))
    adim2kont();
    

}}
////////////////////////////////////////////////////////////////////////////////////////
void adim2kont() {
 display.clearDisplay();
 
       
  while(1){
  display.display();
  birayapoku();

//delay(10);
    display.setTextSize(1);
    display.clearDisplay();
     temperature = getTemp();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(25, 0);
    display.print("SET  ACT");
    display.drawFastHLine(0,8,83,BLACK);
    display.setCursor(0, 10);
    display.setTextSize(1);
    display.print("ISI");
    display.setCursor(27, 10);
    display.setTextSize(1);
    display.print(SET2);
    display.setCursor(58, 10);
    display.print(temperature);
display.setCursor(10, 30);
    display.print("2. Adim");
 
    if(temperature<SET2)
    {
    digitalWrite(led1,HIGH);
    delay(1000);
    }
    else
    {
    digitalWrite(led1, LOW);
    }
    
   C.Timer();
   if(temperature<SET2)
    {C.PauseTimer();
 display.setCursor(0, 20);
    display.setTextSize(1);
    display.print("ZMN");
    display.setCursor(30, 20);
    display.setTextSize(1);
    display.print(ZMN2);
    display.setCursor(45, 20);
display.print(C.ShowHours());
display.setCursor(50, 20);
    display.print(":");
display.setCursor(55, 20);
    display.print(C.ShowMinutes());
display.setCursor(60, 20);
    display.print(":");    
display.setCursor(65, 20);
    display.print(C.ShowSeconds());
    }
else{
    C.ResumeTimer();
 display.setCursor(0, 20);
    display.setTextSize(1);
    display.print("ZMN");
    display.setCursor(30, 20);
    display.setTextSize(1);
    display.print(ZMN2);
    display.setCursor(45, 20);
display.print(C.ShowHours());
display.setCursor(50, 20);
    display.print(":");
display.setCursor(55, 20);
    display.print(C.ShowMinutes());
display.setCursor(60, 20);
    display.print(":");    
display.setCursor(65, 20);
    display.print(C.ShowSeconds());
    }

  
if(C.TimeCheck(0,0,0))
    adim3kont();

}}
/////////////////////////////////////////////////////////////////////////////////////////////////
void adim3kont() {
 display.clearDisplay();
 
       
  while(1){
  display.display();
  birayapoku();

//delay(10);
   display.setTextSize(1);
    display.clearDisplay();
     temperature = getTemp();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(25, 0);
    display.print("SET  ACT");
    display.drawFastHLine(0,8,83,BLACK);
    display.setCursor(0, 10);
    display.setTextSize(1);
    display.print("ISI");
    display.setCursor(27, 10);
    display.setTextSize(1);
    display.print(SET3);
    display.setCursor(58, 10);
    display.print(temperature);
display.setCursor(10, 30);
    display.print("3. Adim");
 
    if(temperature<SET3)
    {
    digitalWrite(led1,HIGH);
    delay(1000);
    }
    else
    {
    digitalWrite(led1, LOW);
    }
    
   D.Timer();
   if(temperature<SET3)
    {D.PauseTimer();
 display.setCursor(0, 20);
    display.setTextSize(1);
    display.print("ZMN");
    display.setCursor(30, 20);
    display.setTextSize(1);
    display.print(ZMN3);
    display.setCursor(45, 20);
display.print(D.ShowHours());
display.setCursor(50, 20);
    display.print(":");
display.setCursor(55, 20);
    display.print(D.ShowMinutes());
display.setCursor(60, 20);
    display.print(":");    
display.setCursor(65, 20);
    display.print(D.ShowSeconds());
    }
else{
    D.ResumeTimer();
 display.setCursor(0, 20);
    display.setTextSize(1);
    display.print("ZMN");
    display.setCursor(30, 20);
    display.setTextSize(1);
    display.print(ZMN3);
    display.setCursor(45, 20);
display.print(D.ShowHours());
display.setCursor(50, 20);
    display.print(":");
display.setCursor(55, 20);
    display.print(D.ShowMinutes());
display.setCursor(60, 20);
    display.print(":");    
display.setCursor(65, 20);
    display.print(D.ShowSeconds());
    }

  
if(D.TimeCheck(0,0,0))
    boiling();

}}
/////////////////////////////////////////////////////////////////////////////////////////////////
void boiling() {
 display.clearDisplay();
 
       
  while(1){
  display.display();
  birayapoku();

//delay(10);
   display.setTextSize(1);
    display.clearDisplay();
     temperature = getTemp();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(25, 0);
    display.print("SET  ACT");
    display.drawFastHLine(0,8,83,BLACK);
    display.setCursor(0, 10);
    display.setTextSize(1);
    display.print("ISI");
    display.setCursor(27, 10);
    display.setTextSize(1);
    display.print(SETb);
    display.setCursor(58, 10);
    display.print(temperature);
display.setCursor(10, 30);
    display.print("Boiling");
 
    if(temperature<SETb)
    {
    digitalWrite(led1,HIGH);
    delay(1000);
    }
    else
    {
    digitalWrite(led1, LOW);
    }
    
   E.Timer();
   if(temperature<SETb)
    {E.PauseTimer();
 display.setCursor(0, 20);
    display.setTextSize(1);
    display.print("ZMN");
    display.setCursor(30, 20);
    display.setTextSize(1);
    display.print(ZMNb);
    display.setCursor(45, 20);
display.print(E.ShowHours());
display.setCursor(50, 20);
    display.print(":");
display.setCursor(55, 20);
    display.print(E.ShowMinutes());
display.setCursor(60, 20);
    display.print(":");    
display.setCursor(65, 20);
    display.print(E.ShowSeconds());
    }
else{
    E.ResumeTimer();
 display.setCursor(0, 20);
    display.setTextSize(1);
    display.print("ZMN");
    display.setCursor(30, 20);
    display.setTextSize(1);
    display.print(ZMNb);
    display.setCursor(45, 20);
display.print(E.ShowHours());
display.setCursor(50, 20);
    display.print(":");
display.setCursor(55, 20);
    display.print(E.ShowMinutes());
display.setCursor(60, 20);
    display.print(":");    
display.setCursor(65, 20);
    display.print(E.ShowSeconds());
    }

  
if(E.TimeCheck(0,0,0))
    ana_ekran();

}}

void boilzmn(){
  display.clearDisplay();
  while(1){
  display.display();
//    reading=analogRead(buttonPin);
    delay(100);
display.setTextSize(1);
    display.clearDisplay();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("BOIL ZAMAN");
    display.drawFastHLine(0,10,83,BLACK);
    display.setTextSize(2);
    display.setCursor(25, 20);
    display.print(ZMNb);
//    display.display();
  if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    ZMNb++;
    delay(50);  
  }
  if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    ZMNb--;
    delay(50);
  }

   if(ZMNb==0){
      display.clearDisplay();
      display.display();
   display.setTextSize(3);
     display.setCursor(30, 10);
    display.print("0");
    }
    if(digitalRead(buton3)==HIGH){ okbuton++;
  }
  if(okbuton>3){okbuton=1; 
  delay(50);
  boil();
    }
  EEPROM.write(9, ZMNb); // burada set değerini eproma kaydediyoruz
  // SET değer değiştirme buraya kadar
 delay(100);
}}
/////////////////////////////////////////////////////////////////////////////////////////////////
void destek(){
    display.clearDisplay();
  while(1){ 
    display.display();
    analogoku();
     display.setTextColor(  BLACK,WHITE);
     display.setCursor(0, 0);
     display.print("Destek icin :");
     display.setCursor(0, 10);
    display.print("www.baybira.com");
    display.setCursor(0, 20);
    display.print("veya");
    display.setCursor(0, 30);
    display.print("0212-1234567");
    if(digitalRead(buton3)==HIGH)
    { okbuton++;}
    if(okbuton>3){
    okbuton=1;
    display.clearDisplay();
   delay(100);
   ana_ekran();
   }}}

void mashing(){
  display.clearDisplay();
  while(1){
  display.display();
//    reading=analogRead(buttonPin);
    delay(100);
display.setTextSize(1);
    display.clearDisplay();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(15, 0);
    display.print("MASHING");
    display.drawFastHLine(0,10,83,BLACK);
    display.setTextSize(2);
    display.setCursor(25, 13);
    display.print(SETm);
//    display.display();
  if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    SETm++;
    delay(50);  
  }
  if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    SETm--;
    delay(50);
  }

   if(SETm==0){
      display.clearDisplay();
      display.display();
   display.setTextSize(3);
     display.setCursor(30, 10);
    display.print("0");
    }
    if(digitalRead(buton3)==HIGH){ okbuton++;
  }
  if(okbuton>3){
    okbuton=1;
    tone(buzzer, 4250, 100);
    delay(50);
  manuel();
    }
  EEPROM.write(0, SETm); // burada set değerini eproma kaydediyoruz
  // SET değer değiştirme buraya kadar
 delay(100);

}}
void adim1isi(){
  display.clearDisplay();
  while(1){
  display.display();
//    reading=analogRead(buttonPin);
    delay(100);
display.setTextSize(1);
    display.clearDisplay();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(15, 0);
    display.print("1. ADIM ISI");
    display.drawFastHLine(0,10,83,BLACK);
    display.setTextSize(2);
    display.setCursor(35, 13);
    display.print(SET1);
//    display.display();
  if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(100);
    SET1++;
    delay(100);  
  }
  if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(100);
    SET1--;
    delay(100);
  }

   if(SET1==0){
      display.clearDisplay();
      display.display();
   display.setTextSize(3);
     display.setCursor(30, 10);
    display.print("0");
    }
    if(digitalRead(buton3)==HIGH){ okbuton++;
  }
  if(okbuton>3){okbuton=1;display.clearDisplay();delay(100);
  adim1();
    }
  EEPROM.write(1, SET1); // burada set değerini eproma kaydediyoruz
  // SET değer değiştirme buraya kadar
 delay(100);
}}
void adim1zmn(){
  display.clearDisplay();
  while(1){
  display.display();
//    reading=analogRead(buttonPin);
    delay(100);
display.setTextSize(1);
    display.clearDisplay();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(15, 0);
    display.print("1. ADIM ZAMAN");
    display.drawFastHLine(0,10,83,BLACK);
    display.setTextSize(2);
    display.setCursor(25, 13);
    display.print(ZMN1);
//    display.display();
  if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    ZMN1++;
    delay(50);  
  }
  if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    ZMN1--;
    delay(50);
  }

   if(ZMN1==0){
      display.clearDisplay();
      display.display();
   display.setTextSize(3);
     display.setCursor(30, 10);
    display.print("0");
    }
    if(digitalRead(buton3)==HIGH){ okbuton++;
  }
  if(okbuton>3){okbuton=1;display.clearDisplay();delay(50);
  adim1();
    }
  EEPROM.write(6, ZMN1); // burada set değerini eproma kaydediyoruz
  // SET değer değiştirme buraya kadar
 delay(100);
}}

void adim1(){
  display.clearDisplay();
  while(1){
  display.display();
  adim1menuoku();
//delay(10);
    display.clearDisplay();
    temperature = getTemp();
    display.setTextSize(1);
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("1. ADIM");
    display.setCursor(55, 0);
    display.print(temperature);
    display.drawCircle(69,2,1, BLACK);
    display.setCursor(73, 0);
    display.print("C");
    display.drawFastHLine(0,7,84,BLACK); // 1.  yatay çizgi
    display.drawFastVLine(0,7,40,BLACK); // Soldaki dikey çizgi
    display.drawFastHLine(0,27,84,BLACK); // 3. yatay çizgi
    display.drawFastHLine(0,17,84,BLACK); // 2. yatay çizgi
    display.drawFastHLine(0,37,84,BLACK); // 4. yatay çizgi
    display.drawFastHLine(0,47,84,BLACK); // 5. yatay çizgi
    display.drawFastVLine(83,7,40,BLACK); // Sağdaki dikey çizgi   
    
    if(adim1menuid==1) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 9);
    display.print("Sicaklik");
    if(digitalRead(buton3)==HIGH) {
 okbuton=1; adim1isi(); } }
  else  { display.setTextColor(BLACK,WHITE);
        display.setCursor(5, 9);
    display.print("Sicaklik"); }

     if(adim1menuid==2) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 19);
    display.print("Zaman");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; adim1zmn(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 19);
    display.print("Zaman"); }

    if(adim1menuid==3) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 29);
    display.print("Geri");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; ana_ekran(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 29);
    display.print("Geri"); }
}}

int adim1menuoku()
{
//  reading=analogRead(buttonPin);
if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(100);
    adim1menuid++;
    delay(100); 
      if(adim1menuid==4)
      {adim1menuid=1;}}
     if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(100);
    adim1menuid--;
    delay(100);
      if(adim1menuid==0){  adim1menuid=3;}}
 //return menuitem;
 }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void adim2isi(){
  display.clearDisplay();
  while(1){
  display.display();
//    reading=analogRead(buttonPin);
    delay(100);
display.setTextSize(1);
    display.clearDisplay();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(15, 0);
    display.print("2. ADIM ISI");
    display.drawFastHLine(0,10,83,BLACK);
    display.setTextSize(2);
    display.setCursor(35, 13);
    display.print(SET2);
//    display.display();
  if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(100);
    SET2++;
    delay(100);  
  }
  if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(100);
    SET2--;
    delay(100);
  }

   if(SET2==0){
      display.clearDisplay();
      display.display();
   display.setTextSize(3);
     display.setCursor(30, 10);
    display.print("0");
    }
    if(digitalRead(buton3)==HIGH){ okbuton++;
  }
  if(okbuton>3){okbuton=1;display.clearDisplay();delay(100);
  adim2();
    }
  EEPROM.write(2, SET2); // burada set değerini eproma kaydediyoruz
  // SET değer değiştirme buraya kadar
 delay(100);
}}
void adim2zmn(){
  display.clearDisplay();
  while(1){
  display.display();
//    reading=analogRead(buttonPin);
    delay(100);
display.setTextSize(1);
    display.clearDisplay();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("2. ADIM ZAMAN");
    display.drawFastHLine(0,10,83,BLACK);
    display.setTextSize(2);
    display.setCursor(25, 20);
    display.print(ZMN2);
//    display.display();
  if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    ZMN2++;
    delay(50);  
  }
  if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    ZMN2--;
    delay(50);
  }

   if(ZMN2==0){
      display.clearDisplay();
      display.display();
   display.setTextSize(3);
     display.setCursor(30, 10);
    display.print("0");
    }
    if(digitalRead(buton3)==HIGH){ okbuton++;
  }
  if(okbuton>2){okbuton=1; 
  delay(50);
  adim2();
    }
  EEPROM.write(7, ZMN2); // burada set değerini eproma kaydediyoruz
  // SET değer değiştirme buraya kadar
 delay(100);
}}

void adim2(){
  display.clearDisplay();
  while(1){
  display.display();
  adim2menuoku();
//delay(10);
    display.clearDisplay();
    temperature = getTemp();
    display.setTextSize(1);
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("2. ADIM");
    display.setCursor(55, 0);
    display.print(temperature);
    display.drawCircle(69,2,1, BLACK);
    display.setCursor(73, 0);
    display.print("C");
    display.drawFastHLine(0,7,84,BLACK); // 1.  yatay çizgi
    display.drawFastVLine(0,7,40,BLACK); // Soldaki dikey çizgi
    display.drawFastHLine(0,27,84,BLACK); // 3. yatay çizgi
    display.drawFastHLine(0,17,84,BLACK); // 2. yatay çizgi
    display.drawFastHLine(0,37,84,BLACK); // 4. yatay çizgi
    display.drawFastHLine(0,47,84,BLACK); // 5. yatay çizgi
    display.drawFastVLine(83,7,40,BLACK); // Sağdaki dikey çizgi   
    
    if(adim2menuid==1) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 9);
    display.print("Sicaklik");
    if(digitalRead(buton3)==HIGH) {
 okbuton=1; adim2isi(); } }
  else  { display.setTextColor(BLACK,WHITE);
        display.setCursor(5, 9);
    display.print("Sicaklik"); }

     if(adim2menuid==2) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 19);
    display.print("Zaman");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; adim2zmn(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 19);
    display.print("Zaman"); }

    if(adim2menuid==3) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 29);
    display.print("Geri");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; ana_ekran(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 29);
    display.print("Geri"); }
}}

int adim2menuoku()
{
//  reading=analogRead(buttonPin);
if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(100);
    adim2menuid++;
    delay(100); 
      if(adim2menuid==4)
      {adim2menuid=1;}}
     if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(100);
    adim2menuid--;
    delay(100);
      if(adim2menuid==0){  adim2menuid=3;}}
 //return menuitem;
 }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void hopadd1zmn(){
  display.clearDisplay();
  while(1){
  display.display();
//    reading=analogRead(buttonPin);
    delay(100);
display.setTextSize(1);
    display.clearDisplay();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("Hop Add 1");
    display.drawFastHLine(0,10,83,BLACK);
    display.setTextSize(2);
    display.setCursor(25, 20);
    display.print(ZMNha1);
//    display.display();
  if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    ZMNha1++;
    delay(50);  
  }
  if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    ZMNha1--;
    delay(50);
  }

   if(ZMNha1==0){
      display.clearDisplay();
      display.display();
   display.setTextSize(3);
     display.setCursor(30, 10);
    display.print("0");
    }
    if(digitalRead(buton3)==HIGH){ okbuton++;
  }
  if(okbuton>2){okbuton=1; 
  delay(50);
  hopadd();
    }
  EEPROM.write(10, ZMNha1); // burada set değerini eproma kaydediyoruz
  // SET değer değiştirme buraya kadar
 delay(100);
}}
void hopadd2zmn(){
  display.clearDisplay();
  while(1){
  display.display();
//    reading=analogRead(buttonPin);
    delay(100);
display.setTextSize(1);
    display.clearDisplay();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("Hop Add 2");
    display.drawFastHLine(0,10,83,BLACK);
    display.setTextSize(2);
    display.setCursor(25, 20);
    display.print(ZMNha2);
//    display.display();
  if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    ZMNha2++;
    delay(50);  
  }
  if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    ZMNha2--;
    delay(50);
  }

   if(ZMNha2==0){
      display.clearDisplay();
      display.display();
   display.setTextSize(3);
     display.setCursor(30, 10);
    display.print("0");
    }
    if(digitalRead(buton3)==HIGH){ okbuton++;
  }
  if(okbuton>2){okbuton=1; 
  delay(50);
  hopadd();
    }
  EEPROM.write(11, ZMNha2); // burada set değerini eproma kaydediyoruz
  // SET değer değiştirme buraya kadar
 delay(100);
}}
void hopadd3zmn(){
  display.clearDisplay();
  while(1){
  display.display();
//    reading=analogRead(buttonPin);
    delay(100);
display.setTextSize(1);
    display.clearDisplay();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("Hop Add 3");
    display.drawFastHLine(0,10,83,BLACK);
    display.setTextSize(2);
    display.setCursor(25, 20);
    display.print(ZMNha3);
//    display.display();
  if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    ZMNha3++;
    delay(50);  
  }
  if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    ZMNha3--;
    delay(50);
  }

   if(ZMNha3==0){
      display.clearDisplay();
      display.display();
   display.setTextSize(3);
     display.setCursor(30, 10);
    display.print("0");
    }
    if(digitalRead(buton3)==HIGH){ okbuton++;
  }
  if(okbuton>2){okbuton=1; 
  delay(50);
  hopadd();
    }
  EEPROM.write(12, ZMNha3); // burada set değerini eproma kaydediyoruz
  // SET değer değiştirme buraya kadar
 delay(100);
}}
void hopadd(){
  display.clearDisplay();
  while(1){
  display.display();
  hopmenuidoku();
//delay(10);
    display.clearDisplay();
    temperature = getTemp();
    display.setTextSize(1);
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("Hop Adding");
    display.setCursor(55, 0);
    display.print(temperature);
    display.drawCircle(69,2,1, BLACK);
    display.setCursor(73, 0);
    display.print("C");
    display.drawFastHLine(0,7,84,BLACK); // 1.  yatay çizgi
    display.drawFastVLine(0,7,40,BLACK); // Soldaki dikey çizgi
    display.drawFastHLine(0,27,84,BLACK); // 3. yatay çizgi
    display.drawFastHLine(0,17,84,BLACK); // 2. yatay çizgi
    display.drawFastHLine(0,37,84,BLACK); // 4. yatay çizgi
    display.drawFastHLine(0,47,84,BLACK); // 5. yatay çizgi
    display.drawFastVLine(83,7,40,BLACK); // Sağdaki dikey çizgi   
    
    if(hopmenuid==1) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 9);
    display.print("Hop Add 1");
    if(digitalRead(buton3)==HIGH) {
 okbuton=1; hopadd1zmn(); } }
  else  { display.setTextColor(BLACK,WHITE);
        display.setCursor(5, 9);
    display.print("Hop Add 1"); }

     if(hopmenuid==2) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 19);
    display.print("Hop Add 2");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; hopadd2zmn(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 19);
    display.print("Hop Add 2"); }

    if(hopmenuid==3) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 19);
    display.print("Hop Add 3");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; hopadd3zmn(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 19);
    display.print("Hop Add 3"); }
    
    if(hopmenuid==4) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 29);
    display.print("Geri");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; ana_ekran(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 29);
    display.print("Geri"); }
}}

int hopmenuidoku()
{
//  reading=analogRead(buttonPin);
if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    hopmenuid++;
    delay(50); 
      if(hopmenuid==5)
      {hopmenuid=1;}}
     if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    adim2menuid--;
    delay(50);
      if(hopmenuid==0){  hopmenuid=4;}}
 //return menuitem;
 }

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 void adim3isi(){
  display.clearDisplay();
  while(1){
  display.display();
//    reading=analogRead(buttonPin);
    delay(100);
display.setTextSize(1);
    display.clearDisplay();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(15, 0);
    display.print("3. ADIM ISI");
    display.drawFastHLine(0,10,83,BLACK);
    display.setTextSize(2);
    display.setCursor(35, 13);
    display.print(SET3);
//    display.display();
  if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(50);
    SET3++;
    delay(50);  
  }
  if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(50);
    SET3--;
    delay(50);
  }

   if(SET3==0){
      display.clearDisplay();
      display.display();
   display.setTextSize(3);
     display.setCursor(30, 10);
    display.print("0");
    }
    if(digitalRead(buton3)==HIGH){ okbuton++;
  }
  if(okbuton>3){okbuton=1;display.clearDisplay();delay(100);
  adim3();
    }
  EEPROM.write(3, SET3); // burada set değerini eproma kaydediyoruz
  // SET değer değiştirme buraya kadar
 delay(50);
}}
void adim3zmn(){
  display.clearDisplay();
  while(1){
  display.display();
//    reading=analogRead(buttonPin);
    delay(100);
display.setTextSize(1);
    display.clearDisplay();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("3. ADIM ZAMAN");
    display.drawFastHLine(0,10,83,BLACK);
    display.setTextSize(2);
    display.setCursor(25, 20);
    display.print(ZMN3);
//    display.display();
  if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    ZMN3++;
    delay(50);  
  }
  if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    ZMN3--;
    delay(50);
  }

   if(ZMN3==0){
      display.clearDisplay();
      display.display();
   display.setTextSize(3);
     display.setCursor(30, 10);
    display.print("0");
    }
    if(digitalRead(buton3)==HIGH){ okbuton++;
  }
  if(okbuton>2){okbuton=1; 
  delay(50);
  adim3();
    }
  EEPROM.write(8, ZMN3); // burada set değerini eproma kaydediyoruz
  // SET değer değiştirme buraya kadar
 delay(100);
}}

void adim3(){
  display.clearDisplay();
  while(1){
  display.display();
  adim3menuoku();
//delay(10);
    display.clearDisplay();
    temperature = getTemp();
    display.setTextSize(1);
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("3. ADIM");
    display.setCursor(55, 0);
    display.print(temperature);
    display.drawCircle(69,2,1, BLACK);
    display.setCursor(73, 0);
    display.print("C");
    display.drawFastHLine(0,7,84,BLACK); // 1.  yatay çizgi
    display.drawFastVLine(0,7,40,BLACK); // Soldaki dikey çizgi
    display.drawFastHLine(0,27,84,BLACK); // 3. yatay çizgi
    display.drawFastHLine(0,17,84,BLACK); // 2. yatay çizgi
    display.drawFastHLine(0,37,84,BLACK); // 4. yatay çizgi
    display.drawFastHLine(0,47,84,BLACK); // 5. yatay çizgi
    display.drawFastVLine(83,7,40,BLACK); // Sağdaki dikey çizgi   
    
    if(adim3menuid==1) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 9);
    display.print("Sicaklik");
    if(digitalRead(buton3)==HIGH) {
 okbuton=1; adim3isi(); } }
  else  { display.setTextColor(BLACK,WHITE);
        display.setCursor(5, 9);
    display.print("Sicaklik"); }

     if(adim3menuid==2) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 19);
    display.print("Zaman");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; adim3zmn(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 19);
    display.print("Zaman"); }

    if(adim3menuid==3) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 29);
    display.print("Geri");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; ana_ekran(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 29);
    display.print("Geri"); }
}}

int adim3menuoku()
{
//  reading=analogRead(buttonPin);
if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(100);
    adim3menuid++;
    delay(100); 
      if(adim3menuid==4)
      {adim3menuid=1;}}
     if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(100);
    adim3menuid--;
    delay(100);
      if(adim3menuid==0){  adim3menuid=3;}}
 //return menuitem;
 }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void boil(){
  display.clearDisplay();
  while(1){
  display.display();
  boilmenuoku();
//delay(10);
    display.clearDisplay();
    temperature = getTemp();
    display.setTextSize(1);
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("BOILING");
    display.setCursor(55, 0);
    display.print(temperature);
    display.drawCircle(69,2,1, BLACK);
    display.setCursor(73, 0);
    display.print("C");
    display.drawFastHLine(0,7,84,BLACK); // 1.  yatay çizgi
    display.drawFastVLine(0,7,40,BLACK); // Soldaki dikey çizgi
    display.drawFastHLine(0,27,84,BLACK); // 3. yatay çizgi
    display.drawFastHLine(0,17,84,BLACK); // 2. yatay çizgi
    display.drawFastHLine(0,37,84,BLACK); // 4. yatay çizgi
    display.drawFastHLine(0,47,84,BLACK); // 5. yatay çizgi
    display.drawFastVLine(83,7,40,BLACK); // Sağdaki dikey çizgi   
    
    if(boilmenuid==1) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 19);
    display.print("Zaman");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; boilzmn(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 19);
    display.print("Zaman"); }

    if(boilmenuid==2) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 29);
    display.print("Geri");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; ana_ekran(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 29);
    display.print("Geri"); }
}}

int boilmenuoku()
{
//  reading=analogRead(buttonPin);
if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(100);
    boilmenuid++;
    delay(100); 
      if(boilmenuid==3)
      {boilmenuid=1;}}
     if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(100);
    boilmenuid--;
    delay(100);
      if(boilmenuid==0){  boilmenuid=2;}}
 //return menuitem;
 }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
   
 // Burası AYARLAR SAYFASI

void ayarlar(){
  display.clearDisplay();
  while(1){
  display.display();
  ayarlaroku();
//delay(10);
    display.clearDisplay();
    temperature = getTemp();
    display.setTextSize(1);
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("AYARLAR");
    display.setCursor(55, 0);
    display.print(temperature);
    display.drawCircle(69,2,1, BLACK);
    display.setCursor(73, 0);
    display.print("C");
    display.drawFastHLine(0,7,84,BLACK); // 1.  yatay çizgi
    display.drawFastVLine(0,7,40,BLACK); // Soldaki dikey çizgi
    display.drawFastHLine(0,27,84,BLACK); // 3. yatay çizgi
    display.drawFastHLine(0,17,84,BLACK); // 2. yatay çizgi
    display.drawFastHLine(0,37,84,BLACK); // 4. yatay çizgi
    display.drawFastHLine(0,47,84,BLACK); // 5. yatay çizgi
    display.drawFastVLine(83,7,40,BLACK); // Sağdaki dikey çizgi   
    
    if(ayarmenuid==1) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 9);
    display.print("Kontrast");
    if(digitalRead(buton3)==HIGH) {
 okbuton=1; kont(); } }
  else  { display.setTextColor(BLACK,WHITE);
        display.setCursor(5, 9);
    display.print("Kontrast"); }

     if(ayarmenuid==2) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 19);
    display.print("Saat Ayari");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; saat(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 19);
    display.print("Saat Ayari"); }

    if(ayarmenuid==3) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 29);
    display.print("Dil");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; dil(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 29);
    display.print("Dil"); }

    if(ayarmenuid==4) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 39);
    display.print("Destek");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; destek(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 39);
    display.print("Destek"); }

 // 1 saniye bekliyoruz. Monitörde saniyede 1 sıcaklık değeri yazmaya devam edecek.
}}

int ayarlaroku()
{
//  reading=analogRead(buttonPin);
if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(100);
    ayarmenuid++;
    delay(100); 
      if(ayarmenuid==5)
      {ayarmenuid=1;}}
     if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(100);
    ayarmenuid--;
    delay(100);
      if(ayarmenuid==0){  ayarmenuid=4;}}
 //return menuitem;
 }

 void manuel(){
  display.clearDisplay();
  while(1){
  display.display();
  manueloku();
//delay(10);
    display.clearDisplay();
    temperature = getTemp();
    display.setTextSize(1);
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("MANUEL");
    display.setCursor(55, 0);
    display.print(temperature);
    display.drawCircle(69,2,1, BLACK);
    display.setCursor(73, 0);
    display.print("C");
    display.drawFastHLine(0,7,84,BLACK); // 1.  yatay çizgi
    display.drawFastVLine(0,7,40,BLACK); // Soldaki dikey çizgi
    display.drawFastHLine(0,27,84,BLACK); // 3. yatay çizgi
    display.drawFastHLine(0,17,84,BLACK); // 2. yatay çizgi
    display.drawFastHLine(0,37,84,BLACK); // 4. yatay çizgi
    display.drawFastHLine(0,47,84,BLACK); // 5. yatay çizgi
    display.drawFastVLine(83,7,40,BLACK); // Sağdaki dikey çizgi 
    
    if(manuelmenuid==1) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 9);
    display.print("Masing");
    if(digitalRead(buton3)==HIGH) {
 okbuton=1; mashing(); } }
  else  { display.setTextColor(BLACK,WHITE);
        display.setCursor(5, 9);
    display.print("Masing"); }

     if(manuelmenuid==2) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 19);
    display.print("1. Adim");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; adim1(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 19);
    display.print("1. Adim"); }

    if(manuelmenuid==3) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 29);
    display.print("2. Adim");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; adim2(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 29);
    display.print("2. Adim"); }
    
    if(manuelmenuid==4) {      
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 39);
    display.print("3. Adim");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; adim3(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 39);
    display.print("3. Adim"); }
    
    if(manuelmenuid==5) 
    {
      manuel1();     
    }
   
}}

int manueloku()
{
if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(100);
    manuelmenuid++;
    delay(100); 
      if(manuelmenuid==6)
      {manuelmenuid=1;}}
     if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(100);
    manuelmenuid--;
    delay(100);
      if(manuelmenuid==0){  manuelmenuid=5;}}
 //return menuitem;
 }

 void manuel1(){
  display.clearDisplay();
  while(1){
  display.display();
  manueloku1();
//delay(10);
    display.clearDisplay();
    temperature = getTemp();
    display.setTextSize(1);
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("MANUEL1");
    display.setCursor(55, 0);
    display.print(temperature);
    display.drawCircle(69,2,1, BLACK);
    display.setCursor(73, 0);
    display.print("C");
    display.drawFastHLine(0,7,84,BLACK); // 1.  yatay çizgi
    display.drawFastVLine(0,7,40,BLACK); // Soldaki dikey çizgi
    display.drawFastHLine(0,27,84,BLACK); // 3. yatay çizgi
    display.drawFastHLine(0,17,84,BLACK); // 2. yatay çizgi
    display.drawFastHLine(0,37,84,BLACK); // 4. yatay çizgi
    display.drawFastHLine(0,47,84,BLACK); // 5. yatay çizgi
    display.drawFastVLine(83,7,40,BLACK); // Sağdaki dikey çizgi
    
    if(manuelmenu1id==1) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 9);
    display.print("> Boiling");
    if(digitalRead(buton3)==HIGH) {
 okbuton=1; boil(); } }
  else  { display.setTextColor(BLACK,WHITE);
        display.setCursor(5, 9);
    display.print("Boiling"); }

     if(manuelmenu1id==2) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 19);
    display.print("Hop Additions");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; hopadd(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 19);
    display.print("Hop Additions"); }

    if(manuelmenu1id==3) 
    {
      manuel();     
    }
}}

int manueloku1()
{
if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(100);
    manuelmenu1id++;
    delay(100); 
      if(manuelmenu1id==4)
      {manuelmenu1id=1;}}
     if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(100);
    manuelmenu1id--;
    delay(100);
      if(manuelmenu1id==0){  manuelmenu1id=3;}}
 //return menuitem;
 }

  void tarifler(){
  display.clearDisplay();
  while(1){
  display.display();
  tarifleroku();
//delay(10);
    display.clearDisplay();
    temperature = getTemp();
    display.setTextSize(1);
    display.setTextColor(BLACK, WHITE);
    display.setCursor(0, 0);
    display.print("TARIFLER");
    display.setCursor(55, 0);
    display.print(temperature);
    display.drawCircle(69,2,1, BLACK);
    display.setCursor(73, 0);
    display.print("C");
    display.drawFastHLine(0,7,84,BLACK); // 1.  yatay çizgi
    display.drawFastVLine(0,7,40,BLACK); // Soldaki dikey çizgi
    display.drawFastHLine(0,27,84,BLACK); // 3. yatay çizgi
    display.drawFastHLine(0,17,84,BLACK); // 2. yatay çizgi
    display.drawFastHLine(0,37,84,BLACK); // 4. yatay çizgi
    display.drawFastHLine(0,47,84,BLACK); // 5. yatay çizgi
    display.drawFastVLine(83,7,40,BLACK); // Sağdaki dikey çizgi
    
    if(tarifmenuid==1) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 9);
    display.print("> 1. Tarif");
    if(digitalRead(buton3)==HIGH) {
 okbuton=1; tarif1(); } }
  else  { display.setTextColor(BLACK,WHITE);
        display.setCursor(5, 9);
    display.print("1. Tarif"); }

     if(tarifmenuid==2) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 19);
    display.print("2. Tarif");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; hopadd(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 19);
    display.print("2. Tarif"); }

    if(tarifmenuid==3) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 19);
    display.print("3. Tarif");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; hopadd(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(5, 19);
    display.print("3. Tarif"); }
}}

int tarifleroku()
{
if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(100);
    tarifmenuid++;
    delay(100); 
      if(tarifmenuid==4)
      {tarifmenuid=1;}}
     if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(100);
    tarifmenuid--;
    delay(100);
      if(tarifmenuid==0){  tarifmenuid=3;}}
 //return menuitem;
 }
int birayapoku()
{
if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(100);
    birayapmenuid++;
    delay(100); 
      if(birayapmenuid==3)
      {birayapmenuid=1;}}
     if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(100);
    birayapmenuid--;
    delay(100);
      if(birayapmenuid==0){  birayapmenuid=2;}}
 
 }
int bira1menuidoku()
{
if(digitalRead(buton1)==HIGH)
  {
    digitalWrite(buzzer,HIGH);
    tone(buzzer, 4250, 100);
    delay(100);
    bira1menuid++;
    delay(100); 
      if(bira1menuid==3)
      {bira1menuid=1;}}
     if(digitalRead(buton2)==HIGH)
  {
    tone(buzzer, 4000, 100);
    delay(100);
    bira1menuid--;
    delay(100);
      if(bira1menuid==0){  bira1menuid=2;}}
 
 }
 void birayap(){
  display.clearDisplay();
  while(1){
  display.display();
  birayapoku();
//delay(10);
    display.setTextSize(1);
    display.clearDisplay();
     temperature = getTemp();
    display.setTextColor(BLACK, WHITE);
    display.setCursor(8, 0);
    display.print("SET    ACT");
    display.drawFastHLine(0,8,83,BLACK);
    display.setCursor(5, 10);
    display.setTextSize(1);
    display.print(SETm);
    display.setCursor(55, 10);
    display.print(temperature);
    display.setCursor(5, 20);
    display.print("Su Tamam mi?");
    
    if(birayapmenuid==1) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(5, 40);
    display.print("Basla");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; basladik(); } }
  else  { display.setTextColor(BLACK,WHITE);
        display.setCursor(5, 40);
    display.print("Basla"); }

     if(birayapmenuid==2) {
    display.setTextColor(WHITE, BLACK);
    display.setCursor(50, 40);
    display.print("Iptal");
    if(digitalRead(buton3)==HIGH) {
    okbuton=1; ana_ekran(); } }
    else  { display.setTextColor(BLACK,WHITE);
    display.setCursor(50, 40);
    display.print("Iptal"); }

}}


