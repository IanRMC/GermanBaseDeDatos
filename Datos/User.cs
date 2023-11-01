using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class User
    {

        public int Id { get; set; }
        public string user {  get; set; }
        public string password { get; set; }
        public string numTarjeta {  get; set; }
        public string CVV {  get; set; }
        public string fechaVe {  get; set; }
        public string NomTitular { get; set; }

        public User(int id, string user, string Password) 
        {
            Id = id;
            this.user = user;
            password = Password;
        }

        public User(string NumTarjeta, string cvv, string FechaVe, string titular)
        {
            numTarjeta = NumTarjeta;
            CVV = cvv;
            fechaVe = FechaVe;
            NomTitular = titular;
        }

    }
}
