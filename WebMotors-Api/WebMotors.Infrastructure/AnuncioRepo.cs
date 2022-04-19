using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using WebMotors.Domain;
using WebMotors.Infrastructure.Context;
using WebMotors.Infrastructure.Contract;

namespace WebMotors.Infrastructure
{
    public class AnuncioRepo : IAnuncioRepo
    {
        private readonly WebMotorsContext _context;

        public AnuncioRepo(WebMotorsContext context)
        {
            _context = context;
        }

        public async Task<Anuncio> SelectAnuncio(string tema)
        {
            IDbConnection conn = _context.GetConnection();

            using (conn)
            {
                conn.Open();
                string query = @"SELECT *
                                 FROM tb_AnuncioWebmotors
                                 WHERE marca like @tema
                                    OR modelo like @tema
                                    OR versao like @tema
                                    OR observacao like @tema";
                Anuncio anuncio = await conn.QueryFirstOrDefaultAsync<Anuncio>
                    (sql: query, param: new { tema });
                conn.Close();
                return anuncio;
            }
        }

        public async Task<Anuncio> SelectAnuncioById(int id)
        {
            IDbConnection conn = _context.GetConnection();

            using (conn)
            {
                conn.Open();
                string query = @"SELECT * FROM tb_AnuncioWebmotors WHERE Id = @id";
                Anuncio anuncio = await conn.QueryFirstOrDefaultAsync<Anuncio>
                    (sql: query, param: new { id });
                conn.Close();
                return anuncio;
            }
        }

        public async Task<Anuncio> InsertAnuncio(Anuncio anuncio)
        {
            IDbConnection conn = _context.GetConnection();

            using (conn)
            {
                conn.Open();
                string command = @"INSERT INTO tb_AnuncioWebmotors(marca, modelo, versao, ano, quilometragem, observacao) VALUES(@marca,@modelo,@versao,@ano,@quilometragem,@observacao)";

                var result = await conn.ExecuteAsync(sql: command, param: anuncio);
                if (result > 0)
                {
                    conn.Close();
                    return anuncio;
                }
                conn.Close();
                return null;
            }
        }

        public async Task<int> UpdateAnuncio(int id, Anuncio anuncio)
        {
            IDbConnection conn = _context.GetConnection();

            using (conn)
            {
                conn.Open();
                string command = $@"UPDATE tb_AnuncioWebmotors
                                  SET marca = @marca,
                                      modelo = @modelo,
                                      versao = @versao,
                                      ano = @ano,
                                      quilometragem = @quilometragem,
                                      observacao = @observacao
                                  WHERE Id = {id} ";
                var valor = await conn.ExecuteAsync(sql: command, param: anuncio);
                conn.Close();
                return valor;
            }
        }

        public async Task<int> DeleteAnuncio(int id)
        {
            IDbConnection conn = _context.GetConnection();

            using (conn)
            {
                conn.Open();
                string command = @"DELETE FROM tb_AnuncioWebmotors WHERE Id = @id";
                var valor = await conn.ExecuteAsync(sql: command, param: new { id });
                conn.Close();
                return valor;
            }
        }

    }
}
