using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace agenda_telefonica.Views.Home
{


    public partial class AgendaTelefonica : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TELEFONE;Data Source=CELSO-MEGA\KELVIN");


        SqlCommand cmd = new SqlCommand();

        SqlDataAdapter sqlda;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                preenchergrid();

            }
        }

        public void preenchergrid()
        {
            con.Open();
            sqlda = new SqlDataAdapter("select * from Cadastroo", con);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nome.Text = GridView1.SelectedRow.Cells[2].Text;
            email.Text = GridView1.SelectedRow.Cells[3].Text;
            endereço.Text = GridView1.SelectedRow.Cells[4].Text;
            celular.Text = GridView1.SelectedRow.Cells[5].Text;
            telefone.Text = GridView1.SelectedRow.Cells[6].Text;
        }



        protected void salvar_Click1(object sender, EventArgs e)
        {
            Salvar();

        }

        public void Salvar()
        {




            SqlCommand comm;

            comm = new SqlCommand("insert into Cadastroo(Nome,Email,Endereco,Celular,Telefone) values('" + nome.Text + "','" + email.Text + "','" + endereço.Text + "','" + celular.Text + "','" + telefone.Text + "')", con);


            con.Open();
            comm.ExecuteNonQuery();
            con.Close();

            Page.ClientScript.RegisterStartupScript(GetType(), "msgBox", "alert('Cadastrado com secesso!!!')", true);

            preenchergrid();
        }





        protected void Alterar_Click(object sender, EventArgs e)
        {


            SqlCommand comm;

            comm = new SqlCommand("Update Cadastroo set Nome='" + nome.Text + "',Email='" + email.Text + "',Endereco='" + endereço.Text + "',Celular='" + celular.Text + "',Telefone='" + telefone.Text + "' where IDnome='" + GridView1.SelectedRow.Cells[1].Text + "'", con);


            con.Open();
            comm.ExecuteNonQuery();
            con.Close();

            

            Page.ClientScript.RegisterStartupScript(GetType(), "msgBox", "alert('Alterado com secesso!!!')", true);

            preenchergrid();

        }

        protected void Excluir_Click(object sender, EventArgs e)
        {

            SqlCommand comm;

            comm = new SqlCommand("DELETE FROM Cadastroo WHERE IDnome='" + GridView1.SelectedRow.Cells[1].Text + "'", con);


            con.Open();
            comm.ExecuteNonQuery();
            con.Close();

            Page.ClientScript.RegisterStartupScript(GetType(), "msgBox", "alert('Excluido com secesso!!!')", true);

            preenchergrid();

        }
    }
}
