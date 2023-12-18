using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveComponent : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction;

    public float Speed { get { return speed; } set { speed = value; } }
    public Vector3 Direction { get { return direction; } set { direction = value; } }
}
