/*
 * UserInterface.cs
 * Author: Nick Ruffini
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Ksu.Cis300.Graphs;

namespace Ksu.Cis300.Sudoku
{
    /// <summary>
    /// Represents the User Interface for the Sudoku Solver
    /// </summary>
    public partial class uxUserInterface : Form
    {
        /// <summary>
        /// The size of the Sudoku puzzle
        /// </summary>
        private const int _gridSize = 9;

        /// <summary>
        /// The size of each cell on the grid
        /// </summary>
        private const int _cellSize = 40;

        /// <summary>
        /// Initializes a new Sudoku Object, which serves as the puzzle we are working with.
        /// </summary>
        private Sudoku _puzzle = new Sudoku();
       

        /// <summary>
        /// Sets up the User Interface, including the DataGridView control
        /// </summary>
        public uxUserInterface()
        {
            InitializeComponent();

            for (int i = 0; i < _gridSize; i++)
            {
                DataGridViewTextBoxColumn txCol = new DataGridViewTextBoxColumn();
                txCol.MaxInputLength = 1;
                uxGrid.Columns.Add(txCol);
                uxGrid.Columns[i].Name = "Col " + (i + 1).ToString();
                uxGrid.Columns[i].Width = _cellSize;
                uxGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewRow row = new DataGridViewRow();
                row.Height = _cellSize;
                uxGrid.Rows.Add(row);
            }

            //marks the 3x3 grids
            uxGrid.Columns[2].DividerWidth = 2;
            uxGrid.Columns[5].DividerWidth = 2;
            uxGrid.Rows[2].DividerHeight = 2;
            uxGrid.Rows[5].DividerHeight = 2;

            //DELETE AFTER TESTING
            //Demonstrates how to set cell values in the grid
            //SetCell(0, 0, 4);
            //SetCell(3, 3, 7);
            //SetCell(8, 8, 9);
            //SetCell(0, 0, -1);
        }
   
        /// <summary>
        /// Sets a cell in the GUI grid to display the given value
        /// </summary>
        /// <param name="row">The row of the cell</param>
        /// <param name="col">The column of the cell</param>
        /// <param name="value">The value to display</param>
        public void SetCell(int row, int col, int value)
        {
            if (value == -1)
            {
                uxGrid.Rows[row].Cells[col].Value = "";
            }
            else
            {
                uxGrid.Rows[row].Cells[col].Value = value;
            }

        }

        /// <summary>
        /// Loops through each cell in the puzzle, pulls out its
        /// current value, and calls the SetCell method to update the user interface to have
        /// the current cell value
        /// </summary>
        private void UpdateDisplay()
        {
            for (int row = 0; row < _gridSize; row++)
            {
                for (int col = 0; col < _gridSize; col++)
                {
                    int value = _puzzle[row, col].Value;
                    SetCell(row, col, value);
                }
            }
        }

        /// <summary>
        /// Click event for "Load a Puzzle" Menu Item. Checks if the input file is correctly formatted, and
        /// if it is, calls UpdateDisplay() with the new values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLoadPuzzle_Click(object sender, EventArgs e)
        {
            if (uxOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = uxOpenFileDialog.FileName;

                try
                {
                    _puzzle.ReadPuzzle(fileName);

                    UpdateDisplay();
                }
                catch (Exception)
                {
                    MessageBox.Show("Input File is ill-formatted");
                }
            }
        }

        /// <summary>
        /// Click event for the "Solve Puzzle" button. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSolvePuzzleButton_Click(object sender, EventArgs e)
        {
            bool result = _puzzle.ConnectGraph();

            if (result == false)
            {
                MessageBox.Show("The graph could not be connected.");
            }
            else
            {
                bool solvedResult = _puzzle.SolveSudoku();
                if (solvedResult == false)
                {
                    MessageBox.Show("A solution could not be found.");
                }
                else
                {
                    UpdateDisplay();
                }
            }
            
        }

        /// <summary>
        /// Event when the user finishes editing a cell in the grid. If the input is valid, updates the cell!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Object value = uxGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value == null || value.ToString() == "" || (Convert.ToInt32(value) >= 1 && Convert.ToInt32(value) <= 9) )
                {
                    _puzzle.UpdateCell(e.RowIndex, e.ColumnIndex);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Invalid Operator entered in a cell");
                uxGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
        }
    }
}
