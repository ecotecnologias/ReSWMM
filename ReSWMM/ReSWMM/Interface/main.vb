'*******************************************************************************************
'   ReSWMM
'
'   This tool improves the SWMM simulations by placing dummy nodes in the links
'
'       Begin: 2018-04-06
'       Copyright: Pachaly, R. L.
'       E-mai: robsonleopachaly@yahoo.com.br
'
'*******************************************************************************************

Imports System
Imports System.IO
Imports System.IO.Directory

Public Class main


    '----------------------------------------------------------------------------------------
    'VARIABLES:
    '
    'projectDir = D:\Dropbox\Dropbox\Mestrado\DISSERTACAO\ReSWMM\ReSWMM\bin\Debug\ReSWMM.exe 
    'SWMMDir = D:\Dropbox\Dropbox\Mestrado\DISSERTACAO\Exemplos\Ex1
    'inputDir = 
    'reportDir = 
    'outputDir = 
    '
    '-----------------------------------------------------------------------------------------


    Dim projectDir, SWMMDir, SWMMDirFile, inputDir, reportDir, outputDir As String

    Dim inputParameters, verifyInput As String()

    '----------------------------------------------------------------------------------------
    ' INITIALIZE
    '----------------------------------------------------------------------------------------

    'Sub to load SWMM data when the Add-in is active 
    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Get the directories
        inputParameters = Environment.GetCommandLineArgs()

        'STANDALONE APPLICATION - OPENING A DIRECT .INP FILE
        If inputParameters.Count <= 1 Then
            MsgBox("Select an Input File")
            Exit Sub

        Else
            'ADD ON APPLICATION - OPENING DIRECTLY FROM SWMM .TMP
            inputDir = inputParameters(1)
            tbInputFile.Text() = inputDir

        End If

    End Sub

    '----------------------------------------------------------------------------------------
    ' ANALYZE
    '----------------------------------------------------------------------------------------

    'Sub to analyse the input file
    Private Sub bAnalyze_Click(sender As Object, e As EventArgs) Handles bAnalyze.Click

        'Get SWMM Directory
        SWMMDir = tbInputFile.Text()

        Dim extension As String = Path.GetExtension(SWMMDir)

        'If extension = ".inp" Or ".INP" Then
        'Verify if there are more than 1 inp file in the directory and run analysis
        runAnalysis(SWMMDir)
        'Else


        'End If



    End Sub

    '----------------------------------------------------------------------------------------
    ' NECESSARY DISCRETIZATION
    '----------------------------------------------------------------------------------------

    'If necessary discretization is checked, allow the run button
    Private Sub rbNecessaryDisc_CheckedChanged(sender As Object, e As EventArgs) Handles rbNecessaryDisc.CheckedChanged

        If bRunNecDisc.Enabled() = False Then
            bRunNecDisc.Enabled() = True
        Else
            bRunNecDisc.Enabled() = False
        End If


    End Sub

    'Sub to run the Necessary Discretization
    Private Sub bRunNecDisc_Click(sender As Object, e As EventArgs) Handles bRunNecDisc.Click

        'Get SWMM Directory
        SWMMDir = tbInputFile.Text()
        runNecessaryDiscretization(SWMMDir)

    End Sub

    '----------------------------------------------------------------------------------------
    ' REGULAR DISCRETIZATION
    '----------------------------------------------------------------------------------------

    'If regular discretization is checked, allow the configure button
    Private Sub rbRegularDisc_CheckedChanged(sender As Object, e As EventArgs) Handles rbRegularDisc.CheckedChanged

        If bConfRegDisc.Enabled() = False Then
            bConfRegDisc.Enabled() = True
        Else
            bConfRegDisc.Enabled() = False
        End If


    End Sub

    'Sub to open configuration for regular discretization
    Private Sub bConfRegDisc_Click(sender As Object, e As EventArgs) Handles bConfRegDisc.Click

        configRI.Show()

    End Sub

    'Sub to run the regular discretization
    Private Sub bRunRegDisc_Click(sender As Object, e As EventArgs) Handles bRunRegDisc.Click

        'Get SWMM Directory
        SWMMDir = tbInputFile.Text()
        runFunctions(SWMMDir, 1)

    End Sub

    '----------------------------------------------------------------------------------------
    ' FIXED INTERVAL DISCRETIZATION
    '----------------------------------------------------------------------------------------

    'If interval fixed discretization is checked, allow the configure button
    Private Sub rbDxDDisc_CheckedChanged(sender As Object, e As EventArgs) Handles rbFIDisc.CheckedChanged

        If bConfIFDisc.Enabled() = False Then
            bConfIFDisc.Enabled() = True
        Else
            bConfIFDisc.Enabled() = False
        End If

    End Sub

    'Sub to open configuration for interval fixed discretization
    Private Sub bConfIFDisc_Click(sender As Object, e As EventArgs) Handles bConfIFDisc.Click

        configIF.Show()

    End Sub

    'Sub to run fixed interval discretization
    Private Sub bRunIFDisc_Click(sender As Object, e As EventArgs) Handles bRunIFDisc.Click

        'Get SWMM Directory
        SWMMDir = tbInputFile.Text()
        runFunctions(SWMMDir, 2)

    End Sub

    '----------------------------------------------------------------------------------------
    ' DxD BASED DISCRETIZATION
    '----------------------------------------------------------------------------------------

    'If DxD discretization is checked, allow the configure button
    Private Sub rbDxD_CheckedChanged(sender As Object, e As EventArgs) Handles rbDxD.CheckedChanged

        If bConfDxD.Enabled() = False Then
            bConfDxD.Enabled() = True
        Else
            bConfDxD.Enabled() = False
        End If

    End Sub

    'Sub to open configuration for DxD discretization
    Private Sub bConfDxD_Click(sender As Object, e As EventArgs) Handles bConfDxD.Click

        configDxD.Show()

    End Sub

    'Sub to run DxD discretization
    Private Sub bRunDxDDisc_Click(sender As Object, e As EventArgs) Handles bRunDxDDisc.Click

        'Get SWMM Directory
        SWMMDir = tbInputFile.Text()
        runFunctions(SWMMDir, 3)

    End Sub

    '----------------------------------------------------------------------------------------
    ' STRIP MENU SUB'S
    '----------------------------------------------------------------------------------------

    'Open input file 
    Public Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

        inputDir = openInputFile()
        tbInputFile.Text() = inputDir

    End Sub

    'About 
    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click

        about.Show()

    End Sub

    'Exit
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    '----------------------------------------------------------------------------------------
    ' MAIN INTERFACE
    '----------------------------------------------------------------------------------------

    'Close the main form
    Private Sub bClose_Click(sender As Object, e As EventArgs) Handles bClose.Click
        Me.Close()
    End Sub

End Class
