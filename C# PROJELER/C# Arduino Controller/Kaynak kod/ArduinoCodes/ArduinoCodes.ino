#include <EEPROM.h>
//------------------------------EEPROM SAVE-----
 int adress,value;
 int d2read;
 int d3read;
  int d4read;
 int d5read;
  int d6read;
 int d7read;
  int d8read;
 int d9read;
  int d10read;
 int d11read;
  int d12read;
 int d13read;
 //--------------------------EEPROM SAVE
//-------------------------------PİN'S----------
int d2 = 2;
int d3 = 3;
int d4 = 4;
int d5 = 5;
int d6 = 6;
int d7 = 7;
int d8 = 8;
int d9 = 9;
int d10 =10;
int d11 = 11;
 int d12 = 12;
int d13 = 13;
String txt = "";
bool a0set,a1set,a2set,a3set,a4set,a5set;
void setup(){
   Serial.begin(9600);
  defaultmodes();
eepromread();
 setupcodes();
}
  void loop(){
              eepromwrite();
         loopcodes();
         while(Serial.available()){
           txt = Serial.readString();
           serialreading();
           analogSerialReading();
          
         }
                                  }
  void serialreading(){
                      lastmodes();
  if(txt == "ALL0"){
        digitalWrite(d2,LOW);
     digitalWrite(d3,LOW);
     digitalWrite(d4,LOW);
     digitalWrite(d5,LOW);
     digitalWrite(d6,LOW);
     digitalWrite(d7,LOW);
     digitalWrite(d8,LOW);
     digitalWrite(d9,LOW);
     digitalWrite(d10,LOW);
     digitalWrite(d11,LOW);
     digitalWrite(d12,LOW);
     digitalWrite(d13,LOW);
        }
        
             if(txt=="D2ON"){
  digitalWrite(d2,HIGH);
  }
     if(txt=="D2OFF"){
    digitalWrite(d2,LOW);
    }
    if(txt=="D3ON"){
     
      digitalWrite(d3,HIGH);
      }
   if(txt == "D3OFF")
    {
      digitalWrite(d3,LOW);
      }
          if(txt=="D4ON"){
  digitalWrite(d4,HIGH);
  }
  if(txt=="D4OFF"){
    digitalWrite(d4,LOW);
    }
    if(txt=="D5ON"){
     
      digitalWrite(d5,HIGH);
      }
   if(txt == "D5OFF")
    {
      digitalWrite(d5,LOW);
      }
          if(txt=="D6ON"){
  digitalWrite(d6,HIGH);
  }
  if(txt=="D6OFF"){
    digitalWrite(d6,LOW);
    }
    if(txt=="D7ON"){
     
      digitalWrite(d7,HIGH);
      }
   if(txt == "D7OFF")
    {
      digitalWrite(d7,LOW);
      }
         if(txt=="D8ON"){
     
      digitalWrite(d8,HIGH);
      }
   if(txt == "D8OFF")
    {
      digitalWrite(d8,LOW);
      }
         if(txt=="D9ON"){
     
      digitalWrite(d9,HIGH);
      }
   if(txt == "D9OFF")
    {
      digitalWrite(d9,LOW);
      }
         if(txt=="D10ON"){
     
      digitalWrite(d10,HIGH);
      }
   if(txt == "D10OFF")
    {
      digitalWrite(d10,LOW);
      }
         if(txt=="D11ON"){
     
      digitalWrite(d11,HIGH);
      }
   if(txt == "D11OFF")
    {
      digitalWrite(d11,LOW);
      }
         if(txt=="D12ON"){
     
      digitalWrite(d12,HIGH);
      }
   if(txt == "D12OFF")
    {
      digitalWrite(d12,LOW);
      }
         if(txt=="D13ON"){
     
      digitalWrite(d13,HIGH);
      }
   if(txt == "D13OFF")
    {
      digitalWrite(d13,LOW);
      }
       }
        
  
 void defaultmodes(){
 pinMode(d2,OUTPUT);
  pinMode(d3,OUTPUT);
   pinMode(d4,OUTPUT);
    pinMode(d5,OUTPUT);
     pinMode(d6,OUTPUT);
      pinMode(d7,OUTPUT);
       pinMode(d8,OUTPUT);
        pinMode(d9,OUTPUT);
         pinMode(d10,OUTPUT);
          pinMode(d11,OUTPUT);
           pinMode(d12,OUTPUT);
            pinMode(d13,OUTPUT);
  }

  void lastmodes(){
         if(txt == "d2in"){
    pinMode(d2,INPUT);
      }
       if(txt == "d2out"){
    pinMode(d2,OUTPUT);
      }
      if(txt == "d3in"){
    pinMode(d3,INPUT);
      }
       if(txt == "d3out"){
    pinMode(d3,OUTPUT);
      }
      if(txt == "d4in"){
    pinMode(d4,INPUT);
      }
       if(txt == "d4out"){
    pinMode(d4,OUTPUT);
      }
      if(txt == "d5in"){
    pinMode(d5,INPUT);
      }
       if(txt == "d5out"){
    pinMode(d5,OUTPUT);
      }
      if(txt == "d6in"){
    pinMode(d6,INPUT);
      }
       if(txt == "d6out"){
    pinMode(d6,OUTPUT);
      }
      if(txt == "d7in"){
    pinMode(d7,INPUT);
      }
       if(txt == "d7out"){
    pinMode(d7,OUTPUT);
      }
      if(txt == "d8in"){
    pinMode(d8,INPUT);
      }
       if(txt == "d8out"){
    pinMode(d8,OUTPUT);
      }
      if(txt == "d9in"){
    pinMode(d9,INPUT);
      }
       if(txt == "d9out"){
    pinMode(d9,OUTPUT);
      }
      if(txt == "d10in"){
    pinMode(d10,INPUT);
      }
       if(txt == "d10out"){
    pinMode(d10,OUTPUT);
      }
      if(txt == "d11in"){
    pinMode(d11,INPUT);
      }
       if(txt == "d11out"){
    pinMode(d11,OUTPUT);
      }
      if(txt == "d12in"){
    pinMode(d12,INPUT);
      }
       if(txt == "d12out"){
    pinMode(d12,OUTPUT);
      }
      if(txt == "d13in"){
    pinMode(d13,INPUT);
      }
       if(txt == "d13out"){
    pinMode(d13,OUTPUT);
      }
  }
      void eepromread(){
d2read = 2;
d3read = 3;
d4read = 4;
d5read = 5;
d6read = 6;
d7read = 7;
d8read = 8;
d9read = 9;
d10read = 10;
d11read = 11;
d12read = 12;
d13read = 13;
  if(EEPROM.read(d2read) == 1){
    digitalWrite(d2,HIGH);
       }
    if(EEPROM.read(d3read) == 1){
  digitalWrite(d3,HIGH);
  }
  if(EEPROM.read(d4read) == 1){
    digitalWrite(d4,HIGH);
    }
    if(EEPROM.read(d5read) == 1){
  digitalWrite(d5,HIGH);
  }
  if(EEPROM.read(d6read) == 1){
    digitalWrite(d6,HIGH);
    }
    if(EEPROM.read(d7read) == 1){
  digitalWrite(d7,HIGH);
  }
  if(EEPROM.read(d8read) == 1){
    digitalWrite(d8,HIGH);
    }
    if(EEPROM.read(d9read) == 1){
  digitalWrite(d9,HIGH);
  }
  if(EEPROM.read(d10read) == 1){
    digitalWrite(d10,HIGH);
    }
    if(EEPROM.read(d11read) == 1){
  digitalWrite(d11,HIGH);
  }
  if(EEPROM.read(d12read) == 1){
    digitalWrite(d12,HIGH);
    }
    if(EEPROM.read(d13read) == 1){
  digitalWrite(d13,HIGH);
  }
  if(EEPROM.read(d2read) == 0){
    digitalWrite(d2,LOW);
    }
    if(EEPROM.read(d3read) == 0){
  digitalWrite(d3,LOW);
  }
  if(EEPROM.read(d4read) == 0){
    digitalWrite(d4,LOW);
    }
    if(EEPROM.read(d5read) == 0){
  digitalWrite(d5,LOW);
  }
  if(EEPROM.read(d6read) == 0){
    digitalWrite(d6,LOW);
    }
    if(EEPROM.read(d7read) == 0){
  digitalWrite(d7,LOW);
  }
  if(EEPROM.read(d8read) == 0){
    digitalWrite(d8,LOW);
    }
    if(EEPROM.read(d9read) == 0){
  digitalWrite(d9,LOW);
  }
  if(EEPROM.read(d10read) == 0){
    digitalWrite(d10,LOW);
    }
    if(EEPROM.read(d11read) == 0){
  digitalWrite(d11,LOW);
  }
  if(EEPROM.read(d12read) == 0){
    digitalWrite(d12,LOW);
    }
    if(EEPROM.read(d13read) == 0){
  digitalWrite(d13,LOW);
  }
        }
        void eepromwrite(){
                if(digitalRead(d2)==HIGH){
              adress = 2;
              value = 1;
              EEPROM.write(adress,value);
              delay(10);
            }
            if(digitalRead(d2)==LOW){
                adress = 2;
              value = 0;
              EEPROM.write(adress,value);
              delay(10);
              }
          if(digitalRead(d3)==HIGH){
              adress = 3;
              value = 1;
              EEPROM.write(adress,value);
              delay(10);
            }
            if(digitalRead(d3)==LOW){
                adress = 3;
              value = 0;
              EEPROM.write(adress,value);
              delay(10);
              }
                             if(digitalRead(d4)==HIGH){
              adress = 4;
              value = 1;
              EEPROM.write(adress,value);
              delay(10);
            }
            if(digitalRead(d4)==LOW){
                adress = 4;
              value = 0;
              EEPROM.write(adress,value);
              delay(10);
              }
                 if(digitalRead(d5)==HIGH){
              adress = 5;
              value = 1;
              EEPROM.write(adress,value);
              delay(10);
            }
            if(digitalRead(d5)==LOW){
                adress = 5;
              value = 0;
              EEPROM.write(adress,value);
              delay(10);
              }
          if(digitalRead(d6)==HIGH){
              adress = 6;
              value = 1;
              EEPROM.write(adress,value);
              delay(10);
            }
            if(digitalRead(d6)==LOW){
                adress = 6;
              value = 0;
              EEPROM.write(adress,value);
              delay(10);
              }
                             if(digitalRead(d7)==HIGH){
              adress = 7;
              value = 1;
              EEPROM.write(adress,value);
              delay(10);
            }
            if(digitalRead(d7)==LOW){
                adress = 7;
              value = 0;
              EEPROM.write(adress,value);
              delay(10);
              }
                                 if(digitalRead(d8)==HIGH){
              adress = 8;
              value = 1;
              EEPROM.write(adress,value);
              delay(10);
            }
            if(digitalRead(d8)==LOW){
                adress = 8;
              value = 0;
              EEPROM.write(adress,value);
              delay(10);
              }
                                 if(digitalRead(d9)==HIGH){
              adress = 9;
              value = 1;
              EEPROM.write(adress,value);
              delay(10);
            }
            if(digitalRead(d9)==LOW){
                adress = 9;
              value = 0;
              EEPROM.write(adress,value);
              delay(10);
              }
                if(digitalRead(d10)==HIGH){
              adress = 10;
              value = 1;
              EEPROM.write(adress,value);
              delay(10);
            }
            if(digitalRead(d10)==LOW){
                adress = 10;
              value = 0;
              EEPROM.write(adress,value);
              delay(10);
              }
                if(digitalRead(d11)==HIGH){
              adress = 11;
              value = 1;
              EEPROM.write(adress,value);
              delay(10);
            }
            if(digitalRead(d11)==LOW){
                adress = 11;
              value = 0;
              EEPROM.write(adress,value);
              delay(10);
              }
                if(digitalRead(d12)==HIGH){
              adress = 12;
              value = 1;
              EEPROM.write(adress,value);
              delay(10);
            }
            if(digitalRead(d12)==LOW){
                adress = 12;
              value = 0;
              EEPROM.write(adress,value);
              delay(10);
              } 
              if(digitalRead(d13)==HIGH){
              adress = 13;
              value = 1;
              EEPROM.write(adress,value);
              delay(10);
            }
            if(digitalRead(d13)==LOW){
                adress = 13;
              value = 0;
              EEPROM.write(adress,value);
              delay(10);
              }
      }
      void analogSerialReading(){
           if(txt=="a0state")
           Serial.println(analogRead(A0));
            else if(txt=="a1state")
      Serial.println(analogRead(A1)); 
      else if(txt=="a2state")
      Serial.println(analogRead(A2));
      else if(txt =="a3state")
      Serial.println(analogRead(A3));
      else if(txt =="a4state")
      Serial.println(analogRead(A4));
      else if(txt =="a5state")
      Serial.println(analogRead(A5)); 
      
      }

