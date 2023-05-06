using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    GameObject currentObj;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
        currentObj = this.gameObject;
    }

    void Update()
    {
        currentObj.transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
