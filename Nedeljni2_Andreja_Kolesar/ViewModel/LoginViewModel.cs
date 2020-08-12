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
                person.password = (obj as PasswordBox).Password;
                tblUser user = Service.Service.GetUser(person.username, person.password);
                if (user == null)
                {
                    if (person.isMaster())
                    {
                        Master master = new Master();
                        login.Close();
                        master.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.Try again");
                    }
                }
                else
                {
                    if (Service.Service.isPatient(user) != null)
                    {
                        tblClinicPatient patient = Service.Service.isPatient(user);
                        Patient p = new Patient();
                        login.Close();
                        p.Show();
                    }
                    else if (Service.Service.isDoctor(user) != null)
                    {
                        tblClinicDoctor doctor = Service.Service.isDoctor(user);
                        Doctor d = new Doctor();
                        login.Close();
                        d.Show();
                    }
                    else if (Service.Service.isManager(user) != null)
                    {
                        tblClinicManager manager = Service.Service.isManager(user);
                        Manager m = new Manager();
                        login.Close();
                        m.Show();
                    }
                    else
                    {
                        tblClinicAdministrator admin = Service.Service.isAdministrator(user);
                        Administrator a = new Administrator();
                        login.Close();
                        a.Show();
                    }
                }
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
