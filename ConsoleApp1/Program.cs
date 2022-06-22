namespace ConsoleApp1
{
    class Program
    {
        public static SchoolContext ctx = new();
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hello World!");
            Console.WriteLine();
            Console.WriteLine("=======");
            Console.WriteLine(" Menu");
            Console.WriteLine("=======");
            Console.WriteLine("1. Tambah Student");
            Console.WriteLine("2. Hapus Student");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. List Student");

            Console.Write("Pilih angka : ");
            var action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        AddingStudent();
                        ExitOrNot();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        RemoveStudent();
                        ExitOrNot();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        UpdateStudent();
                        ExitOrNot();
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        ListStudent();
                        ExitOrNot();
                        break;
                    }
                default:
                    Console.WriteLine("Salah pilih!!");
                    break;
            }
        }
        public static void ListStudent()
        {
            Console.WriteLine("===================");
            Console.WriteLine("List Nama Students");
            Console.WriteLine("===================");
            int i = 1;
            foreach (var item in ctx.Students!)
            {
                Console.WriteLine("{0}. {1} {2}", item.StudentId, item.FirstName, item.LastName);
                i++;
            }
        }
        public static void ExitOrNot()
        {
            Console.WriteLine();
            Console.WriteLine("1. Kembali ke menu");
            Console.WriteLine("2. Exit");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    {
                        Console.Clear();
                        Main();
                        break;
                    }
                case 2:
                    {
                        Environment.Exit(0);
                        break;
                    }
                default:
                    Environment.Exit(1);
                    break;
            }
        }

        public static void AddingStudent()
        {
            Console.WriteLine("==============");
            Console.WriteLine("TAMBAH STUDENT");
            Console.WriteLine("==============");
            Console.Write("Your First Name : ");
            string? fname = Console.ReadLine();
            Console.Write("Your Last Name : ");
            string? lname = Console.ReadLine();

            var data = new Student()
            {
                FirstName = fname,
                LastName = lname,
            };

            ctx.Add<Student>(data);
            ctx.SaveChanges();
            Console.WriteLine("Berhasil menambah {0} {1} ke DB", fname, lname);
        }

        public static void RemoveStudent()
        {
            ListStudent();
            Console.WriteLine();
            Console.Write("Pilih nomer yang Student yang ingin di hapus : ");
            int input = Convert.ToInt32(Console.ReadLine());

            var std = ctx.Students?.FirstOrDefault(id => id.StudentId == input);
            ctx.Remove<Student>(std!);
            ctx.SaveChanges();
            Console.Clear();
            ListStudent();
            Console.WriteLine("Data dengan Id {0} berhasil di hapus!", input);
        }

        public static void UpdateStudent()
        {
            ListStudent();
            Console.WriteLine();
            Console.Write("Pilih nomer yang ingin di update : ");
            int input = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("New First Name : ");
            string? fname = Console.ReadLine();
            Console.Write("New Last Name : ");
            string? lname = Console.ReadLine();

            var data = new Student()
            {
                FirstName = fname,
                LastName = lname,
            };
            var std = ctx.Students?.FirstOrDefault(id => id.StudentId == input);

            std!.FirstName = fname;
            std.LastName = lname;
            ctx.SaveChanges();
            Console.WriteLine("Student dengan id {0} berhasil Dirubah menjadi {1} {2}", input, fname, lname);
        }
    }

}