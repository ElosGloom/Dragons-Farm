using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Common
{
    public class EggTimer : MonoBehaviour
    {
        [SerializeField] private GameObject timer;
        [SerializeField] private Button eggButton;
        [SerializeField] private float timerDisplayDuration = 5f;

        private float _timerCounter;

        private void Start()
        {
            eggButton.onClick.AddListener(ShowTimer);
        }

        private void Update()
        {
            _timerCounter += Time.deltaTime;
            if (_timerCounter >= timerDisplayDuration)
            {
                HideTimer();
                _timerCounter = 0f;
            }
        }

        private void ShowTimer()
        {
            timer.SetActive(true);
        }

        private void HideTimer()
        {
            timer.SetActive(false);
        }
    }
}