using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MakeNewMap : MonoBehaviour
{
    public static MakeNewMap Instance;
    [SerializeField] private TMP_InputField getNumber;
    [SerializeField] private TMP_InputField getDensity;
    public Button startButton;

    public int numStars;
    public float density;

    public void Update()
    {
        int.TryParse(getNumber.text, out numStars);
        float.TryParse(getDensity.text, out density);
    }
    public void LoadScene()
    {
        if (numStars > 1000 || density > 0.005)
        {
        }
        else if (numStars == 0 || density == 0)
        {
        }
        else
        {
            MainMenu.Instance.newMap = true;
            MainMenu.Instance.isAtMenu = false;
            MainMenu.Instance.isAtMap = true;
            SceneManager.LoadScene(1);
        }
    }
}
