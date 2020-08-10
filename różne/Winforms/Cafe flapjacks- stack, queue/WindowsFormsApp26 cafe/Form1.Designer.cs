namespace WindowsFormsApp26_cafe
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.numOfFlapjacks = new System.Windows.Forms.NumericUpDown();
            this.addLumberjackButton = new System.Windows.Forms.Button();
            this.nextLumberjackButton = new System.Windows.Forms.Button();
            this.addFlapjacksButton = new System.Windows.Forms.Button();
            this.laneList = new System.Windows.Forms.ListBox();
            this.crispy = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.soggy = new System.Windows.Forms.RadioButton();
            this.banana = new System.Windows.Forms.RadioButton();
            this.browned = new System.Windows.Forms.RadioButton();
            this.infoBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numOfFlapjacks)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lumberjack name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Breakffast lane";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(104, 9);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(151, 20);
            this.nameBox.TabIndex = 3;
            // 
            // numOfFlapjacks
            // 
            this.numOfFlapjacks.Location = new System.Drawing.Point(6, 30);
            this.numOfFlapjacks.Name = "numOfFlapjacks";
            this.numOfFlapjacks.Size = new System.Drawing.Size(120, 20);
            this.numOfFlapjacks.TabIndex = 4;
            // 
            // addLumberjackButton
            // 
            this.addLumberjackButton.Location = new System.Drawing.Point(12, 35);
            this.addLumberjackButton.Name = "addLumberjackButton";
            this.addLumberjackButton.Size = new System.Drawing.Size(243, 23);
            this.addLumberjackButton.TabIndex = 5;
            this.addLumberjackButton.Text = "Add Lumberjack";
            this.addLumberjackButton.UseVisualStyleBackColor = true;
            this.addLumberjackButton.Click += new System.EventHandler(this.addLumberjackButton_Click);
            // 
            // nextLumberjackButton
            // 
            this.nextLumberjackButton.Location = new System.Drawing.Point(6, 289);
            this.nextLumberjackButton.Name = "nextLumberjackButton";
            this.nextLumberjackButton.Size = new System.Drawing.Size(126, 23);
            this.nextLumberjackButton.TabIndex = 6;
            this.nextLumberjackButton.Text = "Next Lumberjack";
            this.nextLumberjackButton.UseVisualStyleBackColor = true;
            this.nextLumberjackButton.Click += new System.EventHandler(this.nextLumberjackButton_Click);
            // 
            // addFlapjacksButton
            // 
            this.addFlapjacksButton.Location = new System.Drawing.Point(6, 169);
            this.addFlapjacksButton.Name = "addFlapjacksButton";
            this.addFlapjacksButton.Size = new System.Drawing.Size(120, 23);
            this.addFlapjacksButton.TabIndex = 7;
            this.addFlapjacksButton.Text = "Add flapjacks";
            this.addFlapjacksButton.UseVisualStyleBackColor = true;
            this.addFlapjacksButton.Click += new System.EventHandler(this.addFlapjacksButton_Click);
            // 
            // laneList
            // 
            this.laneList.FormattingEnabled = true;
            this.laneList.Location = new System.Drawing.Point(9, 129);
            this.laneList.Name = "laneList";
            this.laneList.Size = new System.Drawing.Size(114, 303);
            this.laneList.TabIndex = 8;
            // 
            // crispy
            // 
            this.crispy.AutoSize = true;
            this.crispy.Checked = true;
            this.crispy.Location = new System.Drawing.Point(6, 66);
            this.crispy.Name = "crispy";
            this.crispy.Size = new System.Drawing.Size(53, 17);
            this.crispy.TabIndex = 9;
            this.crispy.TabStop = true;
            this.crispy.Text = "Crispy";
            this.crispy.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.infoBox);
            this.groupBox1.Controls.Add(this.soggy);
            this.groupBox1.Controls.Add(this.banana);
            this.groupBox1.Controls.Add(this.browned);
            this.groupBox1.Controls.Add(this.numOfFlapjacks);
            this.groupBox1.Controls.Add(this.nextLumberjackButton);
            this.groupBox1.Controls.Add(this.crispy);
            this.groupBox1.Controls.Add(this.addFlapjacksButton);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(129, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 317);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Feed a Lumberjack";
            // 
            // soggy
            // 
            this.soggy.AutoSize = true;
            this.soggy.Location = new System.Drawing.Point(6, 89);
            this.soggy.Name = "soggy";
            this.soggy.Size = new System.Drawing.Size(55, 17);
            this.soggy.TabIndex = 12;
            this.soggy.Text = "Soggy";
            this.soggy.UseVisualStyleBackColor = true;
            // 
            // banana
            // 
            this.banana.AutoSize = true;
            this.banana.Location = new System.Drawing.Point(6, 135);
            this.banana.Name = "banana";
            this.banana.Size = new System.Drawing.Size(62, 17);
            this.banana.TabIndex = 11;
            this.banana.Text = "Banana";
            this.banana.UseVisualStyleBackColor = true;
            // 
            // browned
            // 
            this.browned.AutoSize = true;
            this.browned.Location = new System.Drawing.Point(6, 112);
            this.browned.Name = "browned";
            this.browned.Size = new System.Drawing.Size(67, 17);
            this.browned.TabIndex = 10;
            this.browned.Text = "Browned";
            this.browned.UseVisualStyleBackColor = true;
            // 
            // infoBox
            // 
            this.infoBox.Enabled = false;
            this.infoBox.Location = new System.Drawing.Point(6, 198);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(120, 85);
            this.infoBox.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 441);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.laneList);
            this.Controls.Add(this.addLumberjackButton);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numOfFlapjacks)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.NumericUpDown numOfFlapjacks;
        private System.Windows.Forms.Button addLumberjackButton;
        private System.Windows.Forms.Button nextLumberjackButton;
        private System.Windows.Forms.Button addFlapjacksButton;
        private System.Windows.Forms.ListBox laneList;
        private System.Windows.Forms.RadioButton crispy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton soggy;
        private System.Windows.Forms.RadioButton banana;
        private System.Windows.Forms.RadioButton browned;
        private System.Windows.Forms.TextBox infoBox;
    }
}

