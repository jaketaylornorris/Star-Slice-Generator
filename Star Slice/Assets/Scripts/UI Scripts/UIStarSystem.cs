using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStarSystem : MonoBehaviour
{
    public GameObject mCamera;
    public GameObject savePlanetsButton;
    public GameObject backToMapButton;
    public GameObject backToMenuButton;
    public GameObject star;
    private bool isActive = false;

    private void Awake()
    {
        mCamera = GameObject.Find("Main Camera");
        savePlanetsButton.SetActive(false);
        backToMapButton.SetActive(false);
        backToMenuButton.SetActive(false);
    }

    void Update()
    {
        if (!isActive && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            MakeActive();
        }
        else if (isActive && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = false;
            MakeInactive();
        }
    }
    public void MakeActive()
    {
        savePlanetsButton.SetActive(true);
        backToMapButton.SetActive(true);
        backToMenuButton.SetActive(true);
        mCamera.gameObject.GetComponent<CursorController>().FreezeCamera();
        mCamera.gameObject.GetComponent<CursorController>().enabled = false;
        isActive = true;
    }

    public void MakeInactive()
    {
        savePlanetsButton.SetActive(false);
        backToMapButton.SetActive(false);
        backToMenuButton.SetActive(false);
        mCamera.gameObject.GetComponent<CursorController>().enabled = true;
        mCamera.gameObject.GetComponent<CursorController>().UnlockCamera();
        isActive = false;
    }

    public void BackToMenu()
    {
        star = GameObject.FindGameObjectWithTag("star");
        mCamera.transform.SetParent(star.transform);
        Destroy(star);
        MainMenu.Instance.isAtSystem = false;
        SceneManager.LoadScene(0);
    }

    public void BackToMap()
    {
        star = GameObject.FindGameObjectWithTag("star");
        mCamera.transform.SetParent(star.transform);
        Destroy(star);
        MainMenu.Instance.isAtSystem = false;
        MainMenu.Instance.isAtMap = true;
        SceneManager.LoadScene(1);
    }
}
