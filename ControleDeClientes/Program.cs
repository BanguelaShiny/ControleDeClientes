using System.ComponentModel.Design;

namespace ControleClientes;

class Program
{
    static List<Cliente> ListaClientes = new List<Cliente>();
    static void Main(string[] args)
    {
        bool executar = true;
        while (executar)
        {
            Console.WriteLine($"Selecione uma opção:");
            Console.WriteLine("Adicionar Cliente - 1");
            Console.WriteLine("Vizualizar Clientes - 2");
            Console.WriteLine("Editar Cliente - 3");
            Console.WriteLine("Excluir Cliente - 4");
            Console.WriteLine("Sair - 5");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    AdicionarCliente();
                    break;
                case 2:
                    VizualizarClientes();
                    break;
                case 3:
                    EditarCliente();
                    break;
                case 4:
                    ExcluirCliente();
                    break;
                case 5:
                    executar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

    }
    static void AdicionarCliente()
    {
        Console.Clear();
        Console.Write("Digite o nome do cliente: ");
        string nome = Console.ReadLine()!;
        Console.Write($"Digite o e-mail de {nome}: ");
        string email = Console.ReadLine()!;
        
        Cliente cliente = new Cliente(nome, email);
        Console.WriteLine("Cliente adicionado com sucesso.");
        ListaClientes.Add(cliente);
        Thread.Sleep(2000);
        Console.Clear();
    }
    static void VizualizarClientes()
    {
        if (ListaClientes.Count == 0)
        {
            Console.WriteLine("Nenhum cliente cadastrado.");
        }
        else
        {
            Console.Clear();
            foreach (Cliente cliente in ListaClientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"E-mail: {cliente.Email}");
                Console.WriteLine("------------------------------------------");
            }
        }
        Console.ReadKey();
        Console.Clear();
    }
    static void EditarCliente()
    {
        Console.Clear();
        Console.Write("Digite o nome do cliente que deseja editar: ");
        string nome = Console.ReadLine()!;
        Cliente cliente = ListaClientes.Find(c=>c.Nome == nome);
        if(cliente == null )
        {
            Console.WriteLine($"Cliente {nome} não encontrado.");
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"O que deseja alterar em {nome}?");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Alterar Nome - 1");
            Console.WriteLine("Alterar E-mail - 2");
            Console.WriteLine("Alterar Nome e E-mail - 3");
            Console.Write("Digite a opção desejada: ");
            int opcao = int.Parse(Console.ReadLine()!);
            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Alterando nome");
                    Console.Write("Digite o novo nome do cliente: ");
                    string novoNome = Console.ReadLine()!;
                    cliente.Nome = novoNome;
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Alterando e-mail");
                    Console.Write("Digite o novo e-mail do cliente: ");
                    string novoEmail = Console.ReadLine()!;
                    cliente.Email = novoEmail;
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Alterando nome e e-mail");
                    Console.Write("Digite o novo nome do cliente: ");
                    string nomeNovo = Console.ReadLine()!;
                    cliente.Nome = nomeNovo;
                    Console.Write("Digite o novo e-mail do cliente: ");
                    string emailNovo = Console.ReadLine()!;
                    cliente.Email = emailNovo;
                    break;
            }
            Console.WriteLine($"Dados do cliente alterados com sucesso.");
        }
        Thread.Sleep(1000);
        Console.Clear();
    }
    static void ExcluirCliente()
    {
        Console.Clear();
        Console.Write("Digite o nome do cliente que deseja excluir.");
        string nome = Console.ReadLine()!;

        Cliente cliente = ListaClientes.Find(c=>c.Nome == nome);
        if(cliente == null)
        {
            Console.WriteLine($"Cliente {nome} não encontrado.");
        }
        else
        {
            ListaClientes.Remove(cliente);
            Console.WriteLine($"Cliente {nome} removido com sucesso.");
        }
        Thread.Sleep(1000);
        Console.Clear();
    }
}
    class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

    }