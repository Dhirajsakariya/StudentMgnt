using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.UpdateModel
{
    [NotMapped]
    public class FeesUpdate
    {
        public long Amount { get; set; }

    }
}
