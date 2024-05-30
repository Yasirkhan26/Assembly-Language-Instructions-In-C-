#include <iostream>
#include <string>
#include <stdlib.h>
#include "ALU.h"
#include "binToDec.h"
using namespace std;

class Computer
{
private:
    string Memory[2048];

    string InstructionRegister;
    string TempRegister;
    string ProgramCounter;
    string MemoryAccessRegister;
    string Accumulator;
    string Input;
    string Output;
    string BRegister;
    string ComparisonRegister;

    char IEN;
    char INT;
    char SKF;
    // char AOV;
    // char SOV;
    char OPR;
    char DIR;
    char INF;
    char OPF;

public:
    ALU ALU1;
    Computer()
    {
        for (int i = 0; i < 2048; i++)
        {
            Memory[i] = "00000000000";
        }
        InstructionRegister = TempRegister = ProgramCounter = MemoryAccessRegister = Accumulator = Input = Output = ComparisonRegister = "00000000000";
        IEN = INT = SKF = DIR = INF = OPF = '0';
        OPR = '1';
    }

    void clockPulse()
    {
        string temp1 = "00000000001";
        MemoryAccessRegister = ProgramCounter;
        ProgramCounter = ALU1.performArithmeticOperation("add", ProgramCounter, temp1);
    }

    void LOD(string address)
    {
        if (DIR = 0)
        {
            int index = binaryToDecimal(address);
            Accumulator = Memory[index];
        }
        else if (DIR = 1)
        {
            int temp1 = binaryToDecimal(address);
            string temp2 = Memory[temp1];
            int index = binaryToDecimal(temp2);
            Accumulator = Memory[index];
        }
        return;
    }

    void STO(string address)
    {
        if (DIR = 0)
        {
            int index = binaryToDecimal(address);
            Memory[index] = Accumulator;
        }
        else if (DIR = 1)
        {
            int temp1 = binaryToDecimal(address);
            string temp2 = Memory[temp1];
            int index = binaryToDecimal(temp2);
            Memory[index] = Accumulator;
        }
        return;
    }

    void ADD(string address)
    {
        if (DIR = 0)
        {
            int index = binaryToDecimal(address);
            BRegister = Memory[index];
            Accumulator = ALU1.performArithmeticOperation("add", Accumulator, BRegister);
        }
        else if (DIR = 1)
        {
            int temp1 = binaryToDecimal(address);
            string temp2 = Memory[temp1];
            int index = binaryToDecimal(temp2);
            BRegister = Memory[index];
            Accumulator = ALU1.performArithmeticOperation("add", Accumulator, BRegister);
        }
        return;
    }

    void SUB(string address)
    {
        if (DIR = 0)
        {
            int index = binaryToDecimal(address);
            BRegister = Memory[index];
            Accumulator = ALU1.performArithmeticOperation("subrtact", Accumulator, BRegister);
        }
        else if (DIR = 1)
        {
            int temp1 = binaryToDecimal(address);
            string temp2 = Memory[temp1];
            int index = binaryToDecimal(temp2);
            BRegister = Memory[index];
            Accumulator = ALU1.performArithmeticOperation("subtract", Accumulator, BRegister);
        }
        return;
    }

    void CMP(string address)
    {
        if (DIR = 0)
        {
            int index = binaryToDecimal(address);
            BRegister = Memory[index];

            if(Accumulator > BRegister)
                ComparisonRegister[3] = '1';
            if (Accumulator < BRegister)
                ComparisonRegister[2] = '1';
            if (Accumulator == BRegister)
                ComparisonRegister[1] = '1';
            if (Accumulator != BRegister)
                ComparisonRegister[0] = '1';
        }
        else if (DIR = 1)
        {
            int temp1 = binaryToDecimal(address);
            string temp2 = Memory[temp1];
            int index = binaryToDecimal(temp2);
            BRegister = Memory[index];
            Accumulator = ALU1.performArithmeticOperation("subtract", Accumulator, BRegister);

            if (Accumulator > BRegister)
                ComparisonRegister[3] = '1';
            if (Accumulator < BRegister)
                ComparisonRegister[2] = '1';
            if (Accumulator == BRegister)
                ComparisonRegister[1] = '1';
            if (Accumulator != BRegister)
                ComparisonRegister[0] = '1';
        }
        return;
    }

    void JMP(string address)
    {
        if (DIR = 0)
        {
            int index = binaryToDecimal(address);
            ProgramCounter = Memory[index];
        }
        else if (DIR = 1)
        {
            int temp1 = binaryToDecimal(address);
            string temp2 = Memory[temp1];
            int index = binaryToDecimal(temp2);
            ProgramCounter = Memory[index];
        }
        return;
    }

    void LAD(string address)
    {
        if (DIR = 0)
        {
            int index = binaryToDecimal(address);
            BRegister = Memory[index];
            Accumulator = ALU1.logicalAND(Accumulator, BRegister);
        }
        else if (DIR = 1)
        {
            int temp1 = binaryToDecimal(address);
            string temp2 = Memory[temp1];
            int index = binaryToDecimal(temp2);
            BRegister = Memory[index];
            Accumulator = ALU1.logicalAND(Accumulator, BRegister);
        }
        return;
    }

    void LOR(string address)
    {
        if (DIR = 0)
        {
            int index = binaryToDecimal(address);
            BRegister = Memory[index];
            Accumulator = ALU1.logicalOR(Accumulator, BRegister);
        }
        else if (DIR = 1)
        {
            int temp1 = binaryToDecimal(address);
            string temp2 = Memory[temp1];
            int index = binaryToDecimal(temp2);
            BRegister = Memory[index];
            Accumulator = ALU1.logicalOR(Accumulator, BRegister);
        }
        return;
    }

    void LNT(string address)
    {
        if (DIR = 0)
        {
            int index = binaryToDecimal(address);
            BRegister = Memory[index];
            Accumulator = ALU1.logicalNOT(BRegister);
        }
        else if (DIR = 1)
        {
            int temp1 = binaryToDecimal(address);
            string temp2 = Memory[temp1];
            int index = binaryToDecimal(temp2);
            BRegister = Memory[index];
            Accumulator = ALU1.logicalNOT(BRegister);
        }
        return;
    }

    void SWP(string address)
    {
        if (DIR = 0)
        {
            string temp;
            int index = binaryToDecimal(address);
            BRegister = Memory[index];
            temp = Accumulator;
            Accumulator = BRegister;
            BRegister = temp;
        }
        else if (DIR = 1)
        {
            string temp;
            int temp1 = binaryToDecimal(address);
            string temp2 = Memory[temp1];
            int index = binaryToDecimal(temp2);
            BRegister = Memory[index];
            temp = Accumulator;
            Accumulator = BRegister;
            BRegister = temp;
        }
        return;
    }

    void LDM(string Operand)
    {
        Accumulator = Operand;
        return;
    }

    string INC(string OpRegister)
    {
        string temp1;
        char temp2;
        temp1 = "000000000001";
        temp2 = '0';
        return ALU1.performArithmeticOperation("add", OpRegister, temp1);
    }

    string CLR(string OpRegister)
    {
        string temp1;
        temp1 = "0000000000";
        return ALU1.logicalAND(OpRegister, temp1);
    }

    string SHT(string ShiftType)
    {
        if (ShiftType == "CIL")
        {
            return ALU1.cil(Accumulator);
        }
        else if (ShiftType == "CIR")
        {
            return ALU1.cir(Accumulator);
        }
        else if (ShiftType == "SHL")
        {
            return ALU1.shl(Accumulator);
        }
        else if (ShiftType == "SHR")
        {
            return ALU1.shr(Accumulator);
        }
        else if (ShiftType == "ASHL")
        {
            return ALU1.ashl(Accumulator);
        }
        else if (ShiftType == "ASHR")
        {
            return ALU1.ashr(Accumulator);
        }
    }

    void INE()
    {
        if(MemoryAccessRegister == "001")
        {
            IEN = '1';
        }
        else if (MemoryAccessRegister == "002")
        {
            IEN = '0';
        }
        return;
    }

    void BRS(string address)
    {
        int index = binaryToDecimal(MemoryAccessRegister);
        Memory[index] = ProgramCounter;
        string temp1 = "00000000001";
        MemoryAccessRegister = ALU1.performArithmeticOperation("add", MemoryAccessRegister, temp1);
        ProgramCounter = MemoryAccessRegister;
    }

    void SKP()
    {
        if (SKF == '1')
        {
            string temp = "00000000001";
            ProgramCounter = ALU1.performArithmeticOperation("add", ProgramCounter, temp);
        }
        return;
    }

    void JML()
    {
        if (ComparisonRegister[1] == '1')
        {
            int index = binaryToDecimal(MemoryAccessRegister);
            ProgramCounter = Memory[index];
        }
        return;
    }

    void JME()
    {
        if (ComparisonRegister[2] == '1')
        {
            int index = binaryToDecimal(MemoryAccessRegister);
            ProgramCounter = Memory[index];
        }
        return;
    }

    void JMN()
    {
        if (ComparisonRegister[4] == '1')
        {
            int index = binaryToDecimal(MemoryAccessRegister);
            ProgramCounter = Memory[index];
        }
        return;
    }

    void JMG()
    {
        if (ComparisonRegister[0] == '1')
        {
            int index = binaryToDecimal(MemoryAccessRegister);
            ProgramCounter = Memory[index];
        }
        return;
    }

    void END()
    {
        OPR = '0';
        return;
    }
};

int main()
{
}