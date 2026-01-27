using DevIO.Domain.Notificacoes;

namespace DevIO.Domain.Interfaces;

public interface INotificador
{
    bool TemNotificacoes();
    List<Notificacao> ObterNotificacoes();
    void Handle(Notificacao notificacao);
}
