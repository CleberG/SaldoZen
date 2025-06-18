namespace SaldoZen.Domain.Enun
{
    public enum EUsuarioStatus
    {
        /// <summary>
        /// Usuário ativo
        /// </summary>
        Ativo = 1,
        /// <summary>
        /// Usuário inativo
        /// </summary>
        Inativo = 2,
        /// <summary>
        /// Usuário que foi cnvidado, mas ainda não confirmou o convite.
        /// </summary>
        AguardandoConfimacao = 3,
        /// <summary>
        /// Usuário excluído
        /// </summary>
        Excluido = 4,
    }
}
