#include <Keypad.h>

const byte satirSayisi= 4;
const byte sutunSayisi= 4;

char tuslar[satirSayisi][sutunSayisi]=
{
{'1', '2', '3', 'K'},
{'4', '5', '6', 'B'},
{'7', '8', '9', 'C'},
{'R', '0', 'E', 'D'}
};

byte satirPinleri[satirSayisi] = {9,8,7,6};
byte sutunPinleri[sutunSayisi]= {5,4,3,2};

Keypad tusTakimi= Keypad(makeKeymap(tuslar), satirPinleri, sutunPinleri, satirSayisi, sutunSayisi);

void setup(){
  Serial.begin(9600);
}

void loop(){
  char basilanTus = tusTakimi.getKey();
  if (basilanTus != NO_KEY){
    Serial.println(basilanTus);
    
      } 
      }
