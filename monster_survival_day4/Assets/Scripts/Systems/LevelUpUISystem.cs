using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpUISystem
{
    private GameEvent gameEvent;
    private GameObject playerObject;
    private List<LevelUpUIComponent> levelUpUIComponentList = new List<LevelUpUIComponent>();

    public LevelUpUISystem(GameEvent gameEvent, GameObject playerObject)
    {
        this.gameEvent = gameEvent;
        this.playerObject = playerObject;
        gameEvent.AddComponent += AddComponent;
        gameEvent.RemoveComponent += RemoveComponent;
    }

    public void Initialize()
    {
        for (int i = 0; i < levelUpUIComponentList.Count; i++)
        {
            LevelUpUIComponent levelUpUIComponent = levelUpUIComponentList[i];

            levelUpUIComponent.AttackButton.onClick.AddListener(() =>
            {
                playerObject.GetComponent<LevelComponent>().AttackLevel += 1;
                gameEvent.LevelUp();
            });
            levelUpUIComponent.SpeedButton.onClick.AddListener(() =>
            {
                playerObject.GetComponent<LevelComponent>().AttackSpeedLevel += 1;
                gameEvent.LevelUp();
            });
            levelUpUIComponent.HpButton.onClick.AddListener(() =>
            {
                playerObject.GetComponent<LevelComponent>().HitPointLevel += 1;
                gameEvent.LevelUp();
            });
        }
    }

    public void OnUpdate()
    {
        for (int i = 0; i < levelUpUIComponentList.Count; i++)
        {
            LevelUpUIComponent levelUpUIComponent = levelUpUIComponentList[i];
            if (playerObject.GetComponent<LevelComponent>().IsLevelUp)
            {
                levelUpUIComponent.gameObject.SetActive(true);
            }
            else
            {
                levelUpUIComponent.gameObject.SetActive(false);
            }
        }
    }


    public void AddComponent(GameObject gameObject)
    {
        LevelUpUIComponent levelUpUIComponent = gameObject.GetComponent<LevelUpUIComponent>();

        if (levelUpUIComponent == null) return;

        levelUpUIComponentList.Add(levelUpUIComponent);
    }

    public void RemoveComponent(GameObject gameObject)
    {
        LevelUpUIComponent levelUpUIComponent = gameObject.GetComponent<LevelUpUIComponent>();

        if (levelUpUIComponent == null) return;

        levelUpUIComponentList.Remove(levelUpUIComponent);
    }

}
