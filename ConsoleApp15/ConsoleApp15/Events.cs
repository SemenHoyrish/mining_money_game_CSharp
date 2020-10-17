using System;
using System.Collections.Generic;

namespace ConsoleApp15
{
    static class Events
    {

        private static PC _pc;
        private static Balance _balance;
        private static List<string> _events_list = new List<string> { "GPUBroken", "YouFindAPassport" };
        private static Random rnd = new Random();

        public static void startEvent(PC pc, Balance balance, string event_name = "")
        {
            _pc = pc;
            _balance = balance;
            if (event_name != "")
            {

            }
            else
            {
                int event_index = rnd.Next(0, _events_list.Count);
                string event_string = _events_list[event_index];
                switch(event_string)
                {
                    case "GPUBroken":
                        GPUBroken();
                        break;
                    case "YouFindAPassport":
                        YouFindAPassport();
                        break;
                    default:
                        break;
                }
            }
            Saver.save();
        }

        private static void GPUBroken()
        {
            if (_balance.getMoneyCount() < 100 || _pc.getPCDetails()[1].Key == "no") return;
            Console.WriteLine("ВИДЕОКАРТА СЛОМАЛАСЬ!!!!!!");
            _pc.setDetail("GPU", new KeyValuePair<string, int>("no", 0));
        }

        private static void YouFindAPassport()
        {
            string answer = "";
            while (answer != "1" && answer != "2")
            {
                Console.WriteLine("Вы шли по улице и нашли паспорт!");
                Console.WriteLine("Так же вы недавно наткнулись на объявление где за любой паспорт платят 500");
                Console.WriteLine("Что вы сделаете? 1) Отнесёте паспорт в полицию 2) Продадите паспорт на сайте");
                answer = Console.ReadLine();
            }
            int answer_int = int.Parse(answer);
            switch (answer_int)
            {
                case 1:
                    Console.WriteLine("Хозяин паспорта был очень рад и отблагодарил Вас (+50)");
                    _balance.addMoney(50);
                    break;
                case 2:
                    int tmp = rnd.Next(1, 2 + 1);
                    switch (tmp)
                    {
                        case 1:
                            Console.WriteLine("Вы успешно продали паспорт на сайте (+500)");
                            _balance.addMoney(500);
                            break;
                        case 2:
                            Console.WriteLine($"Вас поймала полиция за незаконную продажу документов. Вам выписали штраф (-{(_balance.getMoneyCount() < 500 ? _balance.getMoneyCount() : 500)})");
                            if (_balance.getMoneyCount() < 500) _balance.removeMoney(_balance.getMoneyCount());
                            else _balance.removeMoney(500);
                            break;
                        default:
                            break;
                    }
                    break;
            }
            Console.WriteLine($"Ваш баланс {_balance.getMoneyCount()}");
            //_pc.setDetail("GPU", new KeyValuePair<string, int>("no", 0));
        }
    }
}
