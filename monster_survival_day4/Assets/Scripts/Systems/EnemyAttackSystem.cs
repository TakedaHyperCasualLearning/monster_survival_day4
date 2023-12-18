using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSystem : MonoBehaviour
{
    private GameEvent gameEvent;
    private ObjectPool objectPool;
    private GameObject playerObject;
    private GameObject enemyPrefab;

    private float intervalTimer = 0.0f;
    private float interval = 0.5f;

    public EnemyAttackSystem(GameEvent gameEvent, ObjectPool objectPool, GameObject playerObject, GameObject enemyPrefab)
    {
        this.gameEvent = gameEvent;
        this.objectPool = objectPool;
        this.playerObject = playerObject;
        this.enemyPrefab = enemyPrefab;
    }

    public void OnUpdate()
    {
        if (intervalTimer < interval)
        {
            intervalTimer += Time.deltaTime;
            return;
        }

        List<GameObject> enemyList = objectPool.GetGameObjectList(enemyPrefab);
        if (enemyList == null) return;

        for (int i = 0; i < enemyList.Count; i++)
        {
            GameObject enemy = enemyList[i];
            if (!enemy.activeSelf) continue;

            ColliderComponent enemyColliderComponent = enemy.GetComponent<ColliderComponent>();
            ColliderComponent playerColliderComponent = playerObject.GetComponent<ColliderComponent>();

            if (!IsCollision(enemyColliderComponent, playerColliderComponent)) return;
            DamageComponent playerDamageComponent = playerObject.GetComponent<DamageComponent>();
            CharacterBaseComponent enemyCharacterBaseComponent = enemy.GetComponent<CharacterBaseComponent>();

            if (playerDamageComponent == null) continue;
            playerDamageComponent.Damage += enemyCharacterBaseComponent.Attack;
            playerDamageComponent.IsDamage = true;
            intervalTimer = 0.0f;
            return;
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
