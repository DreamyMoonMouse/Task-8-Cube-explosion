using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody prefab;
    
    private float splitChance = 1.0f;
    private Spawner spawner;
    private ExplosionHandler explosionHandler;
    private Splitter splitter;
    private Scaler scaler;
    
    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        explosionHandler = FindObjectOfType<ExplosionHandler>();
        splitter = FindObjectOfType<Splitter>();
        scaler = FindObjectOfType<Scaler>();
    }

    private void OnMouseDown()
    {
        float randomValue = Random.value;
        Debug.Log($"Log: Random.value: {randomValue}, splitChance: {splitChance}");
        
        if (randomValue < splitChance)
        {
            Vector3 newScale = scaler.Scale(transform.localScale);
            List<Rigidbody> newObjects = spawner.SpawnNewCubes(prefab, transform.position, newScale, splitter.GetNewSplitChance(splitChance));
            explosionHandler.ApplyExplosionForce(newObjects, transform.position);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void SetSplitChance(float chance)
    {
        splitChance = chance;
    }
}

