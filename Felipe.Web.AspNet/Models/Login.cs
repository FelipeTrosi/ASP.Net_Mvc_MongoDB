using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Felipe.Web.AspNet.Models
{
    public class Login
    {
        [BsonElement("user"), Required(ErrorMessage = "Informe um usuario !")]
        public string User { get; set; }
        [BsonElement("password"), Required(ErrorMessage = "Informe a senha !")]
        public string Password { get; set; }
    }
}