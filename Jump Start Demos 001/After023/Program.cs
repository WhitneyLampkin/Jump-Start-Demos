using System;
using System.Diagnostics.Contracts;

namespace After023
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat();
            Animal dog = new Dog();

            if (cat is Dog)
                throw new NotSupportedException("Dogs only!");

            if (cat == dog)
                throw new Exception("Not the same");

            // Checks value?
            if (cat.Equals(dog))
                throw new Exception("Not equal");
        }

        public abstract class Animal
        {
            public string Name { get; protected set; }
            public abstract void SetName(string value);
        }

        public class Cat : Animal
        {
            public override void SetName(string value)
            {
                // non-static 
                // validate empty
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("value");

                // validate conflict
                if (value == this.Name)
                    throw new ArgumentException("value is duplicate");

                // validate size
                if (value.Length > 10)
                    throw new ArgumentException("value is too long");

                // Contract.EndContractBlock(); makes all of the above static contracts

                this.Name = value;
            }   
        }

        public class Dog : Animal
        {
            public string Name { get; protected set; }
            public override void SetName(string value)
            {
                // validate input
                Contract.Requires(!string.IsNullOrWhiteSpace(value), "value is empty");
                Contract.Requires(value == this.Name, "value is duplicate");
                Contract.Requires(value.Length > 10, "value is too long");

                this.Name = value;
            }

            public string GetName()
            {
                // validate output
                // post conditions
                Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));
                return this.Name;
            }
        }

    }
}
