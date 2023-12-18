using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitPointUIComponent : MonoBehaviour
{
    [SerializeField] private GameObject hitPointUIPrefab;
    private TextMeshPro hitPointUI;
    [SerializeField] private Vector3 positionOffset = new Vector3(0, 0, 0);

    public GameObject HitPointUIPrefab { get { return hitPointUIPrefab; } set { hitPointUIPrefab = value; } }
    public TextMeshPro HitPointUI { get { return hitPointUI; } set { hitPointUI = value; } }
    public Vector3 PositionOffset { get { return positionOffset; } set { positionOffset = value; } }
}
