using MongoDB.Bson.Serialization.Attributes;
using System.Security.Cryptography;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
namespace CastingWebAPI.Models
{
    public class Project
    {
        [BsonId]
        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location {  get; set; }
     
        public Guid recruiterId { get; init; }

        /*
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Project ID: {Id}");
            sb.AppendLine($"Project Name: {Name}");
            sb.AppendLine($"Location: {Location}");
            sb.AppendLine($"Description: {Description}");

            string printContent = sb.ToString();
            return printContent;
        }*/
    }
}
