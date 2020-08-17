using System;
using KLabs.Entities.EntityBases.Concrete;

namespace KLabs.Entities.Concrete
{
    public class LoginLog : Entity
    {
        public string LoggedIp { get; set; }

        public bool Success { get; set; }

    }
}