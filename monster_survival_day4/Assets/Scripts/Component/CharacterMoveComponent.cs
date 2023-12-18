using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveComponent : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction = Vector3.zero;

    public float Speed { get { return speed; } set { speed = value; } }
    public Vector3 Direction { get { return direction; } set { direction = value; } }
}
