 #include <Stepper.h>
String data;
const int stepsPerRevolution =200;

Stepper myStepper1(stepsPerRevolution, 22, 23, 24 ,25);
Stepper myStepper2(stepsPerRevolution, 26, 27, 28 ,29);
Stepper myStepper3(stepsPerRevolution, 30, 31, 32 ,33);
Stepper myStepper4(stepsPerRevolution, 34, 35, 36 ,37);
Stepper myStepper5(stepsPerRevolution, 38, 39, 40 ,41);
Stepper myStepper6(stepsPerRevolution, 42, 43, 44 ,45);

void setup() {
myStepper1.setSpeed(60);
myStepper2.setSpeed(60);
myStepper3.setSpeed(60);
myStepper4.setSpeed(60);
myStepper5.setSpeed(60);
myStepper6.setSpeed(60);
Serial.begin(9600);
}

void loop() {
  
   if(Serial.available()){

 
    data = Serial.readString();
    Serial.println(data);
 if(data=="m1gof"){
    myStepper1.step(stepsPerRevolution);
    delay(10);
   }

  else if(data=="m1gob"){
    myStepper1.step(-stepsPerRevolution);
    delay(10);
   }
  else if(data=="m2gof"){
    myStepper2.step(stepsPerRevolution);
    delay(10);
   }

  else if(data=="m2gob"){
    myStepper2.step(-stepsPerRevolution);
    delay(10);
   }

   else if(data=="m3gof"){
    myStepper3.step(stepsPerRevolution);
    delay(10);
   }

  else if(data=="m3gob"){
    myStepper3.step(-stepsPerRevolution);
    delay(10);
   }


   else if(data=="m4gof"){
    myStepper4.step(stepsPerRevolution);
    delay(10);
   }

   else if(data=="m4gob"){
    myStepper4.step(-stepsPerRevolution);
    delay(10);
   }

  else if(data=="m5gof"){
    myStepper5.step(stepsPerRevolution);
    delay(10);
   }

  else if(data=="m5gob"){
    myStepper5.step(-stepsPerRevolution);
    delay(10);
   }

  else if(data=="m6gof"){
    myStepper6.step(stepsPerRevolution);
    delay(10);
   }

  else if(data=="m6gob"){
    myStepper6.step(-stepsPerRevolution);
    delay(10);
   }
   else if(data=="allstop"){
   //TÜM MOTORLARI DURDUR
   }
   }
   
   
  
}

