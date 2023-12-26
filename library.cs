using System.Numerics;

namespace ProjectEuler
{
    class Helper
    {
        public static Problem GetProblem(int N)
        {
            String className = $"ProjectEuler.Problem{N}";
            Type? type = Type.GetType(className);

            if (type == null)
            {
                throw new ArgumentException($"problem {N} is not solved yet!");
            }


            var res = Activator.CreateInstance(type)!;

            return (Problem)res;
        }
        public static bool IsPrime(long N)
        {
            if (N == 2) return true;
            if (N < 2 || N%2 == 0) return false;
            for (long i = 3; i <= Math.Sqrt(N); i+=2)
            {
                if (N % i == 0) return false;
            }
            return true;
        }

        public static Dictionary<long, long> GetPrimeFactorization(long N)
        {
            Dictionary<long, long> factors = [];

            while (N % 2 == 0)
            {
                factors[2] = factors.GetValueOrDefault(2, 0) + 1;
                N /= 2;
            }

            for (long i = 3; i <= Math.Sqrt(N); i += 2)
            {
                while (N % i == 0)
                {
                    factors[i] = factors.GetValueOrDefault(i, 0) + 1;
                    N /= i;
                }
            }

            if (N > 2)
            {
                factors[N] = 1;
            }

            return factors;
        }

        public static bool IsPalindrome (long N)
        {
            if (N < 0) return false;
            if (N < 10) return true;

            long N_temp = N;
            var queue = new Queue<long>();
            while (N_temp > 0)
            {
                queue.Enqueue(N_temp % 10);
                N_temp /= 10;
            }

            long N_new = 0;

            while (queue.Count() > 0)
            {
                N_new *= 10;
                N_new += queue.Dequeue();
            }

            return N == N_new;
        }

        public static long GCD(long N1, long N2)
        {
            if (N1 == N2) return N1;
            if (N1 < N2) return GCD(N2, N1);
            if (N2 <= 0) return N1;
            return GCD(N2, N1 % N2);
        }

        public static long LCM(long N1, long N2) => N1/ GCD(N1, N2) * N2;

        public static List<int> Primes(int N) 
        {
            if (N < 2) return [];
            if (N == 2) return [2];
            var isPrime = Enumerable.Repeat(true, N + 1).ToList();
            isPrime[0] = false;
            isPrime[1] = false;
            for (int j = 4; j < N + 1; j += 2)
            {
                isPrime[j] = false;
            }

            for (int i = 3; i < Math.Sqrt(N) + 1; i += 2)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j < N + 1; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            return isPrime
                .Select((b, i) => new { b, i })
                .Where(x => x.b)
                .Select(x => x.i)
                .ToList(); 
        }
        public static int NthPrime(int N) => Primes(N*N)[N - 1];

        public static IEnumerable<IEnumerable<T>> Permutation<T>(IEnumerable<T> enumerable, int len)
        {
            if (len == 1) return enumerable.Select(e => new T[] {e});
            return Permutation(enumerable, len - 1).SelectMany(perm => enumerable.Where(e => !perm.Contains(e)), (perm, e) => perm.Concat(new T[] {e}));
        }

        public static BigInteger Choose(int n, int r) => Enumerable.Range(1, r).Aggregate((BigInteger) 1, (prod, i) => prod * (n - r + i) / i);
    }
}
