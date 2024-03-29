﻿using TestCoreApi.CreateModel;
using TestCoreApi.Dtos;
using TestCoreApi.Models;
using TestCoreApi.UpdateModel;

namespace TestCoreApi.Mapper
{  
    public class StandardMapper
    {  
        public static Standard Map(StandardCreate standardCreate)
        {
            return new()
            {
                StandardNumber = standardCreate.StandardNumber,
                Section = standardCreate.Section,
            };

        }
        public static StandardDto MapToDto(Standard standard)
        {
            return new()
            {
                Id = standard.Id,
                StandardNumber = standard.StandardNumber,
                Section = standard.Section,
            };

        }
        public static void MapToEntity(StandardUpdate standardUpdate,Standard standard)
        {
            standard.Section = standardUpdate.Section;
            standard.StandardNumber = standardUpdate.StandardNumber;
        }
    }
}
