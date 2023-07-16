using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovePlayer : MonoBehaviour
{

    public float mouseSpeed = 1000f;
    public Transform player;
    float rotationX;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
        
        rotationX -= mouseY;

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        rotationX = Mathf.Clamp(rotationX, -80f, 65f);

        
        player.Rotate(Vector3.up * mouseX);
    }
}
