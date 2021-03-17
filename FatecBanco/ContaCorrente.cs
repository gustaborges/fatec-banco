using System;
using System.Collections.Generic;
using System.Text;

namespace FatecBanco
{
    public class ContaCorrente
    {
        public ContaCorrente(decimal saldo)
        {
            Saldo = saldo;
        }

        public decimal Saldo { get; private set; }

        public ResultadoOperacao Sacar(decimal valor)
        {
            if(valor > Saldo)
                return ResultadoOperacao.SaldoInsuficiente;

            this.Saldo -= valor;
            return ResultadoOperacao.SaqueRealizado;
        }
    }
}
