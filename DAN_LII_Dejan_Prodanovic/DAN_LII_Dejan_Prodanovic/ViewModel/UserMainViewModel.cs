using DAN_LII_Dejan_Prodanovic.Model;
using DAN_LII_Dejan_Prodanovic.Service;
using DAN_LII_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LII_Dejan_Prodanovic.ViewModel
{
    class UserMainViewModel:ViewModelBase
    {
        UserMainView view;
        IService service;

        public UserMainViewModel(UserMainView userMainView)
        {
            view = userMainView;
            service = new ServiceClass();

            User = new tblUser();
        }

        public UserMainViewModel(UserMainView userMainView,string cakeType)
        {
            view = userMainView;
            service = new ServiceClass();
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

        private void CountSellPrices(List<tblCake>cakes)
        {
            foreach (var cake in cakes)
            {
                cake.SellPrice = (decimal)cake.PurchasePrice * (decimal)1.2;
            }
        }
    }
}
