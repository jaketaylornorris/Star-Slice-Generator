using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject mcamera;
    public Quaternion rot;

    private void Start()
    {
        mcamera = GameObject.Find("Main Camera");
    }
    void Update()
    {
        //transform.rotation = rot;
        if (mcamera.transform.parent == null)
        {
            rot = Quaternion.LookRotation(transform.position -
            mcamera.transform.position, mcamera.transform.up);
            transform.rotation = rot;
        }
        else
        {
            rot = Quaternion.LookRotation(transform.position -
            mcamera.transform.position, mcamera.transform.up);
            //rot *= Quaternion.FromToRotation(Vector3.left, Vector3.up);
            transform.rotation = rot;
        }
    }
}
