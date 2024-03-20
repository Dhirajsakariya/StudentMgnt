﻿using TestCoreApi.CreateModel;
using TestCoreApi.Dtos;
using TestCoreApi.Models;

namespace TestCoreApi.Mapper
{
    public class TimeTableMapper
    {
        public static TimeTable Map(TimeTableCreate timeTableCreate)
        {
            return new()
            {
                NoOfDay =  timeTableCreate.NoOfDay,
                StartTime = timeTableCreate.StartTime,
                EndTime = timeTableCreate.EndTime,
                SubjectId = timeTableCreate.SubjectId,
                StandardId = timeTableCreate.StandardId
            };
        }  
        public static TimeTableDto MapToDto(TimeTable timeTable)
        {
            return new()
            {
                Id = timeTable.Id,
                NoOfDay = timeTable.NoOfDay,
                StartTime = timeTable.StartTime,
                EndTime = timeTable.EndTime,
                SubjectId = timeTable.SubjectId,
                StandardId = timeTable.StandardId
            };

        }
    }
}