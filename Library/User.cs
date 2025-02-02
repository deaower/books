using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class User
    {
        public string Username { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanView { get; set; }

        public User(string username, bool canEdit, bool canDelete, bool canView)
        {
            Username = username;
            CanEdit = canEdit;
            CanDelete = canDelete;
            CanView = canView;
        }
    }
}
