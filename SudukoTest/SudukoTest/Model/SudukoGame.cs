using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static SudukoTest.Model.EnumColors;

namespace SudukoTest.Model
{
    public  class SudukoGame
    {

        public const int Size = 9;
        public int[,] grid;
        public const int subGridIndex= 3;

        public SudukoGame()
        {
            grid = new int[Size, Size];
        }
     
        public int GetValue(int row, int col)
        {
            return grid[row, col];
        }

        public void SetValue(int row, int col, int value)
        {
           grid[row, col] = value;
        }
        public bool IsValid(int[,] grid, int row, int col, int num)
        {
            for (var x = 0; x < Size; x++)
            {
                if (grid[row, x] == num || grid[x, col] == num)

                    return false;
            }
            var startRow = row - row % 3;
            var startCol = col - col % 3;
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (grid[i + startRow, j + startCol] == num)
                        return false;
                }
            }
            return true;
        }
       public  bool Solve(int[,] grid, int r, int c)
        {
            if (r == 9)
            {
                return true;
            }

            if (c == 9)
            {
                return Solve(grid, r + 1, 0);
            }

            if (grid[r, c] != 0)
            {
                return Solve(grid, r, c + 1);
            }

            for (var k = 1; k <= 9; k++)
            {
                if (IsValid(grid, r, c, k))
                {
                    grid[r, c] = k;

                    if (Solve(grid, r, c + 1))
                    {
                        return true;
                    }

                    grid[r, c] = 0;
                }
            }

            return false;
        }
       
        public int[,] GetGrid()
        {
            return (int[,])grid;
        }
        public int GetSize()
        {
            return Size;
        }
        public void updateArrayFromDataGridView(int col,int row,DataGridView dataGridView1, int[,] dataArray)
        {
            var cellValue = dataGridView1[col, row].Value;
            if (cellValue != null && int.TryParse(cellValue.ToString(), out int parsedValue))
            {
                dataArray[row, col] = parsedValue;
            }
        }
        public void updateDatagridViewFromArray(int[,] dataArray, DataGridView dataGridView1)
        {
            var rowCount = dataArray.GetLength(0);
            var colCount = dataArray.GetLength(1);

            dataGridView1.Rows.Clear(); 

            for (var i = 0; i < rowCount; i++)
            {
                object[] row = new object[colCount];
                for (var j = 0; j < colCount; j++)
                {
                    row[j] = dataArray[i, j];
                }
                dataGridView1.Rows.Add(row);
            }
        
        }
        public void resetGame(DataGridView dataGridView1 , int[,] dataArray,MaterialMenuStrip materialMenuStrip1)
        {
            var rowCount = dataGridView1.Rows.Count;
            var columnCount = dataGridView1.Columns.Count;
            for (var r = 0; r < rowCount; r++)
            {
                for (var c = 0; c < columnCount; c++)
                {
                    dataGridView1.Rows[r].Cells[c].Value = null;
                    dataGridView1.Rows[r].Cells[c].ReadOnly = false;
                    dataGridView1.Rows[r].Cells[c].Style.BackColor = Color.White;
                    dataArray[r, c] = 0;
                }
            }

            dataGridView1.ReadOnly = false;
            materialMenuStrip1.Enabled = true;
            materialMenuStrip1.Items[1].Enabled = true;
            materialMenuStrip1.Items[3].Enabled = true;

        }
       public bool  verifyGridContainsInvalidCell(DataGridView dataGridView1)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Style.BackColor == EnumColors.GetColorFromEnum(CellValidationColor.Invalid))
                    {
                        return true; 
                    }
                }
            }
            return false; 

        }
        public void EnableAllCells(DataGridView dataGridView1)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ReadOnly = false;
                }
            }
        }
        public void MakeCellsReadOnlyExcept(int rowIndex, int colIndex,DataGridView dataGridView1)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ReadOnly = !(cell.ColumnIndex == colIndex && cell.RowIndex == rowIndex);
                }
            }
        }
    }
}
