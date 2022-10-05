using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScale : MonoBehaviour
{
    public float relRadius;

    private void Start()
    {
        Invoke("ScaleStar", 0.3f);
    }

    public void ScaleStar()
    {
        relRadius = GetComponent<Radius>().relRadius;

        transform.localScale = new Vector3(relRadius, relRadius, relRadius);
    }
}
