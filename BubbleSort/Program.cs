namespace FebTest

{

    internal class Program

    {

        static void Main(string[] args)

        {

            Console.WriteLine("enter n:  ");

            int number = int.Parse(Console.ReadLine());

            bool found = false;
            int countofharshadnumbers = 0;
            int count = 1;
            while (found == false)
            {
               int Sumofdigits = 0;
                
                foreach(char num in Convert.ToString(count))
                {
                    Sumofdigits = Sumofdigits + num - 48;

                }
                if (count % Sumofdigits == 0)
                    countofharshadnumbers++;
                if(countofharshadnumbers == Convert.ToInt32(number))
                {
                    Console.WriteLine(count);
                    found = true;
                }
                count++;
            }

        }



        







        


    }

}