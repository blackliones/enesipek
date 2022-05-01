using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class doorscript : MonoBehaviour {
    public bool doorState;
    public float doorDistance;
       public GameObject doorWood;
    private Transform karakter;
 public float doorVal,doorOpeningSpeed;
	void Start () {
        karakter = GameObject.FindGameObjectWithTag("Player").transform;
        doorState = false;
        doorVal = 0;
              doorWood.transform.localEulerAngles = new Vector3(0,0,0);
    }
	// Update is called once per frame
	void Update () {
        doorDistance = Vector3.Distance(karakter.position,transform.position);
        if (doorDistance <= 5)
        {
                                              if (Input.GetKeyDown(KeyCode.E))
            {
                 doorState = !doorState;
            }
        }
               if (doorState)
        {
            if (doorVal > -60)
                doorVal -= Time.deltaTime * doorOpeningSpeed;
            else if (doorVal < -60)
            {
                doorVal = -60;
            }
          
                   }
        else
        {
            if (doorVal < 0)
            {
                doorVal += Time.deltaTime * doorOpeningSpeed;
            }
            else if (doorVal > 0)
            {
                doorVal = 0;
            }
            }
        doorWood.transform.localEulerAngles = new Vector3(0, 0, doorVal);

    }
}
