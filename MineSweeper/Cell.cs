using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;

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
        private bool _isOpened;

        private int _xCoord;
        private int _yCoord;

        private int _currentSpriteIndex;
        private const int _lengthSprite = 13;

        private Dictionary<int, Point> _spritesIndex;

        public int CurrentSpriteIndex 
        {
            get { return _currentSpriteIndex; }
            set 
            { 
                _currentSpriteIndex = value >= 0 && value < _lengthSprite ? value : _currentSpriteIndex;
                OnSpriteIndexChanged(_currentSpriteIndex);
            }
        }

        public bool IsBomb 
        { 
            get { return _isBomb; }
            set { _isBomb = value; }
        }
        public bool IsOpened 
        { 
            get { return _isOpened; } 
            set { _isOpened = value; }
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

        private void OnSpriteIndexChanged(int spriteIndex)
        {
            if (_spritesIndex == null)
            {
                _spritesIndex = new Dictionary<int, Point>()
                {
                    {0, new Point(0, 0) },
                    {1, new Point(1, 0) },
                    {2, new Point(2, 0) },
                    {3, new Point(3, 0) },
                    {4, new Point(4, 0) },
                    {5, new Point(0, 1) },
                    {6, new Point(1, 1) },
                    {7, new Point(2, 1) },
                    {8, new Point(3, 1) },
                    {9, new Point(4, 1) },
                    {10, new Point(0, 2) },
                    {11, new Point(1, 2) },
                    {12, new Point(2, 2) },
                };
            }

            Point spritePos;

            _spritesIndex.TryGetValue(spriteIndex, out spritePos);

            Image image = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(image);
            Rectangle imageRect = new Rectangle(new Point(0,0), new Size(Width, Height));

            g.DrawImage(Properties.Resources.SpriteAtlas, imageRect, 0 + 33 * spritePos.X, 0 + 32 * spritePos.Y, 33, 33, GraphicsUnit.Pixel);
            this.Image = image;
        }

        /*public void SpriteChange(int x, int y)
        {
            Image image = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(image);
            Rectangle imageRect = new Rectangle(new Point(0, 0), new Size(Width, Height));

            g.DrawImage(Properties.Resources.SpriteAtlas, imageRect, 0 + 33 * x, 0 + 32 * y, 33, 33, GraphicsUnit.Pixel);
            this.Image = image;
        }*/
    }
}
