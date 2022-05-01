using UnityEngine;
using System.Collections;

public class okyöntakip2 : MonoBehaviour {

   public Transform target;
	void Start () {
       target = GameObject.Find("movekure").transform;
	}
	
	// Update is called once per frame 
	void Update () {
         transform.position = target.transform.position + new Vector3(0,0.3f,0);
     
    }
    }

