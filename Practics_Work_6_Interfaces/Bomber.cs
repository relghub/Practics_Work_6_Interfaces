using System;
namespace Practics_Work_6_Interfaces
{
    internal class Bomber : IParent
    {
        protected int speed;
        protected int flightHeight;
        protected int bombCount;
        public int price;
        string IParent.output => Info();
        public Bomber(int speed, int flightHeight, int bombCount)
        {
            this.speed = speed;
            this.flightHeight = flightHeight;
            this.bombCount = bombCount;
            price = Price();
        }
        public int Price()
        {
            return 1500 * speed + 150 * flightHeight + 50 * bombCount;
        }
        public string Info()
        {
            return "має такі характеристики:\n" +
                   $"максимальна швидкість - {speed} км/год;\n" +
                   $"максимальна висота польоту - {flightHeight} м;\n" +
                   "максимальна кількість бомб, " +
                   $"яку літак може переносити - {bombCount};\n" +
                   $"ціна в стандартній комплектації - ${price:0.00}.";
        }
    }
}
