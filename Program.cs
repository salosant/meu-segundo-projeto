public class Program
{
    static void Main(string[] args)
    {
        ContaBancaria conta = new ContaBancaria(1000.00m, 5000.00m);

        while (true)
        {
            etq2:
            Console.WriteLine("Seu saldo atual é: " + conta.ObterSaldo());
            Console.WriteLine("Seu limite disponível é: " + conta.ObterLimiteDisponivel());
            Console.WriteLine("Digite 1 para fazer um depósito");
            Console.WriteLine("Digite 2 para fazer um saque");
            Console.WriteLine("Digite 3 para sair");
            
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
            etq1:
                Console.WriteLine("Digite o valor do depósito:");
                decimal valor = decimal.Parse(Console.ReadLine());
            if (valor < 500)
            {
                System.Console.WriteLine("Valor minimo requerido R$500 ");
                goto etq1;
            }
                conta.Depositar(valor);

                Console.WriteLine("Depósito realizado com sucesso!");
                Console.WriteLine("Valor do depósito: " + valor);
                Console.WriteLine("Saldo atual: " + conta.ObterSaldo());
            
            }
            
            else if (opcao == 2)
            {
                Console.WriteLine("Digite o valor do saque:");
                decimal valor = decimal.Parse(Console.ReadLine());

                try
                {
                    conta.Sacar(valor);

                    Console.WriteLine("Saque realizado com sucesso!");
                    Console.WriteLine("Valor do saque: " + valor);
                    Console.WriteLine("Saldo atual: " + conta.ObterSaldo());
                    Console.WriteLine("Limite disponível: " + conta.ObterLimiteDisponivel());
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (opcao == 3)
            {
                break;
            }
            else 
            {
                Console.WriteLine("Opção inválida! Tente novamente.");
                goto etq2;
            }
        }
    }
}