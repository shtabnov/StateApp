using System;
using System.Collections.Generic;

namespace StateApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Демонстрация работы с государствами ===\n");
            
            // Создание списка государств различных типов
            List<State> states = new List<State>
            {
                new Republic("Франция", new DateTime(1789, 7, 14), 67_000_000, "Эмманюэль Макрон", "Эмманюэль Макрон", 5),
                new Kingdom("Великобритания", new DateTime(1707, 5, 1), 67_000_000, "Карл III", "Карл III", 400),
                new Federation("Россия", new DateTime(1991, 12, 25), 146_000_000, "Владимир Путин", 85, "Владимир Путин"),
                new Republic("Германия", new DateTime(1949, 5, 23), 83_000_000, "Фрэнк-Вальтер Штайнмайер", "Олаф Шольц", 4),
                new Kingdom("Испания", new DateTime(1978, 12, 29), 47_000_000, "Фелипе VI", "Фелипе VI", 500),
                new Federation("США", new DateTime(1776, 7, 4), 333_000_000, "Джо Байден", 50, "Джо Байден")
            };

            // Вывод информации о всех государствах
            Console.WriteLine("╔═══════════════════════════════════════════╗");
            Console.WriteLine("║   ИНФОРМАЦИЯ О ВСЕХ ГОСУДАРСТВАХ          ║");
            Console.WriteLine("╚═══════════════════════════════════════════╝\n");
            
            foreach (var state in states)
            {
                state.DisplayInfo();
            }

            Console.WriteLine("\n╔═══════════════════════════════════════════╗");
            Console.WriteLine("║   СОРТИРОВКА ПО ЧИСЛЕННОСТИ НАСЕЛЕНИЯ      ║");
            Console.WriteLine("╚═══════════════════════════════════════════╝\n");
            
            var sortedByPopulation = new List<State>(states);
            sortedByPopulation.Sort();
            
            Console.WriteLine("Государства от меньшего к большему населению:\n");
            foreach (var state in sortedByPopulation)
            {
                Console.WriteLine($"  {state.Name}: {state.Population:N0} чел.");
            }
            
            Console.WriteLine("\n╔═══════════════════════════════════════════╗");
            Console.WriteLine("║   СОРТИРОВКА ПО ДАТЕ ОСНОВАНИЯ            ║");
            Console.WriteLine("╚═══════════════════════════════════════════╝\n");
            
            var sortedByDate = new List<State>(states);
            sortedByDate.Sort(State.SortByFoundationDate);
            
            Console.WriteLine("Государства от древнейших к новейшим:\n");
            foreach (var state in sortedByDate)
            {
                Console.WriteLine($"  {state.Name}: основано {state.FoundationDate:dd.MM.yyyy}");
            }
            
            Console.WriteLine("\n╔═══════════════════════════════════════════╗");
            Console.WriteLine("║   СОРТИРОВКА ПО ИМЕНИ РУКОВОДИТЕЛЯ        ║");
            Console.WriteLine("╚═══════════════════════════════════════════╝\n");
            
            var sortedByLeader = new List<State>(states);
            sortedByLeader.Sort(State.SortByLeaderName);
            
            Console.WriteLine("Государства по имени руководителя (алфавит):\n");
            foreach (var state in sortedByLeader)
            {
                Console.WriteLine($"  {state.Name}: {state.LeaderName}");
            }
            
            Console.WriteLine("\n╔═══════════════════════════════════════════╗");
            Console.WriteLine("║   ПОИСК ПО ДИАПАЗОНУ ЧИСЛЕННОСТИ         ║");
            Console.WriteLine("╚═══════════════════════════════════════════╝\n");
            
            int minPopulation = 40_000_000;
            int maxPopulation = 100_000_000;
            
            Console.WriteLine($"Поиск государств с населением от {minPopulation:N0} до {maxPopulation:N0}:\n");
            var filteredStates = states.FindAll(s => s.Population >= minPopulation && s.Population <= maxPopulation);
            
            if (filteredStates.Count > 0)
            {
                foreach (var state in filteredStates)
                {
                    Console.WriteLine($"  {state.Name}: {state.Population:N0} чел.");
                }
            }
            else
            {
                Console.WriteLine("  В данном диапазоне государств не найдено.");
            }

            Console.ReadLine(); // Пауза для просмотра результатов
        }
    }
}