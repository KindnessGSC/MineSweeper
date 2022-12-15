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
            this.Load += Leaderboard_Load;
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = "Легко";
            dataGridView1.Columns[1].HeaderText = "Нормально";
            dataGridView1.Columns[2].HeaderText = "Сложно";

            if (inputName.Players.Count > 0)
                LoadToDataGrid(inputName.Players.ToArray());
        }

        List<Player> _players;
        Player[] temp;

        private void LoadToDataGrid(Player[] players) 
        {
            _players = players != null ? players.ToList() : _players;
            temp = _players.Where(x => x.Difficult == 1).ToArray();
            dataGridView1.DataSource = temp;
            dataGridView1.ColumnHeaderMouseClick += PlayersTable_ColumnHeaderMouseClick;
        }

        private void PlayersTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            temp = _players.ToArray();
            if (e.ColumnIndex == 0) 
            {
                temp = _players.Where(x => x.Difficult ==1).ToArray();
            }
            if (e.ColumnIndex == 1)
            {
                temp = _players.Where(x => x.Difficult == 2).ToArray();
            }
            if (e.ColumnIndex == 2)
            {
                temp = _players.Where(x => x.Difficult == 3).ToArray();
            }
            
            dataGridView1.DataSource = temp;
        }

        public static Player[] LoadData(string fileName) 
        {
            List<Player> players = new List<Player>();
            XmlSerializer xmlSerializer = new XmlSerializer(type: typeof(Player[]));

            using (FileStream reader = new FileStream(fileName, FileMode.OpenOrCreate)) 
            {
                try
                {
                    players = ((Player[])xmlSerializer.Deserialize(reader)).ToList();
                }
                catch
                {
                    
                }
            }

            return players.ToArray();
        }

        public static void SaveData(string fileName, Player[] players) 
        {
            XmlSerializer xmlSerializer = new XmlSerializer(type: typeof(Player[]));
            
            using (FileStream writer = new FileStream(fileName, FileMode.OpenOrCreate)) // указать имя переменной в которой лежит имя и путь файла
            {
                try
                {
                    xmlSerializer.Serialize(writer, players); // то что нужно добавить в файл
                }
                catch
                {

                }
            }
        }
    }
}
