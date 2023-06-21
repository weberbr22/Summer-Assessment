using System;

namespace SummerAssessment // Note: actual namespace depends on the project name.
{
    public class SaleData
    {
        public string ID;
        public int Quantity;

        public SaleData(string id, int quantity)
        {
            this.ID = id;
            this.Quantity = quantity;
        }
    }

    internal class OOP
    {
        static void Main()
        {
            Employee[] employees = new Employee[8];

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            docPath = Path.Combine(docPath, "Academic/Computing/C#/Employees.txt");

            StreamReader reader = new StreamReader(docPath);
            string text = reader.ReadToEnd();
            string[] hoursData = File.ReadAllLines(text);

            for (int i = 0; i < hoursData.Length; i++)
            {
                string[] data = hoursData[i].Split(',');
                float hourlyPay = float.Parse(data[0]);
                string employeeNumber = data[1];
                string jobTitle = data[3];
                float[] pay = new float[52];
                if (data.Length == 4)
                {
                    employees[i] = new Employee(hourlyPay, employeeNumber, jobTitle, pay);
                }
                else if (data.Length == 5)
                {
                    double bonusValue = double.Parse(data[2]);
                    employees[i] = new Manager(hourlyPay, employeeNumber, jobTitle, pay, bonusValue);
                }
            }
            EnterHours(employees);

            foreach (Employee employee in employees)
            {
                Console.WriteLine("Employee Number: " + employee.GetEmployeeNumber);
                Console.WriteLine("Total Pay: $" + employee.GetTotalPay());
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        public class Employee
        {
            public float HourlyPay;
            public string EmployeeNumber;
            public string JobTitle;
            public float[] PayYear2022;

            public Employee(float HourlyPay, string EmployeeNumber, string JobTitle, float[] PayYear2022)
            {
                this.HourlyPay = HourlyPay;
                this.EmployeeNumber = EmployeeNumber;
                this.JobTitle = JobTitle;
                this.PayYear2022 = PayYear2022;
            }

            public static void Constructor(float HourlyPay, string EmployeeNumber, string JobTitle)
            {
                float[] PayYear2022 = new float[52];
                for (int i = 0; i < PayYear2022.Length; i++)
                {
                    PayYear2022[i] = 0.0f;
                }
                new Employee(HourlyPay, EmployeeNumber, JobTitle, PayYear2022);
            }

            public string GetEmployeeNumber
            {
                get { return EmployeeNumber; }
            }

            virtual public void SetPay(int week, int hours)
            {
                float pay = hours * HourlyPay;
                PayYear2022[week] = pay;
            }

            public float GetTotalPay()
            {
                float total = 0.0f;
                foreach (float var in PayYear2022)
                {
                    total += var;
                }
                return total;
            }
        }

        public class Manager : Employee
        {
            private double BonusValue;

            public Manager(float HourlyPay, string EmployeeNumber, string JobTitle, float[] PayYear2022, double BonusValue)
                : base(HourlyPay, EmployeeNumber, JobTitle, PayYear2022)
            {
                this.HourlyPay = HourlyPay;
                this.EmployeeNumber = EmployeeNumber;
                this.JobTitle = JobTitle;
                this.PayYear2022 = PayYear2022;
                this.BonusValue = BonusValue;
            }

            public static void Constructor(float HourlyPay, string EmployeeNumber, string JobTitle, float BonusValue)
            {
                float[] PayYear2022 = new float[52];
                for (int i = 0; i < PayYear2022.Length; i++)
                {
                    PayYear2022[i] = 0.0f;
                }
                new Manager(HourlyPay, EmployeeNumber, JobTitle, PayYear2022, BonusValue);
            }

            public override void SetPay(int week, int hours)
            {
                base.SetPay(week, hours + Convert.ToInt16(BonusValue));
            }
        }

        static void EnterHours(Employee[] employees)
        {
            string[] lines = File.ReadAllLines("HoursWeek1.txt");
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                string employeeNumber = data[0];
                int hoursWorked = int.Parse(data[1]);
                foreach (Employee employee in employees)
                {
                    if (employee.GetEmployeeNumber == employeeNumber)
                    {
                        employee.SetPay(0, hoursWorked);
                        break;
                    }
                }
            }
        }
    }

    internal class Program
    {
        static void SortDescending(string[] Array)
        {
            int ArrayLength = Array.Length;
            string Temp;

            for (int x = 0; x < ArrayLength - 1; x++)
            {
                for(int y = 0; y < ArrayLength - x - 1; y++)
                {
                    if (Array[y][0] < Array[y][0])
                    {
                        Temp = Array[y];
                        Array[y] = Array[y + 1];
                        Array[y + 1] = Temp;
                    }
                }
            }

            foreach (var i in Array)
            {
                Console.WriteLine(i);
            }
        }

        static int Enqueue(SaleData New, SaleData[] CircularQueue, int Tail)
        {
            if (Tail == 5)
            {
                return -1;
            }

            else
            {
                New = CircularQueue[Tail];
                Tail++;
                return 1;
            }
        }

        static SaleData Dequeue(SaleData[] CircularQueue, int Tail, int Head)
        {
            if (Tail == 0)
            {
                return null;
            }
            else
            {
                Head++;
                return CircularQueue[Head];
            }
        }

        static void EnterRecord(string ID, int Quantity, SaleData[] CircularQueue, int Tail)
        {
            SaleData record = new SaleData(ID, Quantity);
            int response = Enqueue(record, CircularQueue, Tail);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Assessment!");

            // Part 1

            string[] Animals = new string[10];
            Animals[0] = "horse";
            Animals[1] = "lion";
            Animals[2] = "rabbit";
            Animals[3] = "mouse";
            Animals[4] = "bird";
            Animals[5] = "deer";
            Animals[6] = "whale";
            Animals[7] = "elephant";
            Animals[8] = "kangaroo";
            Animals[9] = "tiger";

            SortDescending(Animals);

            // Part 2

            SaleData[] CircularQueue = new SaleData[5];
            int tail = 0;
            int head = 0;
            int NumberOfItems = 0;

            for (int i = 0; i <= 5; i++)
            {
                CircularQueue[i-1] = new SaleData("", -1);
            }

            EnterRecord("ADF", 10, CircularQueue, tail);
            EnterRecord("OOP", 1, CircularQueue, tail);
            EnterRecord("BXW", 5, CircularQueue, tail);
            EnterRecord("XXZ", 22, CircularQueue, tail);
            EnterRecord("HQR", 6, CircularQueue, tail);
            EnterRecord("LLP", 3, CircularQueue, tail);
            Dequeue(CircularQueue, tail, head);
            if (head == tail)
            {
                Console.WriteLine("Queue empty");
            }
            else
            {
                Console.WriteLine(CircularQueue[0].ID + " " + CircularQueue[0].Quantity);
            }
            EnterRecord("LLP", 3, CircularQueue, tail);
            for (int i = head; i < tail; i++)
            {
                Console.WriteLine(CircularQueue[i].ID + " " + CircularQueue[i].Quantity);
            }
        }
    }
}