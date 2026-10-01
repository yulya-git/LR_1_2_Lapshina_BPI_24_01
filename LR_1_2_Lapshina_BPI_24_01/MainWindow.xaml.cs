using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LR_1_2_Lapshina_BPI_24_01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            cubeRadio.Checked += SelectFigure;
            cylinderRadio.Checked += SelectFigure;
            tetrahedronRadio.Checked += SelectFigure;

            calculateV.Click += CalculateVolume;
            calculateS.Click += CalculateSurfaceArea;

            UpdatePanelsVisibility();
        }

        private void UpdatePanelsVisibility()
        {
            if (cubeRadio.IsChecked == true)
            {
                cubePanel.Visibility = Visibility.Visible;
                cylinderPanel.Visibility = Visibility.Collapsed;
                tetrahedronPanel.Visibility = Visibility.Collapsed;
            }
            else if (cylinderRadio.IsChecked == true)
            {
                cubePanel.Visibility = Visibility.Collapsed;
                cylinderPanel.Visibility = Visibility.Visible;
                tetrahedronPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                cubePanel.Visibility = Visibility.Collapsed;
                cylinderPanel.Visibility = Visibility.Collapsed;
                tetrahedronPanel.Visibility = Visibility.Visible;
            }

            resultV.Content = "Не посчитан";
            resultS.Content = "Не посчитана";
            message.Content = "Нет";
        }

        private void SelectFigure(object sender, RoutedEventArgs e)
        {
            UpdatePanelsVisibility();
        }

        private bool ValidateTextBox(TextBox input)
        {
            if (string.IsNullOrWhiteSpace(input.Text))
            {
                input.Background = Brushes.Red;
                return false;
            }

            if (double.TryParse(input.Text, out double value) && value > 0)
            {
                input.Background = Brushes.Green;
                return true;
            }
            else
            {
                input.Background = Brushes.Red;
                return false;
            }
        }

        private bool AreAllInputsValid()
        {
            if (cubeRadio.IsChecked == true)
            {
                return ValidateTextBox(inputCubeSide);
            }

            if (cylinderRadio.IsChecked == true)
            {
                bool radiusOk = ValidateTextBox(inputCylRadius);
                bool heightOk = ValidateTextBox(inputCylHeight);
                return radiusOk && heightOk;
            }

            if (tetrahedronRadio.IsChecked == true)
            {
                return ValidateTextBox(inputTetraSide);
            }

            return false;
        }

        private Figure CreateFigure()
        {
            if (cubeRadio.IsChecked == true)
            {
                double side = double.Parse(inputCubeSide.Text);
                return new Cube(side);
            }

            if (cylinderRadio.IsChecked == true)
            {
                double radius = double.Parse(inputCylRadius.Text);
                double height = double.Parse(inputCylHeight.Text);
                return new Cylinder(radius, height);
            }

            if (tetrahedronRadio.IsChecked == true)
            {
                double side = double.Parse(inputTetraSide.Text);
                return new Tetrahedron(side);
            }

            throw new Exception("Фигура не выбрана");
        }

        private void CalculateVolume(object sender, RoutedEventArgs e)
        {
            message.Content = "Ошибка";
            resultV.Content = "Не посчитан";

            if (!AreAllInputsValid())
            {
                message.Content = "Ошибка";
                return;
            }

            try
            {
                Figure figure = CreateFigure();
                double volume = figure.GetVolume();
                resultV.Content = volume.ToString("F2");
                message.Content = "Объём посчитан";
            }
            catch (Exception)
            {
                message.Content = "Ошибка";
            }
        }

        private void CalculateSurfaceArea(object sender, RoutedEventArgs e)
        {
            message.Content = "Ошибка";
            resultS.Content = "Не посчитана";

            if (!AreAllInputsValid())
            {
                message.Content = "Ошибка";
                return;
            }

            try
            {
                Figure figure = CreateFigure();
                double surfaceArea = figure.GetSurfaceArea();
                resultS.Content = surfaceArea.ToString("F2");
                message.Content = "Площадь посчитана";
            }
            catch (Exception)
            {
                message.Content = "Ошибка";
            }
        }

        public void checkInputData(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            ValidateTextBox(textBox);
        }
    }
}
