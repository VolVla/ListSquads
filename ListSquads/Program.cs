using System;
using System.Collections.Generic;
using System.Linq;

namespace ListSquads
{
    internal class Program
    {
        static void Main()
        {
            Division division = new Division();
            ConsoleKey exitButton = ConsoleKey.Enter;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Для начало работы нажмите на любую клавишу");
                Console.ReadKey();
                Console.Clear();
                division.TransferSoldiers();
                Console.WriteLine($"\nВы хотите выйти из программы?Нажмите {exitButton}.\nДля продолжение работы нажмите любую другую клавишу");

                if (Console.ReadKey().Key == exitButton)
                {
                    Console.WriteLine("Вы вышли из программы");
                    isWork = false;
                }

                Console.Clear();
            }
        }
    }

    class Division
    {
        private List<Soldier> _firstSquad;
        private List<Soldier> _secondSquad;
        private string _firstInitialeSurname = "Б";

        public Division()
        {
            _firstSquad = new List<Soldier>()
            {
               new Soldier ("Антонов"),
               new Soldier ("Владислав"),
               new Soldier ("Бородин"),
               new Soldier ("Дроздов"),
               new Soldier ("Балабанов"),
            };
            _secondSquad = new List<Soldier>()
            {
                new Soldier ("Дмитрий"),
                new Soldier ("Барабанов"),
                new Soldier ("Будеев"),
            };
        }

        public void TransferSoldiers()
        {
            Console.WriteLine("Первый отряд");
            ShowInfo(_firstSquad);
            Console.WriteLine("Второй отряд");
            ShowInfo(_secondSquad);
            Console.WriteLine($"Всех бойцов из отряда 1, у которых фамилия начинается на букву {_firstInitialeSurname},переводим во 2 отряд.");
            var initialSurname = _firstSquad.Where(soldier => soldier.Surname.StartsWith(_firstInitialeSurname));
            _firstSquad = _firstSquad.Except(initialSurname).ToList();
            _secondSquad = initialSurname.Union(_secondSquad).ToList();
            ShowInfo(_firstSquad);
            Console.WriteLine();
            ShowInfo(_secondSquad);
        }

        private void ShowInfo(IEnumerable<Soldier> _filterSoldiers)
        {
            foreach (var soldier in _filterSoldiers)
            {
                Console.WriteLine($"Солдат с фамилией {soldier.Surname}");
            }
        }
    }

    class Soldier
    {
        public Soldier(string surname)
        {
            Surname = surname;
        }

        public string Surname { get; private set; }
    }
}