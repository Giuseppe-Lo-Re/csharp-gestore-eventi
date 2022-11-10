using System.Diagnostics.Tracing;
using System.Runtime.ConstrainedExecution;
using static GestoreEventi;


Evento evento = CreaEvento();
Prenotazioni(evento);
ProgrammaEventi programmaEventi = CreaProgrammaEventi();
CreaConferenza(programmaEventi);


// Prenotazione Evento
void Prenotazioni(Evento evento)
{
    bool disdetta = true;
     
    Console.WriteLine(); 
    Console.WriteLine("********** PRENOTAZIONE EVENTO **********");
    Console.Write("Inserisci i posti da prenotare: ");
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
            Console.WriteLine();
            Console.WriteLine("Grazie e arrivederci!");
            disdetta = false;
        }
    }
}

// Creazione evento
Evento CreaEvento()
{
    Console.WriteLine();
    Console.WriteLine("********** CREAZIONE EVENTO **********");

    Console.WriteLine("Inserisci il nome del nuovo evento: ");
    string titoloEvento = Console.ReadLine();

    Console.WriteLine("Inserisci la data dell'evento (gg/mm/yyyy): ");
    DateTime dataEvento = System.DateTime.Parse(Console.ReadLine());

    Console.WriteLine("Inserisci il numero dei posti totali: ");
    int postiTotali = Convert.ToInt32(Console.ReadLine());

    Evento evento = new Evento(titoloEvento, dataEvento, postiTotali);
    Console.WriteLine("Hai appena registrato correttamente il seguente evento: \n " + evento.ToString());

    return evento;
}

// Creazione programma eventi
ProgrammaEventi CreaProgrammaEventi()
{
    Console.WriteLine();
    Console.WriteLine("********** CREAZIONE PROGRAMMA EVENTI **********");

    Console.WriteLine("Inserire il titolo del nuovo programma eventi: ");
    string titolo = Console.ReadLine();

    ProgrammaEventi programmaEventi = new ProgrammaEventi(titolo);

    Console.WriteLine("Quanti eventi vuoi inserire nel programma?");
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

    return programmaEventi;
}

// Creazione conferenza
void CreaConferenza(ProgrammaEventi programmaEventi)
{
    Console.WriteLine();
    Console.WriteLine("********** PRENOTAZIONE CONFERENZA **********");

    Console.WriteLine("Inserisci il titolo della conferenza:");
    string titolo = Console.ReadLine();

    DateTime datatime = new DateTime();
    int postiPrenotati = 0;
    int massimaCapienza = 0;

    Console.WriteLine("Inserisci la data della conferenza (gg/mm/yyyy):");
    string data = Console.ReadLine();
    datatime = DateTime.Parse(data);

    Console.WriteLine("Inserisci la capienza massima della conferenza:");
    massimaCapienza = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Inserisci il nome del relatore");
    string relatore = Console.ReadLine();

    Console.WriteLine("Inserisci il prezzo della conferenza:");
    double prezzo = Convert.ToInt32(Console.ReadLine());

    Conferenza conferenza = new Conferenza(titolo, datatime, massimaCapienza, relatore, prezzo);
    programmaEventi.AggiungiEvento(conferenza);
}