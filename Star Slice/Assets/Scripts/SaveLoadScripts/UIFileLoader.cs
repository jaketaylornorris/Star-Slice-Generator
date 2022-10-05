using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFileLoader : MonoBehaviour
{
    public GameObject fileBrowser;
    public bool isActive = false;

    private void Start()
    {
        fileBrowser.SetActive(false);
    }
    public void SetActiveFileBrowser()
    {
        if(!isActive)
        {
            fileBrowser.SetActive(true);
            isActive = true;
        }
        else
        {
            fileBrowser.SetActive(false);
            isActive = false;
        }
    }
}
