namespace Ksu.Cis300.Sudoku
{
    partial class UserInterface
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uxPanel = new System.Windows.Forms.Panel();
            this.uxGrid = new System.Windows.Forms.DataGridView();
            this.uxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // uxPanel
            // 
            this.uxPanel.Controls.Add(this.uxGrid);
            this.uxPanel.Location = new System.Drawing.Point(20, 25);
            this.uxPanel.Margin = new System.Windows.Forms.Padding(2);
            this.uxPanel.Name = "uxPanel";
            this.uxPanel.Size = new System.Drawing.Size(361, 363);
            this.uxPanel.TabIndex = 0;
            // 
            // uxGrid
            // 
            this.uxGrid.AllowUserToAddRows = false;
            this.uxGrid.AllowUserToDeleteRows = false;
            this.uxGrid.AllowUserToResizeColumns = false;
            this.uxGrid.AllowUserToResizeRows = false;
            this.uxGrid.BackgroundColor = System.Drawing.Color.White;
            this.uxGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uxGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.uxGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxGrid.Location = new System.Drawing.Point(0, 0);
            this.uxGrid.Margin = new System.Windows.Forms.Padding(2);
            this.uxGrid.Name = "uxGrid";
            this.uxGrid.ReadOnly = true;
            this.uxGrid.RowHeadersVisible = false;
            this.uxGrid.RowHeadersWidth = 40;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.uxGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.uxGrid.RowTemplate.Height = 28;
            this.uxGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.uxGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.uxGrid.Size = new System.Drawing.Size(361, 363);
            this.uxGrid.TabIndex = 0;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 417);
            this.Controls.Add(this.uxPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(420, 534);
            this.Name = "UserInterface";
            this.Text = "Sudoku Solver";
            this.uxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uxPanel;
        private System.Windows.Forms.DataGridView uxGrid;
    }
}

