namespace BlazorApp1.domain
{
    public enum CellState
    {
        Blank, X, O
    }
    public enum GameResult
    {
        Xwon,
        Owom,
        Draw
    }
    public enum Gamer
    {
        X,
        O
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
        public CellState CurrentTurn = CellState.X;

        //тернарный опретор
        public void NextTurns()
        {
            CurrentTurn = CurrentTurn == CellState.X ? CellState.O : CellState.X;
        }

        public void CellClick(int row, int column)
        {
            if (Cells[row, column] == CellState.Blank)
            {
                Cells[row, column] = CurrentTurn;
                NextTurns();
            }
        }

        public GameResult GetGameResult()
        {
            if(GameCheck(Gamer.X))
            {
                return GameResult.Xwon;
            }
            else if(GameCheck(Gamer.O))
            {
                return GameResult.Owom;
            }
            return GameResult.Draw;

        }
        public bool GameCheck(Gamer gamer)
        {
            CellState expectedCellState;
            if (gamer == Gamer.X)
                expectedCellState = CellState.X;
            else
                expectedCellState = CellState.O;
            for(int column = 0; column < ColumCount; column++)
            {
                var expcount =0;
                for (int row = 0; row < RowCount; row++)
                {
                    if(Cells[row, column] == expectedCellState)
                    {
                        expcount++;
                    }
                    if(expcount == 3)
                    {
                        return true;
                    }
                }
            }
            //if (Cells[0, 0] == expectedCellState && Cells[1, 0] == expectedCellState && Cells[2, 0] == expectedCellState)
            //{
            //    return true;
            //}
            //if (Cells[0, 1] == expectedCellState && Cells[1, 1] == expectedCellState && Cells[2, 1] == expectedCellState)
            //{
            //    return true;
            //}
            //if (Cells[0, 2] == expectedCellState && Cells[1, 2] == expectedCellState && Cells[2, 2] == expectedCellState)
            //{
            //    return true;
            //}
            //if (Cells[0, 0] == expectedCellState && Cells[1, 1] == expectedCellState && Cells[2, 2] == expectedCellState)
            //{
            //    return true;
            //}
            //if (Cells[2, 0] == expectedCellState && Cells[1, 1] == expectedCellState && Cells[0, 2] == expectedCellState)
            //{
            //    return true;
            //}
            return false;
        }
    }
}
