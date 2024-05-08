using System;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.Panels.MainMenuPanelModule
{
    public class MainMenuPanel : MonoBehaviour
    {
        [SerializeField] private FooterMenuPanel _footerMenuPanel;
        
        public void SubscribeFooterMenuOnButtonsClick(Action OnGamesPageButtonClick, 
            Action OnApplicationsPageButtonClick, Action OnBooksPageButtonClick)
        {
            _footerMenuPanel.SubscribeOnButtonsClick(OnGamesPageButtonClick, OnApplicationsPageButtonClick, OnBooksPageButtonClick);
        }

        public void UnsubscribeFooterMenuButtonsListeners()
        {
            _footerMenuPanel.UnsubscribeButtonsListeners();
        }
    }
}