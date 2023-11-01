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
    public partial class frmOpciones : Form
    {

        User usuario;

        public frmOpciones(User usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            frmPerfil perfil = new frmPerfil(usuario);
            perfil.Show();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Actualizar actualizar = new Actualizar(usuario);
            actualizar.Show();
        }
    }
}
