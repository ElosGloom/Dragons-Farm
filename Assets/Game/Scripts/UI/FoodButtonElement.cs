using System;
using Game.Scripts.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class FoodButtonElement : MonoBehaviour
    {
        public static event Action<string> FoodSpawnButtonClick;
        public TextMeshProUGUI buttonText;
        public Button button;
        public FoodType type;

        private void Start()
        {
            button.onClick.AddListener(OnDragonSpawnButtonClick);
        }

        private void OnDragonSpawnButtonClick()
        {
            FoodSpawnButtonClick?.Invoke(type.ToString());
        }
    }
}