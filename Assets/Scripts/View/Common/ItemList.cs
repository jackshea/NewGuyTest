using System;
using System.Collections.Generic;
using UnityEngine;

namespace View.Common
{
    public class ItemList : MonoBehaviour
    {
        private readonly List<GameObject> mItemList = new List<GameObject>();
        public GameObject ItemTemplate;

        public int Count => mItemList.Count;
        public GameObject this[int index] => mItemList[index];

        public void Reset()
        {
            for (var i = 0; i < mItemList.Count; i++) mItemList[i].SetActive(false);
        }

        public void Refresh<T>(int index, T data, Action<T, GameObject> draw, bool isActive = true)
        {
            if (mItemList == null) return;

            if (index < mItemList.Count)
            {
                mItemList[index].SetActive(isActive);
                draw(data, mItemList[index]);
            }
            else
            {
                var newItem = Instantiate(ItemTemplate);
                newItem.SetActive(isActive);
                newItem.transform.SetParent(ItemTemplate.transform.parent, false);
                mItemList.Add(newItem);
                draw(data, newItem);
            }
        }

        public GameObject GetGoItem(int index)
        {
            if (index >= mItemList.Count) return null;

            return mItemList[index];
        }

        public List<GameObject> GetItemList()
        {
            return mItemList;
        }

        private void OnDestroy()
        {
            foreach (var item in mItemList) Destroy(item);
            mItemList.Clear();
        }
    }
}