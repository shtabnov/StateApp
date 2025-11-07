## Документация публичного API проекта StateApp

### Обзор

StateApp — учебный пример, демонстрирующий применение абстрактных классов и интерфейсов `IComparable`/`ICloneable` для моделирования различных типов государств. Публичный API состоит из абстрактного базового класса `State`, производных типов `Republic`, `Kingdom`, `Federation`, а также статического входа `Program.Main`, который показывает типовые сценарии использования.

### Требования и запуск

- .NET SDK 6.0 или новее  
- Команды запуска из корня репозитория:  
  - `dotnet build` — проверка сборки  
  - `dotnet run` — запуск демонстрационной консольной программы

### Архитектура пространства имён `StateApp`

- `State` — абстрактный базовый класс для всех государств.  
- `Republic`, `Kingdom`, `Federation` — конкретные реализации с дополнительными полями и логикой.  
- `Program` — точка входа, создающая и обрабатывающая коллекции состояний.

## Абстрактный класс `State`

`State` описывает общие характеристики государства и определяет контракт для отображения информации. Все производные типы обязаны реализовать метод `DisplayInfo`.

**Конструктор**

```csharp
protected State(string name, DateTime foundationDate, int population, string leaderName)
```

- `name` — официальное название.  
- `foundationDate` — дата основания.  
- `population` — численность населения в людях.  
- `leaderName` — текущее имя главы государства.

**Публичные свойства**

| Свойство        | Тип        | Описание                                           |
|-----------------|------------|----------------------------------------------------|
| `Name`          | `string`   | Название государства.                              |
| `FoundationDate`| `DateTime` | Дата основания; используется для расчёта возраста. |
| `Population`    | `int`      | Население в людях.                                 |
| `LeaderName`    | `string`   | Имя текущего руководителя.                         |

**Методы и компараторы**

| Член | Сигнатура | Назначение |
|------|-----------|------------|
| `DisplayInfo()` | `abstract void DisplayInfo()` | Выводит форматированное описание. Реализуется в наследниках. |
| `GetAge()` | `int GetAge()` | Возвращает полный возраст государства в годах на текущую дату. |
| `CompareTo()` | `int CompareTo(State? other)` | Сортировка по `Population` (возрастает). Реализация `IComparable<State>`. |
| `SortByFoundationDate` | `static IComparer<State>` | Компаратор для сортировки по дате основания (от старейших к новейшим). |
| `SortByLeaderName` | `static IComparer<State>` | Компаратор для сортировки по имени руководителя (лексикографически). |
| `Clone()` | `virtual object Clone()` | Поверхностное клонирование экземпляра. Производные углубляют клонирование строковых полей. |

**Пример использования**

```8:20:State.cs
// ... existing code ...
var states = new List<State>
{
    new Republic("Италия", new DateTime(1946, 6, 2), 59_000_000, "Серджо Маттарелла", "Серджо Маттарелла", 7),
    new Kingdom("Швеция", new DateTime(1523, 6, 6), 10_500_000, "Карл XVI Густав", "Карл XVI Густав", 200)
};

states.Sort(); // Использует CompareTo, сортируя по населению
var oldestFirst = states.OrderBy(s => s, State.SortByFoundationDate);

var clone = (State)states[0].Clone();
```

> **Совет:** при добавлении собственных реализаций `State` переопределяйте `Clone`, чтобы корректно копировать ссылочные поля.

## Производные классы

### `Republic`

**Назначение:** государство с выборной формой правления.

- Дополнительные свойства:
  - `President` (`string`) — имя президента.  
  - `TermYears` (`int`) — длительность президентского срока в годах.
- Конструктор:  

  ```csharp
  public Republic(string name, DateTime foundationDate, int population, string leaderName,
                  string president, int termYears)
  ```

- Переопределения:
  - `DisplayInfo()` — выводит данные о республике.  
  - `Clone()` — клонирует строковые поля для изоляции копии.

**Пример**

```6:33:Republic.cs
// ... existing code ...
var france = new Republic(
    name: "Франция",
    foundationDate: new DateTime(1789, 7, 14),
    population: 67_000_000,
    leaderName: "Эмманюэль Макрон",
    president: "Эмманюэль Макрон",
    termYears: 5);

france.DisplayInfo(); // Отобразит сведения в консоли
```

### `Kingdom`

**Назначение:** монархическая форма правления.

- Дополнительные свойства:
  - `KingName` (`string`) — имя монарха.  
  - `DynastyYears` (`int`) — длительность правления текущей династии.
- Конструктор:

  ```csharp
  public Kingdom(string name, DateTime foundationDate, int population, string leaderName,
                 string kingName, int dynastyYears)
  ```

- Переопределения:
  - `DisplayInfo()` — выводит форматированный отчёт о королевстве.  
  - `Clone()` — обеспечиваёт копирование строковых полей.

**Пример**

```6:33:Kingdom.cs
// ... existing code ...
var uk = new Kingdom(
    name: "Великобритания",
    foundationDate: new DateTime(1707, 5, 1),
    population: 67_000_000,
    leaderName: "Карл III",
    kingName: "Карл III",
    dynastyYears: 400);
```

### `Federation`

**Назначение:** федеративное устройство с разделением на субъекты.

- Дополнительные свойства:
  - `NumberOfStates` (`int`) — количество субъектов федерации.  
  - `FederalLeader` (`string`) — имя федерального лидера.
- Конструктор:

  ```csharp
  public Federation(string name, DateTime foundationDate, int population, string leaderName,
                    int numberOfStates, string federalLeader)
  ```

- Переопределения:
  - `DisplayInfo()` — выводит данные о федеративном государстве.  
  - `Clone()` — глубоко копирует строковые поля.

**Пример**

```6:37:Federation.cs
// ... existing code ...
var usa = new Federation(
    name: "США",
    foundationDate: new DateTime(1776, 7, 4),
    population: 333_000_000,
    leaderName: "Джо Байден",
    numberOfStates: 50,
    federalLeader: "Джо Байден");
```

## Работа с коллекциями состояний

`Program.Main` демонстрирует базовые операции, которые вы можете переиспользовать:

```16:88:Program.cs
// ... existing code ...
var states = new List<State>
{
    new Republic("Франция", new DateTime(1789, 7, 14), 67_000_000, "Эмманюэль Макрон", "Эмманюэль Макрон", 5),
    new Kingdom("Великобритания", new DateTime(1707, 5, 1), 67_000_000, "Карл III", "Карл III", 400),
    new Federation("Россия", new DateTime(1991, 12, 25), 146_000_000, "Владимир Путин", 85, "Владимир Путин")
};

// Сортировка по населению
states.Sort();

// Сортировка по дате основания
states.Sort(State.SortByFoundationDate);

// Поиск по диапазону населения
var filtered = states.FindAll(s => s.Population is >= 40_000_000 and <= 100_000_000);
```

> **Пауза в `Program.Main`:** строка `Console.ReadLine()` оставляет окно консоли открытым после вывода, чтобы пользователь мог изучить результаты.

## Расширение и лучшие практики

- Новые типы государств должны наследовать `State`, добавлять доменно-специфичные свойства и переопределять `DisplayInfo`/`Clone`.  
- Используйте `SortByFoundationDate` и `SortByLeaderName` вместо собственных делегатов, чтобы обеспечить единообразие сортировок.  
- При копировании объектов всегда приводите результат `Clone()` к конкретному типу (`var copy = (Republic)original.Clone();`).  
- Для тестирования логики сортировки и фильтрации покрывайте сценарии с нулевыми коллекциями, дубликатами и граничными значениями населения.

## Точка входа `Program.Main`

- Создаёт коллекцию `List<State>` с разными государствами.  
- Демонстрирует вывод сведений, сортировки и фильтрацию по диапазону населения.  
- Подходит как пример интеграции при подключении библиотеки к другим приложениям: импортируйте пространство имён `StateApp`, создайте нужные экземпляры и примените сравнение или фильтрацию согласно требованиям.

