namespace Real_Estate_WindowsForms.TablesForms
{
    partial class Users
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
            this.IDtextBox1 = new System.Windows.Forms.TextBox();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.SearchBTN1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ClearColumnsFieldsButton = new System.Windows.Forms.Button();
            this.UpdateTableBTN = new System.Windows.Forms.Button();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TableDataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.CodeTextBox = new System.Windows.Forms.TextBox();
            this.UserPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGridView)).BeginInit();
            this.ColumnsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // IDtextBox1
            // 
            this.IDtextBox1.Location = new System.Drawing.Point(60, 26);
            this.IDtextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IDtextBox1.Name = "IDtextBox1";
            this.IDtextBox1.Size = new System.Drawing.Size(61, 22);
            this.IDtextBox1.TabIndex = 11;
            this.IDtextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.INTtextBox_KeyPress);
            // 
            // UserPanel
            // 
            this.UserPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserPanel.Controls.Add(this.IDtextBox1);
            this.UserPanel.Controls.Add(this.label5);
            this.UserPanel.Controls.Add(this.SearchBTN1);
            this.UserPanel.Controls.Add(this.label4);
            this.UserPanel.Location = new System.Drawing.Point(387, 390);
            this.UserPanel.Margin = new System.Windows.Forms.Padding(4);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(231, 57);
            this.UserPanel.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(16, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Поиск записи по коду";
            // 
            // SearchBTN1
            // 
            this.SearchBTN1.Location = new System.Drawing.Point(125, 26);
            this.SearchBTN1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchBTN1.Name = "SearchBTN1";
            this.SearchBTN1.Size = new System.Drawing.Size(88, 23);
            this.SearchBTN1.TabIndex = 8;
            this.SearchBTN1.Text = "Поиск";
            this.SearchBTN1.UseVisualStyleBackColor = true;
            this.SearchBTN1.Click += new System.EventHandler(this.SearchBTN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(16, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Код";
            // 
            // ClearColumnsFieldsButton
            // 
            this.ClearColumnsFieldsButton.Location = new System.Drawing.Point(165, 390);
            this.ClearColumnsFieldsButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearColumnsFieldsButton.Name = "ClearColumnsFieldsButton";
            this.ClearColumnsFieldsButton.Size = new System.Drawing.Size(212, 25);
            this.ClearColumnsFieldsButton.TabIndex = 22;
            this.ClearColumnsFieldsButton.Text = "Очистить поля заполнения";
            this.ClearColumnsFieldsButton.UseVisualStyleBackColor = true;
            this.ClearColumnsFieldsButton.Click += new System.EventHandler(this.ClearColumnsFieldsButton_Click);
            // 
            // UpdateTableBTN
            // 
            this.UpdateTableBTN.Location = new System.Drawing.Point(4, 390);
            this.UpdateTableBTN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UpdateTableBTN.Name = "UpdateTableBTN";
            this.UpdateTableBTN.Size = new System.Drawing.Size(157, 26);
            this.UpdateTableBTN.TabIndex = 21;
            this.UpdateTableBTN.Text = "Обновить таблицу";
            this.UpdateTableBTN.UseVisualStyleBackColor = true;
            this.UpdateTableBTN.Click += new System.EventHandler(this.UpdateTableBTN_Click);
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(20, 144);
            this.ExecuteButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(152, 44);
            this.ExecuteButton.TabIndex = 11;
            this.ExecuteButton.Text = "Выполнить";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.Execute_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(17, 112);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(132, 20);
            this.radioButton3.TabIndex = 60;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Удалить запись";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(17, 79);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(142, 20);
            this.radioButton2.TabIndex = 59;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Изменить запись";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 44);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(140, 20);
            this.radioButton1.TabIndex = 58;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Добавить запись";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(17, 11);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(154, 23);
            this.label16.TabIndex = 0;
            this.label16.Text = "Работа с данными";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.ExecuteButton);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Location = new System.Drawing.Point(427, 455);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 203);
            this.panel1.TabIndex = 32;
            // 
            // TableDataGridView
            // 
            this.TableDataGridView.AllowUserToAddRows = false;
            this.TableDataGridView.AllowUserToDeleteRows = false;
            this.TableDataGridView.AllowUserToResizeRows = false;
            this.TableDataGridView.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.TableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableDataGridView.Location = new System.Drawing.Point(0, 0);
            this.TableDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.TableDataGridView.Name = "TableDataGridView";
            this.TableDataGridView.ReadOnly = true;
            this.TableDataGridView.RowHeadersWidth = 51;
            this.TableDataGridView.Size = new System.Drawing.Size(628, 383);
            this.TableDataGridView.TabIndex = 17;
            this.TableDataGridView.SelectionChanged += new System.EventHandler(this.TableDataGridView_SelectionChanged);
            // 
            // ColumnsPanel
            // 
            this.ColumnsPanel.BackColor = System.Drawing.Color.PowderBlue;
            this.ColumnsPanel.Controls.Add(this.label1);
            this.ColumnsPanel.Controls.Add(this.PasswordTextBox);
            this.ColumnsPanel.Controls.Add(this.pictureBox2);
            this.ColumnsPanel.Controls.Add(this.label2);
            this.ColumnsPanel.Controls.Add(this.LoginTextBox);
            this.ColumnsPanel.Controls.Add(this.pictureBox9);
            this.ColumnsPanel.Controls.Add(this.pictureBox8);
            this.ColumnsPanel.Controls.Add(this.pictureBox7);
            this.ColumnsPanel.Controls.Add(this.pictureBox6);
            this.ColumnsPanel.Controls.Add(this.pictureBox1);
            this.ColumnsPanel.Controls.Add(this.label17);
            this.ColumnsPanel.Controls.Add(this.CodeTextBox);
            this.ColumnsPanel.Location = new System.Drawing.Point(9, 455);
            this.ColumnsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ColumnsPanel.Name = "ColumnsPanel";
            this.ColumnsPanel.Size = new System.Drawing.Size(409, 164);
            this.ColumnsPanel.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(221, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 66;
            this.label1.Text = "Код (Code)";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(25, 113);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(189, 22);
            this.PasswordTextBox.TabIndex = 65;
            this.PasswordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginPasswordTextBox_KeyPress);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pictureBox2.Location = new System.Drawing.Point(12, 144);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(356, 6);
            this.pictureBox2.TabIndex = 64;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(221, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 18);
            this.label2.TabIndex = 63;
            this.label2.Text = "Пароль (Password)";
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(25, 69);
            this.LoginTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(189, 22);
            this.LoginTextBox.TabIndex = 61;
            this.LoginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginPasswordTextBox_KeyPress);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pictureBox9.Location = new System.Drawing.Point(11, 12);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(7, 135);
            this.pictureBox9.TabIndex = 50;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pictureBox8.Location = new System.Drawing.Point(13, 12);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(356, 6);
            this.pictureBox8.TabIndex = 49;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pictureBox7.Location = new System.Drawing.Point(363, 12);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(7, 138);
            this.pictureBox7.TabIndex = 48;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pictureBox6.Location = new System.Drawing.Point(12, 100);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(356, 6);
            this.pictureBox6.TabIndex = 47;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pictureBox1.Location = new System.Drawing.Point(13, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 6);
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(221, 73);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 18);
            this.label17.TabIndex = 31;
            this.label17.Text = "Логин (Login)";
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.Location = new System.Drawing.Point(25, 26);
            this.CodeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(189, 22);
            this.CodeTextBox.TabIndex = 30;
            this.CodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.INTtextBox_KeyPress);
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 663);
            this.Controls.Add(this.ColumnsPanel);
            this.Controls.Add(this.UserPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ClearColumnsFieldsButton);
            this.Controls.Add(this.UpdateTableBTN);
            this.Controls.Add(this.TableDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Users";
            this.ShowIcon = false;
            this.Text = "Users";
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGridView)).EndInit();
            this.ColumnsPanel.ResumeLayout(false);
            this.ColumnsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox IDtextBox1;
        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SearchBTN1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ClearColumnsFieldsButton;
        private System.Windows.Forms.Button UpdateTableBTN;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView TableDataGridView;
        private System.Windows.Forms.Panel ColumnsPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox CodeTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}