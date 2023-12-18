using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject cameraObject;
    [SerializeField] GameObject enemySpawner;

    private GameEvent gameEvent;
    private ObjectPool objectPool;

    private EnemySpawnerSystem enemySpawnerSystem;
    private EnemyAttackSystem enemyAttackSystem;

    private PlayerInputSystem playerInputSystem;
    private CharacterMoveSystem characterMoveSystem;
    private PlayerAttackSystem playerAttackSystem;

    private BulletMoveSystem bulletMoveSystem;
    private BulletHitSystem bulletHitSystem;

    private CameraMoveSystem cameraMoveSystem;

    private DamageSystem damageSystem;

    void Start()
    {
        gameEvent = new GameEvent();

        GameObject player = Instantiate(playerPrefab);

        objectPool = new ObjectPool(gameEvent);
        enemySpawnerSystem = new EnemySpawnerSystem(gameEvent, objectPool, player.transform);
        enemyAttackSystem = new EnemyAttackSystem(gameEvent, objectPool, player, enemyPrefab);

        playerInputSystem = new PlayerInputSystem(gameEvent);
        characterMoveSystem = new CharacterMoveSystem(gameEvent);
        playerAttackSystem = new PlayerAttackSystem(gameEvent, objectPool);

        bulletMoveSystem = new BulletMoveSystem(gameEvent, player.transform);
        bulletHitSystem = new BulletHitSystem(gameEvent, objectPool, bulletPrefab, enemyPrefab);

        cameraMoveSystem = new CameraMoveSystem(gameEvent, player.transform);

        damageSystem = new DamageSystem(gameEvent);

        gameEvent.AddComponent(player);
        gameEvent.AddComponent(cameraObject);
        gameEvent.AddComponent(enemySpawner);
    }

    void Update()
    {
        playerInputSystem.OnUpdate();
        characterMoveSystem.OnUpdate();
        playerAttackSystem.OnUpdate();
        enemySpawnerSystem.OnUpdate();
        bulletMoveSystem.OnUpdate();
        bulletHitSystem.OnUpdate();
        enemyAttackSystem.OnUpdate();
        damageSystem.OnUpdate();
        cameraMoveSystem.OnUpdate();
    }
}
