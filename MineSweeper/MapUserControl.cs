using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    /// <summary>
    /// Поле игры.
    /// </summary>
    public partial class MapUserControl : UserControl
    {
        private int _mapWidth;
        private int _mapHeight;
        private int _cellCount;
        private int[,] _map;
         
        public int CellCount { get { return _cellCount; } }
        public int MapWidth { get { return _mapWidth; } }
        public int MapHeight { get { return _mapHeight; } }

        /// <summary>
        /// Создает пустое поле для игры.
        /// </summary>
        public MapUserControl()
        {
            InitializeComponent();
            _mapWidth = 0;
            _mapHeight = 0;
            _cellCount = 0;
            _map = null;
            Size = new Size(_mapWidth, _mapHeight);
        }

        /// <summary>
        /// Генерирует поле в зависимости от установленного параметра сложности.
        /// </summary>
        /// <param name="cellCount">Количество клеток (Уровень сложности)</param>
        public void GenerateMap(int cellCount)
        {
            SetMapSize(cellCount);
        }

        /// <summary>
        /// Устанавливает размер поля.
        /// </summary>
        /// <param name="cellCount">Количество клеток</param>
        private void SetMapSize(int cellCount)
        {
            _cellCount = (cellCount > 0) ? cellCount : _cellCount;
            _map = new int[_cellCount, _cellCount];
            Size = new Size(_mapWidth, _mapHeight);
        }
    }
}
