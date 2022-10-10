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
        
        /// <summary>
        /// Возвращает общее количество ячеек.
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
        /// Создает пустое поле для игры.
        /// </summary>
        public FieldUserControl()
        {
            InitializeComponent();
            _fieldSize = 0;
            _cellCount = 0;
            _field = null;
            _cellSize = 0;
            Size = new Size(_fieldSize, _fieldSize);
        }

        /// <summary>
        /// Генерирует поле размером, в зависимости от размера ячейки и установленного уровня сложности.
        /// </summary>
        /// <param name="cellCount">Количество ячеек (Уровень сложности)</param>
        /// <param name="cellSize">Размер ячейки</param>
        public void GenerateField(int cellCount, int cellSize)
        {
            SetFieldSize(cellCount, cellSize);
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
    }
}
