using System;

namespace After037_NewVirtualOverride
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // A set/hierarchy of classes 
            // Defined below

            var baseClass = new BaseClass();
            var derivedOverride = new DerivedOverride();
            var derivedNew = new DerivedNew();
            var derivedOverWrite = new DerivedOverwrite();

            // Here we call the "Name" method for all of the classes to see if they call 
            // their own implementation or the base class' implementation.
            baseClass.Name();
            derivedOverride.Name();
            derivedNew.Name();
            derivedOverWrite.Name();

            // When they are cast back to the base class, 3 of the 4 calls the impletementation
            // from the base class.
            //All except for teh Overriden name method.
            Console.ReadLine();
            baseClass.Name();
            derivedOverride.Name();
            ((BaseClass) derivedNew).Name();
            ((BaseClass) derivedOverWrite).Name();
            Console.ReadLine();

            var t1 = typeof (BaseClass);
            Console.WriteLine(t1.Name);
            Console.WriteLine(t1.Assembly);
            Console.ReadLine();
        }
    }


    internal class BaseClass
    {
        // The virtual keyword says that this method can be overriden by derived classes.
        // It doesn't have to be but it can be.
        internal virtual void Name()
        {
            Console.WriteLine("BaseClass");
        }
    }

    internal class DerivedOverride : BaseClass
    {
        // The override keyword here replaces the code block in the base class.
        internal override void Name()
        {
            Console.WriteLine("DerivedOverride");
        }
    }

    internal class DerivedNew : BaseClass
    {
        // The "new" keyword tells the compiler that it replaces the implementation of "new".
        internal new void Name()
        {
            Console.WriteLine("New");
        }
    }

    internal class DerivedOverwrite : BaseClass
    {
        // There is no keyword here which hides the base implementation of the Name.
        internal void Name()
        {
            Console.WriteLine("Overwrite");
        }
    }
}