namespace BFS
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
            this.buttonCreateLand = new System.Windows.Forms.Button();
            this.buttonFindPath = new System.Windows.Forms.Button();
            this.mazeControl = new BFS.MazeControl();
            this.SuspendLayout();
            // 
            // buttonCreateLand
            // 
            this.buttonCreateLand.Location = new System.Drawing.Point(268, 9);
            this.buttonCreateLand.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreateLand.Name = "buttonCreateLand";
            this.buttonCreateLand.Size = new System.Drawing.Size(100, 28);
            this.buttonCreateLand.TabIndex = 1;
            this.buttonCreateLand.Text = "Create Land";
            this.buttonCreateLand.UseVisualStyleBackColor = true;
            this.buttonCreateLand.Click += new System.EventHandler(this.buttonCreateMap_Click);
            // 
            // buttonFindPath
            // 
            this.buttonFindPath.Location = new System.Drawing.Point(675, 9);
            this.buttonFindPath.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFindPath.Name = "buttonFindPath";
            this.buttonFindPath.Size = new System.Drawing.Size(172, 28);
            this.buttonFindPath.TabIndex = 2;
            this.buttonFindPath.Text = "Find the shortest way";
            this.buttonFindPath.UseVisualStyleBackColor = true;
            this.buttonFindPath.Click += new System.EventHandler(this.buttonShortestPath_Click);
            // 
            // mazeControl
            // 
            this.mazeControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mazeControl.Location = new System.Drawing.Point(12, 54);
            this.mazeControl.Name = "mazeControl";
            this.mazeControl.Size = new System.Drawing.Size(1200, 600);
            this.mazeControl.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 671);
            this.Controls.Add(this.mazeControl);
            this.Controls.Add(this.buttonFindPath);
            this.Controls.Add(this.buttonCreateLand);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCreateLand;
        private System.Windows.Forms.Button buttonFindPath;
        private MazeControl mazeControl;
    }
}

