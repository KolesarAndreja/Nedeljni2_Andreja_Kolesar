using Nedeljni2_Andreja_Kolesar.Service;
using Nedeljni2_Andreja_Kolesar.ViewModel;
using System.Windows;

namespace Nedeljni2_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for CreateDoctor.xaml
    /// </summary>
    public partial class CreateDoctor : Window
    {
        public CreateDoctor()
        {
            InitializeComponent();
            this.DataContext = new CreateDoctorViewModel(this);
        }

        public CreateDoctor(tblClinicDoctor doc,tblUser user)
        {
            InitializeComponent();
            this.DataContext = new CreateDoctorViewModel(this,doc,user);
        }
    }
}
