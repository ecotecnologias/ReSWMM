Public Class configDxD

    Public Sub okButton_Click(sender As Object, e As EventArgs) Handles okButton.Click

        'Enable the run button
        main.bRunDxDDisc.Enabled() = True
        Me.Hide()

    End Sub

End Class