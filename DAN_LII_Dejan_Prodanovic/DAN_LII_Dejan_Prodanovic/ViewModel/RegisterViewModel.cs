using DAN_LII_Dejan_Prodanovic.Command;
using DAN_LII_Dejan_Prodanovic.Model;
using DAN_LII_Dejan_Prodanovic.Service;
using DAN_LII_Dejan_Prodanovic.Utility;
using DAN_LII_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_LII_Dejan_Prodanovic.ViewModel
{
    class RegisterViewModel:ViewModelBase
    {
        RegisterView view;
        IService service;

        public RegisterViewModel(RegisterView registerView)
        {
            view = registerView;
            service = new ServiceClass();

            User = new tblUser();
        }

        private tblUser user;
        public tblUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(SaveExecute, CanSaveExecute);
                }
                return save;
            }
        }

        private void SaveExecute(object parameter)
        {
            try
            {
               
                tblUser userInDb = service.GetUserByUserName(User.Username);

                if (userInDb != null)
                {
                    string str1 = string.Format("User with this username exists\n" +
                        "Enter another username");
                    MessageBox.Show(str1);
                    return;
                }

                if (IsTelephoneNumberValid(User.TelephoneNumber))
                {
                    MessageBox.Show("Telephone number is not valid");
                }
              
                var passwordBox = parameter as PasswordBox;
                var password = passwordBox.Password;

                string encryptedString = EncryptionHelper.Encrypt(password);
                User.UserPassword = encryptedString;

                service.AddUser(User);
                MessageBox.Show("You successfully registered.");
                LoginView loginView = new LoginView();
                view.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object parameter)
        {

            if (String.IsNullOrEmpty(User.Fullname) || String.IsNullOrEmpty(User.TelephoneNumber)
                || String.IsNullOrEmpty(User.UserAddress) || String.IsNullOrEmpty(User.Username)     
                || parameter as PasswordBox == null
              | String.IsNullOrEmpty((parameter as PasswordBox).Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                LoginView loginView = new LoginView();
                loginView.Show();
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCloseExecute()
        {
            return true;
        }



        private bool IsTelephoneNumberValid(string telephoneNumber)
        {
            if (telephoneNumber.Length!=8)
            {
                return false;
            }
            long helpVar;

            return  long.TryParse(telephoneNumber,out helpVar);
        }

       

        

        
    }
}
