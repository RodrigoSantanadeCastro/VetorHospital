using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetorHospital
{
    class Program
    {
        const int maxPacientes = 10;
        static Paciente[] filaPacientes = new Paciente[maxPacientes];
        static int inicio = 0;
        static int fim = 0;
        static int totalPacientes = 0;

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Cadastrar paciente");
                Console.WriteLine("2 - Inserir paciente na fila");
                Console.WriteLine("3 - Listar fila de pacientes");
                Console.WriteLine("4 - Incluir paciente prioritário");
                Console.WriteLine("5 - Atender paciente");
                Console.WriteLine("q - Sair");
                string opcao = Console.ReadLine();

                if (opcao == "q")
                {
                    break;
                }

                switch (opcao)
                {
                    case "1":
                        CadastrarPaciente();
                        break;
                    case "2":
                        InserirPacienteNaFila();
                        break;
                    case "3":
                        ListarFilaDePacientes();
                        break;
                    case "4":
                        IncluirPacientePrioritario();
                        break;
                    case "5":
                        AtenderPaciente();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void CadastrarPaciente()
        {
            if (totalPacientes < maxPacientes)
            {
                Console.WriteLine("Digite o nome do paciente:");
                string nome = Console.ReadLine();
                Paciente paciente = new Paciente(nome);
                filaPacientes[totalPacientes++] = paciente;
                Console.WriteLine("Paciente cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Número máximo de pacientes cadastrados atingido!");
            }
        }

        static void InserirPacienteNaFila()
        {
            if (fim < maxPacientes)
            {
                Console.WriteLine("Digite o nome do paciente a ser inserido na fila:");
                string nome = Console.ReadLine();
                Paciente paciente = EncontrarPaciente(nome);
                if (paciente != null)
                {
                    filaPacientes[fim++] = paciente;
                    Console.WriteLine("Paciente inserido na fila com sucesso!");
                }
                else
                {
                    Console.WriteLine("Paciente não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("Fila de pacientes está cheia!");
            }
        }

        static void ListarFilaDePacientes()
        {
            Console.WriteLine("Pacientes na fila:");
            for (int i = inicio; i < fim; i++)
            {
                Console.WriteLine(filaPacientes[i].Nome);
            }
        }

        static void IncluirPacientePrioritario()
        {
            if (fim < maxPacientes)
            {
                Console.WriteLine("Digite o nome do paciente prioritário a ser inserido na fila:");
                string nome = Console.ReadLine();
                Paciente paciente = EncontrarPaciente(nome);
                if (paciente != null)
                {
                    for (int i = fim; i > inicio; i--)
                    {
                        filaPacientes[i] = filaPacientes[i - 1];
                    }
                    filaPacientes[inicio] = paciente;
                    fim++;
                    Console.WriteLine("Paciente prioritário inserido na fila com sucesso!");
                }
                else
                {
                    Console.WriteLine("Paciente não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("Fila de pacientes está cheia!");
            }
        }

        static void AtenderPaciente()
        {
            if (inicio < fim)
            {
                Paciente atendido = filaPacientes[inicio];
                for (int i = inicio; i < fim - 1; i++)
                {
                    filaPacientes[i] = filaPacientes[i + 1];
                }
                fim--;
                Console.WriteLine($"Paciente {atendido.Nome} atendido com sucesso!");
            }
            else
            {
                Console.WriteLine("Não há pacientes na fila!");
            }
        }

        static Paciente EncontrarPaciente(string nome)
        {
            foreach (var paciente in filaPacientes)
            {
                if (paciente != null && paciente.Nome == nome)
                {
                    return paciente;
                }
            }
            return null;
        }
    }

    class Paciente
    {
        public string Nome { get; set; }

        public Paciente(string nome)
        {
            Nome = nome;
        }
    }
}
