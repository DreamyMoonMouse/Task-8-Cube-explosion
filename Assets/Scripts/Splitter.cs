using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    private const float splitChanceDecay = 0.5f;
    private const int minObjects = 2;
    private const int maxObjects = 6;

    public float GetNewSplitChance(float currentSplitChance)
    {
        return currentSplitChance * splitChanceDecay;
    }

    public int GetSplitCount()
    {
        return Random.Range(minObjects, maxObjects + 1);
    }
}
