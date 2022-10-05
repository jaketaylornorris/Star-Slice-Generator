using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlanetCanvas : MonoBehaviour
{
    public float relRadius;
    public float relMass;
    public int type;
    public float temperature;
    public float period;
    public float axisAU;
    public string planetName;
    private string[] typesArray = { "Terrestrial", "Super Earth", "Ice Giant", "Gas Giant" };
    public GameObject mCamera;
    public GameObject canvas2;
    public GameObject star;

    [SerializeField] TMP_Text typeText;
    [SerializeField] TMP_Text massText;
    [SerializeField] TMP_Text radiusText;
    [SerializeField] TMP_Text tempText;
    [SerializeField] TMP_Text axisText;
    [SerializeField] TMP_Text periodText;
    [SerializeField] TMP_Text nameText;

    private void Awake()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        mCamera = GameObject.Find("Main Camera");
        star = GameObject.FindGameObjectWithTag("star");
    }

    private void Start()
    {
        Invoke("GetPlanetStats", 0.21f);
    }

    private void Update()
    {
        var camDist = (mCamera.transform.position - transform.GetChild(1).gameObject.transform.position).magnitude;
        var size = camDist * 0.00025f * mCamera.gameObject.GetComponent<Camera>().fieldOfView;
        transform.GetChild(1).gameObject.transform.localScale = Vector3.one * size;
        transform.GetChild(1).gameObject.transform.forward = transform.GetChild(1).gameObject.transform.position
            - mCamera.transform.position;
    }

    public void GetPlanetStats()
    {
        type = gameObject.GetComponent<PlanetStats>().type;
        relMass = gameObject.GetComponent<PlanetStats>().relMass;
        relRadius = gameObject.GetComponent<PlanetStats>().radius;
        temperature = gameObject.GetComponent<PlanetStats>().temperature / 255f;
        period = gameObject.GetComponent<PlanetStats>().periodY;
        axisAU = gameObject.GetComponent<PlanetStats>().axis / 1.496f / Mathf.Pow(10, 11);
        planetName = gameObject.GetComponent<StarName>().starName;

        typeText.text = "Type: " + typesArray[type - 1];
        massText.text = "Mass: " + relMass.ToString();
        radiusText.text = "Radius: " + relRadius.ToString();
        tempText.text = "Temp: " + temperature.ToString();
        axisText.text = "Major Axis (AU): " + axisAU.ToString();
        periodText.text = "Period (Years): " + period.ToString();
        nameText.text = planetName;

        transform.GetChild(1).gameObject.transform.localScale = gameObject.transform.localScale / relRadius;
        transform.GetChild(1).gameObject.GetComponentInChildren<TextMeshProUGUI>().text = planetName;
        transform.GetChild(1).gameObject.GetComponent<Canvas>().worldCamera = mCamera.GetComponent<Camera>();
    }

    public void SolarView()
    {
        mCamera.transform.parent = null;
        mCamera.transform.position = new Vector3(0f, 0f, -5f * star.transform.localScale.x);
        mCamera.transform.LookAt(star.transform);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
