﻿namespace webapi.inlock.codefirst.Manha.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// Gera uma hash a partir de uma senha
        /// </summary>
        /// <param name="senha">Senha que recebera a Hash</param>
        /// <returns>Senha criptografada com a hash</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a hash da senha informada é igual a senha salva no banco
        /// </summary>
        /// <param name="senhaForm">Senha informada pelo usuario</param>
        /// <param name="senhaBanco">Senha cadastrada no bnaco</param>
        /// <returns>True ou False(Senha é verdadeira?)</returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
