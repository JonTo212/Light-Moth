using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamZoom : MonoBehaviour
{
    public CinemachineFreeLook cam;
    public float zoomSpeed;
    float FOV;

    void Start()
    {
        FOV = cam.m_Lens.FieldOfView;
    }

    void Update()
    {
        GetScrollWheelInput();
    }

    void GetScrollWheelInput()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            FOV -= zoomSpeed;
            ChangeFOV();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            FOV += zoomSpeed;
            ChangeFOV();
        }
    }

    void ChangeFOV()
    {
        if (FOV >= 20 && FOV <= 60)
        {
            cam.m_Lens.FieldOfView = FOV;
        }
    }
}
