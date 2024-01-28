using System;
using System.Collections;
using System.Collections.Generic;
using HPhysic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class PlayerConnectorManager : MonoBehaviour
{
    private int _currentConnectionNum = 0;

    public Connector firstConnector;
    public Connector secondConnector;
    public Connector thirdConnector;
    public Connector fourthConnector;

    public Material playerOneMaterial;
    public Material playerTwoMaterial;
    public Material playerThreeMaterial;
    public Material playerFourMaterial;

    public Material ringOne;
    public Material ringTwo;
    public Material ringThree;
    public Material ringFour;

    public GameObject firstCable;
    public GameObject secondCable;

    private void Start()
    {
        firstCable.SetActive(false);
        secondCable.SetActive(false);
    }

    public void NewConnection(Connector connectorPoint, MeshRenderer player, MeshRenderer ring)
    {

        if (_currentConnectionNum == 0)
        {
            firstCable.SetActive(true);
            connectorPoint.SetAsConnectedTo(firstConnector);
            player.material = playerOneMaterial;
            ring.material = ringOne;
        }
        if (_currentConnectionNum == 1)
        {
            connectorPoint.SetAsConnectedTo(secondConnector);
            player.material = playerTwoMaterial;
            ring.material = ringTwo;

        }        
        if (_currentConnectionNum == 2)
        {
            secondCable.SetActive(true);
            connectorPoint.SetAsConnectedTo(thirdConnector);
            player.material = playerThreeMaterial;
            ring.material = ringThree;

        }        
        if (_currentConnectionNum == 3)
        {
            connectorPoint.SetAsConnectedTo(fourthConnector);
            player.material = playerFourMaterial;
            ring.material = ringFour;

        }        
        _currentConnectionNum++;
    }
}
