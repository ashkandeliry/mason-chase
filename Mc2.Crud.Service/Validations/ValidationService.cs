using Mc2.Crud.Models.Generics;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.Crud.Service.Validations
{
    public static class ValidationService
    {
        public static bool validateEmail(string Email)
        {
            var trimmedEmail = Email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                if (addr.Address == trimmedEmail)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Phone">03336323900</param>
        /// <param name="CuntryCode">PK</param>
        /// Produces "+923336323997"
        /// <returns></returns>
        public static GenericOutputResult<string> CheckPhoneNo(string Phone, string CuntryCode)
        {
            try
            {
                PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
                PhoneNumbers.PhoneNumber phoneNumber = phoneUtil.Parse(Phone, CuntryCode);

                bool isMobile = false;
                bool isValidNumber = phoneUtil.IsValidNumber(phoneNumber); // returns true for valid number    

                // returns trueor false w.r.t phone number region  
                bool isValidRegion = phoneUtil.IsValidNumberForRegion(phoneNumber, CuntryCode);

                string region = phoneUtil.GetRegionCodeForNumber(phoneNumber); // GB, US , PK    

                var numberType = phoneUtil.GetNumberType(phoneNumber); // Produces Mobile , FIXED_LINE    

                string phoneNumberType = numberType.ToString();

                if (!string.IsNullOrEmpty(phoneNumberType) && phoneNumberType == "MOBILE")
                    isMobile = true;

                return new GenericOutputResult<string> { Status = true, DataResult = phoneUtil.Format(phoneNumber, PhoneNumberFormat.E164) };

            }
            catch (Exception ex)
            {
                return new GenericOutputResult<string> { Status = false };
            }
        }

    }



}
