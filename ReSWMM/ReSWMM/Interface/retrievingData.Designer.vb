<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class retrievingData
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.LabelObject = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(223, 40)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Retrieving data from input file. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please wait."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(12, 96)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(232, 24)
        Me.ProgressBar2.TabIndex = 1
        Me.ProgressBar2.UseWaitCursor = True
        '
        'LabelObject
        '
        Me.LabelObject.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelObject.Location = New System.Drawing.Point(17, 64)
        Me.LabelObject.Name = "LabelObject"
        Me.LabelObject.Size = New System.Drawing.Size(223, 24)
        Me.LabelObject.TabIndex = 2
        Me.LabelObject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'retrievingData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(257, 131)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelObject)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "retrievingData"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents LabelObject As Label
End Class
