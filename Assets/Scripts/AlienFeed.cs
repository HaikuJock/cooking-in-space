using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienFeed : MonoBehaviour
{
    public string order;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            if (other.gameObject.name == order)
            {
                Destroy(other.gameObject);
                Satisfaction.Score += Random.Range(50, 100);
                GameObject.Find("AlienYay").GetComponent<AlienHappy>().MakeAlienHappy();
                Destroy(gameObject);
            }
        }
    }
}
