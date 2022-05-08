﻿namespace EmployeesApp.Validation
{
    public class AccountNumberValidation
    {
        private const int startingPartLength = 3;
        private const int middlePartLength = 10;
        private const int lastPartLength = 2;
        public bool IsValid(string accountNumber)
        {
            try
            {
                var firstDelimiter = accountNumber.IndexOf('-');
                var secondDelimiter = accountNumber.LastIndexOf('-');

                if (firstDelimiter == -1 || secondDelimiter == firstDelimiter)
                    throw new ArgumentException();

                //var firstPart = accountNumber.Substring(0, firstDelimiter);
                var firstPart = accountNumber[..firstDelimiter];

                if (firstPart.Length != startingPartLength)
                    return false;

                var tempPart = accountNumber.Remove(0, startingPartLength + 1);
                var middlePart = tempPart.Substring(0, tempPart.IndexOf('-'));

                if (middlePart.Length != middlePartLength)
                    return false;

                var lastPart = accountNumber.Substring(secondDelimiter + 1);

                if (lastPart.Length != lastPartLength)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
