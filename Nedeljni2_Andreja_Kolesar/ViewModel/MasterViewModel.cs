﻿using Nedeljni2_Andreja_Kolesar.Command;
using Nedeljni2_Andreja_Kolesar.Model;
using Nedeljni2_Andreja_Kolesar.Service;
using Nedeljni2_Andreja_Kolesar.View;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni2_Andreja_Kolesar.ViewModel
{
    class MasterViewModel:ViewModelBase
    {
        #region Prop
        Master master;
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

        private tblClinicAdministrator _newAdministrator;
        public tblClinicAdministrator newAdministrator
        {
            get
            {
                return _newAdministrator;
            }
            set
            {
                _newAdministrator = value;
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

        #endregion

        #region constructor
        public MasterViewModel(Master open)
        {
            master = open;
            newUser = new tblUser();
            newAdministrator = new tblClinicAdministrator();
            currentPassword = null;
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
                string content = "Master has logged out.";
                LogIntoFile.getInstance().PrintActionIntoFile(content);
                Login login = new Login();
                master.Close();
                login.Show();

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
                    newAdministrator.userId = u.userId;
                    tblClinicAdministrator a = Service.Service.AddAdministrator(newAdministrator);
                    if (u != null && a != null)
                    {
                        content = "Administrator with username " + newUser.username + " has been registered.";
                        Login login = new Login();
                        MessageBox.Show("Administrator has been registered.");
                        master.Close();
                        login.Show();

                    }
                }
                else
                {
                    content = "Administrator registration failed due to weak password";
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
            if (!String.IsNullOrEmpty(newUser.citizenship)&&!String.IsNullOrEmpty(newUser.fullname) && !String.IsNullOrEmpty(newUser.citizenship) && !String.IsNullOrEmpty(newUser.gender) && newUser.dateOfBirth != null && !String.IsNullOrEmpty(newUser.ICnumber))
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
        #endregion

        #region Visibility
        private Visibility _createAdmin;
        public Visibility createAdmin
        {
            get
            {
                if (Service.Service.AdminExist())
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
            set
            {
                _createAdmin = value;
                OnPropertyChanged("createAdmin");
            }
        }

        private Visibility _alreadyAdmin;
        public Visibility alreadyAdmin
        {
            get
            {
                if (Service.Service.AdminExist())
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            set
            {
                _alreadyAdmin = value;
                OnPropertyChanged("alreadyAdmin");
            }
        }
        #endregion
    }
}
