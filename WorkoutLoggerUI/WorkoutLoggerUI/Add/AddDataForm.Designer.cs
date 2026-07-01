namespace WorkoutLoggerUI.Add
{
    partial class AddDataForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmBoxSport = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sport:";
            // 
            // cmBoxSport
            // 
            this.cmBoxSport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmBoxSport.FormattingEnabled = true;
            this.cmBoxSport.Location = new System.Drawing.Point(102, 27);
            this.cmBoxSport.Margin = new System.Windows.Forms.Padding(4);
            this.cmBoxSport.Name = "cmBoxSport";
            this.cmBoxSport.Size = new System.Drawing.Size(146, 33);
            this.cmBoxSport.TabIndex = 8;
            this.cmBoxSport.SelectedIndexChanged += new System.EventHandler(this.cmBoxSport_SelectedIndexChanged);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add.Location = new System.Drawing.Point(15, 438);
            this.btn_add.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(141, 42);
            this.btn_add.TabIndex = 9;
            this.btn_add.Text = "ADD";
            this.btn_add.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_cancel.Location = new System.Drawing.Point(168, 438);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(141, 42);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(599, 363);
            this.dataGridView1.TabIndex = 11;
            // 
            // AddDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 494);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.cmBoxSport);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddDataForm";
            this.Text = "AddDataForm";
            this.Load += new System.EventHandler(this.AddDataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmBoxSport;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}