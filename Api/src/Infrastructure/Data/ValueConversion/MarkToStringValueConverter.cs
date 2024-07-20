using Domain.Sessions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.ValueConversion
{
    public class MarkToStringValueConverter : ValueConverter<Mark?[], string>
    {
        public MarkToStringValueConverter(ConverterMappingHints hints = null) :
            base(a => string.Join("", a.Select(m => m == null ? '*' : m.Value)), 
                value => value.Select(m => Mark.Parse(m)).ToArray(), hints)
        {

        }
    }
}
