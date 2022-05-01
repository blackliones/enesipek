using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mainmenuUI : MonoBehaviour
{
    public GameObject loadingPanel, anaPanel;
    public Sprite photo1, photo2, photo3,photo4,photo5,photo6;
          public int maxphotoval, photoval, minphotoval;
    public float loadedVal,loadingSpeed;
    public float changeTime,changeMaxtime;
    public Text loadedValText;
    public bool loadingbool,changebool;
    public RawImage photosri;
    void Start()
    {
        loadedVal = 0;
        loadedValText = GameObject.Find("loadedValue").GetComponent<Text>();
        anaPanel = GameObject.Find("AnaPanel");
        loadingPanel = GameObject.Find("LoadingPanel");
        photosri = GameObject.Find("photos").GetComponent<RawImage>();
               loadingbool = false;
        anaPanel.SetActive(true);
        loadingPanel.SetActive(false);
        photoval = 1;
        changeTime = changeMaxtime;
        changebool = false;
        loadedValText.enabled = false;  
              Time.timeScale = 1;
            }

    void Update()
            {
        if (loadingbool)
        {
            loadedValText.enabled = true;
            loadedVal +=Time.deltaTime*loadingSpeed;
       if(loadedVal >=98)
            {
                Application.LoadLevel("InGame");
                loadedVal = 100;
                             loadingbool = false;
                changebool = false;
                StopCoroutine(say());
            }
            loadedValText.text = "" + loadedVal.ToString("f0");
                        if (changebool)
            {
                if (changeTime > 0)
                {
                                       changeTime -= Time.deltaTime;
                }
                else if (changeTime <= 0)
                {
                    if (photoval < maxphotoval)
                        photoval += 1;
                    else if (photoval == maxphotoval)
                        photoval = 1;
                    changebool = false;
                    changeTime = changeMaxtime;
                    StartCoroutine(say());
                }
            }
        }
        if (photoval == 1)
        {
            photosri.texture = photo1.texture;
                    }
        else if (photoval == 2)
        {
            photosri.texture = photo2.texture;
        }
        else if (photoval == 3)
        {
            photosri.texture = photo3.texture;
        }
        else if(photoval == 4)
        {
            photosri.texture = photo4.texture;
        }
        else if (photoval == 5)
        {
            photosri.texture = photo5.texture;
        }
        else if (photoval == 6)
        {
            photosri.texture = photo6.texture;
    		}
    }
    public void clickstate(string btnname)
    {
        if (btnname == "startbtn")
        {
            loadingbool = true;
            loadingPanel.SetActive(true);
            anaPanel.SetActive(false);
            StartCoroutine(say());
        }
        else if (btnname == "exitbtn")
        {
            Application.Quit();
        }

    }
    IEnumerator say()
    {
        yield return new WaitForSeconds(1.5f);
        changebool = true;
    }
}