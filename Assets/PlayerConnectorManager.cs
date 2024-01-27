using System.Collections;
using System.Collections.Generic;
using HPhysic;
using UnityEngine;

public class PlayerConnectorManager : MonoBehaviour
{
    private int _currentConnectionNum = 0;

    public Connector firstConnector;
    public Connector secondConnector;
    
    
    

    public void NewConnection(Connector connectorPoint)
    {
        if (_currentConnectionNum == 0)
            connectorPoint.SetAsConnectedTo(firstConnector);
        if (_currentConnectionNum == 1)
            connectorPoint.SetAsConnectedTo(secondConnector);
        _currentConnectionNum++;
    }
}
