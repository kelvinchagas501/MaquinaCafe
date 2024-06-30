class Program
{
    static void Main()
    {
        MaquinaCafe maquina = new MaquinaCafe();
        maquina.Ligar();

        string cafeEscolhido = Console.ReadLine();

        maquina.IniciarProcesso(cafeEscolhido);
        


    }
}