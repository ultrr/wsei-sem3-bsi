using System;
using System.Collections.Generic;
namespace bsi_3.Ciphers
{
    public class CipherPlayfair : CipherBase
    {
        //5x7
        int columns = 5;
        int lines = 7;

        public CipherPlayfair(string input, string code) : base (input, code)
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
                if (_alphabet.IndexOf(_code[i]) != -1) code_new += _code[i];
            }
            if (code_new == null) throw new ArgumentNullException("Code cant be empty!");
            else _code = code_new;

        }

        public override string Encrypt()
        {
            string input = string.Empty;
            string code = string.Empty;
            string output = string.Empty;
            string alphabet = string.Empty;
            List<string> alph_list = new List<string>();

            //usun zduplikowane litery z kodu
            for (int i = 0; i < _code.Length; i++) if (code.IndexOf(_code[i]) == -1) code += _code[i];

            alphabet += code;
            for (int i = 0; i < _alphabet.Length; i++) if (code.IndexOf(_alphabet[i]) == -1) alphabet += _alphabet[i];

            for (int i = 0; i < lines; i++) alph_list.Add(alphabet.Substring(i * columns, columns));

            //sprawdz czy diagramy nie sa takie same, jesli sa -> rozdziel je wstawiajac X (lub A) pomeidzy takie same litery
            for (int i = 0; i < _input.Length - 1; i+=2)
            {
                if (_input[i] == _input[i+1])
                {
                    input += _input[i];
                    if (_input[i] == 'x') input += 'a';
                    else input += 'x';
                    input += _input[i + 1];
                }
                else
                {
                    input += _input[i];
                    input += _input[i + 1];
                }
            }
            if (_input.Length % 2 != 0) input += _input[_input.Length - 1];
            //jesli niepatrzysta dlugosc -> dodaj X (lub A) na koniec
            if (input.Length % 2 != 0) 
            {
                if (input[input.Length - 1] == 'x') input += 'a';
                else input += 'x';
            }

            //szyfrowanie
            for (int i = 0; i < input.Length; i += 2)
            {
                int c1_x, c1_y;
                int c2_x, c2_y;
                c1_x = c1_y = c2_x = c2_y = 0;

                bool c1, c2;
                c1 = c2 = false;

                //znajdz indeks
                int j = 0;
                do
                {
                    if (alph_list[j].Contains(input[i]))
                    {
                        c1_x = alph_list[j].IndexOf(input[i]);
                        c1_y = j;
                        c1 = true;
                    }

                    if (alph_list[j].Contains(input[i+1]))
                    {
                        c2_x = alph_list[j].IndexOf(input[i+1]);
                        c2_y = j;
                        c2 = true;
                    }

                    j++;
                }
                while (c1 == false || c2 == false);

                //porownaj indeks, wybierz rodzaj szyfru
                if (c1_x == c2_x)
                {
                    output += alph_list[c1_y][(c1_x + 1) % lines];
                    output += alph_list[c2_y][(c2_x + 1) % lines];
                }
                else if (c1_y == c2_y)
                {
                    output += alph_list[(c1_y + 1) % columns][c1_x];
                    output += alph_list[(c2_y + 1) % columns][c2_x];
                }
                else
                {
                    output += alph_list[c1_y][c2_x];
                    output += alph_list[c2_y][c1_x];
                }
            }

            return output;
        }

        public override string Decrypt()
        {
            string code = string.Empty;
            string output = string.Empty;
            string alphabet = string.Empty;
            List<string> alph_list = new List<string>();

            //usun zduplikowane litery z kodu
            for (int i = 0; i < _code.Length; i++) if (code.IndexOf(_code[i]) == -1) code += _code[i];

            alphabet += code;
            for (int i = 0; i < _alphabet.Length; i++) if (code.IndexOf(_alphabet[i]) == -1) alphabet += _alphabet[i];

            for (int i = 0; i < lines; i++) alph_list.Add(alphabet.Substring(i * columns, columns));

            //deszyfrowanie
            for (int i = 0; i < _input.Length; i += 2)
            {
                int c1_x, c1_y;
                int c2_x, c2_y;
                c1_x = c1_y = c2_x = c2_y = 0;

                bool c1, c2;
                c1 = c2 = false;

                //znajdz indeks
                int j = 0;
                do
                {
                    if (alph_list[j].Contains(_input[i]))
                    {
                        c1_x = alph_list[j].IndexOf(_input[i]);
                        c1_y = j;
                        c1 = true;
                    }

                    if (alph_list[j].Contains(_input[i + 1]))
                    {
                        c2_x = alph_list[j].IndexOf(_input[i + 1]);
                        c2_y = j;
                        c2 = true;
                    }

                    j++;
                }
                while (c1 == false || c2 == false);

                //porownaj indeks, wybierz rodzaj szyfru
                if (c1_x == c2_x)
                {
                    output += alph_list[c1_y][(lines + c1_x - 1) % lines];
                    output += alph_list[c2_y][(lines + c2_x - 1) % lines];
                }
                else if (c1_y == c2_y)
                {
                    output += alph_list[(columns + c1_y - 1) % columns][c1_x];
                    output += alph_list[(columns + c2_y - 1) % columns][c2_x];
                }
                else
                {
                    output += alph_list[c1_y][c2_x];
                    output += alph_list[c2_y][c1_x];
                }
            }

            return output;
        }
    }
}
