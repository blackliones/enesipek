int latchPin = 12;
//Pin connected to SH_CP of 74HC595
int clockPin = 11;
////Pin connected to DS of 74HC595
int dataPin = 13;
int rightPin = 2;
int leftPin=3;
bool rightSignal,leftSignal;
// shift out lowbyte
int val;
bool zeroeff;
String mode;
void setup() {
  //set pins to output because they are addressed in the main loop
  pinMode(latchPin, OUTPUT);
  pinMode(clockPin, OUTPUT);
  pinMode(dataPin, OUTPUT);
  pinMode(leftPin,OUTPUT);
  pinMode(rightPin,OUTPUT);
Serial.begin(9600);
zeroeff=false;
leftSignal=false;
rightSignal=false;
digitalWrite(leftPin,HIGH);
digitalWrite(rightPin,HIGH);
val = 120;
}
//LSBFIRST(LOOP) or MSBFIRST(SINGLE) 
void loop() {
  if(Serial.available()){
    mode = Serial.readString();
    if(mode == "nosignal"){
    Serial.println("NO SIGNAL");
        rightSignal=false;
    leftSignal=false;
  }
   else  if(mode=="left"){
      Serial.println("LEFT");
       if(!leftSignal){
             rightSignal=false;
      leftSignal=true;
    }
   }
    else if(mode=="right")
    {
       Serial.println("RIGHT");
       if(!rightSignal){
          leftSignal=false;
              rightSignal =true;
           }
    }
    else if(mode=="double"){
       Serial.println("DOUBLE");
       if(!rightSignal)        
         rightSignal=true;
     if(!leftSignal)
     leftSignal=true;
    }
  }
    //ANİMASYON İÇİN SADECE FOR İÇERSİNDEKİ DELAY İLE VE J KOSULUYLA OYNA
if(rightSignal&&!leftSignal){
  Signal();
  digitalWrite(rightPin,LOW);//PNP TRANSİSTÖR KULLANDIM O YÜZDEN LOW İLE TETİKLENİYOR
  digitalWrite(leftPin,HIGH);
}
else if(leftSignal&&!rightSignal){
  Signal();
   digitalWrite(rightPin,HIGH);
  digitalWrite(leftPin,LOW);
}
 else if(leftSignal&&rightSignal){
  Signal();
   digitalWrite(rightPin,LOW);
  digitalWrite(leftPin,LOW);
}
else if(!leftSignal&&!rightSignal){
  digitalWrite(rightPin,HIGH);
  digitalWrite(leftPin,HIGH);
}
}
void Signal(){
if(val<140){
  val++;
    digitalWrite(latchPin, LOW);
    shiftOut(dataPin, clockPin, LSBFIRST,val);
    //return the latch pin high to signal chip that it
    //no longer needs to listen for information
    digitalWrite(latchPin, HIGH);
    //Serial.println(val);
    if(!zeroeff){
  delay(25);
    }
  else{
  delay(5);
  zeroeff=false;
    }
   }
  else if(val==140){
    val=120;
 zeroeff=true;
  }
}
