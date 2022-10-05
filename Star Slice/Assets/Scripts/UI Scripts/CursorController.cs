using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private float speed = 150f;
    public Texture2D cursor;

    private void Awake()
    {
        Cursor.visible = false;
    }
    void Start()
    {
        Vector2 cursorOffset = new Vector2(cursor.width / 2, cursor.height / 2);
        Cursor.SetCursor(cursor, cursorOffset, CursorMode.Auto);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            FreezeCamera();
            Cursor.visible = true;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        GoToStar(hit.transform.position, hit.transform.gameObject);
                    }
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            UnlockCamera();
            Cursor.visible = false;
        }
    }

    public void ActivateCursor()
    {
        Cursor.visible = true;
    }

    public void FreezeCamera()
    {
        gameObject.GetComponent<CameraController>().enabled = false;
    }

    public void UnlockCamera()
    {
        gameObject.GetComponent<CameraController>().enabled = true;
    }

    public void GoToStar(Vector3 starPos, GameObject starOBJ)
    {
        Vector3 viewPos = starPos - transform.position;
        float viewDis = Vector3.Magnitude(viewPos);

        if (viewDis >= 3 * starOBJ.GetComponent<Radius>().relRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, starPos, speed * Time.deltaTime);
        }
        
    }
}
