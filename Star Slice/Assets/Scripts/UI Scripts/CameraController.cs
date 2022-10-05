using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public float speed = 25f;
    public float sensitivity = 200f;
    public GameObject center;
    public float startPos;

    public Vector3 pos;

    private void Start()
    {
        if (MainMenu.Instance.newMap)
        {
            center = GameObject.Find("Center");
            startPos = center.GetComponent<StarGenerator>().distance;
            pos = new Vector3(0, 0, 0);
            transform.position = pos;
        }
    }

    private void Update()
    {
        MoveCamera(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        RotateCamera(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    public void MoveCamera(float x, float y)
    {
        Vector3 movementAmount = new Vector3(x, 0, y) * speed * Time.deltaTime;
        transform.Translate(movementAmount);
    }

    public void RotateCamera(float rx, float ry)
    {
        Vector3 rotateAmount = new Vector3(-ry, rx, 0) * sensitivity * Time.deltaTime;
        transform.Rotate(rotateAmount);

    }
}
