using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinHandler : MonoBehaviour
{
    private PlayerInputManager inputManager;
GameObject player1;
 GameObject player2;
 GameObject player3;
 GameObject player4;
public GameObject playerPrefab2;
public GameObject playerPrefab3;
public GameObject playerPrefab4;
 
    void OnPlayerJoined(PlayerInput input)
    {  
			Debug.Log("OnPlayerJoined");
        if (player1 == null)
        {
            player1 = input.gameObject;
            inputManager.playerPrefab = playerPrefab2;          
        } 
        else if (player2 == null)
        {
            player2 = input.gameObject;     
            inputManager.playerPrefab = playerPrefab3;     
        }      
        else if (player3 == null)
        {
            player3 = input.gameObject;     
            inputManager.playerPrefab = playerPrefab4;     
        }      
        else if (player4 == null)
        {
            player4 = input.gameObject;     
        }      
    }
    
    // Start is called before the first frame update
    void Start()
    {
        inputManager = gameObject.GetComponent<PlayerInputManager>();

        inputManager.onPlayerJoined += OnPlayerJoined;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
