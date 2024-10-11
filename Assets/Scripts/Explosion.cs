using UnityEngine;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    private float _explosionForce = 5f;
    private List<Rigidbody> _spawnedCubes = new List<Rigidbody>();

    public void RegisterCube(Rigidbody cubeRigidbody)
    {
        _spawnedCubes.Add(cubeRigidbody);
    }
    public void Explode(Cube clickedCube)
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
