
String value2 = "";

int Header =1;

int menuMod = 1;
int programMode = 4;
int topicon1 = 5;
int topicon2 = 12;
int saat = 07;
int dk = 22;
int trigger = 0;
int sleepState = 3;
int Sicaklikdegeri = 12;
int Sicaklik_buffer=0;
int DurSaat = 0;
int DurDk = 0;
int EOFsaat = 0;
int EOFdk = 0;
int AlarmSaat =0;
int AlarmDk = 0;
int EcoState = 0;
int SaatAyarlar = 0;
int DkAyarlar = 0;
int Buzzer = 0;
int Parlaklik = 0;
int BlueTooth = 0;
int Language = 0;
int GeceModu = 0;
int SleepTime = 44;
int UnitTemp = 0;
int HazirYemekSicaklik = 0;
int HazirYemekSaat = 0;
int HazirYemekDk = 0;
int Gelen_buffer=0;
int oldGelen_buffer = 0;
String old_value2="";

int HazirYemekDk_BufferMeat=0;
int HazirYemekSaat_BufferMeat=0;

int HazirYemekDk_BufferChicken=0;
int HazirYemekSaat_BufferChicken=0;

int HazirYemekDk_BufferFish=0;
int HazirYemekSaat_BufferFish=0;

int HazirYemekDk_BufferVegan=0;
int HazirYemekSaat_BufferVegan=0;

int HazirYemekDk_BufferPaste=0;
int HazirYemekSaat_BufferPaste=0;

int HazirYemekDk_BufferPizza=0;
int HazirYemekSaat_BufferPizza=0;

int HazirYemekDk_BufferCake=0;
int HazirYemekSaat_BufferCake=0;

int HazirYemekDk_BufferCookie=0;
int HazirYemekSaat_BufferCookie=0;

int HazirYemekDk_BufferPie=0;
int HazirYemekSaat_BufferPie=0;

int HazirYemekDk_BufferBread=0;
int HazirYemekSaat_BufferBread=0;


String value = "";
boolean durum = false;
boolean stringComplete=false;

void setup() 
{
 Serial.begin(115200);
//Serial2.begin(115200);
 delay(1000);
 
 


}

void loop() 
{

while (Serial.available()  > 0)
  {
    char gelen = (char)Serial.read();
    value += gelen;
   
    if (gelen == '?')
    {
      value2=value;
      Serial.print(value2);
      stringComplete = true;
    }
    
  }
  
  
  
      if(value2 == "R0?")
      {
        Sicaklik_buffer=0;
        
      }
          if(value2 == "R1?")
      {
        Sicaklik_buffer=1;
        
      }
       if(value2 == "R2?")
      {
        Sicaklik_buffer=2;
        
      }
       if(value2 == "R3?")
      {
        Sicaklik_buffer=3;
        
      }
       if(value2 == "R4?")
      {
        Sicaklik_buffer=4;
        
      }
      if(value2 == "R5?")
      {
        Sicaklik_buffer=5;
        
      }
       if(value2 == "R6?")
      {
        Sicaklik_buffer=6;
        
      }
       if(value2 == "R7?")
      {
        Sicaklik_buffer=7;
        
      }
       if(value2 == "R8?")
      {
        Sicaklik_buffer=8;
        
        
      }
   
      if(value2 == "R9?")
      {
        Sicaklik_buffer=9;
        
      }
       if(value2 == "R10?")
      {
        Sicaklik_buffer=10;
        
      }
       if(value2 == "R11?")
      {
        Sicaklik_buffer=11;
        
      }
       if(value2 == "R12?")
      {
        Sicaklik_buffer=12;
        
      }
    
      if(value2 == "R13?")
      {        
        Sicaklik_buffer=13;
        
       
      }

       if(value2 == "R14?")
      {
        Sicaklik_buffer=14;
        
      }

       if(value2 == "R15?")
      {
        Sicaklik_buffer=15;
        
      }
       if(value2 == "R16?")
      {
        Sicaklik_buffer=16;
        
      }

       
      
      if(value2 == "R17?")
      {
        Sicaklik_buffer=17;
        
      }
       if(value2 == "R18?")
      {
        Sicaklik_buffer=18;
        
      }
       if(value2 == "R19?")
      {
        Sicaklik_buffer=19;
        
      }
       if(value2 == "R20?")
      {
        Sicaklik_buffer=20;
        
      }
      if(value2 == "R21?")
      {
        Sicaklik_buffer=21;
        
      }
       if(value2 == "R22?")
      {
        Sicaklik_buffer=22;
        
      }
       if(value2 == "R23?")
      {
        Sicaklik_buffer=23;
        
      }
       if(value2 == "R24?")
      {
        Sicaklik_buffer=24;
        
      }
      if(value2 == "R25?")
      {
        Sicaklik_buffer=25;
        
      }
       if(value2 == "R26?")
      {
        Sicaklik_buffer=26;
        
      }
       if(value2 == "R27?")
      {
        Sicaklik_buffer=27;
        
      }
       if(value2 == "R28?")
      {
        Sicaklik_buffer=28;
        
      }
      if(value2 == "R29?")
      {
        Sicaklik_buffer=29;
        
      }
       if(value2 == "R30?")
      {
        Sicaklik_buffer=30;
        
      }
       if(value2 == "R31?")
      {
        Sicaklik_buffer=31;
        
      }
       if(value2 == "R32?")
      {
        Sicaklik_buffer=32;
        
      }
      if(value2 == "R33?")
      {
        Sicaklik_buffer=33;
        
      }
       if(value2 == "R34?")
      {
        Sicaklik_buffer=34;
        
      }
       if(value2 == "R35?")
      {
        Sicaklik_buffer=35;
        
      }
       if(value2 == "R36?")
      {
        Sicaklik_buffer=36;
        
      
      }
      if(value2 == "R37?")
      {
        Sicaklik_buffer=37;
        
      
      }
       if(value2 == "R38?")
      {
        Sicaklik_buffer=38;
        
        
      }
       if(value2 == "R39?")
      {
        Sicaklik_buffer=39;
        
        
      }
       if(value2 == "R40?")
      {
        Sicaklik_buffer=40;
        
      }

      if(menuMod == 1)
      {
        Sicaklikdegeri=Sicaklik_buffer;
        //value2="";
      }

      if(value2 == "L0?")
      {
        Gelen_buffer=0;
        
      }

      if(value2 == "L1?")
      {
        Gelen_buffer=1;
        
      }
       if(value2 == "L2?")
      {
        Gelen_buffer=2;
       
      }
       if(value2 == "L3?")
      {
        Gelen_buffer=3;
        
      }
       if(value2 == "L4?")
      {
        Gelen_buffer=4;
        
      }
      if(value2 == "L5?")
      {
        Gelen_buffer=5;
        
      }
       if(value2 == "L6?")
      {
        Gelen_buffer=6;
        
      }
       if(value2 == "L7?")
      {
        Gelen_buffer=7;
        
      }
       if(value2 == "L8?")
      {
        Gelen_buffer=8;
        
      }
   
      if(value2 == "L9?")
      {
        Gelen_buffer=9;
        
      }
       if(value2 == "L10?")
      {
        Gelen_buffer=10;
        
      }
       if(value2 == "L11?")
      {
        Gelen_buffer=11;
        
      }
       if(value2 == "L12?")
      {
        Gelen_buffer=12;
        
      }
    
      if(value2 == "L13?")
      {        
        Gelen_buffer=13;
       
      }

       if(value2 == "L14?")
      {
        Gelen_buffer=14;
        
      }

       if(value2 == "L15?")
      {
        Gelen_buffer=15;
        
      }
       if(value2 == "L16?")
      {
        Gelen_buffer=16;
        
      }

       
      
      if(value2 == "L17?")
      {
        Gelen_buffer=17;
        
      }
       if(value2 == "L18?")
      {
        Gelen_buffer=18;
        
      }
       if(value2 == "L19?")
      {
        Gelen_buffer=19;
        
      }
       if(value2 == "L20?")
      {
        Gelen_buffer=20;
        
      }
      if(value2 == "L21?")
      {
        Gelen_buffer=21;
        
      }
       if(value2 == "L22?")
      {
        Gelen_buffer=22;
        
      }
       if(value2 == "L23?")
      {
        Gelen_buffer=23;
        
      }
       if(value2 == "L24?")
      {
        Gelen_buffer=24;
        
      }
      if(value2 == "L25?")
      {
        Gelen_buffer=25;
        
      }
       if(value2 == "L26?")
      {
        Gelen_buffer=26;
        
      }
       if(value2 == "L27?")
      {
        Gelen_buffer=27;
        
      }
       if(value2 == "L28?")
      {
        Gelen_buffer=28;
        
      }
      if(value2 == "L29?")
      {
        Gelen_buffer=29;
        
      }
       if(value2 == "L30?")
      {
        Gelen_buffer=30;
        
      }
       if(value2 == "L31?")
      {
        Gelen_buffer=31;
       
      }
       if(value2 == "L32?")
      {
        Gelen_buffer=32;
        
      }
      if(value2 == "L33?")
      {
        Gelen_buffer=33;
        
      }
       if(value2 == "L34?")
      {
        Gelen_buffer=34;
        
      }
       if(value2 == "L35?")
      {
        Gelen_buffer=35;
        
      }
       if(value2 == "L36?")
      {
        Gelen_buffer=36;
        
      
      }
      if(value2 == "L37?")
      {
        Gelen_buffer=37;
        
      
      }
       if(value2 == "L38?")
      {
        Gelen_buffer=38;
        
        
      }
       if(value2 == "L39?")
      {
        Gelen_buffer=39;
        
        
      }
       if(value2 == "L40?")
      {
        Gelen_buffer=40;
        
      }

     
      if(menuMod ==27 || menuMod == 29 || menuMod == 31 || menuMod == 33 || menuMod == 35 || menuMod == 37 || menuMod == 39 || menuMod == 41 || menuMod == 43 || menuMod == 45)
      {

        if(Gelen_buffer  > 0 && Gelen_buffer < 5)
        {
          HazirYemekSicaklik =150;
          
        }
        if(Gelen_buffer  > 4 && Gelen_buffer < 10)
        {
          HazirYemekSicaklik =160;
        }
        if(Gelen_buffer  > 9 && Gelen_buffer < 15)
        {
          HazirYemekSicaklik =170;
        }
        if(Gelen_buffer  > 14 && Gelen_buffer < 20)
        {
          HazirYemekSicaklik =180;
        }
        if(Gelen_buffer  > 19 && Gelen_buffer < 25)
        {
          HazirYemekSicaklik =190;
        }
        if(Gelen_buffer  > 24 && Gelen_buffer < 30)
        {
          HazirYemekSicaklik =200;
        }
        if(Gelen_buffer  > 29 && Gelen_buffer < 35)
        {
          HazirYemekSicaklik =210;
        }
        if(Gelen_buffer  > 34 && Gelen_buffer < 40)
        {
          HazirYemekSicaklik =220;
        }
        
        
      }

      

if(menuMod == 28)
          {
            
              HazirYemekDk=HazirYemekDk_BufferMeat;
              HazirYemekSaat=HazirYemekSaat_BufferMeat;
            
            if(Gelen_buffer > oldGelen_buffer)
             {
              if(Gelen_buffer == 40 && oldGelen_buffer == 0)
              {
                HazirYemekDk--;
              }
              
              HazirYemekDk++;
              
              if(HazirYemekDk == 60)
              {
                HazirYemekSaat++;
                HazirYemekDk=0;
              }
              oldGelen_buffer=Gelen_buffer;
              
             }
             
             if(Gelen_buffer < oldGelen_buffer)
             {
              if(Gelen_buffer == 0 && oldGelen_buffer == 40)
              {
                HazirYemekDk++;
              }
              if(HazirYemekDk > 0)
              {
                HazirYemekDk--;
              
              if(HazirYemekDk == 0)
              {
                if(HazirYemekSaat == 0)
                {
                  HazirYemekSaat=0;
                  HazirYemekDk = 0;
                }
                else
                {
                   HazirYemekSaat--;
                   HazirYemekDk=60;
                }
              }
              
              }
              
             oldGelen_buffer=Gelen_buffer;
             }
              
            HazirYemekDk_BufferMeat=HazirYemekDk;
            HazirYemekSaat_BufferMeat=HazirYemekSaat;
          }

if(menuMod == 30)
          {
            
              HazirYemekDk=HazirYemekDk_BufferChicken;
              HazirYemekSaat=HazirYemekSaat_BufferChicken;
            
            if(Gelen_buffer > oldGelen_buffer)
             {
              if(Gelen_buffer == 40 && oldGelen_buffer == 0)
              {
                HazirYemekDk--;
              }
              
              HazirYemekDk++;
              
              if(HazirYemekDk == 60)
              {
                HazirYemekSaat++;
                HazirYemekDk=0;
              }
              oldGelen_buffer=Gelen_buffer;
              
             }
             
             if(Gelen_buffer < oldGelen_buffer)
             {
              if(Gelen_buffer == 0 && oldGelen_buffer == 40)
              {
                HazirYemekDk++;
              }
              if(HazirYemekDk > 0)
              {
                HazirYemekDk--;
              
              if(HazirYemekDk == 0)
              {
                if(HazirYemekSaat == 0)
                {
                  HazirYemekSaat=0;
                  HazirYemekDk = 0;
                }
                else
                {
                   HazirYemekSaat--;
                   HazirYemekDk=60;
                }
              }
              
              }
              
             oldGelen_buffer=Gelen_buffer;
             }
              
            HazirYemekDk_BufferChicken=HazirYemekDk;
            HazirYemekSaat_BufferChicken=HazirYemekSaat;
}

if(menuMod == 32)
          {
            
              HazirYemekDk=HazirYemekDk_BufferFish;
              HazirYemekSaat=HazirYemekSaat_BufferFish;
            
            if(Gelen_buffer > oldGelen_buffer)
             {
              if(Gelen_buffer == 40 && oldGelen_buffer == 0)
              {
                HazirYemekDk--;
              }
              
              HazirYemekDk++;
              
              if(HazirYemekDk == 60)
              {
                HazirYemekSaat++;
                HazirYemekDk=0;
              }
              oldGelen_buffer=Gelen_buffer;
              
             }
             
             if(Gelen_buffer < oldGelen_buffer)
             {
              if(Gelen_buffer == 0 && oldGelen_buffer == 40)
              {
                HazirYemekDk++;
              }
              if(HazirYemekDk > 0)
              {
                HazirYemekDk--;
              
              if(HazirYemekDk == 0)
              {
                if(HazirYemekSaat == 0)
                {
                  HazirYemekSaat=0;
                  HazirYemekDk = 0;
                }
                else
                {
                   HazirYemekSaat--;
                   HazirYemekDk=60;
                }
              }
              
              }
              
             oldGelen_buffer=Gelen_buffer;
             }
              
            HazirYemekDk_BufferFish=HazirYemekDk;
            HazirYemekSaat_BufferFish=HazirYemekSaat;
}




if(menuMod == 34)
          {
            
              HazirYemekDk=HazirYemekDk_BufferVegan;
              HazirYemekSaat=HazirYemekSaat_BufferVegan;
            
            if(Gelen_buffer > oldGelen_buffer)
             {
              if(Gelen_buffer == 40 && oldGelen_buffer == 0)
              {
                HazirYemekDk--;
              }
              
              HazirYemekDk++;
              
              if(HazirYemekDk == 60)
              {
                HazirYemekSaat++;
                HazirYemekDk=0;
              }
              oldGelen_buffer=Gelen_buffer;
              
             }
             
             if(Gelen_buffer < oldGelen_buffer)
             {
              if(Gelen_buffer == 0 && oldGelen_buffer == 40)
              {
                HazirYemekDk++;
              }
              if(HazirYemekDk > 0)
              {
                HazirYemekDk--;
              
              if(HazirYemekDk == 0)
              {
                if(HazirYemekSaat == 0)
                {
                  HazirYemekSaat=0;
                  HazirYemekDk = 0;
                }
                else
                {
                   HazirYemekSaat--;
                   HazirYemekDk=60;
                }
              }
              
              }
              
             oldGelen_buffer=Gelen_buffer;
             }
              
            HazirYemekDk_BufferVegan=HazirYemekDk;
            HazirYemekSaat_BufferVegan=HazirYemekSaat;
}

if(menuMod == 36)
          {
            
              HazirYemekDk=HazirYemekDk_BufferPaste;
              HazirYemekSaat=HazirYemekSaat_BufferPaste;
            
            if(Gelen_buffer > oldGelen_buffer)
             {
              if(Gelen_buffer == 40 && oldGelen_buffer == 0)
              {
                HazirYemekDk--;
              }
              
              HazirYemekDk++;
              
              if(HazirYemekDk == 60)
              {
                HazirYemekSaat++;
                HazirYemekDk=0;
              }
              oldGelen_buffer=Gelen_buffer;
              
             }
             
             if(Gelen_buffer < oldGelen_buffer)
             {
              if(Gelen_buffer == 0 && oldGelen_buffer == 40)
              {
                HazirYemekDk++;
              }
              if(HazirYemekDk > 0)
              {
                HazirYemekDk--;
              
              if(HazirYemekDk == 0)
              {
                if(HazirYemekSaat == 0)
                {
                  HazirYemekSaat=0;
                  HazirYemekDk = 0;
                }
                else
                {
                   HazirYemekSaat--;
                   HazirYemekDk=60;
                }
              }
              
              }
              
             oldGelen_buffer=Gelen_buffer;
             }
              
            HazirYemekDk_BufferPaste=HazirYemekDk;
            HazirYemekSaat_BufferPaste=HazirYemekSaat;
}






if(menuMod == 38)
          {
            
              HazirYemekDk=HazirYemekDk_BufferPizza;
              HazirYemekSaat=HazirYemekSaat_BufferPizza;
            
            if(Gelen_buffer > oldGelen_buffer)
             {
              if(Gelen_buffer == 40 && oldGelen_buffer == 0)
              {
                HazirYemekDk--;
              }
              
              HazirYemekDk++;
              
              if(HazirYemekDk == 60)
              {
                HazirYemekSaat++;
                HazirYemekDk=0;
              }
              oldGelen_buffer=Gelen_buffer;
              
             }
             
             if(Gelen_buffer < oldGelen_buffer)
             {
              if(Gelen_buffer == 0 && oldGelen_buffer == 40)
              {
                HazirYemekDk++;
              }
              if(HazirYemekDk > 0)
              {
                HazirYemekDk--;
              
              if(HazirYemekDk == 0)
              {
                if(HazirYemekSaat == 0)
                {
                  HazirYemekSaat=0;
                  HazirYemekDk = 0;
                }
                else
                {
                   HazirYemekSaat--;
                   HazirYemekDk=60;
                }
              }
              
              }
              
             oldGelen_buffer=Gelen_buffer;
             }
              
            HazirYemekDk_BufferPizza=HazirYemekDk;
            HazirYemekSaat_BufferPizza=HazirYemekSaat;
}

if(menuMod == 40)
          {
            
              HazirYemekDk=HazirYemekDk_BufferCake;
              HazirYemekSaat=HazirYemekSaat_BufferCake;
            
            if(Gelen_buffer > oldGelen_buffer)
             {
              if(Gelen_buffer == 40 && oldGelen_buffer == 0)
              {
                HazirYemekDk--;
              }
              
              HazirYemekDk++;
              
              if(HazirYemekDk == 60)
              {
                HazirYemekSaat++;
                HazirYemekDk=0;
              }
              oldGelen_buffer=Gelen_buffer;
              
             }
             
             if(Gelen_buffer < oldGelen_buffer)
             {
              if(Gelen_buffer == 0 && oldGelen_buffer == 40)
              {
                HazirYemekDk++;
              }
              if(HazirYemekDk > 0)
              {
                HazirYemekDk--;
              
              if(HazirYemekDk == 0)
              {
                if(HazirYemekSaat == 0)
                {
                  HazirYemekSaat=0;
                  HazirYemekDk = 0;
                }
                else
                {
                   HazirYemekSaat--;
                   HazirYemekDk=60;
                }
              }
              
              }
              
             oldGelen_buffer=Gelen_buffer;
             }
              
            HazirYemekDk_BufferCake=HazirYemekDk;
            HazirYemekSaat_BufferCake=HazirYemekSaat;
}

if(menuMod == 42)
          {
            
              HazirYemekDk=HazirYemekDk_BufferCookie;
              HazirYemekSaat=HazirYemekSaat_BufferCookie;
            
            if(Gelen_buffer > oldGelen_buffer)
             {
              if(Gelen_buffer == 40 && oldGelen_buffer == 0)
              {
                HazirYemekDk--;
              }
              
              HazirYemekDk++;
              
              if(HazirYemekDk == 60)
              {
                HazirYemekSaat++;
                HazirYemekDk=0;
              }
              oldGelen_buffer=Gelen_buffer;
              
             }
             
             if(Gelen_buffer < oldGelen_buffer)
             {
              if(Gelen_buffer == 0 && oldGelen_buffer == 40)
              {
                HazirYemekDk++;
              }
              if(HazirYemekDk > 0)
              {
                HazirYemekDk--;
              
              if(HazirYemekDk == 0)
              {
                if(HazirYemekSaat == 0)
                {
                  HazirYemekSaat=0;
                  HazirYemekDk = 0;
                }
                else
                {
                   HazirYemekSaat--;
                   HazirYemekDk=60;
                }
              }
              
              }
              
             oldGelen_buffer=Gelen_buffer;
             }
              
            HazirYemekDk_BufferCookie=HazirYemekDk;
            HazirYemekSaat_BufferCookie=HazirYemekSaat;
}

if(menuMod == 44)
          {
            
              HazirYemekDk=HazirYemekDk_BufferPie;
              HazirYemekSaat=HazirYemekSaat_BufferPie;
            
            if(Gelen_buffer > oldGelen_buffer)
             {
              if(Gelen_buffer == 40 && oldGelen_buffer == 0)
              {
                HazirYemekDk--;
              }
              
              HazirYemekDk++;
              
              if(HazirYemekDk == 60)
              {
                HazirYemekSaat++;
                HazirYemekDk=0;
              }
              oldGelen_buffer=Gelen_buffer;
              
             }
             
             if(Gelen_buffer < oldGelen_buffer)
             {
              if(Gelen_buffer == 0 && oldGelen_buffer == 40)
              {
                HazirYemekDk++;
              }
              if(HazirYemekDk > 0)
              {
                HazirYemekDk--;
              
              if(HazirYemekDk == 0)
              {
                if(HazirYemekSaat == 0)
                {
                  HazirYemekSaat=0;
                  HazirYemekDk = 0;
                }
                else
                {
                   HazirYemekSaat--;
                   HazirYemekDk=60;
                }
              }
              
              }
              
             oldGelen_buffer=Gelen_buffer;
             }
              
            HazirYemekDk_BufferPie=HazirYemekDk;
            HazirYemekSaat_BufferPie=HazirYemekSaat;
}

if(menuMod == 46)
          {
            
              HazirYemekDk=HazirYemekDk_BufferBread;
              HazirYemekSaat=HazirYemekSaat_BufferBread;
            
            if(Gelen_buffer > oldGelen_buffer)
             {
              if(Gelen_buffer == 40 && oldGelen_buffer == 0)
              {
                HazirYemekDk--;
              }
              
              HazirYemekDk++;
              
              if(HazirYemekDk == 60)
              {
                HazirYemekSaat++;
                HazirYemekDk=0;
              }
              oldGelen_buffer=Gelen_buffer;
              
             }
             
             if(Gelen_buffer < oldGelen_buffer)
             {
              if(Gelen_buffer == 0 && oldGelen_buffer == 40)
              {
                HazirYemekDk++;
              }
              if(HazirYemekDk > 0)
              {
                HazirYemekDk--;
              
              if(HazirYemekDk == 0)
              {
                if(HazirYemekSaat == 0)
                {
                  HazirYemekSaat=0;
                  HazirYemekDk = 0;
                }
                else
                {
                   HazirYemekSaat--;
                   HazirYemekDk=60;
                }
              }
              
              }
              
             oldGelen_buffer=Gelen_buffer;
             }
              
            HazirYemekDk_BufferBread=HazirYemekDk;
            HazirYemekSaat_BufferBread=HazirYemekSaat;
}



    if(menuMod == 5)
          {
            if(Gelen_buffer > oldGelen_buffer)
             {
              if(Gelen_buffer == 40 && oldGelen_buffer == 0)
              {
                DurDk--;
              }
              
              DurDk++;
              
              if(DurDk == 60)
              {
                DurSaat++;
                DurDk=0;
              }
              oldGelen_buffer=Gelen_buffer;
              
             }
             
             if(Gelen_buffer < oldGelen_buffer)
             {
              if(Gelen_buffer == 0 && oldGelen_buffer == 40)
              {
                DurDk++;
              }
              if(DurDk > 0)
              {
                DurDk--;
              
              if(DurDk == 0)
              {
                if(DurSaat == 0)
                {
                  DurSaat=0;
                  DurDk = 0;
                }
                else
                {
                   DurSaat--;
                   DurDk=60;
                }
              }
              
              }
              
             oldGelen_buffer=Gelen_buffer;
             }
          }
      if(menuMod == 6)
          {
            if(Gelen_buffer > oldGelen_buffer)
             {
              if(Gelen_buffer == 40 && oldGelen_buffer == 0)              //0'dan 40'a geçerken 1 azalması için
              {
                EOFdk--;
              }
              EOFdk++;
              
              if(EOFdk == 60)
              {
                EOFsaat++;
                EOFdk=0;
                
              }
              
              oldGelen_buffer=Gelen_buffer;
             }

             
             if(Gelen_buffer < oldGelen_buffer)
             {
              if(Gelen_buffer == 0 && oldGelen_buffer == 40)        //40'tan 0'a geçerken 1 artması için
              {
                EOFdk++;
              }
              if(EOFdk > 0)
              {
                EOFdk--;
              
              if(EOFdk == 0)
              {
                if(EOFsaat == 0)
                {
                  EOFsaat=0;
                  EOFdk = 0;
                }
                else
                {
                   EOFsaat--;
                   EOFdk=60;
                }
              }
              
              }
              
             oldGelen_buffer=Gelen_buffer;
             }
          }
          
    if(menuMod == 7)
          {
            if(Gelen_buffer > oldGelen_buffer)
             {
              if(Gelen_buffer == 40 && oldGelen_buffer == 0)
              {
                AlarmDk--;
              }
              AlarmDk++;

              if(AlarmDk == 60)
              {
                AlarmSaat++;
                AlarmDk=0;
              }
              
              
             oldGelen_buffer=Gelen_buffer;
             }
             
             if(Gelen_buffer < oldGelen_buffer)
             {
              if(Gelen_buffer == 0 && oldGelen_buffer == 40)
              {
                AlarmDk++;
              }
             
              if(AlarmDk > 0)
              {
                AlarmDk--;
              
              if(AlarmDk == 0)
              {
                if(AlarmSaat == 0)
                {
                  AlarmSaat=0;
                  AlarmDk = 0;
                }
                else
                {
                   AlarmSaat--;
                   AlarmDk=60;
                }
              }
              
              }
              
               oldGelen_buffer=Gelen_buffer;
             }
          }
   
      if(value2 == "M1?")
      {
        menuMod=1;
        value2="";
      }
       if(value2 == "M2?")
      {
        menuMod=2;
        value2="";
      }
       if(value2 == "M3?")
      {
        menuMod=3;
        value2="";
      }
       if(value2 == "M4?")
      {
        menuMod=4;
        value2="";
      }
      if(value2 == "M5?")
      {
        menuMod=5;
        value2="";
      }
       if(value2 == "M6?")
      {
        menuMod=6;
        value2="";
      }
       if(value2 == "M7?")
      {
        menuMod=7;
        value2="";
      }
       if(value2 == "M8?")
      {
        menuMod=8;
        value2="";
        
      }
if(menuMod == 8)
  {
        if(Gelen_buffer > 20 )
        {
          EcoState=1;
        }
        if(Gelen_buffer < 20)
        {
          EcoState=0;
        }
 }
      
      if(value2 == "M9?")
      {
        menuMod=9;
      }
       if(value2 == "M10?")
      {
        menuMod=10;
      }
       if(value2 == "M11?")
      {
        menuMod=11;
      }
       if(value2 == "M12?")
      {
        menuMod=12;
      }
      
      
      if(value2 == "M13?")
      {        
        menuMod=13;
       
      }

 if(menuMod == 10)
{
  if(Gelen_buffer > oldGelen_buffer)
       {
            if(Gelen_buffer == 40 && oldGelen_buffer == 0)
                {
                  Buzzer--;
                }
                
            Buzzer++;

            if(Buzzer > 100)
                {
                  Buzzer=100;
                }
           
           oldGelen_buffer=Gelen_buffer;
       }
           
 if(Gelen_buffer < oldGelen_buffer)
      {
            if(Gelen_buffer == 0 && oldGelen_buffer == 40)
                {
                  Buzzer++;
                }
           
            if(Buzzer > 0)
                {
                  Buzzer--;
                }
            if(Buzzer == 0)
                {
                  Buzzer = 0;  
                }
         oldGelen_buffer=Gelen_buffer;         
           
     }
}

if(menuMod == 11)
{
  if(Gelen_buffer > oldGelen_buffer)
       {
            if(Gelen_buffer == 40 && oldGelen_buffer == 0)
                {
                  Parlaklik--;
                }
                
            Parlaklik++;

            if(Parlaklik > 100)
                {
                  Parlaklik=100;
                }
           
           oldGelen_buffer=Gelen_buffer;
       }
           
 if(Gelen_buffer < oldGelen_buffer)
      {
            if(Gelen_buffer == 0 && oldGelen_buffer == 40)
                {
                  Parlaklik++;
                }
           
            if(Buzzer > 0)
                {
                  Parlaklik--;
                }
            if(Parlaklik == 0)
                {
                  Parlaklik = 0;  
                }
         oldGelen_buffer=Gelen_buffer;         
           
     }
}
if(menuMod == 12)
  {
        if(Gelen_buffer > 20 )
        {
          BlueTooth=1;
        }
        if(Gelen_buffer < 20)
        {
          BlueTooth=0;
  }
  }
if(menuMod == 9)
      {
            if(Gelen_buffer > oldGelen_buffer)
             {
              if(Gelen_buffer == 40 && oldGelen_buffer == 0)
              {
                DkAyarlar--;
              }
              
              DkAyarlar++;

              if(DkAyarlar == 60)
              {
                SaatAyarlar++;
                DkAyarlar=0;
              }
              
              
             oldGelen_buffer=Gelen_buffer;
             }
             
             if(Gelen_buffer < oldGelen_buffer)
             {
              if(Gelen_buffer == 0 && oldGelen_buffer == 40)
              {
                DkAyarlar++;
              }
             
              if(DkAyarlar > 0)
              {
                DkAyarlar--;
              
              if(DkAyarlar == 0)
              {
                if(SaatAyarlar == 0)
                {
                  SaatAyarlar=0;
                  DkAyarlar = 0;
                }
                else
                {
                   SaatAyarlar--;
                   DkAyarlar=60;
                }
              }
              
              }
              
               oldGelen_buffer=Gelen_buffer;
             }
    }
 if(menuMod == 13)
  {
        if(Gelen_buffer > 20 )
        {
          Language=1;
        }
        if(Gelen_buffer < 20)
        {
          Language=0;
        }
  }

  if(menuMod == 14)
   {
        if(Gelen_buffer > 20 )
        {
          GeceModu=1;
        }
        if(Gelen_buffer < 20)
        {
          GeceModu=0;
        }
   }
       if(value2 == "M14?")
      {
        menuMod=14;
      }

 if(menuMod == 16)
   {
        if(Gelen_buffer > 20 )
        {
          UnitTemp=1;
        }
        if(Gelen_buffer < 20)
        {
          UnitTemp=0;
        }
    }

      
       if(value2 == "M15?")
      {
        menuMod=15;
      }
       if(value2 == "M16?")
      {
        menuMod=16;
      }

 

      
      if(value2 == "M17?")
      {
        menuMod=17;
      }
       if(value2 == "M18?")
      {
        menuMod=18;
      }
       if(value2 == "M19?")
      {
        menuMod=19;
      }
       if(value2 == "M20?")
      {
        menuMod=20;
      }
      if(value2 == "M21?")
      {
        menuMod=21;
      }
       if(value2 == "M22?")
      {
        menuMod=22;
      }
       if(value2 == "M23?")
      {
        menuMod=23;
      }
       if(value2 == "M24?")
      {
        menuMod=24;
      }
      if(value2 == "M25?")
      {
        menuMod=25;
      }
       if(value2 == "M26?")
      {
        menuMod=26;
      }
       if(value2 == "M27?")
      {
        menuMod=27;
      }
       if(value2 == "M28?")
      {
        menuMod=28;
      }
      if(value2 == "M29?")
      {
        menuMod=29;
      }
       if(value2 == "M30?")
      {
        menuMod=30;
      }
       if(value2 == "M31?")
      {
        menuMod=31;
      }
       if(value2 == "M32?")
      {
        menuMod=32;
      }
      if(value2 == "M33?")
      {
        menuMod=33;
      
      }
       if(value2 == "M34?")
      {
        menuMod=34;
      }
       if(value2 == "M35?")
      {
        menuMod=35;
     
      }
       if(value2 == "M36?")
      {
        menuMod=36;
      
      }
      if(value2 == "M37?")
      {
        menuMod=37;
       
      }
       if(value2 == "M38?")
      {
        menuMod=38;
        
       
      }
       if(value2 == "M39?")
      {
        menuMod=39;
     
      }
       if(value2 == "M40?")
      {
        menuMod=40;
      }
      if(value2 == "M41?")
      {
        menuMod=41;
      
      }
       if(value2 == "M42?")
      {
        menuMod=42;
      }
       if(value2 == "M43?")
      {
        menuMod=43;
       
      }
       if(value2 == "M44?")
      {
        menuMod=44;
      }
      if(value2 == "M45?")
      {
        menuMod=45;
      
      }
       if(value2 == "M46?")
      {
        menuMod=46;
        
      }
      
  char buffer3[350];
  sprintf(buffer3,"%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/%i/?",Header,menuMod,programMode,topicon1,topicon2,saat,dk,trigger,sleepState,Sicaklikdegeri,DurSaat,DurDk,EOFsaat,EOFdk,AlarmSaat,AlarmDk,EcoState,SaatAyarlar,DkAyarlar,Buzzer,Parlaklik,BlueTooth,Language,GeceModu,SleepTime,UnitTemp,HazirYemekSicaklik,HazirYemekSaat,HazirYemekDk); 
  Serial.print(buffer3);
  delay(100);

 
  if (stringComplete)
  {
      //value2 = "";
      value="";
      
      stringComplete = false;  
     
  }











}
