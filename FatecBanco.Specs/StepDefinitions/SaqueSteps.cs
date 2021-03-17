using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace FatecBanco.Specs.Features
{
    [Binding]
    public class SaqueSteps
    {
        private ScenarioContext _scenarioContext;
        private ContaCorrente contaCorrente;
        ResultadoOperacao resultadoOperacao;
        public SaqueSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"que João possui R\$(.*) na conta corrente")]
        public void DadoQueJoaoPossuiRSNaContaCorrente(decimal valor)
        {
            contaCorrente = new ContaCorrente(saldo: valor);
        }
        
        [When(@"João saca R\$(.*)")]
        public void QuandoJoaoSacaRS(decimal valor)
        {
            resultadoOperacao = contaCorrente.Sacar(valor);
        }
        
        [Then(@"o saque deve ser realizado com sucesso")]
        public void EntaoOSaqueDeveSerRealizadoComSucesso()
        {
            resultadoOperacao.Should().Be(ResultadoOperacao.SaqueRealizado);
        }

        [Then(@"deve ser exibida a mensagem 'Saldo Insuficiente'")]
        public void EntaoOSaqueNaoDeveSerRealizado()
        {
            resultadoOperacao.Should().Be(ResultadoOperacao.SaldoInsuficiente);
        }

        [Then(@"o saldo de João deve ser R\$(.*)")]
        public void EntaoOSaldoDeJoaoDeveSerRS(decimal valor)
        {
            contaCorrente.Saldo.Should().Be(valor);
        }
    }
}
