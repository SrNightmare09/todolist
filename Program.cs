using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

public class TodoList : Form {

    private Form form = new Form();
    private Panel panel = new Panel();

    private Button newTaskButton = new Button();
    private Button addTaskButton = new Button();
    private Button exitButton = new Button();

    private TextBox addTaskHeading = new TextBox();
    private TextBox tasktitle = new TextBox();
    private TextBox tasktitleHeading = new TextBox();
    private TextBox taskdescHeading = new TextBox();
    private TextBox taskdesc = new TextBox();
    private TextBox suggestion1 = new TextBox(); // wow, such empty

    private DataGridView table = new DataGridView();

    private Color bgColor = ColorTranslator.FromHtml("#0F1821");
    private Color textColor = ColorTranslator.FromHtml("#20C68D");

    private int count = 1;

    public string ID { get; set; }
    public string TASK { get; set; }
    public string DESCRIPTION { get; set; }

    [STAThread]
    static void Main () {
        Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);
        Application.Run(new TodoList());
    }

    public TodoList() {
        SetupWindow();
        AddComponents();
        SetupTable();
        RenderWindow();
        UpdateTable();
    }

    #region Rendering
    private void SetupWindow() {

        form.Text = "TodoList";
        form.FormBorderStyle = FormBorderStyle.FixedSingle;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.Size = new Size(700, 700);
        form.BackColor = bgColor;
        form.Font = new Font("Consolas", 10);

    }

    private void AddComponents() {

        #region New Task Button
        newTaskButton.BackColor = bgColor;
        newTaskButton.ForeColor = textColor;
        newTaskButton.TabStop = false;
        newTaskButton.FlatStyle = FlatStyle.Flat;
        newTaskButton.FlatAppearance.BorderSize = 1;
        newTaskButton.Text = "New Task...";
        newTaskButton.AutoSize = true;
        newTaskButton.Location = new Point(20, 20);

        newTaskButton.Click += new EventHandler(New_Task);
        #endregion

        #region Add Task Panel
        panel.BackColor = bgColor;
        panel.Size = new Size(form.Width, 250);
        panel.BorderStyle = BorderStyle.FixedSingle;
        panel.Dock = DockStyle.Bottom;
        panel.Visible = false;
        #endregion

        #region Add Task Panel Heading
        addTaskHeading.Text = "Add New Task";
        addTaskHeading.ForeColor = textColor;
        addTaskHeading.BackColor = bgColor;
        addTaskHeading.TextAlign = HorizontalAlignment.Center;
        addTaskHeading.Multiline = true;
        addTaskHeading.ReadOnly = true;
        addTaskHeading.BorderStyle = BorderStyle.None;
        addTaskHeading.Dock = DockStyle.Top;
        addTaskHeading.Font = new Font("Consolas", 12, FontStyle.Underline);
        #endregion

        #region Task Title Heading
        tasktitleHeading.Text = "Task Title [Required]";
        tasktitleHeading.Width = form.Width;
        tasktitleHeading.ForeColor = textColor;
        tasktitleHeading.BackColor = bgColor;
        tasktitleHeading.Location = new Point(129, 37);
        tasktitleHeading.Multiline = true;
        tasktitleHeading.ReadOnly = true;
        tasktitleHeading.BorderStyle = BorderStyle.None;
        #endregion

        #region Task Title Textbox
        tasktitle.Size = new Size(400, 40);
        tasktitle.Location = new Point(130, 60);
        tasktitle.AcceptsReturn = false;
        tasktitle.AcceptsTab = false;
        tasktitle.Multiline = false;
        tasktitle.BorderStyle = BorderStyle.Fixed3D;
        #endregion

        #region Task Description Heading
        taskdescHeading.Text = "Task Description [Optional]";
        taskdescHeading.ForeColor = textColor;
        taskdescHeading.BackColor = bgColor;
        taskdescHeading.Location = new Point(129, 107);
        taskdescHeading.Width = form.Width;
        taskdescHeading.Multiline = true;
        taskdescHeading.ReadOnly = true;
        taskdescHeading.BorderStyle = BorderStyle.None;
        #endregion

        #region Task Description Textbox
        taskdesc.Size = new Size(400, 100);
        taskdesc.Location = new Point(130, 130);
        taskdesc.AcceptsReturn = false;
        taskdesc.AcceptsTab = false;
        taskdesc.BorderStyle = BorderStyle.Fixed3D;
        #endregion

        #region Add Task Button
        addTaskButton.BackColor = bgColor;
        addTaskButton.ForeColor = textColor;
        addTaskButton.TabStop = false;
        addTaskButton.FlatStyle = FlatStyle.Flat;
        addTaskButton.FlatAppearance.BorderSize = 1;
        addTaskButton.Text = "+ Add Task";
        addTaskButton.AutoSize = true;
        addTaskButton.Location = new Point(245, 170);

        addTaskButton.Click += new EventHandler(Add_Task);
        #endregion

        #region Exit Button
        exitButton.BackColor = bgColor;
        exitButton.ForeColor = Color.White;
        exitButton.TabStop = false;
        exitButton.FlatStyle = FlatStyle.Flat;
        exitButton.FlatAppearance.BorderSize = 1;
        exitButton.Text = "Close";
        exitButton.Font = new Font("Consolas", 10, FontStyle.Bold);
        exitButton.AutoSize = true;
        exitButton.Location = new Point(345, 170);

        exitButton.MouseHover += new EventHandler(ExitButton_MouseHover);
        exitButton.MouseLeave += new EventHandler(ExitButton_MouseLeave);
        exitButton.Click += new EventHandler(ExitButton_Click);
        #endregion

        #region Empty Table Suggestion
        suggestion1.Text = "<-- Seems empty, click me to add an item";
        suggestion1.ForeColor = Color.DimGray;
        suggestion1.BackColor = bgColor;
        suggestion1.Location = new Point(130, 25);
        suggestion1.Width = 300;
        suggestion1.TabStop = false;
        suggestion1.Multiline = true;
        suggestion1.ReadOnly = true;
        suggestion1.BorderStyle = BorderStyle.None;
        #endregion

        panel.Controls.Add(addTaskHeading);
        panel.Controls.Add(tasktitleHeading);
        panel.Controls.Add(taskdescHeading);

        panel.Controls.Add(tasktitle);
        panel.Controls.Add(taskdesc);

        panel.Controls.Add(addTaskButton);
        panel.Controls.Add(exitButton);

        form.Controls.Add(newTaskButton);
        form.Controls.Add(suggestion1);
        form.Controls.Add(panel);

    }

    private void RenderWindow() {

        this.Close();
        form.ShowDialog();

    }
    #endregion

    private void SetupTable() {

        form.Controls.Add(table);

        table.ColumnCount = 4;

        table.Name = "Table";
        table.Location = new Point(20, 60);
        table.Width = 645;
        table.Height = 350;

        table.GridColor = bgColor;
        table.BackgroundColor = bgColor;
        table.BorderStyle = BorderStyle.None;

        table.RowHeadersVisible = false;
        table.ReadOnly = true;
        table.AllowUserToResizeColumns = false;
        table.AllowUserToResizeRows = false;
        table.AllowUserToAddRows = false;
        table.AllowDrop = false;

        string[] columns = { "S.No", "Task", "Description", "Click to remove" };
        for (int i = 0; i < columns.Length; i++) {
            table.Columns[i].Name = columns[i];
            table.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

    }

    private void UpdateTable() {

        string[] row = {ID, TASK, DESCRIPTION, "Delete"};
        table.Columns["Click to remove"].DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#E81022");

        table.Rows.Add(row);

        table.CellMouseEnter += new DataGridViewCellEventHandler(Delete_MouseHover);
        table.CellMouseLeave += new DataGridViewCellEventHandler(Delete_MouseLeave);
    }

    private void New_Task(object sender, EventArgs e) {

        panel.Visible = true;
        suggestion1.Visible = false;

    }

    private void Add_Task(object sender, EventArgs e) {

        if (tasktitle.Text.ToString().Trim() == string.Empty) {
            MessageBox.Show("Warning", "Title is a required field");
            return;
        }

        if (taskdesc.Text == string.Empty) {
            taskdesc.Text = "No description";
        }

        ID = count.ToString();
        TASK = tasktitle.Text.ToString().Trim();
        DESCRIPTION = taskdesc.Text.ToString().Trim();

        UpdateTable();

        tasktitle.Text = string.Empty;
        taskdesc.Text = string.Empty;
        count++;

    }

    private void ExitButton_MouseHover(object sender, EventArgs e) => exitButton.BackColor = ColorTranslator.FromHtml("#E81022");
    private void ExitButton_MouseLeave(object sender, EventArgs e) => exitButton.BackColor = bgColor;
    private void ExitButton_Click(object sender, EventArgs e) => panel.Visible = false;

    private void Delete_MouseHover(object sender, DataGridViewCellEventArgs e) {

        string cell = table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        if (cell == "Delete") {
            table.Rows[e.RowIndex].Cells["Click to remove"].Style.BackColor = ColorTranslator.FromHtml("#E81022");
            table.Rows[e.RowIndex].Cells["Click to remove"].Style.ForeColor = Color.White;
        }

    }

    private void Delete_MouseLeave(object sender, DataGridViewCellEventArgs e) {

        string cell = table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        if (cell == "Delete") {
            table.Rows[e.RowIndex].Cells["Click to remove"].Style.BackColor = Color.White;
            table.Rows[e.RowIndex].Cells["Click to remove"].Style.ForeColor = ColorTranslator.FromHtml("#E81022");
        }

    }

    static void ThreadException(object sender, ThreadExceptionEventArgs e) {
        return;
    }

}
