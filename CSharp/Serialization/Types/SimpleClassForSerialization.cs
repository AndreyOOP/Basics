namespace CSharp.Serialization
{
    public class SimpleClassForSerialization
    {
        public int a;
        private decimal b;
        public string c { get; set; }

        public SimpleClassForSerialization()
        {
            a = 101;
            b = decimal.Parse("10,43");
            c = "some text";
        }
    }
}
