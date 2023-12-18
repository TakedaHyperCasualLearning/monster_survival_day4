using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseComponent : MonoBehaviour
{
    [SerializeField] private int hitPoint = 0;
    private int maxHitPoint = 0;
    [SerializeField] private int attack = 0;

    public int HitPoint { get { return hitPoint; } set { hitPoint = value; } }
    public int MaxHitPoint { get { return maxHitPoint; } set { maxHitPoint = value; } }
    public int Attack { get { return attack; } set { attack = value; } }
}
