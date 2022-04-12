using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye_
{
    class Group
    {
        public string No { get; set; }
        public string Category { get; set; }
        public bool IsOnline { get; set; }
        public int Limit { get; set; }
        public static int Bp = 100;
        public static int Db = 100;
        public static int Sl = 100;
        public List<Student> studentslist = new List<Student>();


        public Group()
        {
            int a = 0;
            do
            {
                Console.WriteLine("Kateqoriyani sechin : ");
                Console.WriteLine("1.Programming.");
                Console.WriteLine("2.Design.");
                Console.WriteLine("3.System Administrator.");
                Console.Write("Sechiminiz : ");
                a = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                switch (a)
                {
                    case 1:
                        Category = "Programming";
                        No = $"BP{Bp}";
                        Bp++;
                        break;
                    case 2:
                        Category = "Design";
                        No = $"DB{Db}";
                        Db++;
                        break;
                    case 3:
                        Category = "System Administrator";
                        No = $"SL{Sl}";
                        Sl++;
                        break;
                    default:
                        Console.WriteLine("Bele kateqoriya yoxdur! Duzgun sechim edin : \n");
                        break;
                }
            } while (a != 1 && a != 2 && a != 3);
        }
    }
}