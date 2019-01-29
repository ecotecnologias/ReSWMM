<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class selectInpFile
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(selectInpFile))
        Me.lbInputSelection = New System.Windows.Forms.ListBox()
        Me.bSelect = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbInputSelection
        '
        Me.lbInputSelection.FormattingEnabled = True
        Me.lbInputSelection.ItemHeight = 20
        Me.lbInputSelection.Location = New System.Drawing.Point(16, 16)
        Me.lbInputSelection.Name = "lbInputSelection"
        Me.lbInputSelection.Size = New System.Drawing.Size(584, 184)
        Me.lbInputSelection.TabIndex = 0
        '
        'bSelect
        '
        Me.bSelect.Location = New System.Drawing.Point(16, 208)
        Me.bSelect.Name = "bSelect"
        Me.bSelect.Size = New System.Drawing.Size(584, 40)
        Me.bSelect.TabIndex = 1
        Me.bSelect.Text = "Select"
        Me.bSelect.UseVisualStyleBackColor = True
        '
        'selectInpFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 260)
        Me.Controls.Add(Me.bSelect)
        Me.Controls.Add(Me.lbInputSelection)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "selectInpFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Input File"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lbInputSelection As ListBox
    Friend WithEvents bSelect As Button
End Class
