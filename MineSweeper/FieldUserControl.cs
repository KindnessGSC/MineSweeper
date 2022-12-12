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
        private int _cellsCount; // Количество ячеек на поле

        private int _fieldDifficultlyIndex; // Индекс уровеня сложности поля
        private Dictionary<int, int> _fieldDifficulty; // Уровень сложности поля

        private int _cellSize; // Размер ячейки
        private Cell[,] _field; // Поле ячеек
        private int _bombsCount;
        private int _flagsCount;

        private bool _isStarted = false; // Состояние игры (Запущена)
        int _cellsOpened = 0; // Кол-во открытых ячеек поля

        public delegate void WinHandler();
        public event WinHandler Win;
        
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
        public int FieldDifficultly { get { return _fieldDifficultlyIndex; } }
        /// <summary>
        /// Возвращает кол-во бомб на поле
        /// </summary>
        public int BombsCount { get { return _bombsCount; } }
        public int FlagsCount { get { return _flagsCount; } }

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
            _bombsCount = 0;
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

        public void ChangeDiffucltly(int difficultly)
        {
            _fieldDifficultlyIndex = difficultly;

            RestoreValues();
            GenerateField();
        }

        private void RestoreValues()
        {
            _isStarted = false;
            _cellsOpened = 0;

            for (int i = 0; i < _cellsCount; i++)
            {
                for (int j = 0; j < _cellsCount; j++)
                {
                    Controls.Remove(_field[i, j]);
                }
            }
        }

        public void NewGame()
        {
            RestoreValues();
            GenerateField();
        }

        /// <summary>
        /// Генерирует игровое поле.
        /// </summary>
        private void GenerateField()
        {
            if (_fieldDifficulty == null)
            {
                _fieldDifficulty = new Dictionary<int, int>
                {
                    { 1, 9 },
                    { 2, 14 },
                    { 3, 20 }
                };
            }

            _fieldDifficulty.TryGetValue(_fieldDifficultlyIndex, out _cellsCount);

            switch (_cellsCount)
            {
                case 9:
                    _bombsCount = 10;
                    break;
                case 14:
                    _bombsCount = 40;
                    break;
                case 20:
                    _bombsCount = 100;
                    break;
            }

            _flagsCount = _bombsCount;

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
                        _field[i, j].Text = "*";
                    }
                }
            }

            MessageBox.Show("Вы проиграли! :(");

            RestoreValues();
            GenerateField();
        }

        private void OpenRegion(Cell cell)
        {
            Queue<Cell> queue = new Queue<Cell>();
            queue.Enqueue(cell);
            cell.WasAdded = true;

            while (queue.Count > 0)
            {
                Cell currentCell = queue.Dequeue();
                OpenCell(currentCell.XCoord, currentCell.YCoord, currentCell);
                _cellsOpened++;
                if (CountBombsAround(currentCell.XCoord, currentCell.YCoord) == 0)
                {
                    for (int y = currentCell.YCoord - 1; y <= currentCell.YCoord + 1; y++)
                    {
                        for (int x = currentCell.XCoord - 1; x <= currentCell.XCoord + 1; x++)
                        {
                            if (x == currentCell.XCoord && y == currentCell.YCoord) continue;

                            if (x >= 0 && x < _cellsCount && y >= 0 && y < _cellsCount)
                            {
                                if (!_field[x, y].WasAdded)
                                {
                                    queue.Enqueue(_field[x, y]);
                                    _field[x, y].WasAdded = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void OpenCell(int xC, int yC, Cell cell)
        {
            int bombsAround = CountBombsAround(xC, yC);

            if (bombsAround != 0)
            {
                cell.Text = bombsAround.ToString();
            }

            cell.Enabled = false;
        }

        private void CheckWin()
        {
            int cells = _field.Length;
            int emptycells = cells - _bombsCount;

            if (_cellsOpened >= emptycells)
            {
                MessageBox.Show("Вы победили! :)");
                _cellsOpened = 0;
                Win?.Invoke();
            }
        }

        private int CountBombsAround(int xC, int yC)
        {
            int bombsAround = 0;

            for (int x = xC - 1; x <= xC + 1; x++)
            {
                for (int y = yC - 1; y <= yC + 1; y++)
                {
                    if(x >= 0 && x < _cellsCount && y >= 0 && y < _cellsCount)
                    {
                        if (_field[x, y].IsBomb) bombsAround++;
                    }
                }
            }

            return bombsAround;
        }

        private void CellClick(object sender, MouseEventArgs e)
        {
            Cell cell = sender as Cell;

            if (!_isStarted)
            {
                _isStarted = true;
                GenerateBombs(cell, _bombsCount);
            }

            if(e.Button == MouseButtons.Left && cell.IsClickable)
            {
                if (cell.IsBomb)
                {
                    _isStarted = false;
                    Explode();
                }
                else
                {
                    OpenRegion(cell);
                }
            }

            if(e.Button == MouseButtons.Right)
            {
                if (_flagsCount > 0 && cell.IsClickable)
                {
                    if (cell.IsClickable)
                    {
                        cell.Text = "B";
                        _flagsCount--;
                        cell.IsClickable = false;
                    }
                }
                else
                {
                    if (!cell.IsClickable)
                    {
                        cell.Text = string.Empty;
                        _flagsCount++;
                        cell.IsClickable = true;
                    }
                }
            }
            CheckWin();
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
                    cell.XCoord = i;
                    cell.YCoord = j;
                    cell.IsClickable = true;
                    cell.TabStop = false;

                    cell.MouseUp += CellClick;
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
