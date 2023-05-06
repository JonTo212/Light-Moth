using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    Light attachedLight;
    SphereCollider hitbox;
    bool mouseOver;
    public GameObject bulb;

    void Start()
    {
        attachedLight = GetComponentInParent<Light>();
        hitbox = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (mouseOver && Input.GetMouseButtonDown(0) && !attachedLight.isOn)
        {
            attachedLight.isOn = true;
            Instantiate(bulb, this.gameObject.transform.parent);
            Destroy(this.gameObject);
        }
        else if (mouseOver && Input.GetMouseButtonDown(0) && attachedLight.isOn)
        {
            attachedLight.isOn = false;
            Instantiate(bulb, this.gameObject.transform.parent);
            Destroy(this.gameObject);
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
}
