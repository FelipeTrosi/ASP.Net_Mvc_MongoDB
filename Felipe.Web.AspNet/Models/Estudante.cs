using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Web.AspNet.Models
{
    public class Estudante
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("nome")]
        public string Nome { get; set; }
        [BsonElement("curso")]
        public string Curso { get; set; }
        [BsonElement("user"), Required(ErrorMessage = "Informe um usuario !")]
        public string User { get; set; }
        [BsonElement("password"), Required(ErrorMessage = "Informe a senha !")]
        public string Password { get; set; }
        [BsonElement("rm")]
        public int Rm { get; set; }        
        [BsonElement("dataMatricula")]
        [DisplayName("Data da Matricula"),DataType(DataType.Date)]
        public DateTime DataMatricula { get; set; }
        [BsonElement("valorMensalidade")]
        [DisplayName("Valor da Mensalidade")]
        public double ValorMensalidade { get; set; }
    }
}
