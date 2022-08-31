using System.Xml.Serialization;

Menu();
static void Menu()
{
    Console.Clear();
    Console.WriteLine("|-----------MENU-----------|");
    Console.WriteLine("");
    Console.WriteLine(" O que você deseja fazer? ");
    Console.WriteLine("");
    Console.WriteLine(" 1 - Abrir um arquivo. ");
    Console.WriteLine(" 2 - Criar um novo arquivo. ");
    //Console.WriteLine(" 3 - Excluir um aquivo.");
    Console.WriteLine(" 0 - Sair ");
    Console.WriteLine("");
    Console.Write(" OPÇÃO: ");
    short option = short.Parse(Console.ReadLine());

    switch (option)
    {
        case 1: AbrirArquivo(); break;
        case 2: CriarArquivo(); break;
        //case 3: ExcluirArquivo(); break;
        case 0: System.Environment.Exit(0); break;
    }
}
static void AbrirArquivo()
{
    Console.Clear();
    Console.WriteLine(" Qual o caminho do arquivo?");
    string caminho = Console.ReadLine();

    using (var arquivo = new StreamReader(caminho))
    {
        string text = arquivo.ReadToEnd();
        Console.WriteLine(text);
    }
    Console.WriteLine("");
    Console.ReadLine();
    Menu();
}

static void CriarArquivo()
{
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo. (ESC para sair)");
    Console.WriteLine("-----------------------------------------");
    string text = "";
    do
    {
        text += Console.ReadLine();
        text += Environment.NewLine;
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);

    Salvar(text);
}

/*static void ExcluirArquivo()
{

}
*/

static void Salvar(string text)
{
    Console.Clear();
    Console.WriteLine(" Qual o caminho para salvar o arquivo?");
    var caminho = Console.ReadLine();

    using (var arquivo = new StreamWriter(caminho)) //O using é uma forma segura de abrir/fechar um arquivo, com menores chances de algum erro por esquecimento.
    {
        arquivo.Write(text);
    }
    Console.WriteLine($" Arquivo {caminho} salvo com sucesso!");
    Console.ReadLine();
    Menu();

}