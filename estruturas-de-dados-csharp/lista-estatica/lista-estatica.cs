using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estruturas_de_dados_csharp.lista_estatica
{
    public class ListaEstatica
    {
        private int _length;
        private int _maxLength;
        private object[] _itens;

        public ListaEstatica(int maxLength = 0)
        {
            _itens = new object[maxLength];
            _maxLength = maxLength;
            _length = 0;
        }

        public bool listaVazia()
        {
            return _length == 0;
        }

        public bool listaCheia()
        {
            return _length == _maxLength;
        }

        public bool adicionaNoIndice(int indice, object dadosAdicionar)
        {
            if (listaCheia() || indice >= _maxLength || indice > _length)
                return false;

            if (listaVazia())
            {
                _itens[indice] = dadosAdicionar;
                _length++;
                return true;
            }

            int adicionaIndice;
            for (adicionaIndice = _length; adicionaIndice >= 0; adicionaIndice--)
            {
                if (indice == adicionaIndice)
                    break;

                _itens[adicionaIndice] = _itens[adicionaIndice - 1];
            }

            _itens[adicionaIndice] = dadosAdicionar;
            _length++;

            return true;
        }

        public bool adicionaInicio(object dadosAdicionar)
        {
            return adicionaNoIndice(0, dadosAdicionar);
        }

        public bool adicionaFim(object dadosAdicionar)
        {
            return adicionaNoIndice(_length, dadosAdicionar);
        }

        public object removeIndice(int indice)
        {
            if (listaVazia() || indice >= _maxLength || indice > _length)
                return false;

            object itemRemovido = _itens[indice];

            for (int indiceRemover = indice; indiceRemover < _length; indiceRemover++)
                _itens[indiceRemover] = _itens[indiceRemover + 1];

            _length--;
            return itemRemovido;
        }

        public object removerInicio()
        {
            return removeIndice(0);
        }

        public object removerFim()
        {
            return removeIndice(_length);
        }

        public void printLista()
        {
            Console.WriteLine($"Quantidade de itens: {_length}");
            Console.WriteLine($"Quantidade máxima de itens: {_maxLength}");
            for (int indice = 0; indice < _length; indice++)
            {
                Console.WriteLine($"[{indice}] -> {_itens[indice]}");
            }
        }
    }
}
