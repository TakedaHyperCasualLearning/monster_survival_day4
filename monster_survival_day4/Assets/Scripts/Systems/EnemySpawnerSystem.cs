using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerSystem
{
    private GameEvent gameEvent;
    private ObjectPool objectPool;
    private Transform playerTransform;
    private List<EnemySpawnerComponent> enemySpawnerComponentList = new List<EnemySpawnerComponent>();

    private Vector3 screenSize = new Vector3(0, 0, 0);

    public EnemySpawnerSystem(GameEvent gameEvent, ObjectPool objectPool, Transform playerTransform)
    {
        this.gameEvent = gameEvent;
        this.objectPool = objectPool;
        this.playerTransform = playerTransform;

        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10.0f));
        Debug.Log(screenSize);

        gameEvent.AddComponent += AddComponent;
        gameEvent.RemoveComponent += RemoveComponent;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < enemySpawnerComponentList.Count; i++)
        {
            EnemySpawnerComponent enemySpawnerComponent = enemySpawnerComponentList[i];
            if (!enemySpawnerComponent.gameObject.activeSelf) continue;

            enemySpawnerComponent.SpawnTimer += Time.deltaTime;
            if (enemySpawnerComponent.SpawnTimer > enemySpawnerComponent.SpawnInterval)
            {
                enemySpawnerComponent.SpawnTimer = 0;
                GameObject tempObject = objectPool.GetObject(enemySpawnerComponent.EnemyPrefab);
                Vector3 spawnPosition = new Vector3(Random.Range(screenSize.x, screenSize.x + enemySpawnerComponent.SpawnOffset.x), 0, Random.Range(screenSize.y, screenSize.y + enemySpawnerComponent.SpawnOffset.y));
                spawnPosition *= Random.Range(0, 2) == 0 ? 1 : -1;
                spawnPosition = playerTransform.position + spawnPosition;
                tempObject.transform.position = spawnPosition;
                tempObject.GetComponent<CharacterMoveComponent>().TargetTransform = playerTransform;
                if (objectPool.IsNewGenerate)
                {
                    gameEvent.AddComponent(tempObject);
                    objectPool.IsNewGenerate = false;
                }
            }
        }
    }

    private void AddComponent(GameObject gameObject)
    {
        EnemySpawnerComponent enemySpawnerComponent = gameObject.GetComponent<EnemySpawnerComponent>();

        if (enemySpawnerComponent == null) return;

        enemySpawnerComponentList.Add(enemySpawnerComponent);
    }

    private void RemoveComponent(GameObject gameObject)
    {
        EnemySpawnerComponent enemySpawnerComponent = gameObject.GetComponent<EnemySpawnerComponent>();

        if (enemySpawnerComponent == null) return;

        enemySpawnerComponentList.Remove(enemySpawnerComponent);
    }
}
