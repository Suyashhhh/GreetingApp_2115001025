﻿using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IGreetingBL
    {
        string GetGreet();

        string greeting(UserModel userModel);
        bool GreetMessage(GreetingModel greetModel);

        public GreetingModel GetGreetingById(int id);

        public List<GreetingModel> GetAllGreetings();

        public GreetingModel EditGreeting(int id, GreetingModel greetingModel);

        public bool DeleteGreeting(int id);
    }
}