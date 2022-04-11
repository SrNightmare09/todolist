using System.Windows.Forms;
using System.Drawing;

public class Components {

    public Form form = new Form();
    public Panel panel = new Panel();

    public Button newTaskButton = new Button();
    public Button addTaskButton = new Button();
    public Button exitButton = new Button();

    public TextBox addTaskHeading = new TextBox();
    public TextBox tasktitle = new TextBox();
    public TextBox tasktitleHeading = new TextBox();
    public TextBox taskdescHeading = new TextBox();
    public TextBox taskdesc = new TextBox();
    public TextBox suggestion1 = new TextBox(); // wow, such empty

    public DataGridView table = new DataGridView();

    public Color bgColor = ColorTranslator.FromHtml("#0F1821");
    public Color textColor = ColorTranslator.FromHtml("#20C68D");

    public int count = 1;

    public string ID = string.Empty;
    public string TASK = string.Empty;
    public string DESCRIPTION = string.Empty;

}