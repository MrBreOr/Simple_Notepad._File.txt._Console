using System;

namespace Homework_07
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Entry list = new Entry();
            while (true)
            {
                Console.WriteLine("\n=====Инструкция=====" +
                    "\nСоздать файл - F" +
                    "\nОткрыть файл - O" +
                    "\nРедактировать заметку - E" +
                    "\nРаспечатать файл- G" +
                    "\nУдалить заметку - D" +
                    "\nСоздать заметку - C" +
                    "\nДобавление из другого файла - N" +
                    "\nСортировка заметок - R" +
                    "\nСохранить - S" +
                    "\nПочистить консоль - W" +
                    "\nВыйти из программы - X");

                char key = Console.ReadKey(true).KeyChar; key = char.ToUpper(key);
                Console.WriteLine();
                switch (key)
                {
                    case 'F':
                    case 'А':
                        list.CreateFile();
                        break;
                    case 'O':
                    case 'Щ':
                        list.Open();
                        break;
                    case 'E':
                    case 'У':
                        list.Edit();
                        break;
                    case 'G':
                    case 'П':
                        list.Print();
                        break;
                    case 'D':
                    case 'В':
                        list.Del();
                        break;
                    case 'C':
                    case 'С':
                        list.Create();
                        break;
                    case 'N':
                    case 'Т':
                        list.AddnewFile();
                        break;
                    case 'R':
                    case 'К':
                        list.VSort();
                        break;
                    case 'S':
                    case 'Ы':
                        list.Save();
                        break;
                    case 'W':
                    case 'Ц':
                        Console.Clear();
                        break;
                    case 'X':
                    case 'Ч':
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
