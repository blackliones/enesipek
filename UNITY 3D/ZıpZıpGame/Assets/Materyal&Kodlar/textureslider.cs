using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class textureslider : MonoBehaviour {
    public bool touch;
    public float panelcode;
    public GameObject panel1;
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;
    public GameObject panel2;
 /*   void OnTouchDown()
        {
            touch = true;
        }
            void OnTouchUp()
        {
            touch = false;
        }*/
    void OnMouseDown() {
        touch = true;
       
         }
    void OnMouseUp() {
        touch = false; 
    }

	void Start () {
        panelcode = 0;
	}
	
	void Update () {
        if (touch)
        {
            if (Input.GetAxis("Mouse X")<=-0.05f||Input.GetAxis("Mouse X")>= 0.05f)
            {
                panel1.GetComponent<Image>().color = new Color(0.1f,0.1f,0.1f);
                panel2.GetComponent<Image>().color = new Color(0.1f, 0.1f, 0.1f);
            }
        }
        if (!touch)
        {
            panel1.GetComponent<Image>().color = Color.black;
            panel2.GetComponent<Image>().color = Color.black;
        }
    /*     if (panelcode == 0)//MOBİLE
         {
             panel1.SetActive(true);
             panel2.SetActive(false);
             if (touch && Input.GetTouch(0).deltaPosition.x <= -0.2f)
         {
             panelcode = 1;
         }
         }
         if (panelcode == 1)
         {
               panel1.SetActive(false);
            panel2.SetActive(true);
              if (touch && Input.GetTouch(0).deltaPosition.x >= 0.2f)
         {
             panelcode = 0;
         }
         }*/
        if (panelcode == 0)//PC
        {
            panel1.SetActive(true);
            panel2.SetActive(false);
            if (touch && Input.GetAxis("Mouse X") <= -0.2f)
            {
                panelcode = 1;
            }
        }
        if(panelcode == 1)
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
            if (touch && Input.GetAxis("Mouse X") >=0.2f)
            {  
                panelcode = 0;
            }
      
        }
        
    }
}
