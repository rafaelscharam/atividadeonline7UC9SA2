using System;
using System.Collections.Generic;
using System.Threading;

namespace cadastroPessoa
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao;

            List<PessoaFisica> listaPf = new List<PessoaFisica>();
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"+===================================================+");
            Console.WriteLine($"|       Bem vindo ao Sistema de cadastro de         |");
            Console.WriteLine($"|           pessoas Fisica e Juridica               |");
            Console.WriteLine($"+===================================================+");

            Console.ResetColor();
            Thread.Sleep(1000);

            BarraCarregamento("Iniciando");

            Console.Clear();
            Console.ResetColor();


            do
            {

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(@$"
+===================================================+
|                  Escolha uma opção                |
|---------------------------------------------------|
|                PESSOA FÍSICA                      |
|       1 - Pessoa Física                           |
|       2 - Listar Pessoa Física                    |
|       3 - Remover Pessoa Física                   |
|                                                   |
|                PESSOA JURÍDICA                    |
|       4 - Cadastrar Pessoa Jurídica               |
|       5 - Listar Pessoa Jurídica                  |
|       6 - Remover Pessoa Jurídica                 |
|                                                   |
|       0 - Sair                                    |
+===================================================+
");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":

                        Console.ResetColor();

                        PessoaFisica pf = new PessoaFisica();
                        PessoaFisica novaPf = new PessoaFisica();
                        Endereco endPf = new Endereco();

                        Console.WriteLine($"Digite seu logradouro");
                        endPf.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite seu numero");
                        endPf.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite um complemento (aperte ENTER para vazio)");
                        endPf.complemento = Console.ReadLine();

                        Console.WriteLine($"Seu endereço é Comercial? S/N");
                        string endComercial = Console.ReadLine().ToUpper();

                        if (endComercial == "S")
                        {
                            endPf.enderecoComercial = true;
                        }
                        else
                        {
                            endPf.enderecoComercial = false;
                        }


                        novaPf.endereco = endPf;

                        Console.WriteLine($"Digite seu CPF (Somente numeros)");
                        novaPf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite seu Nome completo");
                        novaPf.nome = Console.ReadLine();

                        Console.WriteLine($"Digite seu rendimento mensal (Somente numeros)");
                        novaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite sua Data de Nascimento (AAAA-MM-DD)");
                        novaPf.dataNascimento = DateTime.Parse(Console.ReadLine());

                        bool idadeValida = pf.validarDataNascimento(novaPf.dataNascimento);

                        if (idadeValida == true)
                        {
                            Console.WriteLine($"Cadastro Aprovado!");
                            listaPf.Add(novaPf);
                            Console.WriteLine($"O valor do Desconto do imposto é de: {pf.PagarImposto(novaPf.rendimento).ToString("N2")} reais");
                        }
                        else
                        {
                            Console.WriteLine($"Cadastro Reprovado!");
                        }

                        break;

                    case "2":

                        foreach (var cadaItem in listaPf)
                        {
                            Console.WriteLine($"Nome: {cadaItem.nome}");
                            Console.WriteLine($"CPF: {cadaItem.cpf}");
                            Console.WriteLine($"Logradouro: {cadaItem.endereco.logradouro}");
                            Console.WriteLine($"Numero: {cadaItem.endereco.numero}");
                            Console.WriteLine($"Rendimento: {cadaItem.rendimento}");
                        }

                        break;

                    case "3":

                        Console.WriteLine($"Digite o CPF que deseja remover");
                        string cpfProcurado = Console.ReadLine();

                        PessoaFisica pessoaEncontrada = listaPf.Find(cadaItem => cadaItem.cpf == cpfProcurado);

                        if (pessoaEncontrada != null)
                        {
                            listaPf.Remove(pessoaEncontrada);
                            Console.WriteLine($"Cadastro Removido!");
                        }
                        else
                        {
                            Console.WriteLine($"CPF não encontrado!");

                        }

                        break;

                    case "4":

                        Console.ResetColor();
                        PessoaJuridica pj = new PessoaJuridica();
                        PessoaJuridica novaPj = new PessoaJuridica();
                        Endereco endPj = new Endereco();

                        Console.WriteLine($"Digite seu logradouro");
                        endPj.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite seu numero");
                        endPj.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite seu complemento (aperte ENTER para vazio)");
                        endPj.complemento = Console.ReadLine();

                        Console.WriteLine($"Seu endereço é Comercial? S/N");
                        string endComercialPj = Console.ReadLine().ToUpper();

                        if (endComercialPj == "S")
                        {
                            endPj.enderecoComercial = true;
                        }
                        else
                        {
                            endPj.enderecoComercial = false;
                        }

                        novaPj.endereco = endPj;

                        Console.WriteLine($"Digite seu CNPJ (Somente numeros)");
                        novaPj.cnpj = Console.ReadLine();

                        Console.WriteLine($"Digite sua Razao Social");
                        novaPj.razaoSocial = Console.ReadLine();

                        Console.WriteLine($"Digite seu rendimento mensal (Somente numeros)");
                        novaPj.rendimento = float.Parse(Console.ReadLine());


                        if (pj.validarCNPJ(novaPj.cnpj))
                        {
                            Console.WriteLine($"CNPJ Valido!");
                            listaPj.Add(novaPj);
                            Console.WriteLine($"O valor do Desconto do imposto é de: {pj.PagarImposto(novaPj.rendimento).ToString("N2")} reais");

                        }
                        else
                        {
                            Console.WriteLine($"CNPJ Invalido!");
                        }

                        break;

                    case "5":

                        foreach (var cadaItem in listaPj)
                        {
                            Console.WriteLine($"Razao Social: {cadaItem.razaoSocial}");
                            Console.WriteLine($"CNPJ: {cadaItem.cnpj}");
                            Console.WriteLine($"Logradouro: {cadaItem.endereco.logradouro}");
                            Console.WriteLine($"Numero: {cadaItem.endereco.numero}");
                            Console.WriteLine($"Rendimento: {cadaItem.rendimento}");
                        }

                        break;

                    case "6":

                        Console.WriteLine($"Digite o CNPJ que deseja remover");
                        string cnpjProcurado = Console.ReadLine();

                        PessoaJuridica pessoaJEncontrada = listaPj.Find(cadaItem => cadaItem.cnpj == cnpjProcurado);

                        if (pessoaJEncontrada != null)
                        {
                            listaPj.Remove(pessoaJEncontrada);
                            Console.WriteLine($"Cadastro Removido!");
                        }
                        else
                        {
                            Console.WriteLine($"CNPJ não encontrado!");

                        }

                        break;

                    case "0":
                        Console.ResetColor();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Obrigado por utilizar o sistema");

                        BarraCarregamento("Finalizando");

                        Console.ResetColor();
                        break;

                    default:
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"Opção invalida, digite uma opção válida");
                        break;
                }
            } while (opcao != "0");



        }

        static void BarraCarregamento(string textoCarregamento)
        {

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(textoCarregamento);
            Thread.Sleep(300);

            for (var contador = 0; contador < 5; contador++)
            {
                Console.Write($".");
                Thread.Sleep(180);
            }
        }
    }
}