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
    class CreateMaintenanceViewModel:ViewModelBase
    {
        #region property
        CreateMaintenance main;
        private tblClinicMaintenance _newMaintenance;
        public tblClinicMaintenance newMaintenance
        {
            get
            {
                return _newMaintenance;
            }
            set
            {
                _newMaintenance = value;
                OnPropertyChanged("newMaintenance");
            }
        }

        public bool isUpdated = false;
        public bool isEditingWindow = false;
        #endregion

        #region constructor
        public CreateMaintenanceViewModel(CreateMaintenance open)
        {
            main = open;
            newMaintenance = new tblClinicMaintenance();
        }

        public CreateMaintenanceViewModel(CreateMaintenance open, tblClinicMaintenance m)
        {
            main = open;
            newMaintenance = m;
            isEditingWindow = true;

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
                Queue<tblClinicMaintenance> queue = Service.Service.GetMaintenanceQueue();
                string message;
                //just for adding new items
                if (!isEditingWindow)
                {
                    message = "Clinic editClinic has been added.";
                    //if there is already 3 services, remove first one, then continue with adding
                    if (queue != null && queue.Count == 3)
                    {
                        tblClinicMaintenance deleteThis = queue.Dequeue();
                        Service.Service.DeleteMaintenance(deleteThis);
                    }
                }
                else
                {
                    message = "Clinic editClinic has been updated.";
                }
                tblClinicMaintenance maintenance = Service.Service.AddMaintenance(newMaintenance);
                if (maintenance != null)
                {
                    MessageBox.Show(message);
                    isUpdated = true;
                    main.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object obj)
        {
            if (!String.IsNullOrEmpty(newMaintenance.name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region logout
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
                main.Close();

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
        #endregion
    }

}
