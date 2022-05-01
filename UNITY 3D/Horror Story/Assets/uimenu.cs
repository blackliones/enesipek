using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uimenu : MonoBehaviour {
    bool menustate;
	// Use this for initialization
	void Start () {
        menustate = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (menustate)
                menustate = false;
            else
                menustate = true;
        }
        if (menustate)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
            Time.timeScale = 1;
        }

	}
}
