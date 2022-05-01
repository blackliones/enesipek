unsigned long mtime,sleeptime;
void setup() {
  // put your setup code here, to run once:
Serial.begin(9600);
sleeptime=0;
}

void loop() {
  // put your main code here, to run repeatedly:
mtime=millis();
if(mtime-sleeptime>5000){
  sleeptime=mtime;
  Serial.println("5SANIYE OLDU");
}
}
