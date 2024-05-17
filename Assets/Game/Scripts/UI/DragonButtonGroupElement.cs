using System;
using Game.Scripts.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class DragonButtonGroupElement : MonoBehaviour
    {
        public static event Action <DragonType> DragonSpawnButtonClick;
        public TextMeshProUGUI buttonText;
        public Button button;
        public DragonType type;

        private void Start()
        {
            button.onClick.AddListener(OnDragonSpawnButtonClick);
        }
        
        private void OnDragonSpawnButtonClick()
        {
            DragonSpawnButtonClick?.Invoke(type);
        }
    }
}