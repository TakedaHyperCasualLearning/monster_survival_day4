using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAttackSystem
{
    private GameEvent gameEvent;
    private ObjectPool objectPool;
    List<InputComponent> inputComponentList = new List<InputComponent>();
    List<ShotComponent> shotComponentList = new List<ShotComponent>();

    public PlayerAttackSystem(GameEvent gameEvent, ObjectPool objectPool)
    {
        this.gameEvent = gameEvent;
        this.objectPool = objectPool;

        gameEvent.AddComponent += OnAddComponent;
        gameEvent.RemoveComponent += OnRemoveComponent;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < inputComponentList.Count; i++)
        {
            InputComponent inputComponent = inputComponentList[i];
            if (!inputComponent.gameObject.activeSelf) continue;

            ShotComponent shotComponent = shotComponentList[i];
            if (shotComponent.ShotTimer < shotComponent.ShotInterval)
            {
                shotComponent.ShotTimer += Time.deltaTime;
                return;
            }

            if (!inputComponent.IsClick) return;

            shotComponent.ShotTimer = 0;
            GameObject tempObject = objectPool.GetObject(shotComponent.BulletPrefab);
            tempObject.transform.position = inputComponent.gameObject.transform.position;
            tempObject.GetComponent<BulletMoveComponent>().Direction = inputComponent.gameObject.transform.forward;
            if (objectPool.IsNewGenerate)
            {
                gameEvent.AddComponent(tempObject);
                objectPool.IsNewGenerate = false;
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
