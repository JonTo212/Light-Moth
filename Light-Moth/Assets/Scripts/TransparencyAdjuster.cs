using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyAdjuster : MonoBehaviour
{
    Color brightness;
    LightObject attachedLight;
    // Start is called before the first frame update
    void Start()
    {
        brightness = GetComponent<MeshRenderer>().material.color;
        attachedLight = GetComponentInParent<LightObject>();
    }

    // Update is called once per frame
    void Update()
    {
        brightness.a = attachedLight.intensity;
        this.GetComponent<MeshRenderer>().material.color = brightness;
    }
}
