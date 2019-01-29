Imports System
Imports System.IO
Imports System.IO.Directory
Imports Microsoft.VisualBasic.FileIO


Public Class inpData

    'Function to get the Start Line of an specific element
    Public Shared Function getStartLine(ByVal fileDirectory, element)

        Dim counter As Integer
        Dim totalLines() As String = IO.File.ReadAllLines(fileDirectory)

        Using sr As StreamReader = File.OpenText(fileDirectory)
            While Not sr.EndOfStream
                Dim line As String = sr.ReadLine()
                If line.Contains(element) Then
                    getStartLine = counter + 3
                    Exit While
                End If
                counter += 1
            End While
        End Using

    End Function

    'Function to get the End Line of an specific element
    Public Shared Function getEndLine(ByVal fileDirectory, startLine)

        Dim counter As Integer
        Dim verify As String
        Dim totalLines() As String = IO.File.ReadAllLines(fileDirectory)

        Using sr As StreamReader = File.OpenText(fileDirectory)
            While Not sr.EndOfStream
                Dim line As String = sr.ReadLine()
                For i = startLine To totalLines.Length + 1
                    verify = File.ReadAllLines(fileDirectory).ElementAt(i)
                    If verify = Nothing Or verify.StartsWith(vbTab) Then
                        getEndLine = counter + startLine
                        Exit Function
                    End If
                    counter += 1
                Next
            End While
        End Using

    End Function

    'Function to get the Data of an speficic element
    Public Shared Function getData(ByVal fileDirectory, startLine)

        Dim counter As Integer
        Dim totalLines() As String = IO.File.ReadAllLines(fileDirectory)
        Dim data(100000) As String

        Using sr As StreamReader = File.OpenText(fileDirectory)
            While Not sr.EndOfStream
                Dim line As String = sr.ReadLine()
                For i = startLine To totalLines.Length + 1
                    data(i - startLine) = File.ReadAllLines(fileDirectory).ElementAt(i)
                    If data(i - startLine) = Nothing Or data(i - startLine).StartsWith(vbTab) Then
                        data(i - startLine) = Nothing
                        Return data
                    End If
                Next
            End While
        End Using

    End Function

    'Function to get the number of elements of an speficic element
    Public Shared Function getElementNumber(ByVal startLine, endLine)

        getElementNumber = endLine - startLine

    End Function

End Class
