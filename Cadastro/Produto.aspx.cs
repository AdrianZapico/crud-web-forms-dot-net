using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Cadastro
{
    public partial class Produto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Salvar(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection openCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\teemo\\OneDrive\\Documents\\scommerce.mdf;Integrated Security=True;Connect Timeout=30"))

                {
                    string saveStaff = "INSERT into Produto (Nome,quantidade,telefone,sexo) VALUES (@Nome,@Quantidade,@telefone,@sexo)";
                    if (tbId.Text != "")
                    {
                        saveStaff = "UPDATE Produto set Nome=@Nome,quantidade=@Quantidade,telefone=@telefone,sexo=@sexo where idProduto=@idProduto";

                    }
                    using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                    {
                        querySaveStaff.Connection = openCon;

                        if (tbId.Text != "")
                        {
                            querySaveStaff.Parameters.Add("@idProduto", SqlDbType.Int).Value = tbId.Text;
                        }
                        querySaveStaff.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = tbnome.Text;
                        querySaveStaff.Parameters.Add("@Quantidade", SqlDbType.Int).Value = tbquantidade.Text;
                        querySaveStaff.Parameters.Add("@telefone", SqlDbType.VarChar).Value = idtelefone.Text;
                        querySaveStaff.Parameters.Add("@sexo", SqlDbType.VarChar).Value = idsexo.Text;
                        openCon.Open();

                        querySaveStaff.ExecuteNonQuery();
                        if (tbId.Text != "")
                        {
                            MessageBox.Show("Produto alterado com Sucesso!!");
                        }
                        else
                        {
                            MessageBox.Show("Produto cadasrado com Sucesso!!");
                        }

                        limparCampo();
                    }
                }
            }
            catch (Exception ex)
            {
                limparCampo();
                idMensagem.Text = "Não salvou,favor digitar apenas numeros" + ex.Message;

            }

        }

        private void limparCampo()
        {
            tbId.Text = "";
            tbnome.Text = "";
            tbquantidade.Text = "";
            idtelefone.Text = "";
            idsexo.Text = "";
        }

        public void onlyNumbers(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbquantidade.Text, "[^0-9]"))
            {
                MessageBox.Show("Digite somente números!");
                tbquantidade.Text = tbquantidade.Text.Remove(tbquantidade.Text.Length - 1);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\teemo\\OneDrive\\Documents\\scommerce.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

            SqlCommand command = new SqlCommand("Select idProduto,Nome,Quantidade,telefone,sexo from [Produto] where idProduto=@idProduto", conn);
            command.Parameters.AddWithValue("@idProduto", tbId.Text);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    tbnome.Text = reader["Nome"].ToString();
                    tbquantidade.Text = reader["Quantidade"].ToString();
                    idtelefone.Text = reader["telefone"].ToString();
                    idsexo.Text = reader["sexo"].ToString();

                }
                else
                {
                    MessageBox.Show("ID inexistente!");
                }
            }

            conn.Close();
        }

        protected void Delete(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\teemo\\OneDrive\\Documents\\scommerce.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM Produto WHERE idProduto   = "+tbId.Text, con))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Deletado com Sucesso");
                        limparCampo();
                    }
                    con.Close();
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}