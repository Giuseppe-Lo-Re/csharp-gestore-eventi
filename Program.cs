using System.Diagnostics.Tracing;
using System.Runtime.ConstrainedExecution;
using static GestoreEventi;

Evento evento = CreaEvento();

Evento CreaEvento()
{
    Console.WriteLine("inserisci il nome del nuovo evento: ");
    string titoloEvento = Console.ReadLine();

    Console.WriteLine("Inserisci la data dell'evento nel seguente formato:(gg/mm/yyyy): ");
    DateTime dataEvento = System.DateTime.Parse(Console.ReadLine());

    Console.WriteLine("Inserisci il numero dei posti totali: ");
    int postiTotali = Convert.ToInt32(Console.ReadLine());

    Evento evento = new Evento(titoloEvento, dataEvento, postiTotali);
    Console.WriteLine(evento.ToString());

    return evento;
}



