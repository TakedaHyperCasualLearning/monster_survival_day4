using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSystem
{
    private GameEvent gameEvent;
    private List<GameOverComponent> gameOverComponentList = new List<GameOverComponent>();

    public GameOverSystem(GameEvent gameEvent)
    {
        this.gameEvent = gameEvent;
        gameEvent.AddComponent += AddComponent;
        gameEvent.RemoveComponent += RemoveComponent;
        gameEvent.GameOver += GameOver;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < gameOverComponentList.Count; i++)
        {
            GameOverComponent gameOverComponent = gameOverComponentList[i];

            if (!gameOverComponent.gameObject.activeSelf) continue;

            if (!gameOverComponent.IsGameOver) continue;

            if (Input.GetMouseButtonDown(0))
            {

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
            }
        }
    }

    public void AddComponent(GameObject gameObject)
    {
        GameOverComponent gameOverComponent = gameObject.GetComponent<GameOverComponent>();

        if (gameOverComponent == null) return;

        gameOverComponentList.Add(gameOverComponent);
    }

    public void RemoveComponent(GameObject gameObject)
    {
        GameOverComponent gameOverComponent = gameObject.GetComponent<GameOverComponent>();

        if (gameOverComponent == null) return;

        gameOverComponentList.Remove(gameOverComponent);
    }

    public void GameOver()
    {
        for (int i = 0; i < gameOverComponentList.Count; i++)
        {
            GameOverComponent gameOverComponent = gameOverComponentList[i];

            gameOverComponent.IsGameOver = true;
            gameOverComponent.gameObject.SetActive(true);
        }
    }
}
