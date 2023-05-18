﻿namespace Practics_Work_6_Interfaces
{
    internal class JetLiner : IParent
    {
        protected int speed;
        protected int flightHeight;
        internal int price;
        string IParent.output => Info();
        public JetLiner(int speed, int flightHeight)
        {
            this.speed = speed;
            this.flightHeight = flightHeight;
            price = Price();
        }
        public int Price()
        {
            return 1000 * speed + 100 * flightHeight;
        }
        public string Info()
        {
            return "має такі характеристики:\n" +
                   $"максимальна швидкість - {speed} км/год;\n" +
                   $"максимальна висота польоту - {flightHeight} м;\n" +
                   $"ціна в стандартній комплектації - ${price:0.00}.";
        }
    }
}
