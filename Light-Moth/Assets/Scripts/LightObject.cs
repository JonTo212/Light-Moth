using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightObject : MonoBehaviour
{
    public float intensity;
    public bool isOn;
    public Camera cam;
    bool mouseOver;

    public GameObject slider;
    private GameObject currentSlider;
    private Slider currentSliderBar;
    public GameObject onBulb;
    public GameObject offBulb;
    public GameObject currentButton;
    private Light lighting;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        lighting = GetComponent<Light>();
    }
    void Update()
    {
        //Spawn slider
        if (isOn)
        {
            DimmerOpen();
        }
        else if (!isOn)
        {
            Destroy(currentSlider);
        }

        //Turn on and off
        if (mouseOver && Input.GetMouseButtonDown(0) && currentButton == null && !isOn)
        {
            OnOpen();
        }
        else if (mouseOver && Input.GetMouseButtonDown(0) && currentButton != null && !isOn)
        {
            Destroy(currentButton);
        }

        lighting.intensity = intensity * 2;
    }

    #region MouseOver
    void OnMouseEnter()
    {
        mouseOver = true;
    }
    void OnMouseOver()
    {
        mouseOver = true;
    }
    void OnMouseExit()
    {
        mouseOver = false;
    }
    #endregion

    void DimmerOpen()
    {
        if (currentSlider == null)
        {
            currentSlider = Instantiate(slider, transform.GetChild(0));
            currentSliderBar = currentSlider.transform.GetChild(0).gameObject.GetComponent<Slider>();
        }
        currentSlider.transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        intensity = currentSliderBar.value;
    }

    void OnOpen()
    {
        currentButton = Instantiate(offBulb, transform.GetChild(1));
    }
}
