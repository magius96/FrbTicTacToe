using System.Collections.Generic;

namespace FrbTicTacToe.Unmanaged_Code
{
    public class TicTacToeLine
    {
        public List<GridSpace> Cells  = new List<GridSpace>();

        public TicTacToeLine(GridSpace cell1, GridSpace cell2, GridSpace cell3)
        {
            Cells.Add(cell1);
            Cells.Add(cell2);
            Cells.Add(cell3);
        }

        public int FindCellIndex(int x, int y)
        {
            for(var index = 0;index < Cells.Count;index++)
            {
                if (Cells[index].X == x && Cells[index].Y == y) return index;
            }
            return -1;
        }
    }
}
