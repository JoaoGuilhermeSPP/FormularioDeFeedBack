using models;
using System.Net;
using System.Net.Mail;

namespace Servico
{
public class EmailService
{
    public static async Task EnviarFormularioAsync(FeedBackModel formulario)
{
    try
    {
        var remetente = "email@gmail.com";
        var senha = "kffq haml bktp chsp"; // Considere usar Configuration
        var destinatario = "receber@gmail.com";

        using var mensagem = new MailMessage(remetente, destinatario);
        mensagem.Subject = $"Novo Feedback - {formulario.Nome}";
        mensagem.Body = $@"
            Nome: {formulario.Nome}
            Email: {formulario.Email}
            Telefone: {formulario.Telefone}
            Estrelas: {formulario.Estrelas}
            Feedback: {formulario.Feedback}";
        using var smtpClient = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential(remetente, senha),
            EnableSsl = true,
            Timeout = 10000 // 10 segundos
        };

        await smtpClient.SendMailAsync(mensagem);
    }
    catch (SmtpException ex)
    {
        throw new Exception($"Erro SMTP: {ex.Message}");
    }
    catch (Exception ex)
    {
        throw new Exception($"Erro ao enviar email: {ex.Message}");
    }
}
    
}
}
