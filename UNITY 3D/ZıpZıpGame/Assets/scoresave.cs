using UnityEngine;
using System.Collections;

public class scoresave : MonoBehaviour {
    public float bestscoredk;
    public float bestscoresn;
    public float totalpoint;
    public bool bt=true;
	// Use this for initialization
	void Awake () {

        // DontDestroyOnLoad(gameObject.transform);
        bestscoredk = PlayerPrefs.GetFloat("Scoredk", 0.0f);
        bestscoresn = PlayerPrefs.GetFloat("Scoresn",0.0f);
        totalpoint = PlayerPrefs.GetFloat("Point",0.0f);
    }
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetFloat("Scoresn",bestscoresn);
        PlayerPrefs.SetFloat("Scoredk", bestscoredk);
        PlayerPrefs.SetFloat("Point", totalpoint);
    }

	
}
