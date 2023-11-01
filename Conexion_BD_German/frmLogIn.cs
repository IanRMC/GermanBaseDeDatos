using System.Windows.Forms;
using Datos;


namespace Conexion_BD_German
{
    public partial class frmLogIn : Form
    {

        private Conexion co = new Conexion();

        public frmLogIn()
        {
            InitializeComponent();

            string host = "darkserver.mysql.database.azure.com", user = "Usuario", pass = "laverdadnosequeponer";

            co.newSesion(host, user, pass);
        }

        private void btnLogIn_Click(object sender, System.EventArgs e)
        {
            userDAO users = new userDAO();
            User u = users.login(txtUser.Text, txtPass.Text);

            if(u != null )
            {
                frmOpciones ventana = new frmOpciones(u);
                ventana.Show();
                //this.Dispose();
            }
            else
            {
                MessageBox.Show("Usuario y/o Contraseña incorrecta");
            }

        }

    }
}
