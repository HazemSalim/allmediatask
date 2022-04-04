using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMediaDesk
{
    public class PeterNumbers
    {
        public static int GetPeterNumber(int number, int index, int last, int numberTry)
        {

            int len = number.ToString().Length;
            if (index == len)
            {
                if (numberTry <= number) return numberTry;
                return 0;
            }
            else
            {
                int chif = 9;
                while (chif >= last)
                {
                    int newTry = numberTry * 10 + chif;
                    int res = GetPeterNumber(number, index + 1, chif, newTry);
                    if (res > 0)
                    {
                        return res;

                    }
                    chif--;
                }
            }

            return 0;
        }

    }
}
