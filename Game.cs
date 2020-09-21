using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace HelloWorld
{
    struct Item
    {
        public int cost;
        public string name;
    }

    class Game
    {
        private Player _player;
        private Shop _shop;
        private Item _arrow;
        private Item _shield;
        private Item _gem;
        private Item[] _shopInventory;
        private bool _gameOver;

        //Run the game
        public void Run()
        {
            _gameOver = false;
            Start();
            while (!_gameOver)
                Update();
            End();
        }

        //Performed once when the game begins
        public void Start()
        {
            InitItems();
            _shopInventory = new Item[] { _arrow, _shield, _gem };
            _player = new Player();
            _shop = new Shop(_shopInventory);
        }

        //Repeated until the game ends
        public void Update()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Shop!");
            Console.WriteLine();
            Console.WriteLine("Player Gold: " + _player.GetGold() + "g");
            Console.WriteLine();
            OpenShopMenu();

            int shopInput = -1;
            while (true)
            {
                Console.Write("> ");
                shopInput = int.Parse(Console.ReadKey().KeyChar.ToString()) - 1;
                if (shopInput >= 0 && shopInput < _shopInventory.Length)
                    break;
                Console.WriteLine("\nInvalid Input\n");

            }
            Console.WriteLine();

            Console.WriteLine("Choose a slot in your inventory.");
            PrintInventory(_player.GetInventory());

            int inventoryInput = -1;
            while (true)
            {
                Console.Write("> ");
                inventoryInput = int.Parse(Console.ReadKey().KeyChar.ToString()) - 1;
                if (inventoryInput >= 0 && inventoryInput < _player.GetInventory().Length)
                    break;
                Console.WriteLine("\nInvalid Input\n");
            }
            Console.WriteLine();

            if (_shop.Sell(_player, shopInput, inventoryInput))
                Console.WriteLine("Player purchased " + _shopInventory[shopInput].name + " for " + _shopInventory[shopInput].cost + "g.");
            else
                Console.WriteLine("Transaction failed.");

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        //Performed once when the game ends
        public void End()
        {
            
        }

        private void InitItems()
        {
            _arrow.name = "Arrow";
            _arrow.cost = 5;

            _shield.name = "Shield";
            _shield.cost = 25;

            _gem.name = "Healing Gem";
            _gem.cost = 40;
        }

        public Item PrintInventory(Item[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write(" [" + (i + 1) + "] " + items[i].name);
                if (items[i].name != "None")
                    Console.WriteLine(": " + items[i].cost + "g");
                else
                    Console.WriteLine();
            }

            return items[0];
        }

        private void OpenShopMenu()
        {
            Console.WriteLine("Shop Inventory:");
            PrintInventory(_shopInventory);
        }
    }
}
