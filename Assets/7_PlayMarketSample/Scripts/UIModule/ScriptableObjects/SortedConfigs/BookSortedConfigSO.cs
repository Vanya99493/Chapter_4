using System.Collections.Generic;
using _7_PlayMarketSample.Scripts.UIModule.Enums;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.ApplicationLists;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.SortedConfigs
{
    [CreateAssetMenu(fileName = "BookSortedConfigSO", menuName = "SortedConfigs/BookSortedConfigSO")]
    public class BookSortedConfigSO : ScriptableObject, ISerializationCallbackReceiver
    {
        public string Description;
        public bool IsRandom;
        public BookCategory BookCategory;
        public bool ByRateDecreasing;
        public int AppsNumber;
        
        public void OnBeforeSerialize(){}

        public void OnAfterDeserialize()
        {
            if (IsRandom)
            {
                ByRateDecreasing = false;
                BookCategory = BookCategory.All;
            }
        }

        public List<AppSO> GetSortedBooksList(ApplicationListSO applicationListSO)
        {
            List<BookSO> sortedList = SortByCategory(applicationListSO);

            if (ByRateDecreasing)
            {
                sortedList = GetPopularApps(sortedList);
            }
            else if (IsRandom)
            {
                sortedList = GetRandomApps(sortedList);
            }

            List<AppSO> boxedList = new List<AppSO>();
            foreach (var gameSO in sortedList)
            {
                boxedList.Add(gameSO);
            }

            return boxedList;
        }

        private List<BookSO> SortByCategory(ApplicationListSO applicationListSO)
        {
            List<BookSO> sortedList = new List<BookSO>();
            foreach (var app in applicationListSO.Applications)
            {
                BookSO bookSO = app as BookSO;

                if (IsRandom || BookCategory == BookCategory.All || bookSO.BookCategory == BookCategory)
                {
                    sortedList.Add(bookSO);
                }
            }

            return sortedList;
        }

        private List<BookSO> GetPopularApps(List<BookSO> list)
        {
            List<BookSO> newList = new List<BookSO>();
            list.Sort();
            foreach (var bookSO in list)
            {
                if (newList.Count >= AppsNumber)
                {
                    break;
                }

                newList.Add(bookSO);
            }

            return newList;
        }

        private List<BookSO> GetRandomApps(List<BookSO> list)
        {
            List<BookSO> newList = new List<BookSO>();
            int counter = 0;
            foreach (var bookSO in list)
            {
                if (Random.Range(0, list.Count - counter) < AppsNumber - newList.Count)
                {
                    newList.Add(bookSO);
                }
                counter++;
            }

            return newList;
        }
    }
}