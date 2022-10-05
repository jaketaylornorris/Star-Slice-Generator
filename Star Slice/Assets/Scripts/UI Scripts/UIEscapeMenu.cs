using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIEscapeMenu : MonoBehaviour
{
    public GameObject saveMapButton;
    public GameObject backButton;
    public GameObject mapNameIF;
    public GameObject toFileButton;

    private bool isActive = false;

    private void Awake()
    {
        saveMapButton.SetActive(false);
        backButton.SetActive(false);
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
        if (MainMenu.Instance.isAtMap)
        {
            saveMapButton.SetActive(true);
            backButton.SetActive(true);
            gameObject.GetComponent<CursorController>().FreezeCamera();
            gameObject.GetComponent<CursorController>().enabled = false;
            isActive = true;
        }
    }

    public void MakeInactive()
    {
        if (MainMenu.Instance.isAtMap)
        {
            saveMapButton.SetActive(false);
            backButton.SetActive(false);
            toFileButton.SetActive(false);
            mapNameIF.SetActive(false);
            gameObject.GetComponent<CursorController>().enabled = true;
            gameObject.GetComponent<CursorController>().UnlockCamera();
            isActive = false;
        }
    }
}
