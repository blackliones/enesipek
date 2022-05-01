using UnityEngine;
using System.Collections;

public class PointSc : MonoBehaviour {
    public float randompointval;
    public bool jump;
    public UIManager ui;
    public scoresave scores;
    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Player")
        {
            randompointval = Random.Range(10, 15);
            ui.point += randompointval;
            scores.totalpoint += ui.point;
            Destroy(gameObject);
        }
    }
    void Start () {
        StartCoroutine(say());
        scores = GameObject.Find("ScoreSaved").GetComponent<scoresave>();
        ui = GameObject.Find("ButonKontrol").GetComponent<UIManager>();

    }
	
	// Update is called once per frame
	void Update () {
       
        if (jump)
        {
            StartCoroutine(say());
            gameObject.transform.Translate(new Vector3(0, 0.2f, 0));
        }
        else if (!jump)
        {
            gameObject.transform.Translate(new Vector3(0, 0, 0));
        }
    }
    IEnumerator say()
    {
        jump = false;
        yield return new WaitForSeconds(1);
        jump = true;
        StopCoroutine(say());
    }
}
