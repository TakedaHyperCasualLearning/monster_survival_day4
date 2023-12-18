using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColliderComponent : MonoBehaviour
{
    [SerializeField] private Transform transform;
    private Vector2 position;
    [SerializeField] private Vector2 size;

    public Transform Transform { get { return transform; } set { transform = value; } }
    public Vector2 Position { get { return position; } set { position = value; } }
    public Vector2 Size { get { return size; } set { size = value; } }
}
