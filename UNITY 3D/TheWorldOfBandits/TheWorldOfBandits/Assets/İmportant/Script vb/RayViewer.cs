using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour {

    public float weaponRange;
   public Camera fpsCam;
    public Vector3 lineOrigin;
  	void Start () {
         }
	
	
	void Update () {
     
           lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponRange, Color.red);
                }
}
