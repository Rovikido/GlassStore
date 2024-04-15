

namespace GlassStore.Server.Domain.Models
{
    public class DataList <T>
    {
        public IEnumerable<T> data { get; set; }
        //public int ListSize => Data?.Count() ?? 0;
        public int ?listSize { get; set; }
    }
}

