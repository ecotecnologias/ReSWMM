Public Class functionsAux

    '####################################################
    '############## SUBS TO ADJUST ARRAYS ###############
    '####################################################

    'Sub to insert in the middle of an array
    Public Shared Sub InsertArrayElement(Of T)(
         ByRef sourceArray() As T,
         ByVal insertIndex As Integer,
         ByVal newValue As T)

        Dim newPosition As Integer
        Dim counter As Integer

        newPosition = insertIndex
        If (newPosition < 0) Then newPosition = 0
        If (newPosition > sourceArray.Length) Then _
           newPosition = sourceArray.Length

        Array.Resize(sourceArray, sourceArray.Length + 1)

        For counter = sourceArray.Length - 2 To newPosition Step -1
            sourceArray(counter + 1) = sourceArray(counter)
        Next counter

        sourceArray(newPosition) = newValue
    End Sub

    'Sub to remove in the middle of an array
    Public Shared Sub RemoveAt(Of T)(ByRef arr As T(), ByVal index As Integer)
        Dim uBound = arr.GetUpperBound(0)
        Dim lBound = arr.GetLowerBound(0)
        Dim arrLen = uBound - lBound

        If index < lBound OrElse index > uBound Then
            Throw New ArgumentOutOfRangeException(
            String.Format("Index must be from {0} to {1}.", lBound, uBound))

        Else
            'create an array 1 element less than the input array
            Dim outArr(arrLen - 1) As T
            'copy the first part of the input array
            Array.Copy(arr, 0, outArr, 0, index)
            'then copy the second part of the input array
            Array.Copy(arr, index + 1, outArr, index, uBound - index)

            arr = outArr
        End If
    End Sub



    '####################################################
    '############## SUBS TO ADJUST STRINGS ##############
    '####################################################

    'Sub to adjust the junctions lines in the SWMM file
    Public Shared Function junctionLine(ByVal uNode, dNode, counter, Elev, MaxDepth, InitDepth, SurDepth, Aponded)

        junctionLine = uNode & "_" & dNode & "_" & (counter + 1).ToString & "     " & vbTab & Elev.ToString &
                       "     " & vbTab & MaxDepth.ToString & "     " & vbTab & InitDepth & "     " & vbTab & SurDepth & "     " & vbTab & Aponded & "     "

    End Function

    'Sub to adjust the conduits lines in the SWMM file
    Public Shared Function conduitLine(ByVal conduitName, counter, uNode, dNode, lenght, conduitRoughness, InOffset, OutOffset, InitFlow, MaxFlow)

        conduitLine = conduitName & "_" & (counter + 1).ToString & "     " & vbTab & uNode & vbTab & "     " &
                      dNode & vbTab & "     " & Math.Round(lenght, 4).ToString &
                      "     " & vbTab & conduitRoughness.ToString & vbTab & "     " & InOffset &
                      "     " & vbTab & OutOffset & "     " & vbTab & InitFlow & "     " & vbTab & MaxFlow

    End Function

    'Sub to adjust the conduits lines in the SWMM file when exception occurs
    Public Shared Function conduitLineException(ByVal conduitName, uNode, dNode, disLength, conduitRoughness, InOffset, OutOffset, InitFlow, MaxFlow)

        conduitLineException = conduitName & "     " & vbTab & uNode & vbTab & "     " &
                               dNode & vbTab & "     " & Math.Round(disLength, 4).ToString &
                               "     " & vbTab & conduitRoughness.ToString & vbTab & "     " & InOffset &
                               "     " & vbTab & OutOffset & "     " & vbTab & InitFlow & "     " & vbTab & MaxFlow

    End Function

    '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    'Sub to adjust the storage lines in the SWMM file
    'NOT READY
    Public Shared Function storageLine(ByVal uNode, dNode, counter, Elev, MaxDepth, InitDepth, Shape, CurveName, NA, Fevap)

        storageLine = uNode & "_" & dNode & "_" & (counter + 1).ToString & "     " & vbTab &
                      Elev.ToString & "     " & vbTab & MaxDepth.ToString &
                      "     " & InitDepth.ToString & "     " & vbTab & Shape & "     " & vbTab & CurveName &
                      NA.ToString & "     " & Fevap.ToString

    End Function

    'Sub to adjust the xsections lines in the SWMM file
    Public Shared Function xsectionLine(ByVal conduitName, counter, shape, geom1, geom2, geom3, geom4, barrels, culvert)

        xsectionLine = conduitName & "_" & (counter + 1).ToString & "     " & vbTab &
                       shape & vbTab & geom1 & vbTab & geom2 & vbTab & geom3 & vbTab &
                       geom4 & vbTab & barrels & vbTab & culvert

    End Function

    'Sub to adjust the xsections lines in the SWMM file when exception occurs
    Public Shared Function xsectionLineException(ByVal conduitName, shape, geom1, geom2, geom3, geom4, barrels, culvert)

        xsectionLineException = conduitName & "     " & vbTab &
                                shape & vbTab & geom1 & vbTab & geom2 &
                                vbTab & geom3 & vbTab & geom4 & vbTab & barrels &
                                vbTab & culvert

    End Function

    'Sub to adjust the losses lines in the SWMM file
    Public Shared Function lossesLine(ByVal conduitName, counter, kEntry, kExit, kAvg, flapGate, seepage)

        lossesLine = conduitName & "_" & (counter + 1).ToString & "     " & vbTab & kEntry & vbTab & kExit & vbTab & kAvg &
                                vbTab & flapGate & vbTab & seepage

    End Function

    'Sub to adjust the losses lines in the SWMM file when exception occurs
    Public Shared Function lossesLineException(ByVal conduitName, kEntry, kExit, kAvg, flapGate, seepage)

        lossesLineException = conduitName & vbTab & kEntry & vbTab & kExit & vbTab & kAvg &
                                vbTab & flapGate & vbTab & seepage

    End Function

    'Sub to adjust the coordinates in the SWMM file
    Public Shared Function coordinatesLine(ByVal uNode, dNode, counter, x1, y1)

        coordinatesLine = uNode & "_" & dNode & "_" & (counter + 1).ToString & vbTab & x1.ToString & vbTab & y1.ToString

    End Function

    'Sub to run SWMM
    Public Shared Function runSWMM(ByVal dll, SWMMDir)

        Dim executablePath As String = System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + "\dlls\"

        Dim mountedPathRun As String

        If dll = 0 Then

            mountedPathRun = executablePath.Remove(0, 6) + "default\swmm5.exe" + " " + SWMMDir + " " + SWMMDir.Remove(SWMMDir.Length - 3) + "rpt " + SWMMDir.Remove(SWMMDir.Length - 3) + "out"
            Shell(mountedPathRun)

        End If

        If dll = 1 Then

            mountedPathRun = executablePath.Remove(0, 6) + "250\swmm5.exe" + " " + SWMMDir + " " + SWMMDir.Remove(SWMMDir.Length - 3) + "rpt " + SWMMDir.Remove(SWMMDir.Length - 3) + "out"
            Shell(mountedPathRun)


        End If

        If dll = 2 Then

            mountedPathRun = executablePath.Remove(0, 6) + "500\swmm5.exe" + " " + SWMMDir + " " + SWMMDir.Remove(SWMMDir.Length - 3) + "rpt " + SWMMDir.Remove(SWMMDir.Length - 3) + "out"
            Shell(mountedPathRun)


        End If

        If dll = 3 Then

            mountedPathRun = executablePath.Remove(0, 6) + "1000\swmm5.exe" + " " + SWMMDir + " " + SWMMDir.Remove(SWMMDir.Length - 3) + "rpt " + SWMMDir.Remove(SWMMDir.Length - 3) + "out"
            Shell(mountedPathRun)


        End If

        MsgBox("SWMM simulation complete! Check for rpt and out files.")

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(SWMMDir.Remove(SWMMDir.Length - 3) + "ini", True)
        file.WriteLine("[Results]")
        file.WriteLine("Saved=1")
        file.Close()

    End Function

End Class
