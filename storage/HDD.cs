using System;
using static System.Console;
using System.Collections.Generic;

namespace storage
{
     class HDD : Storage
    {
        private int number = 2;//кол-во разделов
        public HDD(string name, string model) : base(name, model)
        {
            Speed= 4026531840;//4 026 531 840 бит(скорость)
            Tom[] mass = new Tom[number];
            for (int i = 0; i < number; i++)
            {
                mass[i] = new Tom();
                Free += mass[i].Space;
            }
        }
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                HDD p = (HDD)obj;
                return (Name == p.Name) && (Speed == p.Speed) && (Model == p.Model) && (Free == p.Free);
            }
        }
        public override int GetHashCode()
        {
            return Tuple.Create(Name, Speed, Model, Free).GetHashCode();
        }
        protected override void Memory()
        {
            WriteLine("Общий объём: 128 Гб");
        }

        public override void Copy(double value, string name)
        {
            switch (name)
            {
                case "бит":
                    Free -= value;
                    break;
                case "б":
                    value *= 8;
                    Free -= value;
                    break;
                case "байт":
                    value *= 8;
                    Free -= value;
                    break;
                case "Кб":
                    value *= 8; value *= 1024;
                    Free -= value;
                    break;
                case "Мб":
                    value *= 8; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
                case "Гб":
                    value *= 8; value *= 1024; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
            }
            Write($"\t\tСъёмный HDD\nСкопировано удачно!\nВремя: ");
            if (value / Speed < 60)
                WriteLine(value / Speed + " сек");
            else if (value / Speed < 3600) WriteLine(value / Speed / 60 + " мин");
            else WriteLine(value / Speed / 3600 + " часов");
            FreeMemory();
            Line();
        }

        protected override void FreeMemory()
        {
            Free /= 8;
            Free /= 1024;
            Free /= 1024;
            Free /= 1024;
            WriteLine($"Свободное место на диске: {Free} Гб");
            Free *= 1024;
            Free *= 1024;
            Free *= 1024;
            Free *= 8;
        }

        public override void GetInfo()
        {
            WriteLine("Название устройства: " + Name);
            WriteLine("Модель устройства: " + Model);
            WriteLine($"Кол-во томов: {number}");
            Tom[] mass = new Tom[number];
            for (int i = 0; i < number; i++)
            {
                mass[i] = new Tom();
                WriteLine($"Название {i + 1} тома: {mass[i].Name}"+(i+1));
                WriteLine($"Размер {i + 1} тома: 64 Гб");
            }
            Memory();
            FreeMemory();
            WriteLine("Скорость интерфейса: 480 Мб/сек");
            Line();
        }
    }
    class Tom
    {
        public string Name { get; } = "Tom";
        public double Space { get; } = 549755813888;//549 755 813 888 бит
    }

}