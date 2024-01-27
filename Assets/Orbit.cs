using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float orbitSpeed = 10f;
    void Update()
    {
        Vector3 point = new Vector3(0,0,0);
        Vector3 axis = new Vector3(0,1, 0);
        transform.RotateAround(point, axis, Time.deltaTime * orbitSpeed);
    }
}
