using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    private int _bunCount;
    private int _burgerCount;
    private int _cheeseCount;

    [SerializeField] private float _relaunchForceMin, _relaunchForceMax;
    [SerializeField] private TMP_Text inventoryText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _bunCount = 0;
        _burgerCount = 0;
        _cheeseCount = 0;
    }

    void Update()
    {
        inventoryText.text = "Buns: " + _bunCount + "\nBurgers: " + _burgerCount + "\nCheese: " + _cheeseCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            print(other.gameObject.name);
            if (other.gameObject.name == "Burger(Clone)")
            {
                if (_burgerCount >= 3)
                {
                    ReLaunchItem(other.gameObject);
                }
                else
                {
                    Destroy(other.gameObject);
                    _burgerCount++;
                }
            }
            
        }
    }

    private void ReLaunchItem(GameObject obj)
    {
        var randomDirection = Random.rotation;
        var objRB = obj.GetComponent<Rigidbody>();

        obj.transform.rotation = randomDirection;
        objRB.AddForce( transform.forward * Random.Range(_relaunchForceMin, _relaunchForceMax));
    }
}
