using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToPlanet : MonoBehaviour
{
    [SerializeField] Transform contentPanel;

    public GameObject mCamera;
    public GameObject star;
    public GameObject[] planets;
    public GameObject planet;
    public Vector2 planetVector;
    public Vector2 planetVectorNorm;
    public Vector2 planetVectorPer;
    public Vector2 planetVectorCombine;
    public float radius;
    public float a;
    public float b;
    public float c;
    public GameObject buttonPrefab;

    public Vector3 buttonCoords;
    public string planetName;
    public bool isLocked;
    private int n;

    public void Start()
    {
        mCamera = GameObject.Find("Main Camera");
        star = GameObject.FindGameObjectWithTag("star");
        Invoke("MakeButtons", 0.5f);
    }

    public void MakeButtons()
    {
        planets = GameObject.FindGameObjectsWithTag("planet");

        n = planets.Length - 1;

        for(int i = 0; i <= n; i++)
        {
            buttonCoords = new Vector3(0f, 96f - 31f * i, 0f);
            GameObject button = (GameObject)Instantiate(buttonPrefab);
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = planets[i].GetComponent<StarName>().starName;

            button.GetComponent<Button>().onClick.AddListener
                (() => {
                    ShiftToPlanet(button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
                });

            button.transform.SetPositionAndRotation(buttonCoords, Quaternion.identity);
            button.transform.SetParent(contentPanel, false);
        }
    }

    public void ShiftToPlanet(string planetN)
    {
        if(mCamera.transform.parent != null)
        {
            mCamera.transform.parent.transform.GetChild(0).gameObject.SetActive(false);
            mCamera.transform.parent = null;
        }
        planets = GameObject.FindGameObjectsWithTag("planet");

        foreach (GameObject planet2 in planets)
        {
            if(planet2.GetComponent<StarName>().starName == planetN)
            {
                planet = planet2;
                break;
            }
        }

        isLocked = true;
        radius = planet.GetComponent<PlanetCanvas>().relRadius;
        planetVector = new Vector2(planet.transform.position.x, planet.transform.position.y);
        planetVectorNorm = planetVector.normalized * 1.5f * radius;
        planetVectorPer = Vector2.Perpendicular(planetVector).normalized * 1.5f * radius;
        planetVectorCombine = planetVector + planetVectorNorm + planetVectorPer;

        a = planetVectorCombine.x;
        b = planetVectorCombine.y;
        c = -0.5f * radius;
        mCamera.transform.SetParent(planet.transform);
        mCamera.transform.position = new Vector3(a, b, c);
        mCamera.transform.LookAt(star.transform, Vector3.back);

        planet.transform.GetChild(0).gameObject.SetActive(true);
    }
}
