using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19
{
    class Computer
    {
        public int Id { get; set; }
        public string Processor { get; set; }
        public int OZU { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComp = new List<Computer>()
        {
        new Computer(){ Id=1, Processor="Центральный", OZU=16, Price=30350, Amount=15 },
        new Computer(){ Id=2, Processor="Графический ускоритель", OZU=8, Price=44190, Amount=63 },
        new Computer(){ Id=3, Processor="Центральный", OZU=8, Price=36120, Amount=44 },
        new Computer(){ Id=4, Processor="Однокристальные системы", OZU=32, Price=74870, Amount=57 },
        new Computer(){ Id=5, Processor="Однокристальные системы", OZU=4, Price=27010, Amount=30 },
        new Computer(){ Id=6, Processor="Графический ускоритель", OZU=16, Price=33210, Amount=21 },
        new Computer(){ Id=7, Processor="Центральный", OZU=8, Price=55630, Amount=5 },
        new Computer(){ Id=8, Processor="Однокристальные системы", OZU=32, Price=61730, Amount=34 },
        };

            Console.WriteLine("Все компьютеры с указанным процессором:");
            string processor = Console.ReadLine();
            List<Computer> computer1 = listComp.Where(c => c.Processor == processor).ToList();
            foreach (Computer d in computer1)
                Console.WriteLine($"{d.Id} {d.Processor} {d.OZU} {d.Price} {d.Amount}");
            Console.WriteLine();



            Console.WriteLine("Объем ОЗУ:");
            int ozu = Convert.ToInt32(Console.ReadLine());
            List<Computer> computer2 = listComp.Where(c => c.OZU == ozu).ToList();
            foreach (Computer d in computer2)
                Console.WriteLine($"{d.Id} {d.Processor} {d.OZU} {d.Price} {d.Amount}");
            Console.WriteLine();

            Console.WriteLine("Сортировка по увеличению стоимости:");
            Computer computer3 = listComp.OrderBy(d => d.Price).FirstOrDefault();
            Console.WriteLine($"{computer3.Id} {computer3.Processor} {computer3.OZU} {computer3.Price} {computer3.Amount}");
            Console.WriteLine();

            Console.WriteLine("Группировка по типу процессора:");
            IEnumerable<IGrouping<string, Computer>> computer4 = listComp.GroupBy(x => x.Processor);
            foreach (IGrouping<string, Computer> gr in computer4)
            {
                Console.WriteLine(gr.Key);
                foreach (Computer d in gr)
                {
                    Console.WriteLine($"{d.Id} {d.Processor} {d.OZU} {d.Price} {d.Amount}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Самый дорогой компьютер");
            List<Computer> computer5 = (from c in listComp
                                        where c.Price == listComp.Max(x => x.Price)
                                        select c).ToList();
            foreach (Computer d in computer5)
                Console.WriteLine($"{d.Id} {d.Processor} {d.OZU} {d.Price} {d.Amount}");
            Console.WriteLine();

            Console.WriteLine("Самый дешевый компьютер");
            List<Computer> computer6 = (from c in listComp
                                        where c.Price == listComp.Min(x => x.Price)
                                        select c).ToList();
            foreach (Computer d in computer6)
                Console.WriteLine($"{d.Id} {d.Processor} {d.OZU} {d.Price} {d.Amount}");
            Console.WriteLine();

            Console.WriteLine("Количество компьютеров не менее 30:");
            List<Computer> computer7 = (from c in listComp
                                        where c.Amount >= 30
                                        select c).ToList();

            foreach (Computer d in computer7)
                Console.WriteLine($"{d.Id} {d.Processor} {d.OZU} {d.Price} {d.Amount}");
            Console.ReadKey();
        }
    }
}