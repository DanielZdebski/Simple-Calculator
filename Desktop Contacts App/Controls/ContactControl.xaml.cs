﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Desktop_Contacts_App.Classes;

namespace Desktop_Contacts_App.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {

        #region New Contact dependency property 
        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact() {Name ="Name LastName", Email="email@domain.com", Phone="(01234) 45678 902" }, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = (ContactControl)d;

            if (control != null)
            {
                control.nameTextBlock.Text = (e.NewValue as Contact).Name;
                control.emailTextBlock.Text = ((Contact)e.NewValue).Email;
                control.phoneTextBlock.Text = ((Contact)e.NewValue).Phone;
            }
        }
        #endregion

        //private Contact contact;

        //public Contact Contact
        //{
        //    get { return contact; }
        //    set
        //    {
        //        contact = value;

        //        nameTextBlock.Text = contact.Name;
        //        emailTextBlock.Text = contact.Email;
        //        phoneTextBlock.Text = contact.Phone;
        //    }
        //}

        public ContactControl()
        {
            
            InitializeComponent();
        }
    }
}
