namespace FirstSimpleExtension
{
    partial class BleepaUsingsSortControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SortUsingsCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SortUsingsCheckbox
            // 
            this.SortUsingsCheckbox.AutoSize = true;
            this.SortUsingsCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SortUsingsCheckbox.Location = new System.Drawing.Point(6, 25);
            this.SortUsingsCheckbox.Name = "SortUsingsCheckbox";
            this.SortUsingsCheckbox.Size = new System.Drawing.Size(119, 17);
            this.SortUsingsCheckbox.TabIndex = 0;
            this.SortUsingsCheckbox.Text = "Sort usings on save";
            this.SortUsingsCheckbox.UseVisualStyleBackColor = true;
            this.SortUsingsCheckbox.CheckedChanged += new System.EventHandler(this.SortUsingsCheckbox_CheckedChanged);
            this.SortUsingsCheckbox.Leave += new System.EventHandler(this.SortUsings_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(100, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 2);
            this.label1.TabIndex = 1;
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bleepa project usings";
            // 
            // BleepaUsingsSortControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SortUsingsCheckbox);
            this.Name = "BleepaUsingsSortControl";
            this.Size = new System.Drawing.Size(316, 108);
            this.Load += new System.EventHandler(this.BleepaUsingsSortControl_Load);
            this.Leave += new System.EventHandler(this.BleepaUsingsSortControl_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox SortUsingsCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
