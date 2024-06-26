namespace Real_Estate_WindowsForms
{
    partial class StartForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.ToDiagram = new System.Windows.Forms.Button();
            this.WelcomeText = new System.Windows.Forms.Label();
            this.ToUsers = new System.Windows.Forms.Button();
            this.ToTypeOfRealEstate = new System.Windows.Forms.Button();
            this.ToProffessions = new System.Windows.Forms.Button();
            this.ToPerson = new System.Windows.Forms.Button();
            this.ToEmployees = new System.Windows.Forms.Button();
            this.ToDeals = new System.Windows.Forms.Button();
            this.ToRealEstate = new System.Windows.Forms.Button();
            this.LoginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPanel
            // 
            this.LoginPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginPanel.Controls.Add(this.RegistrationButton);
            this.LoginPanel.Controls.Add(this.LoginButton);
            this.LoginPanel.Controls.Add(this.PasswordTextBox);
            this.LoginPanel.Controls.Add(this.LoginTextBox);
            this.LoginPanel.Location = new System.Drawing.Point(-1, 0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(231, 397);
            this.LoginPanel.TabIndex = 5;
            this.LoginPanel.VisibleChanged += new System.EventHandler(this.LoginPanel_VisibleChanged);
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegistrationButton.Location = new System.Drawing.Point(49, 199);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(133, 38);
            this.RegistrationButton.TabIndex = 8;
            this.RegistrationButton.Text = "Зарегистрироваться";
            this.RegistrationButton.UseVisualStyleBackColor = true;
            this.RegistrationButton.Click += new System.EventHandler(this.RegistrationButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginButton.Location = new System.Drawing.Point(49, 155);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(133, 38);
            this.LoginButton.TabIndex = 7;
            this.LoginButton.Text = "Войти";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordTextBox.Location = new System.Drawing.Point(49, 106);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(133, 26);
            this.PasswordTextBox.TabIndex = 6;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginTextBox.Location = new System.Drawing.Point(49, 56);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(133, 26);
            this.LoginTextBox.TabIndex = 5;
            this.LoginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginTextBox_KeyPress);
            // 
            // ToDiagram
            // 
            this.ToDiagram.Location = new System.Drawing.Point(7, 342);
            this.ToDiagram.Name = "ToDiagram";
            this.ToDiagram.Size = new System.Drawing.Size(109, 42);
            this.ToDiagram.TabIndex = 17;
            this.ToDiagram.Text = "Диаграмма типов недвижимости";
            this.ToDiagram.UseVisualStyleBackColor = true;
            this.ToDiagram.Click += new System.EventHandler(this.ToDiagram_Click);
            // 
            // WelcomeText
            // 
            this.WelcomeText.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WelcomeText.Location = new System.Drawing.Point(16, -14);
            this.WelcomeText.Name = "WelcomeText";
            this.WelcomeText.Size = new System.Drawing.Size(199, 103);
            this.WelcomeText.TabIndex = 16;
            this.WelcomeText.Text = "Выберите таблицу для работы";
            this.WelcomeText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ToUsers
            // 
            this.ToUsers.Enabled = false;
            this.ToUsers.Location = new System.Drawing.Point(123, 342);
            this.ToUsers.Name = "ToUsers";
            this.ToUsers.Size = new System.Drawing.Size(97, 42);
            this.ToUsers.TabIndex = 15;
            this.ToUsers.Text = "Пользователи (Users)";
            this.ToUsers.UseVisualStyleBackColor = true;
            this.ToUsers.Click += new System.EventHandler(this.ToUsers_Click);
            // 
            // ToTypeOfRealEstate
            // 
            this.ToTypeOfRealEstate.Location = new System.Drawing.Point(51, 242);
            this.ToTypeOfRealEstate.Name = "ToTypeOfRealEstate";
            this.ToTypeOfRealEstate.Size = new System.Drawing.Size(126, 37);
            this.ToTypeOfRealEstate.TabIndex = 14;
            this.ToTypeOfRealEstate.Text = "Типы недвижимости (TypeOfRealEstate)";
            this.ToTypeOfRealEstate.UseVisualStyleBackColor = true;
            this.ToTypeOfRealEstate.Click += new System.EventHandler(this.ToTypeOfRealEstate_Click);
            // 
            // ToProffessions
            // 
            this.ToProffessions.Location = new System.Drawing.Point(51, 156);
            this.ToProffessions.Name = "ToProffessions";
            this.ToProffessions.Size = new System.Drawing.Size(126, 37);
            this.ToProffessions.TabIndex = 13;
            this.ToProffessions.Text = "Профессии (Proffessions)";
            this.ToProffessions.UseVisualStyleBackColor = true;
            this.ToProffessions.Click += new System.EventHandler(this.ToProffessions_Click);
            // 
            // ToPerson
            // 
            this.ToPerson.Location = new System.Drawing.Point(51, 199);
            this.ToPerson.Name = "ToPerson";
            this.ToPerson.Size = new System.Drawing.Size(126, 37);
            this.ToPerson.TabIndex = 12;
            this.ToPerson.Text = "Человек (Person)";
            this.ToPerson.UseVisualStyleBackColor = true;
            this.ToPerson.Click += new System.EventHandler(this.ToPerson_Click);
            // 
            // ToEmployees
            // 
            this.ToEmployees.Location = new System.Drawing.Point(51, 285);
            this.ToEmployees.Name = "ToEmployees";
            this.ToEmployees.Size = new System.Drawing.Size(126, 37);
            this.ToEmployees.TabIndex = 11;
            this.ToEmployees.Text = "Сотрудники (Employees)";
            this.ToEmployees.UseVisualStyleBackColor = true;
            this.ToEmployees.Click += new System.EventHandler(this.ToEmployees_Click);
            // 
            // ToDeals
            // 
            this.ToDeals.Location = new System.Drawing.Point(51, 72);
            this.ToDeals.Name = "ToDeals";
            this.ToDeals.Size = new System.Drawing.Size(126, 37);
            this.ToDeals.TabIndex = 10;
            this.ToDeals.Text = "Сделки (Deals)";
            this.ToDeals.UseVisualStyleBackColor = true;
            this.ToDeals.Click += new System.EventHandler(this.ToDeals_Click);
            // 
            // ToRealEstate
            // 
            this.ToRealEstate.Location = new System.Drawing.Point(51, 115);
            this.ToRealEstate.Name = "ToRealEstate";
            this.ToRealEstate.Size = new System.Drawing.Size(126, 35);
            this.ToRealEstate.TabIndex = 9;
            this.ToRealEstate.Text = "Недвижимость (RealEstate)";
            this.ToRealEstate.UseVisualStyleBackColor = true;
            this.ToRealEstate.Click += new System.EventHandler(this.ToRealEstate_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(229, 394);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.ToUsers);
            this.Controls.Add(this.ToDiagram);
            this.Controls.Add(this.ToTypeOfRealEstate);
            this.Controls.Add(this.ToProffessions);
            this.Controls.Add(this.ToPerson);
            this.Controls.Add(this.ToEmployees);
            this.Controls.Add(this.ToDeals);
            this.Controls.Add(this.ToRealEstate);
            this.Controls.Add(this.WelcomeText);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.Text = "Главное меню";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartForm_KeyDown);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Button RegistrationButton;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Button ToDiagram;
        private System.Windows.Forms.Label WelcomeText;
        private System.Windows.Forms.Button ToUsers;
        private System.Windows.Forms.Button ToTypeOfRealEstate;
        private System.Windows.Forms.Button ToProffessions;
        private System.Windows.Forms.Button ToPerson;
        private System.Windows.Forms.Button ToEmployees;
        private System.Windows.Forms.Button ToDeals;
        private System.Windows.Forms.Button ToRealEstate;
    }
}

