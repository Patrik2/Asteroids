using System.Web;

namespace Asteroids.Models
{
    public interface IAsteroid
    {
        int ID { get; set; }
        string Name { get; set; }
        double Profit { get; set; }
        double Value { get; set; }
        string FileName { get; set; }
        byte[] FileData { get; set; }
        string FileDateBase64 { get; }
        HttpPostedFileBase File { get; set;}
    }
}