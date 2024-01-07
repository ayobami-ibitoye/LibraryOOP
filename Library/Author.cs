namespace LibraryOOP.Library
{
    class Author 
    {
        

        public Author(string name, string dob)
        {
            _name = name;
            _dob = dob;
        }

        private string _dob { get; set; }
        private string _name { get; set; }
    }
}