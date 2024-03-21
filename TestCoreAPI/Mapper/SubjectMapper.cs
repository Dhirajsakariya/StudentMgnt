using Microsoft.AspNetCore.Mvc;

using TestCoreApi.CreateModel;
using TestCoreApi.Dtos;
using TestCoreApi.Models;

namespace TestCoreApi.Mapper
{
    public class SubjectMapper
    {
        public static Subject Map(SubjectCreate subjectCreate)
        {
            return new()
            {
                Name = subjectCreate.Name,
                StandardId = subjectCreate.StandardId,
            };

        }
        public static SubjectDto MapToDto(Subject subject)
        {
            return new()
            {
                Id = subject.Id,
                Name = subject.Name,
                StandardId = subject.StandardId,
            };
        }
        public static Subject MapToEntity(SubjectDto subjectDto)
        {
            return new()
            {
                //Id = subjectDto.Id,
                Name = subjectDto.Name,
                StandardId = subjectDto.StandardId,
            };
        }





    }
}
