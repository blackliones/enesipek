int ledpin = 13;
String inputString = "";
boolean stringComplete = false;
void setup() {
  // put your setup code here, to run once:
pinMode(ledpin,OUTPUT);
Serial.begin(9600);
  digitalWrite(ledpin,HIGH);
    delay(250);
    digitalWrite(ledpin,LOW);
     inputString.reserve(200);
     stringComplete = false;
}

void loop() {
  
  // put your main code here, to run repeatedly:
  if (stringComplete) {
   Serial.print(inputString);
       datas();
        // clear the string:
    inputString = "";
  stringComplete = false;
  }
}
void datas(){
if(inputString=="m1gof"){
        digitalWrite(ledpin,HIGH);
             }
   else if(inputString=="allstop"){
         digitalWrite(ledpin,LOW);
     }
  else if(inputString=="m1gob"){
         digitalWrite(ledpin,HIGH);

    }
   else if(inputString=="m2gob"){
         digitalWrite(ledpin,HIGH);

    }
    else if(inputString=="m2gof"){
      digitalWrite(ledpin,HIGH);

    }
     else if(inputString=="m3gob"){
         digitalWrite(ledpin,HIGH);
 
    }
  else if(inputString=="m3gof"){
         digitalWrite(ledpin,HIGH);
      } else if(inputString=="m4gob"){
         digitalWrite(ledpin,HIGH);

    }
  else if(inputString=="m4gof"){
         digitalWrite(ledpin,HIGH);

    }
     else if(inputString=="m5gob"){
         digitalWrite(ledpin,HIGH);
    }
  else if(inputString=="m5gof"){
         digitalWrite(ledpin,HIGH);

    }
     else if(inputString=="m6gob"){
         digitalWrite(ledpin,HIGH);

    }
  else if(inputString=="m6gof"){
         digitalWrite(ledpin,HIGH);
    }
}

void serialEvent() {
   while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();
    // add it to the inputString:
   inputString += inChar;
    // if the incoming character is a newline, set a flag so the main loop can
    // do something about it:
                  if (inChar == '\n') {
      stringComplete = true;
      inputString.remove(inputString.length()-1);
                }
  
  }
}
