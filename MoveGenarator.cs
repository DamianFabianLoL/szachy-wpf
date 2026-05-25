using System.Collections.Generic;
using System.Linq;

namespace ChessWPF
{
    public static class MoveGenerator
    {
        public static List<Move> GetLegalMoves(Board board, int r, int c)
        {
            var piece = board.Squares[r, c];
            if (piece == null || piece.Color != board.Turn)
                return new List<Move>();

            var moves = piece.Type switch
            {
                PieceType.Pawn => PawnMoves(board, r, c),
                PieceType.Rook => Sliding(board, r, c, rookDirs),
                PieceType.Bishop => Sliding(board, r, c, bishopDirs),
                PieceType.Queen => Sliding(board, r, c, queenDirs),
                PieceType.Knight => KnightMoves(board, r, c),
                PieceType.King => KingMoves(board, r, c),
                _ => new List<Move>()
            };

            // Basic filtering stub: ensure not leaving king in check (calls GameRules)
            return moves
                .Where(m => !GameRules.LeavesKingInCheck(board, m))
                .ToList();
        }

        static readonly (int, int)[] rookDirs = { (1, 0), (-1, 0), (0, 1), (0, -1) };
        static readonly (int, int)[] bishopDirs = { (1, 1), (1, -1), (-1, 1), (-1, -1) };
        static readonly (int, int)[] queenDirs = rookDirs.Concat(bishopDirs).ToArray();

        // Minimal safe stubs for move families so project compiles.
        static List<Move> PawnMoves(Board board, int r, int c) => new List<Move>();
        static List<Move> KnightMoves(Board board, int r, int c) => new List<Move>();
        static List<Move> KingMoves(Board board, int r, int c) => new List<Move>();
        static List<Move> Sliding(Board board, int r, int c, (int, int)[] dirs) => new List<Move>();
    }
}
