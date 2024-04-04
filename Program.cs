using System;

namespace Gestao_de_Alunos
{
    // Estrutura de dados para representar um Aluno
    public class sAluno
    {
        public string codAlu; // c�digo do aluno (string)
        public string nomAlu; // nome do aluno (string)
        public int idaAlu; // idade do aluno (int)
        public float medAlu; // m�dia de notas do aluno (float)
        public float proAlu; // propina do aluno (float)
        public float salAlu; // saldo do aluno (float)

        // Estrutura de dados para representar o estado e valor da divida mensal
        public struct EstadoMensal
        {
            public int mes; // Identificador do m�s
            public bool estadoPagamento; // true - pago; false - n�o pago
            public float valorDivida; // Valor da divida mensal
        }

        public EstadoMensal[] mesesParaPagar; // Array de meses para Pagar

        public bool teveDividas; // aluno teve d�vidas?

        // Construtor para inicializar um objeto sAluno
        public sAluno()
        {
            codAlu = "";
            nomAlu = "";
            idaAlu = 0;
            medAlu = 0.0f;
            proAlu = 0.0f;
            salAlu = 0.0f;
            mesesParaPagar = new EstadoMensal[12];
            teveDividas = false;

            // Inicializa todos os meses com estado pago e valor da d�vida zero
            for (int i = 0; i < mesesParaPagar.Length; i++)
            {
                mesesParaPagar[i].mes = i + 1;
                mesesParaPagar[i].estadoPagamento = true;
                mesesParaPagar[i].valorDivida = proAlu;
            }
        }

        // M�todo para verificar se h� uma d�vida no pr�ximo m�s
        public bool DividaProxima(int mesAtual)
        {
            int proximoMes = mesAtual + 1;

            // Verifica se o pr�ximo m�s existe na lista de mesesParaPagar
            if (proximoMes < mesesParaPagar.Length)
            {
                // Verifica se o estado de pagamento do pr�ximo m�s � falso (ou seja, h� uma d�vida)
                if (!mesesParaPagar[proximoMes].estadoPagamento)
                {
                    return true; // H� uma d�vida no pr�ximo m�s
                }
            }

            return false; // N�o h� d�vida no pr�ximo m�s
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            sAluno[] sAlu = new sAluno[0]; // Array para armazenar os alunos
            int opcaoMenu = 0; // Op��o do menu

            // Loop do menu
            do
            {
                opcaoMenu = ListaMenu(); // Chama a fun��o para exibir o menu e recebe a op��o escolhida

                switch (opcaoMenu)
                {
                    case 1:
                        Console.Clear(); // Limpa a Consola
                        Console.WriteLine("********** Inserir alunos **********");
                        InserirAlunos(ref sAlu); // Chama a fun��o para inserir alunos
                        break;

                    case 2:
                        Console.Clear(); // Limpa a Consola
                        Console.WriteLine("********** Listar alunos **********");
                        MostrarAlunos(sAlu, 0); // Chama a fun��o para listar alunos
                        break;

                    case 3:
                        Console.Clear(); // Limpa a Consola
                        Console.WriteLine("********** Consultar Aluno **********");
                        ConsultarAluno(sAlu); // Chama a fun��o para consultar um aluno
                        break;

                    case 4:
                        Console.Clear(); // Limpa a Consola
                        Console.WriteLine("********** Alterar dados de Aluno **********");
                        AlterarDadosAluno(sAlu); // Chama a fun��o para alterar os dados de um aluno
                        break;

                    case 5:
                        Console.Clear(); // Limpa a Consola
                        Console.WriteLine("********** Eliminar Aluno **********");
                        EliminarAluno(ref sAlu); // Chama a fun��o para eliminar um aluno
                        break;

                    case 6:
                        Console.Clear(); // Limpa a Consola
                        Console.WriteLine("********** Pagar Propinas **********");
                        PagarPropinas(sAlu); // Chama a fun��o para pagar propinas
                        break;

                    case 7:
                        Console.Clear(); // Limpa a Consola
                        Console.WriteLine("********** Alunos que j� tiveram d�vidas **********");
                        AlunosComDividas(sAlu); // Chama a fun��o para listar os alunos que j� tiveram d�vidas
                        break;

                    case 8:
                        Console.Clear(); // Limpa a Consola
                        Console.WriteLine("********** Verificar d�vidas futuras **********");
                        VerificarDividasFuturas(sAlu, DateTime.Now.Month); // Chama a fun��o para verificar as d�vidas futuras
                        break;

                    case 9:
                        Console.Clear(); // Limpa a Consola
                        Console.WriteLine("********** Carregar Saldo **********");
                        CarregarSaldo(sAlu); // Chama a fun��o para carregar saldo de um aluno
                        break;

                    case 10:
                        Console.Clear(); // Limpa a Consola
                        Console.WriteLine("********** Melhor / Pior Aluno **********");
                        MelhorPiorAluno(sAlu); // Chama a fun��o para carregar saldo de um aluno
                        break;

                    case 11:
                        Console.Clear(); // Limpa a Consola
                        AlunoSemDividas(sAlu);
                        break;

                    case 12:
                        Console.Clear(); // Limpa a Consola
                        break;

                    case 13:
                        Console.Clear(); // Limpa a Consola
                        break;

                    case 14:
                        Console.Clear(); // Limpa a Consola
                        ExibirOpcoesEstatisticas(sAlu);
                        break;
                }
            } while (opcaoMenu != 0);
        }

        // Menu de op��es
        static int ListaMenu()
        {
            // Exibe as op��es de menu e retorna a op��o escolhida
            Console.WriteLine("\nGest�o de Alunos");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. Inserir Aluno");
            Console.WriteLine("2. Listar Alunos");
            Console.WriteLine("3. Consultar Aluno");
            Console.WriteLine("4. Alterar dados de Aluno");
            Console.WriteLine("5. Eliminar Aluno");
            Console.WriteLine("6. Pagar Propinas");
            Console.WriteLine("7. Listagem de d�vidas");
            Console.WriteLine("8. Listagem de d�vidas pr�ximas");
            Console.WriteLine("9. Carregar o saldo de um Aluno");
            Console.WriteLine("10. Calcular melhor e pior Aluno sem d�vidas");
            Console.WriteLine("11. Calcular Aluno que nunca teve d�vidas");
            Console.WriteLine("12. Carregar array de Alunos");
            Console.WriteLine("13. Carregar ficheiro com array");
            Console.WriteLine("14. Estatisticas");
            Console.WriteLine("0. Sair");

            Console.Write("Escolhe a op��o: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Insere alunos na estrutura
        // Solicita informa��es do aluno e insere na estrutura sAlu
        static void InserirAlunos(ref sAluno[] sAlu)
        {
            Console.Write("Digite o n�mero de alunos a inserir: ");
            int quantidadeAlunos = Convert.ToInt32(Console.ReadLine());

            int tamanhoAtual = sAlu.Length;
            int newArraySize = tamanhoAtual + quantidadeAlunos;

            // Resize do array para acomodar os novos alunos
            Array.Resize(ref sAlu, newArraySize);

            // Ciclo para introdu��o dos dados dos alunos
            for (int i = tamanhoAtual; i < newArraySize; i++)
            {
                sAlu[i] = new sAluno(); // Inicializa��o do objeto sAluno

                bool codigoValido = false;
                string codigoAluno;

                do
                {
                    Console.Write("\n Insere o c�digo do aluno: ");
                    codigoAluno = Console.ReadLine();

                    // Verifica se o c�digo do aluno j� existe ou n�o
                    codigoValido = !VerificarCodigo(sAlu, codigoAluno);
                    if (!codigoValido)
                        Console.WriteLine("O c�digo do aluno j� existe.");

                } while (!codigoValido);

                sAlu[i].codAlu = codigoAluno;

                Console.Write("Insere o nome: ");
                sAlu[i].nomAlu = Console.ReadLine();

                Console.Write("Insere a idade: ");
                sAlu[i].idaAlu = Convert.ToInt32(Console.ReadLine());

                Console.Write("Insere m�dia: ");
                sAlu[i].medAlu = Convert.ToSingle(Console.ReadLine());

                Console.Write("Insere a propina do aluno: ");
                sAlu[i].proAlu = Convert.ToSingle(Console.ReadLine());

                Console.Write("Insere o saldo: ");
                sAlu[i].salAlu = Convert.ToSingle(Console.ReadLine());

                // Se o aluno tem um saldo negativo, teveDividas = true
                if (sAlu[i].salAlu < 0)
                    sAlu[i].teveDividas = true;

                // Inicialize o array de d�vidas para cada aluno
                for (int j = 0; j < sAlu[i].mesesParaPagar.Length; j++)
                {
                    bool entradaValida; // Flag que verifica se a op��o introduzida � valida
                    string entrada; // Declara a vari�vel de entrada fora do loop

                    // Ciclo para definir o estado das d�vidas
                    do
                    {
                        Console.Write($"O aluno pagou o m�s {sAlu[i].mesesParaPagar[j].mes}? (S/N) - ");
                        entrada = Console.ReadLine().ToLower(); // L� a entrada e converte para min�sculas

                        if (entrada == "s")
                        {
                            sAlu[i].mesesParaPagar[j].estadoPagamento = true;
                            entradaValida = true; // Define a flag como true para sair do loop
                        }
                        else if (entrada == "n")
                        {
                            sAlu[i].mesesParaPagar[j].estadoPagamento = false;

                            // Se o aluno n�o pagou o m�s anterior ao atual
                            if (sAlu[i].mesesParaPagar[j].mes < DateTime.Now.Month)
                                sAlu[i].teveDividas = true;

                            entradaValida = true; // Define a flag como true para sair do loop
                        }
                        else
                        {
                            Console.WriteLine("Entrada inv�lida. Por favor, insira 'S' ou 'N'.");
                            entradaValida = false; // Define a flag como false para continuar do loop
                        }
                    } while (!entradaValida);
                }
            }
        }

        // Verifica se o c�digo do aluno j� existe na estrutura sAlu
        static bool VerificarCodigo(sAluno[] col, string codigoAlu)
        {
            foreach (var aluno in col)
            {
                if (aluno != null && codigoAlu == aluno.codAlu)
                    return true;
            }
            return false;
        }

        // Mostra informa��es de todos os alunos na estrutura sAlu
        static void MostrarAlunos(sAluno[] sAlu, int flag)
        {
            if (sAlu.Length > 0)
            {
                for (int i = 0; i < sAlu.Length; i++)
                    MostrarInformacaoAluno(sAlu[i], ref flag);
            }
            else
                Console.WriteLine("N�o existe nenhum aluno na lista.");
        }

        // Mostra informa��es detalhadas de um aluno
        static void MostrarInformacaoAluno(sAluno reg, ref int flag)
        {
            // flag = 0 (consulta de baixo nivel no aluno)
            if (flag == 0)
            {
                Console.WriteLine(
                $"C�d: {reg.codAlu} " +
                $"Nome: {reg.nomAlu} " +
                $"Idade: {reg.idaAlu} anos " +
                $"M�dia de Notas: {reg.medAlu} valores"
                );
            }
            else if (flag == 1)
            {
                // flag = 1 (consulta de alto n�vel no aluno)
                Console.WriteLine(
                    $"C�d: {reg.codAlu} " +
                    $"Nome: {reg.nomAlu} " +
                    $"Idade: {reg.idaAlu} anos " +
                    $"M�dia de Notas: {reg.medAlu} valores " +
                    $"Propina: {reg.proAlu} euro(s) " +
                    $"Saldo: {reg.salAlu} euro(s) "
                    );

                Console.WriteLine("Propinas - M�s:");
                for (int i = 0; i < reg.mesesParaPagar.Length; i++)
                {
                    // Representa��o visual do estado do Pagamento
                    string estadoDoPagamento;

                    // Se o valor presente no estadoPagamento for TRUE
                    if (reg.mesesParaPagar[i].estadoPagamento)
                        estadoDoPagamento = "Pago";
                    else
                        estadoDoPagamento = "N�o Pago";

                    // Apenas para dizer qual � o m�s atual
                    if (i + 1 == DateTime.Now.Month)
                        Console.WriteLine($"M�s {reg.mesesParaPagar[i].mes} (m�s atual): {estadoDoPagamento}");
                    else
                        Console.WriteLine($"M�s {reg.mesesParaPagar[i].mes}: {estadoDoPagamento}");
                }
            }
            else
            {
                Console.WriteLine("Valor da Flag inv�lida.");
                return;
            }
        }

        // Consulta informa��es de um aluno espec�fico
        static void ConsultarAluno(sAluno[] sAlu)
        {
            string codigoAluno;

            // Verifica se h� alunos na lista
            if (sAlu.Length > 0)
            {
                MostrarAlunos(sAlu, 0); // Mostra a lista de alunos dispon�veis

                Console.Write("Qual o c�digo do aluno que quer consultar? - ");
                codigoAluno = Console.ReadLine();

                bool encontrouAluno = false;
                int flag = 1; // Define a flag para mostrar a informa��o detalhada do aluno

                // Itera sobre todos os alunos
                foreach (var aluno in sAlu)
                {
                    // Verifica se o aluno atual corresponde ao c�digo fornecido pelo utilizador
                    if (aluno.codAlu == codigoAluno)
                    {
                        MostrarInformacaoAluno(aluno, ref flag); // Mostra as informa��es detalhadas do aluno
                        encontrouAluno = true;
                        break;
                    }
                }

                // Se o aluno n�o foi encontrado, informa o utilizador
                if (!encontrouAluno)
                    Console.WriteLine($"O aluno com o c�digo {codigoAluno} n�o foi encontrado.");
            }
            else
                Console.WriteLine("\n N�o existem alunos na lista. \n"); // Mensagem exibida se n�o houver alunos na lista
        }

        // Altera dados de um aluno espec�fico
        static void AlterarDadosAluno(sAluno[] sAlu)
        {
            // Verifica se h� alunos na lista
            if (sAlu.Length > 0)
            {
                string codigoAluno;
                bool encontrouAluno = false;

                // Mostra os alunos para que o utilizador possa escolher qual alterar
                MostrarAlunos(sAlu, 0);

                Console.WriteLine("Qual o c�digo do aluno que quer alterar?");
                codigoAluno = Console.ReadLine();

                // Itera sobre todos os alunos
                for (int i = 0; i < sAlu.Length; i++)
                {
                    // Verifica se o aluno atual corresponde ao c�digo fornecido pelo utilizador
                    if (sAlu[i].codAlu == codigoAluno)
                    {
                        // Solicita ao utilizador que insira os novos dados do aluno
                        Console.Write("Insere o nome: ");
                        sAlu[i].nomAlu = Console.ReadLine();

                        Console.Write("Insere a idade: ");
                        sAlu[i].idaAlu = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Insere m�dia: ");
                        sAlu[i].medAlu = Convert.ToSingle(Console.ReadLine());

                        Console.Write("Insere a propina do aluno: ");
                        sAlu[i].proAlu = Convert.ToSingle(Console.ReadLine());

                        Console.Write("Insere o saldo: ");
                        sAlu[i].salAlu = Convert.ToSingle(Console.ReadLine());

                        // Verifica se o saldo do aluno � negativo (indicando d�vidas)
                        if (sAlu[i].salAlu < 0)
                            sAlu[i].teveDividas = true;

                        encontrouAluno = true;
                        break;
                    }
                }

                // Se o aluno n�o foi encontrado, informa o utilizador
                if (!encontrouAluno)
                    Console.WriteLine($"O aluno com o c�digo {codigoAluno} n�o foi encontrado.");
            }
            else
                Console.WriteLine("N�o existem alunos na lista.");
        }

        // Elimina um aluno da estrutura sAlu
        static void EliminarAluno(ref sAluno[] sAlu)
        {
            // Verifica se h� alunos na lista
            if (sAlu.Length > 0)
            {
                string codigoAluno;
                bool encontrouAluno = false;
                int indexToRemove;

                // Mostra os alunos para que o utilizador possa escolher qual remover
                MostrarAlunos(sAlu, 1);

                // Solicita o c�digo do aluno que o utilizador deseja remover
                Console.WriteLine("Qual o c�digo do aluno que deseja eliminar?");
                codigoAluno = Console.ReadLine();

                // Itera sobre todos os alunos na lista
                for (int i = 0; i < sAlu.Length; i++)
                {
                    // Verifica se o c�digo do aluno atual corresponde ao c�digo fornecido pelo utilizador
                    if (sAlu[i].codAlu == codigoAluno)
                    {
                        // Confirma��o da remo��o com o utilizador
                        Console.Write($"Pretende eliminar o aluno {codigoAluno}? (s/n): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            indexToRemove = i;

                            // Move os elementos para preencher o espa�o do aluno removido
                            for (int j = indexToRemove; j < sAlu.Length - 1; j++)
                            {
                                sAlu[j] = sAlu[j + 1];
                            }
                            Array.Resize(ref sAlu, sAlu.Length - 1);

                            Console.WriteLine($"O aluno com o c�digo {codigoAluno} foi eliminado.");

                            encontrouAluno = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Registo n�o eliminado.");
                            return; // Se o utilizador n�o quer eliminar a fun��o, sai dela.
                        }
                    }
                }

                // Se o aluno n�o foi encontrado na lista
                if (!encontrouAluno)
                {
                    Console.WriteLine($"O aluno com o c�digo {codigoAluno} n�o foi encontrado.");
                    return; // Sai da fun��o
                }
            }
            else
                Console.WriteLine("\n N�o existem alunos na lista. \n");
        }

        // Paga as propinas de um aluno ou de todos os alunos
        static void PagarPropinas(sAluno[] sAlu)
        {
            // Verifica se h� alunos na lista
            if (sAlu.Length > 0)
            {
                Console.WriteLine("Deseja pagar as propinas de todos os alunos? S/N");
                string resposta = Console.ReadLine().ToLower();

                // Se o utilizador optar por pagar as propinas de todos os alunos
                if (resposta == "s")
                {
                    // Itera sobre todos os alunos
                    for (int i = 0; i < sAlu.Length; i++)
                    {
                        // Itera sobre todos os meses de propinas do aluno atual
                        for (int j = 0; i < sAlu[i].mesesParaPagar[j].mes; j++)
                        {
                            // Verifica se o m�s atual n�o est� pago
                            if (sAlu[i].mesesParaPagar[j + 1].estadoPagamento == false)
                            {
                                // Marca o m�s atual como pago
                                sAlu[i].mesesParaPagar[j + 1].estadoPagamento = true;
                            }
                        }

                        // Informa que todas as propinas do aluno atual foram pagas
                        Console.WriteLine($"As propinas de todos os meses do aluno {sAlu[i].nomAlu} (Cod:{sAlu[i].codAlu}) j� est�o pagas.");
                    }
                }
                // Se o utilizador optar por pagar as propinas de um aluno espec�fico
                else
                {
                    // Mostra os alunos para que o utilizador possa escolher qual pagar as propinas
                    MostrarAlunos(sAlu, 0);

                    Console.Write("Qual � o c�digo de aluno que pretende pagar as propinas? - ");
                    string alunoPagarPropinas = Console.ReadLine();

                    // Itera sobre todos os alunos
                    for (int i = 0; i < sAlu.Length; i++)
                    {
                        // Verifica se o aluno atual corresponde ao c�digo fornecido pelo utilizador
                        if (sAlu[i].codAlu == alunoPagarPropinas)
                        {
                            // Mostra as op��es de pagamento de propinas
                            Console.WriteLine("1. Pagar as propinas do m�s corrente.");
                            Console.WriteLine("2. Pagar as propinas de outro m�s que n�o seja o m�s corrente.");
                            Console.WriteLine($"3. Pagar todas as propinas do aluno {sAlu[i].nomAlu}. \n");

                            // Recebe a escolha do utilizador
                            int escolha = Convert.ToInt32(Console.ReadLine());

                            switch (escolha)
                            {
                                case 1:
                                    // Verifica se as propinas do m�s corrente n�o foram pagas
                                    if (sAlu[i].mesesParaPagar[DateTime.Now.Month - 1].estadoPagamento == false)
                                    {
                                        // Marca as propinas do m�s corrente como pagas
                                        sAlu[i].mesesParaPagar[DateTime.Now.Month - 1].estadoPagamento = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"As propinas do m�s atual para o aluno {sAlu[i].codAlu} j� est�o pagas.");
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("Escreva o n�mero do m�s que quer pagar: ");
                                    int mesEscolhido = Convert.ToInt32(Console.ReadLine());

                                    // Verifica se as propinas do m�s escolhido n�o foram pagas
                                    if (sAlu[i].mesesParaPagar[mesEscolhido - 1].estadoPagamento == false)
                                    {
                                        // Marca as propinas do m�s escolhido como pagas
                                        sAlu[i].mesesParaPagar[mesEscolhido - 1].estadoPagamento = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"As propinas do m�s {mesEscolhido} para o aluno {sAlu[i].codAlu} j� est�o pagas.");
                                    }
                                    break;

                                case 3:
                                    // Itera sobre todos os meses de propinas do aluno atual
                                    for (int j = 0; j < sAlu[i].mesesParaPagar.Length; j++)
                                    {
                                        // Verifica se as propinas do m�s atual n�o foram pagas
                                        if (sAlu[i].mesesParaPagar[j].estadoPagamento == false)
                                        {
                                            // Marca as propinas do m�s atual como pagas
                                            sAlu[i].mesesParaPagar[j].estadoPagamento = true;
                                        }
                                    }
                                    Console.WriteLine($"As propinas do aluno {sAlu[i].codAlu} j� est�o pagas.");
                                    break;

                                default:
                                    Console.WriteLine("Op��o Inv�lida");
                                    break;
                            }
                        }
                    }
                }
            }
            else
                Console.WriteLine("N�o existem alunos na lista.");
        }

        // Mostra alunos com dividas e alunos que j� tiveram dividas!
        static void AlunosComDividas(sAluno[] sAlu)
        {
            bool existiuDividas = false;

            // Iterar sobre todos os alunos 
            for (int i = 0; i < sAlu.Length; i++)
            {
                bool temDividas = false;
                int mesesEmAtraso = 0;
                float valorTotalDivida = 0;

                // Iterar sobre os meses para pagar
                for (int j = 0; j < sAlu[i].mesesParaPagar.Length; j++)
                {
                    // Verificar se o pagamento do m�s n�o foi feito
                    if (!sAlu[i].mesesParaPagar[j].estadoPagamento)
                    {
                        temDividas = true;
                        mesesEmAtraso++;
                        valorTotalDivida = valorTotalDivida + sAlu[i].mesesParaPagar[j].valorDivida;
                    }
                }

                // Verificar se o aluno teve d�vidas
                if (temDividas)
                {
                    Console.WriteLine($"O aluno {sAlu[i].nomAlu} ({sAlu[i].codAlu}) tem {mesesEmAtraso} m�s/meses em atraso com um total de {valorTotalDivida} euros.");
                }
                else if (sAlu[i].teveDividas)
                {
                    Console.WriteLine($"O aluno {sAlu[i].nomAlu} ({sAlu[i].codAlu}) j� teve d�vidas, mas est� em dia agora.");
                }
            }

            if (!existiuDividas)
                Console.WriteLine($"Nenhum aluno teve dividas.");
        }

        // Verifica se os alunos t�m d�vidas futuras no pr�ximo m�s
        static void VerificarDividasFuturas(sAluno[] sAlu, int mesAtual)
        {
            Console.WriteLine("D�vidas futuras:");

            // Iterar sobre todos os alunos
            for (int i = 0; i < sAlu.Length; i++)
            {
                // Verificar se o aluno tem uma d�vida no pr�ximo m�s
                if (sAlu[i].DividaProxima(mesAtual))
                    Console.WriteLine($"Aluno {sAlu[i].nomAlu} ({sAlu[i].codAlu}) tem uma d�vida no pr�ximo m�s.");
                else
                    Console.WriteLine($"Aluno {sAlu[i].nomAlu} ({sAlu[i].codAlu}) n�o tem uma d�vida no pr�ximo m�s.");
            }
        }

        // Carrega saldo para um aluno espec�fico
        static void CarregarSaldo(sAluno[] sAlu)
        {
            // Vari�veis para armazenar o c�digo do aluno e o valor a ser carregado
            string codAluno;
            int valor;

            // Solicita o c�digo do aluno que deseja carregar o saldo
            Console.Write("Qual � o aluno que quer carregar o saldo? - ");
            codAluno = Console.ReadLine();

            // Itera sobre todos os alunos na lista
            for (int i = 0; i < sAlu.Length; i++)
            {
                // Verifica se o c�digo do aluno atual corresponde ao c�digo fornecido
                if (sAlu[i].codAlu == codAluno)
                {
                    // Solicita o valor a ser carregado para o saldo do aluno
                    Console.Write("Qual � o montante que quer carregar o saldo? - ");
                    valor = Convert.ToInt32(Console.ReadLine());

                    // Adiciona o valor ao saldo do aluno correspondente
                    sAlu[i].salAlu = sAlu[i].salAlu + valor;

                    // Exibe mensagem de confirma��o do carregamento do saldo
                    Console.WriteLine("O saldo foi carregado.");
                }
            }
        }

        // Mostra qual � o melhor e o pior aluno sem dividas
        static void MelhorPiorAluno(sAluno[] sAlu)
        {
            // Indices para saber as posi��es dos alunos
            int indicePiorAluno = 0;
            int indiceMelhorAluno = 0;

            // Assume a melhor e a pior m�dia pelo primeiro aluno da lista
            float melhorMedia = sAlu[0].medAlu;
            float piorMedia = sAlu[0].medAlu;

            // Ciclo para encontrar o melhor e o pior aluno
            for (int i = 0; i < sAlu.Length; i++)
            {
                // Verifica se a m�dia do aluno atual � maior que a do melhor aluno
                if (sAlu[i].medAlu > melhorMedia)
                {
                    melhorMedia = sAlu[i].medAlu;
                    indiceMelhorAluno = i;
                }
                // Verifica se a m�dia do aluno atual � menor que a do pior aluno
                else if (sAlu[i].medAlu < piorMedia)
                {
                    piorMedia = sAlu[i].medAlu;
                    indicePiorAluno = i;
                }
            }

            // Exibe o melhor e pior aluno
            Console.WriteLine($"Melhor aluno: {sAlu[indiceMelhorAluno].nomAlu}, M�dia: {melhorMedia}");
            Console.WriteLine($"Pior aluno: {sAlu[indicePiorAluno].nomAlu}, M�dia: {piorMedia}");
        }

        // Exibe os alunos que nunca tiveram d�vidas
        static void AlunoSemDividas(sAluno[] sAlu)
        {
            // Itera sobre todos os alunos
            for (int i = 0; i < sAlu.Length; i++)
            {
                // Verifica se o aluno n�o teve d�vidas
                if (!sAlu[i].teveDividas)
                {
                    // Mostra as informa��es do aluno
                    MostrarAlunos(sAlu, 0);
                }
            }
        }

        // Fun��o para exibir op��es de estat�sticas
        static void ExibirOpcoesEstatisticas(sAluno[] sAlu)
        {
            Console.WriteLine("\nOp��es Estat�sticas:");
            Console.WriteLine("1. M�dia das idades dos alunos");
            Console.WriteLine("2. M�dia das m�dias dos alunos");
            Console.WriteLine("3. N�mero de alunos com saldo negativo");
            Console.WriteLine("4. Percentagem de alunos com d�vidas");
            Console.WriteLine("5. Todas\n");

            Console.Write("Escolha uma op��o: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CalcularMediaIdades(sAlu);
                    break;

                case 2:
                    CalcularMediaMedias(sAlu);
                    break;

                case 3:
                    ContarAlunosComSaldoNegativo(sAlu);
                    break;

                case 4:
                    CalcularPercentagemAlunosComDividas(sAlu);
                    break;

                case 5:
                    CalcularMediaIdades(sAlu);
                    CalcularMediaMedias(sAlu);
                    ContarAlunosComSaldoNegativo(sAlu);
                    CalcularPercentagemAlunosComDividas(sAlu);
                    break;

                default:
                    Console.WriteLine("Op��o inv�lida.");
                    break;
            }
        }

        // Calcula a m�dia das idades dos alunos
        static void CalcularMediaIdades(sAluno[] sAlu)
        {
            // Verifica se h� alunos na lista
            if (sAlu.Length > 0)
            {
                int somaIdades = 0;

                // Itera sobre cada aluno na lista
                foreach (var aluno in sAlu)
                {
                    // Soma as idades de todos os alunos
                    somaIdades += aluno.idaAlu;
                }
                // Calcula a m�dia das idades 
                Console.WriteLine($"A m�dia das idades dos alunos �: {somaIdades / sAlu.Length}");
            }
            else
            {
                Console.WriteLine("N�o existem alunos na lista.");
            }
        }

        // Calcula a m�dia das m�dias dos alunos
        static void CalcularMediaMedias(sAluno[] sAlu)
        {
            // Verifica se h� alunos na lista
            if (sAlu.Length > 0)
            {
                float somaMedias = 0;

                // Itera sobre cada aluno na lista
                foreach (var aluno in sAlu)
                {
                    // Soma as m�dias de todos os alunos
                    somaMedias += aluno.medAlu;
                }
                // Calcula a m�dia das m�dias
                Console.WriteLine($"A m�dia das m�dias dos alunos �: {somaMedias / sAlu.Length}");
            }
            else
            {
                Console.WriteLine("N�o existem alunos na lista.");
            }
        }

        // Conta quantos alunos t�m saldo negativo
        static void ContarAlunosComSaldoNegativo(sAluno[] sAlu)
        {
            // Verifica se h� alunos na lista
            if (sAlu.Length > 0)
            {
                int contador = 0;

                // Itera sobre cada aluno na lista
                foreach (var aluno in sAlu)
                {
                    // Verifica se o saldo do aluno � negativo e incrementa o contador
                    if (aluno.salAlu < 0)
                    {
                        contador++;
                    }
                }

                // N�mero de alunos com saldo negativo
                Console.WriteLine($"O n�mero de alunos com saldo negativo �: {contador}");
            }
            else
            {
                Console.WriteLine("N�o existem alunos na lista.");
            }
        }

        // Calcula a percentagem de alunos que j� tiveram d�vidas
        static void CalcularPercentagemAlunosComDividas(sAluno[] sAlu)
        {
            // Verifica se h� alunos na lista
            if (sAlu.Length > 0)
            {

                int alunosComDividas = 0;

                // Itera sobre cada aluno na lista
                foreach (var aluno in sAlu)
                {
                    // Verifica se o aluno j� teve d�vidas e incrementa o contador
                    if (aluno.teveDividas)
                    {
                        alunosComDividas++;
                    }
                }
                // Calcula a percentagem de alunos com d�vidas
                float percentagemAlunosDividas = (float)alunosComDividas / sAlu.Length * 100;
                Console.WriteLine($"A percentagem de alunos com d�vidas �: {percentagemAlunosDividas:F2}%");
            }
            else
            {
                Console.WriteLine("N�o existem alunos na lista."); // teste
            }
        }

    }
}