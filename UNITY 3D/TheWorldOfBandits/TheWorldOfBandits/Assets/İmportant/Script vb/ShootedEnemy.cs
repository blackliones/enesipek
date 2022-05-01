using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootedEnemy : MonoBehaviour {
    public int currentHealth;
	// Use this for initialization
	void Start () {
        gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Damage(int damageVal)
    {
        currentHealth -= damageVal;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
