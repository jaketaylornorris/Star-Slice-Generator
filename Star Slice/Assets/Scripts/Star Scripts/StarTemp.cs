using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTemp : MonoBehaviour
{
    public float sigma; //Stefan-Boltzmann Constant
    public float temp;
    public float relTemp;
    public float solTemp;
    public float luminosity;
    public float solLuminosity;
    public float radius;

    void Start()
    {
        sigma = 5.670374419f * Mathf.Pow(10f, -8f);
        solTemp = 5778f;
        solLuminosity = 3.83f * Mathf.Pow(10f, 26f);

        Invoke("GetTemperature", 0.2f);
    }

    public void GetTemperature()
    {
        luminosity = solLuminosity * gameObject.GetComponent<Luminosity>().luminosity;
        radius = gameObject.GetComponent<Radius>().radius;

        temp = Mathf.Pow(luminosity / (4 * Mathf.PI * Mathf.Pow(radius, 2f) * sigma), 1f / 4f);

        relTemp = temp / solTemp;
    }
    
}
