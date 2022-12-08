using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    /// <summary>
    /// Ячейка поля.
    /// </summary>
    public class Cell : Button
    {
        private bool _isBomb;

        public bool IsBomb 
        { 
            get { return _isBomb; }
            set { _isBomb = value; }
        }
    }
}
