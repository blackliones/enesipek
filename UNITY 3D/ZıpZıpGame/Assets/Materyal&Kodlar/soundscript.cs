using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class soundscript : MonoBehaviour {
    public Sprite muteon,muteoff;
    public AudioSource source;
    public GameObject btn;
    public bool musicstate;
    void Start ()
    {

        musicstate = false;
        
    }
	
	void Update () {
        if (musicstate) 
        {
            btn.GetComponent<Image>().overrideSprite = muteon;
        }
        else {
            btn.GetComponent<Image>().overrideSprite = muteoff;
        }
	}
public void click(string name)
    {
        if(name == "soundbuton")
        {
            if (musicstate)
            {
                source.mute = false;
                musicstate = false;

            }
            else if (!musicstate)
            {
                source.mute = true;
                musicstate = true;
            }
        }
    } 
}
