using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _range; 
    public bool Grounded { get; private set; }

    private void Update()
    {
        Grounded = Physics.Raycast(transform.position, -transform.up, _range, _ground);
    }
}