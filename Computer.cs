using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    struct Registers
    {
        public string InstructionRegister;
        public string TempRegister;
        public string ProgramCounter;
        public string MemoryAccessRegister;
        public string Accumulator;
        public string Input;
        public string Output;
        public string BRegister;
        public string ComparisonRegister;
    }

    struct Flops
    {
        public char IEN;
        public char INT;
        public char SKF;
        public char CURMOD;
        public char ADDRMOD;
        public char INPR;
        public char OUTR;
        public char AOFB;
        public char SOFB;
    }

    internal class Computer
    {
        private string[] Memory;
        private Flops flops;
        private Registers registers;

        private string opcode;
       

        private ALU alu;
        private utils compUtilities;

        public Computer()
        {
            compUtilities = new utils();
            alu = new ALU();
            Memory = new string[4096];
            flops= new Flops();
            registers = new Registers();

            opcode = "0000";

            for (int i = 0; i < 4096; i++)
                Memory[i] = "00000000000000000";

            registers.ProgramCounter = registers.MemoryAccessRegister = registers.Accumulator = registers.Input = registers.Output = registers.BRegister = "000000000000";
            registers.InstructionRegister = registers.TempRegister = "00000000000000000";
            registers.ComparisonRegister = "0000";
            flops.IEN = flops.INT = flops.SKF = flops.ADDRMOD = flops.INPR = flops.OUTR = '0';
            flops.OUTR = '1';
        }

        public Flops getFlops()
        {
            flops.AOFB = alu.getAOFB();
            flops.SOFB = alu.getSOFB();
            return flops;
        }

        public Registers getRegisters()
        {
            return registers;
        }

        public string[] getMemory()
        {
            string[] copy = new string[Memory.Length];
            Array.Copy(Memory, copy, Memory.Length);
            return copy;
        }

        public void loadMemory(string[] mem)
        {
            for(int i = 0; i < mem.Length; i++)
            {
                if (mem[i].Length < 17)
                    MessageBox.Show(mem[i]);
                Memory[i] = mem[i];
            }
        }

        public void runNext()
        {
            if(flops.CURMOD=='0')
            {
                MessageBox.Show("Already finished execution!");
                return;
            }

            fetch();
            decode();
            execute();
        }

        public void fetch()
        {
            registers.MemoryAccessRegister = registers.ProgramCounter;
            registers.InstructionRegister = Memory[compUtilities.binaryToDecimalMemory(registers.MemoryAccessRegister)];
            registers.ProgramCounter = alu.performArithmeticOperation("addWithCarry", registers.ProgramCounter, "000000000000");
        }

        public void decode()
        {
            opcode = registers.InstructionRegister.Substring(0, 4);
            flops.ADDRMOD = registers.InstructionRegister[4];
            registers.MemoryAccessRegister = registers.InstructionRegister.Substring(5, 12);
            //MessageBox.Show("Decoded: opcode=" + opcode + "\nDIR=" + flops.DIR + "\nMAR=" + registers.MemoryAccessRegister + " = " + compUtilities.binaryToDecimalMemory(registers.MemoryAccessRegister).ToString());
        }

        public void execute()
        {
            //Register Operation
            if (opcode == "0000")
            {
                checkIndirect();
                LDA();  
            }
            else if (opcode == "0001")
            {
                checkIndirect();
                STA();
            }
            else if (opcode == "0010")
            {
                checkIndirect();
                ADD();
            }
            else if (opcode == "0011")
            {
                checkIndirect();
                SUB();
            }
            else if (opcode == "0100")
            {
                checkIndirect();
                CMP();
            }
            else if (opcode == "0101")
            {
                checkIndirect();
                JMP();
            }
            else if (opcode == "0110")
            {
                checkIndirect();
                LAND();

            }
            else if (opcode == "0111")
            {
                checkIndirect();
                LOR();

            }
            else if (opcode == "1000")
            {
                checkIndirect();
                LNOT();
            }
            else if (opcode == "1001")
            {
                checkIndirect();
                SWAP();
            }

            //Utility
            else if (opcode == "1010" && flops.ADDRMOD == '0')
                LDI();
            else if (opcode == "1011" && flops.ADDRMOD == '0')
                INC();
            else if (opcode == "1100" && flops.ADDRMOD == '0')
                CLR();
            else if (opcode == "1101" && flops.ADDRMOD == '0')
                SHFT();
            else if (opcode == "1110" && flops.ADDRMOD == '0')
                IEN();
            else if (opcode == "1111" && flops.ADDRMOD == '0')
                BSA();

            else if (opcode == "1010" && flops.ADDRMOD == '1')
                SKIP();
            else if (opcode == "1011" && flops.ADDRMOD == '1')
                JMPL();
            else if (opcode == "1100" && flops.ADDRMOD == '1')
                JMPE();
            else if (opcode == "1101" && flops.ADDRMOD == '1')
                JMPN();
            else if (opcode == "1110" && flops.ADDRMOD == '1')
                JMPG();
            else if (opcode == "1111" && flops.ADDRMOD == '1')
                END();
        }

        public void checkIndirect()
        {
            if (flops.ADDRMOD == '1')
                registers.MemoryAccessRegister = Memory[compUtilities.binaryToDecimalMemory(registers.MemoryAccessRegister)].Substring(5, 12);
        }

        public void LDA()
        {
            registers.Accumulator = Memory[compUtilities.binaryToDecimalMemory(registers.MemoryAccessRegister)].Substring(5, 12);
            return;
        }

        public void STA()
        {
            Memory[compUtilities.binaryToDecimalMemory(registers.MemoryAccessRegister)] = "00000" + registers.Accumulator;
            return;
        }

        public void ADD()
        {
            registers.BRegister = Memory[compUtilities.binaryToDecimalMemory(registers.MemoryAccessRegister)].Substring(5,12);
            registers.Accumulator = alu.performArithmeticOperation("add", registers.Accumulator, registers.BRegister);
            flops.AOFB = alu.getAOFB();
            return;
        }

        public void SUB()
        {
            registers.BRegister = Memory[compUtilities.binaryToDecimalMemory(registers.MemoryAccessRegister)].Substring(5, 12);
            registers.Accumulator = alu.performArithmeticOperation("subtract", registers.Accumulator, registers.BRegister);
            return;
        }

        public void CMP()
        {
            
            registers.BRegister = Memory[compUtilities.binaryToDecimalMemory(registers.MemoryAccessRegister)].Substring(5, 12);

            int accVal = compUtilities.binaryToDecimalOperand(registers.Accumulator);
            int bVal = compUtilities.binaryToDecimalOperand(registers.BRegister);

            if (accVal > bVal)
                registers.ComparisonRegister = "1001";
            else if (accVal < bVal)
                registers.ComparisonRegister = "0101";
            else if (accVal == bVal)
                registers.ComparisonRegister = "0010";
            
           
            return;
        }

        public void JMP()
        {
            registers.ProgramCounter = registers.MemoryAccessRegister;
            return;
        }

        public void LAND()
        {
            registers.BRegister = Memory[compUtilities.binaryToDecimalMemory(registers.MemoryAccessRegister)].Substring(5, 12);
            registers.Accumulator = alu.logicalAND(registers.Accumulator, registers.BRegister);
           
            return;
        }

        public void LOR()
        {
            registers.BRegister = Memory[compUtilities.binaryToDecimalMemory(registers.MemoryAccessRegister)].Substring(5, 11);
            registers.Accumulator = alu.logicalOR(registers.Accumulator, registers.BRegister);

            return;
        }

        public void LNOT()
        {
            registers.Accumulator = Memory[compUtilities.binaryToDecimalMemory(registers.MemoryAccessRegister)].Substring(5, 12);
            registers.Accumulator = alu.logicalNOT(registers.Accumulator);

            return;
        }

        public void SWAP()
        {
            registers.TempRegister = Memory[compUtilities.binaryToDecimalMemory(registers.MemoryAccessRegister)];
            Memory[compUtilities.binaryToDecimalMemory(registers.MemoryAccessRegister)] = "00000" + registers.Accumulator;
            registers.Accumulator = registers.TempRegister.Substring(5, 12);
            
            return;
        }

        public void LDI()
        {
            registers.Accumulator = registers.MemoryAccessRegister;
            return;
        }

        public void INC()
        {
            if (registers.MemoryAccessRegister[11] == '1')
                registers.Accumulator = alu.performArithmeticOperation("addWithCarry", registers.Accumulator, "000000000000");
            else if (registers.MemoryAccessRegister[10] == '1')
                registers.BRegister = alu.performArithmeticOperation("addWithCarry", registers.BRegister, "000000000000");
            else if (registers.MemoryAccessRegister[9] == '1')
                flops.IEN = '1';
            else if (registers.MemoryAccessRegister[8] == '1')
                flops.SKF = '1';
            else if (registers.MemoryAccessRegister[7] == '1')
                flops.INPR = '1';
            else if (registers.MemoryAccessRegister[6] == '1')
                flops.OUTR = '1';
        }

        public void CLR()
        {
            if (registers.MemoryAccessRegister[11] == '1')
                registers.Accumulator = "000000000000";
            else if (registers.MemoryAccessRegister[10] == '1')
                registers.BRegister = "000000000000";
            else if (registers.MemoryAccessRegister[9] == '1')
                registers.ComparisonRegister = "0000";
            else if (registers.MemoryAccessRegister[8] == '1')
                flops.IEN = '0';
            else if (registers.MemoryAccessRegister[7] == '1')
                flops.SKF = '0';
            else if (registers.MemoryAccessRegister[6] == '1')
                flops.INPR = '0';
            else if (registers.MemoryAccessRegister[5] == '1')
                flops.OUTR = '0';
            else if (registers.MemoryAccessRegister[3] == '1')
                alu.clearAOFB();
            else if (registers.MemoryAccessRegister[2] == '1')
                alu.clearSOFB();
        }

        public void SHFT()
        {
            if (registers.MemoryAccessRegister[11] == '1')
                registers.Accumulator = alu.shl(registers.Accumulator);
            else if (registers.MemoryAccessRegister[10] == '1')
                registers.Accumulator = alu.shr(registers.Accumulator);
            else if (registers.MemoryAccessRegister[9] == '1')
                registers.Accumulator = alu.cil(registers.Accumulator);
            else if (registers.MemoryAccessRegister[8] == '1')
                registers.Accumulator = alu.cir(registers.Accumulator);
            else if (registers.MemoryAccessRegister[7] == '1')
                registers.Accumulator = alu.ashl(registers.Accumulator);
            else if (registers.MemoryAccessRegister[6] == '1')
                registers.Accumulator = alu.ashr(registers.Accumulator);
        }

        public void IEN()
        {
            if (registers.MemoryAccessRegister[11] == '1')
                flops.IEN = '1';
            else if (registers.MemoryAccessRegister[10] == '1')
                flops.IEN = '0';

            return;
        }

        public void BSA()
        {
            Memory[compUtilities.binaryToDecimalMemory(registers.MemoryAccessRegister)] = "00000" + registers.ProgramCounter;
            registers.MemoryAccessRegister = alu.performArithmeticOperation("addWithCarry", registers.MemoryAccessRegister, "000000000000");
            registers.ProgramCounter = registers.MemoryAccessRegister;
        }

        public void SKIP()
        {
            if (flops.SKF == '1')
                registers.ProgramCounter = alu.performArithmeticOperation("addWithCarry", registers.ProgramCounter, "000000000000");

            return;
        }

        public void JMPL()
        {
            if (registers.ComparisonRegister[1] == '1')
                registers.ProgramCounter = registers.MemoryAccessRegister;
            return;
        }

        public void JMPE()
        {
            if (registers.ComparisonRegister[2] == '1')
                registers.ProgramCounter = registers.MemoryAccessRegister;
            return;
        }

        public void JMPN()
        {
            if (registers.ComparisonRegister[3] == '1')
                registers.ProgramCounter = registers.MemoryAccessRegister;
            return;
        }

        public void JMPG()
        {
            if (registers.ComparisonRegister[0] == '1')
                registers.ProgramCounter = registers.MemoryAccessRegister;
            return;
        }

        public void END()
        {
            flops.OUTR = '0';
            return;
        }
    };
}
