<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class configIF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(configIF))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Mnsa = New System.Windows.Forms.TextBox()
        Me.MinI = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MaxI = New System.Windows.Forms.TextBox()
        Me.okButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(219, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Minimum Nodal Surface Area:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(251, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Fixed Interval (SWMM Flow Units):"
        '
        'Mnsa
        '
        Me.Mnsa.Location = New System.Drawing.Point(272, 20)
        Me.Mnsa.Name = "Mnsa"
        Me.Mnsa.Size = New System.Drawing.Size(256, 26)
        Me.Mnsa.TabIndex = 8
        Me.Mnsa.Text = "0.01"
        Me.Mnsa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MinI
        '
        Me.MinI.Location = New System.Drawing.Point(312, 60)
        Me.MinI.Name = "MinI"
        Me.MinI.Size = New System.Drawing.Size(64, 26)
        Me.MinI.TabIndex = 9
        Me.MinI.Text = "2"
        Me.MinI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(272, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Min"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(424, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Max"
        '
        'MaxI
        '
        Me.MaxI.Location = New System.Drawing.Point(464, 59)
        Me.MaxI.Name = "MaxI"
        Me.MaxI.Size = New System.Drawing.Size(64, 26)
        Me.MaxI.TabIndex = 11
        Me.MaxI.Text = "4"
        Me.MaxI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'okButton
        '
        Me.okButton.Location = New System.Drawing.Point(16, 103)
        Me.okButton.Name = "okButton"
        Me.okButton.Size = New System.Drawing.Size(520, 40)
        Me.okButton.TabIndex = 13
        Me.okButton.Text = "OK"
        Me.okButton.UseVisualStyleBackColor = True
        '
        'configIF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 161)
        Me.Controls.Add(Me.MaxI)
        Me.Controls.Add(Me.okButton)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.MinI)
        Me.Controls.Add(Me.Mnsa)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "configIF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fixed Interval Configuration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents okButton As Button
    Public WithEvents Mnsa As TextBox
    Public WithEvents MinI As TextBox
    Public WithEvents MaxI As TextBox
End Class
