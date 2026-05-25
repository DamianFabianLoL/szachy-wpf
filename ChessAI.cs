using System;
using System.Collections.Generic;

namespace ChessWPF
{
    public class ChessAI
    {
        public Move? FindBestMove(Board board, int depth = 3)
        {
            int bestScore = int.MinValue;
            Move? bestMove = null;

            foreach (var move in AllMoves(board))
            {
                var clone = Clone(board);
                GameRules.ApplyMove(clone, move);
                int score = -Minimax(clone, depth - 1);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = move;
                }
            }
            return bestMove;
        }

        int Minimax(Board board, int depth)
        {
            if (depth == 0)
                return Evaluate(board);

            int best = int.MinValue;
            foreach (var move in AllMoves(board))
            {
                var clone = Clone(board);
                GameRules.ApplyMove(clone, move);
                best = Math.Max(best, -Minimax(clone, depth - 1));
            }
            return best;
        }

        IEnumerable<Move> AllMoves(Board board)
        {
            var moves = new List<Move>();
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    var piece = board.Squares[r, c];
                    if (piece == null || piece.Color != board.Turn) continue;
                    moves.AddRange(MoveGenerator.GetLegalMoves(board, r, c));
                }
            }
            return moves;
        }

        Board Clone(Board board) => GameRules.CloneBoard(board);

        int Evaluate(Board board)
        {
            // Stub: simple material evaluation to allow compilation; customize later.
            int score = 0;
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    var p = board.Squares[r, c];
                    if (p == null) continue;
                    int val = p.Type switch
                    {
                        PieceType.Pawn => 100,
                        PieceType.Knight => 320,
                        PieceType.Bishop => 330,
                        PieceType.Rook => 500,
                        PieceType.Queen => 900,
                        PieceType.King => 20000,
                        _ => 0
                    };
                    score += (p.Color == PieceColor.White) ? val : -val;
                }
            }
            return score;
        }
    }
}
