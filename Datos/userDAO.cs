using Datos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion_BD_German
{
    public class userDAO
    {
        public User login(String usuario, String password)
        {
            User us = null;
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    String select = @"SELECT id
                        FROM Usuarios
                        WHERE Usuario=SHA2(@usuario, 256) AND Password=SHA2(@password, 256)";


                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@usuario", usuario);
                    sentencia.Parameters.AddWithValue("@password", password);

                    sentencia.Connection = Conexion.conexion;

                    MySqlDataAdapter da = new MySqlDataAdapter(sentencia);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow fila = dt.Rows[0];
                        us = new User(Convert.ToInt32(fila["Id"]), usuario, password);

                    }

                    return us;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return null;
            }

        }

        public User obtenerUsuario(int id)
        {
            User us = null;
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    String select = @"SELECT cast(aes_decrypt(Nombre_del_Titular, 'nosequeponer.22')as char) as nom,
                        cast(aes_decrypt(Tarjeta_de_Credito, 'nosequeponer.22')as char) as tar,
                        cast(aes_decrypt(CVV, 'nosequeponer.22')as char) as cvv,
                        cast(aes_decrypt(Fecha_de_Vencimiento, 'nosequeponer.22')as char) as fe
                        FROM Usuarios
                        WHERE id=@id";


                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    
                    sentencia.Parameters.AddWithValue("@id", id);

                    sentencia.Connection = Conexion.conexion;

                    MySqlDataAdapter da = new MySqlDataAdapter(sentencia);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow fila = dt.Rows[0];
                        us = new User(fila["tar"].ToString(), fila["cvv"].ToString(), fila["fe"].ToString(), fila["nom"].ToString());

                    }

                    return us;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return null;
            }

        }

        public int actualizarUsuario(int id, string pass, string user, string num, string cvv, string fe, string nom)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    String update = @"UPDATE Usuarios SET 
                        Usuario = SHA2(@User, 256),
                        Password = SHA2(@Pass, 256),
                        Tarjeta_de_Credito = AES_ENCRYPT(@num, 'nosequeponer.22'),
                        CVV = AES_ENCRYPT(@cvv, 'nosequeponer.22'),
                        Fecha_de_Vencimiento = AES_ENCRYPT(@fe, 'nosequeponer.22'),
                        Nombre_del_Titular = AES_ENCRYPT(@nom, 'nosequeponer.22')
                        WHERE id=@id";

                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = update;
                    sentencia.Parameters.AddWithValue("@id", id);
                    sentencia.Parameters.AddWithValue("@User", user);
                    sentencia.Parameters.AddWithValue("@Pass", pass);
                    sentencia.Parameters.AddWithValue("@num", num);
                    sentencia.Parameters.AddWithValue("@cvv", cvv);
                    sentencia.Parameters.AddWithValue("@fe", fe);
                    sentencia.Parameters.AddWithValue("@nom", nom);
                    sentencia.Connection = Conexion.conexion;

                    int filasAfectadas = Convert.ToInt32(sentencia.ExecuteNonQuery());


                    return filasAfectadas;


                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return -1;
            }

        }

    }
}
