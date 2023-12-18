using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemySpawner;

    private GameEvent gameEvent;
    private ObjectPool objectPool;

    private EnemySpawnerSystem enemySpawnerSystem;

    private PlayerInputSystem playerInputSystem;
    private CharacterMoveSystem characterMoveSystem;
    private PlayerAttackSystem playerAttackSystem;

    private BulletMoveSystem bulletMoveSystem;
    void Start()
    {
        gameEvent = new GameEvent();

        GameObject player = Instantiate(playerPrefab);

        objectPool = new ObjectPool(gameEvent);
        enemySpawnerSystem = new EnemySpawnerSystem(gameEvent, objectPool, player.transform);

        playerInputSystem = new PlayerInputSystem(gameEvent);
        characterMoveSystem = new CharacterMoveSystem(gameEvent);
        playerAttackSystem = new PlayerAttackSystem(gameEvent, objectPool);

        bulletMoveSystem = new BulletMoveSystem(gameEvent);

        gameEvent.AddComponent(player);
        gameEvent.AddComponent(enemySpawner);
    }

    void Update()
    {
        playerInputSystem.OnUpdate();
        characterMoveSystem.OnUpdate();
        playerAttackSystem.OnUpdate();
        enemySpawnerSystem.OnUpdate();
        bulletMoveSystem.OnUpdate();
    }
}
