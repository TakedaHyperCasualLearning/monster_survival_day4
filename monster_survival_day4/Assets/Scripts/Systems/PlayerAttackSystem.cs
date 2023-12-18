using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAttackSystem
{
    private GameEvent gameEvent;
    List<InputComponent> inputComponentList = new List<InputComponent>();
    List<ShotComponent> shotComponentList = new List<ShotComponent>();

    public PlayerAttackSystem(GameEvent gameEvent)
    {
        this.gameEvent = gameEvent;
        gameEvent.AddComponent += OnAddComponent;
        gameEvent.RemoveComponent += OnRemoveComponent;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < inputComponentList.Count; i++)
        {
            InputComponent inputComponent = inputComponentList[i];
            if (!inputComponent.gameObject.activeSelf) continue;

            if (inputComponent.IsClick)
            {
                Debug.Log("Attack");
            }
        }
    }

    private void OnAddComponent(GameObject gameObject)
    {
        InputComponent inputComponent = gameObject.GetComponent<InputComponent>();
        ShotComponent shotComponent = gameObject.GetComponent<ShotComponent>();

        if (inputComponent == null || shotComponent == null) return;

        inputComponentList.Add(inputComponent);
        shotComponentList.Add(shotComponent);
    }

    private void OnRemoveComponent(GameObject gameObject)
    {
        InputComponent inputComponent = gameObject.GetComponent<InputComponent>();
        ShotComponent shotComponent = gameObject.GetComponent<ShotComponent>();

        if (inputComponent == null || shotComponent == null) return;

        inputComponentList.Remove(inputComponent);
    }
}
