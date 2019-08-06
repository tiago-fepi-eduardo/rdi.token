using System.Linq;
using System.Collections.Generic;
using Token.Domain.Entity;
using Token.Domain.Interfaces;

namespace Token.Domain
{
    public class GenerateToken : IToken
    {
        private const int min = 5;

        /// <summary>
        /// Validate token informed by user with the token saved on the database.
        /// There is no token saved on the data base. Only the data to RE-generate the token.
        /// It's not save let the token information on the databased.
        /// </summary>
        /// <param name="tokenInformed"></param>
        /// <param name="tokenEntity"></param>
        /// <returns></returns>
        public bool Validate(string tokenInformed, TokenEntity tokenEntity)
        {
            string tokenValid = Generate(tokenEntity);

            // Just to make sure they are in the same format
            if (tokenInformed.Trim().ToLower() == tokenValid.Trim().ToLower())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Generate a new token.
        /// </summary>
        /// <param name="tokenEntity"></param>
        /// <returns></returns>
        public string Generate(TokenEntity tokenEntity)
        {
            int[] cardNumber = tokenEntity.CardNumber.ToString().ToArray().Select(x => int.Parse(x.ToString())).ToArray();
            int[] dateTimeNow = tokenEntity.Date.ToString("yyyyMMddHHmmss").ToArray().Select(x => int.Parse(x.ToString())).ToArray();
            int cvvNumber = tokenEntity.CVV;

            int[] preToken = ConcatArrays(cardNumber, dateTimeNow);

            preToken = Compare(preToken);

            int[] token = Rotate(preToken, cvvNumber);

            return string.Join("", token);
        }

        /// <summary>
        /// Part 1 - algorithms to generate token
        /// </summary>
        /// <param name="preToken"></param>
        /// <returns></returns>
        private int[] Compare(int[] preToken)
        {
            int cutLine = preToken.Min() + min;
            IEnumerable<int> tokenResult = from item in preToken where item <= cutLine select item;

            return tokenResult.ToArray();
        }

        /// <summary>
        /// Part 2 - algorithms to generate token
        /// </summary>
        /// <param name="preToken"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private int[] Rotate(int[] preToken, int k)
        {
            List<int> list = new List<int>(preToken);

            while (k != 0)
            {
                int lastItem = list.Last();
                list.Insert(0, lastItem);
                list.RemoveAt(list.Count - 1);

                k--;
            }

            return list.ToArray();
        }

        /// <summary>
        /// Part 3 - algorithms to generate token
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        private T[] ConcatArrays<T>(params T[][] list)
        {
            var result = new T[list.Sum(a => a.Length)];
            int offset = 0;
            for (int x = 0; x < list.Length; x++)
            {
                list[x].CopyTo(result, offset);
                offset += list[x].Length;
            }
            return result;
        }
    }
}
