using UnityEngine;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Spawner _spawnerPrefab;
    
    private float _explosionForce = 5f;
    private List<Rigidbody> _spawnedCubes = new List<Rigidbody>();
    
    public void OnEnable()
    {
        _spawnerPrefab.CubeTriggered.AddListener(HandleCubeExplosion);
    }

    public void RegisterCube(Rigidbody cubeRigidbody)
    {
        _spawnedCubes.Add(cubeRigidbody);
    }
    
    private void HandleCubeExplosion(Cube clickedCube)
        {
            Explode(clickedCube);
            Destroy(clickedCube.gameObject);
        }
    
    private void Explode(Cube clickedCube)
    {
        Vector3 explosionPosition = clickedCube.transform.position;
        
        foreach (Rigidbody rigidbody in _spawnedCubes)
        {
            if (rigidbody != null && rigidbody.gameObject != clickedCube.gameObject)
            {
                Vector3 direction = (rigidbody.transform.position - explosionPosition).normalized;
                rigidbody.AddForce(direction * _explosionForce, ForceMode.Impulse);
            }
        }
    }
}
