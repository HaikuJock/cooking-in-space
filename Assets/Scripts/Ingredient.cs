using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Collectable") == false)
        {
            var orbit = gameObject.GetComponent<Orbit>();

            if (orbit != null)
            {
                orbit.orbitSpeed = 0f;
            }
        }
    }
}
