/* 
 * Sudoku.cs
 * Author: Nick Ruffini
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        Cell[,] _nodes;

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
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ConnectGraph()
        {

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
            else
            {
                // create an edge between the 2 Cells with a weight of 0
                _graph.AddEdge(source, destination, 0);

                // if one of the cell's has a value other than default (-1), remove that value from
                // it's Moves array
                if (source.Value != -1)
                {
                    destination.RemoveMove(source.Value);
                }
                else if (destination.Value != -1)
                {
                    source.RemoveMove(destination.Value);
                }
            }

            return true;
        }

        //-------------------------------------------------------------------------------------------

        /// <summary>
        /// Tries to add edges between the parameter cell and every other cell in the 
        /// same row, using the ConnectEdge method.
        /// </summary>
        /// <param name="cell"> Cell we are using as the source node to add edges to </param>
        /// <returns> Whether or not it could successfully add all the edges</returns>
        private bool ConnectRow(Cell source)
        {
            // flag for whether all the edges could be added
            bool allAdded = true;

            for (int i = 0; i < _gridSize; i++)
            {
                // Makes sure we don't compare the same cell to itself, which will always return false
                if (i != source.Col)
                {
                    bool added = ConnectEdge(source, _nodes[source.Row, i]);
                    if (added == false)
                    {
                        allAdded = false;
                    }
                }
            }

            if (allAdded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Tries to add edges between the parameter cell and every other cell in the same column,
        /// using the ConnectEdge method.
        /// </summary>
        /// <param name="source"> Cell we are using to connect all other cells in column </param>
        /// <returns> Whether or not all the edges could be added </returns>
        private bool ConnectColumn(Cell source)
        {
            // flag for whether all the edges could be added
            bool allAdded = true;

            for (int i = 0; i < _gridSize; i++)
            {
                // Makes sure we don't compare the same cell to itself, which will always return false
                if (i != source.Row)
                {
                    bool added = ConnectEdge(source, _nodes[i, source.Col]);
                    if (added == false)
                    {
                        allAdded = false;
                    }
                }
            }

            if (allAdded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Tries to add edges between the parameter cell and every other cell in the same
        /// 3x3 grid, using the ConnectEdge method.
        /// </summary>
        /// <param name="source"> Cell we are trying to link to all other cells in it's 3x3 </param>
        /// <returns> Whether or not all the cell's could be linked </returns>
        private bool ConnectSmallGrid(Cell source)
        {
            bool allAdded = true;
            source.
            
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




    }
}
