﻿namespace BlazorApp1.domain
{
    public enum CellState
    {
        Blank, X, O
    }

    public class Board
    {
        public int ColumCount => 3;
        public int RowCount => 3;
        public CellState[,] Cells { get; set; }
        public Board()
        {
            Cells = new CellState[RowCount, ColumCount];
        }

        public CellState Celll_0_0 { get; set; } = CellState.X;
        public CellState Cell_0_1 { get; set; }
        public CellState Cell_0_2 { get; set; }
        public CellState Cell_1_0 { get; set; }
        public CellState Cell_1_1 { get; set; }
        public CellState Cell_1_2 { get; set; }
        public CellState Cell_2_0 { get; set; }
        public CellState Cell_2_1 { get; set; }
        public CellState Cell_2_2 { get; set; }

    public void CellClick(int row, int column) 
    {
    if (Cells[row, column] == CellState.Blank)
    {
     Cells[row, column] = CellState.X;
    }
    else if (Cells[row, column] == CellState.Blank) {
    Cells [row, column] = CellState.O;
    }

    }

    }
}