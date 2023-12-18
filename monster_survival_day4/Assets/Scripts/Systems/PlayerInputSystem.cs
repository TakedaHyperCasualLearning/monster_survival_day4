using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSystem
{
    List<CharacterMoveComponent> characterMoveComponentList = new List<CharacterMoveComponent>();
    List<InputComponent> inputComponentList = new List<InputComponent>();
    GameEvent gameEvent;

    public PlayerInputSystem(GameEvent gameEvent)
    {
        this.gameEvent = gameEvent;

        gameEvent.AddComponent += AddComponent;
        gameEvent.RemoveComponent += RemoveComponent;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < characterMoveComponentList.Count; i++)
        {
            CharacterMoveComponent characterMoveComponent = characterMoveComponentList[i];
            if (!characterMoveComponent.gameObject.activeSelf) continue;

            Movement(characterMoveComponent);
            MouseClick(inputComponentList[i]);
        }
    }

    private void Movement(CharacterMoveComponent moveComponent)
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) direction += Vector3.left;
        if (Input.GetKey(KeyCode.D)) direction += Vector3.right;
        if (Input.GetKey(KeyCode.W)) direction += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) direction += Vector3.back;

        moveComponent.Direction = direction;
    }

    private void MouseClick(InputComponent inputComponent)
    {
        if (Input.GetMouseButton(0))
        {
            inputComponent.IsClick = true;
            inputComponent.MousePosition = Input.mousePosition;
            return;
        }
        inputComponent.IsClick = false;
    }

    public void AddComponent(GameObject gameObject)
    {
        CharacterMoveComponent characterMoveComponent = gameObject.GetComponent<CharacterMoveComponent>();
        InputComponent inputComponent = gameObject.GetComponent<InputComponent>();

        if (characterMoveComponent == null || inputComponent == null) return;

        characterMoveComponentList.Add(characterMoveComponent);
        inputComponentList.Add(inputComponent);
    }

    public void RemoveComponent(GameObject gameObject)
    {
        CharacterMoveComponent characterMoveComponent = gameObject.GetComponent<CharacterMoveComponent>();
        InputComponent inputComponent = gameObject.GetComponent<InputComponent>();

        if (characterMoveComponent == null || inputComponent == null) return;

        characterMoveComponentList.Remove(characterMoveComponent);
        inputComponentList.Remove(inputComponent);
    }
}
