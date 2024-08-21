using System;

namespace Opah.Lib.Logger
{
    public interface IOpahLogger
    {
        /// <summary>
        /// Grava o log e gera um token de rastreamento
        /// </summary>
        /// <param name="logType">Tipo do log: Erro, informação, etc.</param>
        /// <param name="exception">Exception para ser gravada no log. Mensagem e Stack trace</param>
        /// <returns></returns>
        Guid Log(LogType logType, Exception exception);

        /// <summary>
        /// Grava o log e gera um token de rastreamento
        /// </summary>
        /// <param name="logType">Tipo do log: Erro, informação, etc.</param>
        /// <param name="message">Mensagem a ser gravada</param>
        /// <param name="exception">Exception para ser gravada no log. Mensagem e Stack trace</param>
        /// <returns></returns>
        Guid Log(LogType logType, string message, Exception exception);

        /// <summary>
        /// Grava o log e gera um token de rastreamento
        /// </summary>
        /// <param name="logType">Tipo do log: Erro, informação, etc.</param>
        /// <param name="message">Mensagem a ser gravada</param>
        /// <returns></returns>
        Guid Log(LogType logType, string message);

        /// <summary>
        /// Grava o log com o token passado para permitir rastreamento entre microsserviços
        /// </summary>
        /// <param name="logType">Tipo do log: Erro, informação, etc.</param>
        /// <param name="exception">Exception para ser gravada no log. Mensagem e Stack trace</param>
        /// <param name="token">Token de rastreamento no log</param>
        void Log(LogType logType, Exception exception, Guid token);

        /// <summary>
        /// Grava o log com o token passado para permitir rastreamento entre microsserviços
        /// </summary>
        /// <param name="logType">Tipo do log: Erro, informação, etc.</param>
        /// <param name="message">Mensagem a ser gravada</param>
        /// <param name="exception">Exception para ser gravada no log. Mensagem e Stack trace</param>
        /// <param name="token">Token de rastreamento no log</param>
        void Log(LogType logType, string message, Exception exception, Guid token);

        /// <summary>
        /// Grava o log com o token passado para permitir rastreamento entre microsserviços
        /// </summary>
        /// <param name="logType">Tipo do log: Erro, informação, etc.</param>
        /// <param name="message">Mensagem a ser gravada</param>
        /// <param name="token">Token de rastreamento no log</param>
        void Log(LogType logType, string message, Guid token);
    }
}