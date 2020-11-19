namespace OOTPLab4
{
    public class Owner
    {
        private int ID;
        private static int count;
        private string autor;
        private string company;

        public void SetAuthorAndCompany(string author, string company)
        {
            this.autor = author;
            this.company = company;
        }
        public Owner(string autor, string company)
        {
            this.autor = autor;
            this.company = company;
            this.ID = count;
            ID++;
        }

        public string Autor {
            get => autor;
            set => autor = value;
        }

        public string Company
        {
            get => company;
            set => company = value;
        }

        public Owner()
        {
            
        }

        static Owner()
        {
            count = 0;
        }
    }
    

}