using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarStats : MonoBehaviour
{
    public float mass;
    public float luminosity;
    public int type;
    public float radius;
    public float temp;
    private string[] starTypeArray = { "O", "B", "A", "F", "G", "K", "M" };
    public string starName;

    [SerializeField] TMP_Text typeText;
    [SerializeField] TMP_Text massText;
    [SerializeField] TMP_Text radiusText;
    [SerializeField] TMP_Text tempText;
    [SerializeField] TMP_Text lumText;
    [SerializeField] TMP_Text nameText;

    private GameObject mcamera;

    private void Awake()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void Start()
    {
        mcamera = GameObject.Find("Main Camera");

        Invoke("GetStats", 0.4f);
    }

    private void Update()
    {
        if (Vector3.Magnitude(mcamera.transform.position - transform.position) <= 3 * GetComponent<Radius>().relRadius)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void GetStats()
    {
        type = gameObject.GetComponent<StarType>().starType;
        mass = gameObject.GetComponent<StarMass>().mass;
        luminosity = gameObject.GetComponent<Luminosity>().luminosity;
        radius = gameObject.GetComponent<Radius>().relRadius;
        temp = gameObject.GetComponent<StarTemp>().relTemp;
        starName = gameObject.GetComponent<StarName>().starName;


        typeText.text = "Type: " + starTypeArray[type];
        massText.text = "Mass: " + mass.ToString();
        radiusText.text = "Radius: " + radius.ToString();
        tempText.text = "Temp: " + temp.ToString();
        lumText.text = "Luminosity: " + luminosity.ToString();
        nameText.text = starName;
    }
}
