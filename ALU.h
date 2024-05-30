#pragma once
#include <iostream>

using namespace std;

class ALU
{
private:
    char SOV, AOV;

public:
    ALU()
    {
        SOV = AOV = '0';
    }

    string binaryAdder(string op1, string op2, char carry)
    {
        string result = "00000000000";

        for (int i = 10; i >= 0; i--)
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
            AOV = '1';

        return result;
    }

    string performArithmeticOperation(string operation, string op1, string op2)
    {
        if (operation == "add")
        {
            return binaryAdder(op1, op2, '0');
        }
        else if (operation == "addWithCarry")
        {
            return binaryAdder(op1, op2, '0');
        }
        else if (operation == "subtract")
        {
            return binaryAdder(op1, logicalNOT(op2), '1');
        }
        else if (operation == "subtractWithBorrow")
        {
            return binaryAdder(op1, logicalNOT(op2), '0');
        }
    }

    string logicalNOT(string op)
    {
        string result = "00000000000";
        for (int i = 0; i < 11; i++)
            if (op[i] == '0')
                result[i] = '1';

        return result;
    }

    string logicalOR(string op1, string op2)
    {
        string result = "00000000000";
        for (int i = 0; i < 11; i++)
            if (op1[i] == '1' || op2[i] == '1')
                result[i] = '1';

        return result;
    }

    string logicalAND(string op1, string op2)
    {
        string result = "00000000000";
        for (int i = 0; i < 11; i++)
            if (op1[i] == '1' && op2[i] == '1')
                result[i] = '1';

        return result;
    }

    string shr(string op)
    {
        string result = "00000000000";
        SOV = op[10];

        for (int i = 1; i < 11; i++)
            result[i] = op[i - 1];

        return result;
    }

    string shl(string op)
    {
        string result = "00000000000";
        SOV = op[0];

        for (int i = 0; i < 10; i++)
            result[i] = op[i + 1];

        return result;
    }

    string cir(string op)
    {
        string result = "00000000000";
        result[0] = op[10];

        for (int i = 1; i < 11; i++)
            result[i] = op[i - 1];

        return result;
    }

    string cil(string op)
    {
        string result = "00000000000";
        result[10] = op[0];

        for (int i = 0; i < 10; i++)
            result[i] = op[i + 1];

        return result;
    }

    string ashr(string op)
    {
        string result = "00000000000";
        result[0] = op[0];

        for (int i = 1; i < 11; i++)
            result[i] = op[i - 1];

        return result;
    }

    string ashl(string op)
    {
        string result = "00000000000";
        if (op[0] != op[1])
            SOV = 1;

        for (int i = 0; i < 10; i++)
            result[i] = op[i + 1];

        return result;
    }

    char getSOV()
    {
        return SOV;
    }

    char getAOV()
    {
        return AOV;
    }

    void clearSOV()
    {
        SOV = '0';
    }

    void clearAOV()
    {
        AOV = '0';
    }
};