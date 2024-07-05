using Domain.SeedWork;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.ValueConversion
{
    public class TypedIdValueConverter<TTypedIdValueBase> : 
        ValueConverter<TTypedIdValueBase, Guid> where TTypedIdValueBase : TypedIdValueBase
    {
        public TypedIdValueConverter(ConverterMappingHints hints = null) : 
            base(id => id.Id, value => Create(value), hints)
        {

        }

        private static TTypedIdValueBase Create(Guid id) => 
            Activator.CreateInstance(typeof(TTypedIdValueBase), id) as TTypedIdValueBase;
    }
}
