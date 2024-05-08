using System;
using System.Text;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _7_PlayMarketSample.Scripts.UIModule.Panels.ItemsContainerPanelModule
{
    [RequireComponent(typeof(Button))]
    public class ItemPanel : MonoBehaviour
    {
        private const int MAX_NAME_LENGTH = 20;
        
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _rateText;

        private AppSO _appSO;
        
        public void Initialize(AppSO appSo, Action<AppSO> OnAppItemButtonClick)
        {
            GetComponent<Button>().onClick.AddListener(() => OnAppItemButtonClick?.Invoke(_appSO));
            
            _appSO = appSo;
            string name = _appSO.AppInfo.Name;
            
            if (_appSO.AppInfo.Name.Length > MAX_NAME_LENGTH)
            {
                StringBuilder newName = new StringBuilder();
                for (int i = 0; i < MAX_NAME_LENGTH - 1; i++)
                {
                    if (i + 1 >= MAX_NAME_LENGTH)
                    {
                        newName.Append("...");
                        break;
                    }
                    newName.Append(_appSO.AppInfo.Name[i]);
                }

                name = newName.ToString();
            }
            
            _nameText.text = name;
            _rateText.text = $"{_appSO.Rate}/10";
            _icon.sprite = _appSO.AppInfo.Icon;
        }
    }
}