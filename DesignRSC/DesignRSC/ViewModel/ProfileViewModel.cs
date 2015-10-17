using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignRSC.ViewModel
{
    public class ProfileViewModel :ViewModelBase
    {
        private string _name;
        private string _surname;
        private string _nameSurname;
        private string _profilePicture;
        public string Name
        {
            get
            {
                return "Dragutin";
                //return _name;
            }
            set
            {
                Set(ref _name, value);
            }
        }


        public string Surname
        {
            get
            {
                return "Dumic";
                //return _surname;
            }
            set
            {
                Set(ref _surname, value);
            }
        }

        public string NameSurname
        {
            get
            {
                return "Dragutin Dumic";
                //return _nameSurname;
            }
            set
            {
                Set(ref _nameSurname, value);
            }
        }

        public string ProfilePicture
        {
            get
            {
                //user = helper.SelectUser();
                /* if (user.Image == null)
                 {
                     _profilePicture = "ms-appx:///Assets/Icons/User-Login.png";
                     return _profilePicture;
                 }
                else if(user.Image.UriSource.ToString() == "")
                 {
                     _profilePicture = "ms-appx:///Assets/Icons/User-Login.png";
                     return _profilePicture;
                 }
                 else
                 {
                     _profilePicture = user.Image.UriSource.ToString();
                     return _profilePicture;
                 }*/
                _profilePicture = "ms-appx:///Assets/Icons/roko_64_64.png";
                return _profilePicture;
            }
        }

            public ProfileViewModel()
        {

        }
    }
}
