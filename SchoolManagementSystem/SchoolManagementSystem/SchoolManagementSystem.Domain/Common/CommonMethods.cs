﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace SchoolManagementSystem.Domain.Common
{
	public static class CommonMethods
	{
        public static string WebAPIUrl=> WebConfigurationManager.AppSettings["WebAPIUrl"].ToString();

		public static string GetIPAddress()
		{
			return Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
		}
	}
}
