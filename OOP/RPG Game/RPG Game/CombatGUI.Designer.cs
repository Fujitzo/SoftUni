namespace RPG_Game
{
    partial class CombatGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.partyActionAttack = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.partyActionSkill = new System.Windows.Forms.CheckBox();
            this.comboSkill = new System.Windows.Forms.ComboBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.attackButton = new System.Windows.Forms.Button();
            this.Party1 = new System.Windows.Forms.PictureBox();
            this.Enemy1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Party2 = new System.Windows.Forms.PictureBox();
            this.enemyAttackTimer = new System.Windows.Forms.Timer(this.components);
            this.systemSleepTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Party1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Party2)).BeginInit();
            this.SuspendLayout();
            // 
            // partyActionAttack
            // 
            this.partyActionAttack.AutoSize = true;
            this.partyActionAttack.Location = new System.Drawing.Point(12, 285);
            this.partyActionAttack.Name = "partyActionAttack";
            this.partyActionAttack.Size = new System.Drawing.Size(57, 17);
            this.partyActionAttack.TabIndex = 0;
            this.partyActionAttack.Text = "Attack";
            this.partyActionAttack.UseVisualStyleBackColor = true;
            this.partyActionAttack.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 309);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // partyActionSkill
            // 
            this.partyActionSkill.AutoSize = true;
            this.partyActionSkill.Location = new System.Drawing.Point(12, 333);
            this.partyActionSkill.Name = "partyActionSkill";
            this.partyActionSkill.Size = new System.Drawing.Size(45, 17);
            this.partyActionSkill.TabIndex = 2;
            this.partyActionSkill.Text = "Skill";
            this.partyActionSkill.UseVisualStyleBackColor = true;
            // 
            // comboSkill
            // 
            this.comboSkill.FormattingEnabled = true;
            this.comboSkill.Location = new System.Drawing.Point(12, 371);
            this.comboSkill.Name = "comboSkill";
            this.comboSkill.Size = new System.Drawing.Size(121, 21);
            this.comboSkill.TabIndex = 3;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(174, 268);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(455, 82);
            this.textBox.TabIndex = 4;
            this.textBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // attackButton
            // 
            this.attackButton.Location = new System.Drawing.Point(288, 371);
            this.attackButton.Name = "attackButton";
            this.attackButton.Size = new System.Drawing.Size(225, 48);
            this.attackButton.TabIndex = 5;
            this.attackButton.Text = "Attack";
            this.attackButton.UseVisualStyleBackColor = true;
            this.attackButton.Click += new System.EventHandler(this.attackButton_Click);
            // 
            // Party1
            // 
            this.Party1.Location = new System.Drawing.Point(33, 28);
            this.Party1.Name = "Party1";
            this.Party1.Size = new System.Drawing.Size(100, 50);
            this.Party1.TabIndex = 6;
            this.Party1.TabStop = false;
            // 
            // Enemy1
            // 
            this.Enemy1.Location = new System.Drawing.Point(528, 27);
            this.Enemy1.Name = "Enemy1";
            this.Enemy1.Size = new System.Drawing.Size(100, 50);
            this.Enemy1.TabIndex = 7;
            this.Enemy1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(528, 107);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 50);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // Party2
            // 
            this.Party2.Location = new System.Drawing.Point(133, 107);
            this.Party2.Name = "Party2";
            this.Party2.Size = new System.Drawing.Size(100, 50);
            this.Party2.TabIndex = 9;
            this.Party2.TabStop = false;
            // 
            // enemyAttackTimer
            // 
            this.enemyAttackTimer.Tick += new System.EventHandler(this.enemyAttackTimer_Tick);
            // 
            // systemSleepTimer
            // 
            this.systemSleepTimer.Interval = 1000;
            this.systemSleepTimer.Tick += new System.EventHandler(this.SleepTick);
            // 
            // CombatGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 431);
            this.Controls.Add(this.Party2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.Enemy1);
            this.Controls.Add(this.Party1);
            this.Controls.Add(this.attackButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.comboSkill);
            this.Controls.Add(this.partyActionSkill);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.partyActionAttack);
            this.Name = "CombatGUI";
            this.Text = "CombatGUI";
            this.Load += new System.EventHandler(this.CombatGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Party1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Party2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox partyActionAttack;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox partyActionSkill;
        private System.Windows.Forms.ComboBox comboSkill;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button attackButton;
        private System.Windows.Forms.PictureBox Party1;
        private System.Windows.Forms.PictureBox Enemy1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox Party2;
        private System.Windows.Forms.Timer enemyAttackTimer;
        private System.Windows.Forms.Timer systemSleepTimer;
    }
}