using UnityEngine;

namespace Assets.Scripts
{
    public class BombThrovwer : MonoBehaviour
    {
        [SerializeField] private DroneBomb _bomb;
        [SerializeField] private DroneDetection _detection;

        private void OnEnable()
        {
            _detection.GotTargetPosition += Throw;
        }

        private void OnDisable()
        {
            _detection.GotTargetPosition -= Throw;
        }

        private void Throw()
        {
            _bomb.transform.parent = null;
            _bomb.enabled = true;
            _bomb.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}