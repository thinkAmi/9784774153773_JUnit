using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch20.ex04
{
    public interface IAccountDao
    {
        /**
         * userIdを指定し、アカウント情報を取得する
         * @param userId システムで一意であるユーザーID
         * @return 指定されたユーザーIDのアカウント情報、存在しない場合はnull
         */
        Account FindOrNull(string userId);
    }

    public class Account
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public Account()
        {
        }

        public Account(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }
    }
}
