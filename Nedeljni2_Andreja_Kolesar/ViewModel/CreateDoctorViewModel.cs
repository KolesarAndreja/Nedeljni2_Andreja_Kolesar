using Nedeljni2_Andreja_Kolesar.Command;
using Nedeljni2_Andreja_Kolesar.Model;
using Nedeljni2_Andreja_Kolesar.Service;
using Nedeljni2_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni2_Andreja_Kolesar.ViewModel
{
    class CreateDoctorViewModel:ViewModelBase
    {
        #region Prop
        CreateDoctor register;

        private List<vwClinicManager> _allManagers;
        public List<vwClinicManager> allManagers
        {
            get
            {
                return _allManagers;
            }
            set
            {
                _allManagers = value;
                OnPropertyChanged("allManagers");
            }
        }

        private vwClinicManager _selectedManager;
        public vwClinicManager selectedManager
        {
            get
            {
                return _selectedManager;
            }
            set
            {
                _selectedManager = value;
                OnPropertyChanged("selectedManaager");
            }
        }

        private List<string> _shiftList =new List<string>()
        {
            "morning", "afternoon", "night", "24hours"
        };
        public List<string> shiftList
        {
            get
            {
                return _shiftList;
            }
            set
            {
                _shiftList = value;
                OnPropertyChanged("shiftList");
            }
        }

        private string _selectedShift;
        public string selectedShift
        {
            get
            {
                return _selectedShift;
            }
            set
            {
                _selectedShift = value;
                OnPropertyChanged("selectedShift");
            }
        }

        private tblUser _newUser;
        public tblUser newUser
        {
            get
            {
                return _newUser;
            }
            set
            {
                _newUser = value;
                OnPropertyChanged("newUser");
            }
        }

        private tblClinicDoctor _newDoctor;
        public tblClinicDoctor newDoctor
        {
            get
            {
                return _newDoctor;
            }
            set
            {
                _newDoctor = value;
                OnPropertyChanged("newDoctor");
            }
        }


        private string _currentPassword;
        public string currentPassword
        {
            get
            {
                return _currentPassword;
            }
            set
            {
                _currentPassword = value;
            }
        }

        public bool isUpdated { get; set; }
        public bool isEditingWindow = false;

        #endregion

        #region constructor
        public CreateDoctorViewModel(CreateDoctor open)
        {
            register = open;
            newUser = new tblUser();
            newDoctor = new tblClinicDoctor();
            allManagers = Service.Service.GetManagersList();
        }

        public CreateDoctorViewModel(CreateDoctor open, tblClinicDoctor d, tblUser u)
        {
            register = open;
            newUser = u;
            newDoctor = d;
            allManagers = Service.Service.GetManagersList();
            isEditingWindow = true;

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
                register.Close();

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
                currentPassword = (obj as PasswordBox).Password;
                if (Model.Person.ValidPassword(currentPassword))
                {
                    newUser.password = currentPassword;
                    tblUser u = Service.Service.AddUser(newUser);
                    newDoctor.userId = u.userId;
                    newDoctor.shift = selectedShift;
                    if (selectedManager != null)
                    {
                        newDoctor.managerId = selectedManager.managerId;
                    }
                    tblClinicDoctor doc = Service.Service.AddDoctor(newDoctor);
                    if (u != null && doc != null)
                    {
                        if (isEditingWindow)
                        {
                            content = "Doctor with id: " + doc.doctorId +" has been updated";
                        }
                        else
                        {
                            content = "Doctor with id: " + doc.doctorId + "has been registered";
                        }
                        MessageBox.Show(content);
                        isUpdated = true;
                        register.Close();
                    }
                }
                else
                {
                    content = "Doctor registration failed due to weak password";
                    MessageBox.Show("Pasword must contain at least 6charc including one upper, one lower, one numeric and one special char. Try again");
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
            if (!isEditingWindow)
            {
                if (!String.IsNullOrEmpty(newUser.citizenship) && !String.IsNullOrEmpty(newUser.fullname) && !String.IsNullOrEmpty(newUser.citizenship) && !String.IsNullOrEmpty(newUser.gender) && newUser.dateOfBirth != null && !String.IsNullOrEmpty(newUser.ICnumber) && !String.IsNullOrEmpty(newDoctor.account) && !String.IsNullOrEmpty(newDoctor.department) && !String.IsNullOrEmpty(selectedShift))
                {
                    currentPassword = (obj as PasswordBox).Password;
                    if (!String.IsNullOrEmpty(currentPassword))
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
    
        }
        #endregion
    }
}
