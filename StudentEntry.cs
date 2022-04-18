using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsForms
{
	internal class StudentEntry
	{

		//public StudentEntry() { }


		// Конструхтор, который принимает аргументы
		public StudentEntry(int number, string name, string gender, int spec)
		{
			this.Number = number;
			this.Name = name;
			this.Gender = gender;
			this.Spec = spec;
		}

		public int Number { get; set; }
		public string Name { get; set; }
		public string Gender { get; set; }
		public int Spec { get; set; }
	}
}
