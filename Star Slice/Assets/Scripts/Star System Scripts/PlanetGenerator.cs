using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlanetGenerator : MonoBehaviour
{
    public string dir;
    public string starName;
    public string mapName;

    public GameObject star;
    public GameObject psSurface;
    public GameObject psCorona;
    public float starMass;
    public float relRadius;
    public Vector3 center;
    public Vector3 camStart;
    public Transform canvas;

    public GameObject planetPrefab;
    public GameObject newPlanet;
    public GameObject[] planets;
    public int numPlanets;
    public Vector3 coords;
    public float axis;
    public float distance;
    public float pDist; // distance between planet and center
    public float nDist; // distance between newly instantiated planet and center
    public float randP;
    public float randX;
    public float randY;

    private float zeroProb = 0.3818897638f;
    private float oneProb = 0.7401574803f;
    private float twoProb =  0.9178852643f;
    private float threeProb = 0.9724409449f;
    private float fourProb = 0.9910011249f;
    private float fiveProb = 0.9971878515f;
    private float sixProb = 0.9994375703f;
    private float rand;

    void Awake()
    {
        star = GameObject.FindGameObjectWithTag("star");
        starName = star.GetComponent<StarName>().starName;
        starMass = star.GetComponent<Radius>().mass;
        mapName = GameObject.Find("MainMenu").GetComponent<MainMenu>().folderName;
    }

    private void Start()
    {
        dir = Application.persistentDataPath + "/" + mapName + "/" + starName + "/";
        if (!Directory.Exists(dir))
        {
            GetNumberOfPlanets();
            GeneratePlanets();
        }
        Invoke("ScaleStar", 0.35f);
    }

    public void GetNumberOfPlanets()
    {
        rand = Random.Range(0f, 1f);
        
        if (rand <= zeroProb)
        {
            numPlanets = 0;
        }
        else if (rand <= oneProb)
        {
            numPlanets = 1;
        }
        else if (rand <= twoProb)
        {
            numPlanets = 2;
        }
        else if (rand <= threeProb)
        {
            numPlanets = 3;
        }
        else if (rand <= fourProb)
        {
            numPlanets = 4;
        }
        else if (rand <= fiveProb)
        {
            numPlanets = 5;
        }
        else if (rand <= sixProb)
        {
            numPlanets = 6;
        }
        else
        {
            numPlanets = 7;
        }
    }

    public void GeneratePlanets()
    {
        for (int i = 1; i <= numPlanets; i++)
        {
            planets = GameObject.FindGameObjectsWithTag("planet");
            randP = Random.Range(2.9211f, 29211f);
            axis = Mathf.Pow(randP * starMass, 1f / 3f);
            distance = 50f * Mathf.Log(axis, 10);
            randX = Random.Range(-20f, 20f);
            randY = Random.Range(-20f, 20f);
            coords = new Vector3(randX, randY, 0f);

            newPlanet = Instantiate(planetPrefab, distance * coords.normalized, Quaternion.identity);

        }
    }

    public void ScaleStar()
    {
        star = GameObject.FindGameObjectWithTag("star");
        relRadius = 109f * star.GetComponent<Radius>().relRadius;
        star.transform.localScale = new Vector3(relRadius, relRadius, relRadius);
        psSurface = star.transform.GetChild(1).gameObject;
        psCorona = star.transform.GetChild(2).gameObject;
        psSurface.transform.localScale *= 109f;
        psCorona.transform.localScale *= 109f;
    }
}
