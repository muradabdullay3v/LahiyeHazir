using System;
using System.Collections.Generic;

namespace Lahiye_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> StudentsList = new List<Student>();
            List<Student> ObshiStuList = new List<Student>();
            List<Group> GroupsList = new List<Group>();
            bool isGroup = false;
            bool isStu = false;
            //AddGroup(GroupsList);
            //Console.WriteLine("\n");
            //AddStudent(ref StudentsList, ObshiStuList, GroupsList);
            //Console.WriteLine("\n");
            //ShowInfo(GroupsList, StudentsList);
            //Console.WriteLine("\n");
            int menuvalue = 0;
            do
            {
                Console.WriteLine("Menu : ");
                Console.WriteLine("1.Yeni qrup yarat");
                Console.WriteLine("2.Qruplarin siyahisini goster");
                Console.WriteLine("3.Qrup uzerinde duzelish etmek");
                Console.WriteLine("4.Qrupdaki telebelerin siyahisini goster");
                Console.WriteLine("5.Bütün telebelerin siyahisini goster");
                Console.WriteLine("6.Telebe yarat");
                Console.WriteLine("7.Quit");
                Console.Write("Sechiminiz : ");
                menuvalue = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                switch (menuvalue)
                {
                    case 1:
                        AddGroup(GroupsList);
                        isGroup = true;
                        break;
                    case 2:
                        if (isGroup)
                        {
                            ShowInfo(GroupsList, StudentsList);
                        }
                        else
                        {
                            Console.WriteLine("Qruplar yaradilmayib!!");
                        }
                        break;
                    case 3:
                        if (isGroup)
                        {
                            Console.Write("Edit olunacaq qrupu sechin : ");
                            int a = 0;
                            foreach (var item in GroupsList)
                            {
                                a++;
                                Console.WriteLine($"{a}.{item.No}");
                            }
                            string qrupsech = Console.ReadLine();
                            Console.WriteLine("\n");
                            foreach (var item in GroupsList)
                            {
                                if (item.No == qrupsech.ToUpper())
                                {
                                    Console.Write("Yeni adi daxil edin : ");
                                    string newad = Console.ReadLine().ToUpper();
                                    Console.WriteLine("\n");
                                    foreach (var item1 in GroupsList)
                                    {
                                        if (item1.No != newad)
                                        {
                                            item.No = newad;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Bele qrup artiq var!!\n");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Bele qrup movcud deyil!!\n");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Qruplar hele yaradilmayib!!");
                        }
                        

                        break;
                    case 4:
                        if (isGroup)
                        {
                            Console.Write("Telebeleri gosterilecek qrupun adini daxil edin : ");
                            string qrupadi = Console.ReadLine();
                            Console.WriteLine("\n");
                            bool var = false;
                            foreach (var item in GroupsList)
                            {
                                if (qrupadi.ToUpper() == item.No)
                                {
                                    var = true;
                                    for (int i = 0; i < item.studentslist.Count; i++)
                                    {
                                        Console.WriteLine($"Telebenin adi : {item.studentslist[i].Fullname}\nType : {item.studentslist[i].Type}\nQrupu : {item.studentslist[i].GroupNo}\n");
                                    }
                                }
                                if (!var)
                                {
                                    Console.WriteLine("Bele qrup yoxdue brat !\n");
                                }
                                var = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Qruplar hele yaradilmayiblar");
                        }
                        break;
                    case 5:
                        foreach (var item in ObshiStuList)
                        {
                            Console.WriteLine($"Adi : {item.Fullname}\nGroup : {item.GroupNo}\nZemaneti : {item.Type}\n");
                        }
                        break;
                    case 6:
                        if(isGroup)
                        AddStudent(ref StudentsList, ObshiStuList, GroupsList);
                        else
                            Console.WriteLine("Qruplar hele yaradilmayib!!");
                        break;
                    case 7:
                        Console.WriteLine("Proqram sona catdi !!\n");
                        break;
                    default:
                        Console.WriteLine("Menuda bele opsiya yoxdur! Yeniden sechim edin : \n");
                        break;
                }
            } while (menuvalue != 7);
        }

        static void AddGroup(List<Group> grouplist)
        {
            int OnlineCheck = 0;
            Console.Write("Yaratmaq istediyiniz qruplarin sayini yazin : ");
            int say = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            Group[] Groups = new Group[say];
            for (int i = 0; i < say; i++)
            {
                Groups[i] = new Group();
                do
                {
                    Console.WriteLine("Dersin ne formatda olacagini sechin : ");
                    Console.WriteLine("1.Online.");
                    Console.WriteLine("2.Offline.");
                    Console.Write("Sechiminiz : ");
                    OnlineCheck = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n");
                    switch (OnlineCheck)
                    {
                        case 1:
                            Groups[i].IsOnline = true;
                            break;
                        case 2:
                            Groups[i].IsOnline = false;
                            break;
                        default:
                            Console.WriteLine("Bele opsiya yoxdur! Yeniden sechim edin : \n");
                            break;
                    }
                } while (OnlineCheck != 1 && OnlineCheck != 2);
                if (Groups[i].IsOnline)
                {
                    Groups[i].Limit = 15;
                }
                else
                {
                    Groups[i].Limit = 10;
                }
                grouplist.Add(Groups[i]);
            }
        }

        static void ShowInfo(List<Group> GroupsList, List<Student> StudentsList)
        {
            foreach (var item in GroupsList)
            {
                Console.WriteLine($"No : {item.No}\nOnline : {item.IsOnline}\nStudents number : {item.studentslist.Count}\n");
            }
        }

        static void AddStudent(ref List<Student> StudentsList, List<Student> ObshiStuList, List<Group> GroupsList)
        {
            int typecheck = 0;
            Console.Write("Yaratmaq istediyiniz studentlerin sayini daxil edin : ");
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            StudentsList = new List<Student>();
            Student[] Students = new Student[count];
            for (int i = 0; i < count; i++)
            {
                Students[i] = new Student();
                Console.Write("Full name : ");
                Students[i].Fullname = Console.ReadLine();
                while (Students[i].Fullname == "" || Students[i].Fullname == " ")
                {
                    Console.WriteLine("Sevh format yeniden elave et\n");
                    Console.Write("Full name : ");
                    Students[i].Fullname = Console.ReadLine();
                }
                do
                {
                    Console.WriteLine("Studentin qarantili olub olmamsini secin : ");
                    Console.WriteLine("1.Qarantili");
                    Console.WriteLine("2.Qarantisiz");
                    Console.Write("Sechiminiz : ");
                    typecheck = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n");
                    switch (typecheck)
                    {
                        case 1:
                            Students[i].Type = true;
                            break;
                        case 2:
                            Students[i].Type = false;
                            break;
                        default:
                            Console.WriteLine("Bele opsiya yoxdur! Yeniden sechiM edin : \n");
                            break;
                    }
                } while (typecheck != 1 && typecheck != 2);
                ObshiStuList.Add(Students[i]);
                Console.WriteLine("Studente qrup secin :\n");
                int a = 0;
                foreach (var item in GroupsList)
                {
                    a++;
                    Console.WriteLine($"{a}.{item.No}");
                }
                Console.Write("Sechiminiz :");
                string selectgroup = Console.ReadLine();
                Console.WriteLine("\n");
                bool var = false;
                foreach (var item in GroupsList)
                {
                    if (selectgroup.ToUpper() == item.No)
                    {
                        Students[i].GroupNo = item.No;
                        GroupsList[i].studentslist.Add(Students[i]);
                        var = true;
                    }
                }
                if (!var)
                {
                    Console.WriteLine("Bele qrup yoxudur!!\n");
                }
                var = false;
            }
        }
    }
}