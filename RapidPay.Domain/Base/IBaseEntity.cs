using System;

namespace RapidPay.Domain
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
