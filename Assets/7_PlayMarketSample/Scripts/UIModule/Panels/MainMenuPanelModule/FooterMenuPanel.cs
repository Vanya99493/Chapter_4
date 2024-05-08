using System;
using UnityEngine;
using UnityEngine.UI;

namespace _7_PlayMarketSample.Scripts.UIModule.Panels.MainMenuPanelModule
{
    public class FooterMenuPanel : MonoBehaviour
    {
        [SerializeField] private Button _gamesPageButton;
        [SerializeField] private Button _applicationsPageButton;
        [SerializeField] private Button _booksPageButton;

        public void SubscribeOnButtonsClick(Action OnGamesPageButtonClick, 
            Action OnApplicationsPageButtonClick, Action OnBooksPageButtonClick)
        {
            _gamesPageButton.onClick.AddListener(() => OnGamesPageButtonClick?.Invoke());
            _applicationsPageButton.onClick.AddListener(() => OnApplicationsPageButtonClick?.Invoke());
            _booksPageButton.onClick.AddListener(() => OnBooksPageButtonClick?.Invoke());
        }

        public void UnsubscribeButtonsListeners()
        {
            _gamesPageButton.onClick.RemoveAllListeners();
            _applicationsPageButton.onClick.RemoveAllListeners();
            _booksPageButton.onClick.RemoveAllListeners();
        }
    }
}