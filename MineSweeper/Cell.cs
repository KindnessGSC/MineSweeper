using System.Collections.Generic;
using System.Drawing;

namespace MineSweeper
{
    /// <summary>
    /// Ячейки поля.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Типы ячейки.
        /// </summary>
        public enum CellTypes
        {
            ClosedCell,
            EmptyCell,
            FlaggedCell,
            MinedCell,
            NumedCell,
            UnknownCell
        }

        public CellTypes CellType; // Тип ячейки
        private Dictionary<CellTypes, Image> _cellImages; // Спрайты ячейки
        private readonly int _cellSize; // Размер ячейки

        /// <summary>
        /// Создает пустую ячейку.
        /// </summary>
        public Cell()
        {
            _cellSize = 0;
            CellType = CellTypes.UnknownCell;
            _cellImages = new Dictionary<CellTypes, Image>()
            {
                // TODO: Задать все спрайты в зависимости от типа ячейки
            };
        }

        /// <summary>
        /// Создает ячейку, задает размер и тип, в зависимости от заданных парметров.
        /// </summary>
        /// <param name="cellTypes">Тип ячейки</param>
        /// <param name="cellSize">Размер ячейки</param>
        public Cell(CellTypes cellType, int cellSize)
        {
            CellType = cellType;
            _cellSize = cellSize;
        }

        /// <summary>
        /// Изменяет тип ячейки.
        /// </summary>
        /// <param name="cellTypes">Тип ячейки</param>
        public void ChangeCellType(CellTypes cellType)
        {
            CellType = cellType;
        }
    }
}
