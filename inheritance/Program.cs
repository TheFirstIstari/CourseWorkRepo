namespace inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<Animal> animalList = new List<Animal>();
            Dog MyDog = new Dog("billy", 15, "Chi-hua-hua");
            animalList.Add(MyDog);
            Dog YourDog = new Dog("belly", 50, "Border Collie");
            animalList.Add(YourDog);
            Dog OurDog = new Dog("bally", 100, "Alaskan Malamute");
            animalList.Add(OurDog);
            Capybara supreme = new Capybara("supreme", 300);
            animalList.Add(supreme);
            foreach (Animal animal in animalList)
            {
                animal.MakeNoise(1);
                animal.Play(1);
            }



        }
    }
    class Animal
    {
        protected string name;
        protected int size;
        private string breed;
        public string Name { get => name; set => name = value; }
        public int Size { get => size; set => size = value; }
        protected string Breed { get => breed; set => breed = value; }

        public virtual void Play(int times)
        {
            Console.WriteLine(name + " the " + breed + " is playing");
        }
        public virtual void MakeNoise(int nooftimes)
        {
            Console.WriteLine(name + " is making noise");
        }
        public Animal(string name, int size, string breed, )
        {
            Name = name;
            Size = size;
            Breed = breed;

        }
    }
    class Dog : Animal
    {
        public Dog(string name, int size, string breed) :
        {
            this.name = name;
            this.size = size;
            this.Breed = breed;
            Console.WriteLine("constructor called for " + this.name);


        }

        public override void MakeNoise(int NoOfBArks)
        {
            this.Size = size;
            this.Name = name;
            for (int i = 0; i < NoOfBArks; i++)
            {
                if (size < 20)
                {
                    Console.WriteLine(name + " is yapping");
                }
                else if (size < 70)
                {
                    Console.WriteLine(name + " is barking");
                }
                else
                {
                    Console.WriteLine(name + " is woofing");
                }
            }

        }
    }
    class Capybara : Animal
    {
        public Capybara(string name, int size)
        {
            this.name = name;
            this.size = size;
        }
        public override void MakeNoise(int nooftimes)
        {
            Console.WriteLine("[Verse 1: Miguel]");
            Console.WriteLine("What color is the sky? Ay, mi amor, ay, mi amor");
            Console.WriteLine("You tell me that it's red, ay, mi amor, ay, mi amor");
            Console.WriteLine("Where should I put my shoes? Ay, mi amor, ay, mi amor");
            Console.WriteLine("You say, 'Put them on your head!', ay, mi amor, ay, mi amor");
            Console.WriteLine("You make me un poco loco, un poquititito loco");
            Console.WriteLine("The way you keep me guessing, I'm nodding and I'm yes-ing");
            Console.WriteLine("I'll count it as a blessing that I'm only un poco loco");

            Console.WriteLine("[Verse 2: Hector, Miguel, Both]");
            Console.WriteLine("The loco that you make me, it is just un poco crazy");
            Console.WriteLine("The sense that you're not making");
            Console.WriteLine("The liberties you're taking");
            Console.WriteLine("Leaves my cabeza shaking");
            Console.WriteLine("You're just un poco loco");
            Console.WriteLine("[Bridge: Ensemble]");
            Console.WriteLine("He 's just un poco crazy, leaves my cabeza shaking");
            Console.WriteLine("He 's just un poco crazy, leaves my cabeza shaking");
            Console.WriteLine("He 's just un poco crazy, leaves my cabeza shaking");
            Console.WriteLine("He 's just un poco crazy, leaves my cabeza shaking");

            Console.WriteLine("[Outro: Miguel & Hector]");
            Console.WriteLine("Un poquititititititititi-titititito loco!");
        }
    }
}
