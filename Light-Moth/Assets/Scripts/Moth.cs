using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moth : MonoBehaviour
{
    public float speed;
    public float radius;

    void FixedUpdate()
    {
        MoveTowards();
    }

    void MoveTowards()
    {
        Collider[] lights = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Light"));

        if (lights.Length > 0)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                Light light = lights[i].GetComponent<Light>();

                if (light.isOn)
                {
                    Vector3 vectorTowardsLight = lights[i].transform.position - transform.position;

                    transform.position = Vector3.MoveTowards(transform.position, lights[i].transform.position, speed * light.intensity * Time.deltaTime);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
