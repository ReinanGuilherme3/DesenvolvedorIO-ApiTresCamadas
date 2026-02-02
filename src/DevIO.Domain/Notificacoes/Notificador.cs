using DevIO.Domain.Interfaces;

namespace DevIO.Domain.Notificacoes;

internal class Notificador : INotificador
{
    private readonly List<Notificacao> _notificacoes = [];

    public void Handle(Notificacao notificacao)
        => _notificacoes.Add(notificacao);
    public List<Notificacao> ObterNotificacoes()
        => _notificacoes;

    public bool TemNotificacoes()
        => _notificacoes.Count != 0;
}
