using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eiCarControl : MonoBehaviour {
    public enum ms{Arrows,Wasd }
    private Rigidbody rb;
    public WheelCollider[] wheelCollider = new WheelCollider[4];
    public GameObject[] wheelMesh = new GameObject[4];
    public ms movementStyle;
    public float torque, maxTorque = 1000;
    public float steerAngle,maxSteerAngle=25;
    public float brake;
    public float v, h;
    private RaycastHit hit;
    private Vector3 wheelColliderCenter;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, 0.3f);
    }
	
	// Update is called once per frame
	void Update () {
        Move();
                      switch (movementStyle)
        {
            case ms.Arrows://arrow koşul
              
                break;
            case ms.Wasd://wasd koşul
                torque = -Input.GetAxis("Vertical")*maxTorque;
                steerAngle = Input.GetAxis("Horizontal")*maxSteerAngle;
                brake = Input.GetKey("space") ? rb.mass * 20 : 0.0f;
                             break;
                        }
        if(v!=0)
      //WEEL MESHİN POZİSYONUNU COLLİDERE EŞİTLE
        if (h != 0)
        {

        }
    }
    void Move()
    {
          wheelCollider[0].steerAngle = steerAngle;
        wheelCollider[1].steerAngle = steerAngle;
       for(int i = 0; i < wheelMesh.Length; i++)
        {
            Vector3 pos;
            Quaternion quat;
            wheelCollider[i].GetWorldPose(out pos, out quat);
            wheelMesh[i].transform.rotation = quat;

        }
        if (brake > 0.0f)
        {
            for(int i = 0; i < wheelCollider.Length; i++)
            {
                wheelCollider[2].motorTorque = 0;
                wheelCollider[3].motorTorque = 0;
                wheelCollider[i].brakeTorque = brake;
               
            }          
                }
        else
        {
            for (int i = 0; i < wheelCollider.Length; i++)
            {
                wheelCollider[i].brakeTorque = 0;
                wheelCollider[i].motorTorque = torque;
                         }
                }
    }
}
