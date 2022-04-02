using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoSingleton<EventManager>
{
    public static event Action RandomColorSpawned;
    public static event Action OnPressedColor;

    public static event Action OnDropColor;

    public void SpawnRandomColor()
    {
        RandomColorSpawned?.Invoke();
    }

    public void ClickColor()
    {
        OnPressedColor?.Invoke();
    }

    public void PopColor()
    {
        OnDropColor?.Invoke();
    }
}
