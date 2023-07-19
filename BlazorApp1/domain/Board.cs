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
        Draw,
        Unknow
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

        public void CellClickRevers(int row, int column)
        {
            var gameresult = GetGameResult(out _);
            if (gameresult == GameResult.Unknow)
            {

                if (Cells[row, column] == CellState.Blank)
                {
                    Cells[row, column] = CurrentTurn;
                    NextTurns();
                }
            }
        }

        public GameResult GetGameResult(out CellPosition[] winCell)
        {
            if (GameCheck(Gamer.X, out winCell))
            {
                return GameResult.Xwon;
            }
            else if(GameCheck(Gamer.O, out winCell))
            {
                return GameResult.Owom;
            }
            //else if(GameCheck())
            //{
            //    return GameResult.Draw;
            //}
            return GameResult.Unknow;
        }

        public bool GameCheck(Gamer gamer, out CellPosition[] winCell)
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
                        winCell = new CellPosition[]
                        {
                            new CellPosition(0, column),
                            new CellPosition(1, column),
                            new CellPosition(2, column)
                        };
                        return true;
                    }
                }
            }
            for (int row = 0; row < RowCount; row++)
            {
                var expcount = 0;
                for (int column = 0; column < ColumCount; column++)
                {
                    if (Cells[row, column] == expectedCellState)
                    {
                        expcount++;
                    }
                    if (expcount == 3)
                    {
                        winCell = new CellPosition[]
                         {
                            new CellPosition(row, 0),
                            new CellPosition(row, 1),
                            new CellPosition(row, 2)
                         };
                        return true;
                    }
                }
            }
            winCell = new CellPosition[0];
            return false;
        }
    }

    public record CellPosition(int Row, int Column);
}
