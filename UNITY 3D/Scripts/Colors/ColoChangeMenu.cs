﻿using UnityEngine;
using System.Collections;

public class ColoChangeMenu : MonoBehaviour {

NetworkConnection networkConnection;
	
public int Element=0;
	
	
void Update () {
		
			if(GameObject.Find("Network")){
			networkConnection = GameObject.Find("Network").GetComponent<NetworkConnection>();
			InputColorChange();
		}
	

}
	

private void InputColorChange()
    {
        if (networkConnection.ColorName == "Black")
            ChangeColorTo(new Vector3(0, 0, 0));
		
		if (networkConnection.ColorName == "White")
            ChangeColorTo(new Vector3(1, 1, 1));
		
		if (networkConnection.ColorName == "Red")
            ChangeColorTo(new Vector3(1, 0, 0));
		
		if (networkConnection.ColorName == "Green")
            ChangeColorTo(new Vector3(0, 1, 0));
		
		if (networkConnection.ColorName == "Blue")
            ChangeColorTo(new Vector3(0, 0, 1));
				
	    if (networkConnection.ColorName == "Yellow")
            ChangeColorTo(new Vector3(1, 0.92f, 0.016f));
		
    }

void ChangeColorTo(Vector3 color)
    {
        GetComponent<Renderer>().materials[Element].color = new Color(color.x, color.y, color.z, 1f);

    }
}