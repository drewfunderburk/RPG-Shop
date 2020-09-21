using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private int _gold;
        private Item[] _inventory;

        public Player()
        {
            _gold = 100;
            _inventory = new Item[3];
            for (int i = 0; i < _inventory.Length; i++)
            {
                _inventory[i].name = "None";
            }
        }

        public bool Buy(Item item, int index)
        {
            if (index < _inventory.Length && index >= 0)
            {
                _inventory[index] = item;
                _gold -= item.cost;
                return true;
            }
            return false;
        }

        public int GetGold()
        {
            return _gold;
        }

        public Item[] GetInventory()
        {
            return _inventory;
        }
    }
}
