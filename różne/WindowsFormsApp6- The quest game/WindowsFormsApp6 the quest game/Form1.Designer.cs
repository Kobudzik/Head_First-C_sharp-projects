namespace WindowsFormsApp6_the_quest_game
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.moveLeftButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveRightButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.attackLeftButton = new System.Windows.Forms.Button();
            this.attackRightButton = new System.Windows.Forms.Button();
            this.attackUpButton = new System.Windows.Forms.Button();
            this.attackDownButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ghoulHitPointsLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ghostHitPointsLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.batHitPointsLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.playerHitPointsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.batInGamePictureBox = new System.Windows.Forms.PictureBox();
            this.ghoulInGamePictureBox = new System.Windows.Forms.PictureBox();
            this.bowInGamePictureBox = new System.Windows.Forms.PictureBox();
            this.ghostInGamePictureBox = new System.Windows.Forms.PictureBox();
            this.maceInGamePictureBox = new System.Windows.Forms.PictureBox();
            this.redPotionInGamePictureBox = new System.Windows.Forms.PictureBox();
            this.playerPictureBox = new System.Windows.Forms.PictureBox();
            this.bluePotionInGamePictureBox = new System.Windows.Forms.PictureBox();
            this.swordInGamePictureBox = new System.Windows.Forms.PictureBox();
            this.maceInventoryPictureBox = new System.Windows.Forms.PictureBox();
            this.bowInventoryPictureBox = new System.Windows.Forms.PictureBox();
            this.bluePotionInventoryPictureBox = new System.Windows.Forms.PictureBox();
            this.swordInventoryPictureBox = new System.Windows.Forms.PictureBox();
            this.redPotionInventoryPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.batInGamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghoulInGamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bowInGamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghostInGamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maceInGamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPotionInGamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluePotionInGamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swordInGamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maceInventoryPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bowInventoryPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluePotionInventoryPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swordInventoryPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPotionInventoryPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.moveLeftButton);
            this.groupBox1.Controls.Add(this.moveUpButton);
            this.groupBox1.Controls.Add(this.moveRightButton);
            this.groupBox1.Controls.Add(this.moveDownButton);
            this.groupBox1.Location = new System.Drawing.Point(344, 306);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(105, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Move";
            // 
            // moveLeftButton
            // 
            this.moveLeftButton.Location = new System.Drawing.Point(8, 33);
            this.moveLeftButton.Name = "moveLeftButton";
            this.moveLeftButton.Size = new System.Drawing.Size(27, 27);
            this.moveLeftButton.TabIndex = 3;
            this.moveLeftButton.Text = "←";
            this.moveLeftButton.UseVisualStyleBackColor = true;
            this.moveLeftButton.Click += new System.EventHandler(this.moveLeftButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Location = new System.Drawing.Point(41, 13);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(27, 27);
            this.moveUpButton.TabIndex = 2;
            this.moveUpButton.Text = "↑";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // moveRightButton
            // 
            this.moveRightButton.Location = new System.Drawing.Point(74, 33);
            this.moveRightButton.Name = "moveRightButton";
            this.moveRightButton.Size = new System.Drawing.Size(27, 27);
            this.moveRightButton.TabIndex = 1;
            this.moveRightButton.Text = "→";
            this.moveRightButton.UseVisualStyleBackColor = true;
            this.moveRightButton.Click += new System.EventHandler(this.moveRightButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Location = new System.Drawing.Point(41, 50);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(27, 27);
            this.moveDownButton.TabIndex = 0;
            this.moveDownButton.Text = "↓";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.attackLeftButton);
            this.groupBox2.Controls.Add(this.attackRightButton);
            this.groupBox2.Controls.Add(this.attackUpButton);
            this.groupBox2.Controls.Add(this.attackDownButton);
            this.groupBox2.Location = new System.Drawing.Point(447, 306);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attack";
            // 
            // attackLeftButton
            // 
            this.attackLeftButton.Location = new System.Drawing.Point(8, 33);
            this.attackLeftButton.Name = "attackLeftButton";
            this.attackLeftButton.Size = new System.Drawing.Size(27, 27);
            this.attackLeftButton.TabIndex = 7;
            this.attackLeftButton.Text = "←";
            this.attackLeftButton.UseVisualStyleBackColor = true;
            this.attackLeftButton.Click += new System.EventHandler(this.attackLeftButton_Click);
            // 
            // attackRightButton
            // 
            this.attackRightButton.Location = new System.Drawing.Point(74, 33);
            this.attackRightButton.Name = "attackRightButton";
            this.attackRightButton.Size = new System.Drawing.Size(27, 27);
            this.attackRightButton.TabIndex = 5;
            this.attackRightButton.Text = "→";
            this.attackRightButton.UseVisualStyleBackColor = true;
            this.attackRightButton.Click += new System.EventHandler(this.attackRightButton_Click);
            // 
            // attackUpButton
            // 
            this.attackUpButton.Location = new System.Drawing.Point(41, 13);
            this.attackUpButton.Name = "attackUpButton";
            this.attackUpButton.Size = new System.Drawing.Size(27, 27);
            this.attackUpButton.TabIndex = 6;
            this.attackUpButton.Text = "↑";
            this.attackUpButton.UseVisualStyleBackColor = true;
            this.attackUpButton.Click += new System.EventHandler(this.attackUpButton_Click);
            // 
            // attackDownButton
            // 
            this.attackDownButton.Location = new System.Drawing.Point(41, 50);
            this.attackDownButton.Name = "attackDownButton";
            this.attackDownButton.Size = new System.Drawing.Size(27, 27);
            this.attackDownButton.TabIndex = 4;
            this.attackDownButton.Text = "↓";
            this.attackDownButton.UseVisualStyleBackColor = true;
            this.attackDownButton.Click += new System.EventHandler(this.attackDownButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63F));
            this.tableLayoutPanel1.Controls.Add(this.ghoulHitPointsLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ghostHitPointsLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.batHitPointsLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.playerHitPointsLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(410, 238);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(159, 75);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // ghoulHitPointsLabel
            // 
            this.ghoulHitPointsLabel.AutoSize = true;
            this.ghoulHitPointsLabel.Location = new System.Drawing.Point(61, 54);
            this.ghoulHitPointsLabel.Name = "ghoulHitPointsLabel";
            this.ghoulHitPointsLabel.Size = new System.Drawing.Size(75, 13);
            this.ghoulHitPointsLabel.TabIndex = 7;
            this.ghoulHitPointsLabel.Text = "ghoulHitPoints";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ghoul";
            // 
            // ghostHitPointsLabel
            // 
            this.ghostHitPointsLabel.AutoSize = true;
            this.ghostHitPointsLabel.Location = new System.Drawing.Point(61, 34);
            this.ghostHitPointsLabel.Name = "ghostHitPointsLabel";
            this.ghostHitPointsLabel.Size = new System.Drawing.Size(75, 13);
            this.ghostHitPointsLabel.TabIndex = 5;
            this.ghostHitPointsLabel.Text = "ghostHitPoints";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ghost";
            // 
            // batHitPointsLabel
            // 
            this.batHitPointsLabel.AutoSize = true;
            this.batHitPointsLabel.Location = new System.Drawing.Point(61, 17);
            this.batHitPointsLabel.Name = "batHitPointsLabel";
            this.batHitPointsLabel.Size = new System.Drawing.Size(64, 13);
            this.batHitPointsLabel.TabIndex = 3;
            this.batHitPointsLabel.Text = "batHitPoints";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bat";
            // 
            // playerHitPointsLabel
            // 
            this.playerHitPointsLabel.AutoSize = true;
            this.playerHitPointsLabel.Location = new System.Drawing.Point(61, 0);
            this.playerHitPointsLabel.Name = "playerHitPointsLabel";
            this.playerHitPointsLabel.Size = new System.Drawing.Size(77, 13);
            this.playerHitPointsLabel.TabIndex = 1;
            this.playerHitPointsLabel.Text = "playerHitPoints";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player";
            // 
            // batInGamePictureBox
            // 
            this.batInGamePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.batInGamePictureBox.Image = global::WindowsFormsApp6_the_quest_game.Properties.Resources.bat;
            this.batInGamePictureBox.Location = new System.Drawing.Point(86, 57);
            this.batInGamePictureBox.Name = "batInGamePictureBox";
            this.batInGamePictureBox.Size = new System.Drawing.Size(30, 30);
            this.batInGamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.batInGamePictureBox.TabIndex = 3;
            this.batInGamePictureBox.TabStop = false;
            this.batInGamePictureBox.Visible = false;
            // 
            // ghoulInGamePictureBox
            // 
            this.ghoulInGamePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.ghoulInGamePictureBox.Image = global::WindowsFormsApp6_the_quest_game.Properties.Resources.ghoul;
            this.ghoulInGamePictureBox.Location = new System.Drawing.Point(346, 57);
            this.ghoulInGamePictureBox.Name = "ghoulInGamePictureBox";
            this.ghoulInGamePictureBox.Size = new System.Drawing.Size(30, 30);
            this.ghoulInGamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ghoulInGamePictureBox.TabIndex = 4;
            this.ghoulInGamePictureBox.TabStop = false;
            this.ghoulInGamePictureBox.Visible = false;
            // 
            // bowInGamePictureBox
            // 
            this.bowInGamePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.bowInGamePictureBox.Image = global::WindowsFormsApp6_the_quest_game.Properties.Resources.bow;
            this.bowInGamePictureBox.Location = new System.Drawing.Point(122, 57);
            this.bowInGamePictureBox.Name = "bowInGamePictureBox";
            this.bowInGamePictureBox.Size = new System.Drawing.Size(30, 30);
            this.bowInGamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bowInGamePictureBox.TabIndex = 4;
            this.bowInGamePictureBox.TabStop = false;
            this.bowInGamePictureBox.Visible = false;
            // 
            // ghostInGamePictureBox
            // 
            this.ghostInGamePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.ghostInGamePictureBox.Image = global::WindowsFormsApp6_the_quest_game.Properties.Resources.ghost;
            this.ghostInGamePictureBox.Location = new System.Drawing.Point(178, 57);
            this.ghostInGamePictureBox.Name = "ghostInGamePictureBox";
            this.ghostInGamePictureBox.Size = new System.Drawing.Size(30, 30);
            this.ghostInGamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ghostInGamePictureBox.TabIndex = 5;
            this.ghostInGamePictureBox.TabStop = false;
            this.ghostInGamePictureBox.Visible = false;
            // 
            // maceInGamePictureBox
            // 
            this.maceInGamePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.maceInGamePictureBox.Image = global::WindowsFormsApp6_the_quest_game.Properties.Resources.mace;
            this.maceInGamePictureBox.Location = new System.Drawing.Point(465, 57);
            this.maceInGamePictureBox.Name = "maceInGamePictureBox";
            this.maceInGamePictureBox.Size = new System.Drawing.Size(30, 30);
            this.maceInGamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.maceInGamePictureBox.TabIndex = 6;
            this.maceInGamePictureBox.TabStop = false;
            this.maceInGamePictureBox.Visible = false;
            // 
            // redPotionInGamePictureBox
            // 
            this.redPotionInGamePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.redPotionInGamePictureBox.Image = global::WindowsFormsApp6_the_quest_game.Properties.Resources.potion_red;
            this.redPotionInGamePictureBox.Location = new System.Drawing.Point(402, 57);
            this.redPotionInGamePictureBox.Name = "redPotionInGamePictureBox";
            this.redPotionInGamePictureBox.Size = new System.Drawing.Size(30, 30);
            this.redPotionInGamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redPotionInGamePictureBox.TabIndex = 7;
            this.redPotionInGamePictureBox.TabStop = false;
            this.redPotionInGamePictureBox.Visible = false;
            // 
            // playerPictureBox
            // 
            this.playerPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.playerPictureBox.Image = global::WindowsFormsApp6_the_quest_game.Properties.Resources.player;
            this.playerPictureBox.Location = new System.Drawing.Point(234, 57);
            this.playerPictureBox.Name = "playerPictureBox";
            this.playerPictureBox.Size = new System.Drawing.Size(30, 30);
            this.playerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerPictureBox.TabIndex = 7;
            this.playerPictureBox.TabStop = false;
            // 
            // bluePotionInGamePictureBox
            // 
            this.bluePotionInGamePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.bluePotionInGamePictureBox.Image = global::WindowsFormsApp6_the_quest_game.Properties.Resources.potion_blue;
            this.bluePotionInGamePictureBox.Location = new System.Drawing.Point(290, 57);
            this.bluePotionInGamePictureBox.Name = "bluePotionInGamePictureBox";
            this.bluePotionInGamePictureBox.Size = new System.Drawing.Size(30, 30);
            this.bluePotionInGamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bluePotionInGamePictureBox.TabIndex = 8;
            this.bluePotionInGamePictureBox.TabStop = false;
            this.bluePotionInGamePictureBox.Visible = false;
            // 
            // swordInGamePictureBox
            // 
            this.swordInGamePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.swordInGamePictureBox.Image = global::WindowsFormsApp6_the_quest_game.Properties.Resources.sword;
            this.swordInGamePictureBox.Location = new System.Drawing.Point(90, 113);
            this.swordInGamePictureBox.Name = "swordInGamePictureBox";
            this.swordInGamePictureBox.Size = new System.Drawing.Size(30, 30);
            this.swordInGamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.swordInGamePictureBox.TabIndex = 9;
            this.swordInGamePictureBox.TabStop = false;
            this.swordInGamePictureBox.Visible = false;
            // 
            // maceInventoryPictureBox
            // 
            this.maceInventoryPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.maceInventoryPictureBox.Image = global::WindowsFormsApp6_the_quest_game.Properties.Resources.mace;
            this.maceInventoryPictureBox.Location = new System.Drawing.Point(182, 333);
            this.maceInventoryPictureBox.Name = "maceInventoryPictureBox";
            this.maceInventoryPictureBox.Size = new System.Drawing.Size(50, 50);
            this.maceInventoryPictureBox.TabIndex = 12;
            this.maceInventoryPictureBox.TabStop = false;
            this.maceInventoryPictureBox.Visible = false;
            this.maceInventoryPictureBox.Click += new System.EventHandler(this.macePictureBox_Click);
            // 
            // bowInventoryPictureBox
            // 
            this.bowInventoryPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.bowInventoryPictureBox.Image = global::WindowsFormsApp6_the_quest_game.Properties.Resources.bow;
            this.bowInventoryPictureBox.Location = new System.Drawing.Point(126, 333);
            this.bowInventoryPictureBox.Name = "bowInventoryPictureBox";
            this.bowInventoryPictureBox.Size = new System.Drawing.Size(50, 50);
            this.bowInventoryPictureBox.TabIndex = 11;
            this.bowInventoryPictureBox.TabStop = false;
            this.bowInventoryPictureBox.Visible = false;
            this.bowInventoryPictureBox.Click += new System.EventHandler(this.bowPictureBox_Click);
            // 
            // bluePotionInventoryPictureBox
            // 
            this.bluePotionInventoryPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.bluePotionInventoryPictureBox.Image = global::WindowsFormsApp6_the_quest_game.Properties.Resources.potion_blue;
            this.bluePotionInventoryPictureBox.Location = new System.Drawing.Point(238, 333);
            this.bluePotionInventoryPictureBox.Name = "bluePotionInventoryPictureBox";
            this.bluePotionInventoryPictureBox.Size = new System.Drawing.Size(50, 50);
            this.bluePotionInventoryPictureBox.TabIndex = 13;
            this.bluePotionInventoryPictureBox.TabStop = false;
            this.bluePotionInventoryPictureBox.Visible = false;
            this.bluePotionInventoryPictureBox.Click += new System.EventHandler(this.bluePotionPictureBox_Click);
            // 
            // swordInventoryPictureBox
            // 
            this.swordInventoryPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.swordInventoryPictureBox.Image = global::WindowsFormsApp6_the_quest_game.Properties.Resources.sword;
            this.swordInventoryPictureBox.Location = new System.Drawing.Point(70, 333);
            this.swordInventoryPictureBox.Name = "swordInventoryPictureBox";
            this.swordInventoryPictureBox.Size = new System.Drawing.Size(50, 50);
            this.swordInventoryPictureBox.TabIndex = 10;
            this.swordInventoryPictureBox.TabStop = false;
            this.swordInventoryPictureBox.Visible = false;
            this.swordInventoryPictureBox.Click += new System.EventHandler(this.swordPictureBox_Click);
            // 
            // redPotionInventoryPictureBox
            // 
            this.redPotionInventoryPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.redPotionInventoryPictureBox.Image = global::WindowsFormsApp6_the_quest_game.Properties.Resources.potion_red;
            this.redPotionInventoryPictureBox.Location = new System.Drawing.Point(292, 333);
            this.redPotionInventoryPictureBox.Name = "redPotionInventoryPictureBox";
            this.redPotionInventoryPictureBox.Size = new System.Drawing.Size(50, 50);
            this.redPotionInventoryPictureBox.TabIndex = 14;
            this.redPotionInventoryPictureBox.TabStop = false;
            this.redPotionInventoryPictureBox.Visible = false;
            this.redPotionInventoryPictureBox.Click += new System.EventHandler(this.redPotionPictureBox_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::WindowsFormsApp6_the_quest_game.Properties.Resources.dungeon600x400;
            this.ClientSize = new System.Drawing.Size(598, 397);
            this.Controls.Add(this.redPotionInventoryPictureBox);
            this.Controls.Add(this.bluePotionInventoryPictureBox);
            this.Controls.Add(this.maceInventoryPictureBox);
            this.Controls.Add(this.bowInventoryPictureBox);
            this.Controls.Add(this.swordInventoryPictureBox);
            this.Controls.Add(this.playerPictureBox);
            this.Controls.Add(this.bluePotionInGamePictureBox);
            this.Controls.Add(this.redPotionInGamePictureBox);
            this.Controls.Add(this.ghostInGamePictureBox);
            this.Controls.Add(this.ghoulInGamePictureBox);
            this.Controls.Add(this.batInGamePictureBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.swordInGamePictureBox);
            this.Controls.Add(this.maceInGamePictureBox);
            this.Controls.Add(this.bowInGamePictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.batInGamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghoulInGamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bowInGamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghostInGamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maceInGamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPotionInGamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluePotionInGamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swordInGamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maceInventoryPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bowInventoryPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluePotionInventoryPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swordInventoryPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPotionInventoryPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveRightButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveLeftButton;
        private System.Windows.Forms.Button attackLeftButton;
        private System.Windows.Forms.Button attackRightButton;
        private System.Windows.Forms.Button attackUpButton;
        private System.Windows.Forms.Button attackDownButton;
        private System.Windows.Forms.PictureBox batInGamePictureBox;
        private System.Windows.Forms.PictureBox ghoulInGamePictureBox;
        private System.Windows.Forms.PictureBox bowInGamePictureBox;
        private System.Windows.Forms.PictureBox ghostInGamePictureBox;
        private System.Windows.Forms.PictureBox maceInGamePictureBox;
        private System.Windows.Forms.PictureBox redPotionInGamePictureBox;
        private System.Windows.Forms.PictureBox playerPictureBox;
        private System.Windows.Forms.PictureBox bluePotionInGamePictureBox;
        private System.Windows.Forms.PictureBox swordInGamePictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ghoulHitPointsLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label ghostHitPointsLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label batHitPointsLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label playerHitPointsLabel;
        private System.Windows.Forms.PictureBox maceInventoryPictureBox;
        private System.Windows.Forms.PictureBox bowInventoryPictureBox;
        private System.Windows.Forms.PictureBox bluePotionInventoryPictureBox;
        private System.Windows.Forms.PictureBox swordInventoryPictureBox;
        private System.Windows.Forms.PictureBox redPotionInventoryPictureBox;
    }
}

