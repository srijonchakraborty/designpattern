using Common.Contracts.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Order
{

    public interface IApproval<TModelStatus, TStatus>
    {
        TModelStatus Status { get; set; }
        TStatus StatusApproval { get; set; }
    }

    public interface IOrder : IApproval<OrderStatus,ApprovalStatus>
    {
        string Id { get; set; }
        string OrderNo { get; set; }
        List<IOrderItem> OrderItems { get; set; }
        DateTime CreateDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string ClientEmail { get; set; }
    }
    public interface IOrderItemDocuments
    {
        List<IDocument> ItemDocuments { get; set; }
    }
    public interface IOrderItem : IOrderItemDocuments
    {
        string Id { get; set; }
        string OrderId { get; set; }
        string ItemId { get; set; }
        string ItemName { get; set; }
        double Quantity { get; set; }
        double Price { get; set; }
        double ReceivedQuantity { get; set; }
        double RejectedQuantity { get; set; }
        string Unit { get; set; }
        string SupplierName { get; set; }
        string SupplierEmail { get; set; }
    }
}
