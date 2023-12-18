using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private Vector2 mousePosition;
    private bool isClick;

    public Vector2 MousePosition { get { return mousePosition; } set { mousePosition = value; } }
    public bool IsClick { get { return isClick; } set { isClick = value; } }

}
