using UnityEngine;
using System.Collections;

public class firecontrol : MonoBehaviour {
    public float speed,distance,asama;
          public Transform target1, target2, target3, target4,target5,target6,target7,target8,target9;
    Vector3 pos;
    void Start () {
       
        transform.position =new Vector3(286.67f,-142, 692.28f);
        asama = 0;
          }

    // Update is called once per frame
    void Update()
    {

        if (asama == 0)
        {
            pos = new Vector3(target1.position.x, transform.position.y, target1.position.z);
            distance = Vector3.Distance(transform.position, target1.position);
            transform.position = Vector3.MoveTowards(transform.position, target1.position, speed * Time.deltaTime);
            if (distance <= 0.0f)
            {
                asama = 1;
             
               
            }
        }
        else if (asama == 1)
        {
            pos = new Vector3(target2.position.x, transform.position.y, target2.position.z);
            distance = Vector3.Distance(transform.position, target2.position);
            transform.position = Vector3.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);
            if (distance <= 0.0f)
            {
                asama = 2;
            
            }
        }
        else if (asama == 2)
        {
            pos = new Vector3(target3.position.x, transform.position.y, target3.position.z);
            distance = Vector3.Distance(transform.position, target3.position);
            transform.position = Vector3.MoveTowards(transform.position, target3.position, speed * Time.deltaTime);
            if (distance <= 0.0f)
            {
                asama = 3;
              
            }
        }
        else if (asama == 3)
        {
            pos = new Vector3(target4.position.x, transform.position.y, target4.position.z);
            distance = Vector3.Distance(transform.position, target4.position);
            transform.position = Vector3.MoveTowards(transform.position, target4.position, speed * Time.deltaTime);
            if (distance <= 0.0f)
            {
                asama = 4;
                            }
        }
        else if (asama == 4)
        {
            pos = new Vector3(target5.position.x, transform.position.y, target5.position.z);
            distance = Vector3.Distance(transform.position, target5.position);
            transform.position = Vector3.MoveTowards(transform.position, target5.position, speed * Time.deltaTime);
            if (distance <= 0.0f)
            {
                  asama = 5;
            }
        }
        else if (asama == 5)
        {
            pos = new Vector3(target6.position.x, transform.position.y, target6.position.z);
            distance = Vector3.Distance(transform.position, target6.position);
            transform.position = Vector3.MoveTowards(transform.position, target6.position, speed * Time.deltaTime);
            if (distance <= 0.0f)
            {
                asama = 6;
                             }
        }
        else if (asama == 6)
        {
           pos = new Vector3(target7.position.x, transform.position.y, target7.position.z);
          distance = Vector3.Distance(transform.position, target7.position);
            transform.position = Vector3.MoveTowards(transform.position, target7.position, speed * Time.deltaTime);
            if (distance <= 0.0f)
            {
                asama = 7;
            }
        }
        else if (asama == 7)
        {
            pos = new Vector3(target8.position.x, transform.position.y, target8.position.z);
            distance = Vector3.Distance(transform.position, target8.position);
            transform.position = Vector3.MoveTowards(transform.position, target8.position, speed * Time.deltaTime);
            if (distance <= 0.0f)
            {
                asama = 8;
            }
        }
        else if(asama == 8)
        {
            pos = new Vector3(target9.position.x, transform.position.y, target9.position.z);
            distance = Vector3.Distance(transform.position, target9.position);
            transform.position = Vector3.MoveTowards(transform.position, target9.position, speed * Time.deltaTime);
            if (distance <= 0.0f)
            {
                asama =9;
            }
        }
        else if (asama == 9)
        {
            pos = new Vector3(target1.position.x, transform.position.y, target1.position.z);
            distance = Vector3.Distance(transform.position, target1.position);
            transform.position = Vector3.MoveTowards(transform.position, target1.position, speed * Time.deltaTime);
            if (distance <= 0.0f)
            {
                asama = 0;
            }
        }
    }
}
