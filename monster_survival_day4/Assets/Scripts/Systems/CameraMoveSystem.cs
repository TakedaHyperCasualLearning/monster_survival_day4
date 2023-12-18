using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveSystem
{
    private GameEvent gameEvent;
    private Transform playerTransform;
    private List<CameraMoveComponent> cameraMoveComponentList = new List<CameraMoveComponent>();

    public CameraMoveSystem(GameEvent gameEvent, Transform playerTransform)
    {
        this.gameEvent = gameEvent;
        this.playerTransform = playerTransform;

        gameEvent.AddComponent += AddComponent;
        gameEvent.RemoveComponent += RemoveComponent;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < cameraMoveComponentList.Count; i++)
        {
            CameraMoveComponent cameraMoveComponent = cameraMoveComponentList[i];
            if (!cameraMoveComponent.gameObject.activeSelf) continue;
            cameraMoveComponent.PlayerTransform = playerTransform;

            cameraMoveComponent.transform.position = new Vector3(cameraMoveComponent.PlayerTransform.position.x, cameraMoveComponent.PlayerTransform.position.y, cameraMoveComponent.PlayerTransform.position.z) + cameraMoveComponent.PositionOffset;
        }
    }

    private void AddComponent(GameObject gameObject)
    {
        CameraMoveComponent cameraMoveComponent = gameObject.GetComponent<CameraMoveComponent>();

        if (cameraMoveComponent == null) return;

        cameraMoveComponentList.Add(cameraMoveComponent);
    }

    private void RemoveComponent(GameObject gameObject)
    {
        CameraMoveComponent cameraMoveComponent = gameObject.GetComponent<CameraMoveComponent>();

        if (cameraMoveComponent == null) return;

        cameraMoveComponentList.Remove(cameraMoveComponent);
    }
}
