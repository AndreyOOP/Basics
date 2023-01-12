using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Samples.Sample3
{
    // implicit, explicit, opertor overload
    public class AllMembers
    {
        private string firstName;
        private string lastName;

        public delegate string DelegateSample(int p1, string p2);
        public event DelegateSample ev; // same as delegate but with actions limited to subscribe/unsubscribe

        public AllMembers(string firstName, string lastName) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public void Deconstruct(out string firstName, out string lastName)
        {
            firstName = this.firstName;
            lastName = this.lastName;
        }

        ~AllMembers() // finalizer - called before GC recalims memory
        {
            Console.WriteLine("Finalizing");
        }

        // note: covariant return type - more derived type e.g House instead of Asset
        public virtual string couldBeOverriden()
        {
            return "";
        }

        public static AllMembers operator + (AllMembers am, string str)
        {
            return new AllMembers(am.firstName + str, am.lastName + str);
        }
    }
}
