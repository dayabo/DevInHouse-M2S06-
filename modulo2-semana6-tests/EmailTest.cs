using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modulo2_semana6_tests
{
    public class EmailTest:ConfiguracaoHostApi
    {
        [Theory]
        [InlineData("dayane@gmail.com")]
        [InlineData("dayane@gmail")]
        [InlineData("dayane@123.com")]
        public async Task Consumir_Api_Exemplo_Email_Sucesso(string email)
        {
            var resultado = await client.GetAsync($"/ExercicioEmail/{email}");
            Assert.NotNull(resultado);

            var responseApi = await resultado.Content.ReadAsStringAsync();
            Assert.NotNull(responseApi);
            Assert.Equal(email, responseApi);
          
        }

        [Theory]
        [InlineData("dayane@123")]
        [InlineData("dayane123.com")]
        public async Task Consumir_Api_Exemplo_Email_Erro(string email)
        {
            var resultado = await client.GetAsync($"/ExercicioEmail/{email}");
            Assert.NotNull(resultado);

            var responseApi = await resultado.Content.ReadAsStringAsync();
            Assert.NotNull(responseApi);
            Assert.Equal("Email Inválido", responseApi);

        }
    }
}
