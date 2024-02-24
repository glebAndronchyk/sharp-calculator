namespace calculator;

public partial class Form1
{
    private List<string> calculatorButtons = new();
    private DataGridView grid; 
    
    private void BuildGrid()
    {
        grid = new Grid();
        ((System.ComponentModel.ISupportInitialize)(grid)).BeginInit();
        SuspendLayout();
        grid.Parent = this;
        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        grid.Name = "calculator";
        grid.Size = new Size(200, 200);
        grid.TabIndex = 0;
        grid.ColumnHeadersVisible = false;
        grid.RowHeadersVisible = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        grid.CellClick += calculatorGrid_CellClick;
        ((System.ComponentModel.ISupportInitialize)(grid)).EndInit();
        ResumeLayout(false);
        grid.Visible = true;
        LoadGridData();
    }

    private void LoadGridData()
    {
        foreach (var keyValuePair in _invoker.GetCommands())
        {
            MessageBox.Show("2");
            calculatorButtons.Add("65");
        }

        grid.DataSource = calculatorButtons;
    }

    private void calculatorGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (sender != null)
        {
            DataGridViewCell cell = sender as DataGridViewCell;
            MessageBox.Show(grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }
    }
}