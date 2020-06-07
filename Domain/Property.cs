using System;
using System.Collections.Generic;

namespace Domain
{
    public class Property : IEntity<Guid>, IFullAuditedEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PropertyTypeId { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public bool IsSelling {get;set;}
        public decimal? SalePrice{get;set;}
        public bool IsRenting {get;set;}
        public decimal? RentPrice{get;set;}
        public decimal LotSize{get;set;}
        public decimal ConstructionSize{get;set;}
        public virtual ICollection<PropertyImage> PropertyImages {get;set;}


        // IFullAuditedEntity
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}