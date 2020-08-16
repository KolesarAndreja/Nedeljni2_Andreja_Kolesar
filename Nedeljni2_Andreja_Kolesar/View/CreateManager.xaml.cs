using Nedeljni2_Andreja_Kolesar.Service;
using Nedeljni2_Andreja_Kolesar.ViewModel;
using System.Windows;

namespace Nedeljni2_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for CreateManager.xaml
    /// </summary>
    public partial class CreateManager : Window
    {
        public CreateManager()
        {
            InitializeComponent();
            this.DataContext = new CreateManagerViewModel(this);
        }

        public CreateManager(tblClinicManager man, tblUser user)
        {
            InitializeComponent();
            this.DataContext = new CreateManagerViewModel(this,man, user);
        }

    }
}
