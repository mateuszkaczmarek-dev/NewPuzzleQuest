using System;


namespace PuzzleQuest
{
    class Mefisto
    {
        public string nazwa;
        public int hp;
        public float obrazenia;
        public float krytyczne;
        public int los;
        Random losuj_krytyczne = new Random();
        public Mefisto(string n, int zycie, float dmg, float cryt)
        {
            this.nazwa = n;
            this.hp = zycie;
            this.obrazenia = dmg;
            this.krytyczne = cryt;

        }

        public Mefisto() { }
    }
}
