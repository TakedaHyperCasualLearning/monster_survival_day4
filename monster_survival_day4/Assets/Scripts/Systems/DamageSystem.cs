using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem
{
    private GameEvent gameEvent;
    private GameObject playerObject;
    private List<CharacterBaseComponent> characterBaseComponentList = new List<CharacterBaseComponent>();
    private List<DamageComponent> damageComponentList = new List<DamageComponent>();

    public DamageSystem(GameEvent gameEvent, GameObject playerObject)
    {
        this.gameEvent = gameEvent;
        this.playerObject = playerObject;

        gameEvent.AddComponent += AddComponent;
        gameEvent.RemoveComponent += RemoveComponent;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < characterBaseComponentList.Count; i++)
        {
            CharacterBaseComponent characterBaseComponent = characterBaseComponentList[i];
            DamageComponent damageComponent = damageComponentList[i];

            if (!characterBaseComponent.gameObject.activeSelf) continue;

            if (!damageComponent.IsDamage) continue;

            characterBaseComponent.HitPoint -= damageComponent.Damage;
            damageComponent.Damage = 0;
            damageComponent.IsDamage = false;

            if (characterBaseComponent.HitPoint <= 0)
            {
                gameEvent.ReleaseObject(characterBaseComponent.gameObject);
                playerObject.GetComponent<LevelComponent>().ExperiencePoint += 1;
                if (damageComponent.gameObject != playerObject) continue;
                gameEvent.GameOver();
            }
        }
    }

    public void AddComponent(GameObject gameObject)
    {
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();
        DamageComponent damageComponent = gameObject.GetComponent<DamageComponent>();

        if (characterBaseComponent == null || damageComponent == null) return;

        characterBaseComponentList.Add(characterBaseComponent);
        damageComponentList.Add(damageComponent);
    }

    public void RemoveComponent(GameObject gameObject)
    {
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();
        DamageComponent damageComponent = gameObject.GetComponent<DamageComponent>();

        if (characterBaseComponent == null || damageComponent == null) return;

        characterBaseComponentList.Remove(characterBaseComponent);
        damageComponentList.Remove(damageComponent);
    }
}
