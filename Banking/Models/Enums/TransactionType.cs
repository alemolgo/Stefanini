using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banking.Models.Enums
{
    public enum TransactionType
    {
        None = 0,
        RetiroA = 1,
        RetiroB = 2,
        RetiroC = 3,
        TransferFromAToB = 4,
        TransferFromAToC = 5,
        TransferFromBToC = 6,
        TransferFromBToA = 7,
        TransferFromCToA = 8,
        TransferFromCToB = 9
    }
}