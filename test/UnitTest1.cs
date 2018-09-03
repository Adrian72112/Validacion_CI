using System;
using Xunit;

namespace Person.Test
{
    public class UnitTest1
    {
        [Fact]
        public void ValidarCIFalsa()
        {
            Persona persona = new Persona("John Doe", "1.234.567-8");
            Boolean actual = persona.validarFormatoCI("1.234.567-8");
            Assert.Equal(false, actual);
        }
        [Fact]
        public void ValidarCIVerdadero()
        {
            Persona persona = new Persona("John Doe", "4.870.499-7");
            Boolean actual = persona.validarFormatoCI("4.870.499-7");
            Assert.Equal(true, actual);
        }
    }
}
