﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.bAnalyze = New System.Windows.Forms.Button()
        Me.tbAnalyzeInput = New System.Windows.Forms.TextBox()
        Me.bClose = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HowToUseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbAnalyze = New System.Windows.Forms.ProgressBar()
        Me.tbInputFile = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbFIDisc = New System.Windows.Forms.RadioButton()
        Me.bConfIFDisc = New System.Windows.Forms.Button()
        Me.bRunIFDisc = New System.Windows.Forms.Button()
        Me.bRunDxDDisc = New System.Windows.Forms.Button()
        Me.bConfDxD = New System.Windows.Forms.Button()
        Me.rbDxD = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bAnalyze
        '
        Me.bAnalyze.Location = New System.Drawing.Point(11, 80)
        Me.bAnalyze.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.bAnalyze.Name = "bAnalyze"
        Me.bAnalyze.Size = New System.Drawing.Size(299, 27)
        Me.bAnalyze.TabIndex = 0
        Me.bAnalyze.Text = "Analyze Input"
        Me.bAnalyze.UseVisualStyleBackColor = True
        '
        'tbAnalyzeInput
        '
        Me.tbAnalyzeInput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAnalyzeInput.Location = New System.Drawing.Point(11, 117)
        Me.tbAnalyzeInput.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbAnalyzeInput.Multiline = True
        Me.tbAnalyzeInput.Name = "tbAnalyzeInput"
        Me.tbAnalyzeInput.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.tbAnalyzeInput.Size = New System.Drawing.Size(300, 76)
        Me.tbAnalyzeInput.TabIndex = 1
        '
        'bClose
        '
        Me.bClose.Location = New System.Drawing.Point(11, 361)
        Me.bClose.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.bClose.Name = "bClose"
        Me.bClose.Size = New System.Drawing.Size(299, 26)
        Me.bClose.TabIndex = 2
        Me.bClose.Text = "Close"
        Me.bClose.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(319, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 22)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save as..."
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HowToUseToolStripMenuItem, Me.AboutToolStripMenuItem, Me.ToolStripSeparator1, Me.AboutToolStripMenuItem1})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 22)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HowToUseToolStripMenuItem
        '
        Me.HowToUseToolStripMenuItem.Name = "HowToUseToolStripMenuItem"
        Me.HowToUseToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.HowToUseToolStripMenuItem.Text = "How to use"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.AboutToolStripMenuItem.Text = "Error messages"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(150, 6)
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(153, 22)
        Me.AboutToolStripMenuItem1.Text = "About"
        '
        'pbAnalyze
        '
        Me.pbAnalyze.Location = New System.Drawing.Point(11, 335)
        Me.pbAnalyze.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pbAnalyze.Name = "pbAnalyze"
        Me.pbAnalyze.Size = New System.Drawing.Size(299, 16)
        Me.pbAnalyze.TabIndex = 4
        '
        'tbInputFile
        '
        Me.tbInputFile.Location = New System.Drawing.Point(11, 53)
        Me.tbInputFile.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbInputFile.Name = "tbInputFile"
        Me.tbInputFile.Size = New System.Drawing.Size(300, 20)
        Me.tbInputFile.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Input File Directory:"
        '
        'rbFIDisc
        '
        Me.rbFIDisc.AutoSize = True
        Me.rbFIDisc.Enabled = False
        Me.rbFIDisc.Location = New System.Drawing.Point(16, 201)
        Me.rbFIDisc.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rbFIDisc.Name = "rbFIDisc"
        Me.rbFIDisc.Size = New System.Drawing.Size(154, 17)
        Me.rbFIDisc.TabIndex = 12
        Me.rbFIDisc.Text = "Interval Fixed Discretization"
        Me.rbFIDisc.UseVisualStyleBackColor = True
        '
        'bConfIFDisc
        '
        Me.bConfIFDisc.Enabled = False
        Me.bConfIFDisc.Location = New System.Drawing.Point(11, 228)
        Me.bConfIFDisc.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.bConfIFDisc.Name = "bConfIFDisc"
        Me.bConfIFDisc.Size = New System.Drawing.Size(203, 27)
        Me.bConfIFDisc.TabIndex = 15
        Me.bConfIFDisc.Text = "Configure"
        Me.bConfIFDisc.UseVisualStyleBackColor = True
        '
        'bRunIFDisc
        '
        Me.bRunIFDisc.Enabled = False
        Me.bRunIFDisc.Location = New System.Drawing.Point(224, 228)
        Me.bRunIFDisc.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.bRunIFDisc.Name = "bRunIFDisc"
        Me.bRunIFDisc.Size = New System.Drawing.Size(85, 27)
        Me.bRunIFDisc.TabIndex = 17
        Me.bRunIFDisc.Text = "Run"
        Me.bRunIFDisc.UseVisualStyleBackColor = True
        '
        'bRunDxDDisc
        '
        Me.bRunDxDDisc.Enabled = False
        Me.bRunDxDDisc.Location = New System.Drawing.Point(223, 297)
        Me.bRunDxDDisc.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.bRunDxDDisc.Name = "bRunDxDDisc"
        Me.bRunDxDDisc.Size = New System.Drawing.Size(85, 27)
        Me.bRunDxDDisc.TabIndex = 20
        Me.bRunDxDDisc.Text = "Run"
        Me.bRunDxDDisc.UseVisualStyleBackColor = True
        '
        'bConfDxD
        '
        Me.bConfDxD.Enabled = False
        Me.bConfDxD.Location = New System.Drawing.Point(10, 297)
        Me.bConfDxD.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.bConfDxD.Name = "bConfDxD"
        Me.bConfDxD.Size = New System.Drawing.Size(203, 27)
        Me.bConfDxD.TabIndex = 19
        Me.bConfDxD.Text = "Configure"
        Me.bConfDxD.UseVisualStyleBackColor = True
        '
        'rbDxD
        '
        Me.rbDxD.AutoSize = True
        Me.rbDxD.Enabled = False
        Me.rbDxD.Location = New System.Drawing.Point(15, 271)
        Me.rbDxD.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rbDxD.Name = "rbDxD"
        Me.rbDxD.Size = New System.Drawing.Size(145, 17)
        Me.rbDxD.TabIndex = 18
        Me.rbDxD.Text = "DxD Based Discretization"
        Me.rbDxD.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(139, 383)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 21
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(319, 401)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bRunDxDDisc)
        Me.Controls.Add(Me.bConfDxD)
        Me.Controls.Add(Me.rbDxD)
        Me.Controls.Add(Me.bRunIFDisc)
        Me.Controls.Add(Me.bConfIFDisc)
        Me.Controls.Add(Me.rbFIDisc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbInputFile)
        Me.Controls.Add(Me.pbAnalyze)
        Me.Controls.Add(Me.bClose)
        Me.Controls.Add(Me.tbAnalyzeInput)
        Me.Controls.Add(Me.bAnalyze)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReSWMM Tool v 0.3"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bAnalyze As Button
    Friend WithEvents tbAnalyzeInput As TextBox
    Friend WithEvents bClose As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pbAnalyze As ProgressBar
    Friend WithEvents tbInputFile As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents rbFIDisc As RadioButton
    Friend WithEvents bConfIFDisc As Button
    Friend WithEvents bRunIFDisc As Button
    Friend WithEvents bRunDxDDisc As Button
    Friend WithEvents bConfDxD As Button
    Friend WithEvents rbDxD As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents HowToUseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem1 As ToolStripMenuItem
End Class
