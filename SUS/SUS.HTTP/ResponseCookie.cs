using System.Text;

namespace SUS.HTTP
{
    public class ResponseCookie : Cookie
    {
        public ResponseCookie(string name, string value) 
            : base(name, value)
        {
            this.Path= "/";
        }

        public int MaxAge { get; set; }

        public bool HttpOnly { get; set; }  

        public string Path { get; set; }

        public override string ToString()
        {
            StringBuilder cookieBulder = new StringBuilder();

            cookieBulder.Append($"{this.Name}={this.Value}; Path={this.Path};");

            if (MaxAge!= 0)
            {
                cookieBulder.Append($" Max-Age={this.MaxAge};");
            }

            if (HttpOnly)
            {
                cookieBulder.Append($" HttpOnly;");
            }

            return cookieBulder.ToString();
        }
    }
}
