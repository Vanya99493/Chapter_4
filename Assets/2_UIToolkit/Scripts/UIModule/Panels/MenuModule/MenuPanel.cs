using System;
using _2_UIToolkit.Scripts.UIModule.Panels.MenuModule.MenuContentsPanels;
using UnityEngine;
using UnityEngine.UIElements;

namespace _2_UIToolkit.Scripts.UIModule.Panels.MenuModule
{
    [Serializable]
    public class MenuPanel
    {
        private const string CONTENT_PANEL_NAME = "ButtonsContainer_ve";
        
        public VisualTreeAsset MenuPanelAsset;
        
        [SerializeField] private MainMenuContent _mainMenuContent;
        [SerializeField] private SettingsContent _settingsContent;

        public VisualTreeAsset GetMainMenuTreeAsset()
        {
            var clonedTree = MenuPanelAsset.CloneTree();
            clonedTree.Q<VisualElement>(CONTENT_PANEL_NAME).contentContainer.Add(_mainMenuContent.MainMenuContentAsset.CloneTree());
            return clonedTree.templateSource;
        }
    }
}