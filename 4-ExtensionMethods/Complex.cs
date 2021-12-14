namespace ExtensionMethods
{
    using System;

    /// <inheritdoc cref="IComplex"/>
    public class Complex : IComplex
    {
        private readonly double re;
        private readonly double im;

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="re">the real part.</param>
        /// <param name="im">the imaginary part.</param>
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        /// <inheritdoc cref="IComplex.Real"/>
        public double Real { get; private set; }

        /// <inheritdoc cref="IComplex.Imaginary"/>
        public double Imaginary { get; private set; }

        /// <inheritdoc cref="IComplex.Modulus"/>
        public double Modulus { get => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2)); }

        /// <inheritdoc cref="IComplex.Phase"/>
        public double Phase { get => Math.Atan2(Imaginary, Real); }

        /// <inheritdoc cref="IComplex.ToString"/>
        public override string ToString()
        {
            string n = "";
            if (Real > 0)
            {
                n = "+" + Real.ToString();
            }
            else if (Real < 0)
            {
                n = Real.ToString();
            }
            else
            {
                //Real=0
            }


            if (Imaginary * Imaginary == 1)
            {
                n = n + (Imaginary == 1 ? "+i" : "-i");
            }
            else if (Imaginary > 0)
            {
                n = n + "+" + Imaginary.ToString();
            }
            else if (Imaginary < 0)
            {
                n = n + Imaginary.ToString();
            }
            else
            {
                //Immaginary=0
            }

            if (Real == 0 && Imaginary == 0) return "0";

            return n;
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(IComplex other)
        {
            return other != null &&
                   Real == other.Real &&
                   Imaginary == other.Imaginary;
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            if (obj is Complex)
            {
                return Equals((Complex)obj);
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
        }
    }
}
