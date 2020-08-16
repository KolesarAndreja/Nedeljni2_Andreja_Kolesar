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
    class RegisterPatientViewModel:ViewModelBase
    {
        #region Prop
        RegisterPatient register;
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

        private tblClinicPatient _newPatient;
        public tblClinicPatient newPatient
        {
            get
            {
                return _newPatient;
            }
            set
            {
                _newPatient = value;
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
        public RegisterPatientViewModel(RegisterPatient open)
        {
            register = open;
            newUser = new tblUser();
            newPatient = new tblClinicPatient();
        }

        public RegisterPatientViewModel(RegisterPatient open, tblClinicPatient p, tblUser user)
        {
            register = open;
            newUser = user;
            newPatient = p;
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
                string message = null;
                currentPassword = (obj as PasswordBox).Password;
                if (Model.Person.ValidPassword(currentPassword))
                {
                    newUser.password = currentPassword;
                    tblUser u = Service.Service.AddUser(newUser);
                    newPatient.userId = u.userId;
                    tblClinicPatient p = Service.Service.AddPatient(newPatient);
                    if (u != null && p != null)
                    {
                        if (isEditingWindow)
                        {
                            message = "Patient with id: " + p.patientId + " has been upadated.";
                        }
                        else
                        {
                            message = "Patient with id: " + p.patientId + " has been registered.";
                        }
                        isUpdated = true;
                        MessageBox.Show(message);
                        register.Close();

                    }
                }
                else
                {
                    message = "Patient registration failed due to weak password";
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
                if (!String.IsNullOrEmpty(newUser.citizenship) && !String.IsNullOrEmpty(newUser.fullname) && !String.IsNullOrEmpty(newUser.citizenship) && !String.IsNullOrEmpty(newUser.gender) && newUser.dateOfBirth != null && !String.IsNullOrEmpty(newUser.ICnumber) && !String.IsNullOrEmpty(newPatient.cardNumber))
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
            return true;
    
        }
        #endregion
    }
}
