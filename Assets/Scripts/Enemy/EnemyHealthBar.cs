using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Image _fillingImage;
        [SerializeField] private Gradient _gradient;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void SetMaxHealth(int setMaxHealth)
        {
            _fillingImage.fillAmount = setMaxHealth / 100f;
            _fillingImage.color = _gradient.Evaluate(_fillingImage.fillAmount);
        }

        public void SetHealth(int setHealth)
        {
            _fillingImage.fillAmount = setHealth / 100f;
            _fillingImage.color = _gradient.Evaluate(_fillingImage.fillAmount);
        }

        private void LateUpdate()
        {
            transform.LookAt(new Vector3(_camera.transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
        }
    }
}
