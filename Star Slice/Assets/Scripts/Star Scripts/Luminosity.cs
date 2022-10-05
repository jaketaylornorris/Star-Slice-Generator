using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luminosity : MonoBehaviour
{
    public float mass;

    public float luminosity;

    void Start()
    {
        Invoke("GetLuminosity", 0.1f);
    }

    public void GetLuminosity()
    {
        mass = gameObject.GetComponent<StarMass>().mass;
        if (mass <= 0.43f)
        {
            luminosity = (0.23f) * Mathf.Pow(mass, 2.3f);
        }
        else if ((mass > 0.43f) && (mass <= 2.0f))
        {
            luminosity = Mathf.Pow(mass, 4.0f);
        }
        else if ((mass > 2f) && (mass <= 55f))
        {
            luminosity = (1.4f) * Mathf.Pow(mass, 3.5f);
        }
        else
        {
            luminosity = 32000f * mass;
        }
    }
}
