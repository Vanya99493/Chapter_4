using System;
using System.Text;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _7_PlayMarketSample.Scripts.UIModule.Panels.ItemsContainerPanelModule
{
    [RequireComponent(typeof(Button))]
    public class ItemShortcut : MonoBehaviour
    {
        private const int MAX_NAME_LENGTH = 10;
        
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Image _icon;

        private AppSO _appSO;
        
        public void Initialize(AppSO appSo, Action<AppSO> OnAppItemButtonClick)
        {
            GetComponent<Button>().onClick.AddListener(() => OnAppItemButtonClick?.Invoke(_appSO));

            _appSO = appSo;
            string name = _appSO.AppInfo.Name;
            
            if (_appSO.AppInfo.Name.Length > MAX_NAME_LENGTH)
            {
                StringBuilder newName = new StringBuilder();
                for (int i = 0; i < MAX_NAME_LENGTH; i++)
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
            _icon.sprite = _appSO.AppInfo.Icon;
        }
    }
}