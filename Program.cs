using System.Reflection;

namespace ConsoleHW01
{
    internal class Program
    {
        class Bits
        {
            public Bits(byte b)
            {
                this.Value = b;
            }
            public byte Value { get; private set; } = 0;
            public bool this[int index]
            {
                get
                {
                    if (index > 7 || index < 0)
                        return false;
                    return ((Value >> index) & 1) == 1;
                }
                set
                {
                    if (index > 7 || index < 0) return;
                    if (value == true)
                        Value = (byte)(Value | (1 << index));
                    else
                    {
                        var mask = (byte)(1 << index);
                        mask = (byte)(0xff ^ mask);
                        Value &= (byte)(Value & mask);
                    }
                }

            }

            public static implicit operator byte(Bits b) => b.Value;


            // Домашняя работа:
            public static implicit operator Bits(long value) => new Bits((byte)value);

            public static implicit operator Bits(int value) => new Bits((byte)value);

            public static implicit operator Bits(byte value) => new Bits(value);
        }

        static void Main(string[] args)
        {
            Bits bitsFromLong = 12345L;
            Bits bitsFromInt = 205;
            Bits bitsFromByte = (byte)20;

            Console.WriteLine("Bits from long: " + Convert.ToString(bitsFromLong.Value, 2));
            Console.WriteLine("Bits from int: " + Convert.ToString(bitsFromInt.Value, 2));
            Console.WriteLine("Bits from byte: " + Convert.ToString(bitsFromByte.Value, 2));
















            /*
            var grandMother = new FamilyMember() { Mother = null, Father = null, Name = "Вика", Sex = Gender.Female };
            var grandFather = new FamilyMember() { Mother = null, Father = null, Name = "Виктор", Sex = Gender.Male };
            var father = new FamilyMember() { Mother = null, Father = null, Name = "Илья", Sex = Gender.Male };
            var mother = new FamilyMember() { Mother = grandMother, Father = grandFather, Name = "Маша", Sex = Gender.Female };
            grandMother.AddChild(mother);
            grandFather.AddChild(mother);
            var son = new FamilyMember() { Mother = mother, Father = father, Name = "Коля", Sex = Gender.Male };
            var daughter = new FamilyMember() { Mother = mother, Father = father, Name = "Даша", Sex = Gender.Female };
            mother.AddChild(son);
            father.AddChild(son);
            father.AddChild(daughter);
            mother.AddChild(daughter);
            */

            // father.PrintFamilyTree();
            // mother.PrintFamilyTree();
            // son.PrintFamilyTree();
            // daughter.PrintFamilyTree();
        }
    }
}
