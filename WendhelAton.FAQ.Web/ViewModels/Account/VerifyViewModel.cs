﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WendhelAton.FAQ.Web.ViewModels.Account
{
    public class VerifyViewModel
    {
        public string EmailAddress { get; set; }

        public string RegistrationCode { get; set; }
    }
}