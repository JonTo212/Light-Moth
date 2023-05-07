using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoDOnOff : MonoBehaviour
{
    TwoDLight attachedLight;
    public Button button;
    public Sprite lightOn;
    public Sprite lightOff;

    void Start()
    {
        attachedLight = GetComponentInParent<TwoDLight>();
    }

    void Update()
    {
        if (attachedLight.isOn)
        {
            button.image.sprite = lightOn;
        }
        else if (!attachedLight.isOn)
        {
            button.image.sprite = lightOff;
        }
    }

    public void Switch()
    {
        attachedLight.isOn = !attachedLight.isOn;
    }
}
