using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modulo2_semana6_tests
{
    public class SomaTest : ConfiguracaoHostApi
    {
        [Theory]
        [InlineData(2,4)]
        public async Task Consumir_Api_Exemplo_Soma_Sucesso(int x, int y)
        {
            var resultado = await client.GetAsync($"/ExercicioSoma/{x}/{y}");
            Assert.NotNull(resultado);

            var responseApi = await resultado.Content.ReadAsStringAsync();
            Assert.NotNull(responseApi);
            Assert.Equal($"{x+y}", responseApi);

        }
        [Theory]
        [InlineData(20, 4)]
        public async Task Consumir_Api_Exemplo_Soma_Erro(int x, int y)
        {
            var resultado = await client.GetAsync($"/ExercicioSoma/{x}/{y}");
            Assert.NotNull(resultado);

            var responseApi = await resultado.Content.ReadAsStringAsync();
            Assert.NotNull(responseApi);
            Assert.NotEqual($"{x}+{y}={x + y}", responseApi);

        }
    }
}
