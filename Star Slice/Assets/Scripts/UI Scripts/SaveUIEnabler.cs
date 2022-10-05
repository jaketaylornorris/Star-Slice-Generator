using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveUIEnabler : MonoBehaviour
{
    public TMP_InputField getMapName;
    public GameObject nameInputField;
    public GameObject saveFileButton;
    public GameObject mainMenuButton;
    public GameObject saveMenuButton;

    private void Awake()
    {
        nameInputField.SetActive(false);
        saveFileButton.SetActive(false);
    }
    public void MakeActive()
    {
        nameInputField.SetActive(true);
        saveFileButton.SetActive(true);
        gameObject.GetComponent<CursorController>().FreezeCamera();
        gameObject.GetComponent<CursorController>().enabled = false;
    }

    public void MakeInactive()
    {
        nameInputField.SetActive(false);
        saveFileButton.SetActive(false);
        mainMenuButton.SetActive(false);
        saveMenuButton.SetActive(false);
        gameObject.GetComponent<CursorController>().enabled = true;
        gameObject.GetComponent<CursorController>().UnlockCamera();
    }
}
