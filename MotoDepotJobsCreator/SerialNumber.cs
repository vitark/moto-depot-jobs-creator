using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MotoDepotJobsCreator
{
    internal class SerialNumber
    {
        public string? serialNumber { get; }

        public SerialNumber(string? serialNumber)
        {
            this.serialNumber = serialNumber == null 
                ? serialNumber 
                : serialNumber.ToUpper();
        }

        public bool validate()
        {
            if (serialNumber == null || serialNumber == "")
            {
                return false;
            }

            if (serialNumber.Length != 10)
            {
                return false;
            }

            return Regex.IsMatch(serialNumber, @"\A\d{3}[a-zA-Z]{3,4}\d{3,4}\Z", RegexOptions.IgnoreCase);
        }
    }
}
