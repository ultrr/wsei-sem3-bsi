using System;
namespace bsi_3.Ciphers
{
    public class CipherVigenere : CipherBase
    {
        public CipherVigenere(string input, string code) : base(input, code)
        {
            string input_new = string.Empty;
            string code_new = string.Empty;

            for (int i = 0; i < _input.Length; i++)
            {
                if (_alphabet.IndexOf(_input[i]) != -1) input_new += _input[i];
            }
            if (input_new == string.Empty) throw new ArgumentNullException("Input can't be empty!");
            else _input = input_new;

            for (int i = 0; i < _code.Length; i++)
            {
                if (_alphabet.IndexOf(_code[i]) != -1) code_new += _code[i];
            }
            if (code_new == string.Empty) throw new ArgumentNullException("Code can't be empty!");
            else _code = code_new;

        }

        private string Logic(string code)
        {
            //alfabet z input przecina alfabet zaczynajacy sie od litery w kodzie

            string output = string.Empty;

            for (int i = 0; i < _input.Length; i++)
            {
                int index_input = _alphabet.IndexOf(_input[i]);
                int index_code = _alphabet.IndexOf(code[i % code.Length]);

                output += _alphabet[(index_input + index_code) % _alphabet.Length];
            }

            return output;
        }

        public override string Encrypt()
        {
            return Logic(_code);
        }

        public override string Decrypt()
        {
            string code_inverted = string.Empty;

            for (int i = 0; i < _code.Length; i++)
            {
                int index_code = _alphabet.IndexOf(_code[i % _code.Length]);
                code_inverted += _alphabet[(_alphabet.Length - index_code) % _alphabet.Length];
            }

            return Logic(code_inverted);
        }
    }
}
