using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw4.Models
{
    public class StudentList
    {
        List<Student> lista = new List<Student>();

        public void add(Student student)
        {
            lista.add(student);
        }

        public List<Student> getlist()
        {
            return lista;
        }
    }
}
