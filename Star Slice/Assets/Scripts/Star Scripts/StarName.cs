using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarName : MonoBehaviour
{
    private int n;
    public string starName;

    void Start()
    {
        TextAsset mythnames = Resources.Load<TextAsset>("mythnames");

        string[] data = mythnames.text.Split(new char[] { '\n' });

        n = Random.Range(0, data.Length);

        starName = data[n];
    }
}
