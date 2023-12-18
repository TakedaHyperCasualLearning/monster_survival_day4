using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitSystem
{
    private GameEvent gameEvent;
    private ObjectPool objectPool;
    private GameObject bulletPrefab;
    private GameObject enemyPrefab;

    public BulletHitSystem(GameEvent gameEvent, ObjectPool objectPool, GameObject bulletPrefab, GameObject enemyPrefab)
    {
        this.gameEvent = gameEvent;
        this.objectPool = objectPool;
        this.bulletPrefab = bulletPrefab;
        this.enemyPrefab = enemyPrefab;
    }

    public void OnUpdate()
    {
        List<GameObject> enemyList = objectPool.GetGameObjectList(enemyPrefab);
        List<GameObject> bulletList = objectPool.GetGameObjectList(bulletPrefab);

        if (enemyList == null || bulletList == null) return;

        for (int i = 0; i < bulletList.Count; i++)
        {
            GameObject bullet = bulletList[i];
            if (!bullet.activeSelf) continue;

            for (int j = 0; j < enemyList.Count; j++)
            {
                GameObject enemy = enemyList[j];
                if (!enemy.activeSelf) continue;

                if (!IsCollision(bullet.GetComponent<ColliderComponent>(), enemy.GetComponent<ColliderComponent>())) continue;
                BulletBaseComponent bulletBaseComponent = bullet.GetComponent<BulletBaseComponent>();
                DamageComponent enemyDamageComponent = enemy.GetComponent<DamageComponent>();

                if (bulletBaseComponent == null || enemyDamageComponent == null) continue;
                enemyDamageComponent.Damage += bulletBaseComponent.Attack;
                enemyDamageComponent.IsDamage = true;
                gameEvent.ReleaseObject(bullet);
            }
        }
    }

    private bool IsCollision(ColliderComponent colliderComponent, ColliderComponent targetColliderComponent)
    {
        Vector3 distance = colliderComponent.Transform.position - targetColliderComponent.Transform.position;
        distance.y = 0.0f;
        float distanceMagnitude = distance.magnitude;
        float radiusSum = colliderComponent.Size.x + targetColliderComponent.Size.x;


        // Debug.Log("distanceMagnitude: " + distanceMagnitude);
        // Debug.Log("radiusSum: " + radiusSum);

        if (distanceMagnitude < radiusSum) return true;

        return false;
    }
}
