using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GoToSystem : MonoBehaviour
{
    public bool newSystem = false;
    public string starName;
    public string mapName;
    public string dir;

    public GameObject mCamera;

    private void Start()
    {
        mCamera = GameObject.Find("Main Camera");
    }

    public void CheckSystemExistence()
    {
        starName = gameObject.GetComponent<StarName>().starName;
        mapName = mCamera.GetComponent<SaveData>().mapNameIF.text;

        dir = Application.persistentDataPath + "/" + mapName;

        if (!Directory.Exists(dir) || System.String.IsNullOrEmpty(mapName))
        {
            mCamera.GetComponent<SaveUIEnabler>().MakeActive();
        }
        else
        {
            MainMenu.Instance.isAtMap = false;
            GoToStarSystem();
        }
    }

    public void GoToStarSystem()
    {
        MainMenu.Instance.systemName = starName;
        MainMenu.Instance.star = gameObject;
        MainMenu.Instance.isAtSystem = true;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(mCamera);
        SceneManager.LoadScene(2);
    }
}
