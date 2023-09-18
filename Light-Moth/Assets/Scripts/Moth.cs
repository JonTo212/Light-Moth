using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moth : MonoBehaviour
{
    public float speed;
    public float radius;
    LightObject[] activeLights;
    public Rigidbody rb;

    void FixedUpdate()
    {
        GetLights();
    }

    void GetLights()
    {
        Collider[] lights = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Light"));
        activeLights = new LightObject[lights.Length];

        if (lights.Length > 0)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                LightObject light = lights[i].GetComponent<LightObject>();

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
        //transform.position = Vector3.MoveTowards(transform.position, target, intensity * speed * Time.deltaTime);
        if (target != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }

        print(target);
        rb.AddForce(target);
    }

    Vector3 newPos;
    float newIntensity;

    void GetUsableLights(LightObject[] lights)
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
