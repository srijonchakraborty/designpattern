////using Common;
////using Common.Model;
////using MongoDB.Bson;
////using MongoDB.Bson.Serialization.Attributes;
////using MongoDB.Bson.Serialization.IdGenerators;
////using System.ComponentModel.DataAnnotations;
////using System.ComponentModel.DataAnnotations.Schema;


////namespace Repository.Models
////{
////    [Table("SystemNotification")]
////    public class SystemNotification:Notification
////    {
////        [BsonIgnore]
////        [Key]
////        [Column("NotificationId")]
////        public long NotificationId { get; set; }

////        [NotMapped]
////        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
////        [BsonElement("NotificationId")] // You can change "NotificationId" to your desired field name
////        public ObjectId Id { get; set; }

////        [Column("Emails")]
////        public string Emails { get; set; }

////        [Column("CCEmails")]
////        public string CCEmails { get; set; }

////        [Column("BCCEmails")]
////        public string BCCEmails { get; set; }

////        [Column("PhoneNumbers")]
////        public string PhoneNumbers { get; set; }

////        [Column("NotificationSubject")]
////        public string NotificationSubject { get; set; }

////        [Column("NotificationBody")]
////        public string NotificationBody { get; set; }

////        [Column("AttachmentPaths")]
////        public string AttachmentPaths { get; set; }

////        [Column("NType")]
////        public NotificationType NType { get; set; }
////    }
////}


//#if SQLSERVER
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//#elif MONGODB
//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
//#endif


//using System.ComponentModel.DataAnnotations.Schema;
//namespace Repository.Models
//{
//    public class SystemNotification
//    {
//#if SQLSERVER
//    [Key]
//    [Column("NotificationId")]
//    public int NotificationId { get; set; }
//#elif MONGODB
//    [BsonId]
//    [BsonRepresentation(BsonType.ObjectId)]
//    [BsonElement("NotificationId")]
//    public string Id { get; set; }
//#endif

//        public string Emails { get; set; }

//        [Column("CCEmails")]
//        public string CCEmails { get; set; }

//        [Column("BCCEmails")]
//        public string BCCEmails { get; set; }

//        public string PhoneNumbers { get; set; }

//        public string NotificationSubject { get; set; }

//        public string NotificationBody { get; set; }

//        public string AttachmentPaths { get; set; }

//#if SQLSERVER
//    [Column("NType")]
//    public int? NType { get; set; }
//#elif MONGODB
//    public NotificationType NType { get; set; }
//#endif
//    }
//}
