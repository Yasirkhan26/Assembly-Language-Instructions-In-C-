using System.CodeDom.Compiler;
using System.DirectoryServices;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int clock = 1000;


        utils utilities = new utils();

        Computer computer;

        Registers registers = new Registers();
        Flops flops = new Flops();
        string[] temp1 = new string[4096];

        public void updateValues()
        {

            registers = computer.getRegisters();
            flops = computer.getFlops();
            temp1 = computer.getMemory();

            Accumulator.Text = registers.Accumulator;
            ProgramCounter.Text = registers.ProgramCounter;
            MemoryAccessRegister.Text = registers.MemoryAccessRegister;
            BRegister.Text = registers.BRegister;
            OutputRegister.Text = registers.Output;
            InputRegister.Text = registers.Input;
            InstructionRegister.Text = registers.InstructionRegister;
            TemporaryRegister.Text = registers.TempRegister;
            ComparisonRegister.Text = registers.ComparisonRegister;

            IEN.Text = flops.IEN.ToString();
            INT.Text = flops.INT.ToString();
            SKF.Text = flops.SKF.ToString();
            AOFB.Text = flops.AOFB.ToString();
            SOFB.Text = flops.SOFB.ToString();
            CURMOD.Text = flops.CURMOD.ToString();
            ADDRMOD.Text = flops.ADDRMOD.ToString();
            INPR.Text = flops.INPR.ToString();
            OUTR.Text = flops.OUTR.ToString();

            for (int i = 0; i < temp1.Length; i++)
                temp1[i] = i + ":\t" + temp1[i].Substring(0, 5) + " " + temp1[i].Substring(5, 12);

            mainMemory.Lines = temp1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resetComputer();
        }

        private async void runButton_Click(object sender, EventArgs e)
        {
            if (computer == null)
            {
                MessageBox.Show("Load Program First!");
                return;
            }

            while (flops.OUTR == '1')
            {
                runButton.Enabled = false;
                loadButton.Enabled = false;
                runInstruction.Enabled = false;
                openFromFileButton.Enabled = false;
                resetButton.Enabled = true;
                resetButton.Focus();
                programInput.Enabled = false;
                clockInput.Enabled = false;
                setClockbutton.Enabled = false;

                computer.runNext();
                updateValues();
                await Task.Delay(clock);
            }


            MessageBox.Show("Finished execution of program\nPress load button to restart execution");

            runButton.Enabled = true;
            loadButton.Enabled = true;
            programInput.Enabled = true;
            runInstruction.Enabled = true;
            openFromFileButton.Enabled = true;
            resetButton.Enabled = false;
        }

        private void runInstruction_Click(object sender, EventArgs e)
        {
            if (computer == null)
            {
                MessageBox.Show("Load Program First!");
                return;
            }

            computer.runNext();
            updateValues();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            loadProgram();
        }

        private void saveToFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    foreach (string line in programInput.Lines)
                        writer.WriteLine(line);
                MessageBox.Show("File saved successfully");
            }
        }

        private void openFromFileButton_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Text files (*.txt)|*.txt";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                programInput.Lines = File.ReadAllLines(path);
            }
            loadProgram();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            resetComputer();
        }

        private void setClockbutton_Click(object sender, EventArgs e)
        {
            clock = Convert.ToInt32(float.Parse(clockInput.Text) * 1000);
        }

        private void clockInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void programInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 9)
            {
                e.Handled = true;
                SendKeys.Send("  ");
            }
            else
                e.Handled = false;
        }

        private void resetComputer()
        {
            runButton.Enabled = true;
            loadButton.Enabled = true;
            programInput.Enabled = true;
            runInstruction.Enabled = true;
            openFromFileButton.Enabled = true;
            resetButton.Enabled = false;
            clockInput.Enabled = true;
            setClockbutton.Enabled = true;
            runButton.Enabled = false;
            runInstruction.Enabled = false;
            clockInput.Enabled = true;
            setClockbutton.Enabled = true;

            string[] tempIns = new string[4096];
            for (int i = 0; i < 4096; i++)
                tempIns[i] = i + ":\t00000 00000000000";
            mainMemory.Lines = tempIns;

            computer = new Computer();
            updateValues();
            flops.OUTR = '0';

        }

        private void loadProgram()
        {
            resetComputer();
            string[] tempIns = new string[4096];
            string[] tempMem = new string[4096];

            int i = 0;
            for (; i < 4096; i++)
            {
                tempIns[i] = i + ":\t00000 000000000000";
                tempMem[i] = "00000000000000000";
            }

            i = 0;
            foreach (string line in programInput.Lines)
            {
                decodedInstruction temp = utilities.decodeInstruction(line);

                if (temp.opcode == null)
                {
                    tempIns[i] = i + ":\t11111 111111111111";
                    tempMem[i] = "11111111111111111";
                }
                else if (utilities.categorize(temp.opcode) == 'r')
                {
                    if ((temp.addMode) != "I" && temp.addMode != "D")
                    {
                        MessageBox.Show("Invalid addressing mode/operand used\nCheck program at line:" + line);
                        return;
                    }
                    tempIns[i] = i + ":\t" + utilities.getOpcode(temp.opcode, temp.addMode) + ' ' + utilities.decToBinaryMemory(temp.operand);
                    tempMem[i] = utilities.getOpcode(temp.opcode, temp.addMode) + utilities.decToBinaryMemory(temp.operand);
                }
                else if (utilities.categorize(temp.opcode) == 'u')
                {
                    if ((temp.addMode) == null)
                    {
                        MessageBox.Show("Operand not specified\nCheck program at line:" + line);
                        return;
                    }

                    if (temp.addMode[0] == '#')
                    {
                        tempIns[i] = i + ":\t" + utilities.getOpcode(temp.opcode, "") + ' ' + utilities.hexToBinary(temp.addMode.Substring(1, temp.addMode.Length - 1));
                        tempMem[i] = utilities.getOpcode(temp.opcode, "") + utilities.hexToBinary(temp.addMode.Substring(1, temp.addMode.Length - 1));
                    }
                    else
                    {
                        tempIns[i] = i + ":\t" + utilities.getOpcode(temp.opcode, "") + ' ' + utilities.decToBinary(temp.addMode);
                        tempMem[i] = utilities.getOpcode(temp.opcode, "") + utilities.decToBinary(temp.addMode);
                    }
                }
                else if (utilities.categorize(temp.opcode) == 's')
                {
                    tempIns[i] = i + ":\t10101 111111111111";
                    tempMem[i] = "10101111111111111";
                }
                else if (utilities.categorize(temp.opcode) == 'e')
                {
                    tempIns[i] = i + ":\t11111 111111111111";
                    tempMem[i] = "11111111111111111";
                }
                else
                {
                    if (temp.opcode[0] == '#')
                    {
                        tempIns[i] = i + ":\t00000 " + utilities.hexToBinary(temp.opcode);
                        tempMem[i] = "00000" + utilities.hexToBinary(temp.opcode);
                    }
                    else
                    {
                        if (utilities.decToBinaryMemory(temp.opcode) == "")
                        {
                            MessageBox.Show("Invalid opcode used\nCheck program at line:" + line);
                            return;
                        }

                        tempIns[i] = i + ":\t00000 " + utilities.decToBinaryMemory(temp.opcode);
                        tempMem[i] = "00000" + utilities.decToBinaryMemory(temp.opcode);
                    }
                }

                i++;
            }

            mainMemory.Lines = tempIns;
            computer.loadMemory(tempMem);
            updateValues();
            runButton.Enabled = true;
            runInstruction.Enabled = true;
        }

        private void InstructionRegister_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void InputRegister_Click(object sender, EventArgs e)
        {

        }

        private void TemporaryRegister_Click(object sender, EventArgs e)
        {

        }

        private void ADDRMOD_Click(object sender, EventArgs e)
        {

        }

        private void OutputRegister_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void OUTR_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void AOFB_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void BRegister_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SKF_Click(object sender, EventArgs e)
        {

        }

        private void MemoryAccessRegister_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Accumulator_Click(object sender, EventArgs e)
        {

        }

        private void IEN_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void clockInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void INPR_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void programInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void ProgramCounter_Click(object sender, EventArgs e)
        {

        }

        private void mainMemory_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}