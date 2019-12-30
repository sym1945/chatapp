﻿using chatapp.core;
using System.Security;

namespace chatapp
{
    /// <summary>
    /// RegisterPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RegisterPage : BasePage<LoginViewModel>, IHavePassword
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
