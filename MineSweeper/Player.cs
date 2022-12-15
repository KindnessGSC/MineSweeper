using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
	public class Player
	{
		private string name;
		private int time;
		private int difficulty;

		public string Name { get { return name; } set { name = value; } }
		public int Time { get { return time; } set { time = value; }  }
		public int Difficult {  get { return difficulty; } set { difficulty = value; } }

		public Player()
		{
			Name = "NN";
		}
		public Player(string name, int time, int difficulty)
		{
			Name = name;
			Time = time;
			Difficult = difficulty;
		}
	}
}
