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
using System.Windows.Shapes;
using System.Windows.Markup;
// some change is added
// another important comment
namespace WPFCTSTuterModule
{
    /// <summary>
    /// Логика взаимодействия для WindowQuestionView.xaml
    /// </summary>
    public partial class WindowQuestionView : Window
    {
        public WindowQuestionView(string s)
        {
            InitializeComponent();

            UIElement XAMLQuestion = (UIElement)XamlReader.Parse(s);
            // Добавляем нашу динамическую верстку в контейнер - это пустой стек панел
            container.Children.Clear();
            container.Children.Add(XAMLQuestion);
        }
    }
}
