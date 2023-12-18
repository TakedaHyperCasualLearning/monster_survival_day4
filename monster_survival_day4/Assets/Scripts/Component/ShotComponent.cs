using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotComponent : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    private float shotTimer;
    [SerializeField] private float shotInterval;

    public GameObject BulletPrefab { get { return bulletPrefab; } set { bulletPrefab = value; } }
    public float ShotTimer { get { return shotTimer; } set { shotTimer = value; } }
    public float ShotInterval { get { return shotInterval; } set { shotInterval = value; } }
}
