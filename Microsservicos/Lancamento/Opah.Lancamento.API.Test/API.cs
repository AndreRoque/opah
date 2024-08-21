using Opah.Lancamento.API.Controllers;
using Opah.Lancamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Opah.Lancamento.API.Test
{
    public class API
    {
        [Fact]
        public void TestaSeAAplicacaoEstaSaudavel()
        {
            // Arrange
            var mock = new Mock<IInfoService>();
            mock.Setup(r => r.GetMaxMemory())
                .Returns("1000000000");

            var controller = new HealthCheckController(mock.Object);

            // Act
            var result = controller.HealthCheck();

            // Assert
            var r = Assert.IsType<ObjectResult>(result);
            Assert.Contains("healthy: memory", r.Value.ToString());
        }
    }
}