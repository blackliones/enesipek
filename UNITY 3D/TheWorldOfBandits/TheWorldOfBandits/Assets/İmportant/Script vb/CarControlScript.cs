using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarControlScript : MonoBehaviour
{
    internal enum SpeedType
    {
        MPH,
        KPH
    }

    public float TopSpeed, currentSpeed;
    public float maxSteerAngle, steerAngle;
    public float maxBrakeTorque, brakeTorque;
    public bool brakestate;
    public float maxMotorTorque, motorTorque;
	public float ibreHiz;
	public float carSpeed;
	public Text ibreHizText;
	public GameObject ibreHizGObj;
    public bool drivestate;
  public Rigidbody m_Rigidbody;
    public float v, h;
    [SerializeField]
    private float m_ReverseTorque;
    [SerializeField]
    private SpeedType m_SpeedType;
    [SerializeField]
    private WheelCollider[] wheelCollider = new WheelCollider[4];
    [SerializeField]
    private GameObject[] wheelMesh = new GameObject[4];

    // Use this for initialization
    void Start()
    {
        brakestate = false;
		ibreHiz = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (drivestate)
        {
			ibreHiz = (-wheelCollider [0].rpm/10) + (-wheelCollider [1].rpm/10) / 2;
			v = -Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");
			            if (Input.GetKey(KeyCode.Space))
            {
                brakestate = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                brakestate = false;
            }
			if (Input.GetKey (KeyCode.W)) {
				carSpeed = v * maxMotorTorque;
				currentSpeed = m_Rigidbody.velocity.magnitude;
			} else if (Input.GetKey (KeyCode.S)) {
				carSpeed = v * maxMotorTorque / 2.5f;
				currentSpeed = m_Rigidbody.velocity.magnitude;
			} else if (!Input.GetKey (KeyCode.W) || !Input.GetKey (KeyCode.S)) {
				brakeTorque = 250;
				if (currentSpeed > 0) {
					currentSpeed -= m_Rigidbody.velocity.magnitude;
				}
			}
	            Move();
            if (brakestate)
            {
                brakeTorque = maxBrakeTorque;
            }
            else
            {
                brakeTorque = 0;
            }
            wheelCollider[2].brakeTorque = brakeTorque;
            wheelCollider[3].brakeTorque = brakeTorque;
        }
        else
        {

            brakeTorque = maxBrakeTorque;
            
        }

    }
    public void Move()
    {
        steerAngle = h * maxSteerAngle;
				for (int i = 0; i < 4; i++)
        {
            Vector3 pos;
            Quaternion quat;
                      wheelCollider[i].GetWorldPose(out pos,out quat);
			        			motorTorque = carSpeed; 
            wheelCollider[i].motorTorque = motorTorque;
                      wheelMesh[i].transform.rotation =quat;
                           }
            wheelCollider[0].steerAngle = steerAngle;
        wheelCollider[1].steerAngle = steerAngle;
     	    }
}
