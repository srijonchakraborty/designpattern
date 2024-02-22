//check in this projects csproj file<DefineConstants>SQLSERVER</DefineConstants>
#if SQLSERVER
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#elif MONGODB
using Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endif

namespace DesignPattern.DBContext.Models.Models;

[Table("SystemNotification")]
public partial class SystemNotification
{

    [Key]
    [Column("NotificationId")]
    public int NotificationId { get; set; }

    [BsonId]
    [NotMapped]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public ObjectId Id { get; set; }

    public string Emails { get; set; }

    [Column("CCEmails")]
    public string Ccemails { get; set; }

    [Column("BCCEmails")]
    public string Bccemails { get; set; }

    public string PhoneNumbers { get; set; }

    public string NotificationSubject { get; set; }

    public string NotificationBody { get; set; }

    public string AttachmentPaths { get; set; }

#if SQLSERVER
    [Column("NType")]
    public int? NType { get; set; }
#elif MONGODB
        public NotificationType NType { get; set; }
#endif
    public string ExtraInfo { get; set; }
    
}

