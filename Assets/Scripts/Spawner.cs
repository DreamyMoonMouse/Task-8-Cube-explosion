using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    private Splitter splitter;

    private void Start()
    {
        splitter = FindObjectOfType<Splitter>();
    }

    public List<Rigidbody> SpawnNewCubes(Rigidbody prefab, Vector3 spawnPosition, Vector3 scale, float newSplitChance)
    {
        int range = splitter.GetSplitCount();
        float minHeightAboveTerrain = 0.5f;
        List<Rigidbody> newObjects = new List<Rigidbody>();

        for (int i = 0; i < range; i++)
        {
            Vector3 newPosition = spawnPosition + Random.insideUnitSphere;
            newPosition.y = Mathf.Max(newPosition.y, minHeightAboveTerrain);
            Rigidbody newObject = Instantiate(prefab, newPosition, Random.rotation);
            newObject.transform.localScale = scale;
            newObject.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
            Controller controller = newObject.GetComponent<Controller>();
            controller.SetSplitChance(newSplitChance);
            newObjects.Add(newObject);
        }

        return newObjects;
    }
}
