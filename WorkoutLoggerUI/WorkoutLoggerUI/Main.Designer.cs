namespace WorkoutLoggerUI
{
    partial class Main
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
            this.btn_addData = new System.Windows.Forms.Button();
            this.btn_addSport = new System.Windows.Forms.Button();
            this.btn_addColumn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_addData
            // 
            this.btn_addData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_addData.Location = new System.Drawing.Point(186, 16);
            this.btn_addData.Margin = new System.Windows.Forms.Padding(4);
            this.btn_addData.Name = "btn_addData";
            this.btn_addData.Size = new System.Drawing.Size(160, 60);
            this.btn_addData.TabIndex = 0;
            this.btn_addData.Text = "Add data";
            this.btn_addData.UseVisualStyleBackColor = true;
            this.btn_addData.Click += new System.EventHandler(this.btn_addData_Click);
            // 
            // btn_addSport
            // 
            this.btn_addSport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_addSport.Location = new System.Drawing.Point(17, 16);
            this.btn_addSport.Margin = new System.Windows.Forms.Padding(4);
            this.btn_addSport.Name = "btn_addSport";
            this.btn_addSport.Size = new System.Drawing.Size(160, 60);
            this.btn_addSport.TabIndex = 1;
            this.btn_addSport.Text = "Add sport";
            this.btn_addSport.UseVisualStyleBackColor = true;
            this.btn_addSport.Click += new System.EventHandler(this.btn_addSport_Click);
            // 
            // btn_addColumn
            // 
            this.btn_addColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_addColumn.Location = new System.Drawing.Point(357, 16);
            this.btn_addColumn.Margin = new System.Windows.Forms.Padding(4);
            this.btn_addColumn.Name = "btn_addColumn";
            this.btn_addColumn.Size = new System.Drawing.Size(160, 60);
            this.btn_addColumn.TabIndex = 2;
            this.btn_addColumn.Text = "Add column";
            this.btn_addColumn.UseVisualStyleBackColor = true;
            this.btn_addColumn.Click += new System.EventHandler(this.btn_addColumn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 585);
            this.Controls.Add(this.btn_addColumn);
            this.Controls.Add(this.btn_addSport);
            this.Controls.Add(this.btn_addData);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "WorkoutLogger";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_addData;
        private System.Windows.Forms.Button btn_addSport;
        private System.Windows.Forms.Button btn_addColumn;
    }
}

