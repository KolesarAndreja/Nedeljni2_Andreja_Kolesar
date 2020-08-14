using Nedeljni2_Andreja_Kolesar.Service;
using Nedeljni2_Andreja_Kolesar.ViewModel;
using System.Windows;

namespace Nedeljni2_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for RegisterPatient.xaml
    /// </summary>
    public partial class RegisterPatient : Window
    {
        public RegisterPatient()
        {
            InitializeComponent();
            this.DataContext = new RegisterPatientViewModel(this);
        }

        public RegisterPatient(tblClinicPatient patient)
        {
            InitializeComponent();
            this.DataContext = new RegisterPatientViewModel(this, patient);
        }
    }
}
