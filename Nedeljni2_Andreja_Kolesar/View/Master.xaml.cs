using Nedeljni2_Andreja_Kolesar.ViewModel;
using System.Windows;

namespace Nedeljni2_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for Master.xaml
    /// </summary>
    public partial class Master : Window
    {
        public Master()
        {
            InitializeComponent();
            this.DataContext = new MasterViewModel(this);
        }

    }
}
