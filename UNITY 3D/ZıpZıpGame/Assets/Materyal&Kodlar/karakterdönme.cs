using UnityEngine;
using System.Collections;

public class karakterdönme : MonoBehaviour
{
    public float speed;
    public bool dönme = false;
    void Start()
    {
        speed = 150;
        transform.Rotate(new Vector3(0, 0, 0));
    }

    void OnMouseDown()
    {
        dönme = true;
    }
    void OnMouseUp()
    {
        dönme = false;
    }
    void Update()
    {
        if (dönme)
        {
            // float horizontalmove = Input.touches[0].deltaPosition.x* speed;
            // float verticalmove = Input.touches[0].deltaPosition.y* speed;
            float horizontalmove = Input.GetAxis("Mouse Y") * speed;
            float verticalmove = Input.GetAxis("Mouse X") * speed;
            horizontalmove *= Time.deltaTime;
            verticalmove *= Time.deltaTime;
            if (Input.GetMouseButton(0))
            {
                if (verticalmove > 0)
                {
                    transform.Rotate(new Vector3(1, -horizontalmove, 0.0f));
                }
                if (verticalmove < 0)
                {
                    transform.Rotate(new Vector3(-1, -horizontalmove, 0.0f));
                }
                if (horizontalmove > 0)
                {
                    transform.Rotate(new Vector3(verticalmove, 1, 0.0f));
                }
                if (horizontalmove < 0)
                {
                    transform.Rotate(new Vector3(verticalmove, -1, 0.0f));
                }
            }
        }
    }
}

