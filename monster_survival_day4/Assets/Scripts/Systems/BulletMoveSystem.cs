using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveSystem
{
    private GameEvent gameEvent;
    private List<BulletMoveComponent> bulletMoveComponentList = new List<BulletMoveComponent>();

    public BulletMoveSystem(GameEvent gameEvent)
    {
        this.gameEvent = gameEvent;
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

            if (bulletMoveComponent.transform.position.magnitude > 10)
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
