using ApiCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Estudantes
{
    public static class EstudantesRotas
    {
        public static void AddRotasEstudantes(this WebApplication app)
        {
            var rotasEstudantes = app.MapGroup("estudantes");
            //rota fixa para todos os maps

            //para criar se usa o post
            rotasEstudantes.MapPost("", async (AddEstudanteRequest request, AppDbContext context, CancellationToken ct)=>
            {
                var jaExiste = await context.Estudantes.AnyAsync(estudante => estudante.Nome == request.Nome, ct);
                if (jaExiste)
                {
                    return Results.Conflict("Esse estudante já existe.");
                }
                
                var novoEstudante = new Estudante(request.Nome);

                await context.Estudantes.AddAsync(novoEstudante, ct);
                await context.SaveChangesAsync(ct);

                var estudanteRetorno = new EstudanteDTO(novoEstudante.Id, novoEstudante.Nome);
                //boa prática para não expor dados desnecessários ao front

                return Results.Ok(estudanteRetorno);
            });

            //retornar todos os estudantes cadastrados
            rotasEstudantes.MapGet("", async (AppDbContext context, CancellationToken ct) =>
            {
                var estudantes = await context.Estudantes.Where(estudante => estudante.Ativo)
                .Select(estudante => new EstudanteDTO(estudante.Id, estudante.Nome)).ToListAsync(ct);

                return estudantes;
            });

            //atualiza nome estudante
            rotasEstudantes.MapPut("{id}", async (Guid id,UpdateEstudanteRequest request, AppDbContext context, CancellationToken ct) =>
            {
                var estudante = await context.Estudantes.SingleOrDefaultAsync(estudante => estudante.Id == id, ct);

                if (estudante == null) return Results.NotFound();

                estudante.AtualizarNome(request.Nome);
                await context.SaveChangesAsync(ct);
                return Results.Ok(new EstudanteDTO(estudante.Id, estudante.Nome));
            });

            // Deletar estudante
            rotasEstudantes.MapDelete("{id}", async (Guid id, AppDbContext context, CancellationToken ct) => 
            {
                var estudante = await context.Estudantes.SingleOrDefaultAsync(estudante => estudante.Id == id, ct);

                if (estudante == null) return Results.NotFound();

                estudante.Desativar();

                await context.SaveChangesAsync(ct);
                return Results.Ok();
            });
        }
    }
}
