using DAN_LII_Dejan_Prodanovic.Command;
using DAN_LII_Dejan_Prodanovic.InputDialog;
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
    class LoginViewModel:ViewModelBase
    {
        LoginView view;
        IService service;
       

        public LoginViewModel(LoginView loginView)
        {
            view = loginView;
            service = new ServiceClass();
            

        
        }

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string someProperty]
        {
            get
            {

                return string.Empty;
            }
        }



        private ICommand submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (submitCommand == null)
                {
                    submitCommand = new RelayCommand(Submit);
                    return submitCommand;
                }
                return submitCommand;
            }
        }

        void Submit(object obj)
        {

            string password = (obj as PasswordBox).Password;

            string encryptedString = EncryptionHelper.Encrypt(password);

            tblUser user = service.GetUserByUserNameAndPassword(UserName, encryptedString);
            if (user != null)
            {


               

                
                    InputDialogSample inputDialog = new InputDialogSample("Enter children or adults to choose cake list:" +
                        "", "");
                    if (inputDialog.ShowDialog() == true)
                    {
                        if (inputDialog.Answer.ToLower().Equals("children"))
                        {
                            UserMainView mainView = new UserMainView("children");
                            mainView.Show();
                            view.Close();
                            return;
                        }
                        else if (inputDialog.Answer.ToLower().Equals("adults"))
                        {


                            UserMainView mainView = new UserMainView("adults");
                            mainView.Show();
                            view.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Wrong input");
                        }

                    }
           
              
                
               
            }

            else
            {
                MessageBox.Show("Wrong username or password");

            }


        }

        private ICommand register;
        public ICommand Register
        {
            get
            {
                if (register == null)
                {
                    register = new RelayCommand(param => RegisterExecute(), param => CanRegisterExecute());
                }
                return register;
            }
        }

        private void RegisterExecute()
        {
            try
            {
                RegisterView register = new RegisterView();
                register.Show();
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanRegisterExecute()
        {

            return true;
        }

       
    }
}
