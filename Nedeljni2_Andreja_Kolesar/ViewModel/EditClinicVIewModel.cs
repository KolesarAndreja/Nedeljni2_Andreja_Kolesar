using Nedeljni2_Andreja_Kolesar.Command;
using Nedeljni2_Andreja_Kolesar.Model;
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
                string content = null;
                tblInstitute previous = Service.Service.GetInstitute();
                if(previous.numberOfAccessPointsForInvalids>editClinic.numberOfAccessPointsForInvalids || previous.numberOfAmbulanceAccessPoints > editClinic.numberOfAmbulanceAccessPoints)
                {
                    MessageBox.Show("Access points can only be greater than previous ones.");
                    content = "Unsuccessful update of clinic due to lower values of access pointes then previouse ones.";
                }
                else
                { 
                    //edit
                    tblInstitute institute = Service.Service.AddInstitute(editClinic);
                    if (institute != null)
                    {
                        content = "Clinic has been edited.";
                        MessageBox.Show("Clinic has been edited.");
                        clinic.Close();
                    }

                }
                
                LogIntoFile.getInstance().PrintActionIntoFile(content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object obj)
        {
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
