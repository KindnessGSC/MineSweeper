using System.Windows.Forms;

namespace MineSweeper
{
    /// <summary>
    /// Ячейка поля.
    /// </summary>
    public class Cell : Button
    {
        private bool _isBomb;
        private bool _isClickable;
        private bool _wasAdded;

        private int _xCoord;
        private int _yCoord;

        public bool IsBomb 
        { 
            get { return _isBomb; }
            set { _isBomb = value; }
        }
        public bool IsClickable 
        {
            get { return _isClickable; }
            set { _isClickable = value; }
        }
        public bool WasAdded 
        {
            get { return _wasAdded; }
            set { _wasAdded = value; }
        }
        public int XCoord 
        {
            get { return _xCoord; }
            set { _xCoord = value; }
        }
        public int YCoord
        {
            get { return _yCoord; }
            set { _yCoord = value; }
        }
    }
}
