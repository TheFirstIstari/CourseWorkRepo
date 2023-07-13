namespace binary_writer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 25;
            double d = 3.14257;
            bool b = true;
            string s = "I am happy";
            BinaryWriter File = new BinaryWriter(new FileStream("test.txt", FileMode.Create));
            File.Write(i);
            File.Write(d);
            File.Write(b);
            File.Write(s);
            File.Close();
        }
    }
}