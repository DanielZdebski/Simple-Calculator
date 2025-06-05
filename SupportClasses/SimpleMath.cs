namespace SupportClasses
{
    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        { 
            return n1 + n2; 
        }

        public static double Subtract(double n1, double n2) 
        { 
            return n1 - n2; 
        }

        public static double Multiply(double n1, double n2) 
        { 
            return (n1 * n2); 
        }

        public static int Divide(double n1, double n2, out double result)
        {
            if (n2 == 0) 
            {
                result = 0;
                return 999;
            }
            else
                result = (n1 / n2);

            return 0;
        }
    }
}
