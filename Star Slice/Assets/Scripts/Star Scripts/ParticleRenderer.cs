using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRenderer : MonoBehaviour
{
    public GameObject mcamera;
    public float viewDis;
    public GameObject particleSystemOBJ;
    public GameObject psCoronaOBJ;
    public bool inStarSystem = false;

    void Start()
    {
        particleSystemOBJ = transform.GetChild(1).gameObject;
        psCoronaOBJ = transform.GetChild(2).gameObject;

        particleSystemOBJ.SetActive(false);
        psCoronaOBJ.SetActive(false);
        mcamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (inStarSystem == false)
        {
            viewDis = Vector3.Magnitude(gameObject.transform.position - mcamera.transform.position);

            if (viewDis <= 3 * GetComponent<Radius>().relRadius)
            {
                particleSystemOBJ.SetActive(true);
                psCoronaOBJ.SetActive(true);
            }
            else
            {
                particleSystemOBJ.SetActive(false);
                psCoronaOBJ.SetActive(false);
            }
        }
        else
        {
            particleSystemOBJ.SetActive(true);
            psCoronaOBJ.SetActive(true);
        }
    }
}
