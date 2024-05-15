using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public ControlMap controlMap; 
    public float sensX = 100f;
    public float sensY = 100f;

    public Transform orientation;

    private float xRotation;
    private float yRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        controlMap = new ControlMap();
        controlMap.Player.Look.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDir = controlMap.Player.Look.ReadValue<Vector2>();

        float mouseX = lookDir.x * Time.deltaTime * sensX;
        float mouseY = lookDir.y * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.rotation = Quaternion.Euler(xRotation, yRotation,0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
