
namespace DefectsDMS
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.СохранитьОтчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.открытьОтчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.содержаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridViewSec = new System.Windows.Forms.DataGridView();
            this.filterBox = new System.Windows.Forms.GroupBox();
            this.gaussianBlurCheckBox = new System.Windows.Forms.CheckBox();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.labelSmooth = new System.Windows.Forms.Label();
            this.labelSegment = new System.Windows.Forms.Label();
            this.trackBarSmooth = new System.Windows.Forms.TrackBar();
            this.L = new System.Windows.Forms.CheckBox();
            this.B = new System.Windows.Forms.CheckBox();
            this.G = new System.Windows.Forms.CheckBox();
            this.R = new System.Windows.Forms.CheckBox();
            this.checkBoxSmooth = new System.Windows.Forms.CheckBox();
            this.checkBoxSegment = new System.Windows.Forms.CheckBox();
            this.checkBox3Histo = new System.Windows.Forms.CheckBox();
            this.checkBox2Defect = new System.Windows.Forms.CheckBox();
            this.checkBox1Negative = new System.Windows.Forms.CheckBox();
            this.trackBarSegment = new System.Windows.Forms.TrackBar();
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.textBoxTypeName = new System.Windows.Forms.TextBox();
            this.textBoxTypeDescr = new System.Windows.Forms.TextBox();
            this.buttonTypeAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxPhotoName = new System.Windows.Forms.TextBox();
            this.buttonPhotoAdd = new System.Windows.Forms.Button();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.fullView = new System.Windows.Forms.ToolStripButton();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSec)).BeginInit();
            this.filterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSmooth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSegment)).BeginInit();
            this.groupBoxType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1071, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.СохранитьОтчётToolStripMenuItem,
            this.toolStripMenuItem2,
            this.открытьОтчётToolStripMenuItem,
            this.toolStripMenuItem3,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // СохранитьОтчётToolStripMenuItem
            // 
            this.СохранитьОтчётToolStripMenuItem.Name = "СохранитьОтчётToolStripMenuItem";
            this.СохранитьОтчётToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.СохранитьОтчётToolStripMenuItem.Text = "Сохранить отчёт";
            this.СохранитьОтчётToolStripMenuItem.Click += new System.EventHandler(this.СохранитьОтчётToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(214, 6);
            // 
            // открытьОтчётToolStripMenuItem
            // 
            this.открытьОтчётToolStripMenuItem.Name = "открытьОтчётToolStripMenuItem";
            this.открытьОтчётToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.открытьОтчётToolStripMenuItem.Text = "Открыть последний отчёт";
            this.открытьОтчётToolStripMenuItem.Click += new System.EventHandler(this.открытьОтчётToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(214, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.содержаниеToolStripMenuItem,
            this.toolStripMenuItem1,
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // содержаниеToolStripMenuItem
            // 
            this.содержаниеToolStripMenuItem.Name = "содержаниеToolStripMenuItem";
            this.содержаниеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.содержаниеToolStripMenuItem.Text = "Содержание";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 6);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Location = new System.Drawing.Point(636, 52);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            this.dataGridViewMain.Size = new System.Drawing.Size(433, 434);
            this.dataGridViewMain.TabIndex = 1;
            this.dataGridViewMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMain_CellClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripLabel3,
            this.toolStripSeparator2,
            this.fullView});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1071, 26);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(65, 23);
            this.toolStripLabel1.Text = "Поиск:";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(150, 26);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.toolStripLabel3.Size = new System.Drawing.Size(203, 23);
            this.toolStripLabel3.Text = "Сброс строки поиска";
            this.toolStripLabel3.Click += new System.EventHandler(this.toolStripLabel3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // dataGridViewSec
            // 
            this.dataGridViewSec.AllowUserToAddRows = false;
            this.dataGridViewSec.AllowUserToDeleteRows = false;
            this.dataGridViewSec.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewSec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSec.Location = new System.Drawing.Point(636, 52);
            this.dataGridViewSec.Name = "dataGridViewSec";
            this.dataGridViewSec.ReadOnly = true;
            this.dataGridViewSec.Size = new System.Drawing.Size(433, 434);
            this.dataGridViewSec.TabIndex = 4;
            this.dataGridViewSec.Visible = false;
            this.dataGridViewSec.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSec_CellClick);
            // 
            // filterBox
            // 
            this.filterBox.Controls.Add(this.gaussianBlurCheckBox);
            this.filterBox.Controls.Add(this.confirmBtn);
            this.filterBox.Controls.Add(this.labelSmooth);
            this.filterBox.Controls.Add(this.labelSegment);
            this.filterBox.Controls.Add(this.trackBarSmooth);
            this.filterBox.Controls.Add(this.L);
            this.filterBox.Controls.Add(this.B);
            this.filterBox.Controls.Add(this.G);
            this.filterBox.Controls.Add(this.R);
            this.filterBox.Controls.Add(this.checkBoxSmooth);
            this.filterBox.Controls.Add(this.checkBoxSegment);
            this.filterBox.Controls.Add(this.checkBox3Histo);
            this.filterBox.Controls.Add(this.checkBox2Defect);
            this.filterBox.Controls.Add(this.checkBox1Negative);
            this.filterBox.Controls.Add(this.trackBarSegment);
            this.filterBox.Location = new System.Drawing.Point(12, 52);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(241, 434);
            this.filterBox.TabIndex = 5;
            this.filterBox.TabStop = false;
            // 
            // gaussianBlurCheckBox
            // 
            this.gaussianBlurCheckBox.AutoSize = true;
            this.gaussianBlurCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gaussianBlurCheckBox.Location = new System.Drawing.Point(6, 354);
            this.gaussianBlurCheckBox.Name = "gaussianBlurCheckBox";
            this.gaussianBlurCheckBox.Size = new System.Drawing.Size(141, 20);
            this.gaussianBlurCheckBox.TabIndex = 22;
            this.gaussianBlurCheckBox.Text = "Размытие Гаусса";
            this.gaussianBlurCheckBox.UseVisualStyleBackColor = true;
            // 
            // confirmBtn
            // 
            this.confirmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.confirmBtn.Location = new System.Drawing.Point(6, 392);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(228, 35);
            this.confirmBtn.TabIndex = 21;
            this.confirmBtn.Text = "Применить";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // labelSmooth
            // 
            this.labelSmooth.AutoSize = true;
            this.labelSmooth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSmooth.Location = new System.Drawing.Point(210, 271);
            this.labelSmooth.Name = "labelSmooth";
            this.labelSmooth.Size = new System.Drawing.Size(15, 16);
            this.labelSmooth.TabIndex = 20;
            this.labelSmooth.Text = "0";
            // 
            // labelSegment
            // 
            this.labelSegment.AutoSize = true;
            this.labelSegment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSegment.Location = new System.Drawing.Point(210, 194);
            this.labelSegment.Name = "labelSegment";
            this.labelSegment.Size = new System.Drawing.Size(15, 16);
            this.labelSegment.TabIndex = 19;
            this.labelSegment.Text = "0";
            // 
            // trackBarSmooth
            // 
            this.trackBarSmooth.Location = new System.Drawing.Point(6, 303);
            this.trackBarSmooth.Maximum = 256;
            this.trackBarSmooth.Name = "trackBarSmooth";
            this.trackBarSmooth.Size = new System.Drawing.Size(231, 45);
            this.trackBarSmooth.TabIndex = 18;
            this.trackBarSmooth.TickFrequency = 18;
            this.trackBarSmooth.ValueChanged += new System.EventHandler(this.trackBarSmooth_ValueChanged);
            // 
            // L
            // 
            this.L.AutoSize = true;
            this.L.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L.Location = new System.Drawing.Point(134, 147);
            this.L.Name = "L";
            this.L.Size = new System.Drawing.Size(34, 20);
            this.L.TabIndex = 17;
            this.L.Text = "L";
            this.L.UseVisualStyleBackColor = true;
            this.L.Visible = false;
            // 
            // B
            // 
            this.B.AutoSize = true;
            this.B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B.Location = new System.Drawing.Point(92, 147);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(36, 20);
            this.B.TabIndex = 16;
            this.B.Text = "B";
            this.B.UseVisualStyleBackColor = true;
            this.B.Visible = false;
            // 
            // G
            // 
            this.G.AutoSize = true;
            this.G.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.G.Location = new System.Drawing.Point(49, 147);
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(37, 20);
            this.G.TabIndex = 15;
            this.G.Text = "G";
            this.G.UseVisualStyleBackColor = true;
            this.G.Visible = false;
            // 
            // R
            // 
            this.R.AutoSize = true;
            this.R.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.R.Location = new System.Drawing.Point(6, 147);
            this.R.Name = "R";
            this.R.Size = new System.Drawing.Size(37, 20);
            this.R.TabIndex = 14;
            this.R.Text = "R";
            this.R.UseVisualStyleBackColor = true;
            this.R.Visible = false;
            // 
            // checkBoxSmooth
            // 
            this.checkBoxSmooth.AutoSize = true;
            this.checkBoxSmooth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSmooth.Location = new System.Drawing.Point(6, 267);
            this.checkBoxSmooth.Name = "checkBoxSmooth";
            this.checkBoxSmooth.Size = new System.Drawing.Size(115, 20);
            this.checkBoxSmooth.TabIndex = 13;
            this.checkBoxSmooth.Text = "Сглаживание";
            this.checkBoxSmooth.UseVisualStyleBackColor = true;
            // 
            // checkBoxSegment
            // 
            this.checkBoxSegment.AutoSize = true;
            this.checkBoxSegment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSegment.Location = new System.Drawing.Point(4, 193);
            this.checkBoxSegment.Name = "checkBoxSegment";
            this.checkBoxSegment.Size = new System.Drawing.Size(113, 20);
            this.checkBoxSegment.TabIndex = 12;
            this.checkBoxSegment.Text = "Сегментация";
            this.checkBoxSegment.UseVisualStyleBackColor = true;
            // 
            // checkBox3Histo
            // 
            this.checkBox3Histo.AutoSize = true;
            this.checkBox3Histo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox3Histo.Location = new System.Drawing.Point(4, 115);
            this.checkBox3Histo.Name = "checkBox3Histo";
            this.checkBox3Histo.Size = new System.Drawing.Size(112, 20);
            this.checkBox3Histo.TabIndex = 11;
            this.checkBox3Histo.Text = "Гистограмма";
            this.checkBox3Histo.UseVisualStyleBackColor = true;
            this.checkBox3Histo.CheckedChanged += new System.EventHandler(this.checkBox3Histo_CheckedChanged);
            // 
            // checkBox2Defect
            // 
            this.checkBox2Defect.AutoSize = true;
            this.checkBox2Defect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox2Defect.Location = new System.Drawing.Point(4, 63);
            this.checkBox2Defect.Name = "checkBox2Defect";
            this.checkBox2Defect.Size = new System.Drawing.Size(161, 20);
            this.checkBox2Defect.TabIndex = 10;
            this.checkBox2Defect.Text = "Выделение дефекта";
            this.checkBox2Defect.UseVisualStyleBackColor = true;
            // 
            // checkBox1Negative
            // 
            this.checkBox1Negative.AutoSize = true;
            this.checkBox1Negative.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1Negative.Location = new System.Drawing.Point(4, 19);
            this.checkBox1Negative.Name = "checkBox1Negative";
            this.checkBox1Negative.Size = new System.Drawing.Size(82, 20);
            this.checkBox1Negative.TabIndex = 6;
            this.checkBox1Negative.Text = "Негатив";
            this.checkBox1Negative.UseVisualStyleBackColor = true;
            // 
            // trackBarSegment
            // 
            this.trackBarSegment.Location = new System.Drawing.Point(6, 223);
            this.trackBarSegment.Maximum = 256;
            this.trackBarSegment.Name = "trackBarSegment";
            this.trackBarSegment.Size = new System.Drawing.Size(229, 45);
            this.trackBarSegment.TabIndex = 18;
            this.trackBarSegment.TickFrequency = 18;
            this.trackBarSegment.ValueChanged += new System.EventHandler(this.trackBarSegment_ValueChanged);
            // 
            // groupBoxType
            // 
            this.groupBoxType.Controls.Add(this.textBoxTypeName);
            this.groupBoxType.Controls.Add(this.textBoxTypeDescr);
            this.groupBoxType.Controls.Add(this.buttonTypeAdd);
            this.groupBoxType.Location = new System.Drawing.Point(1075, 246);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Size = new System.Drawing.Size(241, 180);
            this.groupBoxType.TabIndex = 6;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "Добавление нового типа";
            // 
            // textBoxTypeName
            // 
            this.textBoxTypeName.Location = new System.Drawing.Point(6, 35);
            this.textBoxTypeName.Name = "textBoxTypeName";
            this.textBoxTypeName.Size = new System.Drawing.Size(228, 20);
            this.textBoxTypeName.TabIndex = 8;
            this.textBoxTypeName.Text = "Название";
            this.textBoxTypeName.Enter += new System.EventHandler(this.textBoxTypeName_Enter);
            this.textBoxTypeName.Leave += new System.EventHandler(this.textBoxTypeName_Leave);
            // 
            // textBoxTypeDescr
            // 
            this.textBoxTypeDescr.Location = new System.Drawing.Point(6, 78);
            this.textBoxTypeDescr.Multiline = true;
            this.textBoxTypeDescr.Name = "textBoxTypeDescr";
            this.textBoxTypeDescr.Size = new System.Drawing.Size(228, 48);
            this.textBoxTypeDescr.TabIndex = 7;
            this.textBoxTypeDescr.Text = "Описание";
            this.textBoxTypeDescr.Enter += new System.EventHandler(this.textBoxDescr_Enter);
            this.textBoxTypeDescr.Leave += new System.EventHandler(this.textBoxDescr_Leave);
            // 
            // buttonTypeAdd
            // 
            this.buttonTypeAdd.Location = new System.Drawing.Point(83, 132);
            this.buttonTypeAdd.Name = "buttonTypeAdd";
            this.buttonTypeAdd.Size = new System.Drawing.Size(85, 37);
            this.buttonTypeAdd.TabIndex = 7;
            this.buttonTypeAdd.Text = "Добавить тип";
            this.buttonTypeAdd.UseVisualStyleBackColor = true;
            this.buttonTypeAdd.Click += new System.EventHandler(this.buttonTypeAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxType);
            this.groupBox1.Controls.Add(this.textBoxPhotoName);
            this.groupBox1.Controls.Add(this.buttonPhotoAdd);
            this.groupBox1.Location = new System.Drawing.Point(1075, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 166);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление нового фото";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Выберите тип дефекта:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Выберите тип фото"});
            this.comboBoxType.Location = new System.Drawing.Point(6, 43);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(228, 21);
            this.comboBoxType.TabIndex = 9;
            // 
            // textBoxPhotoName
            // 
            this.textBoxPhotoName.Location = new System.Drawing.Point(6, 88);
            this.textBoxPhotoName.Name = "textBoxPhotoName";
            this.textBoxPhotoName.Size = new System.Drawing.Size(228, 20);
            this.textBoxPhotoName.TabIndex = 8;
            this.textBoxPhotoName.Text = "Название";
            this.textBoxPhotoName.Enter += new System.EventHandler(this.textBoxPhotoName_Enter);
            this.textBoxPhotoName.Leave += new System.EventHandler(this.textBoxPhotoName_Leave);
            // 
            // buttonPhotoAdd
            // 
            this.buttonPhotoAdd.Location = new System.Drawing.Point(83, 114);
            this.buttonPhotoAdd.Name = "buttonPhotoAdd";
            this.buttonPhotoAdd.Size = new System.Drawing.Size(85, 37);
            this.buttonPhotoAdd.TabIndex = 7;
            this.buttonPhotoAdd.Text = "Добавить фото";
            this.buttonPhotoAdd.UseVisualStyleBackColor = true;
            this.buttonPhotoAdd.Click += new System.EventHandler(this.buttonPhotoAdd_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::DefectsDMS.Properties.Resources.btnbg;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(96, 23);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // fullView
            // 
            this.fullView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.fullView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fullView.Image = ((System.Drawing.Image)(resources.GetObject("fullView.Image")));
            this.fullView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fullView.Name = "fullView";
            this.fullView.Size = new System.Drawing.Size(113, 23);
            this.fullView.Text = "Расширенный вид";
            this.fullView.Click += new System.EventHandler(this.fullView_Click);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.Color.White;
            this.pictureBoxMain.Image = global::DefectsDMS.Properties.Resources.no_image;
            this.pictureBoxMain.Location = new System.Drawing.Point(259, 52);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(371, 434);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMain.TabIndex = 2;
            this.pictureBoxMain.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 490);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxType);
            this.Controls.Add(this.filterBox);
            this.Controls.Add(this.dataGridViewSec);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBoxMain);
            this.Controls.Add(this.dataGridViewMain);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "DefectsDMS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSec)).EndInit();
            this.filterBox.ResumeLayout(false);
            this.filterBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSmooth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSegment)).EndInit();
            this.groupBoxType.ResumeLayout(false);
            this.groupBoxType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьОтчётToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem содержаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView dataGridViewSec;
        private System.Windows.Forms.ToolStripMenuItem СохранитьОтчётToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.GroupBox filterBox;
        private System.Windows.Forms.TrackBar trackBarSegment;
        private System.Windows.Forms.CheckBox checkBoxSmooth;
        private System.Windows.Forms.CheckBox checkBoxSegment;
        private System.Windows.Forms.CheckBox checkBox3Histo;
        private System.Windows.Forms.CheckBox checkBox2Defect;
        private System.Windows.Forms.CheckBox checkBox1Negative;
        private System.Windows.Forms.CheckBox L;
        private System.Windows.Forms.CheckBox B;
        private System.Windows.Forms.CheckBox G;
        private System.Windows.Forms.CheckBox R;
        private System.Windows.Forms.TrackBar trackBarSmooth;
        private System.Windows.Forms.Label labelSmooth;
        private System.Windows.Forms.Label labelSegment;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.CheckBox gaussianBlurCheckBox;
        private System.Windows.Forms.ToolStripButton fullView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.Button buttonTypeAdd;
        private System.Windows.Forms.TextBox textBoxTypeDescr;
        private System.Windows.Forms.TextBox textBoxTypeName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxPhotoName;
        private System.Windows.Forms.Button buttonPhotoAdd;
        private System.Windows.Forms.Label label1;
    }
}

