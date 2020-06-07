using System;

namespace Domain
{
    public class PropertyImage : IEntity<Guid>, IFullAuditedEntity

    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public Guid PropertyId { get; set; }
        public virtual Property Property { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}