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

        private int currentPictureToSet = 0;
        private Point firstCoord;

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
            currentPictureToSet = 0;
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

        private void OnButtonPressedMouse(object sender, MouseEventArgs e)
        {
            Button pressedButton = sender as Button;
            switch (e.Button.ToString())
            {
                case "Right":
                    OnRightButtonPressed(pressedButton);
                    break;
                case "Left":
                    OnLeftButtonPressed(pressedButton);
                    break;
            }
        }

        private void OnRightButtonPressed(Button pressedButton)
        {
            currentPictureToSet++;
            currentPictureToSet %= 3;
            int posX = 0;
            int posY = 0;
            switch (currentPictureToSet)
            {
                case 0:
                    posX = 0;
                    posY = 0;
                    break;
                case 1:
                    posX = 0;
                    posY = 2;
                    break;
                case 2:
                    posX = 2;
                    posY = 2;
                    break;
            }
            pressedButton.Image = FindNeededImage(posX, posY);
        }

        private void OnLeftButtonPressed(Button pressedButton)
        {
            pressedButton.Enabled = false;
            int iButton = pressedButton.Location.Y / _cellSize;
            int jButton = pressedButton.Location.X / _cellSize;
            if (isFirstStep)
            {
                firstCoord = new Point(jButton, iButton);
                SeedMap();
                CountCellBomb();
                isFirstStep = false;
            }
            OpenCells(iButton, jButton);

            if (_field[iButton, jButton] == -1)
            {
                ShowAllBombs(iButton, jButton);
                MessageBox.Show("Поражение!");
                Controls.Clear();
            }
        }

        private void CountCellBomb()
        {
            for (int i = 0; i < _fieldSize; i++)
            {
                for (int j = 0; j < _fieldSize; j++)
                {
                    if (_field[i, j] == -1)
                    {
                        for (int k = i - 1; k < i + 2; k++)
                        {
                            for (int l = j - 1; l < j + 2; l++)
                            {
                                if (!IsInBorder(k, l) || _field[k, l] == -1)
                                    continue;
                                _field[k, l] = _field[k, l] + 1;
                            }
                        }
                    }
                }
            }
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
                    cell.Image = FindNeededImage(0, 0);
                    cell.MouseUp += new MouseEventHandler(OnButtonPressedMouse);
                    Controls.Add(cell);
                    _cells[i, j] = cell;
                }
            }
        }

        private void OpenCell(int i, int j)
        {
            _cells[i, j].Enabled = false;

            switch (_field[i, j])
            {
                case 1:
                    _cells[i, j].Image = FindNeededImage(1, 0);
                    break;
                case 2:
                    _cells[i, j].Image = FindNeededImage(2, 0);
                    break;
                case 3:
                    _cells[i, j].Image = FindNeededImage(3, 0);
                    break;
                case 4:
                    _cells[i, j].Image = FindNeededImage(4, 0);
                    break;
                case 5:
                    _cells[i, j].Image = FindNeededImage(0, 1);
                    break;
                case 6:
                    _cells[i, j].Image = FindNeededImage(1, 1);
                    break;
                case 7:
                    _cells[i, j].Image = FindNeededImage(2, 1);
                    break;
                case 8:
                    _cells[i, j].Image = FindNeededImage(3, 1);
                    break;
                case -1:
                    _cells[i, j].Image = FindNeededImage(1, 2);
                    break;
                case 0:
                    _cells[i, j].Image = FindNeededImage(0, 0);
                    break;
            }
        }

        private void OpenCells(int i, int j)
        {
            OpenCell(i, j);

            if (_field[i, j] > 0)
                return;

            for (int k = i - 1; k < i + 2; k++)
            {
                for (int l = j - 1; l < j + 2; l++)
                {
                    if (!IsInBorder(k, l))
                        continue;
                    if (!_cells[k, l].Enabled)
                        continue;
                    if (_field[k, l] == 0)
                        OpenCells(k, l);
                    else if (_field[k, l] > 0)
                        OpenCell(k, l);
                }
            }
        }

        private void ShowAllBombs(int iBomb, int jBomb)
        {
            for (int i = 0; i < _fieldSize; i++)
            {
                for (int j = 0; j < _fieldSize; j++)
                {
                    if (i == iBomb && j == jBomb)
                        continue;
                    if (_field[i, j] == -1)
                    {
                        _cells[i, j].Image = FindNeededImage(3, 2);
                    }
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

        private bool IsInBorder(int i, int j)
        {
            if (i < 0 || j < 0 || j > _fieldSize - 1 || i > _fieldSize - 1)
            {
                return false;
            }
            return true;
        }
    }
}
