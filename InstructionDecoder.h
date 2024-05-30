#pragma once
#include <iostream>

using namespace std;

struct decodedInstruction
{
    string opcode;
    string addMode;
    string operand;
};

decodedInstruction decodeInstruction(string instruction)
{
    string temp;
    decodedInstruction ins;

    int i = 0;
    while (instruction[i] != '\0')
    {
        for (; instruction[i] != ' ' && instruction[i] != '\0'; i++)
            temp += instruction[i];

        if (temp.empty())
        {
            i++;
            continue;
        }

        if (ins.opcode.empty())
            ins.opcode = temp;
        else if (ins.addMode.empty())
            ins.addMode = temp;
        else if (ins.operand.empty())
        {
            ins.operand = temp;
            return ins;
        }

        temp = "";
    }

    return ins;
}