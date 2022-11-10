using System.Diagnostics.Tracing;
using System.Runtime.ConstrainedExecution;
using static GestoreEventi;


//Evento evento = CreaEvento();
//Prenotazioni(evento);
CreaProgrammaEventi();


// Prenotazione Evento
void Prenotazioni(Evento evento)
{
    bool disdetta = true;
     
    Console.WriteLine();
    Console.Write("Inserire quanti posti si vogliono prenotare: ");
    int posti = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Posti prenotati: " + posti.ToString());
    evento.PrenotaPosti(posti);
    Console.WriteLine("Posti disponibili: " + evento.NumeroPostiDisponibili());

    while (disdetta)
    {
        Console.WriteLine("Vuoi disdire dei posti? (si/no)");
        string risposta = Console.ReadLine();

        if (risposta == "si")
        {
            Console.WriteLine("Quanti posti vuoi disdire?");
            int numero = Convert.ToInt32(Console.ReadLine());
            evento.DisdiciPosti(numero);
            Console.WriteLine("Posti disponibili: " + evento.NumeroPostiDisponibili());
            disdetta = true;
        }
        else
        {
            Console.WriteLine("Grazie e arrivederci");
            disdetta = false;
        }
    }
}

// Creazione evento
Evento CreaEvento()
{
    Console.WriteLine("Inserisci il nome del nuovo evento: ");
    string titoloEvento = Console.ReadLine();

    Console.WriteLine("Inserisci la data dell'evento (gg/mm/yyyy): ");
    DateTime dataEvento = System.DateTime.Parse(Console.ReadLine());

    Console.WriteLine("Inserisci il numero dei posti totali: ");
    int postiTotali = Convert.ToInt32(Console.ReadLine());

    Evento evento = new Evento(titoloEvento, dataEvento, postiTotali);
    Console.WriteLine("Hai appena registrato correttamente il seguente evento: " + evento.ToString());

    return evento;
}

// Creazione programma eventi
void CreaProgrammaEventi()
{
    Console.WriteLine("Inserire il titolo del nuovo programma eventi: ");
    string titolo = Console.ReadLine();

    ProgrammaEventi programmaEventi = new ProgrammaEventi(titolo);

    Console.WriteLine("Quanti eventi inserire nel programma?");
    int numeroEventi = Convert.ToInt32(Console.ReadLine());


    for (int i = 0; i < numeroEventi; i++)
    {
        Evento nuovoEvento = CreaEvento();
        if (nuovoEvento == null)
        {
            throw new Exception("Attenzione è stato generato un evento nullo");
        }
        programmaEventi.AggiungiEvento(nuovoEvento);
    }

    programmaEventi.ConteggioEventi();
    ProgrammaEventi.StampaListaEventi(programmaEventi.Eventi);
    Console.WriteLine(programmaEventi.MostraProgrammaEventi());
    programmaEventi.RicercaPerData();
}



