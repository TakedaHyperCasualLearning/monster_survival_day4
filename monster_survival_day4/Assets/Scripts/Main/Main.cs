using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;

    private GameEvent gameEvent;

    private PlayerInputSystem playerInputSystem;
    private CharacterMoveSystem characterMoveSystem;
    private PlayerAttackSystem playerAttackSystem;
    void Start()
    {
        gameEvent = new GameEvent();

        playerInputSystem = new PlayerInputSystem(gameEvent);
        characterMoveSystem = new CharacterMoveSystem(gameEvent);
        playerAttackSystem = new PlayerAttackSystem(gameEvent);

        GameObject player = Instantiate(playerPrefab);
        gameEvent.AddComponent(player);

        GameObject enemy = Instantiate(enemyPrefab);
        gameEvent.AddComponent(enemy);
        enemy.GetComponent<CharacterMoveComponent>().TargetTransform = player.transform;
    }

    void Update()
    {
        playerInputSystem.OnUpdate();
        characterMoveSystem.OnUpdate();
        playerAttackSystem.OnUpdate();
    }
}
