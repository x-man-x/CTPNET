namespace HaiFeng
{
    partial class Trade
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
            this.loginButton = new System.Windows.Forms.Button();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.logoutButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.middlePriceTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.initialLongOrderCountTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.initOrderButton = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.initialShortOrderCountTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.testSaveOpenOrdersButton = new System.Windows.Forms.Button();
            this.cleanOvernightOrderButton = new System.Windows.Forms.Button();
            this.suspendRefreshOrdersButton = new System.Windows.Forms.Button();
            this.recoverRefreshOrdersButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("宋体", 16F);
            this.loginButton.Location = new System.Drawing.Point(78, 314);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 34);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "登录";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F);
            this.label1.Location = new System.Drawing.Point(34, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "行情IP地址：";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 16F);
            this.textBox1.Location = new System.Drawing.Point(178, 166);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(314, 32);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "tcp://218.202.237.33:10012";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16F);
            this.label2.Location = new System.Drawing.Point(34, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "交易IP地址：";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 16F);
            this.textBox2.Location = new System.Drawing.Point(178, 215);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(314, 32);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "tcp://218.202.237.33:10002";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 16F);
            this.label3.Location = new System.Drawing.Point(74, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "用户名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 16F);
            this.label4.Location = new System.Drawing.Point(74, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "密  码：";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("宋体", 16F);
            this.textBox3.Location = new System.Drawing.Point(178, 26);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(230, 32);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "104247";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("宋体", 16F);
            this.textBox4.Location = new System.Drawing.Point(178, 75);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(230, 32);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "888888";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 16F);
            this.label5.Location = new System.Drawing.Point(56, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "合约号一：";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("宋体", 16F);
            this.textBox5.Location = new System.Drawing.Point(178, 262);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 32);
            this.textBox5.TabIndex = 10;
            this.textBox5.Text = "SR805";
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("宋体", 16F);
            this.textBox6.ForeColor = System.Drawing.Color.Red;
            this.textBox6.Location = new System.Drawing.Point(178, 367);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(230, 32);
            this.textBox6.TabIndex = 12;
            this.textBox6.Text = "0";
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 16F);
            this.label6.Location = new System.Drawing.Point(8, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 22);
            this.label6.TabIndex = 11;
            this.label6.Text = "实时合约价格：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 16F);
            this.label7.Location = new System.Drawing.Point(476, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 22);
            this.label7.TabIndex = 14;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // logoutButton
            // 
            this.logoutButton.Font = new System.Drawing.Font("宋体", 16F);
            this.logoutButton.Location = new System.Drawing.Point(273, 314);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 34);
            this.logoutButton.TabIndex = 15;
            this.logoutButton.Text = "登出";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Visible = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 16F);
            this.button3.Location = new System.Drawing.Point(126, 620);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 34);
            this.button3.TabIndex = 17;
            this.button3.Text = "买";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 16F);
            this.button4.Location = new System.Drawing.Point(227, 620);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 34);
            this.button4.TabIndex = 18;
            this.button4.Text = "卖";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // middlePriceTextBox
            // 
            this.middlePriceTextBox.Font = new System.Drawing.Font("宋体", 16F);
            this.middlePriceTextBox.Location = new System.Drawing.Point(178, 457);
            this.middlePriceTextBox.Name = "middlePriceTextBox";
            this.middlePriceTextBox.Size = new System.Drawing.Size(135, 32);
            this.middlePriceTextBox.TabIndex = 20;
            this.middlePriceTextBox.Text = "5597";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 16F);
            this.label8.Location = new System.Drawing.Point(41, 467);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 22);
            this.label8.TabIndex = 21;
            this.label8.Text = "中间价格：";
            // 
            // initialLongOrderCountTextBox
            // 
            this.initialLongOrderCountTextBox.Font = new System.Drawing.Font("宋体", 16F);
            this.initialLongOrderCountTextBox.Location = new System.Drawing.Point(178, 501);
            this.initialLongOrderCountTextBox.Name = "initialLongOrderCountTextBox";
            this.initialLongOrderCountTextBox.Size = new System.Drawing.Size(135, 32);
            this.initialLongOrderCountTextBox.TabIndex = 22;
            this.initialLongOrderCountTextBox.Text = "50";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 16F);
            this.label9.Location = new System.Drawing.Point(8, 511);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 22);
            this.label9.TabIndex = 23;
            this.label9.Text = "挂单数（买）：";
            // 
            // initOrderButton
            // 
            this.initOrderButton.Font = new System.Drawing.Font("宋体", 16F);
            this.initOrderButton.Location = new System.Drawing.Point(273, 559);
            this.initOrderButton.Name = "initOrderButton";
            this.initOrderButton.Size = new System.Drawing.Size(135, 34);
            this.initOrderButton.TabIndex = 24;
            this.initOrderButton.Text = "挂单初始化";
            this.initOrderButton.UseVisualStyleBackColor = true;
            this.initOrderButton.Visible = false;
            this.initOrderButton.Click += new System.EventHandler(this.initOrderButton_Click);
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("宋体", 16F);
            this.textBox9.Location = new System.Drawing.Point(178, 119);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(230, 32);
            this.textBox9.TabIndex = 26;
            this.textBox9.Text = "9999";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 16F);
            this.label10.Location = new System.Drawing.Point(52, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 22);
            this.label10.TabIndex = 25;
            this.label10.Text = "代理公司：";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("宋体", 16F);
            this.button7.Location = new System.Drawing.Point(18, 620);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 34);
            this.button7.TabIndex = 27;
            this.button7.Text = "测试";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // initialShortOrderCountTextBox
            // 
            this.initialShortOrderCountTextBox.Font = new System.Drawing.Font("宋体", 16F);
            this.initialShortOrderCountTextBox.Location = new System.Drawing.Point(178, 409);
            this.initialShortOrderCountTextBox.Name = "initialShortOrderCountTextBox";
            this.initialShortOrderCountTextBox.Size = new System.Drawing.Size(135, 32);
            this.initialShortOrderCountTextBox.TabIndex = 28;
            this.initialShortOrderCountTextBox.Text = "50";
            this.initialShortOrderCountTextBox.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 16F);
            this.label11.Location = new System.Drawing.Point(8, 419);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(164, 22);
            this.label11.TabIndex = 29;
            this.label11.Text = "挂单数（卖）：";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(496, 70);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(438, 523);
            this.richTextBox1.TabIndex = 30;
            this.richTextBox1.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 16F);
            this.label12.Location = new System.Drawing.Point(492, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 22);
            this.label12.TabIndex = 31;
            this.label12.Text = "挂单情况：";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // testSaveOpenOrdersButton
            // 
            this.testSaveOpenOrdersButton.Font = new System.Drawing.Font("宋体", 16F);
            this.testSaveOpenOrdersButton.Location = new System.Drawing.Point(509, 620);
            this.testSaveOpenOrdersButton.Name = "testSaveOpenOrdersButton";
            this.testSaveOpenOrdersButton.Size = new System.Drawing.Size(153, 34);
            this.testSaveOpenOrdersButton.TabIndex = 32;
            this.testSaveOpenOrdersButton.Text = "测试保存定单";
            this.testSaveOpenOrdersButton.UseVisualStyleBackColor = true;
            this.testSaveOpenOrdersButton.Visible = false;
            this.testSaveOpenOrdersButton.Click += new System.EventHandler(this.testSaveOpenOrdersButton_Click);
            // 
            // cleanOvernightOrderButton
            // 
            this.cleanOvernightOrderButton.Font = new System.Drawing.Font("宋体", 16F);
            this.cleanOvernightOrderButton.Location = new System.Drawing.Point(12, 559);
            this.cleanOvernightOrderButton.Name = "cleanOvernightOrderButton";
            this.cleanOvernightOrderButton.Size = new System.Drawing.Size(189, 34);
            this.cleanOvernightOrderButton.TabIndex = 33;
            this.cleanOvernightOrderButton.Text = "清除隔夜定单";
            this.cleanOvernightOrderButton.UseVisualStyleBackColor = true;
            this.cleanOvernightOrderButton.Click += new System.EventHandler(this.cleanOvernightOrderButton_Click);
            // 
            // suspendRefreshOrdersButton
            // 
            this.suspendRefreshOrdersButton.Font = new System.Drawing.Font("宋体", 16F);
            this.suspendRefreshOrdersButton.Location = new System.Drawing.Point(602, 36);
            this.suspendRefreshOrdersButton.Name = "suspendRefreshOrdersButton";
            this.suspendRefreshOrdersButton.Size = new System.Drawing.Size(163, 34);
            this.suspendRefreshOrdersButton.TabIndex = 34;
            this.suspendRefreshOrdersButton.Text = "暂停刷新挂单";
            this.suspendRefreshOrdersButton.UseVisualStyleBackColor = true;
            this.suspendRefreshOrdersButton.Click += new System.EventHandler(this.suspendRefreshOrdersButton_Click);
            // 
            // recoverRefreshOrdersButton
            // 
            this.recoverRefreshOrdersButton.Font = new System.Drawing.Font("宋体", 16F);
            this.recoverRefreshOrdersButton.Location = new System.Drawing.Point(771, 36);
            this.recoverRefreshOrdersButton.Name = "recoverRefreshOrdersButton";
            this.recoverRefreshOrdersButton.Size = new System.Drawing.Size(163, 34);
            this.recoverRefreshOrdersButton.TabIndex = 35;
            this.recoverRefreshOrdersButton.Text = "恢复刷新挂单";
            this.recoverRefreshOrdersButton.UseVisualStyleBackColor = true;
            this.recoverRefreshOrdersButton.Visible = false;
            this.recoverRefreshOrdersButton.Click += new System.EventHandler(this.recoverRefreshOrdersButton_Click);
            // 
            // Trade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 665);
            this.Controls.Add(this.recoverRefreshOrdersButton);
            this.Controls.Add(this.suspendRefreshOrdersButton);
            this.Controls.Add(this.cleanOvernightOrderButton);
            this.Controls.Add(this.testSaveOpenOrdersButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.initialShortOrderCountTextBox);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.initOrderButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.initialLongOrderCountTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.middlePriceTextBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginButton);
            this.Name = "Trade";
            this.Text = "Trade";
            this.Load += new System.EventHandler(this.Trade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox middlePriceTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox initialLongOrderCountTextBox;
        private System.Windows.Forms.Button initOrderButton;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox initialShortOrderCountTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button testSaveOpenOrdersButton;
        private System.Windows.Forms.Button cleanOvernightOrderButton;
        private System.Windows.Forms.Button recoverRefreshOrdersButton;
        private System.Windows.Forms.Button suspendRefreshOrdersButton;
    }
}