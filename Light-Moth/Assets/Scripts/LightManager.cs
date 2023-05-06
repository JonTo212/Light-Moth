using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    GameObject[] lightObjects;
    GameObject[] usableLights;
    List<Light> lights;
    Moth moth;

    void Start()
    {
        moth = GameObject.FindGameObjectWithTag("Player").GetComponent<Moth>();
        lights = new List<Light>();
        lightObjects = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject go in lightObjects)
        {
            if (go.GetComponent<Light>() != null)
            {
                lights.Add(go.GetComponent<Light>());
            }
        }
    }

    void Update()
    {
        UsableLights();
    }

    void UsableLights()
    {
        foreach (Light light in lights)
        {
            if (Vector3.Distance(light.transform.position, moth.transform.position) <= moth.radius)
            {
                //light.OnOffOpen();
            }
        }
    }
}
