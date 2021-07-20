using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CadastroCarros
{
    public partial class addcarro : Form
    { 
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;

        string strSQL;
    
        public addcarro()
        {
            InitializeComponent();

           
            


        }

        
       
        

      

        private void addcarro_Load(object sender, EventArgs e)
        {

        }


        private void btn_gravar_Click(object sender, EventArgs e)
        {

            try
            {

            
            conn = new SqlConnection(@"Server = DESKTOP-O23UA05\SQLEXPRESS;Database = Projeto_CRUD; User Id = sa; Password = 12345");

            strSQL = "insert into Carro (Marca,Modelo,Chassi,Combustivel,Ano,Kilometragem,Cor,Placa) values(@Marca,@Modelo,@Chassi,@Combustivel,@Ano,@Kilometragem,@Cor,@Placa)";

            cmd = new SqlCommand(strSQL, conn);

            cmd.Parameters.Add("@Marca",SqlDbType.VarChar).Value = txt_marca.Text;
            cmd.Parameters.Add("@Modelo",SqlDbType.VarChar).Value = txt_modelo.Text;
            cmd.Parameters.Add("@Chassi",SqlDbType.VarChar).Value = txt_chassi.Text;
            cmd.Parameters.Add("@Combustivel",SqlDbType.VarChar).Value = txt_combustivel.Text;
            cmd.Parameters.Add("@Ano",SqlDbType.VarChar).Value = msk_ano.Text;
            cmd.Parameters.Add("@Kilometragem",SqlDbType.VarChar).Value = msk_kilometragem.Text;
            cmd.Parameters.Add("@Cor",SqlDbType.VarChar).Value = txt_cor.Text;
            cmd.Parameters.Add("@Placa",SqlDbType.VarChar).Value = txt_placa.Text;

            conn.Open();
            

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cadastro efetuado com sucesso");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
               
            }

            txt_pesquisar.Enabled = true;

            txt_marca.Clear();
            txt_modelo.Clear();
            txt_cor.Clear();
            txt_chassi.Clear();
            txt_combustivel.Clear();
            txt_placa.Clear();
            msk_ano.Clear();
            msk_kilometragem.Clear();
            
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            try
            {


                conn = new SqlConnection(@"Server = DESKTOP-O23UA05\SQLEXPRESS;Database = Projeto_CRUD; User Id = sa; Password = 12345");
                 
                strSQL = "select * from Carro where Chassi = @Pesquisar";
                

                cmd = new SqlCommand(strSQL, conn);

                cmd.Parameters.Add("@Pesquisar", SqlDbType.VarChar).Value = txt_pesquisar.Text;

                if(txt_pesquisar.Text == String.Empty)
                {
                    MessageBox.Show("Digite a chassi do carro que deseja pesquisar");
                }
                

                conn.Open();
                dr = cmd.ExecuteReader();

                if(dr.HasRows == false)

                {
                    throw new Exception("Chassi não cadastrada");
                }
                
                while (dr.Read())
                {
                    txt_marca.Text = Convert.ToString (dr["Marca"]);
                    txt_modelo.Text = Convert.ToString (dr["Modelo"]);
                    txt_chassi.Text = Convert.ToString (dr["Chassi"]);
                    txt_combustivel.Text = Convert.ToString(dr["Combustivel"]);
                    msk_ano.Text = Convert.ToString (dr["Ano"]);
                    msk_kilometragem.Text = Convert.ToString (dr["Kilometragem"]);
                    txt_cor.Text = Convert.ToString (dr["Cor"]);
                    txt_placa.Text = Convert.ToString (dr["Placa"]);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                
            }

        }

       

        private void btn_exibir_Click(object sender, EventArgs e)
        {
            try
            {


                conn = new SqlConnection(@"Server = DESKTOP-O23UA05\SQLEXPRESS;Database = Projeto_CRUD; User Id = sa; Password = 12345");

                strSQL = "select * from Carro";

                DataSet ds = new DataSet();

                da = new SqlDataAdapter(strSQL, conn);

                conn.Open();

                da.Fill(ds);

                dg_dados.DataSource = ds.Tables[0];

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                
            }
        }

       

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {


                conn = new SqlConnection(@"Server = DESKTOP-O23UA05\SQLEXPRESS;Database = Projeto_CRUD; User Id = sa; Password = 12345");

                strSQL = "update Carro set Marca = @Marca, Modelo = @Modelo, Chassi = @Chassi, Combustivel = @Combustivel, Ano = @Ano, Kilometragem = @Kilometragem, Cor = @Cor, Placa = @Placa where Chassi = @Chassi";

                cmd = new SqlCommand(strSQL, conn);

               
                cmd.Parameters.Add("@Marca", SqlDbType.VarChar).Value = txt_marca.Text;
                cmd.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = txt_modelo.Text;
                cmd.Parameters.Add("@Chassi", SqlDbType.VarChar).Value = txt_chassi.Text;
                cmd.Parameters.Add("@Combustivel", SqlDbType.VarChar).Value = txt_combustivel.Text;
                cmd.Parameters.Add("@Ano", SqlDbType.VarChar).Value = msk_ano.Text;
                cmd.Parameters.Add("@Kilometragem", SqlDbType.VarChar).Value = msk_kilometragem.Text;
                cmd.Parameters.Add("@Cor", SqlDbType.VarChar).Value = txt_cor.Text;
                cmd.Parameters.Add("@Placa", SqlDbType.VarChar).Value = txt_placa.Text;

                conn.Open();


                cmd.ExecuteNonQuery();
                MessageBox.Show("Modificação do cadastro efetuado com sucesso");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();

            }
        }

         private void btn_deletar_Click(object sender, EventArgs e)
        {
            try
            {


                conn = new SqlConnection(@"Server = DESKTOP-O23UA05\SQLEXPRESS;Database = Projeto_CRUD; User Id = sa; Password = 12345");

                strSQL = "delete Carro where Chassi = @Chassi";

                cmd = new SqlCommand(strSQL, conn);

                cmd.Parameters.Add("@Chassi", SqlDbType.VarChar).Value = txt_chassi.Text;
                

                conn.Open();


                cmd.ExecuteNonQuery();
                MessageBox.Show("Carro deletado com sucesso");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                
            }
        }

       
    }
}
