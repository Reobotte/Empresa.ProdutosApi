using Empresa.ProdutosApi.Domains.Entities.Interfaces;
using System;

namespace Empresa.ProdutosApi.Domains.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public Guid Id { get; }

        protected EntityBase() =>
            Id = Guid.NewGuid();

        protected EntityBase(Guid id) =>
            Id = id;

        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityBase;
            if (ReferenceEquals(this, compareTo))
                return true;
            if (ReferenceEquals(null, compareTo))
                return false;
            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(EntityBase a, EntityBase b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(EntityBase a, EntityBase b) =>
            !(a == b);

        public override int GetHashCode() =>
            GetType().GetHashCode() * 15 + Id.GetHashCode();

        public override string ToString() =>
            $"{GetType().Name} [Id = {Id}]";
    }
}
