using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modulo2_semana6_tests
{
    public class VerdadeiroFalsoTest : ConfiguracaoHostApi
    {
        [Theory]
        [InlineData("verdadeiro")]
        [InlineData("falso")]
        public void Consumir_Api_Exemplo_Texto_Verdadeiro_Ou_Falso_Sucesso(string texto)
        {
            var resultado = client.GetAsync($"/ExercicioVerdadeiroFalso/{texto}").GetAwaiter().GetResult();
            Assert.NotNull(resultado);

            var responseApi = resultado.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Assert.NotNull(responseApi);
            Assert.Equal("O texto foi igual a verdadeiro ou falso", responseApi);
        }


        [Theory]
        [InlineData("V")]
     
        public void Consumir_Api_Exemplo_Texto_Verdadeiro_Ou_Falso_Erro(string texto)
        {
            var resultado = client.GetAsync($"/ExercicioVerdadeiroFalso/{texto}").GetAwaiter().GetResult();
            Assert.NotNull(resultado);

            var responseApi = resultado.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Assert.NotEqual("O texto foi igual a verdadeiro ou falso", responseApi);
            Assert.Equal("Texto diferente de verdadeiro ou falso", responseApi);
          
        }
    }
}
