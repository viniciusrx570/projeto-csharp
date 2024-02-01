/*

O Petshop LalaDog precisa de um sistema para ajudar nos cuidados dos pets.

O sistema deve ter 3 opções em um menu.

- Calculo medicação: O usuário informa o peso do pet e a dose por quilo do medicamento,
 ao final o sistema mostra a dose correta.

- Agendamento de Banho: O usuário informa o porte do pet.
 O sistema também pergunta se
 deve ser adicionado cuidados extras (tirar parasitas, aparar pelos, shampoo premium)
  em que cada um tem um valor adicional de R$ 20. Ao final o sistema mostra o valor total do banho.
Pequeno - R$ 80; Médio - R$ 100; Grande - R$ 120

- Cálculo de Alimentação:
 O usuário informa a quantidade de pets que possui
e a quantidade de ração disponível.
O sistema calcula a quantidade de ração diária necessária para todos os pets
com base em 100g por pet
e verifica se a quantidade disponível é suficiente para alimentá-los por um determinado período
(por exemplo, 30 dias).
 O sistema exibe uma mensagem indicando se a ração é suficiente ou se é necessário comprar mais.
*/


internal class Program
{
    private static void Main(string[] args)
    {
        int operacao = 0;

        while (operacao != 9)
        {
            Console.WriteLine("Bem vindo ao sistema LaLaDOG");

            Console.WriteLine("1 - Calculo de medicação");
            Console.WriteLine("2 - Calculo de custo do banho");
            Console.WriteLine("3 - Calculo de disponibilidade de ração");
            Console.WriteLine("9 - Sair");

            // Espera o usuário digitar a operação
            int.TryParse(Console.ReadLine(), out operacao);

            //* operação 9 encerrar o programa.
            if (operacao == 9)
            {
                // Limpa todas as mensagens do console.
                Console.Clear();

                Console.WriteLine("Obrigado por utilizar nosso sistema.");
                Console.WriteLine("Tenha um bom dia!");

                // Aguarda 2 segundos para dar tempo de leitura
                Thread.Sleep(2000);

                // Fecha o programa.
                Environment.Exit(0);
            }

            //* Calculo medicaçã.
            if (operacao == 1)
            {
                Console.Clear();
                //? Usuario informa os dados necessários para operação.
                Console.WriteLine("Vamos realizar o calculo de medicação do pet");

                Console.Write("Qual o peso do animal?: ");
                decimal peso = decimal.Parse(Console.ReadLine()!);
                Console.Write("Qual a dose do medicamento?: ");
                decimal doseKg = decimal.Parse(Console.ReadLine()!);

                //? Calculo da operação
                decimal dose = peso * doseKg;

                //? informa o valor e encerra o programa.
                Console.WriteLine($"A dose total do medicamento deve ser de {dose}");
                Console.ReadKey();
                Console.Clear();
            }
            //* Agendamento de banho.
            if (operacao == 2)
            {
                int pequeno = 80;
                int medio = 100;
                int grande = 120;

                bool tirarParasita = false;
                bool apararPelos = false;
                bool shampoo = false;

                Console.WriteLine("Vamos realizar o calculo de custo para o banho!");

                // Solicita imformação.

                Console.Write("Qual o porte do seu pet (p,m,g)?: ");
                string? porte = Console.ReadLine();

                Console.WriteLine("Deseja cuidados extras? [s/n]: ");

                string cuidadosExtras = Console.ReadLine()!;

                if (cuidadosExtras == "s")
                {
                    int adicionais = 0;

                    while (adicionais != 4)
                    {
                        int valorInt;

                        Console.WriteLine("Quais cuidados deseja?");
                        Console.WriteLine($"[{(tirarParasita ? "x" : " ")}] 1 - Remover parasitas");
                        Console.WriteLine($"[{(apararPelos ? "x" : " ")}] 2 - Aparar pelos");
                        Console.WriteLine($"[{(shampoo ? "x" : " ")}] 3 - Usar shampoo premium");
                        Console.WriteLine("Digite 4 para parar de adicionar");

                        adicionais = (int)SolicitaInformacao("", "int");

                        if (adicionais == 1)
                        {
                            tirarParasita = !tirarParasita;
                        }
                        if (adicionais == 2)
                        {
                            apararPelos = !apararPelos;
                        }
                        if (adicionais == 3)
                        {
                            shampoo = !shampoo;
                        }
                        Console.Clear();
                    }
                }
                decimal valorTotal = 0;

                if (porte == "p")
                    valorTotal += 80;
                else if (porte == "m")
                    valorTotal += 100;
                else if (porte == "g")
                    valorTotal += 120;

                // Teste ternário para somar os valores extras
                valorTotal += tirarParasita ? 20 : 0;
                valorTotal += apararPelos ? 20 : 0;
                valorTotal += shampoo ? 20 : 0;

                Console.WriteLine($"O valor total do banho é de {valorTotal}");

                // Espera o usuário sair da operação
                Console.ReadKey();

                // Limpa a tela
                Console.Clear();
            }
            if (operacao == 3)
            {
                // Limpa todas as mensagens do console.
                Console.Clear();

                Console.WriteLine("Vamos realizar o calculo de ração disponível!");

                decimal racaoDisponivel = (decimal)SolicitaInformacao("Quanto de ração está disponível em kg?", "decimal");
                int quantidadePets = (int)SolicitaInformacao("Qual a quantidade de pets no Local?", "int");
                int dias = (int)SolicitaInformacao("Quantos dias os pets irão ficar?", "int");

                decimal custoTotal = (quantidadePets * 0.1m) * dias;

                if (racaoDisponivel >= custoTotal)
                {
                    Console.WriteLine("Você possui ração suficente para todos os dias");
                }
                else
                {
                    Console.WriteLine($"É melhor comprar ração, vai faltar {custoTotal - racaoDisponivel} kg de ração");
                }

                // Espera o usuário sair da operação
                Console.ReadKey();

                // Limpa a tela
                Console.Clear();
            }
            
        }
    }
    static object SolicitaInformacao(string mensagem, string tipo)
    {
        decimal valorDecimal;
        int valorInteiro;

        // Verifica se a mensagem tem mais de 0 caracteres
        if (mensagem.Length > 0)
            Console.WriteLine(mensagem);

        if (tipo == "string")
            return Console.ReadLine()!;
        else if (tipo == "decimal")
        {
            decimal.TryParse(Console.ReadLine(), out valorDecimal);
            return valorDecimal;
        }
        else if (tipo == "int")
        {
            int.TryParse(Console.ReadLine(), out valorInteiro);
            return valorInteiro;
        }

        return "";
    }
}
