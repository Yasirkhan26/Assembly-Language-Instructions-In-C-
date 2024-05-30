using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    internal class ALU
    {
        private char SOFB, AOFB;

        public ALU()
        {
            SOFB = AOFB = '0';
        }

        public string binaryAdder(string op1, string op2, char carry)
        {
            //MessageBox.Show("Adding the operands: " + op1 + "+" + op2 + "+" + carry);
            char[] result = Enumerable.Repeat('0', 12).ToArray();
            for (int i = 11; i >= 0; i--)
            {
                if (op1[i] == '0' && op2[i] == '0' && carry == '0')
                {
                    result[i] = '0';
                    carry = '0';
                }
                else if (op1[i] == '0' && op2[i] == '0' && carry == '1')
                {
                    result[i] = '1';
                    carry = '0';
                }
                else if (op1[i] == '0' && op2[i] == '1' && carry == '0')
                {
                    result[i] = '1';
                    carry = '0';
                }
                else if (op1[i] == '0' && op2[i] == '1' && carry == '1')
                {
                    result[i] = '0';
                    carry = '1';
                }
                else if (op1[i] == '1' && op2[i] == '0' && carry == '0')
                {
                    result[i] = '1';
                    carry = '0';
                }
                else if (op1[i] == '1' && op2[i] == '0' && carry == '1')
                {
                    result[i] = '0';
                    carry = '1';
                }
                else if (op1[i] == '1' && op2[i] == '1' && carry == '0')
                {
                    result[i] = '0';
                    carry = '1';
                }
                else if (op1[i] == '1' && op2[i] == '1' && carry == '1')
                {
                    result[i] = '1';
                    carry = '1';
                }
            }

            if (carry == '1')
                AOFB = '1';

            return new string(result);
        }

        public string performArithmeticOperation(string operation, string op1, string op2)
        {
            if (operation == "add")
            {
                return binaryAdder(op1, op2, '0');
            }
            else if (operation == "addWithCarry")
            {
                return binaryAdder(op1, op2, '1');
            }
            else if (operation == "subtract")
            {
                return binaryAdder(op1, logicalNOT(op2), '1');
            }
            else if (operation == "subtractWithBorrow")
            {
                return binaryAdder(op1, logicalNOT(op2), '0');
            }
            else
            {
                return "000000000000";
            }
        }

        public string logicalNOT(string op)
        {
            char[] result = Enumerable.Repeat('0', 12).ToArray();
            for (int i = 0; i < 12; i++)
                if (op[i] == '0')
                    result[i] = '1';
                else result[i] = '0';

            return new string (result);
        }

        public string logicalOR(string op1, string op2)
        {
            char[] result = Enumerable.Repeat('0', 12).ToArray();
            for (int i = 0; i < 12; i++)
                if (op1[i] == '1' || op2[i] == '1')
                    result[i] = '1';
                else result[i] = '0';

            return new string(result);
        }

        public string logicalAND(string op1, string op2)
        {
            char[] result = Enumerable.Repeat('0', 12).ToArray();
            for (int i = 0; i < 12; i++)
                if (op1[i] == '1' && op2[i] == '1')
                    result[i] = '1';
                else result[i] = '0';

            return new string(result);
        }

        public string shr(string op)
        {
            char[] result = Enumerable.Repeat('0', 12).ToArray();
            //SOFB = op[11];

            for (int i = 1; i < 12; i++)
                result[i] = op[i - 1];

            return new string(result);
        }

        public string shl(string op)
        {
            char[] result = Enumerable.Repeat('0', 12).ToArray();
            //SOFB = op[0];

            for (int i = 0; i < 11; i++)
                result[i] = op[i + 1];

            return new string(result);
        }

        public string cir(string op)
        {
            char[] result = Enumerable.Repeat('0', 12).ToArray();
            result[0] = op[11];

            for (int i = 1; i < 12; i++)
                result[i] = op[i - 1];

            return new string(result);
        }

        public string cil(string op)
        {
            char[] result = Enumerable.Repeat('0', 12).ToArray();
            result[11] = op[0];

            for (int i = 0; i < 11; i++)
                result[i] = op[i + 1];

            return new string(result);
        }

        public string ashr(string op)
        {
            char[] result = Enumerable.Repeat('0', 12).ToArray();
            result[0] = op[0];

            for (int i = 1; i < 12; i++)
                result[i] = op[i - 1];

            return new string(result);
        }

        public string ashl(string op)
        {
            char[] result = Enumerable.Repeat('0', 12).ToArray();
            if (op[0] != op[1])
                SOFB = '1';

            for (int i = 0; i < 11; i++)
                result[i] = op[i + 1];

            return new string(result);
        }

        public char getSOFB()
        {
            return SOFB;
        }

        public char getAOFB()
        {
            return AOFB;
        }

        public void clearSOFB()
        {
            SOFB = '0';
        }

        public void clearAOFB()
        {
            AOFB = '0';
        }
    };
}
