using System.Reflection;

namespace ConsoleHW01
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int[,] labirynth = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1 },
                {1, 0, 0, 0, 0, 0, 1 },
                {1, 0, 1, 1, 1, 0, 1 },
                {0, 0, 0, 0, 1, 0, 1 },
                {1, 1, 0, 0, 0, 0, 1 },
                {1, 1, 1, 0, 1, 0, 1 },
                {1, 1, 1, 0, 1, 1, 1 }
            };

            int[,] labirynth2 = new int[,]
            {
                {1, 1, 1, 1, 0, 1, 1 },
                {1, 0, 0, 0, 0, 0, 1 },
                {1, 0, 1, 1, 1, 0, 1 },
                {0, 0, 0, 0, 1, 0, 0 },
                {1, 1, 0, 0, 0, 0, 1 },
                {1, 1, 1, 0, 1, 0, 1 },
                {1, 1, 1, 0, 1, 1, 1 }
            };


            Console.WriteLine("Наличие выхода в первом лабиринте: " + HasExit(1, 3, labirynth));
            Console.WriteLine("Количество выходов в первом лабиринте: " + CountExits(labirynth));

            Console.WriteLine();

            Console.WriteLine("Наличие выхода во втором лабиринте : " + HasExitRecursive(1, 3, labirynth2));
            Console.WriteLine("Количество выходов во втором лабиринте : " + CountExits(labirynth2));

        }

        static int CountExits(int[,] lab)
        {
            int exits = 0;

            for (int i = 0; i < lab.GetLength(0); i++)
            {
                if (lab[i, 0] == 0)
                    exits++;
                if (lab[i, lab.GetLength(1) - 1] == 0)
                    exits++;
            }
            
            for (int j = 0; j < lab.GetLength(1); j++)
            {
                if (lab[0, j] == 0)
                    exits++;
                if (lab[lab.GetLength(0) - 1, j] == 0)
                    exits++;
            }

            return exits;
        }

        static bool HasExit(int i, int j, int[,] lab)
        {
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();

            if (lab[i, j] == 0)
                stack.Push(new(i, j));

            while (stack.Count > 0)
            {
                Tuple<int, int> current = stack.Pop();
                if (current.Item1 < 0 || current.Item2 == lab.GetLength(0))
                    continue;
                if (current.Item2 < 0 || current.Item2 == lab.GetLength(1))
                    continue;
                if (lab[current.Item1, current.Item2] == 1 || lab[current.Item1, current.Item2] == 2)
                    continue;
                if (lab.GetLength(0) - 1 == current.Item1 || lab.GetLength(1) - 1 == current.Item2 || current.Item1 == 0 || current.Item2 == 0)
                    return true;
                lab[current.Item1, current.Item2] = 2;

                stack.Push(new(current.Item1 + 1, current.Item2));
                stack.Push(new(current.Item1 - 1, current.Item2));
                stack.Push(new(current.Item1, current.Item2 + 1));
                stack.Push(new(current.Item1, current.Item2 - 1));
            }
            return false;
        }


        static bool HasExitRecursive(int i, int j, int[,] lab)
        {
            if (lab[i, j] != 0)
                return false;
            
            int[,] originalLab = (int[,])lab.Clone();
            bool hasExit = HasExitRec(i, j, lab);
            
            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    lab[row, col] = originalLab[row, col];
                }
            }
            return hasExit;
        }

        static bool HasExitRec(int i, int j, int[,] lab)
        {
            int originalLab = lab[i, j];
            lab[i, j] = 2;

            if (lab.GetLength(0) - 1 == i || lab.GetLength(1) - 1 == j || i == 0 || j == 0)
                return true;

            bool exit = false;

            if (lab[i + 1, j] == 0)
                if (HasExitRec(i + 1, j, lab))
                    exit = true;
            if (lab[i - 1, j] == 0)
                if (HasExitRec(i - 1, j, lab))
                    exit = true;
            if (lab[i, j + 1] == 0)
                if (HasExitRec(i, j + 1, lab))
                    exit = true;
            if (lab[i, j - 1] == 0)
                if (HasExitRec(i, j - 1, lab))
                    exit = true;

            lab[i, j] = originalLab;

            return exit;
        }

        public static void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }






        /*
        Bits bitsFromLong = 12345L;
        Bits bitsFromInt = 205;
        Bits bitsFromByte = (byte)20;

        Console.WriteLine("Bits from long: " + Convert.ToString(bitsFromLong.Value, 2));
        Console.WriteLine("Bits from int: " + Convert.ToString(bitsFromInt.Value, 2));
        Console.WriteLine("Bits from byte: " + Convert.ToString(bitsFromByte.Value, 2));
        */

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


        father.PrintFamilyTree();
        // mother.PrintFamilyTree();
        // son.PrintFamilyTree();
        // daughter.PrintFamilyTree();
        */

     /*
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
        */   
    }  
}
