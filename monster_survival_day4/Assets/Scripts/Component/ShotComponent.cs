using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotComponent : MonoBehaviour
{
    private float shotSpeed;
    [SerializeField] private float shotSpeedInterval;

    public float ShotSpeed { get { return shotSpeed; } set { shotSpeed = value; } }
    public float ShotSpeedInterval { get { return shotSpeedInterval; } set { shotSpeedInterval = value; } }
}
