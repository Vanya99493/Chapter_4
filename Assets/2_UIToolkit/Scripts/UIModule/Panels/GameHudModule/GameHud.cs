using System;
using UnityEngine.UIElements;

namespace _2_UIToolkit.Scripts.UIModule.Panels.GameHudModule
{
    [Serializable]
    public class GameHud
    {
        private const string BACK_TO_MAIN_MENU_BUTTON_NAME = "BackToMainMenu_button";
        
        public VisualTreeAsset GameHudAsset;

        public VisualTreeAsset GetTreeAsset(Action OnBackToMainMenuButtonClick)
        {
            var clonedTree = GameHudAsset.CloneTree();
            
            
            clonedTree.Q<Button>(BACK_TO_MAIN_MENU_BUTTON_NAME).clicked += OnBackToMainMenuButtonClick;
            return clonedTree.templateSource;
            
            //_uiDocument.visualTreeAsset = _gameHud.GameHudAsset;
            //var visualElement = _uiDocument.rootVisualElement.Q<VisualElement>();
            //visualElement.Q<Button>("BackToMainMenu_button").clicked += ActivateMenuPanel;
        }
        
        public void SubscribeButtonOnClickEvents(Action OnBackToMainMenuButtonClick)
        {
            var clonedTree = GameHudAsset.CloneTree();
            clonedTree.Q<Button>(BACK_TO_MAIN_MENU_BUTTON_NAME).clicked += OnBackToMainMenuButtonClick;
        }
    }
}