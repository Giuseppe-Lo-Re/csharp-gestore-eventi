public partial class GestoreEventi
{
    public class Evento
    {
        private string _titolo;
        private DateTime _data;
        private int _massimaCapienzaEvento;
        private int _numeroPostiPrenotati;

        public Evento(string titolo, DateTime data, int massimaCapienzaEvento)
        {
            Titolo = titolo;
            Data = data;
            MassimaCapienzaEvento = massimaCapienzaEvento;
            NumeroPostiPrenotati = 0;
        }
        public string Titolo
        {
            get
            {
                return _titolo;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("Il titolo non può essere vuoto");
                }
                else
                {
                    _titolo = value;
                }
            }
        }

        public DateTime Data
        {
            get { 
                return _data;
            }
            set
            {
                DateTime dataOdierna = DateTime.Now;
                TimeSpan timeSpan = DateTime.Now - dataOdierna;
                int differenzaGiorni = Convert.ToInt32(timeSpan.Days / 30);

                if(differenzaGiorni < 0)
                {
                    throw new Exception("La data non può essere precedente a quella odierna");
                }
                else
                {
                    _data = value;
                }
            }
        }
        public int MassimaCapienzaEvento
        {
            get
            {
                return _massimaCapienzaEvento;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("La capacità massima dell'evento non può essere minore o uguale a 0");
                }
                else
                {
                    _massimaCapienzaEvento = value;
                }
            }
        }
        public int NumeroPostiPrenotati
        {
            get
            {
                return _numeroPostiPrenotati;
            }
            private set
            {
                _numeroPostiPrenotati = value;
            }
        }
        
        public int NumeroPostiDisponibili()
        {
            return MassimaCapienzaEvento - NumeroPostiPrenotati;
        }

        public void PrenotaPosti(int posti)
        {
            if(Data < DateTime.Now)
            {
                throw new Exception("L'evento è terminato");
            }
            if(posti > NumeroPostiDisponibili())
            {
                throw new Exception("Numero posti disponibili insufficiente");
            }
            else
            {
                NumeroPostiPrenotati += posti;
            }
        }
        public void DisdiciPosti(int posti)
        {
            if(posti < 1)
            {
                throw new Exception("Il numero dei posti da sdidire deve essere minimo 1");
            }
            if(posti < NumeroPostiPrenotati)
            {
                throw new Exception("Il numero dei posti da sdidire non può essere superiore al numero posti prenotati");
            }
            if(Data < DateTime.Now)
            {
                throw new Exception("L'evento è terminato");
            }

            NumeroPostiPrenotati -= posti;
        }
        public override string ToString()
        {
            return Data.ToString("dd/MM/yyyy") + " - " + Titolo + "\n"; 
        }
    }
}

