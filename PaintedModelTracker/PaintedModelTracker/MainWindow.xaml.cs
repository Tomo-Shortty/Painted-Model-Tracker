using PaintedModelTracker.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PaintedModelTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ModelList ModelList;
        private static readonly Regex regex = new("[0-9.-]+");

        public MainWindow()
        {
            InitializeComponent();
            ModelList = new ModelList();
            HideModelStatistics();
        }

        private static bool IsTextAllowed(string text)
        {
            return !regex.IsMatch(text);
        }

        private void ModelQuantityTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }

        private void ModelPaintedTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }

        private void HideModelStatistics()
        {
            ModelNameLabel.Visibility = Visibility.Hidden;
            ModelQuantityTitle.Visibility = Visibility.Hidden;
            ModelQuantityLabel.Visibility = Visibility.Hidden;
            ModelPaintedTitle.Visibility = Visibility.Hidden;
            ModelPaintedLabel.Visibility = Visibility.Hidden;
            ModelNotPaintedTitle.Visibility = Visibility.Hidden;
            ModelNotPaintedLabel.Visibility = Visibility.Hidden;
            ModelPercentagePaintedTitle.Visibility = Visibility.Hidden;
            ModelPercentagePaintedLabel.Visibility = Visibility.Hidden;
            EditModelButton.Visibility = Visibility.Hidden;
            RemoveModelButton.Visibility = Visibility.Hidden;
        }

        private void ShowModelStatistics()
        {
            ModelNameLabel.Visibility = Visibility.Visible;
            ModelQuantityTitle.Visibility = Visibility.Visible;
            ModelQuantityLabel.Visibility = Visibility.Visible;
            ModelPaintedTitle.Visibility = Visibility.Visible;
            ModelPaintedLabel.Visibility = Visibility.Visible;
            ModelNotPaintedTitle.Visibility = Visibility.Visible;
            ModelNotPaintedLabel.Visibility = Visibility.Visible;
            ModelPercentagePaintedTitle.Visibility = Visibility.Visible;
            ModelPercentagePaintedLabel.Visibility = Visibility.Visible;
            EditModelButton.Visibility = Visibility.Visible;
            RemoveModelButton.Visibility = Visibility.Visible;
        }

        private void ClearModelText()
        {
            ModelNameTextBox.Text = "";
            ModelQuantityTextBox.Text = "";
            ModelPaintedTextBox.Text = "";
        }

        private void AddModelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model newModel = new(ModelList.Models.Count + 1, ModelNameTextBox.Text, Convert.ToInt32(ModelQuantityTextBox.Text), 
                    Convert.ToInt32(ModelPaintedTextBox.Text));
                ModelList.AddModel(newModel);

                ListBoxItem item = new()
                {
                    Content = newModel.Name + "\nNumber of Models: " + Convert.ToString(newModel.Quantity) + "\tModels Painted: " +
                    Convert.ToString(newModel.Painted)
                };
                ModelListBox.Items.Add(item);

                ClearModelText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearModelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearModelText();
        }

        private void EditModelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveModelButton_Click(object sender, RoutedEventArgs e)
        {
            ModelList.RemoveModel(ModelListBox.SelectedIndex);
            ModelListBox.Items.RemoveAt(ModelListBox.SelectedIndex);
        }

        private void ClearListButton_Click(object sender, RoutedEventArgs e)
        {
            ModelListBox.Items.Clear();
            ModelList.ClearList();
            HideModelStatistics();
            ClearModelText();
        }

        private void ModelListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModelNameLabel.Content = ModelList.Models[(int)ModelListBox.SelectedIndex].Name;
            ModelQuantityLabel.Content = ModelList.Models[(int)ModelListBox.SelectedIndex].Quantity;
            ModelPaintedLabel.Content = ModelList.Models[(int)ModelListBox.SelectedIndex].Painted;
            ModelNotPaintedLabel.Content = ModelList.Models[(int)ModelListBox.SelectedIndex].NotPainted;
            ModelPercentagePaintedLabel.Content = ModelList.Models[(int)ModelListBox.SelectedIndex].PercentagePainted;
            ShowModelStatistics();
        }
    }
}
