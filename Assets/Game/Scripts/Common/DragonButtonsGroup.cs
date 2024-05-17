using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Common
{
    public class DragonButtonsGroup : MonoBehaviour
    {
        [SerializeField] private HorizontalLayoutGroup layoutGroup;
        [SerializeField] private List<DragonButtonGroupElement> buttonsList = new();
        [SerializeField] private DragonButtonGroupElement button;


        private readonly Array _dragonTypes = Enum.GetValues(typeof(DragonType));

        private void Start()
        {
            FillButtonsGroup();
        }

        private void FillButtonsGroup()
        {
            for (int i = 0; i < _dragonTypes.Length; i++)
            {
                var newButton = Instantiate(button, layoutGroup.transform);
                buttonsList.Add(newButton);

                var type = (DragonType)_dragonTypes.GetValue(i);
                newButton.buttonText.text = type.ToString();
                newButton.type = type;
            }
        }
    }
}