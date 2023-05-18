namespace Practics_Work_6_Interfaces
{
    class Program
    {
        const string jetName = "Пасажирський літак";
        const string fightName = "Винищувач";
        const string bombName = "Бомбардувальник";
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Вітаємо в програмі розрахунку вартості " +
                                                             "літаків!");
            TypeInput();
        }
        static void ResultOutput(IParent parent, string planeType)
        {
            string result = parent.output;
            Console.WriteLine($"{planeType} {result}");
        }
        static void TypeInput()
        {
            string planeType;
            while (true)
            {
                try
                {

                    planeType = Console.ReadLine();
                    if (planeType == jetName ||
                        planeType == fightName ||
                        planeType == bombName)
                    {
                        break;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Введено порожній рядок. " +
                                      "Повторіть спробу.");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Введене значення типу літака " +
                                      "не підтримується. " +
                                      "Повторіть спробу.");
                }
            }
        }
        static void GeneralInput(string planeType)
        {
            int planeSpeed;
            int planeFlightHeight;
            while (true)
            {
                try
                {

                    planeSpeed = Int32.Parse(Console.ReadLine());
                    if (planeSpeed > 0) { break; }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Повторіть спробу.");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Повторіть спробу.");
                }
            }
            while (true)
            {
                try
                {

                    planeFlightHeight = Int32.Parse(Console.ReadLine());
                    if (planeFlightHeight > 0) { break; }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Повторіть спробу.");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Повторіть спробу.");
                }
            }
            switch (planeType)
            {
                case jetName:
                    EvalSwitch(planeType, planeSpeed, planeFlightHeight, 0);
                    break;
                case fightName:
                    EvalSwitch(planeType, planeSpeed, planeFlightHeight, 0);
                    break;
                case bombName:
                    BombInput(planeType, planeSpeed, planeFlightHeight);
                    break;
                default:
                    Console.WriteLine("Щось пішло не так. Повторіть спробу.");
                    break;
            }
        }
        static void BombInput(string type,
                              int speed,
                              int altitude)
        {

            int bombCount;
            while (true)
            {
                try
                {
                    bombCount = Int32.Parse(Console.ReadLine());
                    if (bombCount >= 0) { break; }
                    else
                    {
                            throw new ArgumentException();
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Повторіть спробу.");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Повторіть спробу.");
                }
            }
            EvalSwitch(type, speed, altitude, bombCount);
        }
        static void EvalSwitch (string type,
                                int speed,
                                int altitude,
                                int bombs)
        {
            switch (type)
            {
                case jetName:
                    JetLiner jet = new(speed, altitude);
                    ResultOutput(jet, type);
                    break;
                case fightName:
                    Fighter fighter = new(speed, altitude);
                    ResultOutput(fighter, type);
                    break;
                case bombName:
                    Bomber bomber = new(speed,
                                        altitude,
                                        bombs);
                    ResultOutput(bomber, type);
                    break;
                default:
                    Console.WriteLine("Щось пішло не так. Повторіть спробу.");
                    break;
            }
        }
    }
}
