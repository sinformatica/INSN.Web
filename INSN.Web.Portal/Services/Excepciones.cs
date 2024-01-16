namespace INSN.Web.Portal.Services
{
    public class Excepciones : Exception
    {
        public string Code { get; }
        public string ReasonPhrase { get; }

        public Excepciones(string code, string reasonPhrase) 
        {
            Code = code;
            ReasonPhrase = reasonPhrase;
        }
    }
}
