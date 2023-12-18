using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUIComponent : MonoBehaviour
{
    [SerializeField] private Button attackButton;
    [SerializeField] private Button hpButton;
    [SerializeField] private Button speedButton;

    public Button AttackButton { get { return attackButton; } set { attackButton = value; } }
    public Button HpButton { get { return hpButton; } set { hpButton = value; } }
    public Button SpeedButton { get { return speedButton; } set { speedButton = value; } }

}
