using DAN_LII_Dejan_Prodanovic.Command;
using DAN_LII_Dejan_Prodanovic.Model;
using DAN_LII_Dejan_Prodanovic.Service;
using DAN_LII_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_LII_Dejan_Prodanovic.ViewModel
{
    class UserMainViewModel:ViewModelBase
    {
        UserMainView view;
        IService service;
        bool CanAdd = true;
        private decimal totalAmountNum = 0;
        private bool orderConfirmed = false;

        public UserMainViewModel(UserMainView userMainView)
        {
            view = userMainView;
            service = new ServiceClass();

            User = new tblUser();
        }

        public UserMainViewModel(UserMainView userMainView,string cakeType,
            tblUser userLogedIn)
        {
            view = userMainView;
            service = new ServiceClass();
            User = userLogedIn;
            if (cakeType.Equals("children"))
            {
                CakeList = service.GetChildrenCakes();

            }
            else
            {
                CakeList = service.GetAdultsCakes();
            }
            CountSellPrices(CakeList);
            User = new tblUser();
            OrderedCakes = new List<tblUserCake>();
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

        private tblCake selectedCake;
        public tblCake SelectedCake
        {
            get
            {
                return selectedCake;
            }
            set
            {
                selectedCake = value;
                OnPropertyChanged("SelectedCake");
            }
        }

        private int currentAmount = 0;
        public int CurrentAmount
        {
            get
            {
                return currentAmount;
            }
            set
            {
                currentAmount = value;
                OnPropertyChanged("CurrentAmount");

            }
        }
        private string totalAmount = "Total order amount: 0";
        public string TotalAmount
        {
            get
            {
                return totalAmount;
            }
            set
            {
                totalAmount = value;
                OnPropertyChanged("TotalAmount");
            }
        }

        private List<tblCake> cakeList;
        public List<tblCake> CakeList
        {
            get
            {
                return cakeList;
            }
            set
            {
                cakeList = value;
                OnPropertyChanged("CakeList");
            }
        }

        private List<tblUserCake> orderedCakes;
        public List<tblUserCake> OrderedCakes
        {
            get
            {
                return orderedCakes;
            }
            set
            {
                orderedCakes = value;
                OnPropertyChanged("OrderedCakes");
            }
        }

        private ICommand addToOrder;
        public ICommand AddToOrder
        {
            get
            {
                if (addToOrder == null)
                {
                    addToOrder = new RelayCommand(param => AddToOrderExecute(), param => CanAddToOrderExecute());
                }
                return addToOrder;
            }
        }

        private void AddToOrderExecute()
        {
            try
            {
                //tblUserCake thisCake = FindCakeByName(SelectedCake.CakeName);


                //if (thisCake != null && currentAmount == 0)
                //{
                //    CurrentAmount = (int)thisCake.Amount;
                //}
                //if (CurrentAmount <= 0 || CurrentAmount > 50)
                //{
                //    MessageBox.Show("You have to order between 1 and 10 cakes of one type");
                //    return;
                //}
                //tblUserCake newOrder = new tblUserCake();
                //newOrder.CakeID = SelectedCake.CakeID;
                //newOrder.UserID = User.UserID;
              

                //newOrder.Amount = CurrentAmount;
                



                //if (thisCake != null)
                //{ 
                //    totalAmountNum -= ((int)thisCake.Amount * (decimal)thisCake.tblCake.SellPrice);
                //    OrderedCakes.Remove(thisCake);
                //}


                //totalAmountNum += (CurrentAmount * (int)SelectedCake.SellPrice);
                
                //OrderedCakes.Add(newOrder);

                //TotalAmount = string.Format("Total order price {0}", totalAmountNum);
                //string outputStr = string.Format("Your order will contain {0} {1}",
                //    CurrentAmount, SelectedCake.CakeName);
                //CurrentAmount = 0;
                //MessageBox.Show(outputStr);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddToOrderExecute()
        {
            if (orderConfirmed || !CanAdd)
            {
                return false;
            }
            return true;
        }

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }

        private void LogoutExecute()
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
        private bool CanLogoutExecute()
        {
            return true;
        }

        private void CountSellPrices(List<tblCake>cakes)
        {
            foreach (var cake in cakes)
            {
                cake.SellPrice = (decimal)cake.PurchasePrice * (decimal)1.2;
            }
        }

        private tblUserCake FindCakeByName(string name)
        {
            foreach (var cake in orderedCakes)
            {
                if (cake.tblCake.CakeName.Equals(name))
                {
                    return cake;
                }
            }
            return null;
        }
    }
}
