using System;
namespace bsi_3.Ciphers
{
    public abstract class CipherBase
    {
        protected string _input;
        protected string _code;
        protected string _alphabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";

        public CipherBase(string input, string code)
        {
            if (input == null) throw new ArgumentNullException("Input can't be empty!");
            else _input = input.ToLower();

            if (code == null) throw new ArgumentNullException("Code can't be empty!");
            else _code = code.ToLower();
        }

        public abstract string Encrypt();

        public abstract string Decrypt();

    }
}
