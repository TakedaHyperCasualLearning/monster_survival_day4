using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveComponent : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction = Vector3.zero;
    [SerializeField] private bool isChase = false;
    [SerializeField] private bool isLookAtTarget = false;
    private Vector3 targetTransform;

    public float Speed { get { return speed; } set { speed = value; } }
    public Vector3 Direction { get { return direction; } set { direction = value; } }
    public bool IsChase { get { return isChase; } set { isChase = value; } }
    public bool IsLookAtTarget { get { return isLookAtTarget; } set { isLookAtTarget = value; } }
    public Vector3 TargetTransform { get { return targetTransform; } set { targetTransform = value; } }
}
