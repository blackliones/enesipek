using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
	public GameObject pausePanel;
	public GameObject CreditPanel;
	public GameObject YesNoPanel;
    public GameObject buttons;
    public Text timetext;
    public Text pointtxt;
    public Text totalpointtxt;
    public float timeval,point;
    public int dk;
    public KarakterScript ks;
    public bool timebool;
	public Text paneltext;
    public scoresave scores;
    public Text scoretime,bestscoretime;
    public GameObject yes;
	public GameObject no;
    public GameObject saveg;
	public int pnlcontrol;
    public string typecharacter;
	public bool ok = false;

    void Start () {
                   timeval = 0;
        dk = 0;
  
		CreditPanel.SetActive (false);
        		YesNoPanel.SetActive (false);
		pnlcontrol = 0;
        buttons.SetActive(true);
     
        saveg = GameObject.Find("SaveManager");
        StartCoroutine(timestrt());
        scores = GameObject.Find("ScoreSaved").GetComponent<scoresave>();
    }

    void Update() {
        if (typecharacter == "kup")
        {
            ks = GameObject.Find("Karakter1").GetComponentInChildren<KarakterScript>();
        }
    else if (typecharacter == "kure")
        {
            ks = GameObject.Find("Karakter2").GetComponentInChildren<KarakterScript>();
        }
        if (ks.dead)
        {
            scoretime.text = "Time: " + dk.ToString("f0") + ":" + timeval.ToString("f0");
            bestscoretime.text = "Best Time: " + scores.bestscoredk.ToString("f0") + ":" + scores.bestscoresn.ToString("f0");
            pointtxt.text = "Point: " + point;
            totalpointtxt.text = "Total Point: " + scores.totalpoint;
        }
        if (ks.colls)
        {
            scoretime.text = "Time: " + dk.ToString("f0") + ":" + timeval.ToString("f0");
            totalpointtxt.text = "Total Point: " + scores.totalpoint;
            pointtxt.text = "Point: " + point;
            if (dk < scores.bestscoredk)
            {
                scores.bestscoredk = dk;
                scores.bestscoresn = timeval;
                bestscoretime.text = "Best Time: " + scores.bestscoredk.ToString("f0") + ":" + scores.bestscoresn.ToString("f0");
            }
            else if (scores.bestscoredk < dk)
            {
                bestscoretime.text = "Best Time: " + scores.bestscoredk.ToString("f0") + ":" + scores.bestscoresn.ToString("f0");

            }
            if (scores.bestscoredk <= dk && timeval < scores.bestscoresn)
            {
                scores.bestscoredk = dk;
                scores.bestscoresn = timeval;
                bestscoretime.text = "Best Time: " + scores.bestscoredk.ToString("f0") + ":" + scores.bestscoresn.ToString("f0");
            }
            else if (scores.bestscoredk >= dk && timeval > scores.bestscoresn)
            {
                bestscoretime.text = "Best Time: " + scores.bestscoredk.ToString("f0") + ":" + scores.bestscoresn.ToString("f0");

            }

        }
        if (timebool&&!ks.colls&&!ks.dead)
        {
            if (timeval > 59)
            {
                timeval = 0;
                dk += 1;
            }
            timeval += Time.deltaTime;
            timetext.text = dk+" : " + timeval.ToString("f0"); ;
        }
		if (pnlcontrol == 3) {
			paneltext.text = "Quit Game?";
			if (ok) {
				Application.Quit ();
			}

		}
		if (pnlcontrol == 2) {
			paneltext.text = "Restart Game?";
			if (ok) {
				Application.LoadLevel ("zıpzıpgame");
				Time.timeScale = 1;
			}
		}
		if (pnlcontrol == 1){
			paneltext.text = "Go Main Menu?";
			if (ok) {
                Destroy(saveg);
             
                 Application.LoadLevel ("Mainmenu");
				Time.timeScale = 1;
			}
		}
	}
    public void menü(string mainpanel) {
        if (mainpanel == "mainpanel")
        {
            if (pausePanel.activeSelf == true)
            {
                buttons.SetActive(true);
                pausePanel.SetActive(false);
                YesNoPanel.SetActive(false);
                pnlcontrol = 0;
                if (!timebool) {
                    timebool = true;
                }
                Time.timeScale = 1;
                ok = false;
            }
            else
            {
                if (timebool)
                {
                    timebool = false;
                }
                pausePanel.SetActive(true);
                buttons.SetActive(false);  
                pnlcontrol = 0;
                Time.timeScale = 0;
                ok = false;
                CreditPanel.SetActive(false);
                YesNoPanel.SetActive(false);
            }
        }
    }
	public void PanelAc(string paneladi){
		CreditPanel.SetActive (false);
		YesNoPanel.SetActive (false);
        if(paneladi == "credit") {
			CreditPanel.SetActive (true);
			pausePanel.SetActive (false);
		}
        else if (paneladi == "facebook")
        {
           Application.OpenURL("www.facebook.com/zipzipfun");
        }
        else if (paneladi == "paused") {
			pausePanel.SetActive (true);
			ok = false;
			pnlcontrol = 0;
		} else if (paneladi == "closepaused") {
            if (!timebool) {
                timebool = true;
            }
            buttons.SetActive(true);
            pausePanel.SetActive(false);
            YesNoPanel.SetActive(false);
            pnlcontrol = 0;
            Time.timeScale = 1;
            ok = false;
		}
			else if (paneladi == "YES"){
			ok = true;
			}
		else if (paneladi == "Mainmenübtn")
		{
			pnlcontrol = 1;
			pausePanel.SetActive (false);
			YesNoPanel.SetActive (true);
		}
		else if (paneladi == "Restartbtn"){
			pnlcontrol = 2;
			pausePanel.SetActive (false);
			YesNoPanel.SetActive (true);
		}
		else if (paneladi == "Quitbtn"){
			pnlcontrol = 3;
			pausePanel.SetActive (false);
			YesNoPanel .SetActive(true);
		}
        else if(paneladi == "directmainmenu")
        {
            Destroy(saveg);
                      Application.LoadLevel("Mainmenu");
            Time.timeScale = 1;
        }
	}
    IEnumerator timestrt() {
        yield return new WaitForSeconds(3);
        timebool = true;
    }
}