/* 
 * Sudoku.cs
 * Author: Nick Ruffini
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Ksu.Cis300.Graphs;

namespace Ksu.Cis300.Sudoku
{
    /// <summary>
    /// Represents the Sudoku puzzle!
    /// </summary>
    public class Sudoku
    {
        /// <summary>
        /// A graph representing the Sudoku puzzle.
        /// Here, the nodes are Cell objects. The edge weights are ints, but the graph is
        /// unweighted so you can use the same number (0) for all edge weights.
        /// </summary>
        private DirectedGraph<Cell, int> _graph = new DirectedGraph<Cell, int>();
        /// <summary>
        /// An int that represents the grid size (9)
        /// </summary>
        private const int _gridSize = 9;
        /// <summary>
        /// A 9x9 array of all the cells in the Sudoku puzzle
        /// </summary>
        private Cell[,] _nodes;

        /// <summary>
        /// Constructor that initializes the _nodes 2D Array with "empty" values
        /// </summary>
        public Sudoku()
        {
            _nodes = new Cell[_gridSize, _gridSize];

            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    // Gives each cell a value of -1, or "colorless"
                    _nodes[i, j] = new Cell(i, j, -1);
                }
            }
        }

        /// <summary>
        /// Indexer that takes in 2 int values, representing the row and column of the desired cell,
        /// and returns the desired cell at this location.
        /// </summary>
        /// <param name="row"> Row at which we want the cell from </param>
        /// <param name="col"> Column at which we want the cell from </param>
        /// <returns> The cell at the location given the 2 parameters </returns>
        public Cell this[int row, int col]
        {
            get
            {
                return _nodes[row, col];
            }
        }

        /// <summary>
        /// Reads in an input file and creates a 2D array with the values!
        /// </summary>
        /// <param name="inputFileName"> Name of the input file! </param>
        public void ReadPuzzle(string inputFileName) 
        {
            Cell[,] tempArray = new Cell[_gridSize, _gridSize];

            using (StreamReader sr = new StreamReader(inputFileName))
            {
                int row = 0; 

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(' ');

                    for (int i = 0; i < values.Length; i ++)
                    {
                        if (values[i] != "_")
                        {
                            tempArray[row, i] = new Cell(row, i, Convert.ToInt32(values[i]));

                        }
                        else
                        {
                            tempArray[row, i] = new Cell(row, i, -1);
                        }
                    }

                    row++;
                }
            }
            _nodes = tempArray;
        }

        /// <summary>
        /// Updates the Value property for the given cell to be the new value.
        /// </summary>
        /// <param name="row"> Row at which the cell we are changing </param>
        /// <param name="column"> Column at which the cell we are changing </param>
        /// <param name="value"> New value we are giving the cell! </param>
        public void UpdateCell(int row, int column, int value)
        {
            _nodes[row, column].Value = value;
        }

        /// <summary>
        /// Calls the first version of this method, passing -1 (the uncolored value) as the value
        /// parameter.
        /// </summary>
        /// <param name="row"> Row of cell we are changing </param>
        /// <param name="column"> Column of cell we are changing </param>
        public void UpdateCell(int row, int column)
        {
            UpdateCell(row, column, -1);
        }

        /// <summary>
        /// Connects all of the cells in the grid together with their appropriate rows, columns and
        /// 3x3 grids!
        /// </summary>
        /// <returns> Whether or not all the cells could be connected to their appropriate partners </returns>
        public bool ConnectGraph()
        {
            // initializes a new graph
            _graph = new DirectedGraph<Cell, int>();

            // Calls reset moves on all the cells in _nodes
            for (int row = 0; row < _gridSize; row++)
            {
                for (int col = 0; col < _gridSize; col++)
                {
                    _nodes[row, col].ResetMoves();
                }
            }

            // connects the cells in the graph and returns whether or not it could all be connected 
            for (int row = 0; row < _gridSize; row++)
            {
                for (int col = 0; col < _gridSize; col++)
                {
                    bool result1 = ConnectRow(_nodes[row, col]);
                    bool result2 = ConnectColumn(_nodes[row, col]);
                    bool result3 = ConnectSmallGrid(_nodes[row, col]);

                    if (result1 == false || result2 == false || result3 == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Try's to add an edge between two Cells!
        /// </summary>
        /// <param name="source"> First Cell being connected </param>
        /// <param name="destination"> Second Cell being connected </param>
        /// <returns> Whether or not the edge could be added </returns>
        private bool ConnectEdge(Cell source, Cell destination)
        {
            // if the Cells have the same value, cannot connect them with an edge
            if (source.Value == destination.Value)
            {
                if (source.Value > 0)
                {
                    return false;
                }
            }
            // create an edge between the 2 Cells with a weight of 0
            _graph.AddEdge(source, destination, 0);

            // if one of the cell's has a value other than default (-1), remove that value from
            // it's Moves array
            if (destination.Value != -1)
            {
                source.RemoveMove(destination.Value);
            }
            

            return true;
        }

        /// <summary>
        /// Tries to add edges between the parameter cell and every other cell in the 
        /// same row, using the ConnectEdge method.
        /// </summary>
        /// <param name="cell"> Cell we are using as the source node to add edges to </param>
        /// <returns> Whether or not it could successfully add all the edges</returns>
        private bool ConnectRow(Cell current)
        {
            int column = current.Col / 3 * 3;

            for (int i = 0; i < column; i++)
            {
                // Makes sure we don't compare the same cell to itself, which will always return false
                if (i != current.Col)
                {
                    Cell destination = _nodes[current.Row, i];
                    // if there isn't an edge between the 2, try and add one!
                    bool added = ConnectEdge(current, destination);
                    if (added == false)
                    {
                        return false;
                    }
                }
            }
            for (int j = column + 3; j < _gridSize; j++)
            {
                // Makes sure we don't compare the same cell to itself, which will always return false
                if (j != current.Col)
                {
                    Cell destination = _nodes[current.Row, j];
                    // if there isn't an edge between the 2, try and add one!
                    bool added = ConnectEdge(current, destination);
                    if (added == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Tries to add edges between the parameter cell and every other cell in the same column,
        /// using the ConnectEdge method.
        /// </summary>
        /// <param name="source"> Cell we are using to connect all other cells in column </param>
        /// <returns> Whether or not all the edges could be added </returns>
        private bool ConnectColumn(Cell current)
        {
            int row = current.Row / 3 * 3;

            for (int i = 0; i < row; i++)
            {
                // Makes sure we don't compare the same cell to itself, which will always return false
                if (i != current.Row)
                {
                    Cell destination = _nodes[i, current.Col];
                    // if there isn't an edge between the 2, try and add one!
                    bool added = ConnectEdge(current, destination);
                    if (added == false)
                    {
                        return false;
                    }
                }
            }
            for (int j = row + 3; j < _gridSize; j++)
            {
                // Makes sure we don't compare the same cell to itself, which will always return false
                if (j != current.Row)
                {
                    Cell destination = _nodes[j, current.Col];
                    // if there isn't an edge between the 2, try and add one!
                    bool added = ConnectEdge(current, destination);
                    if (added == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Tries to add edges between the parameter cell and every other cell in the same
        /// 3x3 grid, using the ConnectEdge method.
        /// </summary>
        /// <param name="source"> Cell we are trying to link to all other cells in it's 3x3 </param>
        /// <returns> Whether or not all the cell's could be linked </returns>
        private bool ConnectSmallGrid(Cell current)
        {
            // Grids labeled from 0-2 (so if on row 7, 7/3 = 2, so grid row 2!)
            int gridRow = current.Row / 3 * 3;
            int gridCol = current.Col / 3 * 3;

            for (int row = gridRow; row < 3 + gridRow; row++)
            {
                for (int col = gridCol; col < 3 + gridCol; col++)
                {
                    // Makes sure we don't compare the same cell to itself, which will always return false
                    if (row != current.Row || col != current.Col)
                    {
                        Cell destination = _nodes[row, col];
                        // if there isn't an edge between the 2, try and add one!
                        bool added = ConnectEdge(current, destination);
                        if (added == false)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Returns the number of uncolored cells in the graph
        /// </summary>
        /// <returns> Number of uncolored cells in the graph </returns>
        private int GetNumUncolored()
        {
            int numUncolored = 0;

            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    if (_nodes[i, j].Value == -1)
                    {
                        numUncolored++;
                    }
                }
            }

            return numUncolored;
        }

        /// <summary>
        /// Takes the previously processed cell as
        /// a parameter, and should return the next uncolored(value = -1) cell in the puzzle
        /// (“reading” the puzzle left to right, top to bottom) after the parameter cell.
        /// </summary>
        /// <param name="previousCell"> Previously processed cell we are starting at </param>
        /// <returns> The next uncolored cell in the puzzle!</returns>
        private Cell GetNextCell(Cell previousCell)
        {
            // If the cell is null, just look for the first uncolored cell!
            if (previousCell == null)
            {
                for (int row = 0; row < _gridSize; row++)
                {
                    for (int col = 0; col < _gridSize; col++)
                    {
                        if (_nodes[row, col].Value == -1)
                        {
                            return _nodes[row, col];
                        }
                    }
                }
                return null;
            }
            else
            {
                int initialRow = previousCell.Row;
                int initialColumn = previousCell.Col;

                // processes the first, potentially incomplete line
                for (int col = initialColumn; col < _gridSize; col++)
                {
                    if (_nodes[initialRow, col].Value == -1)
                    {
                        return _nodes[initialRow, col];
                    }
                }

                // processes the rest of the grid!
                for (int row = initialRow + 1; row < _gridSize; row++)
                {
                    for (int col = 0; col < _gridSize; col++)
                    {
                        if (_nodes[row, col].Value == -1)
                        {
                            return _nodes[row, col];
                        }
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Returns whether or not a solution could be found to the puzzle found in _nodes!
        /// </summary>
        /// <param name="uncoloredCells"> Number of uncolored cells left in the puzzle! </param>
        /// <param name="previouslyColored"> Cell that was most recently colored! </param>
        /// <returns> Whether or not a solution could be found </returns>
        private bool SolveSudoku(int uncoloredCells, Cell previouslyColored)
        {
            // if all the cells have been colored, return true
            if (uncoloredCells == 0)
            {
                return true;
            }
            // if they haven't,
            // get the next uncolored cell
            Cell nextUncolored = GetNextCell(previouslyColored);

            // for each available color for this uncolored cell (that isn't -1, whose index is 0)
            for (int color = 1; color < nextUncolored.Moves.Length; color++)
            {
                // if the color is indeed available,
                if (nextUncolored.Moves[color] == true)
                {

                    // List of affected nodes (those who have had their available colors altered)
                    List<Cell> affectedCells = new List<Cell>();
                    // search all nodes to see if they are adjacent to our current!
                    /*for (int row = 0; row < _gridSize; row++)
                    {
                        for (int col = 0; col < _gridSize; col++)
                        {
                            // if they are adjacent... (have an edge between them) AND have the color available
                            int val;
                            Cell neighbor = _nodes[row, col];
                            if (_graph.TryGetEdge(nextUncolored, neighbor, out val) && neighbor.Moves[color])
                            {
                                // Remove this color from their available moves and add them to the affected list
                                neighbor.RemoveMove(color);
                                affectedCells.Add(neighbor);
                            }
                        }
                    }*/

                    foreach(Edge<Cell, int> edge in _graph.OutgoingEdges(nextUncolored))
                    {
                        if (edge.Destination.Moves[color])
                        {
                            // Remove this color from their available moves and add them to the affected list
                            edge.Destination.RemoveMove(color);
                            affectedCells.Add(edge.Destination);
                        }
                    }
                    // change the Cell's value to that color
                    nextUncolored.Value = color;

                    // Recursively look for a solution in the resulting puzzle
                    bool solved = SolveSudoku(uncoloredCells - 1, nextUncolored);

                    if (solved)
                    {
                        return true;
                    }
                    // if we don't find a solution, add the color back to the affecte cells(?)
                    foreach (Cell affectedCell in affectedCells)
                    {
                        affectedCell.AddBackMove(color);
                    }

                    nextUncolored.Value = -1;
                }
            }
            return false;
        }

        /// <summary>
        /// Public version of the SolveSudoku method that simply calls on it's private counterpart
        /// </summary>
        /// <returns> Whether or not a solution could be found </returns>
        public bool SolveSudoku()
        {
            return SolveSudoku(GetNumUncolored(), null);
        }



    }
}
