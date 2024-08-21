using Moq.AutoMock;
using Opah.Lancamento.Application.Messages.Requests;
using Opah.Lancamento.Application.Validators;
using Opah.Lib.HttpBase.Exception;

namespace Opah.Lancamento.Application.Test
{
    public class Application
    {
        [Theory]
        [InlineData(100000.01)]
        [InlineData(100001)]
        public void SeCreditoForMuitoAltoDeveRetornarMensagemDeErro(decimal valor)
        {
            //arrange
            var request = new CreditarRequest()
            {
                Valor = valor
            };

            var mocker = new AutoMocker();
            var validator = mocker.CreateInstance<LancamentoValidator>();

            //act
            Action validation = () => validator.Creditar(request);

            //assert
            var exception = Assert.Throws<ErroValidacaoException>(validation);
            Assert.Contains("O valor", exception.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-1000000.123)]
        [InlineData(-0.00001)]
        public void SeCreditoForMuitoBaixoRetornarMensagemDeErro(decimal valor)
        {
            //arrange
            var request = new CreditarRequest()
            {
                Valor = valor
            };

            var mocker = new AutoMocker();
            var validator = mocker.CreateInstance<LancamentoValidator>();

            //act
            Action validation = () => validator.Creditar(request);

            //assert
            var exception = Assert.Throws<ErroValidacaoException>(validation);
            Assert.Contains("O valor", exception.Message);
        }

        [Theory]
        [InlineData(100000.01)]
        [InlineData(-1)]
        [InlineData(-0.00001)]
        public void SeDebitoForMuitoAltoDeveRetornarMensagemDeErro(decimal valor)
        {
            //arrange
            var request = new DebitarRequest()
            {
                Valor = valor
            };

            var mocker = new AutoMocker();
            var validator = mocker.CreateInstance<LancamentoValidator>();

            //act
            Action validation = () => validator.Debitar(request);

            //assert
            var exception = Assert.Throws<ErroValidacaoException>(validation);
            Assert.Contains("O valor", exception.Message);
        }

        [Theory]
        [InlineData(100000.01)]
        [InlineData(-1)]
        [InlineData(-0.00001)]
        public void SeDebitoForMuitoBaixoDeveRetornarMensagemDeErro(decimal valor)
        {
            //arrange
            var request = new DebitarRequest()
            {
                Valor = valor
            };

            var mocker = new AutoMocker();
            var validator = mocker.CreateInstance<LancamentoValidator>();

            //act
            Action validation = () => validator.Debitar(request);

            //assert
            var exception = Assert.Throws<ErroValidacaoException>(validation);
            Assert.Contains("O valor", exception.Message);
        }
    }
}