using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class UIScrollViewer : MonoBehaviour
{
    [SerializeField] Transform contentPanel;
    public List<string> folderList = new List<string>();
    public GameObject buttonPrefab;

    public Vector3 buttonCoords;
    private int n;


    private void Awake()
    {
        GetMaps();
    }

    public void GetMaps()
    {
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        DirectoryInfo[] info = dir.GetDirectories();

        foreach (DirectoryInfo f in info)
        {
            folderList.Add(f.Name);
        }

        n = folderList.Count;

        for (int i = 0; i <= n - 1; i++)
        {
            buttonCoords = new Vector3(0, 126 - (i*32) , 0f);
            GameObject button = (GameObject)Instantiate(buttonPrefab);
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = folderList[i];

            button.GetComponent<Button>().onClick.AddListener
                (() => {
                    MainMenu.Instance.folderName = button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
                    MainMenu.Instance.CarryMapName();
                });

            button.transform.SetPositionAndRotation(buttonCoords, Quaternion.identity);
            button.transform.SetParent(contentPanel, false);
        }
    }
}
