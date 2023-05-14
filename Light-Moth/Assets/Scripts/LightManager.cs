using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    GameObject[] lightObjects;
    List<GameObject> usableLights;
    List<Light> lights;
    Moth moth;
    float distance;

    void Start()
    {
        moth = GameObject.FindGameObjectWithTag("Player").GetComponent<Moth>();
        lights = new List<Light>();
        lightObjects = GameObject.FindGameObjectsWithTag("Light");
        usableLights = new List<GameObject>();
        foreach (GameObject go in lightObjects)
        {
            if (go.GetComponent<Light>() != null && (Vector3.Distance(go.transform.position, moth.transform.position) <= moth.radius))
            {
                lights.Add(go.GetComponent<Light>());
                usableLights.Add(go);
            }
        }
    }
}
