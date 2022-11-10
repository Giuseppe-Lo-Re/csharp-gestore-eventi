using static GestoreEventi;

class Conferenza : Evento
{
    private string _relatore;
    private double _prezzo;

    public string Relatore 
    {
        get
        {
            return _relatore;
        }
        set
        {
            if(value == "" || value == null)
            {
                throw new Exception("Inserisci il nome del relatore");
            }
            _relatore = value;
        }
    }
    public double Prezzo
    {
        get
        {
            return _prezzo;
        }
        set
        {
            if(value <= 0)
            {
                throw new Exception("il prezzo non può essere inferiore o uguale a zero");
            }
            _prezzo = value;
        }
    }

    public Conferenza(string titolo, DateTime data, int massimaCapienzaEvento, string relatore, double prezzo) :base(titolo, data, massimaCapienzaEvento)
    {
        Relatore = titolo;
        Prezzo = prezzo;
    }

    public string PrezzoFormattato()
    {
        string prezzoFormattato = _prezzo.ToString("0.00");
        return prezzoFormattato;
    }

    public override string ToString()
    {
        return Data.ToString("dd/MM/yyyy") + " - " + Titolo + " - " + _relatore + " - " + "euro";
    }
}

