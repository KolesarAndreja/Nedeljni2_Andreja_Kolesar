using Nedeljni2_Andreja_Kolesar.Command;
using Nedeljni2_Andreja_Kolesar.Service;
using Nedeljni2_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni2_Andreja_Kolesar.ViewModel
{
    class AdministratorViewModel:ViewModelBase
    {
        Administrator administrator;
        #region constructor
        public AdministratorViewModel(Administrator open)
        {
            administrator = open;
            maintenanceList = Service.Service.GetMaintenanceList();
            maintenance = new tblClinicMaintenance();
        }
        #endregion

        #region property
        private List<tblClinicMaintenance> _maintenanceList;
        public List<tblClinicMaintenance> maintenanceList
        {
            get
            {
                return _maintenanceList;
            }
            set
            {
                _maintenanceList = value;
                OnPropertyChanged("maintenanceList");
            }
        }

        private tblClinicMaintenance _maintenance;
        public tblClinicMaintenance maintenance
        {
            get
            {
                return _maintenance;
            }
            set
            {
                _maintenance = value;
                OnPropertyChanged("maintenance");
            }
        }
        #endregion

        #region addMaintenance
        private ICommand _addMaintenance;
        public ICommand addMaintenance
        {
            get
            {
                if (_addMaintenance == null)
                {
                    _addMaintenance = new RelayCommand(param => RegistrationExecute(), param => CanRegistrationExecute());
                }
                return _addMaintenance;
            }
        }

        private void RegistrationExecute()
        {
            try
            {
                CreateMaintenance create = new CreateMaintenance();
                create.ShowDialog();
                if ((create.DataContext as CreateMaintenanceViewModel).isUpdated == true)
                {
                    maintenanceList = Service.Service.GetMaintenanceList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanRegistrationExecute()
        {
            return true;
        }
        #endregion

        #region EDIT
        private ICommand _edit;
        public ICommand edit
        {
            get
            {
                if (_edit == null)
                {
                    _edit = new RelayCommand(param => EditDateExecute(), param => CanEditExecute());
                }
                return _edit;
            }
        }

        private void EditDateExecute()
        {

            try
            {
                CreateMaintenance create = new CreateMaintenance(maintenance);
                create.ShowDialog();
                if ((create.DataContext as CreateMaintenanceViewModel).isUpdated == true)
                {
                    maintenanceList = Service.Service.GetMaintenanceList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanEditExecute()
        {
            return true;
        }
        #endregion

        #region log out
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
                Login login = new Login();
                administrator.Close();
                login.ShowDialog();

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

        #region delete
        private ICommand _delete;
        public ICommand delete
        {
            get
            {
                if (_delete == null)
                {
                    _delete = new Command.RelayCommand(param => DeleteExecute(), param => CanDeleteExecute());

                }
                return _delete;
            }
        }

        private void DeleteExecute()
        {
            MessageBoxResult result = MessageBox.Show("Do you realy want to delete this Maintenance?", "Delete Report", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Service.Service.DeleteMaintenance(maintenance);
                maintenanceList = Service.Service.GetMaintenanceList();
            }
        }
        private bool CanDeleteExecute()
        {
            return true;
        }
        #endregion

    }
}
