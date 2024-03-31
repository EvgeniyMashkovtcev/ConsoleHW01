using System.Reflection;

namespace ConsoleHW01
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
