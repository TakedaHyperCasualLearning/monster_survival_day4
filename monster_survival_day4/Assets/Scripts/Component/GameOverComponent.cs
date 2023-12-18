using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverComponent : MonoBehaviour
{
    private bool isGameOver;

    public bool IsGameOver { get { return isGameOver; } set { isGameOver = value; } }
}
