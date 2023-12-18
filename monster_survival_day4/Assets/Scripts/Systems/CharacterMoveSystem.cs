using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveSystem
{
    private GameEvent gameEvent;
    List<CharacterMoveComponent> characterMoveComponentList = new List<CharacterMoveComponent>();

    public CharacterMoveSystem(GameEvent gameEvent)
    {
        this.gameEvent = gameEvent;

        gameEvent.AddComponent += AddComponent;
        gameEvent.RemoveComponent += RemoveComponent;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < characterMoveComponentList.Count; i++)
        {
            CharacterMoveComponent characterMoveComponent = characterMoveComponentList[i];
            if (!characterMoveComponent.gameObject.activeSelf) continue;

            if (characterMoveComponent.IsLookAtTarget)
            {
                characterMoveComponent.gameObject.transform.LookAt(characterMoveComponent.TargetTransform);
            }

            if (characterMoveComponent.IsChase)
            {
                characterMoveComponent.Direction = Vector3.forward;
            }

            characterMoveComponent.gameObject.transform.Translate(characterMoveComponent.Direction * characterMoveComponent.Speed * Time.deltaTime, Space.Self);
        }
    }

    private void AddComponent(GameObject gameObject)
    {
        CharacterMoveComponent characterMoveComponent = gameObject.GetComponent<CharacterMoveComponent>();

        if (characterMoveComponent == null) return;

        characterMoveComponentList.Add(characterMoveComponent);
    }

    private void RemoveComponent(GameObject gameObject)
    {
        CharacterMoveComponent characterMoveComponent = gameObject.GetComponent<CharacterMoveComponent>();

        if (characterMoveComponent == null) return;

        characterMoveComponentList.Remove(characterMoveComponent);
    }

}
