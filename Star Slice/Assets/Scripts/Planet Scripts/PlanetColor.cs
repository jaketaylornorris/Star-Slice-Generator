using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetColor : MonoBehaviour
{
    public Color color;
    public Material material;
    public float rand;

    private void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
        Invoke("GetColor", 0.2f);
    }
    public void GetColor()
    {
        rand = Random.Range(0f, 360f);

        color = Random.ColorHSV();

        material.color = color;
    }
}
