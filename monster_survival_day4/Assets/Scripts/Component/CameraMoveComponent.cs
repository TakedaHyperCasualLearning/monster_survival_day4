using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMoveComponent : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private Vector3 positionOffset;

    public Transform PlayerTransform { get { return playerTransform; } set { playerTransform = value; } }
    public Vector3 PositionOffset { get { return positionOffset; } set { positionOffset = value; } }
}
