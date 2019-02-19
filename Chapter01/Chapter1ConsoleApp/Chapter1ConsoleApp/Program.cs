using System;

namespace Chapter1ConsoleApp
{
    class Program
    {
     
        static void Main(string[] args)
        {
            /* Example 1 (Tuple)
            var person = GetPerson();
            Console.WriteLine($"ID : {person.Item1}, Name : {person.Item2}, DOB : {person.Item3}");
            */

            /* Example 2 (Tuple)
            var person = GetPerson();
            Console.WriteLine($"ID : {person.id}, Name : {person.name}, DOB : {person.dob}");
            */

            /* Example 3 (Constant Pattern)
            SavePerson(null);
            */

            /* Example 4 (Type Pattern)
            SavePerson(new Person { ID = 1 });
            */

            /* Example 5 (Var Pattern)
            SavePerson(new Person());
            */

            /* Example 10 Creating Local Functions
            Console.WriteLine(ExecuteFactorial(4));
            */

           
        }

        /* Example 1 (Tuple)
        static (int, string, DateTime) GetPerson()
        {
            
            return (1, "Mark Thompson", new DateTime(1970, 8, 11));
           
        }
         */
        /* Example 2 (Tuple)
        static (int id, string name, DateTime dob) GetPerson()
        {
            return (1, "Mark Thompson", new DateTime(1970, 8, 11));
        }
        */

        /* Example 3 (Constant Pattern)
        static void SavePerson(Person person)
        {
            if (person is null) return;
        }
        */

        /* Example 4 (Type Pattern)       
        static void SavePerson(Person person)
        {
            //if (!(person.ID is int i)) return;
            //if (!(person.ID is int i) && !(person.DOB>DateTime.Now.AddYears(-20))) return;
            Console.WriteLine($"Person ID is {i}");
        }*/


        /* Example 5 Var pattern 
        static void SavePerson(Person person)
        {
            if (person is var Person) Console.WriteLine($"It is a person object and type is {person.GetType()}");
        }
        */

        /* Example 10 Creating Local Functions
        static long ExecuteFactorial(int n)
        {
            if (n < 0) throw new ArgumentException("Must be non negative", nameof(n));

            else return CheckFactorial(n);

            long CheckFactorial(int x)
            {
                if (x == 0) return 1;
                return x * CheckFactorial(x - 1);
            }
        }
         */

       
    }

    class Person
    {
        public int ID { set; get; }
        public string Name { get; set; }

        public DateTime DOB { get; set; }
    }

    /* Example 6 Reference Returns
    public class PersonManager
    {
        Person _person ;

        ref Person GetPersonInformation()
        {
            _person  = CallPersonHttpService();
            return ref _person ;
        }

        Person CallPersonHttpService()
        {
            //do something to invoke API
            return new Person();
        }

    }
    */

    /*Example 7 Expression Bodied Members
    public class PersonManager
    {
        Person _person;

        PersonManager(Person person) => _person = person;

        //Destructor
        ~PersonManager() => _person = null;

        /* Expression bodies member Example 8
        private String _name;
        public String Name
        {
            get => _name;
            set => _name = value;

        }
        */

    /* Expression bodied member Example 9
    private String _name;
    public String Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException();

    }
    */

    /* Example 11 Out Variables 
    class PersonManager {

        public void GetPerson()
        {
            int year;
            int month;
            int day;
            GetPersonDOB(out year, out month, out day);
        }

        public void GetPersonDOB(out int year, out int month, out int day )
        {
            year = 1980;
            month = 11;
            day = 3;
        }

    }
    */

}

   

}
