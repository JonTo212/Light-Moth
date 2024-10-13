using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMoth : MonoBehaviour
{
    public Transform respawn;
    LightObject[] lights;
    LightObject attachedLight;

    void Start()
    {
        attachedLight = GetComponentInParent<LightObject>();
        lights = FindObjectsOfType<LightObject>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (attachedLight.isOn)
        {
            if (other.tag == "Player")
            {
                other.transform.position = respawn.position;
                other.attachedRigidbody.velocity = Vector3.zero;
                other.transform.rotation = Quaternion.identity;

                attachedLight.isOn = false;
                attachedLight.intensity = 0;
                Destroy(attachedLight.currentButton);
            }

            foreach (LightObject light in lights)
            {
                if (light.isOn)
                {
                    light.isOn = false;
                    light.intensity = 0;
                    Destroy(light.currentButton);
                }
            }
        }
    }
}
