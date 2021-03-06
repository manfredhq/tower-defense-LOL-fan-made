﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorder = 10f;
    public float scrollSpeed = 5f;
    public float minY = 8f;
    public float maxY = 80f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameEnded)
        {
            enabled = false;
            return;
        }


        //Make the movement of the camera
        if (Input.GetKey("z"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(-Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("q"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
