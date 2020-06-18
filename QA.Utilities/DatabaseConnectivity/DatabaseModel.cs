using System;
using System.Collections.Generic;
using System.Text;

namespace QA.Utilities.DatabaseConnectivity
{
    public class DatabaseModel
    {
        private string _dataSource, _authentication, _initialCatalog, _userId, _password;

        public string DataSource
        {
            get => _dataSource;
            set
            {
                _dataSource = value;
            }
        }
        public string Authentication
        {
            get => _authentication;
            
            set
            {
                _authentication = value;
            }
        }
        public string InitialCatalog
        {
            get
            {
                return _initialCatalog;
            }
            set
            {
                _initialCatalog = value;
            }
        }
        public string UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
    }
}
