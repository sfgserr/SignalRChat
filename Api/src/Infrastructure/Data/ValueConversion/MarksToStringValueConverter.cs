using Domain.Sessions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.ValueConversion
{
    public class MarksToStringValueConverter : ValueConverter<IReadOnlyCollection<Mark>, string>
    {
        public MarksToStringValueConverter(ConverterMappingHints hints = null) :
            base(a => string.Join("", a.Select(m => m.Value)), s => s.Select(c => Mark.Parse(c)).ToList(), hints)
        {

        }
    }
}
