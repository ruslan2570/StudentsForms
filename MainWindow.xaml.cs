using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentsForms
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		string[] specs = {"Информационные системы и программирование",
			"Сетевое и системное администрирование", "Строительство чего-то там",
			"Дизайн", "Товароводство", "Поиск смысла жизни", "Поварское депо" };

		FileWorker fw = new FileWorker();

		public MainWindow()
		{
			InitializeComponent();

			// Показываем первую запись
			txStudNumber.Text = 0.ToString();
			ShowInfo();

			// Установка источника строк для ComboBox. Это круче чем через цикл!
			cbSpec.ItemsSource = specs;
			// Заполнение через цикл тоже оставлю
			//	foreach(string s in specs)
			//		cbSpec.Items.Add(s);
			if (fw.GetEntryCount() - 1 == -1)
				txStudNumber.Text = "Новая запись";

		}

		// листаем назад
		private void btnPrev_Click(object sender, RoutedEventArgs e)
		{
			// Ниже дна не опустимся
			if (int.Parse(txStudNumber.Text) != 0)
				txStudNumber.Text = (int.Parse(txStudNumber.Text) - 1).ToString();
			Clear();
			ShowInfo();
		}

		// Сохраняем
		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			SaveInfo();
		}

		// листаем вперед
		private void btnNext_Click(object sender, RoutedEventArgs e)
		{
			if (txStudNumber.Text.Equals("Новая запись")) return;

			int i = int.Parse(txStudNumber.Text);

			Clear();

			if (fw.GetEntryCount() > i)
			{
				txStudNumber.Text = (i + 1).ToString();
				ShowInfo();
			}

			if (fw.GetEntryCount() == i) return;
		}


		// Вы продаете рыбов?
		private void SaveInfo()
		{
			string gender;
			if (rbGFemale.IsChecked == true) gender = rbGFemale.Name;
			else gender = rbGFemale.Name;

			if(txStudNumber.Text.Equals("Новая запись")) txStudNumber.Text = fw.GetEntryCount().ToString();

			StudentEntry se = new StudentEntry(fw.GetEntryCount(), txStudName.Text, gender, cbSpec.SelectedIndex);
			fw.PushEntry(se);
		}

		// Нет, только показываю
		private void ShowInfo()
		{	
			int i = int.Parse(txStudNumber.Text); // Берем номер записи
			var student = fw.PullEntry(i); // запрашиваем запись под этим номером

			if (student != null) // присваиваем элементам значения из записи
			{
				txStudNumber.Text = student.Number.ToString();
				txStudName.Text = student.Name;
				var rb = (RadioButton)this.FindName(student.Gender); // То, что мы на мобильных приложениях нашли. Прикольная штука.
				rb.IsChecked = true;
				cbSpec.SelectedIndex = student.Spec;
			}
		}

		private void Clear()
		{
			txStudName.Clear();
			rbGFemale.IsChecked = false;
			rbGMale.IsChecked = false;
			cbSpec.SelectedIndex = -1;
		}
	}
}
