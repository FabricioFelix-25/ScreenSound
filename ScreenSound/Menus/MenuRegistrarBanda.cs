
using OpenAI_API;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, banda);
        try
        {
            var client = new OpenAIAPI("<SUA API KEY AQUI>");
            var chat = client.Chat.CreateConversation();
            chat.AppendSystemMessage($"Resuma a banda {nomeDaBanda} em 1 parágrafo. Adote um estilo informal");
            var resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
            banda.Resumo = resposta;


            Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao tentar registrar a banda ou obter o resumo.");
            Console.WriteLine($"Detalhes do erro: {ex.Message}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();

    }
}
