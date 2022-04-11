using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

public class TodoList : Form {

    Components component = new Components();

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

        component.form.Text = "TodoList";
        component.form.FormBorderStyle = FormBorderStyle.FixedSingle;
        component.form.StartPosition = FormStartPosition.CenterScreen;
        component.form.Size = new Size(700, 700);
        component.form.BackColor = component.bgColor;
        component.form.Font = new Font("Consolas", 10);

    }

    private void AddComponents() {

        #region New Task Button
        component.newTaskButton.BackColor = component.bgColor;
        component.newTaskButton.ForeColor = component.textColor;
        component.newTaskButton.TabStop = false;
        component.newTaskButton.FlatStyle = FlatStyle.Flat;
        component.newTaskButton.FlatAppearance.BorderSize = 1;
        component.newTaskButton.Text = "New Task...";
        component.newTaskButton.AutoSize = true;
        component.newTaskButton.Location = new Point(20, 20);

        component.newTaskButton.Click += new EventHandler(NewTaskButton_Click);
        #endregion

        #region Add Task Panel
        component.panel.BackColor = component.bgColor;
        component.panel.Size = new Size(component.form.Width, 250);
        component.panel.BorderStyle = BorderStyle.FixedSingle;
        component.panel.Dock = DockStyle.Bottom;
        component.panel.Visible = false;
        #endregion

        #region Add Task Panel Heading
        component.addTaskHeading.Text = "Add New Task";
        component.addTaskHeading.ForeColor = component.textColor;
        component.addTaskHeading.BackColor = component.bgColor;
        component.addTaskHeading.TextAlign = HorizontalAlignment.Center;
        component.addTaskHeading.Multiline = true;
        component.addTaskHeading.ReadOnly = true;
        component.addTaskHeading.BorderStyle = BorderStyle.None;
        component.addTaskHeading.Dock = DockStyle.Top;
        component.addTaskHeading.Font = new Font("Consolas", 12, FontStyle.Underline);
        #endregion

        #region Task Title Heading
        component.tasktitleHeading.Text = "Task Title [Required]";
        component.tasktitleHeading.Width = component.form.Width;
        component.tasktitleHeading.ForeColor = component.textColor;
        component.tasktitleHeading.BackColor = component.bgColor;
        component.tasktitleHeading.Location = new Point(129, 37);
        component.tasktitleHeading.Multiline = true;
        component.tasktitleHeading.ReadOnly = true;
        component.tasktitleHeading.BorderStyle = BorderStyle.None;
        #endregion

        #region Task Title Textbox
        component.tasktitle.Size = new Size(400, 40);
        component.tasktitle.Location = new Point(130, 60);
        component.tasktitle.AcceptsReturn = false;
        component.tasktitle.AcceptsTab = false;
        component.tasktitle.Multiline = false;
        component.tasktitle.BorderStyle = BorderStyle.Fixed3D;
        #endregion

        #region Task Description Heading
        component.taskdescHeading.Text = "Task Description [Optional]";
        component.taskdescHeading.ForeColor = component.textColor;
        component.taskdescHeading.BackColor = component.bgColor;
        component.taskdescHeading.Location = new Point(129, 107);
        component.taskdescHeading.Width = component.form.Width;
        component.taskdescHeading.Multiline = true;
        component.taskdescHeading.ReadOnly = true;
        component.taskdescHeading.BorderStyle = BorderStyle.None;
        #endregion

        #region Task Description Textbox
        component.taskdesc.Size = new Size(400, 100);
        component.taskdesc.Location = new Point(130, 130);
        component.taskdesc.AcceptsReturn = false;
        component.taskdesc.AcceptsTab = false;
        component.taskdesc.BorderStyle = BorderStyle.Fixed3D;
        #endregion

        #region Add Task Button
        component.addTaskButton.BackColor = component.bgColor;
        component.addTaskButton.ForeColor = component.textColor;
        component.addTaskButton.TabStop = false;
        component.addTaskButton.FlatStyle = FlatStyle.Flat;
        component.addTaskButton.FlatAppearance.BorderSize = 1;
        component.addTaskButton.Text = "+ Add Task";
        component.addTaskButton.AutoSize = true;
        component.addTaskButton.Location = new Point(245, 170);

        component.addTaskButton.Click += new EventHandler(AddTaskButton_Click);
        #endregion

        #region Exit Button
        component.exitButton.BackColor = component.bgColor;
        component.exitButton.ForeColor = Color.White;
        component.exitButton.TabStop = false;
        component.exitButton.FlatStyle = FlatStyle.Flat;
        component.exitButton.FlatAppearance.BorderSize = 1;
        component.exitButton.Text = "Close";
        component.exitButton.Font = new Font("Consolas", 10, FontStyle.Bold);
        component.exitButton.AutoSize = true;
        component.exitButton.Location = new Point(345, 170);

        component.exitButton.MouseHover += new EventHandler(ExitButton_MouseHover);
        component.exitButton.MouseLeave += new EventHandler(ExitButton_MouseLeave);
        component.exitButton.Click += new EventHandler(ExitButton_Click);
        #endregion

        #region Empty Table Suggestion
        component.suggestion1.Text = "<-- Seems empty, click me to add an item";
        component.suggestion1.ForeColor = Color.DimGray;
        component.suggestion1.BackColor = component.bgColor;
        component.suggestion1.Location = new Point(130, 25);
        component.suggestion1.Width = 300;
        component.suggestion1.TabStop = false;
        component.suggestion1.Multiline = true;
        component.suggestion1.ReadOnly = true;
        component.suggestion1.BorderStyle = BorderStyle.None;
        #endregion

        component.panel.Controls.Add(component.addTaskHeading);
        component.panel.Controls.Add(component.tasktitleHeading);
        component.panel.Controls.Add(component.taskdescHeading);

        component.panel.Controls.Add(component.tasktitle);
        component.panel.Controls.Add(component.taskdesc);

        component.panel.Controls.Add(component.addTaskButton);
        component.panel.Controls.Add(component.exitButton);

        component.form.Controls.Add(component.newTaskButton);
        component.form.Controls.Add(component.suggestion1);
        component.form.Controls.Add(component.panel);

    }

    private void RenderWindow() {

        this.Close();
        component.form.ShowDialog();

    }
    #endregion

    #region Table
    private void SetupTable() {

        component.form.Controls.Add(component.table);

        component.table.ColumnCount = 4;

        component.table.Name = "Table";
        component.table.Location = new Point(20, 60);
        component.table.Width = 645;
        component.table.Height = 350;

        component.table.GridColor = component.bgColor;
        component.table.BackgroundColor = component.bgColor;
        component.table.BorderStyle = BorderStyle.None;

        component.table.RowHeadersVisible = false;
        component.table.ReadOnly = true;
        component.table.AllowUserToResizeColumns = false;
        component.table.AllowUserToResizeRows = false;
        component.table.AllowUserToAddRows = false;
        component.table.AllowDrop = false;

        string[] columns = { "S.No", "Task", "Description", "Click to remove" };
        for (int i = 0; i < columns.Length; i++) {
            component.table.Columns[i].Name = columns[i];
            component.table.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

    }

    private void UpdateTable() {

        string[] row = {component.ID, component.TASK, component.DESCRIPTION, "Delete"};
        component.table.Columns["Click to remove"].DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#E81022");

        component.table.Rows.Add(row);

        component.table.CellMouseEnter += new DataGridViewCellEventHandler(DeleteButton_MouseHover);
        component.table.CellMouseLeave += new DataGridViewCellEventHandler(DeleteButton_MouseLeave);
        component.table.CellClick += new DataGridViewCellEventHandler(DeleteButton_Click);
    }
    #endregion

    #region Event Handlers
    private void NewTaskButton_Click(object sender, EventArgs e) {

        component.panel.Visible = true;
        component.suggestion1.Visible = false;

    }

    private void AddTaskButton_Click(object sender, EventArgs e) {

        if (component.tasktitle.Text.ToString().Trim() == string.Empty) {
            MessageBox.Show("Warning", "Title is a required field");
            return;
        }

        if (component.taskdesc.Text == string.Empty) {
            component.taskdesc.Text = "No description";
        }

        component.ID = component.count.ToString();
        component.TASK = component.tasktitle.Text.ToString().Trim();
        component.DESCRIPTION = component.taskdesc.Text.ToString().Trim();

        UpdateTable();

        component.tasktitle.Text = string.Empty;
        component.taskdesc.Text = string.Empty;
        component.count++;

    }

    private void ExitButton_Click(object sender, EventArgs e) => component.panel.Visible = false;
    private void ExitButton_MouseHover(object sender, EventArgs e) => component.exitButton.BackColor = ColorTranslator.FromHtml("#E81022");
    private void ExitButton_MouseLeave(object sender, EventArgs e) => component.exitButton.BackColor = component.bgColor;

    private void DeleteButton_Click(object sender, DataGridViewCellEventArgs e) {

        string cell = component.table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        if (cell == "Delete") {

            component.table.Rows.RemoveAt(e.RowIndex);

        }

    }

    private void DeleteButton_MouseHover(object sender, DataGridViewCellEventArgs e) {

        string cell = component.table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        if (cell == "Delete") {
            component.table.Rows[e.RowIndex].Cells["Click to remove"].Style.BackColor = ColorTranslator.FromHtml("#E81022");
            component.table.Rows[e.RowIndex].Cells["Click to remove"].Style.ForeColor = Color.White;
        }

    }

    private void DeleteButton_MouseLeave(object sender, DataGridViewCellEventArgs e) {

        string cell = component.table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        if (cell == "Delete") {
            component.table.Rows[e.RowIndex].Cells["Click to remove"].Style.BackColor = Color.White;
            component.table.Rows[e.RowIndex].Cells["Click to remove"].Style.ForeColor = ColorTranslator.FromHtml("#E81022");
        }

    }
    #endregion

    #region Error Handlers
    static void ThreadException(object sender, ThreadExceptionEventArgs e) {
        return;
    }
    #endregion

}
