using Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Tests
{
    public class UsuarioUnitTest
    {
        [Fact]
        public void CriarObjetoComParametrosValidos()
        {
            Action action = () => new Usuario(1, "Luiz Goebel", "Prefeitura", "goebel.adm@gmail.com", "47991832512", "4733305172");
            action.Should()
                .NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CriarObjetoComIdInvalido()
        {
            Action action = () => new Usuario(-1, "Luiz Goebel", "Prefeitura", "goebel.adm@gmail.com", "47991832512", "4733305172");
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Id inválido.");
        }
    }
}
