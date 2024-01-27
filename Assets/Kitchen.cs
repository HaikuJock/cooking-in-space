using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Cryptography;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class Kitchen : MonoBehaviour
{
    public static int Score;
    [SerializeField] private TMP_Text scoreDisplayText;
    [SerializeField] private int _bunCount;
    [SerializeField] private int _pattyCount;
    [SerializeField] private int _cheeseCount;
    public GameObject burgerPrefab;
    
    [SerializeField] private float _relaunchForceMin, _relaunchForceMax;
    [SerializeField] private TMP_Text inventoryText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _bunCount = 0;
        _pattyCount = 0;
        _cheeseCount = 0;
    }

    void Update()
    {
        inventoryText.text = "Buns: " + _bunCount + "\nPattys: " + _pattyCount + "\nCheese: " + _cheeseCount;
        scoreDisplayText.text = "Score: " + Score;
        
        if (_pattyCount > 0 && _bunCount > 0 && _cheeseCount > 0)
        {
            Instantiate(burgerPrefab, new Vector3(0, 1.4f, 0), quaternion.identity);
            ReLaunchItem(burgerPrefab);
            _pattyCount--;
            _bunCount--;
            _cheeseCount--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            if (other.gameObject.name == "Patty(Clone)")
            {
                if (_pattyCount >= 3)
                {
                    ReLaunchItem(other.gameObject);
                }
                else
                {
                    Destroy(other.gameObject);
                    _pattyCount++;
                }
            }
            else if (other.gameObject.name == "Bun(Clone)")
            {
                if (_bunCount >= 3)
                {
                    ReLaunchItem(other.gameObject);
                }
                else
                {
                    Destroy(other.gameObject);
                    _bunCount++;
                }
            }
            else if (other.gameObject.name == "Cheese(Clone)")
            {
                if (_cheeseCount >= 3)
                {
                    ReLaunchItem(other.gameObject);
                }
                else
                {
                    Destroy(other.gameObject);
                    _cheeseCount++;
                }
            }
            
        }
    }
 
    private void ReLaunchItem(GameObject obj)
    {
        var objRB = obj.GetComponent<Rigidbody>();
        var pos = new Vector3(0, 1.4f, 0);
        obj.transform.position = pos;
        objRB.AddRelativeForce(Random.onUnitSphere * Random.Range(_relaunchForceMin, _relaunchForceMax));
    }
}
