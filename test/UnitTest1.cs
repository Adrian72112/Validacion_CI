using System;
using Xunit;

namespace Person.Test
{
    public class UnitTest1
    {

        [Fact]
        public void ValidarNombre()
        {
            const String nombrePrueba = "Adrian Tesore";
            Persona person = new Persona(nombrePrueba, "48704997");
            Assert.Equal(nombrePrueba,person.Nombre);
        }

        [Theory]
        [InlineData("4.870.499-7")]
        [InlineData("1.234.567-8")]
        [InlineData("3.742.388-1")]
        public void ValidarCI(string value)
        {
            Persona persona = new Persona("Adrian Tesore", value);
            Boolean actual = persona.validarFormatoCI(persona.numero(value));
            Assert.True(actual,$"{value} no es una cedula valida");
        }
    }
}
