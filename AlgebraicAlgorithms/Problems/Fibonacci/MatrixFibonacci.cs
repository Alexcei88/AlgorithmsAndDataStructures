using System;
using System.Numerics;

namespace ConsoleTester.Problems.Fibonacci
{
    public class MatrixFibonacci
        : IProblem
    {
        public class Matrix2D
        {
            private readonly BigInteger[,] _value;

            public BigInteger this[int x, int y] => _value[x, y];

            private Matrix2D(BigInteger[,] value) => _value = value;

            public static Matrix2D BASE = new(new BigInteger[,]
            {
                {1, 1},
                {1, 0}
            });
            
            public static Matrix2D IDENTITY = new(new BigInteger[,]
            {
                {1, 0},
                {0, 1}
            });

            public static Matrix2D operator *(Matrix2D m1, Matrix2D m2)
            {
                return new(new[,]
                {
                    { m1[0,0] * m2[0,0] + m1[0,1] * m2[1,0], m1[0,0] * m2[0,1] + m1[0,1] * m2[1,1] },
                    { m1[1,0] * m2[0,0] + m1[1,1] * m2[1,0], m1[1,0] * m2[0,1] + m1[1,1] * m2[1,1] }
                });
            }
        }
        
        public string Solve(string[] input)
        {
            long N = long.Parse(input[0]);
            if (N < 2)
                return N.ToString();
            
            Matrix2D p = Matrix2D.IDENTITY;
            Matrix2D powP = Matrix2D.BASE;
            long maxPower = N - 1;
            while (maxPower > 0)
            {
                long bit = maxPower & 1;
                if (bit == 1)
                {
                    p *= powP;
                }
                powP *= powP;
                maxPower = maxPower >> 1;
            }
            
            return p[0,0].ToString();
        }
    }
}