using System;

namespace DIO_Console
{
    class Program
    {
        static void Main(string[] args)
        {   
          
        string opcao;
        Aluno[] alunos = new Aluno[5];
        int indice = 0;
       
        do
           {
                ShowMenu();

                opcao = Console.ReadLine();


                switch (opcao)
                {
                    case "1":
                        
                        Console.Clear();

                        var aluno = new Aluno();

                        Console.Write("Informe o nome do aluno: ");    
                        aluno.Nome = Console.ReadLine();

                        Console.Write("Informe a nota do aluno: ");
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }else{
                            throw new ArgumentException("O valor da nota deve ser numérico.");
                        }

                        
                        alunos[indice] = aluno;
                        indice++;


                        break;
                    case "2":
                        
                        Console.Clear();
                        foreach(var alun in alunos){

                            if(!string.IsNullOrEmpty(alun.Nome))
                            {
                                Console.WriteLine("\nNome: " + alun.Nome + " / Nota: " + alun.Nota);                       
                            }

                        }
                        Console.WriteLine("\n Pressione Enter para continuar.");
                        Console.ReadLine();
    
                        break;
                    case "3":
                       
                        decimal notaTotal = 0;
                        var numeroAlunos = 0;

                        Console.Clear();

                        for(int i=0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal += alunos[i].Nota;
                                numeroAlunos++;
                            }

                        }

                        var mediaGeral = (notaTotal / numeroAlunos);
                        
                        ConceitoEnum conceitoGeral = 0;

                        if(mediaGeral <= 2)
                        {
                            conceitoGeral = ConceitoEnum.E;
                        }else if(mediaGeral > 2 && mediaGeral <= 4)
                        {
                            conceitoGeral = ConceitoEnum.D;
                        }
                        else if(mediaGeral > 4 && mediaGeral <= 6)
                        {
                            conceitoGeral = ConceitoEnum.C;
                        
                        }else if(mediaGeral > 6 && mediaGeral <= 8)
                        {
                            conceitoGeral = ConceitoEnum.B;
                        
                        }else if(mediaGeral > 8 )
                        {
                            conceitoGeral = ConceitoEnum.A;
                        }

                        
                        
                        Console.Write($"A média geral dos alunos é de : {mediaGeral}");
                        Console.Write($"\nConceito geral: {conceitoGeral}");
                       
                        Console.WriteLine("\n Pressione Enter para continuar.");
                        Console.ReadLine();

                        break;
                        
                    case "X" or "x":
                        Console.Clear();
                        Console.Write("Finalizando programa.");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Valor informado além do esperado!");
      
                }


            } while (opcao.ToUpper() != "X");
           




        }

        private static void ShowMenu()
        {
            Console.Clear();

            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Inserir um novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair do programa");
            Console.WriteLine("");
        }
    }
}
