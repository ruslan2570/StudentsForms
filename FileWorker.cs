using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace StudentsForms
{
	internal class FileWorker
	{
		FileInfo file = new FileInfo("data");

		public FileWorker()
		{

			if (!file.Exists)
			{
				file.Create();
				MessageBox.Show("Файл создан!");
				// Прикинь, если убрать MessageBox, то при первом запуске программы (или если мы файл "data" удалим) будет ошибка
				// метод file.Create(); создавал файл, а в это время его пытался использовать PullEntry

			}
		}

		/// <summary>
		/// Получаем запись из файла
		/// </summary>
		/// <param name="number">номер записи</param>
		/// <returns>запись</returns>
		public StudentEntry PullEntry(int number)
		{
			// Ищем строку с соответствующим запросу номером.
			using (StreamReader sr = new StreamReader(file.Name))
			{
				StudentEntry se;
				string[] sa;
				while (!sr.EndOfStream)
				{
					// Здесь начинается магия
					// Берем строку (посмотри обязательно содержимое файла "data") и расчленяем её (РЕЗНЯ!!)
					// потом засовываем всё в массив, а потом в запись
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

		/// <summary>
		/// Запишет запись
		/// </summary>
		/// <param name="se">Запись, которую необходимо записать</param>
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

		/// <summary>
		/// Дает количество записей (вроде работает правильно, никак не могу проверить)
		/// </summary>
		/// <returns></returns>
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
