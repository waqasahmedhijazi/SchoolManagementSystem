using SchoolManagementSystem.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Common
{
	public class SMSEncryption
	{
		public static string Encrypt(string toEncrypt)
		{
			return EncryptionHelper.Encrypt(toEncrypt, EncryptionModes.ConstantSaltNoneUserSessionNone);
		}

		public static string Decrypt(string toDecrypt)
		{

			return EncryptionHelper.Decrypt(toDecrypt);

		}
	}
}
