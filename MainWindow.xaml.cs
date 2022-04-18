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

			// Установка источника строк для ComboBox. Это круче чем через цикл!
			cbSpec.ItemsSource = specs;
			// Заполнение через цикл тоже оставлю
			//	foreach(string s in specs)
			//		cbSpec.Items.Add(s);

		}

		private void btnPrev_Click(object sender, RoutedEventArgs e)
		{
			SaveInfo();
		}

		private void btnDel_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnNext_Click(object sender, RoutedEventArgs e)
		{
			SaveInfo();
			if()
		}

		private void SaveInfo()
		{
			string gender;
			int number;
			if (rbGFemale.IsChecked == true) gender = rbGFemale.Name;
			else gender = rbGFemale.Name;
			if (txStudNumber.Text != "Новая запись") number = fw.GetEntryCount() + 1;
			else number = int.Parse(txStudNumber.Text);
			StudentEntry se = new StudentEntry(number, txStudName.Text, gender, cbSpec.SelectedIndex);
			fw.PushEntry(se);
		}

		private void ShowInfo()
		{
			int i = int.Parse(txStudNumber.Text);
			var student = fw.PullEntry(i);
			txStudNumber.Text = student.Number.ToString();
			txStudName.Text = student.Name;
			var rb = (RadioButton)this.FindName(student.Gender);
			rb.IsChecked = true;
			cbSpec.SelectedItem = student.Spec;
		}


	}
}
