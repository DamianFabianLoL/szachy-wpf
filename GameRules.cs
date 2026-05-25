using System;
using System.Collections.Generic;

namespace ChessWPF
{
    public static class GameRules
    {
        public static bool IsCheck(Board board, PieceColor color)
        {
            // Stub: full check detection omitted; return false so code compiles.
            return false;
        }

        public static bool IsCheckmate(Board board, PieceColor color)
            => IsCheck(board, color) && !HasAnyLegalMove(board, color);

        public static bool HasAnyLegalMove(Board board, PieceColor color)
        {
            // Very small implementation: search for any legal move for side.
            var copy = new Board(false);
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    var piece = board.Squares[r, c];
                    if (piece == null || piece.Color != color) continue;
                    var moves = MoveGenerator.GetLegalMoves(board, r, c);
                    if (moves.Count > 0) return true;
                }
            }
            return false;
        }

        public static bool LeavesKingInCheck(Board board, Move move)
        {
            var clone = CloneBoard(board);
            ApplyMove(clone, move);
            return IsCheck(clone, board.Turn);
        }

        public static void ApplyMove(Board board, Move move)
        {
            var piece = board.Squares[move.FromRow, move.FromCol];
            board.Squares[move.ToRow, move.ToCol] = piece;
            board.Squares[move.FromRow, move.FromCol] = null;
            if (piece != null) piece.HasMoved = true;
            board.Turn = board.Turn == PieceColor.White ? PieceColor.Black : PieceColor.White;
            board.LastMove = move;
        }

        public static Board CloneBoard(Board board)
        {
            var clone = new Board(false)
            {
                Turn = board.Turn,
                LastMove = board.LastMove
            };

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    var p = board.Squares[r, c];
                    if (p != null)
                    {
                        var np = new Piece(p.Type, p.Color) { HasMoved = p.HasMoved };
                        clone.Squares[r, c] = np;
                    }
                    else
                    {
                        clone.Squares[r, c] = null;
                    }
                }
            }

            return clone;
        }
    }
}
