using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem
{
    private GameEvent gameEvent;
    private List<CharacterBaseComponent> characterBaseComponentList = new List<CharacterBaseComponent>();
    private List<DamageComponent> damageComponentList = new List<DamageComponent>();

    public DamageSystem(GameEvent gameEvent)
    {
        this.gameEvent = gameEvent;
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

            if (!damageComponent.IsDamage) return;

            Debug.Log("characterBaseComponent.HitPoint: " + characterBaseComponent.HitPoint);
            characterBaseComponent.HitPoint -= damageComponent.Damage;
            damageComponent.Damage = 0;
            damageComponent.IsDamage = false;

            if (characterBaseComponent.HitPoint <= 0)
            {
                gameEvent.ReleaseObject(characterBaseComponent.gameObject);
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
