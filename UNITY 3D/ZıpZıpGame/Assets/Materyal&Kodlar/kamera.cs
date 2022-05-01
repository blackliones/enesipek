using UnityEngine;
using System.Collections;

public class kamera : MonoBehaviour {
	public GameObject karakter;

	void Start () {
        karakter = GameObject.FindGameObjectWithTag("Player") ;
	}

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = karakter.transform.position + new Vector3(0.05f, 0.5f, -0.7f);
    }
}
