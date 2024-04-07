using System.Reflection;

namespace ConsoleHW01
{
    internal class Program
    {

        static void Main(string[] args)
        {
            /*
            Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу. 
            Подсказка: если взять первое число в массиве, 
            можно ли найти в оставшейся его части два числа равных по сумме первому.
            */

            int[] array = { 1, 2, 4, 8, 3, 4, 5, 6, 9, 11, 14, 10, 0, 12, 8 };
            // int[] array1 = { 22, 7, 7, 3, 1, 8, 6, 9, 11, 14, 0, 0 };
            // int[] array2 = { 22, 7, 15, 3, 5, 1, 6, 0, 0 };
            // int[] array3 = { 0, 40, 45, 6, 100, 8 };
            // int[] array4 = { 1, 5, 44, 7, 11, 9, 3, 15, 17 };

            int reqSum = 8;

            FindTriplets(array, reqSum);
            // FindTriplets(array1, reqSum);
            // FindTriplets(array2, reqSum);
            // FindTriplets(array3, reqSum);
            // FindTriplets(array4, reqSum);



        }

        static void FindTriplets(int[] array, int reqSum)
        {
            Array.Sort(array);


            for (int i = 0; i < array.Length - 2; i++)
            {
                int left = i + 1;
                int right = array.Length - 1;
                int currentSum = reqSum - array[i];

                while (left < right)
                {
                    if (array[left] + array[right] == currentSum)
                    {
                        Console.WriteLine($"Три числа: {array[i]}, {array[left]}, {array[right]}");
                        return;
                    }
                    else if (array[left] + array[right] < currentSum)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            Console.WriteLine("Подходящих трех чисел нет");
        }





        /*
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


            Console.WriteLine("Количество выходов в первом лабиринте: " + HasExit(1, 3, labirynth));
                // Print(labirynth);

                Console.WriteLine();

                Console.WriteLine("Количество выходов во втором лабиринте : " + HasExitRecursive(1, 3, labirynth2));
                // Print(labirynth2);
            */

        /*
        static int HasExit(int i, int j, int[,] lab)
        {
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();

            if (lab[i, j] == 0)
                stack.Push(new(i, j));

            int count = 0;

            while (stack.Count > 0)
            {
                Tuple<int, int> current = stack.Pop();
                if (current.Item1 < 0 || current.Item2 == lab.GetLength(0))
                    continue;
                if (current.Item2 < 0 || current.Item2 == lab.GetLength(1))
                    continue;
                if (lab[current.Item1, current.Item2] == 1 || lab[current.Item1, current.Item2] == 2)
                    continue;
                lab[current.Item1, current.Item2] = 2;
                if (lab.GetLength(0) - 1 == current.Item1 || lab.GetLength(1) - 1 == current.Item2 || current.Item1 == 0 || current.Item2 == 0)
                {
                    count++;
                    continue;
                }


                stack.Push(new(current.Item1 + 1, current.Item2));
                stack.Push(new(current.Item1 - 1, current.Item2));
                stack.Push(new(current.Item1, current.Item2 + 1));
                stack.Push(new(current.Item1, current.Item2 - 1));
            }
            return count;
        }


        static int HasExitRecursive(int i, int j, int[,] lab)
        {
            if (lab[i, j] != 0)
                return 0;
            return HasExitRec(i, j, lab);
        }

        static int HasExitRec(int i, int j, int[,] lab)
        {
            lab[i, j] = 2;
            int count = 0;

            if (i + 1 < lab.GetLength(0) && lab[i + 1, j] == 0)
                count += HasExitRec(i + 1, j, lab);
            if (i - 1 >= 0 && lab[i - 1, j] == 0)
                count += HasExitRec(i - 1, j, lab);
            if (j + 1 < lab.GetLength(1) && lab[i, j + 1] == 0)
                count += HasExitRec(i, j + 1, lab);
            if (j - 1 >= 0 && lab[i, j - 1] == 0)
                count += HasExitRec(i, j - 1, lab);

            if (lab.GetLength(0) - 1 == i || lab.GetLength(1) - 1 == j || i == 0 || j == 0)
                return count + 1;

            return count;
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
        */

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
