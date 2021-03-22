using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace WpfApplication1
{
    public partial class MainWindow
    {
        private string[,] TypeMans = Converter.GetArray("Male");
        private int val;
        public MainWindow()
        {
            InitializeComponent();
            foreach (var button in FirstButtons.Children)
            {
                if (button is Button)
                {
                    ((Button) button).Click += Button_OnClick;
                }
            }
            val = TypeMans.Length / 8;
            UpdateData(val);
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var but in FirstButtons.Children)
            {
                if (but is Button)
                {
                    ((Button) but).Background = new SolidColorBrush (Color.FromRgb(25, 59, 82));
                }
            }
            if (e.OriginalSource is Button button)
            {
                var type = button.Content.ToString();
                TypeMans = Converter.GetArray(type);
                switch (type)
                {
                    case "Male":
                        button.Background = new SolidColorBrush (Color.FromRgb(37, 87, 120));
                        break;
                    case "Female":
                        button.Background = new SolidColorBrush (Color.FromRgb(37, 87, 120));
                        break;
                    case "Boy":
                        button.Background = new SolidColorBrush (Color.FromRgb(37, 87, 120));
                        break;
                    default:
                        button.Background = new SolidColorBrush (Color.FromRgb(37, 87, 120));
                        break;
                }
            }
            val = TypeMans.Length/8;
            UpdateData(val);

        }
        
        private void UIElement_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            val -= e.Delta / 120;
            
            if (val <= 0)
                val = 0;
            else if (val >= (TypeMans.Length/4-1))
                val = (TypeMans.Length/4-1);
            UpdateData(val);
        }

        public void UpdateData(int value)
        {
            MainText.Text = TypeMans[0,value];
            int index = 1;
            TextBlock1.Text = TypeMans[1,value];
            TextBlock2.Text = TypeMans[2,value];
            TextBlock3.Text = TypeMans[3,value];

            if (val == 0)
            {
                DownScrollText.Text = TypeMans[0,(value + 1)];
                TopScrollText.Text = "";
            }
            else
            {
                TopScrollText.Text = TypeMans[0,(value - 1)];
            }
            
            if (val == (TypeMans.Length/4-1))
            {
                TopScrollText.Text =TypeMans[0,(value - 1)];
                DownScrollText.Text = "";
            }
            else
            {
                DownScrollText.Text = TypeMans[0,(value + 1)];
            }

        }

        private void UIElement_OnMouseDown_ElemUp(object sender, MouseButtonEventArgs e)
        {
            val++;
            if (val <= 0)
                val = 0;
            else if (val >= (TypeMans.Length/4-1))
                val = (TypeMans.Length/4-1);
            UpdateData(val);

        }

        private void UIElement_OnMouseDown_ElemDown(object sender, MouseButtonEventArgs e)
        {
            val--;
            if (val <= 0)
                val = 0;
            else if (val >= (TypeMans.Length/4-1))
                val = (TypeMans.Length/4-1);
            UpdateData(val);
        }
    }
}