using System;
using System.Collections;
using System.Collections.Generic;
using HPhysic;
using UnityEngine;

public class ConnectPlayer : MonoBehaviour
{
    private PlayerConnectorManager _playerConnectorManager;
    [SerializeField] private Connector _myConnector;
    
    private void Awake()
    {
        _playerConnectorManager = GameObject.Find("Player Connector Manager").GetComponent<PlayerConnectorManager>();
        _playerConnectorManager.NewConnection(_myConnector);
    }
}
