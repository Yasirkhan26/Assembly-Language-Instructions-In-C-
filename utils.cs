using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    struct decodedInstruction
    {
        public string opcode;
        public string addMode;
        public string operand;
    };

    internal class utils
    {
        public decodedInstruction decodeInstruction(string instruction)
        {
            string temp = "";
            decodedInstruction ins = new decodedInstruction();

            int i = 0;
            while (i < instruction.Length) 
            {
                for (; i < instruction.Length; i++)
                {
                    if (instruction[i] == ' ' || instruction[i] == '\0')
                        break;

                    temp += instruction[i];
                }

                if (string.IsNullOrEmpty(temp))
                {
                    i++;
                    continue;
                }

                if (string.IsNullOrEmpty(ins.opcode))
                    ins.opcode = temp;
                else if (string.IsNullOrEmpty(ins.addMode))
                    ins.addMode = temp;
                else if (string.IsNullOrEmpty(ins.operand))
                {
                    ins.operand = temp;
                    return ins;
                }

                temp = "";
            }

            return ins;
        }

        public int binaryToDecimalOperand(string binary)
        {
            int result = 0;
            if (binary[0] == '1')
                result -= Convert.ToInt32(Math.Pow(2, 10));

            for (int i = 1; i < 11; i++)
                if (binary[i] == '1')
                    result += Convert.ToInt32(Math.Pow(2, (10 - i)));

            return result;
        }

        public int binaryToDecimalMemory(string binary)
        {
            int result = 0;

            for (int i = 0; i < 11; i++)
                if (binary[i] == '1')
                    result += Convert.ToInt32(Math.Pow(2, (10 - i)));

            return result;
        }

        public string hexToBinary(string hex)
        {
            string temp = "";
            if (hex.Length == 0)
                temp = "00000000000";
            else if (hex.Length == 1)
                temp = "0000000" + hexToBinaryChar(hex[0]);
            else if (hex.Length == 2)
                temp = "000" + hexToBinaryChar(hex[0]) + hexToBinaryChar(hex[1]);
            else
            {
                if (hexToBinaryChar(hex[0])[0] == '1')
                    temp += "000";
                else temp += hexToBinaryChar(hex[0]).Substring(1, 3);

                temp += hexToBinaryChar(hex[1]);
                temp += hexToBinaryChar(hex[2]);
            }

            return temp;
        }

        public string decToBinaryMemory(string dec)
        {
            try
            {
                return Convert.ToString(int.Parse(dec), 2).PadLeft(11, '0');
            }
            catch(Exception ex)
            { 
                return ""; 
            }
        }

        public string decToBinary(string dec)
        {
            int decVal = int.Parse(dec);
            if (decVal >= 0)
                return decToBinaryMemory(dec);

            string twosComp = "";
            for (int i = 0; i < 11; i++)
            {
                int bitVal = (decVal & (1 << i)) > 0 ? 0 : 1;
                twosComp = bitVal.ToString() + twosComp;
            }

            int carry = 1;
            for (int i = twosComp.Length - 1; i >= 0; i--)
            {
                if (twosComp[i] == '0' && carry == 1)
                    twosComp = twosComp.Substring(0, i) + "1" + twosComp.Substring(i + 1);
                else if (twosComp[i] == '1' && carry == 1)
                    twosComp = twosComp.Substring(0, i) + "0" + twosComp.Substring(i + 1);
                else
                    break;
            }

            return twosComp;
        }

        public string hexToBinaryChar(char hexChar)
        {
            switch (hexChar)
            {
                case '0':
                    return "0000";
                case '1':
                    return "0001";
                case '2':
                    return "0010";
                case '3':
                    return "0011";
                case '4':
                    return "0100";
                case '5':
                    return "0101";
                case '6':
                    return "0110";
                case '7':
                    return "0111";
                case '8':
                    return "1000";
                case '9':
                    return "1001";
                case 'A':
                    return "1010";
                case 'B':
                    return "1011";
                case 'C':
                    return "1100";
                case 'D':
                    return "1101";
                case 'E':
                    return "1110";
                case 'F':
                    return "1111";
                default:
                    return "0000";
            }
        }

        public string getOpcode(string opcode, string addMode)
        {
            char temp = new char();

            if (addMode == "I")
                temp = '1';
            else 
                temp = '0';


            //Register Operations
            if (opcode == "LOD")
                return "0000" + temp;
            else if (opcode == "STO")
                return "0001" + temp;
            else if (opcode == "ADD")
                return "0010" + temp;
            else if (opcode == "SUB")
                return "0011" + temp;
            else if (opcode == "CMP")
                return "0100" + temp;
            else if (opcode == "JMP")
                return "0101" + temp;
            else if (opcode == "LAD")
                return "0110" + temp;
            else if (opcode == "LOR")
                return "0111" + temp;
            else if (opcode == "LNT")
                return "1000" + temp;
            else if (opcode == "SWP")
                return "1001" + temp;

            //Utility Operations

            else if (opcode == "LDM")
                return "10100";
            else if (opcode == "INC")
                return "10110";
            else if (opcode == "CLR")
                return "11000";
            else if (opcode == "SHT")
                return "11010";
            else if (opcode == "INT")
                return "11100";
            else if (opcode == "BRS")
                return "11110";

            else if (opcode == "SKP")
                return "10101";
            else if (opcode == "JML")
                return "10111";
            else if (opcode == "JME")
                return "11001";
            else if (opcode == "JMN")
                return "11011";
            else if (opcode == "JMG")
                return "11101";
            else if (opcode == "END")
                return "11111";

            return "11111";
        }

        public char categorize(string opcode)
        {
            if ((opcode == "LOD") || (opcode == "STO") || (opcode == "ADD") || (opcode == "SUB") || (opcode == "CMP") || (opcode == "JMP") || (opcode == "LAD") || (opcode == "LOR") || (opcode == "LNT") || (opcode == "SWP"))
                return 'r';
            else if ((opcode == "LDM") || (opcode == "INC") || (opcode == "CLR") || (opcode == "SHT") || (opcode == "INT") || (opcode == "BRS") || (opcode == "JML") || (opcode == "JME") || (opcode == "JMN") || (opcode == "JMG"))
                return 'u';
            else if (opcode == "END")
                return 'e';
            else if (opcode == "SKP")
                return 's';
            else
                return 'o';
        }
    }
}
