using System;

namespace DungeonsAndDragonsAPIs.Classes
{
    interface IDice
    {
        int Roll();
    }

    public abstract class DiceBase : IDice
    {
        private string name;
        private int sides;

        public string Name { get => name; }
        public int Sides { get => sides; }

        public DiceBase(int Sides)
        {
            name = "d" + Sides.ToString();
            sides = Sides;
        }

        public int Roll()
        {
            Random randomizer = new Random((int)DateTime.Now.Ticks);
            return randomizer.Next(1, sides + 1);
        }
    }

    public class Dice : DiceBase
    {
        public Dice(int Sides) : base(Sides)
        {
        }
    }

    public class D4 : Dice
    {
        public D4() : base(4)
        {
        }
    }

    public class D6 : Dice
    {
        public D6() : base(6)
        {
        }
    }

    public class D8 : Dice
    {
        public D8() : base(8)
        {
        }
    }

    public class D10 : Dice
    {
        public D10() : base(10)
        {
        }
    }

    public class D12 : Dice
    {
        public D12() : base(12)
        {
        }
    }

    public class D20 : Dice
    {
        public D20() : base(20)
        {
        }
    }

    public class D100 : Dice
    {
        public D100() : base(100)
        {
        }
    }
}
