namespace Ksu.Cis300.Sudoku
{
    partial class uxUserInterface
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.uxMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.uxLoadPuzzle = new System.Windows.Forms.ToolStripMenuItem();
            this.uxOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxSolvePuzzleButton = new System.Windows.Forms.Button();
            this.uxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxPanel
            // 
            this.uxPanel.Controls.Add(this.uxGrid);
            this.uxPanel.Location = new System.Drawing.Point(40, 48);
            this.uxPanel.Margin = new System.Windows.Forms.Padding(4);
            this.uxPanel.Name = "uxPanel";
            this.uxPanel.Size = new System.Drawing.Size(722, 698);
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
            this.uxGrid.Margin = new System.Windows.Forms.Padding(4);
            this.uxGrid.Name = "uxGrid";
            this.uxGrid.RowHeadersVisible = false;
            this.uxGrid.RowHeadersWidth = 40;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.uxGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.uxGrid.RowTemplate.Height = 28;
            this.uxGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.uxGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.uxGrid.Size = new System.Drawing.Size(722, 698);
            this.uxGrid.TabIndex = 0;
            this.uxGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.uxGrid_CellEndEdit);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxMenuStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(788, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // uxMenuStrip
            // 
            this.uxMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxLoadPuzzle});
            this.uxMenuStrip.Name = "uxMenuStrip";
            this.uxMenuStrip.Size = new System.Drawing.Size(90, 36);
            this.uxMenuStrip.Text = "Tools";
            // 
            // uxLoadPuzzle
            // 
            this.uxLoadPuzzle.Name = "uxLoadPuzzle";
            this.uxLoadPuzzle.Size = new System.Drawing.Size(359, 44);
            this.uxLoadPuzzle.Text = " Load a Puzzle";
            this.uxLoadPuzzle.Click += new System.EventHandler(this.uxLoadPuzzle_Click);
            // 
            // uxOpenFileDialog
            // 
            this.uxOpenFileDialog.FileName = "openFileDialog1";
            // 
            // uxSolvePuzzleButton
            // 
            this.uxSolvePuzzleButton.Location = new System.Drawing.Point(286, 754);
            this.uxSolvePuzzleButton.Name = "uxSolvePuzzleButton";
            this.uxSolvePuzzleButton.Size = new System.Drawing.Size(226, 53);
            this.uxSolvePuzzleButton.TabIndex = 2;
            this.uxSolvePuzzleButton.Text = "Solve Puzzle";
            this.uxSolvePuzzleButton.UseVisualStyleBackColor = true;
            this.uxSolvePuzzleButton.Click += new System.EventHandler(this.uxSolvePuzzleButton_Click);
            // 
            // uxUserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 802);
            this.Controls.Add(this.uxSolvePuzzleButton);
            this.Controls.Add(this.uxPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(814, 961);
            this.Name = "uxUserInterface";
            this.Text = "Sudoku Solver";
            this.uxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel uxPanel;
        private System.Windows.Forms.DataGridView uxGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem uxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem uxLoadPuzzle;
        private System.Windows.Forms.OpenFileDialog uxOpenFileDialog;
        private System.Windows.Forms.Button uxSolvePuzzleButton;
    }
}

