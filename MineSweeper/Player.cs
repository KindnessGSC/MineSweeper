using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
	public class Player
	{
		public string Name;
		public int Time;
		public int Difficult;

		public Player()
		{
			Name = "NN";
		}
		public Player(string name, int time, int difficult)
		{
			Name = name;
			Time = time;
			Difficult = difficult;
		}
	}
}
