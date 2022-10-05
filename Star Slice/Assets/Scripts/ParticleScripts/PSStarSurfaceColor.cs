using UnityEngine;

public class PSStarSurfaceColor : MonoBehaviour
{
    public ParticleSystem psStar;
    ParticleSystem.MainModule psStarMain;
    public Color color;


    void Awake()
    {
        psStar = gameObject.GetComponent<ParticleSystem>();
        psStarMain = psStar.main;
        GetParticleColor();
    }


    public void GetParticleColor()
    {
        var col = psStar.colorOverLifetime;

        color = gameObject.GetComponentInParent<StarColor>().color;
        col.color = color;
        psStarMain.startColor = color;
    }
}
