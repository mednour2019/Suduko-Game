using System.Drawing;
using System.Security.Policy;
using System.Text.Json;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using SudukoTest.Model;
using System.IO;
using System.Windows.Media.Media3D;
using Microsoft.Windows.Themes;
using System.ComponentModel;
using static SudukoTest.Model.EnumColors;
using formD = System.Windows.Forms.FileDialog;
namespace SudukoTest
{
    public partial class sudukoGameView : MaterialForm

    {
        private readonly MaterialSkinManager materialSkinManager;
        private int size;
        private int[,] dataArray;
        private SudukoGame model;
        private Gdata fileData;
        public sudukoGameView()
        {
            InitializeComponent();
            model = new SudukoGame();
            fileData = new Gdata(model);
             dataArray = model.GetGrid();
            size = model.GetSize();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            setupMaterialDesign();
            setupGridView();

        }

        public void setupMaterialDesign()
        {
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo500,
                MaterialSkin.Primary.Indigo700, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.Pink200,
                MaterialSkin.TextShade.WHITE);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        }
        public void setupGridView()
        {
             dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
             dataGridView1.AllowUserToAddRows = false;
             dataGridView1.AllowUserToResizeColumns = false;
             dataGridView1.AllowUserToResizeRows = false;
             dataGridView1.RowCount = this.model.GetSize();
             dataGridView1.ColumnCount = this.model.GetSize(); ;
             foreach (DataGridViewColumn column in dataGridView1.Columns)
             {
                 column.Width = 70; 
             }
            dataGridView1.CellPainting += DataGridView1_CellPainting;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                using (Pen pen = new Pen(Color.Black, 2))
                {
                    if (e.RowIndex % 3 == 0 && e.RowIndex != 0)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black, 3), e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
                    }
                    if (e.ColumnIndex % 3 == 0 && e.ColumnIndex != 0)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black, 3), e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                    }
                }

                e.Handled = true;
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }
       
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.materialMenuStrip1.Enabled = true;
            var newValue = dataGridView1[e.ColumnIndex, e.RowIndex].Value;
            if (newValue != null) {
                
                if (int.TryParse(newValue.ToString(), out int result2) && result2!=0 && result2 == dataArray[e.RowIndex, e.ColumnIndex])
                {
                    return;
                }
                if (!int.TryParse(newValue.ToString(), out int result) || result < 1
                || result > 9 || newValue.ToString().Length >= 2)
                {
                    //MessageBox.Show("Invalid input! Only this cell can be edited until corrected.");
                    MessageBox.Show($"\"Invalid input! Only this cell can be edited until corrected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = EnumColors.GetColorFromEnum(CellValidationColor.Invalid);
                  this.model.MakeCellsReadOnlyExcept(e.RowIndex, e.ColumnIndex,this.dataGridView1);
                    this.materialMenuStrip1.Items[1].Enabled = false;
                    this.materialMenuStrip1.Items[3].Enabled = false;
                    return;
                }
                if (!model.IsValid(dataArray, e.RowIndex, e.ColumnIndex, int.Parse(newValue.ToString())))
                {

                    dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = EnumColors.GetColorFromEnum(CellValidationColor.Invalid);
                   // MessageBox.Show("Number exists in the same row, column, or subgrid!");
                    MessageBox.Show($"This number cannot be placed here as it already exists in the same row, column, or 3x3 box. Please try a different number (1-9).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.model.MakeCellsReadOnlyExcept(e.RowIndex, e.ColumnIndex, this.dataGridView1);
                    this.materialMenuStrip1.Items[1].Enabled = false;
                    this.materialMenuStrip1.Items[3].Enabled = false;
                    return;

                }
                dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = EnumColors.GetColorFromEnum(CellValidationColor.Valid);
               this.model.EnableAllCells(this.dataGridView1);
                UpdateArrayFromDataGridView(e.ColumnIndex, e.RowIndex);
                this.materialMenuStrip1.Items[1].Enabled = true;
                this.materialMenuStrip1.Items[3].Enabled = true;

            }
            else
            {
                dataArray[e.RowIndex, e.ColumnIndex] = 0;
                if(dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor == EnumColors.GetColorFromEnum(CellValidationColor.Invalid))
                {
                   this.model.EnableAllCells(this.dataGridView1);
                    dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = EnumColors.GetColorFromEnum(CellValidationColor.Valid);
                    this.materialMenuStrip1.Items[1].Enabled = true;
                    this.materialMenuStrip1.Items[3].Enabled = true;
                }
               
            }
            /* if (newValue == null )
             {
                 this.materialMenuStrip1.Enabled = true;

                 return;
             }
           else  if (!int.TryParse(newValue.ToString(), out int result) ||
                result < 1 || result > 9 ||
                (newValue.ToString().Length > 1 && newValue.ToString().StartsWith("0")))

             {
                 MessageBox.Show("Invalid input! Only this cell can be edited until corrected.");
                 dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.OrangeRed;
                 MakeCellsReadOnlyExcept(e.RowIndex, e.ColumnIndex);

                // return;
             }
             else
             if (int.Parse(newValue.ToString()) == dataArray[e.RowIndex, e.ColumnIndex])
             {
                 this.materialMenuStrip1.Enabled = true;

                 return;
             }

             else if (!model.IsValid(dataArray, e.RowIndex, e.ColumnIndex, int.Parse(newValue.ToString())))
             {

                 dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.OrangeRed;
                 MessageBox.Show("Number exists in the same row, column, or subgrid!");
                 MakeCellsReadOnlyExcept(e.RowIndex, e.ColumnIndex);

             }

             else
             {
                 dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                 EnableAllCells();
                 UpdateArrayFromDataGridView(e.ColumnIndex, e.RowIndex);


             }

             this.materialMenuStrip1.Enabled = true;*/

        }
       
       
        private void UpdateArrayFromDataGridView(int col, int row)
        {
            this.model.updateArrayFromDataGridView(col, row, dataGridView1, dataArray);
          
        }

        private void UpdateDataGridViewFromArray()
        {
            this.model.updateDatagridViewFromArray(dataArray, dataGridView1);
            if (dataArray.Cast<int>().Contains(0))
            {
               // MessageBox.Show($"you can't solve this sduko because the input is wrong try to reset game", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show($"Cannot solve this puzzle. Although numbers don't conflict directly, their placement blocks all possible solutions. Please revise.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void LoadJsonFile(string filePath)
        {

            try
            {
                var json = File.ReadAllText(filePath);
                var gameData = JsonConvert.DeserializeObject<Gdata>(json);
                this.fileData.verificationData(gameData, dataGridView1, dataArray, materialMenuStrip1);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading file: " + ex.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

       /* private void SaveGridToJson(string filePath)
        {
            try
            {
                int[,] grid = new int[9, 9];
                for (var r = 0; r < 9; r++)
                {
                    for (var c = 0; c < 9; c++)
                    {
                        var cellValue = dataGridView1.Rows[r].Cells[c].Value;
                        grid[r, c] = cellValue != null && int.TryParse(cellValue.ToString(), out int result) ? result : 0;
                    }
                }
                var json = JsonConvert.SerializeObject(grid);
                File.WriteAllText(filePath, json);
                MessageBox.Show("Grid saved successfully!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       */
        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult saveResult = MessageBox.Show("if yu click yes yu loose you current data ?", "Load File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (saveResult == DialogResult.Yes)
            {

                this.model.resetGame(dataGridView1, dataArray, this.materialMenuStrip1);
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                    openFileDialog.Title = "Open Sudoku Puzzle File";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var filePath = openFileDialog.FileName;
                        if (System.IO.Path.GetExtension(filePath).Equals(".json", StringComparison.OrdinalIgnoreCase))
                        {
                            LoadJsonFile(filePath);
                        }
                        else
                        {
                            MessageBox.Show("Please select a valid JSON file.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }

            }
            else if (saveResult == DialogResult.No)
            {
               
            }
        }

        public void processSave()
        {
            var savesFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileData.FolderName);
            if (!Directory.Exists(savesFolderPath))
            {
                Directory.CreateDirectory(savesFolderPath);
            }
            var rowCount = dataGridView1.Rows.Count;
            var columnCount = dataGridView1.Columns.Count;
            var gridData = new int[rowCount, columnCount];
            this.fileData.saveData(dataGridView1, gridData, rowCount, columnCount);
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = savesFolderPath;
                saveFileDialog.Filter = "JSON files (*.json)|*.json";
                saveFileDialog.DefaultExt = "json";
                saveFileDialog.FileName = $"GridData_{DateTime.Now:yyyyMMdd_HHmmss}.json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var gameData = new Gdata(model);
                    gameData.FileName = Path.GetFileName(saveFileDialog.FileName);
                    gameData.UserName = "Jhon";
                    gameData.Level = "Beginner";
                    gameData.GridData = gridData;
                    var jsonString = JsonConvert.SerializeObject(gameData, Formatting.Indented);
                    File.WriteAllText(saveFileDialog.FileName, jsonString);
                    MessageBox.Show($"Data saved to {saveFileDialog.FileName}", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isGridNull = dataGridView1.Rows.Cast<DataGridViewRow>()
                    .SelectMany(row => row.Cells.Cast<DataGridViewCell>())
                    .All(cell => cell.Value == null || cell.Value == DBNull.Value || string.IsNullOrWhiteSpace(cell.Value.ToString()));
            if (isGridNull) {
                MessageBox.Show($"Saving empty grid is not allowed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!this.model.verifyGridContainsInvalidCell(this.dataGridView1))
            {
                this.processSave();
            }
            else
            {
                MessageBox.Show($"You have invalid cells - please correct them before saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rESETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.model.resetGame(dataGridView1, dataArray,this.materialMenuStrip1);

        }

        private void sOLVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if(!model.verifyGridContainsInvalidCell(this.dataGridView1)) {
                model.Solve(dataArray, 0, 0);
                UpdateDataGridViewFromArray();
                this.dataGridView1.ReadOnly = true;
           }
            else {
                MessageBox.Show($"Cannot solve puzzle: Invalid entries detected. Please correct all errors before using the solve.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.materialMenuStrip1.Enabled = false;

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isGridNull = dataGridView1.Rows.Cast<DataGridViewRow>()
                   .SelectMany(row => row.Cells.Cast<DataGridViewCell>())
                   .All(cell => cell.Value == null || cell.Value == DBNull.Value || string.IsNullOrWhiteSpace(cell.Value.ToString()));
            if (isGridNull || this.model.verifyGridContainsInvalidCell(this.dataGridView1)) {
                Application.Exit();
            }
            else
            {

                DialogResult saveResult = MessageBox.Show("Do you want to save your progress before exiting?", "Save Game", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (saveResult == DialogResult.Yes)
                {
                    
                    this.processSave();  
                    Application.Exit();
                }
                else if (saveResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            
    
        }
    }
}



