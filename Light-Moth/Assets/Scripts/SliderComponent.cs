using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderComponent : MonoBehaviour
{
    public LayerMask sliderMask;
    public GameObject sliderBall;
    public Transform minPos;
    public Transform maxPos;
    Vector3 mousePosition;
    float percentage;
    RaycastHit hit;
    bool mouseDown;
    Light attachedLight;
    void Update()
    {
        GetMousePos();
        ClickAndHold();
        if (mouseDown && hit.point != null)
        {
            sliderBall.transform.position = new Vector3(mousePosition.x, sliderBall.transform.position.y, mousePosition.z);
            sliderBall.transform.rotation = Quaternion.identity;
        }
    }

    void GetMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, sliderMask))
        {
            mousePosition = hit.point;
            percentage = 1f / ((maxPos.position.x - minPos.position.x) / (sliderBall.transform.position.x - minPos.position.x));

            attachedLight = GetComponentInParent<Light>();
            if (attachedLight != null)
            {
                attachedLight.intensity = percentage;
            }
        }
    }

    void ClickAndHold()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }
    }
}
