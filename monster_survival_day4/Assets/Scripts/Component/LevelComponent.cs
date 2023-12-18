using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComponent : MonoBehaviour
{
    private int level;
    private int experiencePoint;
    [SerializeField] private int experiencePointBorder;
    private int attackLevel;
    private int hitPointLevel;
    private float attackSpeedLevel;
    private bool isLevelUp;
    [SerializeField] private int rasingAttack;
    [SerializeField] private int rasingHitPoint;
    [SerializeField] private float rasingAttackSpeed;

    public int Level { get { return level; } set { level = value; } }
    public int ExperiencePoint { get { return experiencePoint; } set { experiencePoint = value; } }
    public int ExperiencePointBorder { get { return experiencePointBorder; } set { experiencePointBorder = value; } }
    public int AttackLevel { get { return attackLevel; } set { attackLevel = value; } }
    public int HitPointLevel { get { return hitPointLevel; } set { hitPointLevel = value; } }
    public float AttackSpeedLevel { get { return attackSpeedLevel; } set { attackSpeedLevel = value; } }
    public bool IsLevelUp { get { return isLevelUp; } set { isLevelUp = value; } }
    public int RasingAttack { get { return rasingAttack; } set { rasingAttack = value; } }
    public int RasingHitPoint { get { return rasingHitPoint; } set { rasingHitPoint = value; } }
    public float RasingAttackSpeed { get { return rasingAttackSpeed; } set { rasingAttackSpeed = value; } }
}
