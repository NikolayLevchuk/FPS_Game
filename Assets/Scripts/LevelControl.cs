using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class LevelControl : MonoBehaviour  
    {
        [SerializeField] private TMP_Text _destroyedTargetsAndCountOfTargets;
        [SerializeField] private List<GameObject> _targetsNeetToKill;
        [SerializeField] private List<GameObject> _targetsCanGoAway;
        [SerializeField] private GameObject _menusPlate;
        [SerializeField] private GameObject _player;

        private int _destroyedTargets = 0;
        private int _allTargets;        

        public event Action LevelDone;
        public event Action LevelFailed; 

        private void Start()
        {
            _player.GetComponent<Health>().PlayerDead += ActivateLoosePanel;
            for (int i = 0; i < _targetsCanGoAway.Count; i++)
            {
                _targetsCanGoAway[i].GetComponent<IRunawayable>().GotLost += ActivateLoosePanel;
            }
            for (int i = 0; i < _targetsNeetToKill.Count; i++)
            {
                _targetsNeetToKill[i].GetComponent<IEnemieble>().TargetDestroyed += RefreshUI;
            }
            _allTargets = _targetsNeetToKill.Count;
            _destroyedTargetsAndCountOfTargets.text = _destroyedTargets + " / " + _allTargets;
        }

        private void RefreshUI()
        {
            _destroyedTargets++;
            if(_destroyedTargets == _allTargets)
            {
                int currentLevel = SceneManager.GetActiveScene().buildIndex;
                LevelDone?.Invoke();
                PlayerPrefs.SetInt("Levels", currentLevel + 1);
                Invoke(nameof(ActivateWinPanel), 2f);
            }
            _destroyedTargetsAndCountOfTargets.text = _destroyedTargets + " / " + _allTargets;
        }

        private void ActivateWinPanel()
        {
            _menusPlate.SetActive(true);
        }

        private void ActivateLoosePanel()
        {
            LevelFailed?.Invoke();
            _menusPlate.SetActive(true);
        }
    }
}