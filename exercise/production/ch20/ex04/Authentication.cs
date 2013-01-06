using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch20.ex04
{
    public class Authentication
    {
        private IAccountDao dao;

        public Authentication(IAccountDao dao)
        {
            this.dao = dao;
        }

        public Account Authenticate(string userId, string password)
        {
            if (dao == null)
            {
                throw new System.Exception();
            }

            Account account = dao.FindOrNull(userId);

            if (account == null)
            {
                return null;
            }

            return (account.Password == password) ? account : null;
        }
    }
}
