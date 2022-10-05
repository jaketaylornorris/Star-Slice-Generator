using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystemStart : MonoBehaviour
{
    private GameObject star;
    private GameObject mCamera;
    public Vector3 center;
    public Vector3 camStart;
    private Transform canvas;
    public ParticleSystem psSurface;
    public ParticleSystem psCorona;

    void Awake()
    {
        star = GameObject.FindGameObjectWithTag("star");
        mCamera = GameObject.FindGameObjectWithTag("MainCamera");
        center = new Vector3(0f, 0f, 0f);
        camStart = new Vector3(0f, 0f, -6f * 109f * star.GetComponent<Radius>().relRadius);
        star.transform.position = center;
        canvas = star.transform.GetChild(0);

        canvas.gameObject.SetActive(false);
        star.GetComponent<StarStats>().enabled = false;
        mCamera.transform.position = camStart;
        mCamera.transform.rotation = Quaternion.identity;

        star.GetComponent<ParticleRenderer>().inStarSystem = true;
    }
}
