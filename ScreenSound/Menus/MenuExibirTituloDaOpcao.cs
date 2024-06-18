

using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuExibirTituloDaOpcao : Menu
{
    public void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }
}
