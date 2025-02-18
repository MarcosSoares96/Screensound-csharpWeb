﻿namespace ScreenSound.Modelos;

public class Musica
{
    private int artistaId;

    public Musica(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
    public int Id { get; set; }
    public int? AnoLancamento { get; set; }
    public virtual Artista? Artista { get; set; }
    public int ArtistaId { get; set; }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
      
    }

    //public void ExibirMusicaPorAnoLancamento()
    //{
    //    Console.WriteLine($"Musicas {AnoLancamento}");

    //    foreach (var musica in Musicas)
    //    {
    //        Console.WriteLine($"Música: {musica.Nome}");
    //    }
    //}

    //public override string ToString()
    //{
    //    return @$"Id: {Id}
    //    Nome: {Nome}";
    //}
}