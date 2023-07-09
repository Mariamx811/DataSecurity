using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.ElGamal
{
    public class ElGamal
    {
        /// <summary>
        /// Encryption
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="q"></param>
        /// <param name="y"></param>
        /// <param name="k"></param>
        /// <returns>list[0] = C1, List[1] = C2</returns>
        public List<long> Encrypt(int q, int alpha, int y, int k, int m)
        {
            List<long> result = new List<long>();

            long c1 = power(alpha, k, q);
            long c3 = (power(y, k, q) * m) % q;

            result.Add(c1);
            result.Add(c3);
            return result;

        }
        public int Decrypt(int c1, int c2, int x, int q)
        {
            return (int)(c2 * power(c1, q - 1 - x, q)) % q;
        }
        public static long power(long B, long P, long M)
        {
            //REMOVE THIS LINE BEFORE START CODING
            // throw new NotImplementedException();
            if (P == 0) return 1;
            long res = power(B, P / 2, M);
            res = (res * res) % M;
            if (P % 2 == 1) res = (res * (B % M)) % M;
            return res;
        }
    }
}
