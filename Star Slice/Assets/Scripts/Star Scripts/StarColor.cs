using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarColor : MonoBehaviour
{
    public Material material;
    
    public Color color;
    public Color eColor;
    public float wavelength;
    public float b; // constant of proportionality
    public float dMax;
    public float degrees;
    public float lambda;
    public float lambdaMin;
    public float lambdaMax;

    public float temp;
    void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
        
        color.a = 1;

        b = 2.897771955f * Mathf.Pow(10f, -3f);
        dMax = 270f;
        lambdaMin = 380f;
        lambdaMax = 740f;
        Invoke("GetColor", 0.25f);
    }

    public void GetColor()
    {
        temp = gameObject.GetComponent<StarTemp>().temp;
        wavelength = b * 1000000000 / temp; // Wien's Law

        if (wavelength < lambdaMin)
        {
            lambda = lambdaMin;
        }
        else if (wavelength > lambdaMax)
        {
            lambda = lambdaMax;
        }
        else
        {
            lambda = wavelength;
        }

        degrees = Mathf.Abs( ((lambda - lambdaMin) / (lambdaMax - lambdaMin)) - 1 );

        color = Color.HSVToRGB((degrees * dMax) / 360, 1, 1);
        eColor = Color.HSVToRGB((degrees * dMax) / 360, 0.5f, 1);

        material.color = color;
        material.SetColor("_EmissionColor", eColor);
    }
}
