﻿using Models;
using NetworkSocket;
using NetworkSocket.Fast;
using NetworkSocket.Fast.Attributes;
using Server.Attributes;
using Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    /// <summary>
    /// 系统
    /// </summary>
    public class SystemService : FastServiceBase
    {
        public IUserDao UserDao { get; set; }

        /// <summary>
        /// 登录操作
        /// </summary>       
        /// <param name="user">用户数据</param>
        /// <param name="ifAdmin"></param>
        /// <returns></returns>    
        [Service(Implements.Self, 100)]
        public bool Login(User user, bool ifAdmin)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            Console.WriteLine("用户{0}登录操作...", user.Account);
            var state = this.UserDao.IsExist(user);

            // 记录客户端的登录结果
            this.CurrentContext.Client.TagBag.Logined = state;
            return state;
        }

        public override void OnAuthorization(ActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
        }

        public override void OnExecuting(ActionContext actionContext)
        {
            base.OnExecuting(actionContext);
        }

        public override void OnExecuted(ActionContext actionContext)
        {
            base.OnExecuted(actionContext);
        }
    }
}