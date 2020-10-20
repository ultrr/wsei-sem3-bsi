using System;
namespace bsi_3.Ciphers
{
    public class CipherCesar : CipherBase
    {
        private int _offset;

        public CipherCesar(string input, string code) : base(input, code)
        {
            string input_new = string.Empty;
            string code_new = string.Empty;

            for (int i = 0; i < _input.Length; i++)
            {
                if (_alphabet.IndexOf(_input[i]) != -1) input_new += _input[i];
            }
            if (input_new == null) throw new ArgumentNullException("Input cant be empty!");
            else _input = input_new;

            for (int i = 0; i < _code.Length; i++)
            {
                if (char.IsDigit(_code[i]) == true) code_new += _code[i];
            }
            if (code_new == null) throw new ArgumentNullException("Code cant be empty!");
            else _offset = int.Parse(code_new) % _alphabet.Length;
        }

        public override string Encrypt()
        {
            string output = string.Empty;

            for (int i = 0; i < _input.Length; i++)
            {
                int index = _alphabet.IndexOf(_input[i]);

                output += _alphabet[(index + _offset) % _alphabet.Length];
                //if (index == -1) output += _input[i];
                //else output += _alphabet[(index + _offset) % _alphabet.Length];
            }

            return output;
        }

        public override string Decrypt()
        {
            string output = string.Empty;

            for (int i = 0; i < _input.Length; i++)
            {
                int index = _alphabet.IndexOf(_input[i]);

                output += _alphabet[(_alphabet.Length + index - _offset) % _alphabet.Length];
                //if (index == -1) output += _input[i];
                //else output += _alphabet[(_alphabet.Length + index - _offset) % _alphabet.Length];
            }

            return output;
        }

    }
}
