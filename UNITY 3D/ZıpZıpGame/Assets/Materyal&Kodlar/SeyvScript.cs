using UnityEngine;
using System.Collections;
using System;

public class SeyvScript : MonoBehaviour
{ 
    public Texture texture;
    public bool tt;
    public float charactercodesv, savemetalicsv, savesmoothsv,state;
    public Color saveclr;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
