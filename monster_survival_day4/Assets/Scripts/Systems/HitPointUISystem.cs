using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitPointUISystem
{
    private GameEvent gameEvent;
    private TextMeshProUGUI hitPointUIPrefab;
    private Canvas canvas;
    private List<HitPointUIComponent> hitPointUIComponentList = new List<HitPointUIComponent>();
    private List<CharacterBaseComponent> characterBaseComponentList = new List<CharacterBaseComponent>();

    public HitPointUISystem(GameEvent gameEvent, Canvas canvas, TextMeshProUGUI hitPointUIPrefab)
    {
        this.gameEvent = gameEvent;
        this.canvas = canvas;
        this.hitPointUIPrefab = hitPointUIPrefab;

        gameEvent.AddComponent += AddComponent;
        gameEvent.RemoveComponent += RemoveComponent;
        gameEvent.Initialize += Initialize;
    }

    public void Initialize(GameObject gameObject)
    {
        HitPointUIComponent hitPointUIComponent = gameObject.GetComponent<HitPointUIComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (hitPointUIComponent == null || characterBaseComponent == null) return;

        // GameObject textObject = GameObject.Instantiate(hitPointUIComponent.HitPointUIPrefab, hitPointUIComponent.gameObject.transform);
        // TextMeshPro hitPointUI = textObject.GetComponent<TextMeshPro>();
        // hitPointUIComponent.HitPointUI = hitPointUI;
        // hitPointUIComponent.HitPointUI.transform.position = hitPointUIComponent.PositionOffset;
        // hitPointUIComponent.HitPointUI.GetComponent<RectTransform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
        // hitPointUIComponent.HitPointUI.text = "HP :" + characterBaseComponent.HitPoint;


    }

    public void OnUpdate()
    {
        for (int i = 0; i < hitPointUIComponentList.Count; i++)
        {
            HitPointUIComponent hitPointUIComponent = hitPointUIComponentList[i];
            CharacterBaseComponent characterBaseComponent = characterBaseComponentList[i];

            if (!characterBaseComponent.gameObject.activeSelf) continue;
            int hitPoint = characterBaseComponent.HitPoint;
            int maxHitPoint = characterBaseComponent.MaxHitPoint;

            // hitPointUIComponent.HitPointUI.text = "HP :" + hitPoint;
            // hitPointUIComponent.HitPointUI.transform.position = characterBaseComponent.transform.position + hitPointUIComponent.PositionOffset;

            // hitPointUIPrefab.text = "HP :" + hitPoint + "/" + maxHitPoint;
            // hitPointUIPrefab.transform.position = new Vector3(characterBaseComponent.transform.position.x, characterBaseComponent.transform.position.y, 0.0f) + hitPointUIComponent.PositionOffset;

            // hitPointUIComponent.HitPointUI.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    private void AddComponent(GameObject gameObject)
    {
        HitPointUIComponent hitPointUIComponent = gameObject.GetComponent<HitPointUIComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (hitPointUIComponent == null || characterBaseComponent == null) return;

        hitPointUIComponentList.Add(hitPointUIComponent);
        characterBaseComponentList.Add(characterBaseComponent);
    }

    private void RemoveComponent(GameObject gameObject)
    {
        HitPointUIComponent hitPointUIComponent = gameObject.GetComponent<HitPointUIComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (hitPointUIComponent == null || characterBaseComponent == null) return;

        hitPointUIComponentList.Remove(hitPointUIComponent);
        characterBaseComponentList.Remove(characterBaseComponent);
    }
}
