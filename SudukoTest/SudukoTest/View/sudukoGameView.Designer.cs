namespace SudukoTest
{
	partial class sudukoGameView
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sudukoGameView));
            dataGridView1 = new DataGridView();
            openFileDialog1 = new OpenFileDialog();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            materialMenuStrip1 = new MaterialSkin.Controls.MaterialMenuStrip();
            checkToolStripMenuItem = new ToolStripMenuItem();
            testToolStripMenuItem = new ToolStripMenuItem();
            rESETToolStripMenuItem = new ToolStripMenuItem();
            sOLVEToolStripMenuItem = new ToolStripMenuItem();
            eXITToolStripMenuItem = new ToolStripMenuItem();
            imageList1 = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            materialMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Emoji", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(98, 157);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 10;
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.Size = new Size(671, 457);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
            dataGridView1.CellClick += dataGridView1_CellClick_1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabControl1.ImageList = imageList1;
            tabControl1.Location = new Point(211, 69);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(450, 86);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.WhiteSmoke;
            tabPage1.Controls.Add(materialMenuStrip1);
            tabPage1.Font = new Font("Simplified Arabic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage1.ImageKey = "pastime.png";
            tabPage1.Location = new Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(442, 43);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Sudoku Game";
            // 
            // materialMenuStrip1
            // 
            materialMenuStrip1.BackColor = Color.FromArgb(55, 71, 79);
            materialMenuStrip1.BackgroundImageLayout = ImageLayout.Center;
            materialMenuStrip1.Depth = 0;
            materialMenuStrip1.Font = new Font("Roboto", 10F);
            materialMenuStrip1.ImeMode = ImeMode.Off;
            materialMenuStrip1.Items.AddRange(new ToolStripItem[] { checkToolStripMenuItem, testToolStripMenuItem, rESETToolStripMenuItem, sOLVEToolStripMenuItem, eXITToolStripMenuItem });
            materialMenuStrip1.Location = new Point(3, 3);
            materialMenuStrip1.Margin = new Padding(0, 0, 2, 0);
            materialMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            materialMenuStrip1.Name = "materialMenuStrip1";
            materialMenuStrip1.Size = new Size(436, 32);
            materialMenuStrip1.TabIndex = 6;
            materialMenuStrip1.Text = "materialMenuStrip1";
            materialMenuStrip1.ItemClicked += materialMenuStrip1_ItemClicked;
            // 
            // checkToolStripMenuItem
            // 
            checkToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkToolStripMenuItem.Image = (Image)resources.GetObject("checkToolStripMenuItem.Image");
            checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            checkToolStripMenuItem.Size = new Size(89, 28);
            checkToolStripMenuItem.Text = "LOAD";
            checkToolStripMenuItem.Click += checkToolStripMenuItem_Click;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.Image = Properties.Resources.save;
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(70, 28);
            testToolStripMenuItem.Text = "SAVE";
            testToolStripMenuItem.Click += testToolStripMenuItem_Click;
            // 
            // rESETToolStripMenuItem
            // 
            rESETToolStripMenuItem.Image = (Image)resources.GetObject("rESETToolStripMenuItem.Image");
            rESETToolStripMenuItem.Name = "rESETToolStripMenuItem";
            rESETToolStripMenuItem.Size = new Size(77, 28);
            rESETToolStripMenuItem.Text = "RESET";
            rESETToolStripMenuItem.Click += rESETToolStripMenuItem_Click;
            // 
            // sOLVEToolStripMenuItem
            // 
            sOLVEToolStripMenuItem.Image = (Image)resources.GetObject("sOLVEToolStripMenuItem.Image");
            sOLVEToolStripMenuItem.Name = "sOLVEToolStripMenuItem";
            sOLVEToolStripMenuItem.Size = new Size(79, 28);
            sOLVEToolStripMenuItem.Text = "SOLVE";
            sOLVEToolStripMenuItem.TextAlign = ContentAlignment.MiddleRight;
            sOLVEToolStripMenuItem.Click += sOLVEToolStripMenuItem_Click;
            // 
            // eXITToolStripMenuItem
            // 
            eXITToolStripMenuItem.Image = Properties.Resources._switch;
            eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            eXITToolStripMenuItem.Size = new Size(65, 28);
            eXITToolStripMenuItem.Text = "EXIT";
            eXITToolStripMenuItem.Click += eXITToolStripMenuItem_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "suduku.png");
            imageList1.Images.SetKeyName(1, "4058168141_ee18c9aafa.jpg");
            imageList1.Images.SetKeyName(2, "suduku.jpeg");
            imageList1.Images.SetKeyName(3, "pastime.png");
            imageList1.Images.SetKeyName(4, "loading.png");
            // 
            // sudukoGameView
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(840, 672);
            Controls.Add(dataGridView1);
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI Emoji", 9F);
            ImeMode = ImeMode.Off;
            MinimumSize = new Size(2, 2);
            Name = "sudukoGameView";
            ShowIcon = false;
            ShowInTaskbar = false;
            Sizable = false;
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.Manual;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            materialMenuStrip1.ResumeLayout(false);
            materialMenuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
		private OpenFileDialog openFileDialog1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ImageList imageList1;
        private MaterialSkin.Controls.MaterialMenuStrip materialMenuStrip1;
        private ToolStripMenuItem checkToolStripMenuItem;
        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem rESETToolStripMenuItem;
        private ToolStripMenuItem sOLVEToolStripMenuItem;
        private ToolStripMenuItem eXITToolStripMenuItem;
    }
}
