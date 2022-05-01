using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterscript : MonoBehaviour
{
    public float speed;
    public GameObject handlight, normlight, runninglight;
    public bool lightstate;
    private GameObject opentextPress;
    private Animator animator;
    public GameObject []doors;
    public float distance;
    // Use this for initialization
       void Start()
    {
        opentextPress = GameObject.Find("opentextpnl");
        doors = GameObject.FindGameObjectsWithTag("door");
        animator = GetComponent<Animator>();
        lightstate = true;
          }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        
        transform.Translate(rotation, 0, translation);
        for (int i = 0; i < doors.Length; i++)
        {
            distance = Vector3.Distance(doors[i].transform.position, transform.position);
            /////////
            if (distance < 5)
            {
                opentextPress.SetActive(true);
                break;
            }
        }               
        if (distance > 5)
        {
            opentextPress.SetActive(false);
        }
        /// for kapatis

        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (lightstate)
            {
                lightstate = false;
            }
            else if (!lightstate)
            {
                lightstate = true;
            }
        }
        if (lightstate)
        {
            if (translation == 0)
            {
                handlight.SetActive(false);
                runninglight.SetActive(false);
                normlight.SetActive(true);
            }
            else if ((translation > 0 || translation < 0) && !Input.GetKey(KeyCode.LeftShift))
            {
                normlight.SetActive(false);
                runninglight.SetActive(false);
                handlight.SetActive(true);
            }
            else if (translation > 0 && Input.GetKey(KeyCode.LeftShift))
            {
                normlight.SetActive(false);
                handlight.SetActive(false);
                runninglight.SetActive(true);

            }
        }
        else if (!lightstate)
        {
            normlight.SetActive(false);
            handlight.SetActive(false);
            runninglight.SetActive(false);
        }
        if (translation > 0)
        {
            animator.SetBool("W_F", true);
            speed = 5;
        }
        if (translation > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("R_F", true);
            speed = 10;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || translation == 0)
        {
            animator.SetBool("R_F", false);
            speed = 5;
        }
        if (translation < 0)
        {
            animator.SetBool("W_B", true);
            speed = 2;
        }
        if (translation == 0)
        {
            animator.SetBool("W_B", false);
            animator.SetBool("W_F", false);
        }
    }
}