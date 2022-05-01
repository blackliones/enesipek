using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class KarakterScript : MonoBehaviour
{
    public GameObject deadpnl;
    public Text gameovertxt;
    public bool colls;
    public bool dead;
    public GameObject dönder;
    public UIManager ui;
   public AnaControl ac;
    void Start()
    {
        ui = GameObject.Find("ButonKontrol").GetComponent<UIManager>();
        colls = false;
        dönder = GameObject.Find("dönder1");
        dönder.transform.Rotate(new Vector3(0, 0, 0));
        dönder = GameObject.Find("dönder2");
        dönder.transform.Rotate(new Vector3(0, 0, 0));
        Time.timeScale = 1;
        dead = false;
        ac = GameObject.Find("JButton").GetComponent<AnaControl>();
   
    }
    void OnCollisionEnter(Collision col)
    {
  
        if (col.gameObject.tag == "Finish")
        {
            Debug.Log("FİNİSH");
            colls = true;
            deadpnl.SetActive(true);
            gameovertxt.text = "Finish SpaceMap";
            gameovertxt.color = Color.green;
            Time.timeScale = 0;
        }
        else if (col.gameObject.tag == "90derece")
        {
  
          if(col.gameObject.name == "dönder1")
            {
                dönder = GameObject.Find("dönder1");
                StartCoroutine(dontime());
            }
           else if (col.gameObject.name == "dönder2")
            {
                dönder = GameObject.Find("dönder2");
                StartCoroutine(dontime());
            }
        }
        else if (col.gameObject.tag == "Dead")
        {
            dead = true;
            deadpnl.SetActive(true);
                      gameovertxt.text = "GameOver";
            gameovertxt.color = Color.red;
            Time.timeScale = 0;
        }
    }
    void Update()
    {
      
    }
    IEnumerator dontime() {
        yield return new WaitForSeconds(2);
        dönder.transform.Rotate(new Vector3(0, 90, 0));
    }
}