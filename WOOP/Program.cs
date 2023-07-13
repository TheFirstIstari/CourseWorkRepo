namespace WOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(9, 5);
            Rectangle rectangle = new Rectangle(9, 5);
            
            Console.WriteLine(triangle.TrangleArea());
            Console.WriteLine(rectangle.RecangleArea());
        }
        
    }
    public abstract class Shape
    {
        protected  decimal height;
        protected decimal width;

        public decimal Width { get => width; set => width = value; }
        public decimal Height { get => height; set => height = value; }
        public Shape(decimal height, decimal width)
        {
            this.height = height;
            this.width = width; 
        }

    }
    class Triangle : Shape
    {
        public Triangle(decimal height, decimal width) : base(height, width)
        {
            
        }

        public decimal TrangleArea() {
            return 0.5M*Width*Height;
        }

    }
    class Rectangle : Shape
    {
        public Rectangle(decimal height, decimal width) : base(height, width)
        {
            
        }
        public decimal RecangleArea()
        {
            return Width * Height;
        }
    }
}