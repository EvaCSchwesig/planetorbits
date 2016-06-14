using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Orbiter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declare the simulation object and update timer
        Simulation simulation;
        DispatcherTimer stepTimer = new DispatcherTimer();

        // Declare the orbit geometry
        PathGeometry orbitGeometry = new PathGeometry();
        PathFigure orbitFigure = new PathFigure();

        // Declare the zoom parameter
        double zoom = 1.0;

        public MainWindow()
        {
            InitializeComponent();
            stepTimer.Tick += StepTimer_Tick;
            stepTimer.Interval = new TimeSpan(0, 0, 0, 0, 16);

            orbitGeometry.Figures.Add(orbitFigure);
            orbitPath.Data = orbitGeometry;
        }

        private void StepTimer_Tick(object sender, EventArgs e)
        {
            // Perform the next step of the simulation
            simulation.Step();

            // Get the time and position for the latest step
            var t = simulation.t[simulation.i];
            var x = simulation.x[simulation.i];
            var y = simulation.y[simulation.i];

            // Add the step to the data list view
            var item = new DataItem()
            {
                Time = t,
                X = x,
                Y = y,
            };
            dataListView.Items.Add(item);
            dataListView.ScrollIntoView(dataListView.Items[dataListView.Items.Count - 1]);

            // Update the visualization canvas
            orbitFigure.Segments.Add(new LineSegment(new Point(x, y), true));
            UpdateCanvas();

            // Disable the simulation timer once the simulation has ended
            if (simulation.i >= simulation.N - 1)
            {
                stepTimer.Stop();
            }
        }

        private void UpdateCanvas()
        {
            if (simulation == null)
                return;

            var w = outerCanvas.ActualWidth;
            var h = outerCanvas.ActualHeight;
            var x = simulation.x[simulation.i];
            var y = simulation.y[simulation.i];
            planetEllipse.RenderTransform = new TranslateTransform(
                x / zoom * w,
                y / zoom * h);
            orbitGeometry.Transform = new ScaleTransform(
                w / zoom,
                h / zoom);
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            // Reset the simulation and display the input window

            stepTimer.Stop();
            simulation = null;

            dataListView.Items.Clear();
            canvas.Visibility = Visibility.Hidden;
            orbitFigure.Segments.Clear();

            Initialize();
        }

        private void Initialize()
        {
            // Display the input window
            var inputWindow = new InputWindow();
            inputWindow.Owner = this;
            if (inputWindow.ShowDialog().Value == false)
            {
                Application.Current.Shutdown();
                return;
            }

            // Obtain the input from the window
            string planetName = ((ComboBoxItem)inputWindow.planetComboBox.SelectedItem).Content.ToString();
            double timeStep = (double)inputWindow.timestepUpDown.Value;
            double length = (double)inputWindow.lengthUpDown.Value;
            IPlanet planet = null;

            // Initialize the planet object by name
            switch (planetName)
            {
                case "Mercury":
                    planet = new Mercury();
                    break;

                case "Venus":
                    planet = new Venus();
                    break;

                case "Earth":
                    planet = new Earth();
                    break;

                case "Mars":
                    planet = new Mars();
                    break;

                case "Jupiter":
                    planet = new Jupiter();
                    break;

                case "Saturn":
                    planet = new Saturn();
                    break;

                case "Uranus":
                    planet = new Uranus();
                    break;

                case "Neptune":
                    planet = new Neptune();
                    break;
            }

            // Initialize the simulation
            simulation = new Simulation(timeStep, length, planet);

            // Initialize the geometry
            var initialX = simulation.x[0];
            var initialY = simulation.y[0];
            zoom = 2.75 * planet.Radius;
            orbitFigure.StartPoint = new Point(initialX, initialY);
            planetEllipse.RenderTransform = new TranslateTransform(
                planet.Radius / zoom * outerCanvas.ActualWidth,
                planet.Radius / zoom * outerCanvas.ActualHeight);
            planetEllipse.Fill = new ImageBrush(planet.Texture);
            UpdateScale();
            canvas.Visibility = Visibility.Visible;

            // Start the simulation
            stepTimer.Start();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateScale();
            UpdateCanvas();
        }

        private void UpdateScale()
        {
            if (simulation == null)
                return;

            var radius = simulation.Planet.Radius;
            var actualWidth = outerCanvas.ActualWidth;
            var actualHeight = outerCanvas.ActualHeight;

            minimumLabel.Content = string.Format("{0} AU", -radius);
            minimumLabel.UpdateLayout();

            maximumLabel.Content = string.Format("{0} AU", radius);
            maximumLabel.UpdateLayout();

            axis.X2 = actualWidth / zoom * radius;
            axis.X1 = -axis.X2;
            axis.Y1 = -(actualHeight / 2 - 8);
            axis.Y2 = axis.Y1;

            var tickY1 = axis.Y1;
            var tickY2 = tickY1 + 8;
            var labelTop = tickY2 - 4;

            minimumTick.X1 = axis.X1;
            minimumTick.X2 = minimumTick.X1;
            minimumTick.Y1 = tickY1;
            minimumTick.Y2 = tickY2;

            Canvas.SetTop(minimumLabel, labelTop);
            Canvas.SetLeft(minimumLabel, minimumTick.X1 - minimumLabel.ActualWidth / 2);

            middleTick.X1 = 0;
            middleTick.X2 = middleTick.X1;
            middleTick.Y1 = tickY1;
            middleTick.Y2 = tickY2;

            Canvas.SetTop(middleLabel, labelTop);
            Canvas.SetLeft(middleLabel, middleTick.X1 - middleLabel.ActualWidth / 2);

            maximumTick.X1 = axis.X2;
            maximumTick.X2 = maximumTick.X1;
            maximumTick.Y1 = tickY1;
            maximumTick.Y2 = tickY2;

            Canvas.SetTop(maximumLabel, labelTop);
            Canvas.SetLeft(maximumLabel, maximumTick.X1 - maximumLabel.ActualWidth / 2);
        }
    }
}
