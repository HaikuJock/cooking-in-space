using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RopeSpawn : MonoBehaviour
{
    [SerializeField] 
    private GameObject partPrefab, parentObject;

    [SerializeField] 
    [Range(1, 1000)]
    private int length = 1;
    
    [SerializeField] 
    private float partDistance = 0.21f;

    [SerializeField] 
    private bool reset, spawn, snapFirst, snapLast;

    private void Update()
    {
        if (reset)
        {
            foreach (var tap in GameObject.FindGameObjectsWithTag("Player"))
            {
                Destroy(tap);
            }

            if (spawn)
            {
                Spawn();
                spawn = false;
            }
        }
    }

    public void Spawn()
    {
        int count = (int)(length / partDistance);

        for (int x = 0; x < count; x++)
        {
            var tap = Instantiate(partPrefab,new Vector3(transform.position.x, transform.position.y + partDistance * (x + 1), transform.position.z), Quaternion.identity, parentObject.transform);
            tap.transform.eulerAngles = new Vector3(100, 0, 0);
            
            tap.name = parentObject.transform.childCount.ToString();

            if (x == 0)
            {
                Destroy(tap.GetComponent<CharacterJoint>());
            }
            else
            {
                tap.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent
                    <Rigidbody>();
            }
        }
    }
}
