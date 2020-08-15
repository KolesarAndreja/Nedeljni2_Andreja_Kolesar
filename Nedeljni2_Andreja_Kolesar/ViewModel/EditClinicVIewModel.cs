using Nedeljni2_Andreja_Kolesar.Command;
using Nedeljni2_Andreja_Kolesar.Service;
using Nedeljni2_Andreja_Kolesar.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni2_Andreja_Kolesar.ViewModel
{
    class EditClinicVIewModel:ViewModelBase
    {
        EditClinic clinic;
        private tblInstitute _editClinic;
        public tblInstitute editClinic
        {
            get
            {
                return _editClinic;
            }
            set
            {
                _editClinic = value;
                OnPropertyChanged("editClinic");
            }
        }
        public EditClinicVIewModel(EditClinic open, tblInstitute institute)
        {
            clinic = open;
            editClinic = institute;
        }


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
                tblInstitute institute = Service.Service.AddInstitute(editClinic);
                if (institute != null)
                {
                    MessageBox.Show("Clinic has been edited.");
                    clinic.Close();
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

        private ICommand _logOut;
        public ICommand logOut
        {
            get
            {
                if (_logOut == null)
                {
                    _logOut = new RelayCommand(param => LogOutExecute(), param => CanLogOutExecute());
                }
                return _logOut;
            }
        }

        private void LogOutExecute()
        {
            try
            {
                clinic.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogOutExecute()
        {
            return true;
        }
    }
}
