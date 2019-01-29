Public Class configIF

    'Set the configurations
    Public Sub okButton_Click(sender As Object, e As EventArgs) Handles okButton.Click

        'Enable the run button
        main.bRunIFDisc.Enabled() = True
        Me.Hide()

    End Sub

End Class