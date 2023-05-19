using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "New item in shop", menuName = "Shop weapon card")]

    public class ItemInShopTemplate : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _price;
        [SerializeField] private int _priceForAmmo;

        public string Name => _name;
        public Sprite Sprite => _sprite;
        public int Price => _price;
        public int PriceForAmmo => _priceForAmmo;

    }
}