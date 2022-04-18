using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentsForms
{
	internal class FileWorker
	{
		FileInfo file = new FileInfo("data");

		public FileWorker()
		{
			if (!file.Exists) file.Create();
		}

		public StudentEntry PullEntry(int number)
		{
			// Ищем строку с соответствующим запросу номером.
			using (StreamReader sr = new StreamReader(file.Name))
			{
				StudentEntry se;
				string[] sa;
				while (!sr.EndOfStream)
				{
					sa = sr.ReadLine().Split(',');
					if (int.Parse(sa[0]) == number)
					{
						se = new StudentEntry(int.Parse(sa[0]), sa[1], sa[2], int.Parse(sa[3]));
						return se;
					}
				}
			}
			return null;
		}


		public void PushEntry(StudentEntry se)
		{

			// Ответ на вопрос "Кто такой этот ваш using и почему он здесь используется?"
			// инструкция using гарантирует правильное использование объектов IAsyncDisposable.
			// после выполнения кода объект sw удалится и не будет использовать наш файл (это то, как я это понял, надеюсь, так оно и есть)

			using (StreamWriter sw = file.AppendText())
			{
				sw.WriteLine($"{se.Number},{se.Name},{se.Gender},{se.Spec}");
				sw.Close();
			}
		}

		public int GetEntryCount()
		{
			// Считаем количество строк и возвращаем.
			int number = 0;
			using (StreamReader sr = new StreamReader(file.Name))
			{
				while (!sr.EndOfStream)
				{
					sr.ReadLine();
					number++;
				}
			}
			return number;
		}
	}


}
