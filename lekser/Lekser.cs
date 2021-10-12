using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekser
{
    class Lekser
    {
        public List<Token> SignArrary { get; set; }
        public Tuple<bool, int> Analyse(string expresion)
        {
            this.SignArrary = new List<Token>();
            int index = 0;

            LexResult lexRes = new LexResult();
            lexRes.result = false;
            while (index < expresion.Length && (lexRes = S(expresion, index)).result)
            {
                this.SignArrary.Add(lexRes.token);
                index = index + lexRes.token.Argument.Length;
            } 

            return new Tuple<bool, int>(lexRes.result, index);
        }

        private LexResult S(string expresion, int index)
        {
            LexResult lexRes;
            if ((lexRes = Bracket(expresion, index)).result) return lexRes;
            if ((lexRes = Space(expresion, index)).result) return lexRes;
            if ((lexRes = Number(expresion, index)).result) return lexRes;
            lexRes = Operator(expresion, index);
            return lexRes;
        }

        private LexResult Bracket(string expresion, int index)
        {
            LexResult lexResult = new LexResult();
            lexResult.result = expresion[index] == '(' || expresion[index] == ')';
            lexResult.token = new Token(TypTokenu.Nawias, expresion[index].ToString(), index.ToString());
            return lexResult;
        }
        private LexResult Operator(string expresion, int index)
        {
            LexResult lexResult = new LexResult();
            lexResult.result = expresion[index] == '+' || expresion[index] == '-' ||
                expresion[index] == '*' || expresion[index] == '/';
            lexResult.token = new Token(TypTokenu.Operator, expresion[index].ToString(), index.ToString());
            return lexResult;
        }
        private LexResult Space(string expresion, int index)
        {
            LexResult lexBufor, lexResult = new LexResult();
            if (expresion.Length > index + 1 && expresion[index] == ' ' && (lexBufor = Space(expresion, index + 1)).result)
            {
                lexResult.result = true;
                lexResult.token = new Token(TypTokenu.BialeZnaki, expresion[index].ToString() + lexBufor.token.Argument, index.ToString());
                return lexResult;
            }
            else if (expresion[index] == ' ')
            {
                lexResult.result = true;
                lexResult.token = new Token(TypTokenu.BialeZnaki, expresion[index].ToString(), index.ToString());
                return lexResult;
            }
            lexResult.result = false;
            return lexResult;
        }
        private LexResult Rest(string expresion, int index)
        {
            LexResult lexBufor, lexResult = new LexResult();
            if (expresion.Length > index + 1 && "123456789".Contains(expresion[index]) && (lexBufor = Rest(expresion, index + 1)).result)
            {
                lexResult.result = true;
                lexResult.token = new Token(TypTokenu.Liczba, expresion[index].ToString() + lexBufor.token.Argument, index.ToString());
                return lexResult;
            }
            else if (expresion.Length > index + 1 && expresion[index] == '0' && (lexBufor = Rest(expresion, index + 1)).result)
            {
                lexResult.result = true;
                lexResult.token = new Token(TypTokenu.Liczba, expresion[index].ToString() + lexBufor.token.Argument, index.ToString());
                return lexResult;
            }
            else if (expresion.Length == index + 1 && "1234567890".Contains(expresion[index]))
            {
                lexResult.result = true;
                lexResult.token = new Token(TypTokenu.Liczba, expresion[index].ToString(), index.ToString());
                return lexResult;
            }
            lexResult.result = true;
            lexResult.token = new Token(TypTokenu.Liczba, "", index.ToString());
            return lexResult;
        }
        private LexResult Number(string expresion, int index)
        {
            LexResult lexBufor, lexResult = new LexResult();
            if (expresion[index] == '0')
            {
                lexResult.result = true;
                lexResult.token = new Token(TypTokenu.Liczba, expresion[index].ToString(), index.ToString());
                return lexResult;
            }
            else if (expresion.Length > index && "123456789".Contains(expresion[index]) && (lexBufor = Rest(expresion, index + 1)).result)
            {
                lexResult.result = true;
                lexResult.token = new Token(TypTokenu.Liczba, expresion[index].ToString() + lexBufor.token.Argument, index.ToString());
                return lexResult;
            }
            lexResult.result = false;
            return lexResult;
        }

    }
}
