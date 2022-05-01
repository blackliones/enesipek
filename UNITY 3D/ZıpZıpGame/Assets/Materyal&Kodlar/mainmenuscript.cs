using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class mainmenuscript : MonoBehaviour
{
    //Materyaller&Texture
    public Texture savetexture;
    public Material color,Texture1,KureTexture1,KureTexture2,KureTexture3,KupTexture1,KupTexture2,KupTexture3;
    //Paneller
    public GameObject panel,creating,creatingpanel,yesnopanel,SavedPanel;
    //Butonlar
    public GameObject colorcheck,texturecheck,play,exit,create,yes,no,savebtn;
    public Button playbtn;
       //Sliderler
    public Slider smoothness,metalic,RColor,GColor,BColor,AColor;
    //Textler
    public Text paneltext, ColorText, TextureText, label;
    //Floatlar
    public float panelkontrol,charactercode;
    //Karakterler
    public GameObject kup,kure,kupmodel,kuremodel;
  
    //Diğer
    public Color clr = new Color(0.3F, 0.4F, 0.6F);
    public bool ok, state, msc, textureon, coloron,save;
    public string tbname;
    public SeyvScript ss;
    void Start()
    {
        SavedPanel.SetActive(false);
        coloron = true;
               creatingpanel.SetActive(false);
        kup.SetActive(false);
        kure.SetActive(false);
         panelkontrol = 0;
        ok = false;
        creating.SetActive(false);
        yesnopanel.SetActive(false);
        ss = GameObject.Find("SaveManager").GetComponent<SeyvScript>();
        ss.charactercodesv = 1;
    
       }

    void Update()//SAVELER, SMOOTH,METALLİC
    {
        if (state)
        {
               if (!textureon&&!coloron)
            {
                savebtn.GetComponent<Button>().interactable = false;
            }
            else
            {
                savebtn.GetComponent<Button>().interactable = true;
            }
                      if (textureon)
            {
                if (save)
                {
                    ss.saveclr = Color.white;
                    ss.savemetalicsv = 0;
                    ss.savesmoothsv = 0;
                    ss.state = 1;
                    saveitems();
                    ss.charactercodesv = charactercode;
                    ss.texture = savetexture;
                    save = false;
                    }
                
                if (tbname == "t1")
                {//Bu texture 2 si içinde uygun.
                        kup.GetComponent<Renderer>().material = Texture1;
                        kure.GetComponent<Renderer>().material = Texture1;
                                   }
                if (tbname == "t2")
                {
                 kup.GetComponent<Renderer>().material = KupTexture1;                                       
                kure.GetComponent<Renderer>().material = KureTexture1;
                                    }
                if (tbname == "t3")
                {
                    kup.GetComponent<Renderer>().material = KupTexture2;
                    kure.GetComponent<Renderer>().material = KureTexture2;
                }
                if (tbname == "t4")
                {
                    kup.GetComponent<Renderer>().material = KupTexture3;
                    kure.GetComponent<Renderer>().material = KureTexture3;
                }
                         }
            if (coloron)
            {
                if (save)
                {
                    ss.state = 0;
                    ss.savemetalicsv = metalic.value;
                    ss.savesmoothsv = smoothness.value;
                    ss.charactercodesv = charactercode;
                    ss.saveclr = clr;
                                       save = false;
                }
                clr = new Color(RColor.value,GColor.value,BColor.value,0);
                color.color = clr;
                color.SetFloat("_Metallic", metalic.value); 
                color.SetFloat("_Glossiness", smoothness.value);
                kup.GetComponent<Renderer>().material = color;
                kure.GetComponent<Renderer>().material = color;
            }
            if (charactercode == 0)
            {
                kupmodel.GetComponent<RawImage>().color = Color.cyan;
                kuremodel.GetComponent<RawImage>().color = Color.white;
                kup.SetActive(true);
                kure.SetActive(false);
            }
            if (charactercode == 1)
            {
                kupmodel.GetComponent<RawImage>().color = Color.white;
                kuremodel.GetComponent<RawImage>().color = Color.cyan;
                kure.SetActive(true);
                kup.SetActive(false);
            }
        }
        if (panelkontrol != 2 && panelkontrol != 1)
        {
            label.text = "ZIPZIP GAME";
        }
        if (panelkontrol == 1)
        {
            panel.SetActive(false);
            yesnopanel.SetActive(true);
            label.text = "";
            paneltext.text = "Exit Game?";
            if (ok)
            {
                Application.Quit();
            }
        }
        if (panelkontrol == 2)
        {
            label.text = "CREATING";
            panel.SetActive(false);
            creatingpanel.SetActive(true);
            creating.SetActive(true);
        }
    }
    public void click(string name)
    {
        if (name == "Play")
        {
            Application.LoadLevel("zıpzıpgame");
        }
        else if(name == "Save")
        {
            save = true;
            StartCoroutine(apply());
              }
        else if(name == "kup")
        {
            charactercode = 0;
        }
        else if (name == "kure")
        {
            charactercode = 1;
        }
        else if (name == "Create")
        {
            panelkontrol = 2;
          
            ok = false;
            coloron = true;
            state = true;

        }
        else if (name == "Exit")
        {
     
            panelkontrol = 1;
        }
        else if (name == "yes")
        {
            ok = true;
        }
        else if (name == "no")
        {
            panel.SetActive(true);
            ok = false;
            panelkontrol = 0;
            creating.SetActive(false);
            creatingpanel.SetActive(false);
            yesnopanel.SetActive(false);
            state = false;
        }
    }
    public void check(string on)
    {
        if (on == "coloron"){
        
             if (!coloron)
            {
                TextureText.color = Color.white;
                ColorText.color = Color.red;
                colorcheck.GetComponent<Image>().color = Color.white;
                texturecheck.GetComponent<Image>().color = Color.green;
                coloron = true;
                textureon = false;
            }
          
        }
       else if (on == "textureon")
        {
       
            if (!textureon)
            {
                TextureText.color = Color.red;
                ColorText.color = Color.white;
                colorcheck.GetComponent<Image>().color = Color.green;
                texturecheck.GetComponent<Image>().color = Color.white;
                textureon = true;
                coloron = false;
            }
          
        }
        if (on == "t1")
        {
            tbname = "t1";
        }
        else if (on == "t2")
        {
            tbname = "t2";
        }
        else if (on == "t3")
        {
            tbname = "t3";
        }
        else if (on == "t4")
        {
            tbname = "t4";
        }
    }
    void saveitems() {
        if (tbname == "t1")
        {
                savetexture = Texture1.mainTexture;
        }
        if (tbname == "t2")
        {
            if (charactercode == 0)
            {
                savetexture = KupTexture1.mainTexture;

            }
            if (charactercode == 1)
            {
                savetexture = KureTexture1.mainTexture;

            }
        }
        if (tbname == "t3")
        {
            if (charactercode == 0)
            {
                savetexture = KupTexture2.mainTexture;

            }
            if (charactercode == 1)
            {
                savetexture = KureTexture2.mainTexture;

            }
        }
        if (tbname == "t4")
        {
            if (charactercode == 0)
            {
                savetexture = KupTexture3.mainTexture;

            }
            if (charactercode == 1)
            {
                savetexture = KureTexture3.mainTexture;

            }
        }
        }
    IEnumerator apply()
    {
        SavedPanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SavedPanel.SetActive(false);
    }
    }