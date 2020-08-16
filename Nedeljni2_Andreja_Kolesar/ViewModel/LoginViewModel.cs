using Nedeljni2_Andreja_Kolesar.Command;
using Nedeljni2_Andreja_Kolesar.Model;
using Nedeljni2_Andreja_Kolesar.Service;
using Nedeljni2_Andreja_Kolesar.View;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni2_Andreja_Kolesar.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        Login login;
        private Person _person;
        public Person person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                OnPropertyChanged("person");
            }
        }

        #region constructor
        public LoginViewModel(Login openLogin)
        {
            login = openLogin;
            person = new Person();
        }
        #endregion


        #region Commands
        private ICommand _loginBtn;
        public ICommand loginBtn
        {
            get
            {
                if (_loginBtn == null)
                {
                    _loginBtn = new RelayCommand(LoginExecute, CanLoginExecute);
                }
                return _loginBtn;
            }
        }

        private void LoginExecute(object obj)
        {

            try
            {
                string content = null;
                person.password = (obj as PasswordBox).Password;
                tblUser user = Service.Service.GetUser(person.username, person.password);
                if (user == null)
                {
                    if (person.isMaster())
                    {
                        content = "Master has logged in";
                        Master master = new Master();
                        login.Close();
                        master.Show();

                    }
                    else
                    {
                        content = "Unsuccessful login with username " + person.username + " and password " + person.password;
                        MessageBox.Show("Invalid username or password.Try again");
                    }
                }
                else
                {
                    if (Service.Service.isPatient(user) != null)
                    {
                        content = "Patient with username " + person.username + " has logged in."; 
                        tblClinicPatient patient = Service.Service.isPatient(user);
                        Patient p = new Patient();
                        p.Show();
                    }
                    else if (Service.Service.isDoctor(user) != null)
                    {
                        content = "Doctor with username " + person.username + " has logged in.";
                        tblClinicDoctor doctor = Service.Service.isDoctor(user);
                        Doctor d = new Doctor();
                        d.Show();
                    }
                    else if (Service.Service.isManager(user) != null)
                    {
                        content = "Manager with username " + person.username + " has logged in.";
                        tblClinicManager manager = Service.Service.isManager(user);
                        Manager m = new Manager();
                        m.Show();
                    }
                    else
                    {
                        tblClinicAdministrator admin = Service.Service.isAdministrator(user);
                        Administrator a = new Administrator();
                        content = "Administrator has logged in.";
                        if (Service.Service.InstituteExist())
                        {
                            login.Close();
                            a.Show();
                        }
                        else
                        {
                            CreateClinic create = new CreateClinic(admin);
                            login.Close();
                            create.Show();
                        }
                    }
                }
                LogIntoFile.getInstance().PrintActionIntoFile(content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLoginExecute(object obj)
        {
            return true;
        }
        #endregion


        #region REGISTRATION

        private ICommand _registration;
        public ICommand registration
        {
            get
            {
                if (_registration == null)
                {
                    _registration = new RelayCommand(param => RegistrationExecute(), param => CanRegistrationExecute());
                }
                return _registration;
            }
        }

        private void RegistrationExecute()
        {
            try
            {
                RegisterPatient reg = new RegisterPatient();
                reg.ShowDialog();
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
    }
}
