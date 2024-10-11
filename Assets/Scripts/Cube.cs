using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    
    public float SplitChance { get; private set; } = 1f;
    private float _chanceDenominator = 2f;
    
    private void OnMouseDown()
        {
            spawner.OnCubeClicked(this);
        }
    public void Initialize(Vector3 position, Vector3 scale, float splitChance)
    {
        transform.position = position;
        transform.localScale = scale;
        SplitChance = splitChance/_chanceDenominator;
        SetRandomColor();
    }
    
    private void SetRandomColor()
    {
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }
}

