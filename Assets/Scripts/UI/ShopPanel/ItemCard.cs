using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{
    public class ItemCard : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private TMP_Text _priceForAmmo;
        [SerializeField] private Image _icon;
        [SerializeField] private ItemInShopTemplate _template;
        [SerializeField] private GameObject _weapon;
        [SerializeField] private WeaponsShopPlate _shopPlate;
        [SerializeField] private Transform _handPosition;
        private int _timesCanBuyAmmo = 3;
        private bool _canBuyWeapon = true;
        private bool _canBuyAmmo;

        private void Start()
        {
            _shopPlate = GetComponentInParent<WeaponsShopPlate>();
            _name.text = _template.Name;
            _price.text = " Cost:" + _template.Price;
            _icon.sprite = _template.Sprite;
            _priceForAmmo.text = "$" + _template.PriceForAmmo;
        }

        public void ClickOnCard()
        {
            if (_shopPlate.CurrentMoney >= _template.Price && _canBuyWeapon && WeaponsShopPlate.WeaponsCanBuy > 0)
            {
                _canBuyWeapon = false;
                _canBuyAmmo = true;
                WeaponsShopPlate.WeaponsCanBuy--;
                _shopPlate.CurrentMoney -= _template.Price;
                _shopPlate.SetMoney(_shopPlate.CurrentMoney);

                _weapon.transform.parent = _handPosition;
                _weapon.transform.localPosition = Vector3.zero;
                _weapon.transform.localRotation = Quaternion.identity;
            }
        }

        public void BuyAmmo()
        {
            if (_shopPlate.CurrentMoney >= _template.PriceForAmmo && _canBuyAmmo && _timesCanBuyAmmo > 0)
            {
                _timesCanBuyAmmo--;
                _shopPlate.CurrentMoney -= _template.PriceForAmmo;
                _shopPlate.SetMoney(_shopPlate.CurrentMoney);
                _weapon.GetComponent<GunSystem>().MagazineCount++;
            }
        }
    }
}