using System;
using _2_UIToolkit.Scripts.UIModule.Panels.GameHudModule;
using _2_UIToolkit.Scripts.UIModule.Panels.MenuModule;
using UnityEngine;
using UnityEngine.UIElements;

namespace _2_UIToolkit.Scripts.UIModule
{
    [RequireComponent(typeof(UIDocument))]
    public class UIController : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private MenuPanel _menuPanel;
        [SerializeField] private GameHud _gameHud;
        
        private UIDocument _uiDocument;

        private void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();
        }

        private void OnEnable()
        {
            //ActivateGameHudPanel();
            ActivateMenuPanel();
        }

        private void ActivateMenuPanel()
        {
            //_uiDocument.visualTreeAsset = _menuPanel.MenuPanelAsset;
            _uiDocument.visualTreeAsset = _menuPanel.GetMainMenuTreeAsset();
        }

        private void ActivateGameHudPanel()
        {
            //_uiDocument.visualTreeAsset = _gameHud.GetTreeAsset(ActivateMenuPanel);
            
            var clonedTree = _gameHud.GameHudAsset.CloneTree();
            clonedTree.Q<Button>("BackToMainMenu_button").clicked += ActivateMenuPanel;
            _uiDocument.visualTreeAsset = clonedTree.templateSource;
            
            //_uiDocument.visualTreeAsset = _gameHud.GameHudAsset.CloneTree().templateSource;
            //var visualElement = _uiDocument.rootVisualElement.Q<VisualElement>();
            //visualElement.Q<Button>("BackToMainMenu_button").clicked += ActivateMenuPanel;

            //_uiDocument.visualTreeAsset = _gameHud.GameHudAsset.CloneTree().templateSource;

            //_uiDocument.visualTreeAsset = _gameHud.GameHudAsset;
            //var visualElement = _uiDocument.rootVisualElement.Q<VisualElement>();
            //visualElement.Q<Button>("BackToMainMenu_button").clicked += ActivateMenuPanel;
        }
    }
}