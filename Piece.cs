namespace ChessWPF
{
    public enum PieceType { Pawn, Rook, Knight, Bishop, Queen, King }
    public enum PieceColor { White, Black }

    public class Piece
    {
        public PieceType Type { get; }
        public PieceColor Color { get; }
        public bool HasMoved { get; set; }

        public Piece(PieceType type, PieceColor color)
        {
            Type = type;
            Color = color;
        }

        public string Symbol => (Color, Type) switch
        {
            (PieceColor.White, PieceType.King) => "♔",
            (PieceColor.White, PieceType.Queen) => "♕",
            (PieceColor.White, PieceType.Rook) => "♖",
            (PieceColor.White, PieceType.Bishop) => "♗",
            (PieceColor.White, PieceType.Knight) => "♘",
            (PieceColor.White, PieceType.Pawn) => "♙",
            (PieceColor.Black, PieceType.King) => "♚",
            (PieceColor.Black, PieceType.Queen) => "♛",
            (PieceColor.Black, PieceType.Rook) => "♜",
            (PieceColor.Black, PieceType.Bishop) => "♝",
            (PieceColor.Black, PieceType.Knight) => "♞",
            (PieceColor.Black, PieceType.Pawn) => "♟",
            _ => ""
        };
    }
}
