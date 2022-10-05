using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour
{
    public float mass;
    private float fpi; // 4/3 pi
    public float radius;
    public float relRadius;
    public float solRadius;
    public float solMass;
    public int starType;

    // star type densities
    private float oden;
    private float bden;
    private float aden;
    private float fden;
    private float gden;
    private float kden;
    private float mden;


    void Start()
    {
        solMass = 1.9891f * Mathf.Pow(10, 30);
        solRadius = 6.957f * Mathf.Pow(10, 8);
        oden = 48.83278471f;
        bden = 153.4082579f;
        aden = 461.5973558f;
        fden = 733.204959f;
        gden = 1731.383383f;
        kden = 3748.61053f;
        mden = 15724.61881f;

        fpi = (4 / 3) * Mathf.PI;
        Invoke("GetRadius", 0.15f);
    }

    public void GetRadius()
    {
        mass = solMass * gameObject.GetComponent<StarMass>().mass;
        starType = gameObject.GetComponent<StarType>().starType;

        if (starType == 0)
        {
            radius = Mathf.Pow((mass / oden / fpi), 1f/3f);
        }
        else if (starType == 1)
        {
            radius = Mathf.Pow((mass / bden / fpi), 1f / 3f);
        }
        else if (starType == 2)
        {
            radius = Mathf.Pow((mass / aden / fpi), 1f / 3f);
        }
        else if (starType == 3)
        {
            radius = Mathf.Pow((mass / fden / fpi), 1f / 3f);
        }
        else if (starType == 4)
        {
            radius = Mathf.Pow((mass / gden / fpi), 1f / 3f);
        }
        else if (starType == 5)
        {
            radius = Mathf.Pow((mass / kden / fpi), 1f / 3f);
        }
        else
        {
            radius = Mathf.Pow((mass / mden / fpi), 1f / 3f);
        }

        relRadius = radius / solRadius;

    }
}
