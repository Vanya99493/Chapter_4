using _7_PlayMarketSample.Scripts.UIModule.Enums;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications
{
    [CreateAssetMenu(fileName = "BookSO", menuName = "App/BookSO")]
    public class BookSO : AppSO
    {
        public BookCategory BookCategory;
    }
}