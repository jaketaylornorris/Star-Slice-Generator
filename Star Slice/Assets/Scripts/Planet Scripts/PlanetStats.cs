using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetStats : MonoBehaviour
{
    private GameObject star;
    public float starMass;
    public float starTemp;
    public float starRadius;
    private bool isDone = false;

    public float mass;
    public float relMass;
    public float radius;
    public float relRadius;
    public float density;
    public float logAxis;
    public float axis;
    public float periodS; //period in seconds
    public float periodY; //period in years
    public float temperature;
    public float albedo;
    public int type;
    public string[] planetTypes;
    public float gravity;
    private float G = 6.6743015f * Mathf.Pow(10, -11);

    public float randType;
    public Vector3 center = new Vector3(0f, 0f, 0f);
    public float fpi = 4 / 3 * Mathf.PI;
    public float earthMass = 5.972f * Mathf.Pow(10f, 24f);
    public float earthRadius = 6.3781f * Mathf.Pow(10f, 6f);

    void Awake()
    {
        logAxis = Vector3.Distance(transform.position, center);
        star = GameObject.FindGameObjectWithTag("star");
        starMass = GameObject.FindGameObjectWithTag("star").GetComponent<Radius>().mass;
        starTemp = GameObject.FindGameObjectWithTag("star").GetComponent<StarTemp>().temp;
        starRadius = GameObject.FindGameObjectWithTag("star").GetComponent<Radius>().radius;
        GetPlanetType();
        GetPlanetStats();
    }

    private void Start()
    {
    }

    void Update()
    {
        if (isDone)
        {
            transform.RotateAround(center, new Vector3(0, 0, 1), 100 / periodY * Time.deltaTime);
        }
    }

    public void GetPlanetType()
    {
        randType = Random.Range(0f, 1f);
        
        if(randType <= 0.08487084871f)
        {
            type = 1; //Terrestrial
        }
        else if (randType <= 0.3616236162f)
        {
            type = 2; //Super Earth
        }
        else if (randType <= 0.8339483395f)
        {
            type = 3; //Ice Giant
        }
        else
        {
            type = 4; //Gas Giant
        }
    }

    public void GetPlanetStats()
    {
        Invoke("GetPlanetDensityandAlbedo", 0.1f);
        Invoke("GetPlanetRadius", 0.15f);
        Invoke("GetPlanetEverythingElse", 0.2f);
    }

    public void GetPlanetDensityandAlbedo()
    {
        if (type == 1 || type == 2)
        {
            density = 1000f * Random.Range(4f, 10f);
            albedo = Random.Range(0.2f, 0.8f);
        }
        else if (type == 3)
        {
            density = 1000f * Random.Range(0.3f, 1.1f);
            albedo = Random.Range(0.28f, 0.31f);
        }
        else
        {
            density = 1000f * Random.Range(0.3f, 1.1f);
            albedo = Random.Range(0.3f, 0.6f);
        }
    }

    public void GetPlanetRadius()
    {
        if (type == 1)
        {
            radius = Random.Range(0.5f, 1.25f);
        }
        else if (type == 2)
        {
            radius = Random.Range(1.25f, 2f);
        }
        else if (type == 3)
        {
            radius = Random.Range(2f, 6f);
        }
        else
        {
            radius = Random.Range(6f, 22f);
        }
    }

    public void GetPlanetEverythingElse()
    {

        transform.localScale = new Vector3(radius, radius, radius);
        mass = fpi * Mathf.Pow(radius * earthRadius, 3f) * density;
        relMass = mass / earthMass;
        relRadius = radius;
        gravity = G * mass / Mathf.Pow(radius, 2);

        logAxis = Vector3.Distance(transform.position, center);
        axis = Mathf.Pow(10, logAxis / 50f);
        periodS = 2 * Mathf.PI * Mathf.Pow(axis * axis / starMass / G * axis, 0.5f);
        periodY = periodS / 3600 / 365.25f;

        temperature = starTemp * Mathf.Pow(starRadius / 2 / axis, 0.5f) * Mathf.Pow(1 - albedo, 0.25f);
        isDone = true;

        UIPlanetCanvas.isScaleable = true;
    }
}
