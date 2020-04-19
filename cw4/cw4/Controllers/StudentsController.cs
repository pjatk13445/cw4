using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using cw4.DAL;
using cw4.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw4.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        [HttpGet("{IndexNumber}")]
        public IActionResult GetStudents(string indexNumber)
        {
            StudentList studentList = new StudentList();
            using (SqlConnection client = new SqlConnection("Data Source=db-mssql;Initial Catalog=s13445;Integrated Security=True"))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = client;
                command.CommandText = "USE [2019SBD]; SELECT * FROM STUDENT WHERE IndexNumber = @index";
                command.Parameters.AddWithValue("index", indexNumber);
                client.Open();
                var queryResult = command.ExecuteReader();
                while (queryResult.Read())
                    var nStudent = new Student();
                    nStudent.FirstName = (queryResult["FirstName"].ToString());
                    nStudent.LastName = (queryResult["LastName"].ToString());
                    nStudent.IndexNumber = (queryResult["IndexNumber"].ToString());
                    nStudent.BirthDate = ((DateTime) queryResult["BirthDate"]);
                    nStudent.IdEnrollment = (queryResult["IdEnrollment"].ToString());
                    studentList.add(st);
                }
                
            }

            return Ok(studentList.getlist());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Usuwanie ukończone");
            }
            else if (id == 2)
            {
                return Ok("Usuwanie ukończone");
            }
            return NotFound("Nie ma takiego studenta");
        }

        [HttpPost]
        public IActionResult CreateStudnet(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 100000)}";
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent()
        {
            return Ok("Usuwanie zakonczone");
        }

    }
}