using UnityEngine;
using System.Collections;

public class movecolorsc : MonoBehaviour
{

    public Material rnk1, rnk2, rnk3, rnk4, rnk5, rnk6, rnk7, rnk8, rnk9, rnk10, rnk11,rnk12;

    public float rcolorr;
    // Use this for initialization
    void Start()
    {
        rnk1.color = Color.white;
        rnk2.color = Color.white;
        rnk3.color = Color.white;
        rnk4.color = Color.white;
        rnk5.color = Color.white;
        rnk6.color = Color.white;
        rnk7.color = Color.white;
        rnk8.color = Color.white;
        rnk9.color = Color.white;
        rnk10.color = Color.white;
        rnk11.color = Color.white;
        rnk12.color = Color.white;

        rcolorr = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (rcolorr == 1)
        {
            StartCoroutine(say1());
        }
        if (rcolorr == 2)
        {
            StartCoroutine(say2());

        }
        if (rcolorr ==3)
        {
            StartCoroutine(say3());
        }
        if (rcolorr == 4)
        {
            StartCoroutine(say4());
        }
    }

    IEnumerator say1()
    {
        rnk1.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);
        rnk2.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);
        rnk3.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);
        rnk4.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);
        rnk5.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);
        rnk6.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);
        rnk7.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);
        rnk8.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);
        rnk9.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);
        rnk10.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);
        rnk11.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);
        rnk12.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);

        rcolorr = 2;
        StopCoroutine(say1());
    }
    IEnumerator say2()
    {
        rnk1.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        rnk2.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        rnk3.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        rnk4.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        rnk5.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        rnk6.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        rnk7.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        rnk8.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        rnk9.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        rnk10.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        rnk11.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        rnk12.color = Color.black;
        yield return new WaitForSeconds(0.2f);


        rcolorr = 3;
        StopCoroutine(say2());
    }
        IEnumerator say3()
    {
            rnk1.color = Color.green;
            yield return new WaitForSeconds(0.2f);
            rnk2.color = Color.green;
            yield return new WaitForSeconds(0.2f);
            rnk3.color = Color.green;
            yield return new WaitForSeconds(0.2f);
            rnk4.color = Color.green;
            yield return new WaitForSeconds(0.2f);
        rnk5.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        rnk6.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        rnk7.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        rnk8.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        rnk9.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        rnk10.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        rnk11.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        rnk12.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        rcolorr = 4;
            StopCoroutine(say3());
        }
    IEnumerator say4()
    {
        rnk1.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rnk2.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rnk3.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rnk4.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rnk5.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rnk6.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rnk7.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rnk8.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rnk9.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rnk10.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rnk11.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rnk12.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rcolorr = 1;
        StopCoroutine(say4());
    }
}