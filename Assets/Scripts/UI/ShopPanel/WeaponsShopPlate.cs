using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class WeaponsShopPlate : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyText;
        [SerializeField] private int _currentMoney;
        [SerializeField] private GameObject _menu;
        [SerializeField] private GameObject _shopMenu;
        [SerializeField] private GameObject _gameScene;
        [SerializeField] private GameObject _warning;
        [SerializeField] private Animator _animator;
        private const string MONEY_TEXT = "Your money: ";

        public static int WeaponsCanBuy = 3;

        public int CurrentMoney
        {
            get => _currentMoney;
            set
            {
                _currentMoney = value;
            }
        }

        private void Start()
        {
            _moneyText.text = MONEY_TEXT + _currentMoney;
            WeaponsCanBuy = 3;
        }

        public void SetMoney(int money)
        {
            _moneyText.text = MONEY_TEXT + money;
        }

        public void PlayGame()
        {
            if (WeaponsCanBuy < 3)
            {
                _shopMenu.SetActive(false);
                _menu.SetActive(false);
                _gameScene.SetActive(true);
            }
            else if (WeaponsCanBuy == 3)
            {
                _warning.GetComponent<Animator>().Play("WarningAppear");
            }
        }
    }
}