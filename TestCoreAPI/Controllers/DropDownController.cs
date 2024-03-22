using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using TestCoreApi.CreateModel;
using TestCoreApi.Data;
using TestCoreApi.Dtos;
using TestCoreApi.Mapper;
using TestCoreApi.Models;
using TestCoreApi.UpdateModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownController : ControllerBase
    {
        private readonly StudentsAPIDbContext dbContext;
        public DropDownController(StudentsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        [Route("Standard")]
        public List<string> GetAllStandard()
        {
            List<string> standardList = new List<string>();

            var standards = dbContext.Standards.ToList();
            foreach (var standard in standards)
            {
                standardList.Add(standard.StandardNumber + "-" + standard.Section); 
            }
            return standardList;
        }


        [HttpGet]
        [Route("Subject")]
        public List<string> GetAllSubject()
        {
            HashSet<string> subjectList = new HashSet<string>();
            var subjects = dbContext.Subjects.ToList();
            foreach (var subject in subjects)
            {
                subjectList.Add(subject.Name);
            }

            return subjectList.ToList();

        }

    }
}
