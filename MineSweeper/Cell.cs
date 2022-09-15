using System.Collections.Generic;
using System.Drawing;

namespace MineSweeper
{
    public class Cell
    {
        public enum CellTypes 
        {
            DefaultCell,
            EmptyCell,
            FlaggedCell,
            MinedCell,
            NumedCell,
            UnknownCell
        }

        private Dictionary<CellTypes, Image> _cellImages;

        public Cell()
        {
            _cellImages = new Dictionary<CellTypes, Image>();
        }
    }
}
