using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Domain
{
    public interface IEntity
    {

    }

    public interface IEntity<TType> : IEntity
    {
        /// <summary>
        ///  Identity key for the entities
        /// </summary>
        TType Id { set; get; }
    }
}
