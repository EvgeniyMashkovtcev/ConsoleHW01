using ConsoleApp27;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHW01
{
    enum Gender { Male, Female };
    internal class FamilyMember : IComparable<FamilyMember>
    {
        public FamilyMember Mother { get { return mother; } set { mother = value; } }
        public FamilyMember Father { get { return father; } set { father = value; } }
        public string Name { get { return name; } set { name = value; } }
        public Gender Sex { get { return sex; } set { sex = value; } }
        public ListT<FamilyMember> Children { get; }



        FamilyMember mother;
        FamilyMember father;
        string name;
        Gender sex;
        ListT<FamilyMember> children;

        public void MothersLine()
        {
            if (sex == Gender.Female)
                Console.WriteLine(name);
            MothersLinePrivate();
        }

        private void MothersLinePrivate()
        {
            if (mother != null)
            {
                Console.WriteLine(mother.name);
                mother.MothersLinePrivate();
            }
        }

        public void PrintFamilyTree()
        {
            Console.WriteLine("|- Я: " + this.Name);

            if (mother != null) Console.WriteLine(new string("  " + "\\_|- Мама: " + mother.Name));
            if (father != null) Console.WriteLine(new string("  " + "\\_|- Папа: " + father.Name));

            if (father == null) Console.WriteLine(new string("  " + "\\_|- Архив с именем отца утерян"));
            if (mother == null) Console.WriteLine(new string("  " + "\\_|- Архив с именем матери утерян"));

            if (father != null && mother != null)
            {
                if (father != null)
                {
                    foreach (var child in Father.children)
                        if (child.mother.Equals(this.mother))
                        {
                            if (!this.Equals(child))
                            {
                                if (child.Sex == Gender.Female)
                                    Console.WriteLine(new string("|- Сестра: " + child.Name));
                                else
                                    Console.WriteLine(new string("|- Брат: " + child.Name));
                            }
                        }
                        else
                        {
                            if (child.Sex == Gender.Female)
                                Console.WriteLine("|- Единокровная Сестра: " + child.Name);
                            else
                                Console.WriteLine("|- Единокровный Брат: " + child.Name);
                        }
                }
                else
                {
                    foreach (var child in Mother.Children)
                        if (child.Sex == Gender.Female)
                            Console.WriteLine("|- Сестра: " + child.Name);
                        else
                            Console.WriteLine("|- Брат: " + child.Name);
                }

            }
            if (this.Children != null)
            {
                foreach (var child in this.Children)
                    if (child.Sex == Gender.Female)
                        Console.WriteLine(new string("  " + "-|- Дочь: " + child.Name));
                    else
                        Console.WriteLine(new string("  " + "-|- Сын: " + child.Name));
            }




        }

        public void AddChild(FamilyMember child)
        {
            if (child != null)
                children.Add(child);
        }

        public int CompareTo(FamilyMember? other)
        {
            throw new NotImplementedException();
        }

        public FamilyMember()
        {
            children = new ListT<FamilyMember>();
        }

        public FamilyMember(FamilyMember Mother, FamilyMember Father, string Name, Gender Sex)
        {
            children = new ListT<FamilyMember>();
            this.mother = Mother;
            this.father = Father;
            this.name = Name;
            this.sex = Sex;
        }
    }

}