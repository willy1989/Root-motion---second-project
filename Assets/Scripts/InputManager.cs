using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool MoveRightButtonDown()
    {
        return Input.GetKeyDown(KeyCode.D);
    }

    public bool MoveLeftButtonDown()
    {
        return Input.GetKeyDown(KeyCode.A);
    }

    public bool MoveRightButton()
    {
        return Input.GetKey(KeyCode.D);
    }

    public bool MoveLeftButton()
    {
        return Input.GetKey(KeyCode.A);
    }

    public bool MoveRightButtonUp()
    {
        return Input.GetKeyUp(KeyCode.D);
    }

    public bool MoveLeftButtonUp()
    {
        return Input.GetKeyUp(KeyCode.A);
    }

    public bool ShiftDown()
    {
        return Input.GetKeyDown(KeyCode.LeftShift);
    }

    public bool Shift()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    public bool ShiftUp()
    {
        return Input.GetKeyUp(KeyCode.LeftShift);
    }

    public bool SpaceDown()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
