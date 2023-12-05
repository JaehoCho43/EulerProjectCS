using System.Numerics;

namespace ProjectEuler
{
	public abstract class Problem
	{
		public abstract long Solve();

	}

	public class Problem1 : Problem
	{
		//Find the sum of all the multiples of 3 or 5 below 1000.";

		override public long Solve()
		{
			return Enumerable.Range(1, 999).Where(i => (i % 3 == 0) || (i % 5 == 0)).Sum();
		}
	}

	public class Problem2 : Problem
	{
		// By considering the terms in the Fibonacci sequence whose values do not exceed four million,
		// find the sum of the even-valued terms.
		override public long Solve()
		{
			int ans = 2;
			int prev = 1;
			int current = 2;
			while (current <= 4000000)
			{
				current += prev;
				prev = current - prev;
				if (current % 2 == 0)
				{
					ans += current;
				}
			}
			return ans;
		}
	}

	public class Problem3 : Problem
	{
		// What is the largest prime factor of the number 600851475143?
		override public long Solve()
		{
			var N = 600851475143;

			return Helper.getPrimeFactorization(N).Keys.Max();
		}
	}

	public class Problem4 : Problem
	{
		//Find the largest palindrome made from the product of two 3-digit numbers.
		public override long Solve()
		{
			var ans = 0;

			for (int p = 999; p >= 100; p--)
			{
				for (int q = p; q >= 100; q--)
				{
					if (Helper.IsPalindrome(p * q)) ans = Math.Max(ans, p * q);
				}
			}

			return ans;
		}
	}
	public class Problem5 : Problem
	{
		// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20
		public override long Solve() => Enumerable.Range(1, 20).Select(x => (long)x).Aggregate((long)1, (x, y) => Helper.LCM(x, y));

	}

	public class Problem6 : Problem
	{
		// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
		public override long Solve()
		{
			var ans = 0;
			for (int i = 0; i <= 100; i++)
			{
				for (int j = 0; j <= 100 && j != i; j++)
				{
					ans += 2 * i * j;
				}
			}
			return ans;
		}
	}

	public class Problem7 : Problem
	{
		//What is the 10001st prime number?
		public override long Solve() => Helper.NthPrime(10001);
	}

	public class Problem8 : Problem
	{
		// Find the thirteen adjacent digits in the 1000-digit number that have the greatest product.
		// What is the value of this product?
		public override long Solve()
		{
			string numbers = "73167176531330624919225119674426574742355349194934\r\n96983520312774506326239578318016984801869478851843\r\n85861560789112949495459501737958331952853208805511\r\n12540698747158523863050715693290963295227443043557\r\n66896648950445244523161731856403098711121722383113\r\n62229893423380308135336276614282806444486645238749\r\n30358907296290491560440772390713810515859307960866\r\n70172427121883998797908792274921901699720888093776\r\n65727333001053367881220235421809751254540594752243\r\n52584907711670556013604839586446706324415722155397\r\n53697817977846174064955149290862569321978468622482\r\n83972241375657056057490261407972968652414535100474\r\n82166370484403199890008895243450658541227588666881\r\n16427171479924442928230863465674813919123162824586\r\n17866458359124566529476545682848912883142607690042\r\n24219022671055626321111109370544217506941658960408\r\n07198403850962455444362981230987879927244284909188\r\n84580156166097919133875499200524063689912560717606\r\n05886116467109405077541002256983155200055935729725\r\n71636269561882670428252483600823257530420752963450".Replace("\r", "").Replace("\n", "");
			int length = 1000;
			var prod = numbers.Substring(0, 13).Aggregate((long)1, (x, y) => x * (y - '0'));
			var ans = prod;

			for (int i = 1; i < length - 12; i++)
			{
				var toDivide = numbers[i - 1] - '0';
				var toMultiply = numbers[i + 12] - '0';
				prod = (toDivide == 0) ? numbers.Substring(i, 13).Aggregate((long)1, (x, y) => x * (y - '0')) : (prod / toDivide * toMultiply);
				ans = Math.Max(ans, prod);
			}
			return ans;

		}
	}
	public class Problem9 : Problem
	{
		// There exists exactly one Pythagorean triplet for which a + b + c = 1000
		// Find the product abc
		public override long Solve()
		{
			// c = 1000 - a - b
			// a^2 + b^2 = c^2 = a^2 + b^2 + 2ab - 2000a - 2000b + 1000000
			// ab - 1000a - 1000b + 500000 = 0
			// (a-1000)(b-1000) = 500000

			for (int a = 1; a < 1000; a++)
			{
				for (int b = a + 1; b < 1000 - a; b++)
				{
					if ((a - 1000) * (b - 1000) == 500000)
					{
						var c = 1000 - a - b;
						return a * b * c;
					}
				}
			}
			return 0;
		}
	}

	public class Problem10 : Problem
	{
		// Find the sum of all the primes below two million.
		public override long Solve()
		{
			long ans = 0;
			for (long i = 1; i < 2000000; i++)
			{
				if (Helper.IsPrime(i)) ans += i;
			}
			return ans;
		}
	}

	public class Problem11 : Problem
	{
		// Find the sum of all the primes below two million.
		public override long Solve()
		{
			string givenStr = "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08\r\n49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00\r\n81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65\r\n52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91\r\n22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80\r\n24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50\r\n32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70\r\n67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21\r\n24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72\r\n21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95\r\n78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92\r\n16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57\r\n86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58\r\n19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40\r\n04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66\r\n88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69\r\n04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36\r\n20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16\r\n20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54\r\n01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";
			var givenTable = givenStr.Split("\r\n").Select(strs => strs.Split(" ").Select(intStr => Int32.Parse(intStr)).ToList()).ToList();
			long ans = 0;
			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < 20; j++)
				{
					List<long> candidates = [ans];

					if (i - 3 >= 0) candidates.Add(givenTable[i][j] * givenTable[i - 1][j] * givenTable[i - 2][j] * givenTable[i - 3][j]);
					if (i + 3 < 20) candidates.Add(givenTable[i][j] * givenTable[i + 1][j] * givenTable[i + 2][j] * givenTable[i + 3][j]);
					if (j - 3 >= 0) candidates.Add(givenTable[i][j] * givenTable[i][j - 1] * givenTable[i][j - 2] * givenTable[i][j - 3]);
					if (j + 3 < 20) candidates.Add(givenTable[i][j] * givenTable[i][j + 1] * givenTable[i][j + 2] * givenTable[i][j + 3]);
					if ((i - 3 >= 0) && (j - 3 >= 0)) candidates.Add(givenTable[i][j] * givenTable[i - 1][j - 1] * givenTable[i - 2][j - 2] * givenTable[i - 3][j - 3]);
					if ((i + 3 < 20) && (j + 3 < 20)) candidates.Add(givenTable[i][j] * givenTable[i + 1][j + 1] * givenTable[i + 2][j + 2] * givenTable[i + 3][j + 3]);
					if ((i - 3 >= 0) && (j + 3 < 20)) candidates.Add(givenTable[i][j] * givenTable[i - 1][j + 1] * givenTable[i - 2][j + 2] * givenTable[i - 3][j + 3]);
					if ((i + 3 < 20) && (j - 3 >= 0)) candidates.Add(givenTable[i][j] * givenTable[i + 1][j - 1] * givenTable[i + 2][j - 2] * givenTable[i + 3][j - 3]);

					ans = candidates.Max();
				}
			}
			return ans;
		}
	}
	public class Problem12 : Problem
	{
		public override long Solve()
		{
			long n = 1;
			while (true)
			{
				var triangleNumber = n * (n + 1) / 2;
				if (Helper.getPrimeFactorization(triangleNumber)
					.Values
					.Aggregate(1, (prev, m) => prev * ((int)m + 1)) > 500
					) return triangleNumber;

				n++;
			}

		}
	}
	public class Problem13 : Problem
	{
		public override long Solve()
		{
			//Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
			string givenStr = "37107287533902102798797998220837590246510135740250\r\n46376937677490009712648124896970078050417018260538\r\n74324986199524741059474233309513058123726617309629\r\n91942213363574161572522430563301811072406154908250\r\n23067588207539346171171980310421047513778063246676\r\n89261670696623633820136378418383684178734361726757\r\n28112879812849979408065481931592621691275889832738\r\n44274228917432520321923589422876796487670272189318\r\n47451445736001306439091167216856844588711603153276\r\n70386486105843025439939619828917593665686757934951\r\n62176457141856560629502157223196586755079324193331\r\n64906352462741904929101432445813822663347944758178\r\n92575867718337217661963751590579239728245598838407\r\n58203565325359399008402633568948830189458628227828\r\n80181199384826282014278194139940567587151170094390\r\n35398664372827112653829987240784473053190104293586\r\n86515506006295864861532075273371959191420517255829\r\n71693888707715466499115593487603532921714970056938\r\n54370070576826684624621495650076471787294438377604\r\n53282654108756828443191190634694037855217779295145\r\n36123272525000296071075082563815656710885258350721\r\n45876576172410976447339110607218265236877223636045\r\n17423706905851860660448207621209813287860733969412\r\n81142660418086830619328460811191061556940512689692\r\n51934325451728388641918047049293215058642563049483\r\n62467221648435076201727918039944693004732956340691\r\n15732444386908125794514089057706229429197107928209\r\n55037687525678773091862540744969844508330393682126\r\n18336384825330154686196124348767681297534375946515\r\n80386287592878490201521685554828717201219257766954\r\n78182833757993103614740356856449095527097864797581\r\n16726320100436897842553539920931837441497806860984\r\n48403098129077791799088218795327364475675590848030\r\n87086987551392711854517078544161852424320693150332\r\n59959406895756536782107074926966537676326235447210\r\n69793950679652694742597709739166693763042633987085\r\n41052684708299085211399427365734116182760315001271\r\n65378607361501080857009149939512557028198746004375\r\n35829035317434717326932123578154982629742552737307\r\n94953759765105305946966067683156574377167401875275\r\n88902802571733229619176668713819931811048770190271\r\n25267680276078003013678680992525463401061632866526\r\n36270218540497705585629946580636237993140746255962\r\n24074486908231174977792365466257246923322810917141\r\n91430288197103288597806669760892938638285025333403\r\n34413065578016127815921815005561868836468420090470\r\n23053081172816430487623791969842487255036638784583\r\n11487696932154902810424020138335124462181441773470\r\n63783299490636259666498587618221225225512486764533\r\n67720186971698544312419572409913959008952310058822\r\n95548255300263520781532296796249481641953868218774\r\n76085327132285723110424803456124867697064507995236\r\n37774242535411291684276865538926205024910326572967\r\n23701913275725675285653248258265463092207058596522\r\n29798860272258331913126375147341994889534765745501\r\n18495701454879288984856827726077713721403798879715\r\n38298203783031473527721580348144513491373226651381\r\n34829543829199918180278916522431027392251122869539\r\n40957953066405232632538044100059654939159879593635\r\n29746152185502371307642255121183693803580388584903\r\n41698116222072977186158236678424689157993532961922\r\n62467957194401269043877107275048102390895523597457\r\n23189706772547915061505504953922979530901129967519\r\n86188088225875314529584099251203829009407770775672\r\n11306739708304724483816533873502340845647058077308\r\n82959174767140363198008187129011875491310547126581\r\n97623331044818386269515456334926366572897563400500\r\n42846280183517070527831839425882145521227251250327\r\n55121603546981200581762165212827652751691296897789\r\n32238195734329339946437501907836945765883352399886\r\n75506164965184775180738168837861091527357929701337\r\n62177842752192623401942399639168044983993173312731\r\n32924185707147349566916674687634660915035914677504\r\n99518671430235219628894890102423325116913619626622\r\n73267460800591547471830798392868535206946944540724\r\n76841822524674417161514036427982273348055556214818\r\n97142617910342598647204516893989422179826088076852\r\n87783646182799346313767754307809363333018982642090\r\n10848802521674670883215120185883543223812876952786\r\n71329612474782464538636993009049310363619763878039\r\n62184073572399794223406235393808339651327408011116\r\n66627891981488087797941876876144230030984490851411\r\n60661826293682836764744779239180335110989069790714\r\n85786944089552990653640447425576083659976645795096\r\n66024396409905389607120198219976047599490197230297\r\n64913982680032973156037120041377903785566085089252\r\n16730939319872750275468906903707539413042652315011\r\n94809377245048795150954100921645863754710598436791\r\n78639167021187492431995700641917969777599028300699\r\n15368713711936614952811305876380278410754449733078\r\n40789923115535562561142322423255033685442488917353\r\n44889911501440648020369068063960672322193204149535\r\n41503128880339536053299340368006977710650566631954\r\n81234880673210146739058568557934581403627822703280\r\n82616570773948327592232845941706525094512325230608\r\n22918802058777319719839450180888072429661980811197\r\n77158542502016545090413245809786882778948721859617\r\n72107838435069186155435662884062257473692284509516\r\n20849603980134001723930671666823555245252804609722\r\n53503534226472524250874054075591789781264330331690\r\n".Replace("\r\n", "");
			BigInteger sum = 0;
			for (int i = 0; i < 5000; i += 50)
			{
				sum += BigInteger.Parse(givenStr.Substring(i, 50));
			}
			return long.Parse(sum.ToString().Substring(0, 10));
		}
	}

	public class Problem14 : Problem
	{
		//Which starting number, under one million, produces the longest chain of Collatz sequence?
		public override long Solve()
		{
			Dictionary<long, long> CollatzCache = [];
			CollatzCache[1] = 1;

			long CollatzLength(long N)
			{
				var cachedValue = CollatzCache.GetValueOrDefault(N);
				if (cachedValue == 0)
				{
					CollatzCache[N] = 1 + CollatzLength((N % 2 == 0) ? (N / 2) : (3 * N + 1));
				}
				return CollatzCache[N];
			}

			return Enumerable.Range(1, 1000000).Aggregate((long)1, (x, y) => (CollatzLength(x) > CollatzLength(y)) ? x : y);
		}
	}

	public class Problem15 : Problem
	{
		// How many such routes are there through a 20 x 20 grid?
		// 40 choose 20 would be an answer
		public override long Solve() => Enumerable.Range(1, 20).Aggregate((long)1, (prod, i) => prod * (i + 20) / i);
	}

	public class Problem16 : Problem
	{
		// What is the sum of the digits of the number 2^1000?
		public override long Solve() => BigInteger.Pow(2, 1000).ToString().Aggregate((long)0, (sum, nChar) => sum + (nChar - '0'));
	}

	public class Problem18 : Problem
	{
		// Find the maximum total from top to bottom of the triangle below:
		public override long Solve()
		{
			string givenStr = "75\r\n95 64\r\n17 47 82\r\n18 35 87 10\r\n20 04 82 47 65\r\n19 01 23 75 03 34\r\n88 02 77 73 07 63 67\r\n99 65 04 28 06 16 70 92\r\n41 41 26 56 83 40 80 70 33\r\n41 48 72 33 47 32 37 16 94 29\r\n53 71 44 65 25 43 91 52 97 51 14\r\n70 11 33 28 77 73 17 78 39 68 17 57\r\n91 71 52 38 17 14 91 43 58 50 27 29 48\r\n63 66 04 68 89 53 67 30 73 16 69 87 40 31\r\n04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";
			List<List<int>> table = givenStr
				.Split("\r\n")
				.Select(str => str.Split(" ").Select(ch => int.Parse(ch)).ToList()).ToList();

			Dictionary<(int, int), int> dp = [];
			for (int r = 14; r >= 0; r--)
			{
				for (int c = 0; c <= r; c++)
				{
					dp[(r, c)] = table[r][c] + Math.Max(dp.GetValueOrDefault((r + 1, c), 0), dp.GetValueOrDefault((r + 1, c + 1), 0));
				}
			}
			return dp[(0, 0)];
		}
	}

	public class Problem20 : Problem
    {
		// Find the sum of the digits in the number 100!
		public override long Solve() => Enumerable.Range(1, 100).Aggregate((BigInteger)1, (x, y) => x * y).ToString().Aggregate((long)0, (x, y) => x + (y - '0'));
    }

    public class Problem21 : Problem
    {
		// d(n) = sum of proper divisors of n
		// a,b are amicable iff a!=b and d(a) = b and d(b) = a 
		// sum of all amicable numbers under 10000
		public override long Solve()
		{
			Dictionary<int, int> sumOfDivs = [];
			for (int n = 2; n < 10000; n++)
			{
				sumOfDivs[n] = Enumerable.Range(1,n-1).Where(d => n%d == 0).Sum();
            }

			// Enumerable.Range(2,9998).Where(a => (sumOfDivs.GetValueOrDefault(sumOfDivs[a], 0) == a) 

			return Enumerable.Range(2,9998).Where(a => (sumOfDivs.GetValueOrDefault(sumOfDivs[a], 0) == a) && (sumOfDivs[a]!=a)).Sum();
		}
    }
	public class Problem25 : Problem
    {
		// What is the index of the first term in the Fibonacci sequence to contain 100 digits?
		public override long Solve()
		{
			int i = 2;
			BigInteger prev = 1;
			BigInteger current = 1;
			while (true)
			{
				current = prev + current;
				prev = current - prev;
				i++;
				if (current.ToString().Length == 1000) return i;
			}
		}
    }

	public class Problem29 : Problem
    {
		// How many distinct terms are in the sequence generated by a^b for 2<=a<=100 and 2<=b<=100?
		public override long Solve()
		{
			HashSet<BigInteger> set = [];
			for (BigInteger a = 2; a <= 100; a++)
			{
				for (int b = 2; b <= 100; b++)
				{
					set.Add(BigInteger.Pow(a,b));
				}
			}

			return set.Count;
		}
    }
}