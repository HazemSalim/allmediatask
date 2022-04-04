namespace AllMediaDesk
{
    class Calculator
    {
        string input;
        char[] arr;
        int length;
        int current = -1;
        char ch;
        public Calculator(string input)
        {
            this.input = input;
            arr = input.ToCharArray();
            length = arr.Length;
        }
        char nextToken()
        {
            ++current;
            if (current == length) return 'p';
            return arr[current];
        }
        public double expression()
        {
            double d = updateTerm();
            while (true)
            {
                switch (ch)
                {
                    case '+':
                        d += updateTerm();
                        break;
                    case '-':
                        d -= updateTerm();
                        break;
                    case '*':
                        d *= updateTerm();
                        break;
                    case '/':
                        d /= updateTerm();
                        break;


                    default:
                        break;

                }
                if (ch == 'p') break;
            }
            return d;

        }


        public double updateTerm()
        {
            double d = updateMain();
            switch (ch)
            {
                case '*':
                    d *= updateMain();
                    break;
                case '/':
                    d /= updateMain();
                    break;
                default:
                    break;

            }
            return d;
        }
        public double updateMain()
        {
            string str = "";
            double value = 0.0;
            while (true)
            {

                ch = nextToken();
                if (isDigit(ch))
                {
                    str += ch;
                }
                else
                {
                    break;
                }
            }
            value = double.Parse(str);
            return value;

        }

        bool isDigit(char ch)
        {
            return ch == '0' || ch == '1' || ch == '2' || ch == '3' || ch == '4' || ch == '5' || ch == '6' || ch == '7' || ch == '8' || ch == '9';
        }
    }
}
