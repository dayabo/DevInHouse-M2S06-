using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace modulo2_semana6_api.Controllers;

/// <summary>
/// Exercicio 4
/// </summary>
[ApiController]
[Route("[controller]")]
public class ExercicioEmailController : ControllerBase
{
    /// <summary>
    /// Implementar a regra do exercicio 4 aqui dentro do GET
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    [HttpGet("{email}")]
    public string Get(string email)
    {
       if (DateTime.Now.Minute > 30)
        {
            throw new TempoException("Erro na requsição o minuto está acima de 30");
        }

        if (ValidaEmail(email))
        {
            return email;
        }

        return "Email Inválido";
    }


   
        public static bool ValidaEmail(string email)
        {
            var regexEmail = @"^[\w-.]+@([\w-]+.)+[\w-]{2,4}$";
            var emailValido = Regex.IsMatch(email, regexEmail);
            if (emailValido)
            {
                return true;
            }
            return false;
        }

        [Serializable]
        public class TempoException : Exception
        {
            public TempoException() { }
            public TempoException(string message) : base(message) { }
            public TempoException(string message, Exception inner) : base(message, inner) { }
            protected TempoException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
