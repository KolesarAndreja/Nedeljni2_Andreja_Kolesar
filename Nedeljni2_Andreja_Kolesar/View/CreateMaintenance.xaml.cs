using Nedeljni2_Andreja_Kolesar.Service;
using Nedeljni2_Andreja_Kolesar.ViewModel;
using System.Windows;

namespace Nedeljni2_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for CreateMaintenance.xaml
    /// </summary>
    public partial class CreateMaintenance : Window
    {
        public CreateMaintenance()
        {
            InitializeComponent();
            this.DataContext = new CreateMaintenanceViewModel(this);
        }

        public CreateMaintenance(tblClinicMaintenance m)
        {
            InitializeComponent();
            this.DataContext = new CreateMaintenanceViewModel(this, m);
        }
    }
}
