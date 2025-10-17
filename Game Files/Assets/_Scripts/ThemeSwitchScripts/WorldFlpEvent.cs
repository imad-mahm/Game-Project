using System;
using UnityEngine;

public static class WorldFlipEvent
{
    //observer pattern
    public static event Action OnWorldFlipped;

    public static void TriggerWorldFlip()
    {
        OnWorldFlipped?.Invoke();
    }
}