using UnityEngine;
using System.Collections;

public class okyöntakip : MonoBehaviour {

   public Transform target;
	void Start () {
       target = GameObject.Find("movekup").transform;
	}
	
	// Update is called once per frame 
	void Update () {
         transform.position = target.transform.position + new Vector3(0,0.3f,0);
     
    }
    }

