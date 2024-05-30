namespace Simulator
{
    partial class Form1
    {
        private const string V = "Form1";

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            programInput = new TextBox();
            runButton = new Button();
            Accumulator = new Label();
            label1 = new Label();
            label2 = new Label();
            ProgramCounter = new Label();
            label4 = new Label();
            MemoryAccessRegister = new Label();
            label6 = new Label();
            BRegister = new Label();
            label8 = new Label();
            OutputRegister = new Label();
            label10 = new Label();
            InputRegister = new Label();
            label12 = new Label();
            TemporaryRegister = new Label();
            label14 = new Label();
            InstructionRegister = new Label();
            label16 = new Label();
            ComparisonRegister = new Label();
            label3 = new Label();
            label5 = new Label();
            label7 = new Label();
            label9 = new Label();
            label11 = new Label();
            label13 = new Label();
            label15 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            OUTR = new Label();
            INPR = new Label();
            ADDRMOD = new Label();
            CURMOD = new Label();
            SOFB = new Label();
            AOFB = new Label();
            SKF = new Label();
            INT = new Label();
            IEN = new Label();
            loadButton = new Button();
            mainMemory = new TextBox();
            runInstruction = new Button();
            openFromFileButton = new Button();
            resetButton = new Button();
            saveToFileButton = new Button();
            label22 = new Label();
            label23 = new Label();
            setClockbutton = new Button();
            label24 = new Label();
            clockInput = new TextBox();
            label25 = new Label();
            SuspendLayout();
            // 
            // programInput
            // 
            programInput.AcceptsReturn = true;
            programInput.AcceptsTab = true;
            programInput.BackColor = SystemColors.Info;
            programInput.BorderStyle = BorderStyle.FixedSingle;
            programInput.CharacterCasing = CharacterCasing.Upper;
            programInput.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            programInput.ForeColor = SystemColors.WindowText;
            programInput.Location = new Point(551, 541);
            programInput.Multiline = true;
            programInput.Name = "programInput";
            programInput.ScrollBars = ScrollBars.Vertical;
            programInput.Size = new Size(160, 400);
            programInput.TabIndex = 0;
            programInput.TextChanged += programInput_TextChanged;
            programInput.KeyPress += programInput_KeyPress;
            // 
            // runButton
            // 
            runButton.BackColor = SystemColors.InactiveCaption;
            runButton.Font = new Font("Harlow Solid Italic", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            runButton.ForeColor = SystemColors.HotTrack;
            runButton.Location = new Point(12, 687);
            runButton.Name = "runButton";
            runButton.Size = new Size(382, 59);
            runButton.TabIndex = 1;
            runButton.Text = "Execute all Instructions";
            runButton.UseVisualStyleBackColor = false;
            runButton.Click += runButton_Click;
            // 
            // Accumulator
            // 
            Accumulator.AutoSize = true;
            Accumulator.BackColor = Color.Wheat;
            Accumulator.Location = new Point(751, 73);
            Accumulator.MaximumSize = new Size(101, 20);
            Accumulator.MinimumSize = new Size(229, 27);
            Accumulator.Name = "Accumulator";
            Accumulator.Size = new Size(229, 27);
            Accumulator.TabIndex = 2;
            Accumulator.TextAlign = ContentAlignment.MiddleCenter;
            Accumulator.Click += Accumulator_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(551, 76);
            label1.MaximumSize = new Size(155, 0);
            label1.MinimumSize = new Size(155, 0);
            label1.Name = "label1";
            label1.Size = new Size(155, 20);
            label1.TabIndex = 3;
            label1.Text = "Accumulator";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(558, 116);
            label2.MinimumSize = new Size(155, 0);
            label2.Name = "label2";
            label2.Size = new Size(155, 20);
            label2.TabIndex = 5;
            label2.Text = "Program Counter";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // ProgramCounter
            // 
            ProgramCounter.AutoSize = true;
            ProgramCounter.BackColor = Color.Wheat;
            ProgramCounter.Location = new Point(751, 113);
            ProgramCounter.MaximumSize = new Size(101, 20);
            ProgramCounter.MinimumSize = new Size(229, 27);
            ProgramCounter.Name = "ProgramCounter";
            ProgramCounter.Size = new Size(229, 27);
            ProgramCounter.TabIndex = 4;
            ProgramCounter.TextAlign = ContentAlignment.MiddleCenter;
            ProgramCounter.Click += ProgramCounter_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(543, 151);
            label4.MinimumSize = new Size(155, 0);
            label4.Name = "label4";
            label4.Size = new Size(170, 20);
            label4.TabIndex = 7;
            label4.Text = "Memory Access Register";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Click += label4_Click;
            // 
            // MemoryAccessRegister
            // 
            MemoryAccessRegister.AutoSize = true;
            MemoryAccessRegister.BackColor = Color.Wheat;
            MemoryAccessRegister.Location = new Point(751, 151);
            MemoryAccessRegister.MaximumSize = new Size(101, 20);
            MemoryAccessRegister.MinimumSize = new Size(229, 27);
            MemoryAccessRegister.Name = "MemoryAccessRegister";
            MemoryAccessRegister.Size = new Size(229, 27);
            MemoryAccessRegister.TabIndex = 6;
            MemoryAccessRegister.TextAlign = ContentAlignment.MiddleCenter;
            MemoryAccessRegister.Click += MemoryAccessRegister_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(551, 186);
            label6.MinimumSize = new Size(155, 0);
            label6.Name = "label6";
            label6.Size = new Size(155, 20);
            label6.TabIndex = 9;
            label6.Text = "F Register";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            label6.Click += label6_Click;
            // 
            // BRegister
            // 
            BRegister.AutoSize = true;
            BRegister.BackColor = Color.Wheat;
            BRegister.Location = new Point(751, 186);
            BRegister.MaximumSize = new Size(101, 20);
            BRegister.MinimumSize = new Size(229, 27);
            BRegister.Name = "BRegister";
            BRegister.Size = new Size(229, 27);
            BRegister.TabIndex = 8;
            BRegister.TextAlign = ContentAlignment.MiddleCenter;
            BRegister.Click += BRegister_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(543, 232);
            label8.MinimumSize = new Size(155, 0);
            label8.Name = "label8";
            label8.Size = new Size(155, 20);
            label8.TabIndex = 11;
            label8.Text = "Output Register";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            label8.Click += label8_Click;
            // 
            // OutputRegister
            // 
            OutputRegister.AutoSize = true;
            OutputRegister.BackColor = Color.Wheat;
            OutputRegister.Location = new Point(751, 229);
            OutputRegister.MaximumSize = new Size(101, 20);
            OutputRegister.MinimumSize = new Size(229, 27);
            OutputRegister.Name = "OutputRegister";
            OutputRegister.Size = new Size(229, 27);
            OutputRegister.TabIndex = 10;
            OutputRegister.TextAlign = ContentAlignment.MiddleCenter;
            OutputRegister.Click += OutputRegister_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(543, 271);
            label10.MinimumSize = new Size(155, 0);
            label10.Name = "label10";
            label10.Size = new Size(155, 20);
            label10.TabIndex = 13;
            label10.Text = "Input Register";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            label10.Click += label10_Click;
            // 
            // InputRegister
            // 
            InputRegister.AutoSize = true;
            InputRegister.BackColor = Color.Wheat;
            InputRegister.Location = new Point(751, 268);
            InputRegister.MaximumSize = new Size(101, 20);
            InputRegister.MinimumSize = new Size(229, 27);
            InputRegister.Name = "InputRegister";
            InputRegister.Size = new Size(229, 27);
            InputRegister.TabIndex = 12;
            InputRegister.TextAlign = ContentAlignment.MiddleCenter;
            InputRegister.Click += InputRegister_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(543, 361);
            label12.MinimumSize = new Size(155, 0);
            label12.Name = "label12";
            label12.Size = new Size(155, 20);
            label12.TabIndex = 17;
            label12.Text = "Temporary Register";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            label12.Click += label12_Click;
            // 
            // TemporaryRegister
            // 
            TemporaryRegister.AutoSize = true;
            TemporaryRegister.BackColor = Color.RosyBrown;
            TemporaryRegister.Location = new Point(704, 358);
            TemporaryRegister.MaximumSize = new Size(101, 20);
            TemporaryRegister.MinimumSize = new Size(343, 27);
            TemporaryRegister.Name = "TemporaryRegister";
            TemporaryRegister.Size = new Size(343, 27);
            TemporaryRegister.TabIndex = 16;
            TemporaryRegister.TextAlign = ContentAlignment.MiddleCenter;
            TemporaryRegister.Click += TemporaryRegister_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(543, 316);
            label14.MinimumSize = new Size(155, 0);
            label14.Name = "label14";
            label14.Size = new Size(155, 20);
            label14.TabIndex = 15;
            label14.Text = "Instruction Register";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            label14.Click += label14_Click;
            // 
            // InstructionRegister
            // 
            InstructionRegister.AutoSize = true;
            InstructionRegister.BackColor = Color.RosyBrown;
            InstructionRegister.Location = new Point(704, 313);
            InstructionRegister.MaximumSize = new Size(101, 20);
            InstructionRegister.MinimumSize = new Size(343, 27);
            InstructionRegister.Name = "InstructionRegister";
            InstructionRegister.Size = new Size(343, 27);
            InstructionRegister.TabIndex = 14;
            InstructionRegister.TextAlign = ContentAlignment.MiddleCenter;
            InstructionRegister.Click += InstructionRegister_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(543, 414);
            label16.MinimumSize = new Size(155, 0);
            label16.Name = "label16";
            label16.Size = new Size(155, 20);
            label16.TabIndex = 19;
            label16.Text = "Comparison Register";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            label16.Click += label16_Click;
            // 
            // ComparisonRegister
            // 
            ComparisonRegister.AutoSize = true;
            ComparisonRegister.BackColor = Color.Moccasin;
            ComparisonRegister.Location = new Point(803, 407);
            ComparisonRegister.MaximumSize = new Size(101, 20);
            ComparisonRegister.MinimumSize = new Size(114, 27);
            ComparisonRegister.Name = "ComparisonRegister";
            ComparisonRegister.Size = new Size(114, 27);
            ComparisonRegister.TabIndex = 18;
            ComparisonRegister.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.HotTrack;
            label3.Location = new Point(12, 414);
            label3.MinimumSize = new Size(57, 0);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 28;
            label3.Text = "OUTR";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.HotTrack;
            label5.Location = new Point(12, 365);
            label5.MinimumSize = new Size(57, 0);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 27;
            label5.Text = "INPR";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.HotTrack;
            label7.Location = new Point(-5, 320);
            label7.MinimumSize = new Size(57, 0);
            label7.Name = "label7";
            label7.Size = new Size(88, 20);
            label7.TabIndex = 26;
            label7.Text = "ADDRMOD";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            label7.Click += label7_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.HotTrack;
            label9.Location = new Point(8, 275);
            label9.MinimumSize = new Size(57, 0);
            label9.Name = "label9";
            label9.Size = new Size(75, 20);
            label9.TabIndex = 25;
            label9.Text = "CURMOD";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            label9.Click += label9_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.HotTrack;
            label11.Location = new Point(12, 232);
            label11.MinimumSize = new Size(57, 0);
            label11.Name = "label11";
            label11.Size = new Size(57, 20);
            label11.TabIndex = 24;
            label11.Text = "SOFB";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = SystemColors.HotTrack;
            label13.Location = new Point(12, 193);
            label13.MinimumSize = new Size(57, 0);
            label13.Name = "label13";
            label13.Size = new Size(57, 20);
            label13.TabIndex = 23;
            label13.Text = "AOFB";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            label13.Click += label13_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = SystemColors.HotTrack;
            label15.Location = new Point(12, 158);
            label15.MinimumSize = new Size(57, 0);
            label15.Name = "label15";
            label15.Size = new Size(57, 20);
            label15.TabIndex = 22;
            label15.Text = "SKF";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = SystemColors.HotTrack;
            label17.Location = new Point(12, 120);
            label17.MinimumSize = new Size(57, 0);
            label17.Name = "label17";
            label17.Size = new Size(57, 20);
            label17.TabIndex = 21;
            label17.Text = "INT";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            label17.Click += label17_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = SystemColors.HotTrack;
            label18.Location = new Point(12, 80);
            label18.MaximumSize = new Size(155, 0);
            label18.MinimumSize = new Size(57, 0);
            label18.Name = "label18";
            label18.Size = new Size(57, 20);
            label18.TabIndex = 20;
            label18.Text = "IEN";
            label18.TextAlign = ContentAlignment.MiddleCenter;
            label18.Click += label18_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BorderStyle = BorderStyle.FixedSingle;
            label19.ForeColor = SystemColors.AppWorkspace;
            label19.Location = new Point(528, 64);
            label19.MinimumSize = new Size(2, 410);
            label19.Name = "label19";
            label19.Size = new Size(2, 410);
            label19.TabIndex = 29;
            label19.Click += label19_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.BackColor = Color.Linen;
            label20.Font = new Font("Harlow Solid Italic", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label20.ForeColor = SystemColors.HotTrack;
            label20.Location = new Point(549, 23);
            label20.MaximumSize = new Size(155, 0);
            label20.MinimumSize = new Size(498, 0);
            label20.Name = "label20";
            label20.Size = new Size(498, 29);
            label20.TabIndex = 30;
            label20.Text = "Registers";
            label20.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Linen;
            label21.Font = new Font("Harlow Solid Italic", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label21.ForeColor = SystemColors.HotTrack;
            label21.Location = new Point(163, 23);
            label21.MaximumSize = new Size(200, 30);
            label21.MinimumSize = new Size(126, 0);
            label21.Name = "label21";
            label21.Size = new Size(126, 29);
            label21.TabIndex = 31;
            label21.Text = "Flip-Flops";
            label21.TextAlign = ContentAlignment.MiddleCenter;
            label21.Click += label21_Click;
            // 
            // OUTR
            // 
            OUTR.AutoSize = true;
            OUTR.BackColor = Color.LightGray;
            OUTR.Location = new Point(89, 232);
            OUTR.MaximumSize = new Size(101, 20);
            OUTR.MinimumSize = new Size(46, 0);
            OUTR.Name = "OUTR";
            OUTR.Size = new Size(46, 20);
            OUTR.TabIndex = 40;
            OUTR.TextAlign = ContentAlignment.MiddleCenter;
            OUTR.Click += OUTR_Click;
            // 
            // INPR
            // 
            INPR.AutoSize = true;
            INPR.BackColor = Color.LightGray;
            INPR.Location = new Point(89, 320);
            INPR.MaximumSize = new Size(101, 20);
            INPR.MinimumSize = new Size(46, 0);
            INPR.Name = "INPR";
            INPR.Size = new Size(46, 20);
            INPR.TabIndex = 39;
            INPR.TextAlign = ContentAlignment.MiddleCenter;
            INPR.Click += INPR_Click;
            // 
            // ADDRMOD
            // 
            ADDRMOD.AutoSize = true;
            ADDRMOD.BackColor = Color.LightGray;
            ADDRMOD.Location = new Point(89, 414);
            ADDRMOD.MaximumSize = new Size(101, 20);
            ADDRMOD.MinimumSize = new Size(46, 0);
            ADDRMOD.Name = "ADDRMOD";
            ADDRMOD.Size = new Size(46, 20);
            ADDRMOD.TabIndex = 38;
            ADDRMOD.TextAlign = ContentAlignment.MiddleCenter;
            ADDRMOD.Click += ADDRMOD_Click;
            // 
            // CURMOD
            // 
            CURMOD.AutoSize = true;
            CURMOD.BackColor = Color.FromArgb(192, 255, 255);
            CURMOD.Location = new Point(597, 829);
            CURMOD.MaximumSize = new Size(101, 20);
            CURMOD.MinimumSize = new Size(46, 0);
            CURMOD.Name = "CURMOD";
            CURMOD.Size = new Size(46, 20);
            CURMOD.TabIndex = 37;
            CURMOD.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SOFB
            // 
            SOFB.AutoSize = true;
            SOFB.BackColor = Color.LightGray;
            SOFB.Location = new Point(89, 275);
            SOFB.MaximumSize = new Size(101, 20);
            SOFB.MinimumSize = new Size(46, 0);
            SOFB.Name = "SOFB";
            SOFB.Size = new Size(46, 20);
            SOFB.TabIndex = 36;
            SOFB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AOFB
            // 
            AOFB.AutoSize = true;
            AOFB.BackColor = Color.LightGray;
            AOFB.Location = new Point(89, 193);
            AOFB.MaximumSize = new Size(101, 20);
            AOFB.MinimumSize = new Size(46, 0);
            AOFB.Name = "AOFB";
            AOFB.Size = new Size(46, 20);
            AOFB.TabIndex = 35;
            AOFB.TextAlign = ContentAlignment.MiddleCenter;
            AOFB.Click += AOFB_Click;
            // 
            // SKF
            // 
            SKF.AutoSize = true;
            SKF.BackColor = Color.LightGray;
            SKF.Location = new Point(89, 158);
            SKF.MaximumSize = new Size(101, 20);
            SKF.MinimumSize = new Size(46, 2);
            SKF.Name = "SKF";
            SKF.Size = new Size(46, 20);
            SKF.TabIndex = 34;
            SKF.TextAlign = ContentAlignment.MiddleCenter;
            SKF.Click += SKF_Click;
            // 
            // INT
            // 
            INT.AutoSize = true;
            INT.BackColor = Color.LightGray;
            INT.Location = new Point(89, 120);
            INT.MaximumSize = new Size(101, 20);
            INT.MinimumSize = new Size(46, 0);
            INT.Name = "INT";
            INT.Size = new Size(46, 20);
            INT.TabIndex = 33;
            INT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IEN
            // 
            IEN.AutoSize = true;
            IEN.BackColor = Color.LightGray;
            IEN.Location = new Point(89, 80);
            IEN.MaximumSize = new Size(101, 20);
            IEN.MinimumSize = new Size(46, 0);
            IEN.Name = "IEN";
            IEN.Size = new Size(46, 20);
            IEN.TabIndex = 32;
            IEN.TextAlign = ContentAlignment.MiddleCenter;
            IEN.Click += IEN_Click;
            // 
            // loadButton
            // 
            loadButton.BackColor = SystemColors.InactiveCaption;
            loadButton.Font = new Font("Harlow Solid Italic", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            loadButton.ForeColor = SystemColors.HotTrack;
            loadButton.Location = new Point(12, 622);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(382, 59);
            loadButton.TabIndex = 41;
            loadButton.Text = "Load Written Program to Memory";
            loadButton.UseVisualStyleBackColor = false;
            loadButton.Click += loadButton_Click;
            // 
            // mainMemory
            // 
            mainMemory.BackColor = Color.BurlyWood;
            mainMemory.CharacterCasing = CharacterCasing.Upper;
            mainMemory.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            mainMemory.ForeColor = SystemColors.WindowText;
            mainMemory.Location = new Point(814, 541);
            mainMemory.Multiline = true;
            mainMemory.Name = "mainMemory";
            mainMemory.ReadOnly = true;
            mainMemory.ScrollBars = ScrollBars.Vertical;
            mainMemory.Size = new Size(340, 400);
            mainMemory.TabIndex = 42;
            mainMemory.TabStop = false;
            mainMemory.TextChanged += mainMemory_TextChanged;
            // 
            // runInstruction
            // 
            runInstruction.BackColor = SystemColors.InactiveCaption;
            runInstruction.Font = new Font("Harlow Solid Italic", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            runInstruction.ForeColor = SystemColors.HotTrack;
            runInstruction.Location = new Point(12, 752);
            runInstruction.Name = "runInstruction";
            runInstruction.Size = new Size(382, 59);
            runInstruction.TabIndex = 43;
            runInstruction.Text = "Run next Instruction";
            runInstruction.UseVisualStyleBackColor = false;
            runInstruction.Click += runInstruction_Click;
            // 
            // openFromFileButton
            // 
            openFromFileButton.BackColor = SystemColors.InactiveCaption;
            openFromFileButton.Font = new Font("Harlow Solid Italic", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            openFromFileButton.ForeColor = SystemColors.HotTrack;
            openFromFileButton.Location = new Point(12, 557);
            openFromFileButton.Name = "openFromFileButton";
            openFromFileButton.Size = new Size(382, 59);
            openFromFileButton.TabIndex = 44;
            openFromFileButton.Text = "Load Program From File to Memory";
            openFromFileButton.UseVisualStyleBackColor = false;
            openFromFileButton.Click += openFromFileButton_Click;
            // 
            // resetButton
            // 
            resetButton.BackColor = SystemColors.InactiveCaption;
            resetButton.Font = new Font("Harlow Solid Italic", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            resetButton.ForeColor = SystemColors.HotTrack;
            resetButton.Location = new Point(12, 817);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(382, 59);
            resetButton.TabIndex = 45;
            resetButton.Text = "Halt computer and reset";
            resetButton.UseVisualStyleBackColor = false;
            resetButton.Click += resetButton_Click;
            // 
            // saveToFileButton
            // 
            saveToFileButton.BackColor = SystemColors.InactiveCaption;
            saveToFileButton.Font = new Font("Harlow Solid Italic", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            saveToFileButton.ForeColor = SystemColors.HotTrack;
            saveToFileButton.Location = new Point(12, 882);
            saveToFileButton.Name = "saveToFileButton";
            saveToFileButton.Size = new Size(382, 59);
            saveToFileButton.TabIndex = 46;
            saveToFileButton.Text = "Save Program to File";
            saveToFileButton.UseVisualStyleBackColor = false;
            saveToFileButton.Click += saveToFileButton_Click;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.Linen;
            label22.Font = new Font("Harlow Solid Italic", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label22.ForeColor = SystemColors.HotTrack;
            label22.Location = new Point(528, 481);
            label22.MaximumSize = new Size(155, 0);
            label22.MinimumSize = new Size(201, 0);
            label22.Name = "label22";
            label22.Size = new Size(201, 43);
            label22.TabIndex = 47;
            label22.Text = "Input";
            label22.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.BackColor = Color.Linen;
            label23.Font = new Font("Harlow Solid Italic", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label23.ForeColor = SystemColors.HotTrack;
            label23.Location = new Point(803, 481);
            label23.MaximumSize = new Size(155, 0);
            label23.MinimumSize = new Size(382, 0);
            label23.Name = "label23";
            label23.Size = new Size(382, 43);
            label23.TabIndex = 48;
            label23.Text = "Memory";
            label23.TextAlign = ContentAlignment.MiddleCenter;
            label23.Click += label23_Click;
            // 
            // setClockbutton
            // 
            setClockbutton.BackColor = SystemColors.ControlLight;
            setClockbutton.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            setClockbutton.ForeColor = SystemColors.ControlDarkDark;
            setClockbutton.Location = new Point(382, 220);
            setClockbutton.Name = "setClockbutton";
            setClockbutton.Size = new Size(114, 27);
            setClockbutton.TabIndex = 49;
            setClockbutton.Text = "Set";
            setClockbutton.UseVisualStyleBackColor = false;
            setClockbutton.Click += setClockbutton_Click;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Harlow Solid Italic", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label24.ForeColor = SystemColors.HotTrack;
            label24.Location = new Point(163, 171);
            label24.Name = "label24";
            label24.Size = new Size(359, 22);
            label24.TabIndex = 30;
            label24.Text = "Single Instruction Execution Time (Seconds)";
            label24.Click += label24_Click;
            // 
            // clockInput
            // 
            clockInput.BackColor = SystemColors.ControlLight;
            clockInput.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            clockInput.ForeColor = SystemColors.ControlDarkDark;
            clockInput.Location = new Point(183, 220);
            clockInput.Margin = new Padding(3, 4, 3, 4);
            clockInput.MaxLength = 3;
            clockInput.MinimumSize = new Size(4, 23);
            clockInput.Multiline = true;
            clockInput.Name = "clockInput";
            clockInput.PlaceholderText = "1";
            clockInput.Size = new Size(114, 27);
            clockInput.TabIndex = 51;
            clockInput.TextAlign = HorizontalAlignment.Center;
            clockInput.TextChanged += clockInput_TextChanged;
            clockInput.KeyPress += clockInput_KeyPress;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.BackColor = Color.LightGray;
            label25.Location = new Point(89, 365);
            label25.MaximumSize = new Size(101, 20);
            label25.MinimumSize = new Size(46, 0);
            label25.Name = "label25";
            label25.Size = new Size(46, 20);
            label25.TabIndex = 52;
            label25.TextAlign = ContentAlignment.MiddleCenter;
            label25.Click += label25_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1262, 953);
            Controls.Add(label25);
            Controls.Add(clockInput);
            Controls.Add(label24);
            Controls.Add(setClockbutton);
            Controls.Add(label23);
            Controls.Add(label22);
            Controls.Add(saveToFileButton);
            Controls.Add(resetButton);
            Controls.Add(openFromFileButton);
            Controls.Add(runInstruction);
            Controls.Add(mainMemory);
            Controls.Add(loadButton);
            Controls.Add(INPR);
            Controls.Add(ADDRMOD);
            Controls.Add(OUTR);
            Controls.Add(SOFB);
            Controls.Add(AOFB);
            Controls.Add(SKF);
            Controls.Add(INT);
            Controls.Add(IEN);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label7);
            Controls.Add(label9);
            Controls.Add(label11);
            Controls.Add(label13);
            Controls.Add(label15);
            Controls.Add(label17);
            Controls.Add(label18);
            Controls.Add(label16);
            Controls.Add(ComparisonRegister);
            Controls.Add(label12);
            Controls.Add(TemporaryRegister);
            Controls.Add(label14);
            Controls.Add(InstructionRegister);
            Controls.Add(label10);
            Controls.Add(InputRegister);
            Controls.Add(label8);
            Controls.Add(OutputRegister);
            Controls.Add(label6);
            Controls.Add(BRegister);
            Controls.Add(label4);
            Controls.Add(MemoryAccessRegister);
            Controls.Add(label2);
            Controls.Add(ProgramCounter);
            Controls.Add(label1);
            Controls.Add(Accumulator);
            Controls.Add(runButton);
            Controls.Add(programInput);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Simulator";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox programInput;
        private Button runButton;
        private Label Accumulator;
        private Label label1;
        private Label label2;
        private Label ProgramCounter;
        private Label label4;
        private Label MemoryAccessRegister;
        private Label label6;
        private Label BRegister;
        private Label label8;
        private Label OutputRegister;
        private Label label10;
        private Label InputRegister;
        private Label label12;
        private Label TemporaryRegister;
        private Label label14;
        private Label InstructionRegister;
        private Label label16;
        private Label ComparisonRegister;
        private Label label3;
        private Label label5;
        private Label label7;
        private Label label9;
        private Label label11;
        private Label label13;
        private Label label15;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label OUTR;
        private Label INPR;
        private Label ADDRMOD;
        private Label CURMOD;
        private Label SOFB;
        private Label AOFB;
        private Label SKF;
        private Label INT;
        private Label IEN;
        private Button loadButton;
        private TextBox mainMemory;
        private Button runInstruction;
        private Button openFromFileButton;
        private Button resetButton;
        private Button saveToFileButton;
        private Label label22;
        private Label label23;
        private Button setClockbutton;
        private Label label24;
        private TextBox clockInput;
        private Label label25;
    }

}