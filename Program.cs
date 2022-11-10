using System.Diagnostics.Tracing;
using System.Runtime.ConstrainedExecution;
using static GestoreEventi;

void Prenotazioni(Evento evento)
{
    bool disdetta = true;

    Console.WriteLine();
    Console.WriteLine("*** PRENOTA POSTI ***");
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



