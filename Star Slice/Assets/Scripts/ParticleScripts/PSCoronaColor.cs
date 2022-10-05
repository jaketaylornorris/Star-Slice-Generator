using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSCoronaColor : MonoBehaviour
{
    public ParticleSystem psCorona;
    ParticleSystem.MainModule psCoronaMain;
    public Color color;
    public float degrees;
    public float dMax = 270f;


    void Awake()
    {
        psCorona = gameObject.GetComponent<ParticleSystem>();
        psCoronaMain = psCorona.main;
        GetParticleColor();
    }


    public void GetParticleColor()
    {
        var col = psCorona.colorOverLifetime;
        degrees = GetComponentInParent<StarColor>().degrees;

        color = Color.HSVToRGB((degrees * dMax) / 360, 0.5f, 1);
        col.color = color;
        psCoronaMain.startColor = color;
    }
}
