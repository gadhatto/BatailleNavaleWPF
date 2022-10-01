namespace BatailleNavaleWPF
{
    public class Case
    {
        public Position Position { get; set;  }

        public bool Touche { get; private set; }

        public Navire Navire { get; set; }

        public Case(int ligne, int colonne)
        {
            Position = new Position(ligne, colonne);
            Touche = false;
        }

        public void Toucher()
        {
            Touche = true;
        }
    }
}
