using System.IO.Pipelines;

namespace ChessWPF
{
    public record Move(
        int FromRow, int FromCol,
        int ToRow, int ToCol,
        Piece? Promotion = null
    );
}
