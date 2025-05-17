namespace SchoolManagementSystem.Application
{
    public class JwtSettings
    {
        public string Key { get; set; }              // المفتاح السري لتوقيع التوكن
        public string Issuer { get; set; }           // المُصدر (Issuer)
        public string Audience { get; set; }         // الجمهور (Audience)
        public int DurationInMinutes { get; set; }   // مدة صلاحية التوكن بالدقائق
    }
}
