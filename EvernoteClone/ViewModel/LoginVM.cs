using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using EvernoteClone.ViewModel.Helpers;

namespace EvernoteClone.ViewModel
{
    public class LoginVM
    {
        public RegisterCommand RegisterCommand { get; set; }
		public LoginCommand LoginCommand { get; set; }

        private User user;

		public User User
		{
			get { return user; }
			set { user = value; }
		}

		public LoginVM() 
		{
			RegisterCommand = new RegisterCommand(this);
			LoginCommand = new LoginCommand(this);	
		}

	}
}
