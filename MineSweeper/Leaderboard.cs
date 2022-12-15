using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MineSweeper
{
    public partial class Leaderboard : Form
    {
        public Leaderboard()
        {
            InitializeComponent();
        }

        public DataGridView GridView 
        { 
            get { return playersTable; } 
            set { playersTable = value; }
        }


        public static Player LoadData(string fileName) 
        {
            Player player = new Player();
            XmlSerializer xmlSerializer = new XmlSerializer(type: typeof(Player));

            using (FileStream reader = new FileStream(fileName, FileMode.OpenOrCreate)) 
            {
                player = (Player) xmlSerializer.Deserialize(reader);

            }
            return player;
        }

        public static void SaveData(string fileName, Player player) 
        {
            XmlSerializer xmlSerializer = new XmlSerializer(type: typeof(Player));
            
            using (FileStream writer = new FileStream(fileName, FileMode.OpenOrCreate)) // указать имя переменной в которой лежит имя и путь файла
            {
                xmlSerializer.Serialize(writer,player); // то что нужно добавить в файл

            }
        }
    }
}
