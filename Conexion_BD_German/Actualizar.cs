using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace Conexion_BD_German
{
    public partial class Actualizar : Form
    {

        User u;

        public Actualizar(User u)
        {
            InitializeComponent();
            this.u = u;
            User u2 = new userDAO().obtenerUsuario(u.Id);

            txtUser.Text = u.user;
            txtPassword.Text = u.password;
            txtNum.Text = u2.numTarjeta;
            txtCVV.Text = u2.CVV;
            txtMes.Text = u2.fechaVe;
            txtNom.Text = u2.NomTitular;


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            new userDAO().actualizarUsuario(u.Id, txtPassword.Text, txtUser.Text, txtNum.Text, txtCVV.Text, txtMes.Text, txtNom.Text);

            MessageBox.Show("Ya");
        }
    }
}
