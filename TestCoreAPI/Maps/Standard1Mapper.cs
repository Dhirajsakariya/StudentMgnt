//using TestCoreApi.CreateModel;
using TestCoreApi.Dtos;
using System.Net.Http.Headers;

using TestCoreApi.Models;
using TestCoreApi.create;
using static System.Collections.Specialized.BitVector32;

namespace TestCoreApi.Maps
{
    public class Standard1Mapper
    {
        public static Standard Maps(Standard1 standard1)
        {
            return new()
            {
                StandardNumber=standard1.StandardNumber,
                Section=standard1.Section

            };

        }

        public static StandarsDto MapToDto(Standard standard)
        {
            return new()
            {
                StandardNumber = standard.StandardNumber,
                Section = standard.Section
              
            };

        }
    }
}
