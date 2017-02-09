using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Techshop
{
    public class Usuarios
    {
        public int CodigoUsuario { get; set; }
        public string DescricaoUsuario { get; set; }
        public string DescricaoEmail { get; set; }
        public string DescricaoLogin { get; set; }
        public string DescricaoSenha { get; set; }
        public int CodigoEmpresa { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CodigoPerfil { get; set; }
        public DateTime DataExpiracao { get; set; }
        public int IndicadorAtivo { get; set; }
        public string DescricaoMensagem { get; set; }
        public string DataExpiracaoString { get; set; }
        public string DescricaoPerfil { get; set; }
        public string ExamesSelecionados { get; set; }
    }
}