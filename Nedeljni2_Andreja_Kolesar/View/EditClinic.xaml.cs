using Nedeljni2_Andreja_Kolesar.Service;
using Nedeljni2_Andreja_Kolesar.ViewModel;
using System.Windows;

namespace Nedeljni2_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for EditClinic.xaml
    /// </summary>
    public partial class EditClinic : Window
    {
        public EditClinic(tblInstitute institute)
        {
            InitializeComponent();
            this.DataContext = new EditClinicVIewModel(this, institute);
        }
    }
}
