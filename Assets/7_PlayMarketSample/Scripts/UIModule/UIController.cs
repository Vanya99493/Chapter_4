using System;
using System.Collections.Generic;
using _7_PlayMarketSample.Scripts.UIModule.Panels.AppPagePanelModule;
using _7_PlayMarketSample.Scripts.UIModule.Panels.BasePagePanelModule;
using _7_PlayMarketSample.Scripts.UIModule.Panels.BodyPagePanelModule.ApplicationsPagePanelModule;
using _7_PlayMarketSample.Scripts.UIModule.Panels.BodyPagePanelModule.BooksPagePanelModule;
using _7_PlayMarketSample.Scripts.UIModule.Panels.BodyPagePanelModule.GamesPagePanelModule;
using _7_PlayMarketSample.Scripts.UIModule.Panels.MainMenuPanelModule;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.ApplicationLists;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private MainMenuPanel _mainMenuPanel;
        [SerializeField] private AppPagePanel _appPagePanel;
        [Header("Contents panels")]
        [SerializeField] private GamesPagePanel _gamesPagePanel;
        [SerializeField] private ApplicationsPagePanel _applicationsPagePanel;
        [SerializeField] private BooksPagePanel _booksPagePanel;

        private Dictionary<Type, BasePagePanel> _pagePanels;
        private BasePagePanel _currentActivePagePanel;

        private void Awake()
        {
            _pagePanels = new Dictionary<Type, BasePagePanel>()
            {
                { _gamesPagePanel.GetType(), _gamesPagePanel },
                { _applicationsPagePanel.GetType(), _applicationsPagePanel },
                { _booksPagePanel.GetType(), _booksPagePanel }
            };
        }

        public void Initialize(ApplicationListSO gamesListSO, 
            ApplicationListSO applicationListSO, ApplicationListSO booksListSo)
        {
            _gamesPagePanel.Initialize(gamesListSO, OnAppItemButtonClick);
            _gamesPagePanel.Disable();
            
            _applicationsPagePanel.Initialize(applicationListSO, OnAppItemButtonClick);
            _applicationsPagePanel.Disable();
            
            _booksPagePanel.Initialize(booksListSo, OnAppItemButtonClick);
            _booksPagePanel.Disable();
            
            SubscribeMainMenuPanelButtons();
            
            EnterPage<GamesPagePanel>();
        }

        private void EnterPage<T>() where T : BasePagePanel
        {
            _currentActivePagePanel?.Disable();
            _currentActivePagePanel = _pagePanels[typeof(T)];
            _currentActivePagePanel.Enable();
        }

        private void SubscribeMainMenuPanelButtons()
        {
            _mainMenuPanel.SubscribeFooterMenuOnButtonsClick(OnGamesPageButtonClick, OnApplicationsPageButtonClick, OnBooksPageButtonClick);
        }

        private void OnAppItemButtonClick(AppSO appSO) => _appPagePanel.Activate(appSO); 
        private void OnGamesPageButtonClick() => EnterPage<GamesPagePanel>();
        private void OnApplicationsPageButtonClick() => EnterPage<ApplicationsPagePanel>();
        private void OnBooksPageButtonClick() => EnterPage<BooksPagePanel>();
    }
}