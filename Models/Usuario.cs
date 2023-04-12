using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        public String Sobrenome { get; set; }

        public String Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public int Escolaridade { get; set; }
    }
}
