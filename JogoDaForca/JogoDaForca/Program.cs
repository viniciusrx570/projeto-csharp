// Jogo da forca
// Criar lista de palavras [].
// Criar laço de repetição enquanto a resposta de diferente de "s"
//  Criar menu com as opçoes:
//      - 0 para sair;
//      - 1 para jogar;
//  Se 1 por precionado iniciar a logica de jogo:
//      - pegar a variavel que contem a lista de palavras e colocar em um uma variavel que contem a palavra aleatora da lista;
//      - contar a quantidade de letras que a variavel possui;
//      - o numero de erros é 6;



internal class Program
{
    static void Main(string[] args)
    {
        List<string> palavras = new List<string> { "uva", "banana", "pera", "manga", "melancia" };

        Random random = new Random();

        string palavra = palavras[random.Next(palavras.Count)];

        char[] letras = palavra.ToCharArray();
        int operacao = 0;

        while (operacao != 9)
        {
            Console.WriteLine("# ----- Jogo da Forca ----- #");
            Console.WriteLine();
            Console.WriteLine("Jogar - 1");
            Console.WriteLine("Sair - 9");

            int.TryParse(Console.ReadLine(), out operacao);
            Console.Clear();

            // encerra o programa.
            if (operacao == 9)
            {
                Console.Clear();
                Console.WriteLine("Obrigado por jogar xD");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

            if (operacao == 1)
            {
                Console.Clear();

                int tentativas = 0;
                Console.WriteLine("Tente adivinhar as letras");
                List<char> letrasRestantes = new List<char>(letras);

                // verifica se contem a letra
                while (letrasRestantes.Count > 0 && tentativas < 6)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Tentativas: {6 - tentativas} / 6.");
                    Console.WriteLine();

                    Console.Write("Digite uma letra: ");
                    char letraDigitada = Console.ReadLine()![0];

                    if (letrasRestantes.Contains(letraDigitada))
                    {
                        Console.WriteLine($"A lista contém o caractere {letraDigitada}.");
                        letrasRestantes.RemoveAll(l => l == letraDigitada);
                    }
                    else
                    {
                        Console.WriteLine($"A lista não contém o caractere {letraDigitada}.");
                        tentativas++;
                    }
                }
                // caso a pessoa acerte a palavra
                if (letrasRestantes.Count == 0)
                {
                    Console.WriteLine("Parabéns! Você adivinhou a palavra: " + $"""{palavra}""");
                }
                else
                {
                    Console.WriteLine($"Você atingiu o limite de tentativas. A palavra era: {palavra}");
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}