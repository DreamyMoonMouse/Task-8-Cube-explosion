using UnityEngine;

public class Scaler : MonoBehaviour
{
    private float scaleFactor = 0.5f;

    public Vector3 Scale(Vector3 originalScale)
    {
        return originalScale * scaleFactor;
    }
}
