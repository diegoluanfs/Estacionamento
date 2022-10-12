namespace Estacionamento
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o preço inicial:");
            var precoInicial = Console.ReadLine();
            Console.WriteLine("Agora digite o preço por hora:");
            var precoPorHora = Console.ReadLine();

            Estacionamento estacionamento = new Estacionamento();
            IList<Veiculo> veiculos = new List<Veiculo>();
            estacionamento.Veiculos = veiculos;

            int opcao;

            do
            {
                opcao = 0;
                opcao = ChamarMenu();

                switch (opcao)
                {
                    case 1:
                        CadastrarVeiculo(estacionamento);
                        Console.WriteLine("Aperte alguma tecla para voltar ao menu principal.");
                        break;
                    case 2:
                        RemoverVeiculo(estacionamento);
                        break;
                    case 3:
                        ListarVeiculos(estacionamento);
                        break;
                    case 4:
                        break;
                    default:

                        break;
                }
            } while (opcao != 4);
        }

        public static int ChamarMenu()
        {
            bool isNumeric = false;
            int opcaoInt;
            do
            {
                Console.Clear();
                Console.WriteLine("Digite a sua opção:");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículo");
                Console.WriteLine("4 - Encerrar");
                var opcaoString = Console.ReadLine();
                if (opcaoString.All(char.IsDigit))
                {
                    opcaoInt = int.Parse(opcaoString);
                    isNumeric = true;
                }
                else
                {
                    opcaoInt = 0;
                }
            } while (isNumeric == false);

            return opcaoInt;
        }
        public static void CadastrarVeiculo(Estacionamento estacionamento)
        {
            Console.WriteLine("Digite a placa do carro: ");
            var placa = Console.ReadLine();
            Veiculo veiculo = new Veiculo();
            veiculo.Placa = placa;
            estacionamento.Veiculos.Add(veiculo);
        }
        public static void ListarVeiculos(Estacionamento estacionamento)
        {
            Console.Clear();
            Console.WriteLine("A placa dos carros que estão no estacionamento são: \n");

            foreach (var veiculo in estacionamento.Veiculos)
            {
                Console.WriteLine("Placa: " + veiculo.Placa.ToString());
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
            Console.ReadLine();
        }
        public static void RemoverVeiculo(Estacionamento estacionamento)
        {
            Console.Clear();
            Console.WriteLine("Qual a placa do veículo? \n");
            var placaIn = Console.ReadLine();
            int horasEstacinonadoInt;
            bool isNumeric = false;
            int cont = 0;

            foreach (var veiculo in estacionamento.Veiculos)
            {
                if (veiculo.Placa.ToString().Equals(placaIn))
                {
                    cont++;
                }
            }
            if (cont > 0)
            {
                do
                {
                    Console.WriteLine("Veículo encontrado, quantas horas esse veículo ficou estacionado?");
                    var horasEstacinonado = Console.ReadLine();
                    if (horasEstacinonado.All(char.IsDigit))
                    {
                        horasEstacinonadoInt = int.Parse(horasEstacinonado);
                        Veiculo veiculoRemover = new Veiculo();
                        veiculoRemover.Placa = placaIn;

                        foreach (var veiculo in estacionamento.Veiculos)
                        {
                            if (veiculo.Placa.ToString().Equals(placaIn))
                            {
                                estacionamento.Veiculos.Remove(veiculo);
                            }
                        }

                        isNumeric = true;
                        Console.WriteLine("Veículo removido com sucesso!");
                    }
                    else
                    {
                        horasEstacinonadoInt = 0;
                    }
                } while (isNumeric == false);
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
            Console.ReadLine();
        }
    }
}