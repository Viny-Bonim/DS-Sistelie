using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS_Sistelie.Interfaces;
using DS_Sistelie.Database;
using MySql.Data.MySqlClient;

namespace DS_Sistelie.Models
{
    class VendaDAO : IDAO<Venda>
    {
        private static Conexao conn;

        public VendaDAO()
        {
            conn = new Conexao();
        }
 
        public void Insert(Venda t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Venda (unidade_venda, valor_desconto, data_venda, valor_unidade, forma_pagamento, nome_cliente, nome_vendedor, descricao_venda, quantidade_unidade, valor_total_venda, cod_pedido_fk, cod_clien_fk, cod_func_fk, cod_caixa_fk, cod_produto_fk) " +
                    "VALUES (@unidadevenda, @valordesconto, @datavenda, @valorunidade, @formapagamento, @nomecliente, @nomevendedor, @descricaovenda, @quantidadeunidade, @valortotalvenda, @codpedidofk, @codclientefk, @codfuncfk, @codcaixafk, @codprodutofk)";

                query.Parameters.AddWithValue("@unidadevenda", t.UnidadeVenda);
                query.Parameters.AddWithValue("@valordesconto", t.Valordesconto);
                query.Parameters.AddWithValue("@datavenda", t.DataVenda?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@valorunidade", t.ValorUnidade);
                query.Parameters.AddWithValue("@formapagamento", t.Formapagamento);
                query.Parameters.AddWithValue("@nomecliente", t.Nomecliente);
                query.Parameters.AddWithValue("@nomevendedor", t.Nomevendedor);
                query.Parameters.AddWithValue("@descricaovenda", t.DescricaoVenda);
                query.Parameters.AddWithValue("@quantidadeunidade", t.Quantidade);
                query.Parameters.AddWithValue("@valortotalvenda", t.ValorTotal);
                query.Parameters.AddWithValue("@codpedidofk", t.Codpedidofk);
                query.Parameters.AddWithValue("@codclientefk", t.Codclientefk);
                query.Parameters.AddWithValue("@codfuncfk", t.Codfuncionariofk);
                query.Parameters.AddWithValue("@codcaixafk", t.Codcaixafk);
                query.Parameters.AddWithValue("@codprodutofk", t.Codprodutofk);


                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("A venda não registrada, por favor tente novamente!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

 
        public List<Venda> List()
        {
            try
            {
                List<Venda> listForn = new List<Venda>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Venda";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    listForn.Add(new Venda()
                    {
                        Codigovenda = reader.GetInt32("cod_venda"),
                        UnidadeVenda = reader.GetString("unidade_venda"),
                        Valordesconto = reader.GetString("valor_desconto"),
                        DataVenda = reader.GetDateTime("data_venda"),
                        ValorUnidade = reader.GetString("valor_unidade"),
                        Formapagamento = reader.GetString("forma_pagamento"),
                        Nomecliente = reader.GetString("nome_cliente"),
                        Nomevendedor = reader.GetString("nome_vendedor"),
                        DescricaoVenda = reader.GetString("descricao_venda"),
                        Quantidade = reader.GetString("quantidade_unidade"),
                        ValorTotal = reader.GetString("valor_total_venda"),
                    });
                }

                return listForn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        public void Update(Venda t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE Venda SET cod_venda = @id, unidade_venda = @unidadevenda, valor_desconto = @valordesconto, data_venda = @datavenda, valor_unidade = @valorunidade, forma_pagamento = @formapagamento, nome_cliente = @nomecliente, nome_vendedor = @nomevendedor, descricao_venda = @descricaovenda, quantidade_unidade = @quantidadeunidade, valor_total_venda = @valortotalvenda, cod_pedido_fk = @codpedidofk, cod_cliente_fk = @codclientefk, cod_func_fk = @codfuncfk, cod_caixa_fk = @codigocaixafk, cod_produto_fk = @codprodutofk";

                query.Parameters.AddWithValue("@id", t.Codigovenda);
                query.Parameters.AddWithValue("@unidadevenda", t.UnidadeVenda);
                query.Parameters.AddWithValue("@valordesconto", t.Valordesconto);
                query.Parameters.AddWithValue("@datavenda", t.DataVenda?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@valorunidade", t.ValorUnidade);
                query.Parameters.AddWithValue("@formapagamento", t.Formapagamento);
                query.Parameters.AddWithValue("@nomecliente", t.Nomecliente);
                query.Parameters.AddWithValue("@nomevendedor", t.Nomevendedor);
                query.Parameters.AddWithValue("@descricaovenda", t.DescricaoVenda);
                query.Parameters.AddWithValue("@quantidadeunidade", t.Quantidade);
                query.Parameters.AddWithValue("@valortotalvenda", t.ValorTotal);
                query.Parameters.AddWithValue("@codpedidofk", t.Codpedidofk);
                query.Parameters.AddWithValue("@codclientefk", t.Codclientefk);
                query.Parameters.AddWithValue("@codfuncfk", t.Codfuncionariofk);
                query.Parameters.AddWithValue("@codcaixafk", t.Codcaixafk);
                query.Parameters.AddWithValue("@codprodutofk", t.Codprodutofk);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Atualização do registro não foi realizada!");

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Delete(Venda t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM Venda WHERE cod_venda = @id";

                query.Parameters.AddWithValue("@id", t.Codigovenda);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("A venda não foi excluído corretamente, por favor tente novamente!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }


        public Venda GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT* FROM Venda WHERE cod_venda = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var registrarvenda = new Venda();

                while (reader.Read())
                {
                    registrarvenda.Codigovenda = reader.GetInt32("cod_venda");
                   


                }

                return registrarvenda;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Query();
            }
        }
      
    }
}
