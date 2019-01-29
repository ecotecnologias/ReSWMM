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
        Me.SuDis = New System.Windows.Forms.RadioButton()
        Me.JunDis = New System.Windows.Forms.RadioButton()
        Me.SuMH = New System.Windows.Forms.RadioButton()
        Me.JunMH = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(219, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Minimum Nodal Surface Area:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(251, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Fixed Interval (SWMM Flow Units):"
        '
        'Mnsa
        '
        Me.Mnsa.Location = New System.Drawing.Point(272, 93)
        Me.Mnsa.Name = "Mnsa"
        Me.Mnsa.Size = New System.Drawing.Size(256, 26)
        Me.Mnsa.TabIndex = 8
        Me.Mnsa.Text = "0.01"
        Me.Mnsa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MinI
        '
        Me.MinI.Location = New System.Drawing.Point(312, 133)
        Me.MinI.Name = "MinI"
        Me.MinI.Size = New System.Drawing.Size(64, 26)
        Me.MinI.TabIndex = 9
        Me.MinI.Text = "2"
        Me.MinI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(272, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Min"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(424, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Max"
        '
        'MaxI
        '
        Me.MaxI.Location = New System.Drawing.Point(464, 132)
        Me.MaxI.Name = "MaxI"
        Me.MaxI.Size = New System.Drawing.Size(64, 26)
        Me.MaxI.TabIndex = 11
        Me.MaxI.Text = "4"
        Me.MaxI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'okButton
        '
        Me.okButton.Location = New System.Drawing.Point(16, 176)
        Me.okButton.Name = "okButton"
        Me.okButton.Size = New System.Drawing.Size(520, 40)
        Me.okButton.TabIndex = 13
        Me.okButton.Text = "OK"
        Me.okButton.UseVisualStyleBackColor = True
        '
        'SuDis
        '
        Me.SuDis.AutoSize = True
        Me.SuDis.Location = New System.Drawing.Point(152, 8)
        Me.SuDis.Name = "SuDis"
        Me.SuDis.Size = New System.Drawing.Size(124, 24)
        Me.SuDis.TabIndex = 7
        Me.SuDis.Text = "Storage Unit"
        Me.SuDis.UseVisualStyleBackColor = True
        '
        'JunDis
        '
        Me.JunDis.AutoSize = True
        Me.JunDis.Checked = True
        Me.JunDis.Location = New System.Drawing.Point(16, 8)
        Me.JunDis.Name = "JunDis"
        Me.JunDis.Size = New System.Drawing.Size(102, 24)
        Me.JunDis.TabIndex = 6
        Me.JunDis.TabStop = True
        Me.JunDis.Text = "Junctions"
        Me.JunDis.UseVisualStyleBackColor = True
        '
        'SuMH
        '
        Me.SuMH.AutoSize = True
        Me.SuMH.Location = New System.Drawing.Point(152, 8)
        Me.SuMH.Name = "SuMH"
        Me.SuMH.Size = New System.Drawing.Size(124, 24)
        Me.SuMH.TabIndex = 5
        Me.SuMH.Text = "Storage Unit"
        Me.SuMH.UseVisualStyleBackColor = True
        '
        'JunMH
        '
        Me.JunMH.AutoSize = True
        Me.JunMH.Checked = True
        Me.JunMH.Location = New System.Drawing.Point(16, 8)
        Me.JunMH.Name = "JunMH"
        Me.JunMH.Size = New System.Drawing.Size(102, 24)
        Me.JunMH.TabIndex = 4
        Me.JunMH.TabStop = True
        Me.JunMH.Text = "Junctions"
        Me.JunMH.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Manholes:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Discretization:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.JunMH)
        Me.Panel1.Controls.Add(Me.SuMH)
        Me.Panel1.Location = New System.Drawing.Point(256, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(280, 40)
        Me.Panel1.TabIndex = 17
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SuDis)
        Me.Panel2.Controls.Add(Me.JunDis)
        Me.Panel2.Location = New System.Drawing.Point(256, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(280, 48)
        Me.Panel2.TabIndex = 18
        '
        'configIF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 229)
        Me.Controls.Add(Me.MaxI)
        Me.Controls.Add(Me.okButton)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.MinI)
        Me.Controls.Add(Me.Mnsa)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "configIF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fixed Interval Configuration"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents okButton As Button


    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Public WithEvents Mnsa As TextBox
    Public WithEvents MinI As TextBox
    Public WithEvents MaxI As TextBox
    Public WithEvents SuDis As RadioButton
    Public WithEvents JunDis As RadioButton
    Public WithEvents SuMH As RadioButton
    Public WithEvents JunMH As RadioButton
End Class
