/* 
 * Cell.cs
 * Author: Nick Ruffini
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.Sudoku
{
    /// <summary>
    /// Class that represents a cell on the grid!
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Constant int that represents the size of the grid
        /// </summary>
        private const int _gridSize = 9;
        /// <summary>
        /// Public property to get and set the cell's current value
        /// </summary>
        public int Value { get; set; } = -1;
        /// <summary>
        /// Public property to get the cell's current row, but cannot be set
        /// </summary>
        public int Row { get; }
        /// <summary>
        /// Public property to get the cell's current column, but cannot be set
        /// </summary>
        public int Col { get; }
        /// <summary>
        /// a property to get this cell's available values (“colors”). For example,
        /// spot 1 in the array will be true if 1 is an available value.It should have no set
        /// [-1, 1, 2, 3, 4, 5, 6, 7, 8, 9]
        /// </summary>
        public bool[] Moves { get; } = new bool[_gridSize + 1];

        /// <summary>
        /// Constructor that creates this specific cell!
        /// </summary>
        /// <param name="row"> Row at which this cell is located in the grid </param>
        /// <param name="col"> Column at which this cell is located in the grid </param>
        /// <param name="val"> Starting value that this cell contains (-1 if uncolored) </param>
        public Cell(int row, int col, int val)
        {
            Value = val;
            Row = row;
            Col = col;

            ResetMoves();
        }

        /// <summary>
        /// A method to add back index to the list of available
        /// values for this cell
        /// </summary>
        /// <param name="index"> Where we are adding this availability back into the array! </param>
        public void AddBackMove(int index)
        {
            Moves[index] = true;
        }

        /// <summary>
        /// A method to remove index from the list of available
        /// values for this cell
        /// </summary>
        /// <param name="index"> Where we are removing this available value from the array </param>
        public void RemoveMove(int index)
        {
            if (index >= 0)
            {
                Moves[index] = false;
            }
        }

        /// <summary>
        /// resets the possible moves for this cell. If this cell has a Value of
        /// -1, set all possible move values to true. If this cell has any other value, set all possible
        /// move values to false. 
        /// </summary>
        public void ResetMoves()
        {
            if (Value == -1)
            {
                for (int i = 0; i <= _gridSize; i++)
                {
                    Moves[i] = true;
                }
            }
            else
            {
                for (int i = 0; i <= _gridSize; i++)
                {
                    Moves[i] = false;
                }
            }
        }
    }
}
