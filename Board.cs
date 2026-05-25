using System;

namespace ChessWPF
{
    public class Board
    {
        public Piece?[,] Squares = new Piece?[8, 8];
        public PieceColor Turn = PieceColor.White;
        public Move? LastMove;

        public Board(bool setup = true)
        {
            if (setup) Setup();
        }

        void Setup()
        {
            for (int i = 0; i < 8; i++)
            {
                Squares[1, i] = new Piece(PieceType.Pawn, PieceColor.Black);
                Squares[6, i] = new Piece(PieceType.Pawn, PieceColor.White);
            }

            SetupBackRank(0, PieceColor.Black);
            SetupBackRank(7, PieceColor.White);
        }

        void SetupBackRank(int row, PieceColor color)
        {
            Squares[row, 0] = new Piece(PieceType.Rook, color);
            Squares[row, 1] = new Piece(PieceType.Knight, color);
            Squares[row, 2] = new Piece(PieceType.Bishop, color);
            Squares[row, 3] = new Piece(PieceType.Queen, color);
            Squares[row, 4] = new Piece(PieceType.King, color);
            Squares[row, 5] = new Piece(PieceType.Bishop, color);
            Squares[row, 6] = new Piece(PieceType.Knight, color);
            Squares[row, 7] = new Piece(PieceType.Rook, color);
        }
    }
}
