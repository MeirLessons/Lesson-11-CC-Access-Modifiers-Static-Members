using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11_CC_Access_Modifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Access Modifiers
            //Default Access:
            //Class: Internal
            //Memebers(fields, methods): private
            BankDetails b = new BankDetails();
            //b.SetPassword("a12345");
            b.GetPassword();
            b.name = "asdasd";
            //b.lName = "cohen";
            //string ss = b.password;
            //b.password = "123";
            #endregion

            #region Static Modifier

            Person p = new Person();
            p.age = 24;
            p.GetAge();
            Person.GetSumOfPersons();

            //Program p1 = new Program();
            //p1.Foo();// By Instance
            //Program.Main(null);//By Class
            //p.Main();
            //Console c = new Console();
            Console.WriteLine();
            //c.WriteLine()
            BigCircle bc = new BigCircle(3.3);
            Circle.SetPie(3.14);
            double myPie = Circle.pie2;

            Circle c1 = new Circle(3.2);
            
            Circle c2 = new Circle(4.4);
            Console.WriteLine(c1.GetRadius());
            Console.WriteLine(c1.CalcArea());
            Console.WriteLine(c2.GetRadius());
            Console.WriteLine(c2.CalcArea());


            Console.WriteLine(Circle.GetInstanceRadius(c1));
            Console.WriteLine(Circle.GetInstanceRadius(c2));
            #endregion
        }

        public void Foo()
        {

        }
    }

    public class Circle
    {
        public static double pie;
        public const/*Static*/ double pie2 = 3.14;
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public static double GetInstanceRadius(Circle c)
        {
            return c.radius;
        }

        public static bool CompareRadius(Circle c1, Circle c2)
        {
            return (c1.radius == c2.radius);
        }

        public double GetRadius()
        {
            return this.radius;
        }

        public double CalcArea()
        {
            
            return pie2 * radius * radius;
        }

        public static void SetPie(double newPie)
        {
            pie = newPie;
        }
    }

    public class BigCircle : Circle
    {
        public BigCircle(double radius) : base(radius)
        {

        }
    }

    class Person
    {
        private static int sumOfPersons;
        public int age;
        public readonly DateTime bornDate = new DateTime(2020,12,10);

        public Person()
        {
            bornDate = DateTime.Now;
            sumOfPersons++;
        }
        public static int GetSumOfPersons()
        {
            return sumOfPersons;
        }

        public int GetAge()
        {

            return this.age;
        }

        public void SetBornDate(DateTime dateTime)
        {

        }
    }

    public class BankDetails
    {
        public string bankName; // נגיש לכל העולם
        private string password; // נגיש רק למחלקה עצמה
        protected /*or*/ internal string name;// או יורשים או אותו פרויקט
        private /*and*/ protected string lName; //רק מהפרוייקט הנוכחי ולמחלקות היורשות

        public BankDetails()
        {

        }

        public BankDetails(string bankName, string password, string name, string lName)
        {
            this.bankName = bankName;
            this.password = password;
            this.name = name;
            this.lName = lName;
        }


        private/*By Default*/ string GetName()
        {
            return name + lName;
        }

        internal string GetPassword() // נגיש רק לפרוייקט עצמו
        {
            return this.password;
        }
        protected void SetPassword(string newPassword) // נגיש רק למחלקות היורשות
        {
            if(!string.IsNullOrEmpty(newPassword) && newPassword.Length > 10)
                this.password = newPassword;
        }
    }

    public class MYclass
    {
        public MYclass()
        {
            BankDetails b = new BankDetails();
            b.GetPassword();//Must Create Instance
        }
    }
    public class SubBankDetails : BankDetails
    {
        public string accountNumber;
        public SubBankDetails()
        {
            name = "asd";
            lName = "levi";
            SetPassword("9128371092laksd");
            GetPassword();
        }
    }
}
