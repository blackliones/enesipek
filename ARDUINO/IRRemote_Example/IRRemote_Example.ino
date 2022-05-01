#include <IRremote.h>

int RECV_PIN = 4;

IRrecv irrecv(RECV_PIN);

decode_results results;

void setup()
{
  Serial.begin(9600);
  irrecv.enableIRIn(); // Start the receiver
}

void loop() {
 
  if (irrecv.decode(&results)) {
    Serial.println(results.value,HEX);                 
     /* switch(results.value)
      {
        case 0xFF6897:  Serial.println("1"); break; // Button 1
        case 0xFF9867:  Serial.println("2"); break; // Button 2
        case 0xFFB04F:  Serial.println("3"); break; // Button 3
        case 0xFF30CF:  Serial.println("4"); break; // Button 4
        case 0xFF18E7:  Serial.println("5"); break; // Button 5
        case 0xFF7A85:  Serial.println("6"); break; // Button 6
        case 0xFF10EF:  Serial.println("7"); break; // Button 7
        case 0xFF38C7:  Serial.println("8"); break; // Button 8
        case 0xFF5AA5:  Serial.println("9"); break; // Button 9
        case 0xFF4AB5:  Serial.println("0"); break; // Button 0          
        case 0xFF629D:  Serial.println("UP"); break; // UPArrow
        case 0xFF22DD:  Serial.println("LEFT"); break; // LArrow
        case 0xFF02FD:  Serial.println("OK"); break; // OK
        case 0xFFC23D:  Serial.println("RIGHT"); break; // RArrow
        case 0xFFA857:  Serial.println("DOWN"); break; // DARROW
        case 0xFF42BD:  Serial.println("STAR"); break; // Star
        case 0xFF52AD:  Serial.println("SQUARE"); break; // Square
      }  */
    irrecv.resume(); // Receive the next value
  }
}
