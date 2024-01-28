using System.Collections;
using System.Collections.Generic;
using HPhysic;
using UnityEngine;

public class PlayerConnectorManager : MonoBehaviour
{
    private int _currentConnectionNum = 0;

    public Connector firstConnector;
    public Connector secondConnector;
    public Connector thirdConnector;
    public Connector fourthConnector;
    
    

    public void NewConnection(Connector connectorPoint)
    {
        if (_currentConnectionNum == 0)
            connectorPoint.SetAsConnectedTo(firstConnector);
        if (_currentConnectionNum == 1)
            connectorPoint.SetAsConnectedTo(secondConnector);
        if (_currentConnectionNum == 2)
            connectorPoint.SetAsConnectedTo(thirdConnector);
        if (_currentConnectionNum == 3)
            connectorPoint.SetAsConnectedTo(fourthConnector);
        _currentConnectionNum++;
    }
}
