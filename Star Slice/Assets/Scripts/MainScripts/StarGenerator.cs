using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public int numStars;
    public float density;

    public float distance;
    public float randX;
    public float randY;
    public float randZ;
    public Vector3 coords;
    public float line;

    public GameObject prefab;
    public GameObject destroyer;
    public GameObject[] stars;
    public bool newMap;
    void Awake()
    {
        numStars = MainMenu.Instance.numStars;
        density = MainMenu.Instance.density;
        newMap = MainMenu.Instance.newMap;
        distance = Mathf.Pow(numStars / density, 1f / 3f);

        if (newMap)
        {
            MainMenu.Instance.folderName = null;
        }
    }

    void Start()
    {
        if(newMap)
        {
            GenerateStars();
        }
    }
    
    public void GenerateStars()
    {
        for (int i = numStars; i > 0; i--)
        {
            randX = Random.Range(-distance, distance);
            randY = Random.Range(-distance, distance);
            randZ = Random.Range(-distance, distance);
            coords = new Vector3(randX, randY, randZ);

            stars = GameObject.FindGameObjectsWithTag("star");

            Instantiate(prefab, coords, Quaternion.identity);

            foreach (GameObject star in stars)
            {
                line = Vector3.Distance(star.transform.position, coords);
                if (line < 3.5f)
                {
                    Instantiate(destroyer, coords, Quaternion.identity);
                    i++;
                }
            }
        }
    }
}
