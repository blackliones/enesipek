using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollowCameraScript : MonoBehaviour {
        public Transform car;
        public float distance = 6.4f;
    public float height = 1.4f;
    public float rotationDamping = 3.0f;
    public float heightDamping = 2.0f;
    public float zoomRacio = 0.5f;
    public float DefaultFOV = 60;
    public bool rotate = true;
    private Vector3 rotationVector;
	void Start () {
      
	}

    private void LateUpdate()
    {
       var wantedAngel = rotationVector.y;
        var wantedHeight = car.position.y + height;
        var myAngel = transform.eulerAngles.y;
      var myHeight = transform.position.y;
        myAngel = Mathf.LerpAngle(myAngel, wantedAngel, rotationDamping * Time.deltaTime);
        myHeight = Mathf.Lerp(myHeight, wantedHeight, heightDamping * Time.deltaTime);
        var currentRotation = Quaternion.Euler(0, myAngel, 0);
        transform.position = car.position;
        transform.position -= currentRotation * Vector3.forward * distance;
        transform.position = new Vector3(transform.position.x,myHeight,transform.position.z);
        transform.LookAt(car);
    }
    
	void FixedUpdate () {
        var localVilocity = car.InverseTransformDirection(car.GetComponent<Rigidbody>().velocity);
        if (localVilocity.z < -0.5 && rotate)
        {
            rotationVector.y = car.eulerAngles.y + 180;
           
        }
        else
        {
                      rotationVector.y = -car.eulerAngles.y+180;
        }
        if (Input.GetKey(KeyCode.L)&&!Input.GetKey(KeyCode.Q)&&!Input.GetKey(KeyCode.E))
        {
            rotationVector.y = car.eulerAngles.y;
        }
        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.L))
        {
            rotationVector.y = car.eulerAngles.y -145;
        }
        else if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.L))
        {
            rotationVector.y = car.eulerAngles.y + 145;
        }
        else if (Input.GetKey(KeyCode.Q)&&!Input.GetKey(KeyCode.L))
        {
            rotationVector.y = car.eulerAngles.y-90;
        }
              else if (Input.GetKey(KeyCode.E)&&!Input.GetKey(KeyCode.Q))
        {
            rotationVector.y = car.eulerAngles.y +90;
        }
      
        var acc = car.GetComponent<Rigidbody>().velocity.magnitude;
        GetComponent< Camera>().fieldOfView = DefaultFOV + acc * zoomRacio;
    }
}
