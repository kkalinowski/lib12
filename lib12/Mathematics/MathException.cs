using lib12.Exceptions;

namespace lib12.Mathematics
{
    public class MathException : lib12Exception
    {
        public MathException(string message)
            : base(message)
        {

        }
    }
}