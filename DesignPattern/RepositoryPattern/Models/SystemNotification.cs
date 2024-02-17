using Common.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public class SystemNotification:Notification
    {
        [BsonIgnore]
        public long NotificationId { get; set; }

        [NotMapped]
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonElement("NotificationId")] // You can change "NotificationId" to your desired field name
        public ObjectId Id { get; set; }
    }
}
