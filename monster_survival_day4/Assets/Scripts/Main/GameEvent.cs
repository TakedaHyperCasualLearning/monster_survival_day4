using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent
{
    public Action<GameObject> AddComponent;
    public Action<GameObject> RemoveComponent;
    public Action<GameObject> ReleaseObject;
    public Action LevelUp;
    public Func<bool> IsLevelUp;
    public Action<GameObject> Initialize;
    public Action GameOver;
}
