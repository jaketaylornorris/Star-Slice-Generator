using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarMovement : MonoBehaviour
{
    private float G; //Gravitational Constant N * m^2 * kg^-2
    public float axis;
    public float distance;
    public float periodS; // period in seconds
    public float periodY; // period in years
    public float solMass;
    public GameObject star;


    void Start()
    {
        G = 6.6743015f * Mathf.Pow(10, -11);
        solMass = 1.988f * Mathf.Pow(10, 30);
        distance = gameObject.transform.position.y;
        axis = Mathf.Pow(Mathf.Abs(distance) / 20, 10);
        periodS = 2 * Mathf.PI * Mathf.Pow( Mathf.Pow(axis, 3) / G / solMass, 0.5f );
        periodY = periodS / 3600 / 365.25f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(star.transform.position, new Vector3(0, 0, 1), 100 / periodY * Time.deltaTime);
    }
}
