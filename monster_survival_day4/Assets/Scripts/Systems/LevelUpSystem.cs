using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelUpSystem
{
    private GameEvent gameEvent;
    private GameObject playerObject;
    private int baseAttack;
    private int baseHitPoint;
    private float baseAttackSpeed;
    private List<LevelComponent> levelComponentList = new List<LevelComponent>();

    public LevelUpSystem(GameEvent gameEvent, GameObject playerObject)
    {
        this.gameEvent = gameEvent;
        this.playerObject = playerObject;
        gameEvent.AddComponent += AddComponent;
        gameEvent.RemoveComponent += RemoveComponent;
        gameEvent.LevelUp += LevelUp;
        gameEvent.IsLevelUp += () => playerObject.GetComponent<LevelComponent>().IsLevelUp;

        baseAttack = playerObject.GetComponent<CharacterBaseComponent>().Attack;
        baseHitPoint = playerObject.GetComponent<CharacterBaseComponent>().HitPoint;
        baseAttackSpeed = playerObject.GetComponent<ShotComponent>().ShotInterval;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < levelComponentList.Count; i++)
        {
            LevelComponent levelComponent = levelComponentList[i];

            if (!levelComponent.gameObject.activeSelf) continue;

            if (levelComponent.ExperiencePoint < levelComponent.ExperiencePointBorder) continue;

            levelComponent.Level += 1;
            levelComponent.ExperiencePoint -= levelComponent.ExperiencePointBorder;
            levelComponent.IsLevelUp = true;
        }
    }

    public void LevelUp()
    {
        for (int i = 0; i < levelComponentList.Count; i++)
        {
            LevelComponent levelComponent = levelComponentList[i];

            if (!levelComponent.gameObject.activeSelf) continue;

            if (!levelComponent.IsLevelUp) continue;

            playerObject.GetComponent<ShotComponent>().ShotInterval = baseAttackSpeed - (levelComponent.AttackSpeedLevel * levelComponent.RasingAttackSpeed);
            playerObject.GetComponent<CharacterBaseComponent>().Attack = baseAttack + (levelComponent.AttackLevel * levelComponent.RasingAttack);
            playerObject.GetComponent<CharacterBaseComponent>().HitPoint = baseHitPoint + (levelComponent.HitPointLevel * levelComponent.RasingHitPoint);
            playerObject.GetComponent<CharacterBaseComponent>().MaxHitPoint = baseHitPoint + (levelComponent.HitPointLevel * levelComponent.RasingHitPoint);


            Debug.Log("playerObject.GetComponent<ShotComponent>().ShotInterval: " + playerObject.GetComponent<ShotComponent>().ShotInterval);
            Debug.Log("playerObject.GetComponent<CharacterBaseComponent>().Attack: " + playerObject.GetComponent<CharacterBaseComponent>().Attack);
            Debug.Log("playerObject.GetComponent<CharacterBaseComponent>().HitPoint: " + playerObject.GetComponent<CharacterBaseComponent>().HitPoint);
            levelComponent.IsLevelUp = false;
        }
    }


    public void AddComponent(GameObject gameObject)
    {
        LevelComponent levelComponent = gameObject.GetComponent<LevelComponent>();

        if (levelComponent == null) return;

        levelComponentList.Add(levelComponent);
    }

    public void RemoveComponent(GameObject gameObject)
    {
        LevelComponent levelComponent = gameObject.GetComponent<LevelComponent>();

        if (levelComponent == null) return;

        levelComponentList.Remove(levelComponent);
    }
}
