using System;
using System.Numerics;

namespace Coding.Exercise
{
    public interface IDiscriminantStrategy
    {
        double CalculateDiscriminant(double a, double b, double c);
    }

    public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
    {
        // todo
        public double CalculateDiscriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }
    }

    public class RealDiscriminantStrategy : IDiscriminantStrategy
    {
        // todo (return NaN on negative discriminant!)
        public double CalculateDiscriminant(double a, double b, double c)
        {
            var result = b * b - 4 * a * c;
            if (result < 0)
                return double.NaN;
            else
                return result;

        }
    }

    public class QuadraticEquationSolver
    {
        private readonly IDiscriminantStrategy strategy;

        public QuadraticEquationSolver(IDiscriminantStrategy strategy)
        {
            this.strategy = strategy;
        }

        public Tuple<Complex, Complex> Solve(double a, double b, double c)
        {
            var discriminant = new Complex(strategy.CalculateDiscriminant(a, b, c),0);
            var RootOfDisc = Complex.Sqrt(discriminant);

            return Tuple.Create(
                (-b + RootOfDisc) / 2 * a,
                (-b - RootOfDisc) / 2 * a
                );
        }
    }
}