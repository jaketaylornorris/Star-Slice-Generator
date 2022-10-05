using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlanetCanvas : MonoBehaviour
{
    public static bool isScaleable;

    public GameObject mCamera;
    public float rad;
    private float fixedSize = 0.00025f;
    public float camDist;
    public float size;


    public void Awake()
    {
        mCamera = GameObject.Find("Main Camera");
        isScaleable = false;
    }

    public void Update()
    {
        if (isScaleable)
        {
            ScaleUI();
        }
    }

    public void ScaleUI()
    {
        rad = gameObject.transform.parent.gameObject.GetComponent<PlanetStats>().relRadius;
        camDist = (mCamera.transform.position - gameObject.transform.parent.position).magnitude;
        size = camDist * fixedSize * mCamera.transform.GetComponent<Camera>().fieldOfView;
        transform.localScale = Vector3.one * size / rad;
    }
}
