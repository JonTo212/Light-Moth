using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMoth : MonoBehaviour
{
    public Transform respawn;
    LightObject attachedLight;

    void Start()
    {
        attachedLight = GetComponentInParent<LightObject>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = respawn.position;
            attachedLight.isOn = false;
            attachedLight.intensity = 0;
            Destroy(attachedLight.currentButton);
        }
    }
}
