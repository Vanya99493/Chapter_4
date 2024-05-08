using System;
using _7_PlayMarketSample.Scripts.UIModule.Panels.MainMenuPanelModule;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.ApplicationLists;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.Panels.BasePagePanelModule
{
    public class BasePagePanel : MonoBehaviour
    {
        [SerializeField] protected HeaderMenuPanel _headerMenuPanel; 
        [SerializeField] protected BaseMainPagePanel _mainPagePanel;
        [SerializeField] protected BaseTopChartsPagePanel _topChartsPanel;

        public void Initialize(ApplicationListSO applicationListSO, Action<AppSO> OnAppItemButtonClick)
        {
            _mainPagePanel.Initialize(applicationListSO, OnAppItemButtonClick);
            _topChartsPanel.Initialize(applicationListSO, OnAppItemButtonClick);
            
            ActivateMainPagePanel();
            _headerMenuPanel.SubscribeOnButtonsClick(ActivateMainPagePanel, ActivateTopChartsPagePanel);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }
        
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private void ActivateMainPagePanel()
        {
            _mainPagePanel.gameObject.SetActive(true);
            _topChartsPanel.gameObject.SetActive(false);
        }

        private void ActivateTopChartsPagePanel()
        {
            _topChartsPanel.gameObject.SetActive(true);
            _mainPagePanel.gameObject.SetActive(false);
        }
    }
}