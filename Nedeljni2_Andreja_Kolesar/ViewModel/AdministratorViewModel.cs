using Nedeljni2_Andreja_Kolesar.Command;
using Nedeljni2_Andreja_Kolesar.Model;
using Nedeljni2_Andreja_Kolesar.Service;
using Nedeljni2_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni2_Andreja_Kolesar.ViewModel
{
    class AdministratorViewModel : ViewModelBase
    {
        Administrator administrator;
        #region constructor
        public AdministratorViewModel(Administrator open)
        {
            administrator = open;
            maintenanceList = Service.Service.GetMaintenanceList();
            doctorList = Service.Service.DoctorList();
            patientList = Service.Service.PatientsList();
            managerList = Service.Service.GetManagersList();
            maintenance = new tblClinicMaintenance();
            doctor = new tblClinicDoctor();
            manager = new vwClinicManager();
            patient = new tblClinicPatient();
        }
        #endregion

        #region list
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

        private List<tblClinicDoctor> _doctorList;
        public List<tblClinicDoctor> doctorList
        {
            get
            {
                return _doctorList;
            }
            set
            {
                _doctorList = value;
                OnPropertyChanged("doctorList");
            }
        }

        private List<tblClinicPatient> _patientList;
        public List<tblClinicPatient> patientList
        {
            get
            {
                return _patientList;
            }
            set
            {
                _patientList = value;
                OnPropertyChanged("patientList");
            }
        }

        private List<vwClinicManager> _managerList;
        public List<vwClinicManager> managerList
        {
            get
            {
                return _managerList;
            }
            set
            {
                _managerList = value;
                OnPropertyChanged("managerList");
            }
        }
        #endregion

        #region property 
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
                OnPropertyChanged("editClinic");
            }
        }

        private tblClinicDoctor _doctor;
        public tblClinicDoctor doctor
        {
            get
            {
                return _doctor;
            }
            set
            {
                _doctor = value;
                OnPropertyChanged("doctor");
            }
        }

        private vwClinicManager _manager;
        public vwClinicManager manager
        {
            get
            {
                return _manager;
            }
            set
            {
                _manager = value;
                OnPropertyChanged("manager");
            }
        }

        private tblClinicPatient _patient;
        public tblClinicPatient patient
        {
            get
            {
                return _patient;
            }
            set
            {
                _patient = value;
                OnPropertyChanged("patient");
            }
        }
        #endregion

        #region add commands
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



        private ICommand _addManager;
        public ICommand addManager
        {
            get
            {
                if (_addManager == null)
                {
                    _addManager = new RelayCommand(param => AddManagerExecute(), param => CanAddManagerExecute());
                }
                return _addManager;
            }
        }

        private void AddManagerExecute()
        {
            try
            {
                CreateManager man = new CreateManager();
                man.ShowDialog();
                if((man.DataContext as CreateManagerViewModel).isUpdated == true)
                {
                    managerList = Service.Service.GetManagersList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddManagerExecute()
        {
            return true;
        }



        private ICommand _addDoctor;
        public ICommand addDoctor
        {
            get
            {
                if (_addDoctor == null)
                {
                    _addDoctor = new RelayCommand(param => AddDoctorExecute(), param => CanAddDoctorExecute());
                }
                return _addDoctor;
            }
        }

        private void AddDoctorExecute()
        {
            try
            {
                CreateDoctor create = new CreateDoctor();
                create.ShowDialog();
                if ((create.DataContext as CreateDoctorViewModel).isUpdated == true)
                {
                    doctorList = Service.Service.DoctorList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddDoctorExecute()
        {
            return true;
        }



        private ICommand _addPatient;
        public ICommand addPatient
        {
            get
            {
                if (_addPatient == null)
                {
                    _addPatient = new RelayCommand(param => AddPatientExecute(), param => CanAddPatientExecute());
                }
                return _addPatient;
            }
        }

        private void AddPatientExecute()
        {
            try
            {
                RegisterPatient register = new RegisterPatient();
                register.ShowDialog();
                if ((register.DataContext as RegisterPatientViewModel).isUpdated == true)
                {
                    patientList = Service.Service.PatientsList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddPatientExecute()
        {
            return true;
        }
        #endregion

        #region EDIT
        private ICommand _editClinic;
        public ICommand editClinic
        {
            get
            {
                if (_editClinic == null)
                {
                    _editClinic = new RelayCommand(param => EditClinicExecute(), param => CanEditClinicExecute());
                }
                return _editClinic;
            }
        }

        private void EditClinicExecute()
        {
            try
            {
                tblInstitute institute = Service.Service.GetInstitute();
                EditClinic editClinic = new EditClinic(institute);
                editClinic.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanEditClinicExecute()
        {
            return true;
        }



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



        private ICommand _editPatient;
        public ICommand editPatient
        {
            get
            {
                if (_editPatient == null)
                {
                    _editPatient = new RelayCommand(param => EditPatientDateExecute(), param => CanEditPatientExecute());
                }
                return _editPatient;
            }
        }

        private void EditPatientDateExecute()
        {

            try
            {
                int id = patient.patientId;
                int? userId = patient.userId;
                tblUser user = Service.Service.UserById(userId);
                RegisterPatient create = new RegisterPatient(patient,user);
                create.ShowDialog();
                if ((create.DataContext as RegisterPatientViewModel).isUpdated == true)
                {
                    patientList = Service.Service.PatientsList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanEditPatientExecute()
        {
            return true;
        }



        private ICommand _editManager;
        public ICommand editManager
        {
            get
            {
                if (_editManager == null)
                {
                    _editManager = new RelayCommand(param => EditManagerExecute(), param => CanEditManagerExecute());
                }
                return _editManager;
            }
        }

        private void EditManagerExecute()
        {

            try
            {
                int managerId = manager.managerId;
                int userId = manager.userId;
                tblUser user = Service.Service.UserById(userId);
                tblClinicManager man= Service.Service.ManagerById(managerId);
                CreateManager create = new CreateManager(man, user);
                create.ShowDialog();
                if ((create.DataContext as CreateManagerViewModel).isUpdated == true)
                {
                    managerList = Service.Service.GetManagersList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanEditManagerExecute()
        {
            return true;
        }


        private ICommand _editDoctor;
        public ICommand editDoctor
        {
            get
            {
                if (_editDoctor == null)
                {
                    _editDoctor = new RelayCommand(param => EditDoctorExecute(), param => CanEditDoctorExecute());
                }
                return _editDoctor;
            }
        }

        private void EditDoctorExecute()
        {
            try
            {
                int? userId = doctor.userId;
                tblUser user = Service.Service.UserById(userId);
                CreateDoctor create = new CreateDoctor(doctor, user);
                create.ShowDialog();
                if ((create.DataContext as CreateDoctorViewModel).isUpdated == true)
                {
                    doctorList = Service.Service.DoctorList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanEditDoctorExecute()
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
                string content = "Administrator has logged out.";
                LogIntoFile.getInstance().PrintActionIntoFile(content);
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
                string content = "Clinic Maintenance with id: " + maintenance.maintenanceId + "has been deleted.";
                LogIntoFile.getInstance().PrintActionIntoFile(content);
                Service.Service.DeleteMaintenance(maintenance);
                maintenanceList = Service.Service.GetMaintenanceList();
            }
        }
        private bool CanDeleteExecute()
        {
            return true;
        }


        private ICommand _deletePatient;
        public ICommand deletePatient
        {
            get
            {
                if (_deletePatient == null)
                {
                    _deletePatient = new Command.RelayCommand(param => DeletePatientExecute(), param => CanDeletePatientExecute());

                }
                return _deletePatient;
            }
        }

        private void DeletePatientExecute()
        {
            MessageBoxResult result = MessageBox.Show("Do you realy want to delete this Patient?", "Delete Patient", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                string content = "Clinic Patient with id: " + patient.patientId + "has been deleted.";
                LogIntoFile.getInstance().PrintActionIntoFile(content);
                Service.Service.DeletePatient(Service.Service.PatientById(patient.patientId));
                patientList = Service.Service.PatientsList();
            }
        }
        private bool CanDeletePatientExecute()
        {
            return true;
        }



        private ICommand _deleteManager;
        public ICommand deleteManager
        {
            get
            {
                if (_deleteManager == null)
                {
                    _deleteManager = new Command.RelayCommand(param => DeleteManagerExecute(), param => CanDeleteManagerExecute());

                }
                return _deleteManager;
            }
        }

        private void DeleteManagerExecute()
        {
            MessageBoxResult result = MessageBox.Show("Do you realy want to delete this Manager?", "Delete Manager", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                string content = "Clinic Manager with id: " + manager.managerId + "has been deleted.";
                LogIntoFile.getInstance().PrintActionIntoFile(content);
                Service.Service.DeleteManager(Service.Service.ManagerById(manager.managerId));
                managerList = Service.Service.GetManagersList();
                doctorList = Service.Service.DoctorList();
            }
        }
        private bool CanDeleteManagerExecute()
        {
            return true;
        }


        private ICommand _deleteDoctor;
        public ICommand deleteDoctor
        {
            get
            {
                if (_deleteDoctor == null)
                {
                    _deleteDoctor = new Command.RelayCommand(param => DeleteDoctorExecute(), param => CanDeleteDoctorExecute());

                }
                return _deleteDoctor;
            }
        }

        private void DeleteDoctorExecute()
        {
            MessageBoxResult result = MessageBox.Show("Do you realy want to delete this Doctor?", "Delete Doctor", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                string content = "Clinic Doctor with id: " + doctor.doctorId + "has been deleted.";
                LogIntoFile.getInstance().PrintActionIntoFile(content);
                Service.Service.DeleteDoctor(Service.Service.DoctorById(doctor.doctorId));
                doctorList = Service.Service.DoctorList();
                patientList = Service.Service.PatientsList();
            }
        }
        private bool CanDeleteDoctorExecute()
        {
            return true;
        }
        #endregion

        #region Visibility
        private Visibility _viewManager = Visibility.Collapsed;
        public Visibility viewManager
        {
            get
            {
                return _viewManager;
            }
            set
            {
                _viewManager = value;
                OnPropertyChanged("viewManager");
            }
        }

        private Visibility _viewPatient = Visibility.Collapsed;
        public Visibility viewPatient
        {
            get
            {
                return _viewPatient;
            }
            set
            {
                _viewPatient = value;
                OnPropertyChanged("viewPatient");
            }
        }

        private Visibility _viewDoctor = Visibility.Collapsed;
        public Visibility viewDoctor
        {
            get
            {
                return _viewDoctor;
            }
            set
            {
                _viewDoctor = value;
                OnPropertyChanged("viewDoctor");
            }
        }

        private Visibility _viewMaintenance = Visibility.Collapsed;
        public Visibility viewMaintenance
        {
            get
            {
                return _viewMaintenance;
            }
            set
            {
                _viewMaintenance = value;
                OnPropertyChanged("viewMaintenance");
            }
        }
        #endregion

        #region read button commands

        private ICommand _readMaintenance;
        public ICommand readMaintenance
        {
            get
            {
                if (_readMaintenance == null)
                {
                    _readMaintenance = new RelayCommand(param => ReadMaintenanceExecute(), param => CanReadMaintenanceExecute());
                }
                return _readMaintenance;
            }
        }
        private void ReadMaintenanceExecute()
        {

            try
            {
                viewMaintenance = Visibility.Visible;
                viewDoctor = Visibility.Hidden;
                viewManager = Visibility.Hidden;
                viewPatient = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanReadMaintenanceExecute()
        {
            return true;
        }


        private ICommand _readManager;
        public ICommand readManager
        {
            get
            {
                if (_readManager == null)
                {
                    _readManager = new RelayCommand(param => ReadManagerExecute(), param => CanReadManagerExecute());
                }
                return _readManager;
            }
        }

        private void ReadManagerExecute()
        {

            try
            {
                viewMaintenance = Visibility.Hidden;
                viewDoctor = Visibility.Hidden;
                viewManager = Visibility.Visible;
                viewPatient = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanReadManagerExecute()
        {
            return true;
        }


        private ICommand _readDoctor;
        public ICommand readDoctor
        {
            get
            {
                if (_readDoctor == null)
                {
                    _readDoctor = new RelayCommand(param => ReadDoctorExecute(), param => CanReadDoctorExecute());
                }
                return _readDoctor;
            }
        }

        private void ReadDoctorExecute()
        {

            try
            {
                viewMaintenance = Visibility.Hidden;
                viewDoctor = Visibility.Visible;
                viewManager = Visibility.Hidden;
                viewPatient = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanReadDoctorExecute()
        {
            return true;
        }



        private ICommand _readPatient;
        public ICommand readPatient
        {
            get
            {
                if (_readPatient == null)
                {
                    _readPatient = new RelayCommand(param => ReadPatientExecute(), param => CanReadPatientExecute());
                }
                return _readPatient;
            }
        }

        private void ReadPatientExecute()
        {

            try
            {
                viewMaintenance = Visibility.Hidden;
                viewDoctor = Visibility.Hidden;
                viewManager = Visibility.Hidden;
                viewPatient = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanReadPatientExecute()
        {
            return true;
        }
        #endregion
    }
}
