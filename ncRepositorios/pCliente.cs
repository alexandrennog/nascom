using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsCliente;

namespace ncPersistencia.nsCliente
{
    public class pCliente
    {
        public ColecaoCliente Listar()
        {
            ColecaoCliente retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, nome, estadoCivil, sexo, nomePai, nomeMae, dataInclusao, " +
                    " situacao, rg, cpf, carteiraProfissional, dataNascimento, naturalidade, nacionalidade, email, " +
                    " foto, ddd, telefone, dddcel, celular, rgOrgaoEmissor, rgUf_cid From clientes ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoCliente();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCliente();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.estadoCivil = RetornarTexto(row["estadoCivil"]);
                            item.sexo = RetornarTexto(row["sexo"]);
                            item.nomePai = RetornarTexto(row["nomePai"]);
                            item.nomeMae = RetornarTexto(row["nomeMae"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.rg = RetornarTexto(row["rg"]);
                            item.cpf = RetornarTexto(row["cpf"]);
                            item.carteiraProfissional = RetornarTexto(row["carteiraProfissional"]);
                            item.dataNascimento = RetornarTexto(row["dataNascimento"]);
                            item.naturalidade = RetornarTexto(row["naturalidade"]);
                            item.nacionalidade = RetornarTexto(row["nacionalidade"]);
                            item.email = RetornarTexto(row["email"]);
                            item.foto = RetornarTexto(row["foto"]);
                            item.ddd = RetornarTexto(row["ddd"]);
                            item.telefone = RetornarTexto(row["telefone"]);
                            item.dddcel = RetornarTexto(row["dddcel"]);
                            item.celular = RetornarTexto(row["celular"]);
                            item.rgOrgaoEmissor = RetornarTexto(row["rgOrgaoEmissor"]);
                            item.rgUf_cid = RetornarInteiro(row["rgUf_cid"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Cliente [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoCliente Consultar(dCliente dados)
        {
            ColecaoCliente retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select c.cid, nome, logradouro, estadoCivil, sexo, nomePai, nomeMae, c.dataInclusao, " +
                    " situacao, rg, cpf, carteiraProfissional, dataNascimento, naturalidade, nacionalidade, email, " +
                    " foto, ddd, telefone, dddcel, celular, rgOrgaoEmissor, rgUf_cid ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From clientes c left join veiculo v  on  v.clienteid = c.cid " +
                    " left join clienteenderecos e on e.cliente_cid = c.cid  and tipoEndereco = 'p' ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "c.cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.nome, "nome", true);
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.endereco, "logradouro", true);
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.estadoCivil, "estadoCivil");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.sexo, "sexo");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.nomePai, "nomePai", true);
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.nomeMae, "nomeMae", true);
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataInclusao, "dataInclusao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacao, "situacao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.rg, "rg");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cpf, "cpf");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.carteiraProfissional, "carteiraProfissional");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataNascimento, "dataNascimento");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.naturalidade, "naturalidade", true);
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.nacionalidade, "nacionalidade");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.email, "email");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.foto, "foto");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.ddd, "ddd");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.telefone, "telefone");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.veiculo, "placa");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoCliente();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCliente();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.endereco = RetornarTexto(row["logradouro"]);
                            item.estadoCivil = RetornarTexto(row["estadoCivil"]);
                            item.sexo = RetornarTexto(row["sexo"]);
                            item.nomePai = RetornarTexto(row["nomePai"]);
                            item.nomeMae = RetornarTexto(row["nomeMae"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.rg = RetornarTexto(row["rg"]);
                            item.cpf = RetornarTexto(row["cpf"]);
                            item.carteiraProfissional = RetornarTexto(row["carteiraProfissional"]);
                            item.dataNascimento = RetornarTexto(row["dataNascimento"]);
                            item.naturalidade = RetornarTexto(row["naturalidade"]);
                            item.nacionalidade = RetornarTexto(row["nacionalidade"]);
                            item.email = RetornarTexto(row["email"]);
                            item.ddd = RetornarTexto(row["ddd"]);
                            item.telefone = RetornarTexto(row["telefone"]);
                            item.dddcel = RetornarTexto(row["dddcel"]);
                            item.celular = RetornarTexto(row["celular"]);
                            item.foto = RetornarTexto(row["foto"]);
                            item.rgOrgaoEmissor = RetornarTexto(row["rgOrgaoEmissor"]);
                            item.rgUf_cid = RetornarInteiro(row["rgUf_cid"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Cliente [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dCliente dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " clientes (nome, estadoCivil, sexo, nomePai, nomeMae, dataInclusao, " +
                    " situacao, rg, cpf, carteiraProfissional, dataNascimento, naturalidade, nacionalidade, email, " +
                    " foto, ddd, telefone, dddcel, celular, rgOrgaoEmissor, rgUf_cid) " +
                    " VALUES (" +
                    PersistirTexto(dados.nome) + "," +
                    PersistirTexto(dados.estadoCivil) + "," +
                    PersistirTexto(dados.sexo) + "," +
                    PersistirTexto(dados.nomePai) + "," +
                    PersistirTexto(dados.nomeMae) + "," +
                    PersistirData(dados.dataInclusao) + "," +
                    PersistirTexto(dados.situacao) + "," +
                    PersistirTexto(dados.rg) + "," +
                    PersistirTexto(dados.cpf) + "," +
                    PersistirTexto(dados.carteiraProfissional) + "," +
                    PersistirData(dados.dataNascimento) + "," +
                    PersistirTexto(dados.naturalidade) + "," +
                    PersistirTexto(dados.nacionalidade) + "," +
                    PersistirTexto(dados.email) + "," +
                    PersistirTexto(dados.foto) + "," +
                    PersistirTexto(dados.ddd) + "," +
                    PersistirTexto(dados.telefone) + "," +
                    PersistirTexto(dados.dddcel) + "," +
                    PersistirTexto(dados.celular) + "," +
                    PersistirTexto(dados.rgOrgaoEmissor) + "," +
                    PersistirInteiro(dados.rgUf_cid) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Cliente [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int IncluirCid(dCliente dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " clientes (cid, nome, estadoCivil, sexo, nomePai, nomeMae, dataInclusao, " +
                    " situacao, rg, cpf, carteiraProfissional, dataNascimento, naturalidade, nacionalidade, email, " +
                    " foto, ddd, telefone, dddcel, celular, rgOrgaoEmissor, rgUf_cid) " +
                    " VALUES (" +
                    PersistirTexto(dados.cid) + "," +
                    PersistirTexto(dados.nome) + "," +
                    PersistirTexto(dados.estadoCivil) + "," +
                    PersistirTexto(dados.sexo) + "," +
                    PersistirTexto(dados.nomePai) + "," +
                    PersistirTexto(dados.nomeMae) + "," +
                    PersistirData(dados.dataInclusao) + "," +
                    PersistirTexto(dados.situacao) + "," +
                    PersistirTexto(dados.rg) + "," +
                    PersistirTexto(dados.cpf) + "," +
                    PersistirTexto(dados.carteiraProfissional) + "," +
                    PersistirData(dados.dataNascimento) + "," +
                    PersistirTexto(dados.naturalidade) + "," +
                    PersistirTexto(dados.nacionalidade) + "," +
                    PersistirTexto(dados.email) + "," +
                    PersistirTexto(dados.foto) + "," +
                    PersistirTexto(dados.ddd) + "," +
                    PersistirTexto(dados.telefone) + "," +
                    PersistirTexto(dados.dddcel) + "," +
                    PersistirTexto(dados.celular) + "," +
                    PersistirTexto(dados.rgOrgaoEmissor) + "," +
                    PersistirInteiro(dados.rgUf_cid) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Cliente [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dCliente dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE clientes SET " +
                    " nome = " + PersistirTexto(dados.nome) + "," +
                    " estadoCivil = " + PersistirTexto(dados.estadoCivil) + "," +
                    " sexo = " + PersistirTexto(dados.sexo) + "," +
                    " nomePai = " + PersistirTexto(dados.nomePai) + "," +
                    " nomeMae = " + PersistirTexto(dados.nomeMae) + "," +
                    " dataInclusao = " + PersistirData(dados.dataInclusao) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) + "," +
                    " rg = " + PersistirTexto(dados.rg) + "," +
                    " cpf = " + PersistirTexto(dados.cpf) + "," +
                    " carteiraProfissional = " + PersistirTexto(dados.carteiraProfissional) + "," +
                    " dataNascimento = " + PersistirData(dados.dataNascimento) + "," +
                    " naturalidade = " + PersistirTexto(dados.naturalidade) + "," +
                    " nacionalidade = " + PersistirTexto(dados.nacionalidade) + "," +
                    " email = " + PersistirTexto(dados.email) + "," +
                    " foto = " + PersistirTexto(dados.foto) + "," +
                    " ddd = " + PersistirInteiro(dados.ddd) + "," +
                    " telefone = " + PersistirInteiro(dados.telefone) + "," +
                    " dddcel = " + PersistirInteiro(dados.dddcel) + "," +
                    " celular = " + PersistirInteiro(dados.celular) + "," +
                    " rgOrgaoEmissor = " + PersistirTexto(dados.rgOrgaoEmissor) + "," +
                    " rgUf_cid = " + PersistirInteiro(dados.rgUf_cid) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Cliente [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dCliente dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM clientes " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Cliente [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
