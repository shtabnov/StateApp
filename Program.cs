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
            Console.WriteLine("ИНФОРМАЦИЯ О ВСЕХ ГОСУДАРСТВАХ\n");
            
            foreach (var state in states)
            {
                state.DisplayInfo();
            }

            Console.WriteLine("\nСОРТИРОВКА ПО ЧИСЛЕННОСТИ НАСЕЛЕНИЯ\n");
            
            var sortedByPopulation = new List<State>(states);
            sortedByPopulation.Sort();
            
            Console.WriteLine("Государства от меньшего к большему населению:\n");
            foreach (var state in sortedByPopulation)
            {
                Console.WriteLine($"  {state.Name}: {state.Population:N0} чел.");
            }
            
            Console.WriteLine("\nСОРТИРОВКА ПО ДАТЕ ОСНОВАНИЯ\n");
            
            var sortedByDate = new List<State>(states);
            sortedByDate.Sort(State.SortByFoundationDate);
            
            Console.WriteLine("Государства от древнейших к новейшим:\n");
            foreach (var state in sortedByDate)
            {
                Console.WriteLine($"  {state.Name}: основано {state.FoundationDate:dd.MM.yyyy}");
            }
            
            Console.WriteLine("\nСОРТИРОВКА ПО ИМЕНИ РУКОВОДИТЕЛЯ\n");
            
            var sortedByLeader = new List<State>(states);
            sortedByLeader.Sort(State.SortByLeaderName);
            
            Console.WriteLine("Государства по имени руководителя (алфавит):\n");
            foreach (var state in sortedByLeader)
            {
                Console.WriteLine($"  {state.Name}: {state.LeaderName}");
            }
            
            Console.WriteLine("\nПОИСК ПО ДИАПАЗОНУ ЧИСЛЕННОСТИ\n");
            
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

            Console.WriteLine("\n\nНажмите Enter для перехода к заданию 2");
            Console.ReadLine();
            Console.Clear();

            // ========== ЗАДАНИЕ 2: Работа с классом Hash ==========
            DemonstrateHash();
        }

        static void DemonstrateHash()
        {
            Console.WriteLine("ЗАДАНИЕ 2: РАБОТА С КЛАССОМ HASH\n");

            // Создание начальной коллекции Hash
            Hash stateHash = new Hash();
            
            // Заполнение коллекции начальными объектами
            stateHash.Add("FR", new Republic("Франция", new DateTime(1789, 7, 14), 67_000_000, "Эмманюэль Макрон", "Эмманюэль Макрон", 5));
            stateHash.Add("UK", new Kingdom("Великобритания", new DateTime(1707, 5, 1), 67_000_000, "Карл III", "Карл III", 400));
            stateHash.Add("RU", new Federation("Россия", new DateTime(1991, 12, 25), 146_000_000, "Владимир Путин", 85, "Владимир Путин"));
            stateHash.Add("DE", new Republic("Германия", new DateTime(1949, 5, 23), 83_000_000, "Фрэнк-Вальтер Штайнмайер", "Олаф Шольц", 4));
            stateHash.Add("ES", new Kingdom("Испания", new DateTime(1978, 12, 29), 47_000_000, "Фелипе VI", "Фелипе VI", 500));
            stateHash.Add("US", new Federation("США", new DateTime(1776, 7, 4), 333_000_000, "Джо Байден", 50, "Джо Байден"));

            Console.WriteLine($"Начальная коллекция содержит {stateHash.Count} элементов.\n");

            // Меню для работы с коллекцией
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("МЕНЮ УПРАВЛЕНИЯ");
                Console.WriteLine("1. Добавить государство");
                Console.WriteLine("2. Удалить государство");
                Console.WriteLine("3. Показать все государства");
                Console.WriteLine("4. Выполнить запросы");
                Console.WriteLine("5. Перебор через foreach");
                Console.WriteLine("6. Клонирование коллекции");
                Console.WriteLine("7. Поиск элемента");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите действие: ");

                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddStateToHash(stateHash);
                        break;
                    case "2":
                        RemoveStateFromHash(stateHash);
                        break;
                    case "3":
                        DisplayAllStates(stateHash);
                        break;
                    case "4":
                        ExecuteQueries(stateHash);
                        break;
                    case "5":
                        DemonstrateForeach(stateHash);
                        break;
                    case "6":
                        DemonstrateCloning(stateHash);
                        break;
                    case "7":
                        DemonstrateSearch(stateHash);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Выход из программы...");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nНажмите Enter для продолжения");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        static void AddStateToHash(Hash hash)
        {
            Console.WriteLine("ДОБАВЛЕНИЕ ГОСУДАРСТВА\n");

            Console.Write("Введите ключ (например, код страны): ");
            string? key = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(key))
            {
                Console.WriteLine("Ключ не может быть пустым!");
                return;
            }

            Console.WriteLine("\nВыберите тип государства:");
            Console.WriteLine("1. Республика");
            Console.WriteLine("2. Королевство");
            Console.WriteLine("3. Федерация");
            Console.Write("Ваш выбор: ");
            string? typeChoice = Console.ReadLine();

            try
            {
                Console.Write("Название: ");
                string? name = Console.ReadLine();
                Console.Write("Дата основания (гггг-мм-дд): ");
                DateTime foundationDate = DateTime.Parse(Console.ReadLine() ?? "");
                Console.Write("Численность населения: ");
                int population = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Глава государства: ");
                string? leaderName = Console.ReadLine();

                State? newState = null;

                switch (typeChoice)
                {
                    case "1":
                        Console.Write("Президент: ");
                        string? president = Console.ReadLine();
                        Console.Write("Срок полномочий (лет): ");
                        int termYears = int.Parse(Console.ReadLine() ?? "0");
                        newState = new Republic(name ?? "", foundationDate, population, leaderName ?? "", president ?? "", termYears);
                        break;
                    case "2":
                        Console.Write("Король: ");
                        string? kingName = Console.ReadLine();
                        Console.Write("Лет правления династии: ");
                        int dynastyYears = int.Parse(Console.ReadLine() ?? "0");
                        newState = new Kingdom(name ?? "", foundationDate, population, leaderName ?? "", kingName ?? "", dynastyYears);
                        break;
                    case "3":
                        Console.Write("Количество субъектов: ");
                        int numberOfStates = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Федеральный лидер: ");
                        string? federalLeader = Console.ReadLine();
                        newState = new Federation(name ?? "", foundationDate, population, leaderName ?? "", numberOfStates, federalLeader ?? "");
                        break;
                    default:
                        Console.WriteLine("Неверный тип государства!");
                        return;
                }

                hash.Add(key, newState);
                Console.WriteLine($"\nГосударство '{name}' успешно добавлено с ключом '{key}'!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка при добавлении: {ex.Message}");
            }
        }

        static void RemoveStateFromHash(Hash hash)
        {
            Console.WriteLine("УДАЛЕНИЕ ГОСУДАРСТВА\n");

            Console.Write("Введите ключ для удаления: ");
            string? key = Console.ReadLine();

            if (hash.Remove(key ?? ""))
            {
                Console.WriteLine($"\nГосударство с ключом '{key}' успешно удалено!");
            }
            else
            {
                Console.WriteLine($"\nГосударство с ключом '{key}' не найдено!");
            }
        }

        static void DisplayAllStates(Hash hash)
        {
            Console.WriteLine("ВСЕ ГОСУДАРСТВА В КОЛЛЕКЦИИ\n");

            if (hash.Count == 0)
            {
                Console.WriteLine("Коллекция пуста.");
                return;
            }

            for (int i = 0; i < hash.Count; i++)
            {
                object? key = hash.GetKey(i);
                State? value = hash.GetValue(i);
                if (value != null)
                {
                    Console.WriteLine($"Ключ: {key}");
                    value.DisplayInfo();
                }
            }
        }

        static void ExecuteQueries(Hash hash)
        {
            Console.WriteLine("ВЫПОЛНЕНИЕ ЗАПРОСОВ\n");

            // Запрос 1: Количество республик
            int republicCount = 0;
            for (int i = 0; i < hash.Count; i++)
            {
                if (hash.GetValue(i) is Republic)
                    republicCount++;
            }
            Console.WriteLine($"Запрос 1: Количество республик в коллекции: {republicCount}");

            // Запрос 2: Печать всех королевств
            Console.WriteLine("\nЗапрос 2: Все королевства в коллекции:");
            bool hasKingdoms = false;
            for (int i = 0; i < hash.Count; i++)
            {
                if (hash.GetValue(i) is Kingdom kingdom)
                {
                    hasKingdoms = true;
                    Console.WriteLine($"  - {kingdom.Name} (Король: {kingdom.KingName})");
                }
            }
            if (!hasKingdoms)
                Console.WriteLine("  Королевств не найдено.");

            // Запрос 3: Государства с населением больше 100 миллионов
            Console.WriteLine("\nЗапрос 3: Государства с населением > 100 млн человек:");
            bool hasLargeStates = false;
            for (int i = 0; i < hash.Count; i++)
            {
                State? state = hash.GetValue(i);
                if (state != null && state.Population > 100_000_000)
                {
                    hasLargeStates = true;
                    Console.WriteLine($"  - {state.Name}: {state.Population:N0} чел.");
                }
            }
            if (!hasLargeStates)
                Console.WriteLine("  Государств с населением > 100 млн не найдено.");
        }

        static void DemonstrateForeach(Hash hash)
        {
            Console.WriteLine("ПЕРЕБОР КОЛЛЕКЦИИ ЧЕРЕЗ FOREACH\n");

            Console.WriteLine("Перебор всех элементов коллекции:\n");
            int index = 1;
            foreach (object item in hash)
            {
                if (item is KeyValuePair<object, State> kvp)
                {
                    Console.WriteLine($"{index}. Ключ: {kvp.Key}");
                    kvp.Value.DisplayInfo();
                    index++;
                }
            }
        }

        static void DemonstrateCloning(Hash hash)
        {
            Console.WriteLine("КЛОНИРОВАНИЕ КОЛЛЕКЦИИ\n");

            Console.WriteLine("Исходная коллекция:");
            Console.WriteLine($"Количество элементов: {hash.Count}\n");

            // Глубокое клонирование
            Hash clonedHash = hash.Clone();
            Console.WriteLine("Выполнено глубокое клонирование коллекции.");
            Console.WriteLine($"Клонированная коллекция содержит: {clonedHash.Count} элементов\n");

            // Поверхностное копирование
            Hash shallowCopy = hash.ShallowCopy();
            Console.WriteLine("Выполнено поверхностное копирование коллекции.");
            Console.WriteLine($"Поверхностная копия содержит: {shallowCopy.Count} элементов\n");

            // Демонстрация независимости клона
            Console.WriteLine("Добавляем новый элемент в клонированную коллекцию...");
            clonedHash.Add("TEST", new Republic("Тест", DateTime.Now, 1, "Тест", "Тест", 1));
            Console.WriteLine($"Исходная коллекция: {hash.Count} элементов");
            Console.WriteLine($"Клонированная коллекция: {clonedHash.Count} элементов");
            Console.WriteLine("\nКлонирование работает корректно - коллекции независимы!");
        }

        static void DemonstrateSearch(Hash hash)
        {
            Console.WriteLine("ПОИСК ЭЛЕМЕНТА\n");

            Console.Write("Введите название государства для поиска: ");
            string? searchName = Console.ReadLine();

            State? foundState = null;
            for (int i = 0; i < hash.Count; i++)
            {
                State? state = hash.GetValue(i);
                if (state != null && state.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    foundState = state;
                    break;
                }
            }

            if (foundState != null)
            {
                object? key = hash.Find(foundState);
                Console.WriteLine($"\nГосударство найдено!");
                Console.WriteLine($"Ключ: {key}");
                Console.WriteLine("\nИнформация о государстве:");
                foundState.DisplayInfo();
            }
            else
            {
                Console.WriteLine($"\nГосударство '{searchName}' не найдено в коллекции.");
            }
        }
    }
}