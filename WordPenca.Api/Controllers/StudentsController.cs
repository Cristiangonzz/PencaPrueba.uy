//using AngularApp1.Server.infraestructure.db;
//using AngularApp1.Server.Infraestructure.Dto;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Numerics;

//namespace AngularApp1.Server.Infraestructure.Controllers
//{
//    //http://localhost:port/api/Students
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentsController : ControllerBase
//    {
//        public readonly ApplicationDbContext dbContext;

//        public StudentsController(ApplicationDbContext dbContext) 
//        {
//            this.dbContext = dbContext;
//        }

//        //[HttpGet]
//        //public IActionResult GetallStudents()
//        //{
//        //    var studentsDomainModels = dbContext.Students.ToList();

//        //    var studentDto = new List<StudentsDto>();

//        //    //Map/Convert Domain -> DTOs
//        //    foreach (var studentDomain in studentsDomainModels)
//        //    {
//        //        studentDto.Add(new StudentsDto(){
//        //            Id = studentDomain.Id,
//        //            Name = studentDomain.Name,
//        //            Email = studentDomain.Email,
//        //            Phone = studentDomain.Phone,
//        //            Subscribed = studentDomain.Subscribed
//        //        });

                
//        //    }
//        //    return Ok(studentDto);

//        //}

//        //[HttpGet]
//        //[Route("{id:Guid}")]
//        //public IActionResult GetStudent([FromRoute] Guid id)
//        //{
//        //    var studentDomain = dbContext.Students.Find(id);
//        //    /*
//        //     EL id es por defecto que lo busca, 
//        //    si se quiere buscar por algun otro argumento se tiene que usar
//        //    var students = dbContext.Students.FirstOrDefault(x => x.codigo == id)
//        //     */
//        //    if (studentDomain == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    //Map/Convert Domain -> DTOs
//        //    var studentDto = new StudentsDto();
//        //    studentDto.Id = studentDomain.Id;
//        //    studentDto.Name = studentDomain.Name;
//        //    studentDto.Email = studentDomain.Email;
//        //    studentDto.Phone = studentDomain.Phone;
//        //    studentDto.Subscribed = studentDomain.Subscribed;

//        //    return Ok(studentDto);
//        //}
//    }
//}
