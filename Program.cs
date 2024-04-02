using System;

namespace Gestao_de_Alunos
{
    // Estrutura de dados para representar um Aluno
    public class sAluno
    {
        public string codAlu; // código do aluno (string)
        public string nomAlu; // nome do aluno (string)
        public int idaAlu; // idade do aluno (int)
        public float medAlu; // média de notas do aluno (float)
        public float proAlu; // propina do aluno (float)
        public float salAlu; // saldo do aluno (float)

        // Estrutura de dados para representar o estado e valor da divida mensal
        public struct EstadoMensal
        {
            public int mes; // Identificador do mês
            public bool estadoPagamento; // true - pago; false - não pago
            public float valorDivida; // Valor da divida mensal
        }

        public EstadoMensal[] mesesParaPagar; // Array de meses para Pagar

        public bool teveDividas; // aluno teve dívidas?

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

            // Inicializa todos os meses com estado pago e valor da dívida zero
            for (int i = 0; i < mesesParaPagar.Length; i++)
            {
                mesesParaPagar[i].mes = i + 1;
                mesesParaPagar[i].estadoPagamento = true;
                mesesParaPagar[i].valorDivida = proAlu;
            }
        }

        // Método para verificar se há uma dívida no próximo mês
        public bool DividaProxima(int mesAtual)
        {
            return !mesesParaPagar[mesAtual + 1].estadoPagamento;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            sAluno[] sAlu = new sAluno[0]; // Array para armazenar os alunos
            int opcaoMenu = 0; // Opção do menu

            // Loop do menu
            do
            {
                opcaoMenu = ListaMenu(); // Chama a função para exibir o menu e recebe a opção escolhida

                switch (opcaoMenu)
                {
                    case 1:
                        Console.WriteLine("********** Inserir alunos **********");
                        InserirAlunos(ref sAlu); // Chama a função para inserir alunos
                        break;

                    case 2:
                        Console.WriteLine("********** Listar alunos **********");
                        MostrarAlunos(sAlu); // Chama a função para listar alunos
                        break;

                    case 3:
                        Console.WriteLine("********** Consultar Aluno **********");
                        ConsultarAluno(sAlu); // Chama a função para consultar um aluno
                        break;

                    case 4:
                        Console.WriteLine("********** Alterar dados de Aluno **********");
                        AlterarDadosAluno(sAlu); // Chama a função para alterar os dados de um aluno
                        break;

                    case 5:
                        Console.WriteLine("********** Eliminar Aluno **********");
                        EliminarAluno(ref sAlu); // Chama a função para eliminar um aluno
                        break;

                    case 6:
                        Console.WriteLine("********** Pagar Propinas **********");
                        PagarPropinas(sAlu); // Chama a função para pagar propinas
                        break;

                    case 7:
                        Console.WriteLine("********** Alunos que já tiveram dívidas **********");
                        AlunosComDividas(sAlu); // Chama a função para listar os alunos que já tiveram dívidas
                        break;

                    case 8:
                        Console.WriteLine("********** Verificar dívidas futuras **********");
                        VerificarDividasFuturas(sAlu, DateTime.Now.Month); // Chama a função para verificar as dívidas futuras
                        break;

                    case 9:
                        Console.WriteLine("********** Carregar Saldo **********");
                        CarregarSaldo(sAlu); // Chama a função para carregar saldo de um aluno
                        break;

                    case 10:
                        break;

                    case 11:
                        break;

                    case 12:
                        break;

                    case 13:
                        break;

                    case 14:
                        break;
                }
            } while (opcaoMenu != 0);
        }

        // Menu de opções
        static int ListaMenu()
        {
            // Exibe as opções de menu e retorna a opção escolhida
            Console.WriteLine("Gestão de Alunos");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. Inserir Aluno");
            Console.WriteLine("2. Listar Alunos");
            Console.WriteLine("3. Consultar Aluno");
            Console.WriteLine("4. Alterar dados de Aluno");
            Console.WriteLine("5. Eliminar Aluno");
            Console.WriteLine("6. Pagar Propinas");
            Console.WriteLine("7. Listagem de dívidas");
            Console.WriteLine("8. Listagem de dívidas próximas");
            Console.WriteLine("9. Carregar o saldo de um Aluno");
            Console.WriteLine("10. Calcular melhor e pior Aluno sem dívidas");
            Console.WriteLine("11. Calcular Aluno que nunca teve dívidas");
            Console.WriteLine("12. Carregar array de Alunos");
            Console.WriteLine("13. Carregar ficheiro com array");
            Console.WriteLine("0. Sair");

            Console.Write("Escolhe a opção: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Insere alunos na estrutura
        // Solicita informações do aluno e insere na estrutura sAlu
        static void InserirAlunos(ref sAluno[] sAlu)
        {
            Console.Write("Digite o número de alunos a inserir: ");
            int quantidadeAlunos = Convert.ToInt32(Console.ReadLine());

            int tamanhoAtual = sAlu.Length;
            int newArraySize = tamanhoAtual + quantidadeAlunos;

            // Resize do array para acomodar os novos alunos
            Array.Resize(ref sAlu, newArraySize);

            // Ciclo para introdução dos dados dos alunos
            for (int i = tamanhoAtual; i < newArraySize; i++)
            {
                sAlu[i] = new sAluno(); // Inicialização do objeto sAluno

                bool codigoValido = false;
                string codigoAluno;

                do
                {
                    Console.Write("Insere o código do aluno: ");
                    codigoAluno = Console.ReadLine();

                    // Verifica se o código do aluno já existe ou não
                    codigoValido = !VerificarCodigo(sAlu, codigoAluno);
                    if (!codigoValido)
                        Console.WriteLine("O código do aluno já existe.");

                } while (!codigoValido);

                sAlu[i].codAlu = codigoAluno;

                Console.Write("Insere o nome: ");
                sAlu[i].nomAlu = Console.ReadLine();

                Console.Write("Insere a idade: ");
                sAlu[i].idaAlu = Convert.ToInt32(Console.ReadLine());

                Console.Write("Insere média: ");
                sAlu[i].medAlu = Convert.ToSingle(Console.ReadLine());

                Console.Write("Insere a propina do aluno: ");
                sAlu[i].proAlu = Convert.ToSingle(Console.ReadLine());

                Console.Write("Insere o saldo: ");
                sAlu[i].salAlu = Convert.ToSingle(Console.ReadLine());

                // Se o aluno tem um saldo negativo, teveDividas = true
                if (sAlu[i].salAlu < 0)
                    sAlu[i].teveDividas = true;

                // Inicialize o array de dívidas para cada aluno
                for (int j = 0; j < sAlu[i].mesesParaPagar.Length; j++)
                {
                    // Define o estado das dívidas
                    Console.WriteLine($"O aluno pagou o mês {sAlu[i].mesesParaPagar[j].mes}? S/N");
                    if (Console.ReadLine().ToLower() == "s")
                    { 
                        sAlu[i].mesesParaPagar[j].estadoPagamento = true;
                    }
                    else
                    {
                        sAlu[i].mesesParaPagar[j].estadoPagamento = false;

                        // Se o aluno não pagou o mês anterior ao atual
                        if (sAlu[i].mesesParaPagar[j].mes < DateTime.Now.Month)
                            sAlu[i].teveDividas = true;
                    }
                }
            }
        }

        // Verifica se o código do aluno já existe na estrutura sAlu
        static bool VerificarCodigo(sAluno[] col, string codigoAlu)
        {
            foreach (var aluno in col)
            {
                if (aluno != null && codigoAlu == aluno.codAlu)
                    return true;
            }
            return false;
        }

        // Mostra informações de todos os alunos na estrutura sAlu
        static void MostrarAlunos(sAluno[] sAlu)
        {
            if (sAlu.Length > 0)
            {
                for (int i = 0; i < sAlu.Length; i++)
                    MostrarInformacaoAluno(sAlu[i]);
            }
            else
                Console.WriteLine("Não existe nenhum aluno na lista.");
        }

        // Mostra informações detalhadas de um aluno
        static void MostrarInformacaoAluno(sAluno reg)
        {
            Console.WriteLine($"Cód: {reg.codAlu}");
            Console.WriteLine($"Nome: {reg.nomAlu}");
            Console.WriteLine($"Idade: {reg.idaAlu} anos");
            Console.WriteLine($"Média de Notas: {reg.medAlu} valores");
            Console.WriteLine($"Propina: {reg.proAlu} euro(s)");
            Console.WriteLine($"Saldo: {reg.salAlu} euro(s)");

            Console.WriteLine("Propinas - Mês:");
            for (int i = 0; i < reg.mesesParaPagar.Length; i++)
            {
                // Representação visual do estado do Pagamento
                string estadoDoPagamento;

                // Se o valor presente no estadoPagamento for TRUE
                if (reg.mesesParaPagar[i].estadoPagamento)
                    estadoDoPagamento = "Pago";
                else
                    estadoDoPagamento = "Não Pago";

                // Apenas para dizer qual é o mês atual
                if (i + 1 == DateTime.Now.Month)
                    Console.WriteLine($"Mês {reg.mesesParaPagar[i].mes} (mês atual): {estadoDoPagamento}");
                else
                    Console.WriteLine($"Mês {reg.mesesParaPagar[i].mes}: {estadoDoPagamento}");
            }
            Console.WriteLine("=======================================");
        }

        // Consulta informações de um aluno específico
        static void ConsultarAluno(sAluno[] sAlu)
        {
            int flag = 0;
            string codigoAluno;

            if (sAlu.Length > 0)
            {
                MostrarAlunos(sAlu);

                Console.WriteLine("==========================================");
                Console.WriteLine("Qual o código do aluno que quer consultar?");
                codigoAluno = Console.ReadLine();

                bool encontrouAluno = false;

                foreach (var aluno in sAlu)
                {
                    if (aluno.codAlu == codigoAluno)
                    {
                        MostrarInformacaoAluno(aluno);
                        encontrouAluno = true;
                        break;
                    }
                }

                if (!encontrouAluno)
                    Console.WriteLine($"O aluno com o código {codigoAluno} não foi encontrado.");
            }
            else
                Console.WriteLine("\n Não existem alunos na lista. \n");
        }

        // Altera dados de um aluno específico
        static void AlterarDadosAluno(sAluno[] sAlu)
        {
            if (sAlu.Length > 0)
            {
                string codigoAluno;
                bool encontrouAluno = false;

                MostrarAlunos(sAlu);

                Console.WriteLine("Qual o código do aluno que quer alterar?");
                codigoAluno = Console.ReadLine();

                for (int i = 0; i < sAlu.Length; i++)
                {
                    if (sAlu[i].codAlu == codigoAluno)
                    {
                        Console.Write("Insere o nome: ");
                        sAlu[i].nomAlu = Console.ReadLine();

                        Console.Write("Insere a idade: ");
                        sAlu[i].idaAlu = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Insere média: ");
                        sAlu[i].medAlu = Convert.ToSingle(Console.ReadLine());

                        Console.Write("Insere a propina do aluno: ");
                        sAlu[i].proAlu = Convert.ToSingle(Console.ReadLine());

                        Console.Write("Insere o saldo: ");
                        sAlu[i].salAlu = Convert.ToSingle(Console.ReadLine());

                        if (sAlu[i].salAlu < 0)
                            sAlu[i].teveDividas = true;

                        encontrouAluno = true;
                        break;
                    }
                }

                if (!encontrouAluno)
                    Console.WriteLine($"O aluno com o código {codigoAluno} não foi encontrado.");
            }
            else
                Console.WriteLine("Não existem alunos na lista.");
        }

        // Elimina um aluno da estrutura sAlu
        static void EliminarAluno(ref sAluno[] sAlu)
        {
            if (sAlu.Length > 0)
            {
                string codigoAluno;
                bool encontrouAluno = false;

                MostrarAlunos(sAlu);

                Console.WriteLine("Qual o código do aluno que deseja eliminar?");
                codigoAluno = Console.ReadLine();

                int indexToRemove;
                for (int i = 0; i < sAlu.Length; i++)
                {
                    if (sAlu[i].codAlu == codigoAluno)
                    {
                        Console.Write($"Pretende eliminar o aluno {codigoAluno}? (s/n): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            indexToRemove = i;

                            // Move elements to fill the space of the removed aluno
                            for (int j = indexToRemove; j < sAlu.Length - 1; j++)
                            {
                                sAlu[j] = sAlu[j + 1];
                            }
                            Array.Resize(ref sAlu, sAlu.Length - 1);

                            Console.WriteLine($"O aluno com o código {codigoAluno} foi eliminado.");

                            encontrouAluno = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Registo não eliminado.");
                            return; // If user doesn't want to delete, exit the function
                        }
                    }
                }

                if (!encontrouAluno)
                {
                    Console.WriteLine($"O aluno com o código {codigoAluno} não foi encontrado.");
                    return; // If aluno not found, exit the function
                }
            }
            else
                Console.WriteLine("\n Não existem alunos na lista. \n");
        }

        // Paga as propinas de um aluno ou de todos os alunos
        static void PagarPropinas(sAluno[] sAlu)
        {
            if (sAlu.Length > 0)
            {
                Console.WriteLine("Deseja pagar as propinas de todos os alunos? S/N");
                string resposta = Console.ReadLine().ToLower();

                if (resposta == "s")
                {
                    // Iterate over all alunos
                    for (int i = 0; i < sAlu.Length; i++)
                    { 
                        for (int j = 0; i < sAlu[i].mesesParaPagar[j].mes; j++)
                        {
                            // Verificar se o mês atual está pago ou não
                            if (sAlu[i].mesesParaPagar[j + 1].estadoPagamento == false)
                            {
                                sAlu[i].mesesParaPagar[j + 1].estadoPagamento = true;
                            }
                        }

                        Console.WriteLine($"As propinas de todos os meses do aluno {sAlu[i].nomAlu} (Cod:{sAlu[i].codAlu}) já estão pagas.");
                    }
                }
                else
                {
                    MostrarAlunos(sAlu);

                    Console.WriteLine("Qual é o código de aluno que pretende pagar as propinas?");
                    string alunoPagarPropinas = Console.ReadLine();

                    for (int i = 0; i < sAlu.Length; i++)
                    { 
                        if (sAlu[i].codAlu == alunoPagarPropinas)
                        {
                            Console.WriteLine("1. Pagar as propinas do mês corrente.");
                            Console.WriteLine("2. Pagar as propinas de outro mês que não seja o mês corrente.");
                            Console.WriteLine($"3. Pagar todas as propinas do aluno {sAlu[i].nomAlu}.");

                            int escolha = Convert.ToInt32(Console.ReadLine());

                            switch (escolha)
                            {
                                case 1:
                                    if (sAlu[i].mesesParaPagar[DateTime.Now.Month - 1].estadoPagamento == false)
                                    {
                                        // Atualizar o estado da propina do mês atual para "Pago"
                                        sAlu[i].mesesParaPagar[DateTime.Now.Month - 1].estadoPagamento = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"As propinas do mês atual para o aluno {sAlu[i].codAlu} já estão pagas.");
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("Escreva o número do mês que quer pagar: ");
                                    int mesEscolhido = Convert.ToInt32(Console.ReadLine());

                                    if (sAlu[i].mesesParaPagar[mesEscolhido - 1].estadoPagamento == false)
                                    {
                                        // Atualizar o estado da propina do mês atual para "Pago"
                                        sAlu[i].mesesParaPagar[mesEscolhido - 1].estadoPagamento = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"As propinas do mês {mesEscolhido} para o aluno {sAlu[i].codAlu} já estão pagas.");
                                    }
                                    break;

                                case 3:
                                    for (int j = 0; j < sAlu[i].mesesParaPagar.Length; j++)
                                    {
                                        if (sAlu[i].mesesParaPagar[j].estadoPagamento == false)
                                        {
                                            // Atualizar o estado da propina do mês atual para "Pago"
                                            sAlu[i].mesesParaPagar[j].estadoPagamento = true;
                                        }
                                    }
                                    Console.WriteLine($"As propinas do aluno {sAlu[i].codAlu} já estão pagas.");
                                    break;

                                default:
                                    Console.WriteLine("Opção Inválida");
                                    break;
                            }
                        }
                    }
                }
            }
            else
                Console.WriteLine("Não existem alunos na lista.");
        }

        // Mostra alunos com dividas e alunos que já tiveram dividas!
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
                    // Verificar se o pagamento do mês não foi feito
                    if (!sAlu[i].mesesParaPagar[j].estadoPagamento)
                    {
                        temDividas = true;
                        mesesEmAtraso++;
                        valorTotalDivida = valorTotalDivida + sAlu[i].mesesParaPagar[j].valorDivida;
                    }
                }

                // Verificar se o aluno teve dívidas
                if (temDividas)
                {
                    Console.WriteLine($"O aluno {sAlu[i].nomAlu} ({sAlu[i].codAlu}) tem {mesesEmAtraso} mês/meses em atraso com um total de {valorTotalDivida} euros.");
                }
                else if (sAlu[i].teveDividas)
                {
                    Console.WriteLine($"O aluno {sAlu[i].nomAlu} ({sAlu[i].codAlu}) já teve dívidas, mas está em dia agora.");
                }
            }

            if(!existiuDividas)
                Console.WriteLine($"Nenhum aluno teve dividas.");
        }

        // Verifica se os alunos têm dívidas futuras no próximo mês
        static void VerificarDividasFuturas(sAluno[] sAlu, int mesAtual)
        {
            Console.WriteLine("Dívidas futuras:");

            // Iterar sobre todos os alunos
            for (int i = 0; i < sAlu.Length; i++)
            {
                // Verificar se o aluno tem uma dívida no próximo mês
                if (sAlu[i].DividaProxima(mesAtual))
                    Console.WriteLine($"Aluno {sAlu[i].nomAlu} ({sAlu[i].codAlu}) tem uma dívida no próximo mês.");
                else
                    Console.WriteLine($"Aluno {sAlu[i].nomAlu} ({sAlu[i].codAlu}) não tem uma dívida no próximo mês.");
            }
        }

        // Carrega saldo para um aluno específico
        static void CarregarSaldo(sAluno[] sAlu)
        {
            // Variáveis para armazenar o código do aluno e o valor a ser carregado
            string codAluno;
            int valor;

            // Solicita o código do aluno que deseja carregar o saldo
            Console.WriteLine("Qual é o aluno que quer carregar o saldo?");
            codAluno = Console.ReadLine();

            // Itera sobre todos os alunos na lista
            for (int i = 0; i < sAlu.Length; i++)
            {
                // Verifica se o código do aluno atual corresponde ao código fornecido
                if (sAlu[i].codAlu == codAluno)
                {
                    // Solicita o valor a ser carregado para o saldo do aluno
                    Console.WriteLine("Qual é o montante que quer carregar o saldo?");
                    valor = Convert.ToInt32(Console.ReadLine());

                    // Adiciona o valor ao saldo do aluno correspondente
                    sAlu[i].salAlu = sAlu[i].salAlu + valor;

                    // Exibe mensagem de confirmação do carregamento do saldo
                    Console.WriteLine("O saldo foi carregado.");
                }
            }
        }

        // Mostra qual é o melhor e o pior aluno
        static void MelhorPiorAluno(sAluno[] sAlu)
        {
            // Indices para saber as posições dos alunos
            int indicePiorAluno = 0;
            int indiceMelhorAluno = 0;

            // Assume a melhor e a pior média pelo primeiro aluno da lista
            float melhorMedia = sAlu[0].medAlu;
            float piorMedia = sAlu[0].medAlu;

            // Ciclo para encontrar o melhor e o pior aluno
            for (int i = 0; i < sAlu.Length; i++)
            {
                // Verifica se a média do aluno atual é maior que a do melhor aluno
                if (sAlu[i].medAlu > melhorMedia)
                {
                    melhorMedia = sAlu[i].medAlu;
                    indiceMelhorAluno = i;
                }
                // Verifica se a média do aluno atual é menor que a do pior aluno
                else if (sAlu[i].medAlu < piorMedia)
                {
                    piorMedia = sAlu[i].medAlu;
                    indicePiorAluno = i;
                }
            }

            // Exibe o melhor e pior aluno
            Console.WriteLine($"Melhor aluno: {sAlu[indiceMelhorAluno].nomAlu}, Média: {melhorMedia}");
            Console.WriteLine($"Pior aluno: {sAlu[indicePiorAluno].nomAlu}, Média: {piorMedia}");
        }
    }
}