Partial Class nascomercioDataSet
    Partial Class v_balancoDataTable

    End Class

    Partial Class v_crediarioDataTable

        Private Sub v_crediarioDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.valorpagoColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class v_chequesDataTable

        Private Sub v_chequesDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.bancoColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class v_estoqueDataTable

        Private Sub v_estoqueDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.cidColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

  Partial Class v_vendasgrupoDataTable

    Private Sub v_vendasgrupoDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
      If (e.Column.ColumnName = Me.cd_grupoColumn.ColumnName) Then
        'Add user code here
      End If

    End Sub

  End Class

  Partial Class clientesDataTable

    Private Sub clientesDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
      If (e.Column.ColumnName = Me.dddColumn.ColumnName) Then
        'Add user code here
      End If

    End Sub

  End Class

End Class

Namespace nascomercioDataSetTableAdapters
    
    Partial Class v_crediarioTableAdapter

    End Class

    Partial Public Class v_chequesTableAdapter
    End Class
End Namespace
