using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveSystem
{
    private GameEvent gameEvent;
    private Transform playerTransform;
    private List<BulletMoveComponent> bulletMoveComponentList = new List<BulletMoveComponent>();

    public BulletMoveSystem(GameEvent gameEvent, Transform playerTransform)
    {
        this.gameEvent = gameEvent;
        this.playerTransform = playerTransform;

        gameEvent.AddComponent += AddComponent;
        gameEvent.RemoveComponent += RemoveComponent;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < bulletMoveComponentList.Count; i++)
        {
            BulletMoveComponent bulletMoveComponent = bulletMoveComponentList[i];
            if (!bulletMoveComponent.gameObject.activeSelf) continue;

            bulletMoveComponent.transform.Translate(bulletMoveComponent.Direction * bulletMoveComponent.Speed * Time.deltaTime);

            float magnitude = (bulletMoveComponent.transform.position - playerTransform.position).magnitude;
            if (magnitude > 10)
            {
                gameEvent.ReleaseObject(bulletMoveComponent.gameObject);
            }
        }
    }

    private void AddComponent(GameObject gameObject)
    {
        BulletMoveComponent bulletMoveComponent = gameObject.GetComponent<BulletMoveComponent>();

        if (bulletMoveComponent == null) return;

        bulletMoveComponentList.Add(bulletMoveComponent);
    }

    private void RemoveComponent(GameObject gameObject)
    {
        BulletMoveComponent bulletMoveComponent = gameObject.GetComponent<BulletMoveComponent>();

        if (bulletMoveComponent == null) return;

        bulletMoveComponentList.Remove(bulletMoveComponent);
    }
}
