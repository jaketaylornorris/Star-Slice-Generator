using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;
    public bool isAtMenu;
    public bool isAtMap;

    [SerializeField] private TMP_InputField getNumber;
    [SerializeField] private TMP_InputField getDensity;
    public bool newMap = false;
    public bool isAtSystem;
    public Button startButton; 

    public int numStars;
    public float density;

    public string folderName;
    public string planetFolderName;
    public string systemName;
    public GameObject star;
    private void Awake()
    {
        isAtMenu = true;
        isAtMap = false;
        isAtSystem = false;
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (isAtMenu)
        {
            getNumber = GameObject.Find("InputField Number of Stars").GetComponent<TMP_InputField>();
            getDensity = GameObject.Find("InputField Density per Cubic Lightyear").GetComponent<TMP_InputField>();
            int.TryParse(getNumber.text, out numStars);
            float.TryParse(getDensity.text, out density);
        }
    }

    public void CarryMapName()
    {
        newMap = false;
        isAtMenu = false;
        isAtMap = true;
        SceneManager.LoadScene(1);
    }
}
