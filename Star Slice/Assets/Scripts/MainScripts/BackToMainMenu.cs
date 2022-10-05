using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public void GoToMainMenu()
    {
        MainMenu.Instance.isAtMenu = true;
        MainMenu.Instance.isAtMap = false;
        SceneManager.LoadScene(0);
    }
}
