public class ContaBancaria
{
    private decimal saldo;
    private decimal limite;
    private decimal limiteDisponivel;

    public ContaBancaria(decimal saldoInicial, decimal limiteInicial)
    {
        saldo = saldoInicial;
        limite = limiteInicial;
        limiteDisponivel = limiteInicial;
    }

    private decimal TarifarSaque(decimal valor)
    {
        if (valor <= 1000.00m)
        {
            return 1.00m;
        }
        else
        {
            return 2.00m;
        }
    }

    private decimal TarifarMovimentacao(decimal valor)
    {
        return 0.50m;
    }

    public decimal Depositar(decimal valor)
    {
        saldo += valor;
        return saldo;
    }

    public decimal Sacar(decimal valor)
    {
        if (valor > saldo + limiteDisponivel)
        {
            throw new InvalidOperationException("Valor do saque é maior do que o seu saldo e limite disponíveis!");
        }

        saldo -= valor;

        decimal tarifa = TarifarSaque(valor) + TarifarMovimentacao(valor);
        saldo -= tarifa;

        limiteDisponivel = limite - saldo;

        return saldo;
    }

    public decimal ObterSaldo()
    {
        return saldo;
    }

    public decimal ObterLimiteDisponivel()
    {
        return limiteDisponivel;
    }
}