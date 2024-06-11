using System.Runtime.CompilerServices;

namespace ApiCrud.Estudantes
{
    public class Estudante
    {
        public Guid Id { get; init; }
        // Guid gera um id único e init indica que ele não pode ser alterado
        public string Nome { get; private set; }
        // private set indica que ele só pode ser alterado dentro da classe, e não por instância
        public bool Ativo { get; private set;}

        public Estudante(string nome)
        {
            Nome = nome;
            Id = Guid.NewGuid();
            //toda vez que gerar um novo estudante, vai ser gerado um novo id para ele. Do contrário será retirado do DB
            Ativo = true;
        }

        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }
        //permite controlar as alterações feitas na propriedade

        public void Desativar()
        {
            Ativo = false;
        }
        //aqui estou dizendo que nosso estudante nasce ativo, pode ser desativado em algum momento e nunca será ativado novamente
    }
}
