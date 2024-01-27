using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Player")]
    public float moveSpeed = 2.0f;
    private float _speed;
    
    
    public void TetherMove(Vector3 vec)
    {
        _controller.Move(vec);
        //_controller.rig(vec);
    }
}
