using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MineSweeper
{
    /// <summary>
    /// Игровое поле.
    /// </summary>
    public partial class FieldUserControl : UserControl
    {
        private int _fieldSize; // Размер поля
        private int _cellCount; // Количество ячеек
        private int _cellSize; // Размер ячейки
        private int[,] _field; // Поле
        private Button[,] _cells; // Ячейки
        private Image _spriteSet; // Спрайты

        private bool isFirstStep;
        
        /// <summary>
        /// Возвращает общее количество ячеек.
        /// </summary>
        public int CellCount { get { return _cellCount; } }
        /// <summary>
        /// Возвращает размер поля.
        /// </summary>
        public int FieldSize { get { return _fieldSize; } }

        /// <summary>
        /// Создает пустое поле для игры.
        /// </summary>
        public FieldUserControl()
        {
            InitializeComponent();
            _fieldSize = 0;
            _cellCount = 0;
            _field = null;
            _cells = null;
            _cellSize = 0;
            Size = new Size(_fieldSize, _fieldSize);
        }

        /// <summary>
        /// Инициализация поля.
        /// </summary>
        public void Initialize(int cellCount, int cellSize)
        {
            isFirstStep = true;
            _spriteSet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.FullName.ToString(), "Sprites\\tiles.png"));
            GenerateField(cellCount, cellSize);
        }

        /// <summary>
        /// Генерирует поле размером, в зависимости от размера ячейки и установленного уровня сложности.
        /// </summary>
        /// <param name="cellCount">Количество ячеек (Уровень сложности)</param>
        /// <param name="cellSize">Размер ячейки</param>
        private void GenerateField(int cellCount, int cellSize)
        {
            SetFieldSize(cellCount, cellSize);
            SetImages(cellCount, cellSize);
        }

        private void SeedMap()
        {
            Random rnd = new Random();
            int number = rnd.Next(5, 10);

            for (int i = 0; i < number; i++)
            {
                int posX = rnd.Next(0, _fieldSize - 1);
                int posY = rnd.Next(0, _fieldSize - 1);

                while(_field[posY, posX] == -1)
                {
                    posX = rnd.Next(0, _fieldSize - 1);
                    posY = rnd.Next(0, _fieldSize - 1);
                }

                _field[posY, posX] = -1;
            }
        }

        /// <summary>
        /// Устанавливает размер поля.
        /// </summary>
        /// <param name="cellCount">Количество клеток</param>
        private void SetFieldSize(int cellCount, int cellSize)
        {
            _cellCount = (cellCount > 0) ? cellCount : _cellCount;
            _cellSize = (cellSize > 0) ? cellSize : _cellSize;
            _field = new int[_cellCount, _cellCount];

            // Вычисление размера поля
            _fieldSize = _cellSize * cellCount;
            Size = new Size(_fieldSize, _fieldSize);
        }

        private void SetImages(int cellCount, int cellSize)
        {
            _cells = new Button[_cellCount, _cellCount];

            for (int i = 0; i < cellCount; i++)
            {
                for (int j = 0; j < cellCount; j++)
                {
                    Button cell = new Button();
                    cell.Location = new Point(j * cellSize, i * cellSize);
                    cell.Size = new Size(cellSize, cellSize);
                    cell.Image = FindNeededImage(0, 2);
                    Controls.Add(cell);
                    _cells[i, j] = cell;
                }
            }
        }

        private Image FindNeededImage(int xPos, int yPos)
        {
            Image image = new Bitmap(_cellSize, _cellSize);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(_spriteSet, new Rectangle(new Point(0, 0), new Size(_cellSize, _cellSize)), 0 + 32 * xPos, 0 + 32 * yPos, 33, 33, GraphicsUnit.Pixel);
            return image;
        }
    }
}
