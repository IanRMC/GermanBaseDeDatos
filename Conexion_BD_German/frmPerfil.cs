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
    public partial class frmPerfil : Form
    {

        public frmPerfil(User Datos1)
        {
            InitializeComponent();

            User Datos2 = new userDAO().obtenerUsuario(Datos1.Id);

            lblUser.Text = Datos1.user;
            lblCVV.Text = Datos2.CVV;
            lblFecha.Text = Datos2.fechaVe;
            lblNom.Text = Datos2.NomTitular;
            lblNum.Text = Datos2.numTarjeta;

        }
    }
}
