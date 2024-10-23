using System.Collections;
using UnityEngine;
using TMPro;
using System.Linq;

namespace Assets.Scripts
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private Transform _hand;
        [SerializeField] private KeyCode[] _keysForSwitch;
        [SerializeField] private GameObject _hitEffectPrefab;

        [Header("Animation")]
        [SerializeField] private Animator _animator;

        [Header("UI")]
        [SerializeField] private TMP_Text _currentBullets;
        [SerializeField] private TMP_Text _BulletsAll;


        private int _currentWeapon = 0;
        private IWeaponable[] _weapons;

        void Start()
        {
            _weapons = new IWeaponable[_hand.childCount];
            if (_weapons.Count() > 0)
            {
                for (int i = 0; i < _hand.childCount; i++)
                {
                    _weapons[i] = _hand.GetChild(i).GetComponent<IWeaponable>();
                }
                _weapons[0].gameObject.SetActive(true);
            }
        }

        void Update()
        {
            CheckSwitch();
            //ShowAmmo();
        }

        private void CheckSwitch()
        {
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    _currentWeapon--;
                }
                else if (Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    _currentWeapon++;
                }

                _currentWeapon = Mathf.Clamp(_currentWeapon, 0, _weapons.Length - 1);

                _animator.Play("Switch");
                StartCoroutine(nameof(SwitchTimer));
            }

            for (int i = 0; i < _weapons.Length; i++)
            {
                if (Input.GetKeyDown(_keysForSwitch[i]))
                {
                    if (_currentWeapon != i)
                    {
                        _currentWeapon = i;

                        _animator.Play("Switch");
                        StartCoroutine(nameof(SwitchTimer));
                    }
                    break;
                }
            }
        }

        private IEnumerator SwitchTimer()
        {
            yield return new WaitForSeconds(0.5f);
            SwitchWeapon();
        }

        private void ShowAmmo()
        {
            _currentBullets.text = _weapons[_currentWeapon].CurrentRounds + " / " + _weapons[_currentWeapon].RoundsAmount;
            _BulletsAll.text = _weapons[_currentWeapon].AllRounrs.ToString();
        }

        private void SwitchWeapon()
        {
            if (_weapons.Length > 0)
            {
                for (int i = 0; i < _weapons.Length; i++)
                {
                    _weapons[i].gameObject.SetActive(false);
                }
                _weapons[_currentWeapon].gameObject.SetActive(true);
            }
        }
    }
}