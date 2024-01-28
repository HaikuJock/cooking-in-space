using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHappy : MonoBehaviour
{
    public Animator alienController;
    public float alienShowTime = 0.5f;
    
    // Start is called before the first frame update
    public void MakeAlienHappy()
    {
        alienController.SetBool("IsHappy", true);
        StartCoroutine(AlienDelay());
    }

    private IEnumerator AlienDelay()
    {
        yield return new WaitForSeconds(alienShowTime);
        alienController.SetBool("IsHappy", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
