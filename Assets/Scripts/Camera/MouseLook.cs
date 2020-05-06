using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [HideInInspector]
    public float mouseX;
    public float mouseY;
    public float MouseSensitivity = 100f;
    
    public float xRotation = 0f;
    public Transform PlayerBody;

    // Start is called before the first frame update
    void Start()
    {
        PlayerBody = GameObject.FindGameObjectWithTag(PlayerComponents.Player).GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis(MouseAxis.MOUSE_X) * MouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis(MouseAxis.MOUSE_Y) * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        PlayerBody.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation,0f, 0f);
        


    }
}
