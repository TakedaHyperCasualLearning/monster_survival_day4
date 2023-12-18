using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    private GameEvent gameEvent;

    private PlayerInputSystem playerInputSystem;
    private CharacterMoveSystem characterMoveSystem;

    void Start()
    {
        gameEvent = new GameEvent();

        playerInputSystem = new PlayerInputSystem(gameEvent);
        characterMoveSystem = new CharacterMoveSystem(gameEvent);

        GameObject player = Instantiate(playerPrefab);
        gameEvent.AddComponent(player);
    }

    void Update()
    {
        playerInputSystem.OnUpdate();
        characterMoveSystem.OnUpdate();
    }
}
