using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AK.Wwise.Event SomeSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SomeSound.Post(gameObject);
        }
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                SomeSound.Post(gameObject);
            }
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    SomeSound.Post(gameObject);
                }
                {
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        SomeSound.Post(gameObject);
                    }
                }
            }
        }
    }
}
