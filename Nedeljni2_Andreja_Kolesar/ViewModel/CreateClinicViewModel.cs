using Nedeljni2_Andreja_Kolesar.Command;
using Nedeljni2_Andreja_Kolesar.Service;
using Nedeljni2_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni2_Andreja_Kolesar.ViewModel
{
    class CreateClinicViewModel:ViewModelBase
    {
        #region Prop
        CreateClinic clinic;
        private tblInstitute _newClinic;
        public tblInstitute newClinic
        {
            get
            {
                return _newClinic;
            }
            set
            {
                _newClinic = value;
                OnPropertyChanged("newClinic");
            }
        }

        private tblClinicAdministrator _admininstrator;
        public tblClinicAdministrator admininstrator
        {
            get
            {
                return _admininstrator;
            }
            set
            {
                _admininstrator = value;
                OnPropertyChanged("admininstrator");
            }
        }
        #endregion

        #region constructor
        public CreateClinicViewModel(CreateClinic open, tblClinicAdministrator admin)
        {
            clinic = open;
            newClinic = new tblInstitute();
            admininstrator = admin;
        }
        #endregion

        #region save
        private ICommand _save;
        public ICommand save
        {
            get
            {
                if (_save == null)
                {
                    _save = new RelayCommand(SaveExecute, CanSaveExecute);
                }
                return _save;
            }
        }

        private void SaveExecute(object obj)
        {
            try
            {
                //add new clinic
                tblInstitute institute = Service.Service.AddInstitute(newClinic);
                admininstrator.instituteId = institute.instituteId;
                //edit admin
                Service.Service.AddAdministrator(admininstrator);
                if (institute != null)
                {
                    Administrator a = new Administrator();
                    MessageBox.Show("Clinic has been created.");
                    clinic.Close();
                    a.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object obj)
        {
            //currentPassword = (obj as PasswordBox).Password;
            //if (!String.IsNullOrEmpty(newUser.fullname) && !String.IsNullOrEmpty(newUser.citizenship) && !String.IsNullOrEmpty(currentPassword) && !String.IsNullOrEmpty(newUser.gender) && newUser.dateOfBirth!=null && !String.IsNullOrEmpty(newUser.ICnumber))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }
        #endregion
    }
}
