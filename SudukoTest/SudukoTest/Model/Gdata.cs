using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using MaterialSkin.Controls;
using static SudukoTest.Model.EnumColors;

namespace SudukoTest.Model
{
	public class Gdata
	{
        private SudukoGame _model;
		public string FileName { get; set; }
		public string UserName { get; set; }
		public string Level { get; set; }
        public string FolderName { get; set; }

        public int[,] GridData { get; set; }
		public Gdata(SudukoGame model) {
            this.FolderName = "assets";
            this._model = model;

        }


		public void saveData(DataGridView dataGridView1, int[,]gridData,int rowCount, int columnCount)
		{
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    DataGridViewCell cell = dataGridView1.Rows[i].Cells[j];
                    int cellValue = 0;
                    if (cell.Value != null && int.TryParse(cell.Value.ToString(), out cellValue))
                    {
                        gridData[i, j] = cellValue;
                    }
                    else
                    {
                        gridData[i, j] = 0;
                    }
                }
            }


        }

       public void verificationData(Gdata gameData,DataGridView dataGridView1, int[,] dataArray,MaterialMenuStrip materialMenuStrip1)
        {            
            if (gameData.GridData.GetLength(0) != 9 || gameData.GridData.GetLength(1) != 9)
            {
                MessageBox.Show("The Sudoku puzzle must be a 9x9 grid.", "Invalid Grid Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            for (var r = 0; r < gameData.GridData.GetLength(0); r++)
            {
                for (var c = 0; c < gameData.GridData.GetLength(1); c++)
                {
                    if (!IsValidValue(gameData.GridData[r, c]))
                    {
                        MessageBox.Show($"Invalid value at row {r + 1}, column {c + 1}. Values must be between 1 and 9.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; 
                    }
                }
            }
            for (var r = 0; r < gameData.GridData.GetLength(0); r++)
            {
                for (var c = 0; c < gameData.GridData.GetLength(1); c++)
                {
                    if (gameData.GridData[r, c] == 0)
                    {

                        dataGridView1.Rows[r].Cells[c].Value = null;

                    }
                    else
                    {
                        if (!_model.IsValid(dataArray, r, c, gameData.GridData[r, c]))
                        {
                            dataGridView1.Rows[r].Cells[c].Style.BackColor = EnumColors.GetColorFromEnum(CellValidationColor.Invalid);
                            dataGridView1.Rows[r].Cells[c].Value = gameData.GridData[r, c].ToString();
                            materialMenuStrip1.Items[1].Enabled = false;
                            materialMenuStrip1.Items[3].Enabled = false;
                           
                        }
                        else
                        {
                            dataGridView1.Rows[r].Cells[c].Value = gameData.GridData[r, c].ToString();
                            dataGridView1.Rows[r].Cells[c].Style.BackColor = EnumColors.GetColorFromEnum(CellValidationColor.Warning);
                            dataArray[r, c] = gameData.GridData[r, c];
                        }

                    }


                }
            }
        }
        private bool IsValidValue(int value)
        {
            return value >= 0 && value <= 9;

        }

    }
}
