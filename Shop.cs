using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HelloWorld
{
    class Shop
    {
        private int _gold;
        private Item[] _inventory;

        public Shop()
        {
            _gold = 100;
        }

        public Shop(Item[] items)
        {
            _gold = 100;
            _inventory = items;
        }

        public bool Sell(Player player, int shopIndex, int playerIndex)
        {
            if (player.GetGold() >= _inventory[shopIndex].cost)
            {
                if (player.Buy(_inventory[shopIndex], playerIndex))
                {
                    _gold += _inventory[shopIndex].cost;
                    return true;
                }
            }
            Console.WriteLine("Player does not have enough gold");
            return false;
        }

        public void CheckPlayerFunds(Player player)
        {

        }
    }
}
