using System;
using System.Collections.Generic;
using System.Drawing;
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
        private List<Cell> _cells; // Список ячеек
        private Rectangle _clientRectangle;
        
        /// <summary>
        /// Возвращает общее количество ячеек на поле.
        /// </summary>
        public int CellCount { get { return _cellCount; } }
        /// <summary>
        /// Возвращает размер поля.
        /// </summary>
        public int FieldSize { get { return _fieldSize; } }
        /// <summary>
        /// Возвращает список ячеек на поле.
        /// </summary>
        public List<Cell> Cells { get { return _cells; } }
        /// <summary>
        /// Возвращает игровое поле.
        /// </summary>
        public int[,] Field { get { return _field; } }

        /// <summary>
        /// Создает пустое поле для игры.
        /// </summary>
        public FieldUserControl()
        {
            InitializeComponent();
            _fieldSize = 0;
            _cellCount = 0;
            _field = null;
            _cellSize = 0;
            _cells = null;
            Location = new Point(0, 0);
            Size = new Size(_fieldSize, _fieldSize);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawField(_clientRectangle, e.Graphics);
        }

        /// <summary>
        /// Генерирует поле размером, в зависимости от размера ячейки и установленного уровня сложности.
        /// </summary>
        /// <param name="cellCount">Количество ячеек (Уровень сложности)</param>
        /// <param name="cellSize">Размер ячейки</param>
        public void GenerateField(int cellCount, int cellSize, Rectangle clientRectangle)
        {
            _clientRectangle = clientRectangle;
            SetFieldSize(cellCount, cellSize, clientRectangle);
            SetField();
            Invalidate();
        }

        /// <summary>
        /// Устанавливает размер поля.
        /// </summary>
        /// <param name="cellCount">Количество клеток</param>
        private void SetFieldSize(int cellCount, int cellSize, Rectangle window)
        {
            _cellCount = (cellCount > 0) ? cellCount : _cellCount;
            _cellSize = (cellSize > 0) ? cellSize : _cellSize;

            // Вычисление размера поля
            _fieldSize = _cellSize * cellCount;

            // Вычисление положения поля (Центрирование)
            int posX = (window.Width - Width) / 2;
            int posY = (window.Height - Height) / 2;
            Location = new Point(posX, posY);

            Size = new Size(_fieldSize, _fieldSize);
        }

        private void SetField()
        {
            if(_field == null)
            {
                _field = new int[_cellCount, _cellCount];
            }
            if (_cells == null)
            {
                _cells = new List<Cell>(_cellCount);
            }
        }

        private void DrawField(Rectangle client, Graphics g)
        {
            g.FillRectangle(Brushes.LightGray, new Rectangle(Location.X, Location.Y, Width, Height));
        }
    }
}
