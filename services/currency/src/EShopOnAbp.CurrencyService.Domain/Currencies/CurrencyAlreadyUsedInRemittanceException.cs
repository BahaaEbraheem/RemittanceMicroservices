﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace EShopOnAbp.CurrencyService.Currencies
{
   public class CurrencyAlreadyUsedInRemittanceException : BusinessException
    {
        public CurrencyAlreadyUsedInRemittanceException(string remittanceSerial)
            : base(CurrencyServiceErrorCodes.CurrencyAlreadyUsedInRemittance)
        {
            WithData("remittanceSerial", remittanceSerial);
        }
    }

}
