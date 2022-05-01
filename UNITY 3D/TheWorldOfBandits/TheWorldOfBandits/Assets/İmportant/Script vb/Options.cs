using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Options : MonoBehaviour {
    public string buttonstr,yesnostatetxt;
    public bool pausestate,strsave;
    public RawImage wasdkeysbtn, arrowkeysbtn;
    public Material selectedkeystilimg;
    public GameObject carpartspanel;
    public Toggle baggage,bonnet,frdoor,fldoor,rrdoor,rldoor;
      public GameObject yesnopnl, anapnl,creditpnl,settingspnl,saveinf,crosshair,göstergeler,inftext;
    public AudioSource asource;
    public bool drivestate,carparts;
    public Text yesnotext;
    public string carname;
    public carUserKontrol cucscript;
         public RemyMoveSc rms;
     
    void Start () {
        findvoid();
        pausestate = false;
           Cursor.visible = false;
        crosshair.SetActive(true);
        carpartspanel.SetActive(false);
        göstergeler.SetActive(true);
        yesnopnl.SetActive(false);
                carparts = false;
        anapnl.SetActive(false);
        creditpnl.SetActive(false);
        settingspnl.SetActive(false);
        saveinf.SetActive(false);
            if (PlayerPrefs.GetInt("movekeystate")==1)
        {
            rms.tuswasd = true;
            rms.tusarrow = false;
            wasdkeysbtn.material = selectedkeystilimg;
            arrowkeysbtn.material = null;
            
        }
      else  if (PlayerPrefs.GetInt("movekeystate") == 2)
        {
            rms.tuswasd = false;
            rms.tusarrow = true;
            arrowkeysbtn.material = selectedkeystilimg;
            wasdkeysbtn.material = null;
        }
     
    }
	
	// Update is called once per frame
	void Update () {
           if (carname != "")
        {
            cucscript = GameObject.Find(carname).GetComponent<carUserKontrol>();
                     drivestate = cucscript.drivestate;
        }
          if (drivestate)
        {
            if (Time.timeScale == 1)
            {

                cucscript.baggagestate = baggage.isOn;
                cucscript.bonnetstate = bonnet.isOn;
                cucscript.fldoorstate = fldoor.isOn;
                cucscript.rrdoorstate = rrdoor.isOn;
                cucscript.rldoorstate = rldoor.isOn;
                cucscript.frdoorstate=frdoor.isOn;
                if (Input.GetKeyDown(KeyCode.I))
                {
                    if (carparts)
                    {
                        StartCoroutine(openparts(false));
                        Cursor.visible = false;
                    }
                    else
                    {
                        Cursor.visible = true;
                        StartCoroutine(openparts(true));
                    }
                }
                }
        }
        if (strsave)
        {
            if (PlayerPrefs.GetInt("movekeystate") == 1)
            {
                rms.tuswasd = true;
                rms.tusarrow = false;
                wasdkeysbtn.material = selectedkeystilimg;
                arrowkeysbtn.material = null;

            }
            else if (PlayerPrefs.GetInt("movekeystate") == 2)
            {
                rms.tuswasd = false;
                rms.tusarrow = true;
                arrowkeysbtn.material = selectedkeystilimg;
                wasdkeysbtn.material = null;
            }
            strsave = false;
        }
        if (carparts)
        {
          
        }
        else if (!carparts)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pausestate)
                {
                    göstergeler.SetActive(true);
                    Cursor.visible = false;
                    pausestate = false;
                    Time.timeScale = 1;
                    anapnl.SetActive(false);
                    yesnopnl.SetActive(false);
                    creditpnl.SetActive(false);
                    settingspnl.SetActive(false);
                    if (drivestate)
                    {
                        asource = GameObject.Find(carname).GetComponent<AudioSource>();
                        asource.mute = false;
                    }
                    crosshair.SetActive(true);

                }
                else
                {
                    if (drivestate)
                    {
                        asource = GameObject.Find(carname).GetComponent<AudioSource>();
                        asource.mute = true;
                    }
                    inftext.SetActive(false);
                    göstergeler.SetActive(false);
                    crosshair.SetActive(false);
                    Cursor.visible = true;
                    pausestate = true;
                    anapnl.SetActive(true);
                    yesnopnl.SetActive(false);
                    creditpnl.SetActive(false);
                    Time.timeScale = 0;
                }
            }
        }
        if (yesnostatetxt == "no")
        {
            yesnostatetxt = "";
            anapnl.SetActive(true);
            yesnopnl.SetActive(false);
            creditpnl.SetActive(false);
            settingspnl.SetActive(false);
           
        }
              if (buttonstr == "yesnomainmenu")
            {
                         yesnotext.text = "GO MAIN MENU?";
           
            if (yesnostatetxt == "yes")
            {
                Application.LoadLevel("MainMenu");
            }
                   }
            else if (buttonstr == "yesnoexit")
            {
                            yesnotext.text = "EXIT GAME?";
            if (yesnostatetxt == "yes")
            {
                Application.Quit();
            }
                  }
      
    }
   
    public void click(string btnname)
    {
        if(btnname == "mainmenubtn")
        {
            buttonstr = "yesnomainmenu";
            yesnopnl.SetActive(true);
            anapnl.SetActive(false);
                     
        }
        else if(btnname == "resumebtn")
        {
            pausestate = false;
            Time.timeScale = 1;
            Cursor.visible = false;
            anapnl.SetActive(false);
            yesnopnl.SetActive(false);
            creditpnl.SetActive(false);
            settingspnl.SetActive(false);
            crosshair.SetActive(true);
                        göstergeler.SetActive(true);

        }
        else if(btnname == "wasdkeyclicked")
        {
            PlayerPrefs.SetInt("movekeystate",1);
            wasdkeysbtn.material = selectedkeystilimg;
            arrowkeysbtn.material = null;

        }
        else if(btnname == "arrowkeyclicked")
        {
            PlayerPrefs.SetInt("movekeystate", 2);
            wasdkeysbtn.material = null;
            arrowkeysbtn.material = selectedkeystilimg;

        }
        else if(btnname == "creditbtn")
        {
                     creditpnl.SetActive(true);
            anapnl.SetActive(false);
        }
        else if(btnname == "exitbtn")
        {
            buttonstr = "yesnoexit";
            yesnopnl.SetActive(true);
            anapnl.SetActive(false);
                      
        }
        else if(btnname == "backanapnl")
        {
            anapnl.SetActive(true);
            creditpnl.SetActive(false);
            print("backanapnl ");
        }
        else if(btnname == "yesbtn")
        {
            yesnostatetxt = "yes";
        }
        else if(btnname == "nobtn")
        {
            yesnostatetxt = "no";
        }
        else if(btnname == "settingspnl")
        {
            anapnl.SetActive(false);
            settingspnl.SetActive(true);
        }
        else if(btnname == "mksave")
        {
            strsave = true;
            StartCoroutine(mksavesay());
        }
                 }
    IEnumerator openparts(bool state)
    {
        yield return new WaitForSeconds(0.5f);
        carparts = state;
        if (carparts)
        {
            carpartspanel.SetActive(true);
        }
        else
        {
            carpartspanel.SetActive(false);
        }

    }
    IEnumerator mksavesay()
    {
        saveinf.SetActive(true);
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.5f);
        saveinf.SetActive(false);
        pausestate = false;
              Cursor.visible = false;
        anapnl.SetActive(false);
        yesnopnl.SetActive(false);
        creditpnl.SetActive(false);
        crosshair.SetActive(true);
        settingspnl.SetActive(false);
        göstergeler.SetActive(true);
           }
    void findvoid()
    {
        arrowkeysbtn = GameObject.Find("arrowkeys").GetComponent<RawImage>();
        wasdkeysbtn = GameObject.Find("wasdkeys").GetComponent<RawImage>();
        carpartspanel = GameObject.Find("carpartspanel");
        baggage = GameObject.Find("baggage").GetComponent<Toggle>();
        bonnet = GameObject.Find("bonnet").GetComponent<Toggle>();
        frdoor = GameObject.Find("frdoor").GetComponent<Toggle>();
        fldoor = GameObject.Find("fldoor").GetComponent<Toggle>();
        rldoor = GameObject.Find("rldoor").GetComponent<Toggle>();
        rrdoor = GameObject.Find("rrdoor").GetComponent<Toggle>();
        yesnopnl = GameObject.Find("YesNoPnl");
        anapnl = GameObject.Find("AnaPanel");
        creditpnl = GameObject.Find("Creditpnl");
        settingspnl = GameObject.Find("Settingspnl");
        saveinf = GameObject.Find("savedinf");
        crosshair = GameObject.Find("Crosshair");
        göstergeler = GameObject.Find("Göstergeler");
        inftext = GameObject.Find("informationtext");
                       yesnotext = GameObject.Find("YesNoLabel").GetComponent<Text>();
              rms = GameObject.FindGameObjectWithTag("Player").GetComponent<RemyMoveSc>();
    }
}

