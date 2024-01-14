namespace ЭКЗ_Дождь
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SpeedMin = new System.Windows.Forms.TextBox();
            this.SpeedMax = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ColorKap = new System.Windows.Forms.Button();
            this.ColorTycha = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(915, 48);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(157, 57);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 450);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SpeedMin
            // 
            this.SpeedMin.Location = new System.Drawing.Point(945, 127);
            this.SpeedMin.Name = "SpeedMin";
            this.SpeedMin.Size = new System.Drawing.Size(100, 22);
            this.SpeedMin.TabIndex = 2;
            this.SpeedMin.TextChanged += new System.EventHandler(this.SpeedMin_TextChanged);
            // 
            // SpeedMax
            // 
            this.SpeedMax.Location = new System.Drawing.Point(945, 177);
            this.SpeedMax.Name = "SpeedMax";
            this.SpeedMax.Size = new System.Drawing.Size(100, 22);
            this.SpeedMax.TabIndex = 3;
            this.SpeedMax.TextChanged += new System.EventHandler(this.SpeedMax_TextChanged);
            // 
            // ColorKap
            // 
            this.ColorKap.Location = new System.Drawing.Point(915, 229);
            this.ColorKap.Name = "ColorKap";
            this.ColorKap.Size = new System.Drawing.Size(157, 23);
            this.ColorKap.TabIndex = 4;
            this.ColorKap.Text = "Цвет капли";
            this.ColorKap.UseVisualStyleBackColor = true;
            this.ColorKap.Click += new System.EventHandler(this.ColorKap_Click);
            // 
            // ColorTycha
            // 
            this.ColorTycha.Location = new System.Drawing.Point(915, 273);
            this.ColorTycha.Name = "ColorTycha";
            this.ColorTycha.Size = new System.Drawing.Size(157, 23);
            this.ColorTycha.TabIndex = 5;
            this.ColorTycha.Text = "Цвет тучи";
            this.ColorTycha.UseVisualStyleBackColor = true;
            this.ColorTycha.Click += new System.EventHandler(this.ColorTycha_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 511);
            this.Controls.Add(this.ColorTycha);
            this.Controls.Add(this.ColorKap);
            this.Controls.Add(this.SpeedMax);
            this.Controls.Add(this.SpeedMin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox SpeedMin;
        private System.Windows.Forms.TextBox SpeedMax;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ColorKap;
        private System.Windows.Forms.Button ColorTycha;
    }
}

