using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(new Vector3(0,0,-3));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(0, 0, 3));
        }
    }
}
