using UnityEngine;
using System.Collections;
public class hareket : MonoBehaviour {
  Rigidbody rb;
    public float hiz;
    public Transform cam;
    public GameObject move;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        cam.transform.position = transform.position + new Vector3(-3, 2, 0);
        if (Input.GetKey(KeyCode.W))
        {
            move.transform.Rotate(new Vector3(0, 0, -3));
            gameObject.transform.Translate(1*hiz*Time.deltaTime, 0, 0);
        }
   if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(-1*hiz*Time.deltaTime, 0, 0);
            move.transform.Rotate(new Vector3(0, 0, 3));

        }

     if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -5*hiz*Time.deltaTime, 0);
        
        }

        if (Input.GetKey(KeyCode.D))
        {

            transform.Rotate(0, 5 * hiz * Time.deltaTime, 0);

        }
    }
}
