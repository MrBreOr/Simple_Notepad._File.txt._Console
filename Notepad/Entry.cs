using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Homework_07
{
    public struct Entry
    {
        /// <summary>
        /// Список даных из/для файла
        /// </summary>
        private List<Data> list;

        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string path_file;

        /// <summary>
        /// Удалить заметку
        /// </summary>
        public void Del()
        {
            Print();
            Console.Write("Введите номер заметки которую хотите удалить: "); int index = int.Parse(Console.ReadLine());

            if (index <= list.Count())
            {
                list.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Ого! Ну ты и дал, такого же нету!");
            }
        }

        /// <summary>
        /// Создать новую заметку
        /// </summary>
        public void Create()
        {
            Console.Write("Введите название заметки: "); string Name = Console.ReadLine();
            Console.Write("Введите ХешТег: "); string heshteg = Console.ReadLine();
            Console.Write("Введите текс заметки: "); string text = Console.ReadLine();

            list.Add(new Data(Name, heshteg, text));
        }

        /// <summary>
        /// Редактировать
        /// </summary>
        public void Edit()
        {
            Console.Write("Введите номер заметки которую хотите изменить: "); int index = int.Parse(Console.ReadLine());

            if (index <= list.Count())
            {
                list[index].Edit();
            }
            else
            {
                Console.WriteLine("Ого! Ну ты и дал, такого же нету!");
            }
        }

        /// <summary>
        /// Открыть файл
        /// </summary>
        public void Open()
        {
            list = new List<Data>();
            Console.Write("Введите путь: "); string path = Console.ReadLine();
            if (path == path_file)
            {
                Console.WriteLine("Этот файл уже открыт!");
            }
            else if (File.Exists(@path))
            {
                path_file = path;
                Console.WriteLine("Файл открыт");

                using (FileStream fileOpen = new FileStream(@path_file, FileMode.Open))
                {
                    using (StreamReader file = new StreamReader(fileOpen))
                    {
                        while (!file.EndOfStream)
                        {
                            list.Add(new Data(file.ReadLine().Split('/')));
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл не найден");

            }

        }

        /// <summary>
        /// Создать файл
        /// </summary>
        public void CreateFile()
        {
            list = new List<Data>();
            Console.Write("Введите путь: "); string path = Console.ReadLine();
            File.Create(@path);
        }

        /// <summary>
        /// Добавления данных в текущий ежедневник из выбранного файла
        /// </summary>
        public void AddnewFile()
        {
            Console.Write("Введите путь к файлу который надо добавить: "); string path_newFile = Console.ReadLine();

            if (File.Exists(@path_newFile))
            {
                using (StreamReader fileOpen = new StreamReader(@path_newFile))
                {

                    while (!fileOpen.EndOfStream)
                    {
                        list.Add(new Data(fileOpen.ReadLine().Split('/')));
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл не найден");
            }
        }

        /// <summary>
        /// сохранить в новый/старый файл
        /// </summary>
        public void Save()
        {
            if (list.Count() != 0)
            {
                Console.Write("Вы хотите сохранить файл\n" +
                                "Страй - O\n" +
                                "Новый - N\n" +
                                "Отвена сохранения - любая другая кнопка");
                char key = Console.ReadKey(true).KeyChar; key = char.ToUpper(key);
                switch (key)
                {
                    case 'N':
                    case 'Т':
                        Console.Write("Введите путь по каторому нужно сохранить файл: "); string path = Console.ReadLine();
                        SaveFile(path, false);
                        break;
                    case 'O':
                    case 'Щ':
                        SaveFile(path_file, true);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Вам нечего сохранять");
            }
        }

        /// <summary>
        /// Сохранить файл
        /// </summary>
        /// <param name="path">Путь</param>
        /// <param name="flag">Старый или нет</param>
        /// <param name="newlist">Какой массив данных сохранить</param>
        private void SaveFile(string path, bool flag)
        {
            if (flag)
            {
                FileInfo file = new FileInfo(@path);
                file.Delete();

            } // удаление старого файла

            using (FileStream fileOpen = new FileStream(@path, FileMode.OpenOrCreate))
            {
                using (StreamWriter file = new StreamWriter(fileOpen))
                {
                    foreach (var l in list)
                    {
                        file.WriteLine(l.Save());
                    }
                }
            }
        }

        /// <summary>
        /// Упорядочивания записей ежедневника на выбор
        /// </summary>
        public void VSort()
        {
            if (list.Count() > 1)
            {
                Console.WriteLine("Выберете как вы хотетие упорядочить\n" +
                    "По имени - N\n" +
                    "По дате - D\n" +
                    "По объёму - V\n" +
                    "Отмена - любая другая кнопка");
                char key = Console.ReadKey(true).KeyChar; key = char.ToUpper(key);

                switch (key)
                {
                    case 'D': // дата
                    case 'В':
                        {
                            SortD d = new SortD();
                            list.Sort(d);
                        }
                        break;
                    case 'N': // имя
                    case 'Т':
                        {
                            SortN n = new SortN();
                            list.Sort(n);
                        }
                        break;
                    case 'V': // объём
                    case 'М':
                        {
                            SortT t = new SortT();
                            list.Sort(t);
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (list.Count() != 0)
            {
                Console.WriteLine("У вас 1 заметка!");
            }
            else
            {
                Console.WriteLine("У вас нет заметок!");
            }
        }

        /// <summary>
        /// Выводит все записи
        /// </summary>
        public void Print()
        {
            if (list.Count() != 0)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    Console.Write($"№{i}\t"); list[i].Print();
                }
            }
            else
            {
                Console.WriteLine("Упс... Файл оказалася пуст =(");
            }
        }
    }

    /// <summary>
    /// Сортировка по имени
    /// </summary>
    class SortN : IComparer<Data>
    {
        public int Compare(Data o1, Data o2)
        {
            int i = String.Compare(o1.Name, o2.Name);
            return i;
        }
    }

    /// <summary>
    /// Соритровка по дате
    /// </summary>
    class SortD : IComparer<Data>
    {
        public int Compare(Data o1, Data o2)
        {
            if (o1.Create_date < o2.Create_date) return -1;
            else if (o1.Create_date > o2.Create_date) return 1;
            else return 0;
        }
    }

    /// <summary>
    /// Соритровка по размеру текста
    /// </summary>
    class SortT : IComparer<Data>
    {
        public int Compare(Data o1, Data o2)
        {
            if (o1.Text < o2.Text) return -1;
            else if (o1.Text > o2.Text) return 1;
            else return 0;
        }
    }
}
