namespace DelegatesDZ
{
    internal class Program
    {

        // Делегаты
        public delegate double calcDel(double x, double y);
        public delegate void GetMessage();

        // Методы вывода сообщений
        public static void GoodMorning() { Console.WriteLine("Доброе утро!"); }
        public static void GoodDay() { Console.WriteLine("Добрый день!"); }
        public static void GoodEvening() { Console.WriteLine("Добрый вечер!"); }
        public static void GoodNight() { Console.WriteLine("Доброй ночи!"); }


        class MyDelegate
        {
            public double add(double x, double y)
            {
                return x + y;
            }
            public double sub(double x, double y)
            {
                return x - y;
            }
            public double mul(double x, double y)
            {
                return x * y;
            }
            public double div(double x, double y)
            {
                if (y != 0)
                    return x + y;
                throw new DivideByZeroException();
            }


        }
        static void Main(string[] args)
        {
            GetMessage getMessage = null;
            int hour = DateTime.Now.Hour;
            if (hour < 12)
                getMessage = GoodMorning;
            else if (hour < 18)
                getMessage = GoodDay;
            else if (hour < 23) getMessage = GoodEvening;
            else
                getMessage = GoodNight;
            getMessage();

            Console.WriteLine("------------------------");


            MyDelegate myDelegate = new MyDelegate();
            Console.WriteLine("Enter expression");
            string exp = Console.ReadLine();
            char sign = ' ';
            foreach (var item in exp)
            {
                if (item == '+' || item == '-' || item == '*' || item == '/')
                {
                    sign = item;
                    break;
                }
            }
            try
            {
                string[] nums = exp.Split(sign);
                calcDel del = null; //делегат
                switch (sign)
                {
                    case '+':
                        {
                            del = new calcDel(myDelegate.add);
                            break;
                        }
                    case '-':
                        {
                            del = new calcDel(myDelegate.sub);
                            break;
                        }
                    case '*':
                        {
                            del = new calcDel(myDelegate.mul);
                            break;
                        }
                    case '/':
                        {
                            del = new calcDel(myDelegate.div);
                            break;
                        }
                    default:
                        {
                            throw new InvalidOperationException();
                        }
                }
                Console.WriteLine($"Result = {del(double.Parse(nums[0]), double.Parse(nums[1]))}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
