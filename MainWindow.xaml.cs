using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ChessWPF
{
    public partial class MainWindow : Window
    {
        private Piece?[,] board = new Piece?[8, 8];
        private Button? selectedButton;
        private int selectedRow, selectedCol;

        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
            DrawBoard();
        }

        void InitializeBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new Piece(PieceType.Pawn, PieceColor.Black);
                board[6, i] = new Piece(PieceType.Pawn, PieceColor.White);
            }
        }

        void DrawBoard()
        {
            Board.Children.Clear();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    var btn = new Button
                    {
                        FontSize = 32,
                        Background = (row + col) % 2 == 0 ? Brushes.Bisque : Brushes.SaddleBrown,
                        Foreground = Brushes.Black,
                        Tag = (row, col)
                    };

                    var p = board[row, col];
                    if (p != null)
                        btn.Content = p.Symbol;

                    btn.Click += OnSquareClick;
                    Board.Children.Add(btn);
                }
            }
        }

        void OnSquareClick(object? sender, RoutedEventArgs e)
        {
            if (sender is not Button btn) return;
            var (row, col) = ((int, int))btn.Tag;

            if (selectedButton == null && board[row, col] != null)
            {
                selectedButton = btn;
                selectedRow = row;
                selectedCol = col;
                btn.BorderBrush = Brushes.Red;
                btn.BorderThickness = new Thickness(3);
            }
            else if (selectedButton != null)
            {
                board[row, col] = board[selectedRow, selectedCol];
                board[selectedRow, selectedCol] = null;
                selectedButton = null;
                DrawBoard();
            }
        }
    }
}
