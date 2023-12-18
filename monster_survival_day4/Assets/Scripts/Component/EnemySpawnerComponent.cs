using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerComponent : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval;
    private float spawnTimer;
    [SerializeField] private Vector3 spawnOffset = new Vector3(0, 0, 0);

    public GameObject EnemyPrefab { get { return enemyPrefab; } set { enemyPrefab = value; } }
    public float SpawnInterval { get { return spawnInterval; } set { spawnInterval = value; } }
    public float SpawnTimer { get { return spawnTimer; } set { spawnTimer = value; } }
    public Vector3 SpawnOffset { get { return spawnOffset; } set { spawnOffset = value; } }
}
