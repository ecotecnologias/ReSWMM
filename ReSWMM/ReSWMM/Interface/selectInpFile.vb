Public Class selectInpFile

    Dim selectedInp As String

    'Select the inp file
    Public Sub bSelect_Click(sender As Object, e As EventArgs) Handles bSelect.Click
        selectedInp = lbInputSelection.SelectedItem()
        main.tbInputFile.Text() = selectedInp
        Me.Close()
        runAnalysis(selectedInp)
    End Sub

End Class