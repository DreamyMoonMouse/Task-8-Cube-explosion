using UnityEngine;
using System.Collections.Generic;

public class ExplosionHandler : MonoBehaviour
{
    private float explosionForce = 300f;
    private float explosionRadius = 2f;

    public void ApplyExplosionForce(List<Rigidbody> objects, Vector3 explosionPosition)
    {
        foreach (Rigidbody newObject in objects)
        {
            Rigidbody rigidbody = newObject.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
            }
        }
    }
}
