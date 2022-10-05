using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using SaveLoadSystem;
using TMPro;

public class SaveData : MonoBehaviour
{
    public TMP_InputField mapNameIF;
    [SerializeField] public static string mapName;
    public static string starName;
    public static string starNameReplace;
    public static int i;

    private PlayerData myData = new PlayerData();
    private StarData starData = new StarData();
    private PlanetData planetData = new PlanetData();
    public GameObject[] stars;
    public GameObject[] planets;
    public GameObject mCamera;
    public GameObject starInSystem;
    public static string starInSystemName;
    private string[] starTypeArray = { "O", "B", "A", "F", "G", "K", "M" };
    private string[] typesArray = { "Terrestrial", "Super Earth", "Ice Giant", "Gas Giant" };

    public string folderName;
    public GameObject starPrefab;
    public GameObject planetPrefab;
    public string fullPath;

    private void Start()
    {
        mCamera = GameObject.Find("Main Camera");

        folderName = "/" + MainMenu.Instance.folderName + "/";
        if (!MainMenu.Instance.newMap && !MainMenu.Instance.isAtSystem)
        {
            LoadMap();
            LoadPlayer();
        }
        else if (MainMenu.Instance.isAtSystem)
        {
            LoadPlanets();
        }

        if (MainMenu.Instance.isAtMap)
        {
            mapNameIF.text = folderName.Replace("/", "");
        }
    }
    void Update()
    {
        myData.playerPosition = mCamera.transform.position;
        myData.playerRotation = mCamera.transform.rotation;
        if (MainMenu.Instance.isAtMap)
        {
            mapName = mapNameIF.text;
        }
    }

    public void SaveMap()
    {
        stars = GameObject.FindGameObjectsWithTag("star");

        MainMenu.Instance.folderName = mapName;
        MainMenu.Instance.newMap = false;

        SaveGameManager.CurrentSavePlayer.PlayerData = myData;
        SaveGameManager.SavePlayer();

        for (i = stars.Length - 1; i >= 0; i--)
        {
            GameObject star = stars[i];
            starName = star.GetComponent<StarStats>().starName;
            starNameReplace = starName.Replace("'", "");
            starNameReplace = starNameReplace.Replace(":", "");
            starNameReplace = starNameReplace.Replace("/", "");
            starNameReplace = starNameReplace.Replace("*", "");
            starNameReplace = starNameReplace.Replace("<", "");
            starNameReplace = starNameReplace.Replace(">", "");
            starNameReplace = starNameReplace.Replace("|", "");
            starNameReplace = starNameReplace.Replace("?", "");
            starNameReplace = starNameReplace.Replace(" ", "");
            starNameReplace = starNameReplace.Replace("\r", "");

            starData.starName = starNameReplace;
            starData.starPosition = star.transform.position;
            starData.starRadius = star.GetComponent<StarStats>().radius;
            starData.starMass = star.GetComponent<StarStats>().mass;
            starData.starTemp = star.GetComponent<StarStats>().temp;
            starData.starLuminosity = star.GetComponent<StarStats>().luminosity;
            starData.starType = starTypeArray[star.GetComponent<StarStats>().type];

            SaveGameManager.CurrentSaveMap.starData = starData;
            SaveGameManager.SaveStars();
        }
    }

    public void SavePlanetMap()
    {
        planets = GameObject.FindGameObjectsWithTag("planet");
        starInSystem = GameObject.FindGameObjectWithTag("star");
        starInSystemName = starInSystem.gameObject.GetComponent<StarName>().starName;

        MainMenu.Instance.planetFolderName = mapName + "/" + starInSystemName;
        

        for (i = planets.Length - 1; i >= 0; i--)
        {
            GameObject planet = planets[i];
            starName = planet.GetComponent<StarName>().starName;
            starNameReplace = starName.Replace("'", "");
            starNameReplace = starNameReplace.Replace(":", "");
            starNameReplace = starNameReplace.Replace("/", "");
            starNameReplace = starNameReplace.Replace("*", "");
            starNameReplace = starNameReplace.Replace("<", "");
            starNameReplace = starNameReplace.Replace(">", "");
            starNameReplace = starNameReplace.Replace("|", "");
            starNameReplace = starNameReplace.Replace("?", "");
            //starNameReplace = starNameReplace.Replace(" ", "");
            starNameReplace = starNameReplace.Replace("\r", "");

            planetData.planetName = starNameReplace;
            planetData.planetMass = planet.GetComponent<PlanetCanvas>().relMass;
            planetData.planetPosition = planet.transform.position;
            planetData.planetDensity = planet.GetComponent<PlanetStats>().density;
            planetData.planetRadius = planet.GetComponent<PlanetCanvas>().relRadius;
            planetData.albedo = planet.GetComponent<PlanetStats>().albedo;
            planetData.planetTemp = planet.GetComponent<PlanetCanvas>().temperature;
            planetData.planetType = typesArray[planet.GetComponent<PlanetCanvas>().type - 1];
            planetData.axis = planet.GetComponent<PlanetCanvas>().axisAU;
            planetData.period = planet.GetComponent<PlanetCanvas>().period;

            SaveGameManager.CurrentSavePlanet.PlanetData = planetData;
            SaveGameManager.SavePlanets();
        }
    }
    public void LoadMap()
    {
        
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath + folderName);
        FileInfo[] info = dir.GetFiles();

        for (int n = 0; n <= info.Length - 1; n++)
        {
            SaveStarMap tempData = new SaveStarMap();
            fullPath = info[n].ToString();
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<SaveStarMap>(json);

            if(tempData.starData.starName != null)
            {
                GameObject star = (GameObject)Instantiate(starPrefab);
                star.transform.position = tempData.starData.starPosition;
                int i = 0;
                for (; i <= starTypeArray.Length - 1; i++)
                {
                    if (starTypeArray[i].Contains(tempData.starData.starType))
                    {
                        break;
                    }
                }
                StartCoroutine(ChangeStarType(star, i, tempData.starData.starName));
                StartCoroutine(ChangeStarMass(star, tempData.starData.starMass));
            }
        }
    }

    public void LoadPlayer()
    {
        SaveGameManager.LoadPlayer();
        myData = SaveGameManager.CurrentSavePlayer.PlayerData;
        mCamera.transform.position = myData.playerPosition;
        mCamera.transform.rotation = myData.playerRotation;
    }

    public void LoadPlanets()
    {
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath + folderName + MainMenu.Instance.systemName + "/");
        FileInfo[] info = dir.GetFiles();

        for (int n = 0; n <= info.Length - 1; n++)
        {
            SavePlanetStats tempData = new SavePlanetStats();
            fullPath = info[n].ToString();
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<SavePlanetStats>(json);

            if (tempData.PlanetData.planetName != null)
            {
                GameObject planet = (GameObject)Instantiate(planetPrefab);
                planet.transform.position = tempData.PlanetData.planetPosition;
                int i = 0;
                for (; i <= typesArray.Length - 1; i++)
                {
                    if (typesArray[i].Contains(tempData.PlanetData.planetType))
                    {
                        break;
                    }
                }
                StartCoroutine(ChangePlanetType(planet, i, tempData.PlanetData.planetName));
                StartCoroutine(ChangePlanetDensityandAlbedo(planet, tempData.PlanetData.planetDensity, tempData.PlanetData.albedo));
                StartCoroutine(ChangePlanetRadius(planet, tempData.PlanetData.planetRadius));
            }
        }
    }
    
    IEnumerator ChangeStarType(GameObject star, int i, string starName)
    {
        yield return new WaitForSeconds(0.04f);
        star.GetComponent<StarType>().starType = i;
        star.GetComponent<StarName>().starName = starName;
    }

    IEnumerator ChangeStarMass(GameObject star, float starMass)
    {
        yield return new WaitForSeconds(0.06f);
        star.GetComponent<StarMass>().mass = starMass;
    }

    IEnumerator ChangePlanetType(GameObject planet, int i, string planetName)
    {
        yield return new WaitForSeconds(0.05f);
        planet.GetComponent<PlanetStats>().type = i + 1;
        planet.GetComponent<StarName>().starName = planetName;
    }

    IEnumerator ChangePlanetDensityandAlbedo(GameObject planet, float density, float albedo)
    {
        yield return new WaitForSeconds(0.12f);
        planet.GetComponent<PlanetStats>().density = density;
        planet.GetComponent<PlanetStats>().albedo = albedo;
    }

    IEnumerator ChangePlanetRadius(GameObject planet, float radius)
    {
        yield return new WaitForSeconds(0.17f);
        planet.GetComponent<PlanetStats>().radius = radius;
    }
}


[System.Serializable]
public struct PlayerData
{
    public Vector3 playerPosition;
    public Quaternion playerRotation;
}

[System.Serializable]
public struct StarData
{
    public Vector3 starPosition;
    public string starName;
    public string starType;
    public float starMass;
    public float starTemp;
    public float starLuminosity;
    public float starRadius;
}

[System.Serializable]
public struct PlanetData
{
    public Vector3 planetPosition;
    public string planetName;
    public string planetType;
    public float planetDensity;
    public float planetMass;
    public float planetRadius;
    public float albedo;
    public float planetTemp;
    public float period;
    public float axis;
}
