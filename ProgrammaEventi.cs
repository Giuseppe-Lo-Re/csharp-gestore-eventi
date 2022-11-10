using static GestoreEventi;

public class ProgrammaEventi
{
    public string Titolo { get; set; }
    public List<Evento> Eventi { get; private set; }

    public ProgrammaEventi(string titolo)
    {
        this.Titolo = titolo;
        this.Eventi = new List<Evento>();
    }

    public void AggiungiEvento(Evento evento)
    {
        this.Eventi.Add(evento);
    }

    public void RicercaPerData()
    {
        List<Evento> EventiPerData = new List<Evento>();
        Console.WriteLine("Inserire data dell'evento da ricercare: ");
        DateTime DataRicerca = Convert.ToDateTime(Console.ReadLine());

        foreach (Evento evento in this.Eventi)
        {
            if (evento.Data == DataRicerca)
            {
                EventiPerData.Add(evento);
            }
        }

        Console.WriteLine("Gli eventi presenti in data: " + DataRicerca);
        Console.WriteLine();

        foreach (Evento evento in EventiPerData)
        {
            Console.WriteLine("Nome Evento: " + evento.Titolo);
        }
    }

    public static void StampaListaEventi(List<Evento> eventi)
    {
        foreach (Evento eventItem in eventi)
        {
            eventItem.ToString();
        }
    }

    public void ConteggioEventi()
    {
        Console.WriteLine("Numero eventi in programma: " + this.Eventi.Count());
    }

    public void SvuotaListaEventi()
    {
        this.Eventi.Clear();
    }

    public string MostraProgrammaEventi()
    {
        string programma = "Nome programma evento " + this.Titolo;
        Console.WriteLine();
        foreach (Evento evento in this.Eventi)
        {
            programma += evento.ToString();
        }

        return programma;
    }
}



