using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsForms
{
	/// <summary>
	/// Это, по сути, штука, которая помогает нам в удобном виде хранить и передавать запись
	/// Можно считать, будто это какая-нибудь запись в БД
	/// </summary>
	internal class StudentEntry 
	{

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
