using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moth2D : MonoBehaviour
{
    Rigidbody rb;

    public float maxSpeed;
    public float speed;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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
                TwoDLight light = lights[i].GetComponent<TwoDLight>();

                if (light.isOn)
                {
                    Vector3 vectorTowardsLight = lights[i].transform.position - transform.position;

                    transform.position = Vector3.MoveTowards(transform.position, lights[i].transform.position, speed * light.intensity * Time.deltaTime);

                    //rb.AddForce(vectorTowardsLight.normalized * speed * light.intensity);
                    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

                    if (vectorTowardsLight.magnitude <= 0.1f)
                    {
                        rb.velocity = Vector3.zero;
                    }
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

