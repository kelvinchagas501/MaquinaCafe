public class MaquinaCafe
{
	public int DepositoCapsulasDescartadas { get; set; }
	public List<TipoCafe> TiposCafe { get; set; }
	public int QuantidadeDepositoAgua { get; set; }

	public MaquinaCafe()
	{
		TiposCafe = new List<TipoCafe>{
			new TipoCafe(){Descricao = "Curto", Quantidade = 10, NumeroOpcao = "1", TempoProcessamento = 1},
			new TipoCafe(){Descricao = "Normal", Quantidade = 20 , NumeroOpcao = "2", TempoProcessamento = 2},
			new TipoCafe(){Descricao = "Cheio", Quantidade = 30, NumeroOpcao = "3", TempoProcessamento = 3 }
		};

		DepositoCapsulasDescartadas = 7;
		QuantidadeDepositoAgua = LerQuantidadeAgua();
	}

	public void Ligar()
	{
		Console.WriteLine("Ligou a maquina");
		Console.WriteLine("Ainda tem: " + QuantidadeDepositoAgua + "ml de agua restante.");
		AquecerAgua();
		Console.WriteLine("Maquina pronta.");
		MostrarOpcoesCafe();
	}

	public void IniciarProcesso(string cafeEscolhido)
	{
		TipoCafe tipoCafeEscolhido = TiposCafe.FirstOrDefault(e => e.NumeroOpcao == cafeEscolhido);

		if (QuantidadeDepositoAgua < tipoCafeEscolhido.Quantidade)
			Console.WriteLine("Não tem água suficiente.");
		else
		{
			string descricaoCafe = tipoCafeEscolhido.Descricao;

			Console.WriteLine("Você escolheu o café: " + descricaoCafe);

			FazerCafe(tipoCafeEscolhido);

			Console.WriteLine("Ainda tem: " + QuantidadeDepositoAgua + "ml de agua restante.");

		}
	}

	private void AquecerAgua()
	{
		int tempo = 3;

		while (tempo > 0)
		{
			Console.WriteLine("Aquecendo a água...");
			Thread.Sleep(1000);
			tempo--; // é ingual ai isso aqui: tempo = tempo -1;
		}
	}

	private void MostrarOpcoesCafe()
	{
		Console.WriteLine("Escolha uma opção de café:");

		foreach (TipoCafe tipo in TiposCafe)
		{
			Console.WriteLine("Digite: " + tipo.NumeroOpcao + " para café: " + tipo.Descricao);

		}
	}

	private void FazerCafe(TipoCafe tipoCafeEscolhido)
	{
		int tempoProcessamento = tipoCafeEscolhido.TempoProcessamento;

		QuantidadeDepositoAgua = QuantidadeDepositoAgua - tipoCafeEscolhido.Quantidade;

		while (tempoProcessamento > 0)
		{
			Console.WriteLine("Fazendo o café...");
			Thread.Sleep(1000);
			tempoProcessamento--; // é ingual ai isso aqui: tempo = tempo -1;
		}

		EscreverQuantidadeAgua(QuantidadeDepositoAgua);

		Console.WriteLine("Café pronto!");
	}

	public void EscreverQuantidadeAgua(int quantidade)
	{
		try
		{
			using (StreamWriter writer = new StreamWriter("C:\\Projetos\\MaquinaCafe\\quantidade.txt"))
			{
				writer.WriteLine(quantidade);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Erro ao gravar no arquivo: {ex.Message}");
		}
	}

	private int LerQuantidadeAgua()
	{
		try
		{
			using (StreamReader reader = new StreamReader("C:\\Projetos\\MaquinaCafe\\quantidade.txt"))
			{
				string linha = reader.ReadLine();
				if (int.TryParse(linha, out int quantidade))
				{
					return quantidade;
				}
				else
				{
					Console.WriteLine("Erro: O conteúdo do arquivo não é um número inteiro válido.");
					return 0;
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
			return 0;
		}
	}
}
