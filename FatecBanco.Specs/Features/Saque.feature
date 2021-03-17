#language: pt-br
 
Funcionalidade: Saque

Cenario: Saque menor que saldo
	Dado que João possui R$100,00 na conta corrente
	Quando João saca R$40,00
	Então o saque deve ser realizado com sucesso
	E o saldo de João deve ser R$60,00

Cenario: Saque maior que saldo
	Dado que João possui R$100,00 na conta corrente
	Quando João saca R$101,00
	Então deve ser exibida a mensagem 'Saldo Insuficiente'
	E o saldo de João deve ser R$100,00
