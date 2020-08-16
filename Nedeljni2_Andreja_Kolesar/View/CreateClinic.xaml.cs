using Nedeljni2_Andreja_Kolesar.Service;
using Nedeljni2_Andreja_Kolesar.ViewModel;
using System.Windows;

namespace Nedeljni2_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for CreateClinic.xaml
    /// </summary>
    public partial class CreateClinic : Window
    {
        public CreateClinic(tblClinicAdministrator admin)
        {
            InitializeComponent();
            this.DataContext = new CreateClinicViewModel(this,admin);
        }
    }
}
