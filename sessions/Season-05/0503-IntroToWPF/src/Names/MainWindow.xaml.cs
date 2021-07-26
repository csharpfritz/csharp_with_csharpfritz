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

namespace Names
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{

			if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
			{
				lstNames.Items.Add(txtName.Text);

				// TODO: Show an error messagebox if the name is already in the box

				// TODO: Clear the textbox so we don't create the same name twice

				// TODO: Nice to have - move cursor back to textbox after button click

			} 

		}
	}
}
