<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class configDxD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(configDxD))
        Me.DxDRatio = New System.Windows.Forms.TextBox()
        Me.okButton = New System.Windows.Forms.Button()
        Me.Mnsa = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'DxDRatio
        '
        Me.DxDRatio.Location = New System.Drawing.Point(272, 60)
        Me.DxDRatio.Name = "DxDRatio"
        Me.DxDRatio.Size = New System.Drawing.Size(256, 26)
        Me.DxDRatio.TabIndex = 26
        Me.DxDRatio.Text = "5"
        Me.DxDRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'okButton
        '
        Me.okButton.Location = New System.Drawing.Point(16, 104)
        Me.okButton.Name = "okButton"
        Me.okButton.Size = New System.Drawing.Size(520, 40)
        Me.okButton.TabIndex = 28
        Me.okButton.Text = "OK"
        Me.okButton.UseVisualStyleBackColor = True
        '
        'Mnsa
        '
        Me.Mnsa.Location = New System.Drawing.Point(272, 21)
        Me.Mnsa.Name = "Mnsa"
        Me.Mnsa.Size = New System.Drawing.Size(256, 26)
        Me.Mnsa.TabIndex = 23
        Me.Mnsa.Text = "0.01"
        Me.Mnsa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 20)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "DxD Ratio:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(219, 20)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Minimum Nodal Surface Area:"
        '
        'configDxD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 157)
        Me.Controls.Add(Me.DxDRatio)
        Me.Controls.Add(Me.okButton)
        Me.Controls.Add(Me.Mnsa)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "configDxD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DxD Based Configuration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents DxDRatio As TextBox
    Friend WithEvents okButton As Button
    Public WithEvents Mnsa As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
End Class
