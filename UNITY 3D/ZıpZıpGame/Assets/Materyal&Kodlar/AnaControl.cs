using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnaControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float speed, rspeed, artis, zmn, maxzmn;
    public float moveHorizontal, moveVertical;
    public Transform cam;
    public GameObject movekup, movekure,pausebtn,timepnl;
    public Material color, charactertexture;
   public SeyvScript ss;
    public Rigidbody kurerb;
    public bool jeal, fbuton, bbuton, rbuton, lbuton,strt, jmp = false;
    public GameObject kup;
    public Text startsayim;
    public GameObject startsayimpnl;
    public bool hrktlock;
    public UIManager ui;
    public GameObject kure;
    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "FButton")
        {
            fbuton = true;
        }
        if (gameObject.name == "JButton")
        {
                                  StartCoroutine(sayy());
           
        }
        else if (gameObject.name == "BButton")
        {
            bbuton = true;
        }
        else if (gameObject.name == "RButton")
        {
            rbuton = true;
        }
        else if (gameObject.name == "LButton")
        {
            lbuton = true;

        }
    }
    public void OnPointerUp(PointerEventData data)
    {
        if (gameObject.name == "FButton")
        {
            fbuton = false;
        }
        else if (gameObject.name == "BButton")
        {
            bbuton = false;
        }
        else if (gameObject.name == "RButton")
        {
            rbuton = false;
        }
        else if (gameObject.name == "LButton")
        {
            lbuton = false;
        }

    }
    //START-UPDATE
    void Start()
    {
        ui = GameObject.Find("ButonKontrol").GetComponent<UIManager>();
                   pausebtn.SetActive(false);
        maxzmn = 3;
        zmn = maxzmn;
       
        strt = true;
        speed = 2;
        jeal = true;
        hrktlock = true;
        rspeed = 10;
        timepnl.SetActive(false);
        ss = GameObject.Find("SaveManager").GetComponent<SeyvScript>();
        startsayimpnl = GameObject.Find("startsayimpnl");
        startsayim = GameObject.Find("sayim").GetComponent<Text>();
        saveload();
        startsayimpnl.SetActive(true);
       
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            moveHorizontal = Input.touches[0].deltaPosition.x;
            moveVertical = Input.touches[0].deltaPosition.y;
        }
      
            if (strt)
        {
            if (zmn > 0)
            {
                zmn -= Time.deltaTime;
                            }
            else if(zmn <=0)
            {
                zmn = maxzmn;
                strt = false;
                hrktlock = false;
                startsayimpnl.SetActive(false);
                pausebtn.SetActive(true);
                timepnl.SetActive(true);
                
              
                          }
            startsayim.text = "" + zmn.ToString("0");
        }
         if(!hrktlock)
        {
            baslangic();
        }

    }
    //VOİDLER
      void baslangic()
      {

       
        if (artis >= 0.11f)
          {

              jmp = false;
            jeal= false;
          }
      
        if (jmp)
          {

              artis += Time.deltaTime;
              kup.transform.position += new Vector3(0, artis, 0);
              kure.transform.position += new Vector3(0, artis, 0);
              movekup.transform.position += new Vector3(0, artis, 0);
              movekure.transform.position += new Vector3(0, artis, 0);
          }
          if (!jmp)
          {
              if (artis <= 0)
              {
                  artis = 0;
                  kup.transform.position += new Vector3(0, artis, 0);
                  movekup.transform.position += new Vector3(0, artis, 0);
                  kure.transform.position += new Vector3(0, artis, 0);
                  movekure.transform.position += new Vector3(0, artis, 0);
              }
              if (artis > 0)
              {

                  artis -= Time.deltaTime;
                  kup.transform.position += new Vector3(0, artis, 0);
                  movekup.transform.position += new Vector3(0, artis, 0);
                  kure.transform.position += new Vector3(0, artis, 0);
                  movekure.transform.position += new Vector3(0, artis, 0);
              }

          }
          buttons();
          if (ss.charactercodesv == 0)
          {
            ui.typecharacter = "kup";
                   movekup.transform.position = kup.transform.position;
          }
          else if (ss.charactercodesv == 1)
          {
            ui.typecharacter = "kure";
            movekure.transform.position = kure.transform.position;
          }


      }
    void saveload()
    {
        if (ss.charactercodesv == 0)
        {
            kup.SetActive(true);
            kure.SetActive(false);
        }
        else if (ss.charactercodesv == 1)
        {
            kup.SetActive(false);
            kure.SetActive(true);
        }
        if (ss.state == 0)
        {
            color.color = ss.saveclr;
            color.SetFloat("_Metallic", ss.savemetalicsv);
            color.SetFloat("_Glossiness", ss.savesmoothsv);
            movekup.GetComponent<Renderer>().material = color;
            movekure.GetComponent<Renderer>().material = color;
        }
        else if (ss.state == 1)
        {
            movekup.GetComponent<Renderer>().material.mainTexture = ss.texture;
            movekure.GetComponent<Renderer>().material.mainTexture = ss.texture;
        }
    }
    void buttons()
    {
        if (moveHorizontal > 0 || Input.GetKey(KeyCode.D))
        {
            if (ss.charactercodesv == 0)
            {

                kup.transform.Rotate(0, 5 * rspeed * Time.deltaTime, 0);
            }
            else if (ss.charactercodesv == 1)
            {

                kure.transform.Rotate(0, 5 * rspeed * Time.deltaTime, 0);
            }
        }
        if (moveVertical < 0 || Input.GetKey(KeyCode.S))
        {
            if (ss.charactercodesv == 0)
            {
                movekup.transform.Rotate(new Vector3(-3, 0, 0));
                kup.transform.Translate(0, 0, -1 * speed * Time.deltaTime);
            }
            else if (ss.charactercodesv == 1)
            {
                movekure.transform.Rotate(new Vector3(-3, 0, 0));
                kure.transform.Translate(0, 0, -1 * speed * Time.deltaTime);
            }
        }
        if (moveVertical > 0 || Input.GetKey(KeyCode.W))
        {
            if (ss.charactercodesv == 0)
            {
                kup.transform.Translate(0, 0, 1 * speed * Time.deltaTime);
                movekup.transform.Rotate(new Vector3(3, 0, 0));
            }
            else if (ss.charactercodesv == 1)
            {
                kure.transform.Translate(0, 0, 1 * speed * Time.deltaTime);
                movekure.transform.Rotate(new Vector3(3, 0, 0));
            }
        }
        if (moveHorizontal < 0 || Input.GetKey(KeyCode.A))
        {
            if (ss.charactercodesv == 0)
            {

                kup.transform.Rotate(0, -5 * rspeed * Time.deltaTime, 0);
            }
            else if (ss.charactercodesv == 1)
            {

                kure.transform.Rotate(0, -5 * rspeed * Time.deltaTime, 0);
            }
        }
     
    }
    IEnumerator sayy()
    {
        if (jeal)
        {
            jmp = true;
        }
        jeal = false;
        yield return new WaitForSeconds(0.8f);
        jeal = true;
    }
}
