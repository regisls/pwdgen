using System;
using System.Collections.Generic;

namespace Testes
{
    class Program
    {
        static void Main(string[] args)
        {

            Parametros par = Program.getParametros(args);

            if (par.quantidadeSenhas < 1 || par.tamanhoSenhas < 1)
            {
                Program.Help();
            }

            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numeros = "0123456789";
            string simbolos = "_-=+$%@#![{(]})";

            string senha = string.Empty;

            Random r = new Random();

            for (int cont = 0; cont < par.quantidadeSenhas; cont++)
            {
                senha = string.Empty;

                for (int i = 0; i < par.tamanhoSenhas; i++)
                {
                    int tipo = r.Next(0, 3);
                    switch (tipo)
                    {
                        case 0:
                            senha += caracteres[r.Next(0, 46)];
                            break;
                        case 1:
                            senha += numeros[r.Next(0, 10)];
                            break;
                        case 2:
                            senha += simbolos[r.Next(0, 15)];
                            break;
                    }
                }
                Console.WriteLine(senha);
            }

            Console.ReadLine();

        }

        public static Parametros getParametros(string[] args)
        {
            Parametros parametros = new Parametros();

            foreach(string par in args)
            {
                string[] data = par.Split('=');
                switch(data[0])
                {
                    case "-s":
                    case "-size":
                        parametros.tamanhoSenhas = int.Parse(data[1]);
                        break;
                    case "-q":
                    case "-qtd":
                        parametros.quantidadeSenhas = int.Parse(data[1]);
                        break;
                    case "-?":
                    case "-help":
                        Program.Help();
                        break;
                }
            }

            return parametros;
        }

        public static void Help()
        {
            Console.WriteLine("Ajuda do aplicativo de linha de comando pwdgen");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Parametros:");
            Console.WriteLine("  -? ou -help: Exibe esta ajuda");
            Console.WriteLine("  -q ou -qtd: Indica a quantidade de senhas que devem ser geradas.");
            Console.WriteLine("  -s ou -size: Indica o número de caracteres que as senhas devem ter.");
            Console.WriteLine("");
            return;
        }
    }

    public class Parametros
    {
        public int quantidadeSenhas { get; set; }
        public int tamanhoSenhas { get; set; }
    }
}
