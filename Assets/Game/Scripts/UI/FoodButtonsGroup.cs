using System;
using System.Collections.Generic;
using Game.Scripts.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class FoodButtonsGroup : MonoBehaviour
    {
        [SerializeField] private HorizontalLayoutGroup layoutGroup;
        [SerializeField] private List<FoodButtonElement> buttonsList = new();
        [SerializeField] private FoodButtonElement button;


        private readonly Array _foodTypes = Enum.GetValues(typeof(FoodType));

        private void Start()
        {
            FillButtonsGroup();
        }

        private void FillButtonsGroup()
        {
            for (int i = 0; i < _foodTypes.Length; i++)
            {
                var newButton = Instantiate(button, layoutGroup.transform);
                buttonsList.Add(newButton);

                var type = (FoodType)_foodTypes.GetValue(i);
                newButton.buttonText.text = type.ToString();
                newButton.type = type;
            }
        }
    }
}