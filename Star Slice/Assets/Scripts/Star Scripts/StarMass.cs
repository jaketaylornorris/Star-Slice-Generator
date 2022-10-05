using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMass : MonoBehaviour
{
    public float mass;
    public int starType;

    public void Start()
    {
        Invoke("GetMass", 0.05f);
    }

    public void GetMass()
    {
        starType = gameObject.GetComponent<StarType>().starType;

        if (starType == 0)
        {
            mass = Random.Range(16f, 120f);
        }
        else if (starType == 1)
        {
            mass = Random.Range(2.1f, 16f);
        }
        else if (starType == 2)
        {
            mass = Random.Range(1.4f, 2.1f);
        }
        else if (starType == 3)
        {
            mass = Random.Range(1.04f, 1.4f);
        }
        else if (starType == 4)
        {
            mass = Random.Range(0.8f, 1.04f);
        }
        else if (starType == 5)
        {
            mass = Random.Range(0.45f, 0.8f);
        }
        else
        {
            mass = Random.Range(0.08f, 0.45f);
        }
    }
}
