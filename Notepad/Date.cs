using System;

namespace Homework_07
{
    struct Data
    {
        /// <summary>
        /// Имя заметки
        /// </summary>
        private string name;

        /// <summary>
        /// Дата заметки
        /// </summary>
        private DateTime create_date;

        /// <summary>
        /// Дата последнего редактирования
        /// </summary>
        private DateTime edit_date;

        /// <summary>
        /// Общее слово для лёгкого поиска
        /// </summary>
        private string heshteg;

        /// <summary>
        /// Текст заметки
        /// </summary>
        private string text;

        public string Name { get { return name; } private set { } }
        public DateTime Create_date { get { return create_date; } private set { } }
        public int Text { get { return text.Length; } private set { } }




        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Text"></param>
        public Data(string Name, string heshteg, string Text)
        {
            this.name = Name;
            this.create_date = DateTime.Now;
            this.edit_date = DateTime.Now;
            this.heshteg = heshteg;
            this.text = Text;
        }

        /// <summary>
        /// Превращает массив из файла в данные
        /// </summary>
        /// <param name="data"></param>
        public Data(string[] data)
        {
            this.name = data[0];
            this.create_date = DateTime.Parse(data[1]);
            this.edit_date = DateTime.Parse(data[2]);
            this.heshteg = data[3];
            this.text = data[4];
        }

        /// <summary>
        /// Редактирвоать название/текст
        /// </summary>
        public void Edit()
        {
            Console.Write("Если вы хотите изменить название нажмите(англ.) - Y\nИзменить ХешТег - H" +
                            "\nИзменить текст - T\nОтмена - нажмите любую другую клавишу");
            char key = Console.ReadKey(true).KeyChar; key = char.ToUpper(key);

            if (key == 'Y' || key == 'Н')
            {
                Console.Write($"Ваше навание {this.name}\n\nИзменить на: ");
                this.name = Console.ReadLine();
                this.edit_date = DateTime.Now;
            }
            else if (key == 'T' || key == 'Е')
            {
                Console.Write($"Ваш текст {this.text}\n\nИзменить на: ");
                this.text = Console.ReadLine();
                this.edit_date = DateTime.Now;
            }
            else if (key == 'H' || key == 'Р')
            {
                Console.Write($"Ваш ХешТег {this.heshteg}\n\nИзменить на: ");
                this.heshteg = Console.ReadLine();
                this.edit_date = DateTime.Now;
            }
        }

        /// <summary>
        /// Печать в консоль данных
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Название - {0}, Дата созадния - {1}\n\tХешТег - {2}, Дана последнего редактирвоания - {3}:\n\t--{4}\n",
                this.name,
                this.create_date,
                this.heshteg,
                this.edit_date,
                this.text);
        }

        /// <summary>
        /// Формат в котором сохраняюстя данные
        /// </summary>
        public string Save()
        {
            return $"{this.name}/{this.create_date}/{this.edit_date}/{this.heshteg}/{this.text}";
        }
    }
}
