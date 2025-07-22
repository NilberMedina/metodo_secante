namespace metodo_secante
{
    partial class Form1
    {
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
            txtFuncion = new TextBox();
            txtX0 = new TextBox();
            txtX1 = new TextBox();
            txtTolerancia = new TextBox();
            txtMaxIteraciones = new TextBox();
            txtResultado = new TextBox();
            btnCalcular = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtFuncion
            // 
            txtFuncion.Location = new Point(147, 13);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(125, 27);
            txtFuncion.TabIndex = 0;
            // 
            // txtX0
            // 
            txtX0.Location = new Point(147, 67);
            txtX0.Name = "txtX0";
            txtX0.Size = new Size(125, 27);
            txtX0.TabIndex = 1;
            // 
            // txtX1
            // 
            txtX1.Location = new Point(147, 129);
            txtX1.Name = "txtX1";
            txtX1.Size = new Size(125, 27);
            txtX1.TabIndex = 2;
            // 
            // txtTolerancia
            // 
            txtTolerancia.Location = new Point(147, 195);
            txtTolerancia.Name = "txtTolerancia";
            txtTolerancia.Size = new Size(125, 27);
            txtTolerancia.TabIndex = 3;
            // 
            // txtMaxIteraciones
            // 
            txtMaxIteraciones.Location = new Point(147, 261);
            txtMaxIteraciones.Name = "txtMaxIteraciones";
            txtMaxIteraciones.Size = new Size(125, 27);
            txtMaxIteraciones.TabIndex = 4;
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(294, 13);
            txtResultado.Multiline = true;
            txtResultado.Name = "txtResultado";
            txtResultado.ScrollBars = ScrollBars.Both;
            txtResultado.Size = new Size(344, 406);
            txtResultado.TabIndex = 5;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(69, 331);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(94, 29);
            btnCalcular.TabIndex = 6;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 7;
            label1.Text = "Función";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 74);
            label2.Name = "label2";
            label2.Size = new Size(26, 20);
            label2.TabIndex = 8;
            label2.Text = "X0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 136);
            label3.Name = "label3";
            label3.Size = new Size(26, 20);
            label3.TabIndex = 9;
            label3.Text = "X1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 198);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 10;
            label4.Text = "Tolerancia";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 268);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 11;
            label5.Text = "Iteraciones máx";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 433);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCalcular);
            Controls.Add(txtResultado);
            Controls.Add(txtMaxIteraciones);
            Controls.Add(txtTolerancia);
            Controls.Add(txtX1);
            Controls.Add(txtX0);
            Controls.Add(txtFuncion);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFuncion;
        private TextBox txtX0;
        private TextBox txtX1;
        private TextBox txtTolerancia;
        private TextBox txtMaxIteraciones;
        private TextBox txtResultado;
        private Button btnCalcular;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
