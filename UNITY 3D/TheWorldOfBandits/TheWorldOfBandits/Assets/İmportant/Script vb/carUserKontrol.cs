using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class carUserKontrol : MonoBehaviour {

    //GameObjects
    public GameObject remy, remydriving, crosshair, carcamera, personcamera, farlight;
    public GameObject informationtextobj;
    public Transform cameratransform;
    public GameObject healthbar;
    //ARAÇ PARÇALARI
    public GameObject bonnet, baggage, fldoor, frdoor, rrdoor, rldoor;
    public bool bonnetstate, baggagestate, fldoorstate, frdoorstate, rrdoorstate, rldoorstate;
    //Booleans
    public bool drivestate, keyuppitch, binis, inis, farlightstate, enginestate, drive, duranaracbool;
        //Float-İnt-Double..
    public float distance, zamanin, zamanout, maxinzaman, maxoutzaman, brk, estime, esmaxtime;//estime - enginestarttime
                                                                                              //Transform
    public Transform cardoor1koordinat, karakter, carmass;
    //Scripts
    public RemyMoveSc rms;
    public raycasthit rch;
    public MouseLook ml1, ml2;
    public Options optionscript;
    public CarControlScript ccs;
    //Audio..
    AudioSource audios;
    public AudioClip startenginesound, stopenginesound,duranaracses, gasclip, brakeclip;
    //Material-Texture-Pictures
    public Material farbackstop;
    public Texture stopontexture, stopofftexture;
    //Others
    public float drivingsoundval;
    public float currentSpeed, TopSpeed;
    [SerializeField]
    private float[] gearRatioValues;
    public float currentGear;
    public float speedval;
    public bool handbrake;
    public float minGear;
    public float h, v;
    public string carname;
    public float maxGear;
    public int i;
    public float speed = 0.1F;
    private void Awake()
    {
        findvoid();
        baggagestate = false;
        fldoorstate = false;
        frdoorstate = false;
        rldoorstate = false;
        rrdoorstate = false;
                bonnetstate = false;
        estime = esmaxtime;
        enginestate = false;
               zamanin = maxinzaman;
              zamanout = maxoutzaman;
               farlightstate = false;
        farlight.SetActive(false);
              keyuppitch = false;
          }


    public void FixedUpdate()
    {
        ccs.drivestate = drivestate;
        optionscript.carname = carname;
        carpartsvoid();
        distance = Vector3.Distance(karakter.position, carmass.position);
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


        if (distance > 4 || inis || binis)
        {
            informationtextobj.SetActive(false);
        }
        if (distance <= 4 && !drivestate)
        {
            if (!inis && !binis)
            {
                informationtextobj.SetActive(true);
            }
            if (Input.GetKey(KeyCode.F))
            {
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
            karakter.position = cardoor1koordinat.position + new Vector3(0, 1, 0);
            fldoor.transform.localEulerAngles = new Vector3(0, -45, 0);

            if (zamanout > 0)
            {

                zamanout -= Time.deltaTime;
                karakter.eulerAngles = new Vector3(0, 244.8f, 0);

            }
            else if (zamanout <= 0)
            {
                fldoor.transform.localEulerAngles = new Vector3(0, 0, 0);
                rch.carenterexit = false;
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
            fldoor.transform.localEulerAngles = new Vector3(0, 45, 0);
            if (zamanin <= 0.5f)
            {
                fldoor.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            if (zamanin > 0)
            {
                zamanin -= Time.deltaTime;

                rms.move = false;

            }

            else if (zamanin <= 0)
            {
                enginestate = true;
                rms.move = true;
                remy.SetActive(false);
                binis = false;
                estime = esmaxtime;
                enginestate = true;
                drivestate = true;
                remydriving.SetActive(true);
                zamanin = maxinzaman;

               fldoor.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
        if (drivestate)
        {
			healthbar.SetActive (false);
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
                bonnet.transform.localEulerAngles = new Vector3(0, 0, 0);

            }
            if (fldoorstate)
            {
                fldoor.transform.localEulerAngles = new Vector3(0, 45, 0);
            }
            else
            {
                fldoor.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            if (frdoorstate)
            {
                frdoor.transform.eulerAngles = new Vector3(0, -45, 0);
            }
            else
            {
                frdoor.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            if (rldoorstate)
            {
                rldoor.transform.localEulerAngles = new Vector3(0, 45, 0);
            }
            else
            {
                rldoor.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            if (rrdoorstate)
            {
                rrdoor.transform.eulerAngles = new Vector3(0, -45, 0);
            }
            else
            {
                rrdoor.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            if (Time.timeScale == 1)
            {
                currentSpeed = ccs.currentSpeed;
                    TopSpeed = ccs.TopSpeed;

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
              
    				                if (Input.GetKey(KeyCode.G))
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
                h = Input.GetAxis("Horizontal");
                v = -Input.GetAxis("Vertical");
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
					                                                 }
                else if (!Input.GetKey(KeyCode.S) && !handbrake)
                {

                                brk = 0;
                }

                    }
        else
        {
            healthbar.SetActive(true);
            crosshair.SetActive(true);
            personcamera.SetActive(true);
            carcamera.SetActive(false);
                   }
	          }
    private void findvoid()
    {
        cameratransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        karakter = GameObject.FindGameObjectWithTag("Player").transform;
        ccs = GetComponent<CarControlScript>();
        audios = GetComponent<AudioSource>();
        optionscript = GameObject.Find("UIManager").GetComponent<Options>();
        remydriving = GameObject.Find("remydriving");
              carcamera = GameObject.FindGameObjectWithTag("CarCamera");
        personcamera = GameObject.FindGameObjectWithTag("MainCamera");
        crosshair = GameObject.FindGameObjectWithTag("crosshairdef");
        informationtextobj = GameObject.Find("informationtext");
        healthbar = GameObject.Find("health");
        cardoor1koordinat = GameObject.Find("binisposition").transform;
        carmass = GameObject.Find("carmass").transform;
        rms = GameObject.FindGameObjectWithTag("Player").GetComponent<RemyMoveSc>();
        rch = GameObject.Find("Guncharin").GetComponent<raycasthit>();
        ml1 = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>();
        ml2 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();
        remy = GameObject.FindGameObjectWithTag("Player");
        farlight = GameObject.Find("erexasfar");
        carcamera.SetActive(false);
        remydriving.SetActive(false);

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