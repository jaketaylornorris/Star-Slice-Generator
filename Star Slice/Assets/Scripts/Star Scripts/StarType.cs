using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarType : MonoBehaviour
{
    
    public int starType;
    public float starRange;

    private float oProb = 0.011f;
    private float bProb = 0.116f;
    private float aProb = 0.858f;
    private float fProb = 2.978f;
    private float gProb = 6.689f;
    private float kProb = 15.171f;

    private void Awake()
    {
        ChooseStarType();
    }

    public void ChooseStarType()
    {
        starRange = Random.Range(0.0f, 100.0f);

        if (starRange <= oProb)
        {
            starType = 0;
        }
        else if (starRange > oProb && starRange <= bProb)
        {
            starType = 1;
        }
        else if (starRange > bProb && starRange <= aProb)
        {
            starType = 2;
        }
        else if (starRange > aProb && starRange <= fProb)
        {
            starType = 3;
        }
        else if (starRange > fProb && starRange <= gProb)
        {
            starType = 4;
        }
        else if (starRange > gProb && starRange <= kProb)
        {
            starType = 5;
        }
        else
        {
            starType = 6;
        }
    }
}
