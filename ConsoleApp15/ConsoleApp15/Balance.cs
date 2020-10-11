using System;

namespace ConsoleApp15
{
    class Balance
    {
        private int _money = 0;

        public int getMoneyCount()
        {
            return _money;
        }

        public void addMoney(int number)
        {
            _money += number;
        }

        public bool buySomething(int cost)
        {
            if (_money >= cost)
            {
                _money -= cost;
                return true;
            }
            return false;
        }
    }
}
