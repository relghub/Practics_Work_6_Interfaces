namespace Practics_Work_6_Interfaces
{
    class Program
    {
        const string jetName = "Пасажирський літак";
        const string fightName = "Винищувач";
        const string bombName = "Бомбардувальник";
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Вітаємо в програмі розрахунку вартості " +
                                                             "літаків!");
            for (int i = 0; i < 5; i++) { TypeInput(); }
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
                    Console.Write("Введіть тип літака: ");
                    planeType = Console.ReadLine();
                    if (planeType == jetName ||
                        planeType == fightName ||
                        planeType == bombName)
                    {
                        break;
                    }
                    else if (planeType == "")
                    {
                        throw new ArgumentNullException();
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
            GeneralInput(planeType);
        }
        static void GeneralInput(string planeType)
        {
            int planeSpeed;
            int planeFlightHeight;
            while (true)
            {
                try
                {
                    Console.Write("Введіть максимальну швидкість літака: ");
                    planeSpeed = Int32.Parse(Console.ReadLine());
                    if (planeSpeed > 0) { break; }
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
                    Console.WriteLine("Введене значення максимальної " +
                                      "швидкості не підтримується. " +
                                      "Повторіть спробу.");
                }
            }
            while (true)
            {
                try
                {
                    Console.Write("Введіть максимальну висоту польоту " +
                                                             "літака: ");
                    planeFlightHeight = Int32.Parse(Console.ReadLine());
                    if (planeFlightHeight > 0) { break; }
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
                    Console.WriteLine("Введене значення максимальної висоти " +
                                      "не підтримується. " +
                                      "Повторіть спробу.");
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
                    Console.Write("Введіть максимальну кількість бомб," +
                                          " яку може перевезти літак: ");
                    bombCount = Int32.Parse(Console.ReadLine());
                    if (bombCount >= 0) { break; }
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
                    Console.WriteLine("Введене значення кількості бомб " +
                                      "не підтримується. " +
                                      "Повторіть спробу.");
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
