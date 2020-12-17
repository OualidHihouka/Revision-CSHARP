using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision_Csharp
{
    [Serializable()]
    class Etudient
    {
        private int num;
        public string nom;
        private DateTime datenaissence;
        private int aneebac;
        

        public int Num
        {
            get { return this.num; }
            set { this.num = value++; }
        }
        
        public DateTime Datenaissence
        {
            get { return this.datenaissence; }
            set { this.datenaissence = value; }
        }
        public int AneeBac
        {
            get { return this.aneebac; }
            set { this.aneebac = value; }
        }        

        public Etudient() { }
        public Etudient(int a,string b,DateTime c,int d)
        {
            this.num = a;
            this.nom = b;
            this.datenaissence = c;
            this.aneebac = d;
        }
        public Etudient(Etudient e)
        {
            this.num = e.num;
            this.nom = e.nom;
            this.datenaissence = e.datenaissence;
            this.aneebac = e.aneebac;
        }
        public virtual void afficher()
        {
             Console.WriteLine((this.Num + " " + this.nom + " " + this.Datenaissence + " " + this.AneeBac).ToString());
        }
        public override string ToString()
        {
            return (this.Num + " " + this.nom + " " + this.Datenaissence + " " + this.AneeBac).ToString(); ;
        }
    }
}
