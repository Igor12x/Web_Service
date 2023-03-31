using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Web_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        //Os métodos para serem acessados externamente, precisam ser public
        //Precisamos indicar o método de acesso, ou seja, se será acessado
        //usando GET, POST, PUT (editar) OU DELETE
        //É possível retornar qualquer tipo de dados, isto é, int, double,
        //List, etc ou usar a interface IActionResult para deixar no padrão
        //de webservice

        [HttpPost]
        //configurar uma rota espefícica acrecentar [Route("api/[controller]/cadastrar")] por exemplo.
        public IActionResult cadastrar([FromBody] /*FromBody - copor da requisão - não aparece na URL - ´médoto POST*/ Produto p){
            MySqlConnection conexao = new MySqlConnection(
                "Sever= ;Database= ; User= ;password=  ");
      
            MySqlCommand sql = new MySqlCommand(
                "INSERT  INTO produto VALUES(@id, @nome, @preco, @qtde)", conexao);
            sql.Parameters.AddWithValue("@id", p.id);
            sql.Parameters.AddWithValue("@nome", p.nome);
            sql.Parameters.AddWithValue("@preco", p.preco);
            sql.Parameters.AddWithValue("@qtde", p.quantidade);
            conexao.Open();
            if (sql.ExecuteNonQuery() != 0)
            {
                //usando a interface IActionResult para retornar no padrão webservice
                //o método Ok retorna código 200 (sucesso)
                conexao.Close();
                return Ok(new { mensagem = "Cadastrado"});
            }
            else
            {
                conexao.Clone();
                return NoContent(); //Código 204 (sem conteúdo)
            }
        }
    }
}
