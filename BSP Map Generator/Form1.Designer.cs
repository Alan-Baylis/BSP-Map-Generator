namespace BSP_Map_Generator
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btDrawMap = new System.Windows.Forms.Button();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbMaxSize = new System.Windows.Forms.TextBox();
            this.tbScale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btBuild = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSplit = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btDrawMap);
            this.groupBox1.Controls.Add(this.pbMap);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1003, 558);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map";
            // 
            // btDrawMap
            // 
            this.btDrawMap.Location = new System.Drawing.Point(29, 525);
            this.btDrawMap.Name = "btDrawMap";
            this.btDrawMap.Size = new System.Drawing.Size(950, 23);
            this.btDrawMap.TabIndex = 5;
            this.btDrawMap.Text = "Draw Map";
            this.btDrawMap.UseVisualStyleBackColor = true;
            this.btDrawMap.Click += new System.EventHandler(this.btDrawMap_Click);
            // 
            // pbMap
            // 
            this.pbMap.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbMap.Location = new System.Drawing.Point(29, 19);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(951, 501);
            this.pbMap.TabIndex = 0;
            this.pbMap.TabStop = false;
            this.pbMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMap_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbSplit);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbMaxSize);
            this.groupBox2.Controls.Add(this.tbScale);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btBuild);
            this.groupBox2.Location = new System.Drawing.Point(1021, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 558);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // tbMaxSize
            // 
            this.tbMaxSize.Location = new System.Drawing.Point(66, 82);
            this.tbMaxSize.Name = "tbMaxSize";
            this.tbMaxSize.Size = new System.Drawing.Size(203, 20);
            this.tbMaxSize.TabIndex = 4;
            this.tbMaxSize.Text = "200";
            // 
            // tbScale
            // 
            this.tbScale.Location = new System.Drawing.Point(66, 29);
            this.tbScale.Name = "tbScale";
            this.tbScale.Size = new System.Drawing.Size(203, 20);
            this.tbScale.TabIndex = 3;
            this.tbScale.Text = "15";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MAX SIZE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Scale";
            // 
            // btBuild
            // 
            this.btBuild.Location = new System.Drawing.Point(6, 108);
            this.btBuild.Name = "btBuild";
            this.btBuild.Size = new System.Drawing.Size(263, 23);
            this.btBuild.TabIndex = 0;
            this.btBuild.Text = "Build";
            this.btBuild.UseVisualStyleBackColor = true;
            this.btBuild.Click += new System.EventHandler(this.btBuild_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "SplitHorArg";
            // 
            // tbSplit
            // 
            this.tbSplit.Location = new System.Drawing.Point(66, 56);
            this.tbSplit.Name = "tbSplit";
            this.tbSplit.Size = new System.Drawing.Size(203, 20);
            this.tbSplit.TabIndex = 6;
            this.tbSplit.Text = "0.2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1308, 582);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btBuild;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.TextBox tbMaxSize;
        private System.Windows.Forms.TextBox tbScale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDrawMap;
        private System.Windows.Forms.TextBox tbSplit;
        private System.Windows.Forms.Label label3;
    }
}

