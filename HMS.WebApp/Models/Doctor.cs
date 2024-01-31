using System.Security.Cryptography.X509Certificates;

namespace HMS.WebApp.Models
{
    public class Doctor
    {
       public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Specialist { get; set; } = string.Empty;
    }
}
