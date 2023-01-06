using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Inventory
    {
        /*
         *  Id 값에 대한 설명
         *  
         *  0 : 없음
         *  1 : 소모품
         *  2 : 재료
         *  3 : 장비
         */

        struct item
        {
            public item(int _id, string _itemName, int _few, string _described,bool _isUsedItem)
            {
                Id = _id;
                ItemName = _itemName;
                Few = _few;
                Described = _described;
                IsUsedItem = _isUsedItem;
            }

            int Id;
            string ItemName;
            int Few;
            string Described;
            bool IsUsedItem;
        }

        struct equipment
        {
            public equipment(int _id, string _equipmentName, int _few, string _described, bool _isequipped)
            {
                Id = _id;
                EquipmentName = _equipmentName;
                Few = _few;
                Described = _described;
                IsEquipped = _isequipped;
            }
            int Id;
            string EquipmentName;
            int Few;
            string Described;
            bool IsEquipped;
        }

        List<item> InsideInventoryItem = new List<item>();
        List<equipment> InsideInventoryEquipment = new List<equipment>();
        int Gold;
        bool isInventoryActive;

        public Inventory()
        {
            isInventoryActive = false;
        }
        

        public void addItem(string itemName, int few, string described, bool isUsedItem)
        {      
            InsideInventoryItem.Add(new item(InsideInventoryItem.Count, itemName, few, described, isUsedItem));
        }

        public void addEquipment(string equipmentName, int few, string described, bool isequipped)
        {
            InsideInventoryEquipment.Add(new equipment(InsideInventoryItem.Count, equipmentName, few, described, isequipped));
        }

        private item findindex_itemList(int indexNumber)
        {
            item result = default;

            if(InsideInventoryItem.Count > 0)
            {
                for (int i = 0; i < InsideInventoryItem.Count; i++)
                {
                    if(i == indexNumber)
                    {
                        result = InsideInventoryItem[i];
                    }
                }
            }

            return result;
        }

        private equipment findindex_equipmentList(int indexNumber)
        {
            equipment result = default;

            if (InsideInventoryEquipment.Count > 0)
            {
                for (int i = 0; i < InsideInventoryEquipment.Count; i++)
                {
                    if (i == indexNumber)
                    {
                        result = InsideInventoryEquipment[i];
                    }
                }
            }

            return result;
        }

        public void activeInventory()
        {
            if(isInventoryActive)
            {
                isInventoryActive = false;
            }
            else if(!isInventoryActive)
            {
                isInventoryActive = true;
            }
        }
    }
}
