using Nedeljni2_Andreja_Kolesar.Command;
using Nedeljni2_Andreja_Kolesar.Model;
using Nedeljni2_Andreja_Kolesar.Service;
using Nedeljni2_Andreja_Kolesar.View;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni2_Andreja_Kolesar.ViewModel
{
    class CreateManagerViewModel:ViewModelBase
    {
        #region Prop
        CreateManager register;
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

        private tblClinicManager _newManager;
        public tblClinicManager newManager
        {
            get
            {
                return _newManager;
            }
            set
            {
                _newManager = value;
                OnPropertyChanged("newManager");
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
        public CreateManagerViewModel(CreateManager open)
        {
            register = open;
            newUser = new tblUser();
            newManager = new tblClinicManager();
        }

        public CreateManagerViewModel(CreateManager open, tblClinicManager man, tblUser user)
        {
            register = open;
            newUser = user;
            newManager = man;
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
                    _logOut = new Command.RelayCommand(param => LogOutExecute(), param => CanLogOutExecute());
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
                string message = null;
                currentPassword = (obj as PasswordBox).Password;
                if (Model.Person.ValidPassword(currentPassword))
                {
                    newUser.password = currentPassword;
                    tblUser u = Service.Service.AddUser(newUser);
                    newManager.userId = u.userId;
                    tblClinicManager m = Service.Service.AddManager(newManager);
                    if (u != null && m != null)
                    {
                        if (isEditingWindow)
                            message = "Manager with id:" + m.managerId +"  has been upated";
                        else
                        {
                            message = "Manager with id:" + m.managerId + "  has been registered.";
                        }
                        MessageBox.Show(message);
                        isUpdated = true;
                        register.Close();
                    }
                }
                else
                {
                    message = "Manager registration failed due to weak password";
                    MessageBox.Show("Pasword must contain at least 6charc including one upper, one lower, one numeric and one special char. Try again");
                }
                LogIntoFile.getInstance().PrintActionIntoFile(message);
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
                if (!String.IsNullOrEmpty(newUser.citizenship) && !String.IsNullOrEmpty(newUser.fullname) && !String.IsNullOrEmpty(newUser.citizenship) && !String.IsNullOrEmpty(newUser.gender) && newUser.dateOfBirth != null && !String.IsNullOrEmpty(newUser.ICnumber))
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
