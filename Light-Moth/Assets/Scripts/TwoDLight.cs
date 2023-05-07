using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoDLight : MonoBehaviour
{
    public float intensity;
    public bool isOn;
    public Camera cam;
    bool mouseOver;

    public GameObject sliderCanvas;
    private GameObject currentSlider;
    private Slider currentSliderBar;
    public GameObject buttonCanvas;
    private GameObject currentButton;
    private Button OnOffSwitch;

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
        if (mouseOver && Input.GetMouseButtonDown(0) && currentButton == null)
        {
            OnOffOpen();
        }
        else if (mouseOver && Input.GetMouseButtonDown(0) && currentButton != null && !isOn)
        {
            Destroy(currentButton);
        }
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
            currentSlider = Instantiate(sliderCanvas, transform.GetChild(0));
            currentSliderBar = currentSlider.transform.GetChild(0).gameObject.GetComponent<Slider>();
        }
        currentSlider.transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        intensity = currentSliderBar.value;
    }

    public void OnOffOpen()
    {
        if (currentButton == null)
        {
            currentButton = Instantiate(buttonCanvas, transform.GetChild(1));
            //currentButton.transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
            //OnOffSwitch = currentButton.transform.GetChild(0).gameObject.GetComponent<Button>();
        }
    }
}
