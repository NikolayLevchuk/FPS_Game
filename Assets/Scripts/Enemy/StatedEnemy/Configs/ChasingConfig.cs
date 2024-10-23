using UnityEngine;

public class ChasingConfig : MonoBehaviour
{
    [SerializeField, Range(5, 10)] private float _speed;
    public float Speed => _speed;
}