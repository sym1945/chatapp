﻿using chatapp.core;

namespace chatapp
{
    public class ViewModelLocator
    {
        #region Public Properties

        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        public static ApplicationViewModel ApplicationViewModel => IoC.Application;

        public static SettingsViewModel SettingsViewModel => IoC.Settings;

        #endregion
    }
}
