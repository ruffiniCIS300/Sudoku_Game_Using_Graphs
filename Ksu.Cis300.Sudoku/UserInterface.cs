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
        }
   
        /// <summary>
        /// Sets a cell in the GUI grid to display the given value
        /// </summary>
        /// <param name="row">The row of the cell</param>
        /// <param name="col">The column of the cell</param>
        /// <param name="value">The value to display</param>
        public void SetCell(int row, int col, int value)
        {
            uxGrid.Rows[row].Cells[col].Value = value;
        }

    }
}
