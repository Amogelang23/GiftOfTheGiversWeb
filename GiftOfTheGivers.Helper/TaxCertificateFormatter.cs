using System;

namespace GiftOfTheGivers.Helper
{
    public static class TaxCertificateFormatter
    {
        public static string GenerateFormattedNumber()
        {
            string datePart = DateTime.UtcNow.ToString("yyyyMMdd");
            string uniqueId = Guid.NewGuid().ToString().Substring(0, 5).ToUpper();
            return $"GOTG-TAX-{datePart}-{uniqueId}";
        }
    }
}