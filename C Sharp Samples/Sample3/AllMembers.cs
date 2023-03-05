using System;

namespace C_Sharp_Samples.Sample3
{
    public abstract class BaseAllMembers
    {
        protected string firstName;

        public BaseAllMembers(string firstName)
        {
            this.firstName = firstName;
        }

        protected abstract void Test();
    }

    public class AllMembers : BaseAllMembers
    {
        private double[] figures;
        private string lastName;

        public string FirstName {
            get { return firstName; } 
            set { firstName = value; } 
        }
        
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public delegate string DelegateSample(int p1, string p2);
        
        public event DelegateSample ev; // same as delegate but with actions limited to subscribe/unsubscribe

        // indexer
        public double this[int i] => figures[i];

        public AllMembers(string firstName, string lastName) : base(firstName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public void Deconstruct(out string firstName, out string lastName)
        {
            firstName = this.firstName;
            lastName = this.lastName;
        }

        ~AllMembers() // finalizer - called before GC reclaims memory
        {
            Console.WriteLine("Finalizing");
        }

        // note: covariant return type - more derived type e.g House instead of Asset
        public virtual string couldBeOverriden()
        {
            return "";
        }

        // abstract method
        protected override void Test()
        {
            throw new NotImplementedException();
        }

        public static AllMembers operator + (AllMembers am, string str)
        {
            return new AllMembers(am.firstName + str, am.lastName + str);
        }

        // the same could be done for implicit (but types can not dublicate)
        public static explicit operator AllMembers(string s)
        {
            var parts = s.Split(' ');
            return new AllMembers(parts[0], parts[1]);
        }

        public static implicit operator string(AllMembers am)
        {
            return $"{am.firstName} {am.lastName}";
        }
    }
}
