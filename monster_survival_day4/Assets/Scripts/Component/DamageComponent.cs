using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    private int damage = 0;
    private bool isDamage = false;

    public int Damage { get { return damage; } set { damage = value; } }
    public bool IsDamage { get { return isDamage; } set { isDamage = value; } }
}
