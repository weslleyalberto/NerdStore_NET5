using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Validacoes.ValidarSeMenorQue(altura, 1, "O campo altura não pode ser menor ou igual a 0");
            Validacoes.ValidarSeMenorQue(largura, 1, "O campo largura não pode ser menor ou igual a 0");
            Validacoes.ValidarSeMenorQue(profundidade, 1, "O campo profundidade não pode ser menor ou igual a 0");
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }
        public string DescriçãoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }
        public override string ToString()
        {
            return DescriçãoFormatada();
        }
    }
}
