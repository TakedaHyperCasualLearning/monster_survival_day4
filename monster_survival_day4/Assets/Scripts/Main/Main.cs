using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject cameraObject;
    [SerializeField] GameObject enemySpawner;
    [SerializeField] GameObject LevelUpUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] Canvas UICanvas;
    [SerializeField] TextMeshProUGUI hitPointText;
    [SerializeField] TextMeshPro hitPointTextMeshPro;

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
    private LevelUpSystem levelUpSystem;
    private LevelUpUISystem levelUpUISystem;
    private GameOverSystem gameOverSystem;

    private HitPointUISystem hitPointUISystem;

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

        damageSystem = new DamageSystem(gameEvent, player);
        levelUpSystem = new LevelUpSystem(gameEvent, player);
        levelUpUISystem = new LevelUpUISystem(gameEvent, player);
        gameOverSystem = new GameOverSystem(gameEvent);

        hitPointUISystem = new HitPointUISystem(gameEvent, UICanvas, hitPointText);

        gameEvent.AddComponent(player);
        gameEvent.AddComponent(cameraObject);
        gameEvent.AddComponent(enemySpawner);
        gameEvent.AddComponent(LevelUpUI);
        gameEvent.AddComponent(gameOverUI);

        levelUpUISystem.Initialize();
        hitPointUISystem.Initialize(player);
    }

    void Update()
    {
        levelUpSystem.OnUpdate();
        levelUpUISystem.OnUpdate();
        if (gameEvent.IsLevelUp()) return;
        damageSystem.OnUpdate();
        playerInputSystem.OnUpdate();
        characterMoveSystem.OnUpdate();
        playerAttackSystem.OnUpdate();
        enemySpawnerSystem.OnUpdate();
        bulletMoveSystem.OnUpdate();
        bulletHitSystem.OnUpdate();
        enemyAttackSystem.OnUpdate();
        cameraMoveSystem.OnUpdate();
        hitPointUISystem.OnUpdate();
        gameOverSystem.OnUpdate();
    }
}
