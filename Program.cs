using FluxoCaixa.Data;
using FluxoCaixa.Models;
using Microsoft.EntityFrameworkCore;
using MiniValidation;
using FluxoCaixa.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// app.MapGet("/", () => "Hello World!");

app.MapGet("/v1/tipolancamento", (AppDbContext context) =>
{
    var tipos = context.TipoLancamento;
    return tipos is not null ? Results.Ok(tipos) : Results.NotFound();
})
.Produces<TipoLancamento>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithName("GetTipoLancamento")
.WithTags("TipoLancamento");

app.MapGet("/v1/tipolancamento{id:int}", (int id, AppDbContext context) =>
{
    var tipo = context.TipoLancamento.Find(id);
    return tipo is not null ? Results.Ok(tipo) : Results.NotFound();
})
.Produces<Lancamento>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithName("GetTipoLancamentoPorId")
.WithTags("TipoLancamento");

app.MapGet("/v1/lancamentos", (AppDbContext context) =>
{
    var lancamentos = context.Lancamento;
    return lancamentos is not null ? Results.Ok(lancamentos) : Results.NotFound();
})
.Produces<Lancamento>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithName("GetLancamento")
.WithTags("Lancamento");

app.MapGet("/v1/lancamentos{id:int}", (int id, AppDbContext context) =>
{
    var lancamento = context.Lancamento.Find(id);
    return lancamento is not null ? Results.Ok(lancamento) : Results.NotFound();
})
.Produces<Lancamento>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithName("GetLancamentoPorId")
.WithTags("Lancamento");

app.MapPost("/v1/lancamentos", (Lancamento model, AppDbContext context) =>
{
    if (!MiniValidator.TryValidate(model, out var errors))
        return Results.ValidationProblem(errors);

    var lancamentoAnterior = context.Lancamento.OrderByDescending(o =>
        o.DataLancamento).FirstOrDefault();

    var saldo = 0.00M;
    if (lancamentoAnterior != null)
        saldo = lancamentoAnterior.Saldo;

    model.AtualizaLancamento(saldo);

    context.Lancamento.Add(model);

    return context.SaveChanges() > 0
        ? Results.CreatedAtRoute($"GetLancamentoPorId", new { id = model.Id }, model)
        : Results.BadRequest("Ocorreu um erro ao salvar o lançamento");
})
.ProducesValidationProblem()
.Produces<Lancamento>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.WithName("PostLancamento")
.WithTags("Lancamento");

app.MapPut("/v1/lancamentos{id:int}", (int id, Lancamento model, AppDbContext context) =>
{
    var lancamento = context.Lancamento.AsNoTracking<Lancamento>().FirstOrDefault(x => x.Id == id);
    if (lancamento == null || lancamento.Id != id)
        return Results.NotFound();

    if (!MiniValidator.TryValidate(model, out var errors))
        return Results.ValidationProblem(errors);

    var lancamentoAnterior = context.Lancamento.OrderByDescending(o =>
        o.DataLancamento).FirstOrDefault();

    model.AtualizaLancamento(lancamentoAnterior.Saldo);

    context.Lancamento.Update(model);
    return context.SaveChanges() > 0
        ? Results.Created($"/v1/lancamentos/{model.Id}", model)
        : Results.BadRequest("Ocorreu um erro ao salvar o lançamento");
})
.ProducesValidationProblem()
.Produces<Lancamento>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status400BadRequest)
.WithName("PutLancamento")
.WithTags("Lancamento");

app.MapDelete("/v1/lancamentos{id:int}", (int id, AppDbContext context) =>
{
    var lancamento = context.Lancamento.AsNoTracking<Lancamento>().FirstOrDefault(x => x.Id == id);
    if (lancamento == null)
        return Results.NotFound();

    context.Lancamento.Remove(lancamento);
    return context.SaveChanges() > 0
        ? Results.NoContent()
        : Results.BadRequest("Ocorreu um erro ao salvar o lançamento");
})
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status400BadRequest)
.WithName("DeleteLancamento")
.WithTags("Lancamento");

app.MapPost("/v1/consolidado", (ConsolidadoConsultaViewModel viewModel, AppDbContext context) =>
{
    var lancamentos = context.Lancamento.Where(x =>
        x.DataLancamento > viewModel.DataInicial.Date
        && x.DataLancamento <= viewModel.DataFinal.AddDays(1).Date)
        .OrderBy(o => o.DataLancamento).ToList();

    var lancamentoAnterior = context.Lancamento.Where(x =>
        x.DataLancamento < viewModel.DataInicial.Date)
        .OrderByDescending(o => o.DataLancamento)
        .FirstOrDefault();

    var saldoAnterior = 0.00M;

    if (lancamentoAnterior != null)
        saldoAnterior = lancamentoAnterior.Saldo;

    var saldoFinal = lancamentos.LastOrDefault().Saldo;

    var consolidadoViewModel = new ConsolidadoViewModel(saldoAnterior, saldoFinal, lancamentos);

    return consolidadoViewModel is not null ? Results.Ok(consolidadoViewModel) : Results.NotFound();
})
.Produces<Lancamento>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithName("PostConsolidado")
.WithTags("Consolidado");

app.Run();
