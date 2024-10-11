using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube cubePrefab;
    [SerializeField] private Explosion explosionPrefab;
    
    private int _minNewCubes = 2;
    private int _maxNewCubes = 6;
    private int _scaleDenominator = 2;
    
    public void OnCubeClicked(Cube clickedCube)
    {
        Vector3 spawnPosition = clickedCube.transform.position;
        float randomValue = Random.value;
        
         if (randomValue <= clickedCube.SplitChance)
         {
            SpawnNewCubes(spawnPosition, clickedCube.transform.localScale / _scaleDenominator,clickedCube.SplitChance);
         }
         
        explosionPrefab.Explode(clickedCube);
        Destroy(clickedCube.gameObject); 
    }
    
    private void SpawnNewCubes(Vector3 parentPosition, Vector3 scale,float splitChance)
    {
        int newCubesCount = Random.Range(_minNewCubes, _maxNewCubes + 1);
        float minHeightAboveTerrain = 0.1f;

        for (int i = 0; i < newCubesCount; i++)
        {
            Vector3 newPosition = parentPosition + Random.insideUnitSphere;
            newPosition.y = Mathf.Max(newPosition.y, minHeightAboveTerrain);
            Cube newCube = Instantiate(cubePrefab);
            newCube.Initialize(newPosition, scale, splitChance);
            Rigidbody cubeRigidbody = newCube.GetComponent<Rigidbody>();
            
            if (cubeRigidbody != null)
            {
                explosionPrefab.RegisterCube(cubeRigidbody);
            }
        }
    }
}
