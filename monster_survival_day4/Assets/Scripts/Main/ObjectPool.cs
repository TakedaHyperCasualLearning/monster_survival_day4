using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool
{
    private Dictionary<int, List<GameObject>> pool = new Dictionary<int, List<GameObject>>();

    public GameObject GetObject(GameObject gameObject)
    {
        int instanceID = gameObject.GetInstanceID();

        if (pool.ContainsKey(instanceID))
        {
            List<GameObject> gameObjectList = pool[instanceID];

            for (int i = 0; i < gameObjectList.Count; i++)
            {
                if (!gameObjectList[i].activeSelf)
                {
                    gameObjectList[i].SetActive(true);
                    gameObjectList[i].transform.position = Vector3.zero;
                    gameObjectList[i].active = true;
                    return gameObjectList[i];
                }
            }

            GameObject newGameObject = GameObject.Instantiate(gameObject);
            newGameObject.SetActive(true);
            gameObjectList.Add(newGameObject);
            return newGameObject;
        }
        else
        {
            List<GameObject> gameObjectList = new List<GameObject>();
            GameObject newGameObject = GameObject.Instantiate(gameObject);
            newGameObject.SetActive(true);
            gameObjectList.Add(newGameObject);
            pool.Add(instanceID, gameObjectList);
            return newGameObject;
        }
    }
}
