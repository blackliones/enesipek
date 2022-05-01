//Plane
void Planegame(){
myGLCD.drawRect(0,0,82,10);
myGLCD.drawRect(0,0,82,20);
myGLCD.print("SKOR:",3,2);
myGLCD.print("ZMN:",3,12);
myGLCD.print("SV:",50,12);
myGLCD.print("|",55,2);
myGLCD.drawBitmap(Planex,Planey,plane,84,48);
myGLCD.printNumI(targetscore,60,2);
myGLCD.printNumI(level,70,12);
myGLCD.printNumI(timePlane,25,12);
myGLCD.printNumI(score,30,2);
myGLCD.drawCircle(targetx1,targety1,2);
myGLCD.drawCircle(targetx2,targety2,2);
if(score%10==0&&score>=0){
myGLCD.drawCircle(targetbossx,targetbossy,3);
bossstate=true;
}
else{
  bossstate=false;
}
myGLCD.update();
  }
void scoretab(){
   myGLCD.print(gamename,CENTER,13);
      myGLCD.drawRect(0,0,82,22);
  myGLCD.print("EN IYI SKOR",CENTER,3);
  myGLCD.setFont(MediumNumbers);
  if(gamename=="Plane"){
    myGLCD.printNumI(Planemaxscore,CENTER,25);
  }
  else if(gamename=="Defender")
  {
    myGLCD.printNumI(Defendermaxscore,CENTER,25);
  }
    myGLCD.update();
}
void gameover(){
   myGLCD.drawRect(0,0,82,12);
  myGLCD.print("KAYBETTINIZ!",CENTER,3);
   if(score>Planemaxscore){
    myGLCD.print("Yeni Skor",CENTER,20);
    myGLCD.printNumI(score,CENTER,30);
  }
  else{
     myGLCD.printNumI(score,CENTER,20);
  }
  myGLCD.update();
  }

void Planelevelcontrol(){
  if(level==1){
   timePlane = random(score+15,score+5);
  }
  else if(level>1){
    timePlane=random(score-30,score-10);
  }
 targetscore=random(score+15,score+20);
 }
 // GAMES VOİD
void gameinmenu(){
  
   myGLCD.print(gamename,CENTER,3);
    myGLCD.print("OYNA!",29,18);
myGLCD.print("SKOR TAB..",16,28);
myGLCD.drawRect(0,40,82,44);
  myGLCD.drawRect(0,0,82,12);
myGLCD.update();
}
// DEFENDER
void defendergame(){
   myGLCD.drawBitmap(gemix,0,gemi,84,48);
                if(ates)
      myGLCD.drawBitmap(bulletx,bullety,bullet,4,4);
       myGLCD.drawBitmap(enemyx,enemyy,enemy,10,10);
                   myGLCD.drawRect(0,0,82,10);
  myGLCD.print("SCORE:",0,2);
  myGLCD.printNumI(score,35,2);
    myGLCD.update();
}

