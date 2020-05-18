using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour
{

    public CTargetController target;

    public enum Direction { Center = 0, Left, Right }
    public Direction direction = Direction.Center;

    //void Start()
    //{
    //    SetDirection(direction);
    //}

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        direction = Direction.Left;
    //    }
    //    else if (Input.GetMouseButtonDown(1))
    //    {
    //        direction = Direction.Right;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        direction = Direction.Center;
    //    }
    //    SetDirection(direction);
    //}

    private void SetDirection(Direction dir)
    {
        if (direction == Direction.Center)
            target.SetDirection(0f);
        else if (direction == Direction.Left)
            target.SetDirection(1f);
        else if (direction == Direction.Right)
            target.SetDirection(-1f);
    }

}
