using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    
    private float explosionForce = 300f;
    private float explosionRadius = 2f;
    private float splitChance = 1.0f;
    private const float splitChanceDecay = 0.5f;
    private const int minObjects = 2;
    private const int maxObjects = 6;

    private void OnMouseDown()
    {
        float randomValue = Random.value;
        Debug.Log($"Log: Random.value: {randomValue}, splitChance: {splitChance}");
        
        if (randomValue < splitChance)
        {
            List<GameObject> newObjects = CreateNewObjects();
            ApplyExplosionForce(newObjects);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private List<GameObject> CreateNewObjects()
    {
        int range = Random.Range(minObjects, maxObjects + 1);
        float minHeightAboveTerrain = 0.5f;
        float scaleFactor = 0.5f;
        float newSplitChance = splitChance * splitChanceDecay;
        List<GameObject> newObjects = new List<GameObject>();

        for (int i = 0; i < range; i++)
        {
            Vector3 newPosition = transform.position + Random.insideUnitSphere;
            newPosition.y = Mathf.Max(newPosition.y, minHeightAboveTerrain);
            GameObject newObject = Instantiate(prefab, newPosition, Random.rotation);
            newObject.transform.localScale = transform.localScale *  scaleFactor;
            newObject.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
            Controller controller = newObject.GetComponent<Controller>();
            controller.splitChance= newSplitChance;
            newObjects.Add(newObject);
        }

        return newObjects;
    }
    private void ApplyExplosionForce(List<GameObject> objects)
    {
        foreach (GameObject newObject in objects)
        {
            Rigidbody rigidbody = newObject.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }
}

