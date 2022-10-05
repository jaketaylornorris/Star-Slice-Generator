using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer: MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
