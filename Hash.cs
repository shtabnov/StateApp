using System;
using System.Collections;
using System.Collections.Generic;

namespace StateApp
{
    public class Hash : IEnumerable
    {
        protected ArrayList keys;
        protected List<State> values;

        // Конструктор 1: создание пустой коллекции
        public Hash()
        {
            keys = new ArrayList();
            values = new List<State>();
        }

        // Конструктор 2: создание пустой коллекции с начальной ёмкостью
        public Hash(int capacity)
        {
            keys = new ArrayList(capacity);
            values = new List<State>(capacity);
        }

        // Конструктор 3: создание коллекции из другой коллекции
        public Hash(Hash h)
        {
            if (h == null)
            {
                keys = new ArrayList();
                values = new List<State>();
            }
            else
            {
                keys = new ArrayList(h.keys);
                values = new List<State>(h.values);
            }
        }

        // Свойство Count - количество элементов
        public int Count => keys.Count;

        // Индексатор для доступа по ключу
        public State this[object key]
        {
            get
            {
                int index = keys.IndexOf(key);
                if (index >= 0 && index < values.Count)
                    return values[index];
                throw new KeyNotFoundException($"Ключ '{key}' не найден в коллекции.");
            }
            set
            {
                int index = keys.IndexOf(key);
                if (index >= 0)
                {
                    values[index] = value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        // Метод добавления одного элемента
        public void Add(object key, State state)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "Ключ не может быть null.");
            if (state == null)
                throw new ArgumentNullException(nameof(state), "Значение не может быть null.");
            if (keys.Contains(key))
                throw new ArgumentException($"Ключ '{key}' уже существует в коллекции.", nameof(key));

            keys.Add(key);
            values.Add(state);
        }

        // Метод добавления нескольких элементов
        public void AddRange(Hash h)
        {
            if (h == null)
                throw new ArgumentNullException(nameof(h), "Коллекция не может быть null.");

            for (int i = 0; i < h.Count; i++)
            {
                object? key = h.keys[i];
                if (key != null && !keys.Contains(key))
                {
                    keys.Add(key);
                    values.Add(h.values[i]);
                }
            }
        }

        // Метод удаления одного элемента
        public bool Remove(object key)
        {
            if (key == null)
                return false;

            int index = keys.IndexOf(key);
            if (index >= 0)
            {
                keys.RemoveAt(index);
                values.RemoveAt(index);
                return true;
            }
            return false;
        }

        // Метод удаления нескольких элементов
        public int RemoveAll(Hash h)
        {
            if (h == null)
                return 0;

            int removedCount = 0;
            for (int i = 0; i < h.Count; i++)
            {
                object? key = h.keys[i];
                if (key != null && Remove(key))
                    removedCount++;
            }
            return removedCount;
        }

        // Метод поиска элемента по значению
        public object? Find(State value)
        {
            if (value == null)
                return null;

            int index = values.IndexOf(value);
            if (index >= 0 && index < keys.Count)
                return keys[index];
            return null;
        }

        // Метод клонирования коллекции (глубокое копирование)
        public Hash Clone()
        {
            Hash cloned = new Hash(this.Count);
            for (int i = 0; i < this.Count; i++)
            {
                object? key = this.keys[i];
                if (key != null)
                {
                    State clonedValue = (State)this.values[i].Clone();
                    cloned.Add(key, clonedValue);
                }
            }
            return cloned;
        }

        // Метод поверхностного копирования
        public Hash ShallowCopy()
        {
            return new Hash(this);
        }

        // Метод очистки коллекции
        public void Clear()
        {
            keys.Clear();
            values.Clear();
        }

        // Реализация интерфейса IEnumerable
        public IEnumerator GetEnumerator()
        {
            return new HashEnumerator(this);
        }

        // Внутренний класс для реализации IEnumerator
        private class HashEnumerator : IEnumerator
        {
            private Hash hash;
            private int currentIndex;

            public HashEnumerator(Hash hash)
            {
                this.hash = hash;
                currentIndex = -1;
            }

            public object Current
            {
                get
                {
                    if (currentIndex < 0 || currentIndex >= hash.Count)
                        throw new InvalidOperationException();
                    object? key = hash.keys[currentIndex];
                    if (key == null)
                        throw new InvalidOperationException("Ключ не может быть null.");
                    return new KeyValuePair<object, State>(key, hash.values[currentIndex]);
                }
            }

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < hash.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }

        // Вспомогательный метод для получения ключа по индексу
        public object? GetKey(int index)
        {
            if (index >= 0 && index < keys.Count)
                return keys[index];
            return null;
        }

        // Вспомогательный метод для получения значения по индексу
        public State? GetValue(int index)
        {
            if (index >= 0 && index < values.Count)
                return values[index];
            return null;
        }

        // Проверка наличия ключа
        public bool ContainsKey(object key)
        {
            return keys.Contains(key);
        }

        // Проверка наличия значения
        public bool ContainsValue(State value)
        {
            return values.Contains(value);
        }
    }
}

