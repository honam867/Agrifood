using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Domain
{
    public interface IVersionedEntity : IEntity
    {
        byte[] RowVersion { set; get; }
    }
    public interface IVersionedEntity<TKeyType> : IVersionedEntity, IEntity<TKeyType>
    {

    }
}
