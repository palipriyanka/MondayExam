using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeMvc.Utility
{
    public class Utility
    {
        public static int Sum(params int[] prms)
        {
            var sum = 0;
            foreach (var item in prms)
            {
                sum = sum + item;
            }
            return sum;
        }
        public int Multiply(params int[] prms)
        {
            var mul = 1;
            foreach (var item in prms)
            {
                mul = mul * item;
            }
            return mul;
        }
    }
}
