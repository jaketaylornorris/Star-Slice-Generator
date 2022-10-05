using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DefaultConditions : MonoBehaviour
{
    [SerializeField] private TMP_InputField getNumber;
    [SerializeField] private TMP_InputField getDensity;

    public Button defaultCond;

    public int numStars = 100;
    public float density = 0.003f;

    public void SetDefault()
    {
        getNumber.text = numStars.ToString();
        getDensity.text = density.ToString();
    }

}
