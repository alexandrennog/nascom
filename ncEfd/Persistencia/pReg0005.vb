Imports System.Text
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEfd

  Public Class pReg0005

    Public Function Consultar() As dReg0005

      Dim retorno As dReg0005 = Nothing
      Dim acessoBanco As cAcessoBD = New cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim comando As StringBuilder = New StringBuilder()

      comando.Append(" SELECT ")
      comando.Append(" e.nomeFantasia, c.logradouro, c.numero, c.complemento, c.bairro, c.cep, c.dddTelefone, c.dddFax, c.email ")
      comando.Append(" FROM EfdEntidade e, EfdEnderecoContato c ")
      
      ds = acessoBanco.ExecutarDS(comando.ToString())

      If Not ds Is Nothing Then
        If ds.Tables.Count > 0 Then
          dt = ds.Tables(0)

          If dt.Rows.Count > 0 Then
            retorno = New dReg0005()

            retorno.fantasia = cFuncoes.RetornarTexto(dt.Rows(0).Item("nomeFantasia"))
            retorno.cep = cFuncoes.RetornarTexto(dt.Rows(0).Item("cep"))
            retorno.ende = cFuncoes.RetornarTexto(dt.Rows(0).Item("logradouro"))
            retorno.num = cFuncoes.RetornarTexto(dt.Rows(0).Item("numero"))
            retorno.compl = cFuncoes.RetornarTexto(dt.Rows(0).Item("complemento"))
            retorno.bairro = cFuncoes.RetornarTexto(dt.Rows(0).Item("bairro"))
            retorno.fone = cFuncoes.RetornarTexto(dt.Rows(0).Item("dddTelefone"))
            retorno.fax = cFuncoes.RetornarTexto(dt.Rows(0).Item("dddFax"))
            retorno.email = cFuncoes.RetornarTexto(dt.Rows(0).Item("email"))
          End If
        End If
      End If

      Consultar = retorno

    End Function

  End Class

End Namespace
