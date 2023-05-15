using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moth : MonoBehaviour
{
    public float speed;
    public float radius;
    Light[] activeLights;

    void FixedUpdate()
    {
        GetLights();
    }

    void GetLights()
    {
        Collider[] lights = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Light"));
        activeLights = new Light[lights.Length];

        if (lights.Length > 0)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                Light light = lights[i].GetComponent<Light>();

                if (light.isOn)
                {
                    activeLights[i] = light;
                }
            }
            GetUsableLights(activeLights);
            MoveTo(newPos, newIntensity);
        }
    }

    void MoveTo(Vector3 target, float intensity)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, intensity * speed * Time.deltaTime);
    }

    Vector3 newPos;
    float newIntensity;

    void GetUsableLights(Light[] lights)
    {
        newPos = Vector3.zero;
        newIntensity = 0;
        float count = 0;
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i] != null && lights[i].intensity != 0)
            {
                newPos += lights[i].transform.position * lights[i].intensity;
                newIntensity += lights[i].intensity;
                count++;
            }
        }
        if (newIntensity != 0)
        {
            newPos = newPos / newIntensity;
            newIntensity = newIntensity / count;
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
