using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Spectator : MonoBehaviour
{
    [Range(0.1f, 50)]
    public float movespeed = 8f;
    public float sens = 1f;

    [Range(1f, 60)]
    public float zoominfov = 25f;
    private float startfov;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        startfov = cam.fieldOfView;
        //Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            cam.fieldOfView = zoominfov;
        }
        if (Input.GetMouseButtonUp(1))
        {
            cam.fieldOfView = startfov;
        }

        transform.position += transform.forward * Time.deltaTime * movespeed * Input.GetAxis("Vertical");
        transform.position += transform.right * Time.deltaTime * movespeed * Input.GetAxis("Horizontal");
        transform.position += transform.up * Time.deltaTime * movespeed * Input.GetAxis("Lift");

        transform.Rotate(Vector3.up * sens * Input.GetAxis("Mouse X"), Space.World);
        transform.Rotate(Vector3.right * sens * -Input.GetAxis("Mouse Y"), Space.World);

        transform.Rotate(new Vector3(0, 0, 50 * Time.deltaTime));
    }
}
