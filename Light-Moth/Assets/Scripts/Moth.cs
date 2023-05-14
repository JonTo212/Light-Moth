using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moth : MonoBehaviour
{
    public float speed;
    public float radius;
    Light[] activeLights;
    float[] activeLightIntensities;

    void FixedUpdate()
    {
        GetLights();
    }

    void GetLights()
    {
        Collider[] lights = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Light"));
        activeLights = new Light[lights.Length];
        activeLightIntensities = new float[lights.Length];
        Vector3 centerPoint = Vector3.zero;

        if (lights.Length > 0)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                Light light = lights[i].GetComponent<Light>();

                if (light.isOn)
                {
                    //MoveTo(lights[i].transform.position, light.intensity);
                    activeLights[i] = light;
                    activeLightIntensities[i] = light.intensity;
                    centerPoint = GetCenterPoint(activeLights);
                }
            }
        }
        MoveTo(centerPoint);
    }

    void MoveTo(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    Vector3 GetCenterPoint(Light[] lights)
    {
        Vector3 center = Vector3.zero;
        float count = 0;
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i] != null)
            {
                Vector3 newPos = lights[i].transform.position * lights[i].intensity;

                if (newPos != Vector3.zero)
                {
                    center += lights[i].transform.position * lights[i].intensity;
                    count++;
                }
            }
        }
        center = center / count;

        if (float.IsNaN(center.x))
        {
            return transform.position;
        }
        return center;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
