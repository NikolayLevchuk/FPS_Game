using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _fillingImage;
        [SerializeField] private Gradient _gradient;
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
    }
}