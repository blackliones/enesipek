using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CarUserControl : MonoBehaviour
    {
                //GameObjects
        public GameObject remy, remydriving, crosshair, carcamera, personcamera, farlight;
         public GameObject informationtextobj;
        public Transform cameratransform;
        public GameObject healthbar;
        //ARAÇ PARÇALARI
        public GameObject bonnet, baggage, fldoor, frdoor, rrdoor,rldoor;
        public bool bonnetstate, baggagestate, fldoorstate, frdoorstate,rrdoorstate, rldoorstate;
        //Booleans
        public bool drivestate,keyuppitch ,binis, inis, farlightstate, enginestate,drive,duranaracbool;
        //Animators
        public Animator anim;
        public Animator caropendooranim;
        //Float-Ýnt-Double..
        public float distance,zamanin, zamanout, maxinzaman, maxoutzaman,brk,estime,esmaxtime;//estime - enginestarttime
        //Transform
        public Transform cardoor1,cardoor1koordinat,karakter,carmass;
        //Scripts
        public RemyMoveSc rms;
        public raycasthit rch;
        public MouseLook ml1, ml2;
                public Options optionscript;
        public CarControlScript ccs;
        //Audio..
        AudioSource audios;
        public AudioClip kaydirmabaslangic,kaydirmabitis,startenginesound,stopenginesound,driveenginesound,duranaracses;     
        //Material-Texture-Pictures
        public Material farbackstop;
        public Texture stopontexture, stopofftexture;
        //Others
        public float drivingsoundval;
        public float currentSpeed,TopSpeed;
        [SerializeField]
        private float[] gearRatioValues;
        public float currentGear;
        public float speedval;
        public bool handbrake;
        public float minGear;
        public float h,v;
        public string carname;
             public float maxGear;
        public int gearAuto;
             public int i;
        public float speed = 0.1F;
        private void Awake()
        {
            baggagestate = false;
            fldoorstate = false;
            frdoorstate = false;
                      rldoorstate = false;
            rrdoorstate = false;

            bonnetstate = false;
            estime = esmaxtime;
            enginestate = false;
                     audios = GetComponent<AudioSource>();
            zamanin = maxinzaman;
            zamanout = maxoutzaman;
            cameratransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
                                  karakter = GameObject.FindGameObjectWithTag("Player").transform;
            ccs = GetComponent<CarControlScript>();
            optionscript = GameObject.Find("UIManager").GetComponent<Options>();
            farlightstate = false;
            farlight.SetActive(false);
            drivingsoundval = 0;
            gearAuto = 0;
            keyuppitch = false;
         audios.loop=false;
        }

    
   public void FixedUpdate()
        {
            optionscript.carname = carname;
            carpartsvoid();
                      distance = Vector3.Distance(karakter.position, carmass.position);
            if (keyuppitch)
            {
                float i = audios.pitch;
                if (i >= 0.5f)
                {
                  i-=Time.deltaTime;
                }
                    audios.pitch = i;
            }
                      if (enginestate)
            {
                if (estime > 0)
                {
                    estime -= Time.deltaTime;
                    brk = 20000;
                }
                else if (estime <= 0)
                {
                                        enginestate = false;
                    brk = 0;
                   
                }

            }

        
            if (distance > 4||inis||binis)
            {
                informationtextobj.SetActive(false);
            }
            if (distance <= 4 && !drivestate)
            {
                if (!inis && !binis)
                {
                    informationtextobj.SetActive(true);
                }
                if (Input.GetKey(KeyCode.F)){
                    binis = true;
                    informationtextobj.SetActive(false);
                    ml1.driving = true;
                    ml2.driving = true;
                }
            }
           
            else if (drivestate)
            {
                carname = gameObject.transform.name;
                              informationtextobj.SetActive(false);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    inis = true;
                }

            }
                      if (inis)
            {
                               rch.carmodel = "none";
                karakter.position = cardoor1koordinat.position + new Vector3(0,1,0);
                caropendooranim.SetBool("opencardoor",true);
             
                if (zamanout > 0)
                {
                    
                    zamanout -= Time.deltaTime;
             karakter.eulerAngles = new Vector3(0, 244.8f, 0);

                }
                else if (zamanout <= 0)
                {
                    caropendooranim.SetBool("opencardoor", false);
                    rch.carenterexit = false;
                    audios.clip = stopenginesound;
                    audios.Play();
                    zamanout = maxoutzaman;
                    drivestate = false;
                    ml1.driving = false;
                    ml2.driving = false;
                    remydriving.SetActive(false);
                    remy.SetActive(true);
                    inis = false;
                                 }
              
            }
            else if (binis)
            {
                   rch.carenterexit = true;
                rch.carmodel = gameObject.transform.name;
                           caropendooranim.SetBool("opencardoor", true);
                                              if (zamanin <= 0.5f)
                {
                    caropendooranim.SetBool("opencardoor", false);
                }
                if (zamanin > 0)
                {
                    zamanin -= Time.deltaTime;
                  
                                                 rms.move = false;
                                       
                }
               
                else if (zamanin <= 0)
                {            
                    enginestate = true;
                   audios.clip = startenginesound;
                    audios.Play();
                    rms.move = true;
                    remy.SetActive(false);
                    binis = false;
                    estime = esmaxtime;
                    enginestate = true;
                    drivestate = true;
                    remydriving.SetActive(true);
                      zamanin = maxinzaman;   
                                                     
                    cardoor1.transform.eulerAngles = new Vector3(-90, 0,0);
                }
            }
            if (drivestate)
            {
               if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                                       gearAuto += 1;
                }
                else if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                 
                    gearAuto -= 1;
                }
                if(gearAuto < -1)
                {
                    gearAuto = -1;
                }
                else if(gearAuto > 1)
                {
                    gearAuto = 1;
                }

                if (gearAuto == 1)
                {
                  
                }
                else if (gearAuto == 0)
                {
                    
                }
                else if (gearAuto == -1)
                {
                   
                }
                    if (baggagestate)
                {
                                baggage.transform.localEulerAngles = new Vector3(-85, 0, 0);
                }
                else
                {
                                                 baggage.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                if (bonnetstate)
                {
                                  bonnet.transform.localEulerAngles = new Vector3(45.0f, 0, 0);

                }
                else
                {
                                        bonnet.transform.localEulerAngles = new Vector3(0,0, 0);

                }
                if (fldoorstate)
                {
                    fldoor.transform.eulerAngles = new Vector3(0,-45,0);
                }
                else
                {
                                     fldoor.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                if (frdoorstate)
                {
                    frdoor.transform.eulerAngles = new Vector3(0, -135, 0);
                }
                else
                {
                    frdoor.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                if (rldoorstate)
                {
                   rldoor.transform.eulerAngles = new Vector3(0, -45, 0);
                }
                else
                {
                   rldoor.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                if (rrdoorstate)
                {
                    rrdoor.transform.eulerAngles = new Vector3(0, -135, 0);
                }
                else
                {
                    rrdoor.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                if (Time.timeScale == 1)
                {
                  //currentSpeed = m_Car.CurrentSpeed;
                //    TopSpeed = m_Car.MaxSpeed;

                    for (i = 0; i < gearRatioValues.Length; i++)
                    {
                        if (gearRatioValues[i] > currentSpeed)
                        {
                            currentGear = i;
                            break;
                        }
                    }
                    if (i == 0)
                    {
                        minGear = 0;

                    }
                    else
                        minGear = gearRatioValues[i - 1];
                    maxGear = gearRatioValues[i];
                    if (Input.GetKey(KeyCode.W) && !enginestate&&!Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.S) && !enginestate && !Input.GetKey(KeyCode.Space))
                    {
                        keyuppitch = false;
                        if (drivingsoundval == 0)
                        {
                            drivingsoundval = 1;
                            audios.clip = driveenginesound;
                            audios.Play();
                            audios.loop = true;
                        }
                        if (drivingsoundval == 1)
                        {
                            audios.pitch = (currentSpeed - (minGear / 1.15f)) / (maxGear - minGear) + 1;
                        }
                    }
                    else if (!Input.GetKeyUp(KeyCode.W)&&!Input.GetKey(KeyCode.Space)|| !Input.GetKeyUp(KeyCode.S) && !Input.GetKey(KeyCode.Space))
                    {
                        keyuppitch = true;
                      
                    }
                    healthbar.SetActive(false);
                    if (Input.GetKeyDown(KeyCode.G))
                    {
                        if (farlightstate)
                        {
                            farlightstate = false;
                            farlight.SetActive(false);
                        }
                        else
                        {
                            farlight.SetActive(true);
                            farlightstate = true;
                        }
                    }
                    crosshair.SetActive(false);
                    carcamera.SetActive(true);
                    personcamera.SetActive(false);
                    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Space))
                    {
                        farbackstop.mainTexture = stopontexture;
                    }
                    else if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.Space))
                    {
                        farbackstop.mainTexture = stopofftexture;
                    }
                     h = CrossPlatformInputManager.GetAxis("Horizontal");
                     v = -CrossPlatformInputManager.GetAxis("Vertical");
                    if (Input.GetKey(KeyCode.Space))
                    {
                             audios.pitch = 1;
                    }
                    if (currentSpeed < 11)
                    {
                        audios.pitch = 1;
                        if (Input.GetKey(KeyCode.Space))
                        {
                            if (audios.clip == kaydirmabaslangic)
                            {
                                audios.clip = null;
                                audios.Stop();
                            }
                           
                        }
                    
                        if (!Input.anyKey&&!enginestate)
                        {
                            if (audios.clip != duranaracses)
                            {
                                audios.loop = true;
                                audios.clip = duranaracses;
                                audios.Play();
                            }
                                                    
                                                   }   

                    }
                    if (handbrake)
                    {
                        brk = 200;
                    }
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        brk = 250;
                    }
                    else if (Input.GetKeyUp(KeyCode.S))
                    {
                        brk = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W))
                    {
                        if (handbrake)
                        {
                            handbrake = false;
                            brk = 0;
                        }
                        else
                        {
                                                 handbrake = true;
                        }
                        
                    
                        drivingsoundval = 0;
                        if (currentSpeed > 11)
                        {
                            audios.loop = true;
                            audios.clip = kaydirmabaslangic;
                            audios.Play();

                        }
                      
                    }
                    else if (!Input.GetKey(KeyCode.S)&&!handbrake)
                    {

                        if (audios.clip == kaydirmabaslangic)
                        {

                            audios.Stop();
                            audios.loop = false;
                        }
                        brk = 0;
                    }

                                   }
            }
            else
            {
                healthbar.SetActive(true);
                crosshair.SetActive(true);
                personcamera.SetActive(true);
                carcamera.SetActive(false);
             //   m_Car.Move(0, 0, 0, 20000);
                            }
            if (enginestate)
            {
           //     m_Car.Move(0, 0, 0, 20000);
            }
        }
       
        private void carpartsvoid()
        {
            if (carname == "Erexas")
            {
                               baggage = GameObject.Find("erexasbaggage");
                bonnet = GameObject.Find("erexasbonnet");
                frdoor = GameObject.Find("erexasfrdoor");
                fldoor = GameObject.Find("erexasfldoor");
                rrdoor = GameObject.Find("erexasrrdoor");
                rldoor = GameObject.Find("erexasrldoor");
                      }
        }
    }

 }
