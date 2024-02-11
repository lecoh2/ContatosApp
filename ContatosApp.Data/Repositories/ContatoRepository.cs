using ContatosApp.Data.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Data.Repositories
{
    public class ContatoRepository
    {
        // atributo 
        private string _connectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDCcontatosApp;Integrated Security=True;";

        public void Insert(Contato c)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"INSERT INTO CONTATO
                                    (ID, NOME,EMAIL, TELEFONE, DATAHORACADASTRO)
                                    VALUES(@ID, @NOME,@EMAIL, @TELEFONE, @DATAHORACADASTRO)
                                    ", new
                {
                    @ID = c.Id,
                    @NOME = c.Nome,
                    @EMAIL = c.Email,
                    @TELEFONE = c.Telefone,
                    @DATAHORACADASTRO = c.DataHoraCadastro
                });

            }
        }
        public void Update(Contato c)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"UPDATE CONTATO SET
                                    ID=@ID, NOME = @NOME, TELEFONE=@TELEFONE, EMAIL=@EMAIL FROM CONTATO 
                                    WHERE ID=@ID", new
                {

                    @NOME = c.Nome,
                    @EMAIL = c.Email,
                    @TELEFONE = c.Telefone,
                    @ID = c.Id
                });
            }
        }
        public void Delete(Contato c)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"UPDATE CONTATO SET ATIVO = 0 WHERE ID = @ID", new
                {
                    @ID = c.Id
                });
            }
        }
        public List<Contato> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Contato>(@"SELECT 
                                    ID, NOME,EMAIL, TELEFONE, DATAHORACADASTRO, ATIVO 
                                    FROM CONTATO WHERE ATIVO=1").ToList();
            }
        }
        public Contato? GetById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Contato>(@"SELECT
                                ID, NOME,EMAIL, TELEFONE, DATAHORACADASTRO, ATIVO FROM CONTATO WHERE ATIVO = 1 AND ID=@ID", new
                {
                    @ID = id
                }).FirstOrDefault();
            }
        }
    }
}
