using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int _cellsCount; // Количество ячеек на поле
        private int _fieldDifficultlyIndex; // Индекс уровеня сложности поля
        private Dictionary<int, int> _fieldDifficulty; // Уровень сложности поля

        private int _cellSize; // Размер ячейки
        private Cell[,] _field; // Поле ячеек

        private bool _isStarted = false; // Состояние игры (Запущена)
        
        /// <summary>
        /// Возвращает общее количество ячеек.
        /// </summary>
        public int CellsCount { get { return _cellsCount; } }
        /// <summary>
        /// Возвращает размер поля.
        /// </summary>
        public int FieldSize { get { return _fieldSize; } }
        /// <summary>
        /// Возвращает уровень сложности.
        /// </summary>
        public int FieldDifficultly { get { return _fieldDifficultlyIndex; } set { _fieldDifficultlyIndex = value; } }

        /// <summary>
        /// Создает пустое поле для игры.
        /// </summary>
        public FieldUserControl()
        {
            InitializeComponent();
            _fieldSize = 0;
            _cellsCount = 0;
            _field = null;
            _cellSize = 0;
            _fieldDifficultlyIndex = 0;
            _fieldDifficulty = null;
            Size = new Size(_fieldSize, _fieldSize);
        }

        /// <summary>
        /// Создает поле для игры.
        /// </summary>
        /// <param name="fieldDifficulty">Уровень сложности поля</param>
        /// <param name="cellSize">Размер одной ячейки</param>
        public FieldUserControl(int fieldDifficulty, int cellSize) : base()
        {
            _fieldDifficultlyIndex = fieldDifficulty > 0 && fieldDifficulty <= 3 ? fieldDifficulty : _fieldDifficultlyIndex;
            _cellSize = cellSize > 0 ? cellSize : _cellSize;
        }

        /// <summary>
        /// Генерирует игровое поле.
        /// </summary>
        public void GenerateField()
        {
            if (_fieldDifficulty == null)
            {
                _fieldDifficulty = new Dictionary<int, int>
                {
                    { 1, 9 },
                    { 2, 12 },
                    { 3, 16 }
                };
            }

            _fieldDifficulty.TryGetValue(_fieldDifficultlyIndex, out _cellsCount);

            SetFieldSize(_cellsCount, _cellSize);
            GenerateCells(_cellsCount, _cellSize);
        }

        /// <summary>
        /// Генерирует игровое поле размером, в зависимости от установленного уровня сложности.
        /// </summary>
        public void GenerateField(int fieldDifficultly)
        {
            _fieldDifficultlyIndex = fieldDifficultly > 0 && fieldDifficultly <= 3 ? fieldDifficultly : _fieldDifficultlyIndex;

            if (_fieldDifficulty == null)
            {
                _fieldDifficulty = new Dictionary<int, int>
                {
                    { 1, 9 },
                    { 2, 12 },
                    { 3, 16 }
                };
            }

            _fieldDifficulty.TryGetValue(_fieldDifficultlyIndex, out _cellsCount);

            SetFieldSize(_cellsCount, _cellSize);
            GenerateCells(_cellsCount, _cellSize);
        }

        private void SetFieldSize(int cellsCount, int cellSize)
        {
            _cellsCount = (cellsCount > 0) ? cellsCount : _cellsCount;
            _cellSize = (cellSize > 0) ? cellSize : _cellSize;
            _field = new Cell[_cellsCount, _cellsCount];

            // Вычисление размера поля
            _fieldSize = _cellSize * _cellsCount;
            Size = new Size(_fieldSize, _fieldSize);
        }

        private void Explode()
        {
            for (int i = 0; i < _cellsCount; i++)
            {
                for (int j = 0; j < _cellsCount; j++)
                {
                    if (_field[i, j].IsBomb)
                    {
                        _field[i, j].Font = new Font("Arial", 24);
                        _field[i, j].Text = "*";
                    }
                }
            }

            MessageBox.Show("Вы проиграли! :(");

            for (int i = 0; i < _cellsCount; i++)
            {
                for (int j = 0; j < _cellsCount; j++)
                {
                    Controls.Remove(_field[i, j]);
                }
            }

            GenerateCells(_cellsCount, _cellSize);
        }

        private void OpenCell(Cell cell)
        {
            for (int x = 0; x < _cellsCount; x++)
            {
                for (int y = 0; y < _cellsCount; y++)
                {
                    if (_field[x, y] == cell)
                    {
                        cell.Text = CountBombsAround(x, y).ToString();
                    }
                }
            }
        }

        private int CountBombsAround(int xC, int yC)
        {
            int bombsCount = 0;

            for (int x = xC - 1; x <= xC + 1; x++)
            {
                for (int y = yC - 1; y < yC + 1; y++)
                {
                    if(x >= 0 && x < _cellsCount && y >= 0 && y < _cellsCount)
                    {
                        if (_field[x, y].IsBomb) bombsCount++;
                    }
                }
            }

            return bombsCount;
        }

        private void CellClick(object sender, EventArgs e)
        {
            Cell cell = sender as Cell;
            int bombsCount = (int)(FieldSize / CellsCount * 0.5 * _fieldDifficultlyIndex);

            if (!_isStarted)
            {
                _isStarted = true;
                GenerateBombs(cell, bombsCount);
            }

            if (cell.IsBomb)
            {
                _isStarted = false;
                Explode();
            }
            else
            {
                OpenCell(cell);
            }
        }

        private void GenerateCells(int cellsCount, int cellSize)
        {
            for (int i = 0; i < _cellsCount; i++)
            {
                for (int j = 0; j < _cellsCount; j++)
                {
                    Cell cell = new Cell();

                    int x = j * _cellSize;
                    int y = i * _cellSize;

                    cell.Size = new Size(_cellSize, _cellSize);
                    cell.Location = new Point(x, y);

                    cell.Click += CellClick;
                    _field[i, j] = cell;
                    Controls.Add(_field[i, j]);
                }
            }
        }

        private void GenerateBombs(Cell cell, int bombsCount)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            if (_isStarted)
            {
                while(bombsCount > 0)
                {
                    int x = rnd.Next(0, _cellsCount);
                    int y = rnd.Next(0, _cellsCount);

                    if (_field[x, y] != cell && !_field[x, y].IsBomb)
                    {
                        _field[x, y].IsBomb = true;
                        bombsCount--;
                    }
                }
            }
        }
    }
}
