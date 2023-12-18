using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBaseComponent : MonoBehaviour
{
    private int attack = 0;

    public int Attack { get { return attack; } set { attack = value; } }
}
