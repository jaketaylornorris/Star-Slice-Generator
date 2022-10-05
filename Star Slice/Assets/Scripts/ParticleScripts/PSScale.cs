using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSScale : MonoBehaviour
{
    public float relRadius;

    private void Start()
    {
        Invoke("ScalePS", 0.3f);
    }

    public void ScalePS()
    {
        relRadius = GetComponentInParent<Radius>().relRadius;

        transform.localScale *= relRadius;
    }
}
