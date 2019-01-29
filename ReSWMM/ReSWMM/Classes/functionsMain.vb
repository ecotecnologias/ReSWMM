Imports System
Imports System.IO
Imports System.IO.Directory
Imports Microsoft.VisualBasic.FileIO

Module functionsMain

    '######################################
    '#### GLOBAL VARIABLES DECLARATION ####
    '######################################

    'DOUBLES
    Dim g As Double = 9.81

    '######################################
    '############## FUNCTIONS #############
    '######################################

    'Functions to check if there is more than 1 input file and select one 
    'VERIFY NECESSITY OF THIS   
    Public Function checkInputFiles(ByVal fileDirectory)

        Dim inpFiles As New List(Of String)
        My.Computer.FileSystem.FindInFiles(fileDirectory, "*.inp", True, FileIO.SearchOption.SearchTopLevelOnly)
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(fileDirectory + "\",
    Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.inp")
            inpFiles.Add(foundFile)
        Next
        If inpFiles.Count = 0 Then
            MsgBox("There is no Input file in the directory")
        ElseIf inpFiles.Count = 1 Then
            runAnalysis(inpFiles(0))
            main.tbInputFile.Text() = inpFiles(0)

        Else
            selectInpFile.Show()
            For i = 0 To inpFiles.Count - 1
                selectInpFile.lbInputSelection.Items.Add(inpFiles(i))
            Next
        End If


    End Function

    'Function to run the Analysis
    Public Function runAnalysis(ByVal fileDirectory)

        'Show Retriving Data Form
        retrievingData.Show()
        retrievingData.Refresh()
        retrievingData.ProgressBar2.Maximum = 2

        'DOUBLES
        Dim recomTimeStep, vascTimeStep As Double

        'INTERGERS
        Dim conduitStartLine, conduitEndLine, conduitCounter,
            xsectionCounter, xsectionStartLine, xsectionEndLine As Integer

        'STRINGS
        Dim totalLines() As String = IO.File.ReadAllLines(fileDirectory)
        Dim conduit(100000), conduitData(100000), xsection(100000), xsectionData(100000) As String

        'CONDUITS
        retrievingData.LabelObject.Text = "[CONDUITS]"
        retrievingData.ProgressBar2.Value = 1
        retrievingData.Refresh()
        conduitStartLine = inpData.getStartLine(fileDirectory, "[CONDUITS]")
        conduitEndLine = inpData.getEndLine(fileDirectory, conduitStartLine)
        conduit = inpData.getData(fileDirectory, conduitStartLine)
        conduitCounter = inpData.getElementNumber(conduitStartLine, conduitEndLine)

        'XSECTIONS
        retrievingData.LabelObject.Text = "[XSECTIONS]"
        retrievingData.ProgressBar2.Value = 2
        retrievingData.Refresh()
        xsectionStartLine = inpData.getStartLine(fileDirectory, "[XSECTIONS]")
        xsectionEndLine = inpData.getEndLine(fileDirectory, xsectionStartLine)
        xsection = inpData.getData(fileDirectory, xsectionStartLine)
        xsectionCounter = inpData.getElementNumber(xsectionStartLine, xsectionEndLine)

        'Get the SWMM recommened timestep
        Dim SWMMTimeStep(conduitCounter - 1), GOESTimeStep(conduitCounter - 1) As Double
        Dim conduitsLength(conduitCounter - 1), xsections(conduitCounter - 1) As String

        'Adjust Progress bar
        main.pbAnalyze.Maximum = conduitCounter - 1

        'Close Retriving Data form
        retrievingData.Close()

        For i = 0 To conduitCounter - 1
            'Split the string
            conduitData = conduit(i).Split(vbTab)
            xsectionData = xsection(i).Split(vbTab)

            conduitsLength(i) = conduitData(3)

            'Verify Time-Step
            SWMMTimeStep(i) = conduitData(3) / Math.Sqrt(g * xsectionData(2))
            GOESTimeStep(i) = 0.1 * conduitData(3) / Math.Sqrt(g * xsectionData(2))

            'Progress bar
            main.pbAnalyze.Increment(1)
            main.pbAnalyze.Refresh()
        Next

        'Set recommended time-step
        recomTimeStep = Math.Round(SWMMTimeStep.Min, 2)
        vascTimeStep = Math.Round(GOESTimeStep.Min, 2)
        main.tbAnalyzeInput.Text() = "SWMM recommended time-step: " + recomTimeStep.ToString + " s" & Environment.NewLine &
                                     "Vasconcelos et al. (2018) recommended time-step: " + vascTimeStep.ToString + " s"


        'Verify if there is extremely long conduits
        If conduitsLength.Max / conduitsLength.Min > 4 Then

            main.tbAnalyzeInput.AppendText(Environment.NewLine & "The longest conduit exceeds four times the length of the shortest conduit")
            MsgBox("SWMM Discretization is recommended!")

        End If

        'Clear the progress bar
        main.pbAnalyze.Value() = 0

        'Enable the radio buttons
        main.rbNecessaryDisc.Enabled = True
        main.rbRegularDisc.Enabled = True
        main.rbFIDisc.Enabled = True
        main.rbDxD.Enabled = True

        'Total nodes in the model
        'totalNodes = junctionCounter + outfallCounter + storageCounter '+dividers

    End Function

    'Get directory from Open tab
    Public Function openInputFile() As String

        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        fd.Title = "Search for SWMM Input Files"
        fd.InitialDirectory = "C:\"
        fd.Filter = "SWMM Input Files|*.inp"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
        End If

        Return strFileName


        'Dim myFileDlog As New FolderBrowserDialog()
        'Dim path As String

        'If myFileDlog.ShowDialog() = DialogResult.OK Then

        '    path = myFileDlog.SelectedPath

        'End If

        'Return path

    End Function

    '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    'Function of necessary discretization
    Public Function runNecessaryDiscretization(ByVal fileDirectory)

        Dim conduitStartLine, conduitEndLine, conduitCounter As Integer
        Dim conduit(10000), conduitData(10000) As String

        'Show Retriving Data Form
        retrievingData.Show()
        retrievingData.ProgressBar2.Maximum = 1
        retrievingData.ProgressBar2.Value = 0
        retrievingData.LabelObject.Text = "[CONDUITS]"
        retrievingData.Refresh()


        conduitStartLine = inpData.getStartLine(fileDirectory, "[CONDUITS]")
        conduitEndLine = inpData.getEndLine(fileDirectory, conduitStartLine)
        conduit = inpData.getData(fileDirectory, conduitStartLine)
        conduitCounter = inpData.getElementNumber(conduitStartLine, conduitEndLine)

        retrievingData.ProgressBar2.Value = 1
        retrievingData.Refresh()
        retrievingData.Close()

        Dim conduitsLength(conduitCounter - 1), needDiscConduit(conduitCounter - 1) As String

        For i = 0 To conduitCounter - 1
            'Split the string
            conduitData = conduit(i).Split(vbTab)
            conduitsLength(i) = conduitData(3)
        Next


        For i = 0 To conduitCounter - 1
            If conduitsLength(i) / conduitsLength.Min > 4 Then
                'needDiscConduit() = conduitData(i)

            End If


        Next

    End Function

    Public Function runFunctions(ByVal fileDirectory, type)

        'Manhole Type/DisType
        '0 = Junction
        '1 = Storage Unit

        'INTEGERS
        Dim ManholeType, DiscType,
            evapStartLine, evapEndLine, evapCounter,
            junctionStartLine, junctionEndLine, junctionCounter,
            storageStartLine, storageEndLine, storageCounter,
            outfallStartLine, outfallEndLine, outfallCounter,
            conduitStartLine, conduitEndLine, conduitCounter,
            xsectionStartLine, xsectionEndLine, xsectionCounter,
            lossesStartLine, lossesEndLine, lossesCounter,
            coordinateStartLine, coordinateEndLine, coordinateCounter As Integer

        'DOUBLES
        Dim Mnsa, x1, y1, x2, y2, conduitLength, conduitRoughness,
            inOffset, outOffset, disLength, disLengthAccum, numberOfDisNodes, numberOfDisNodesAccum,
            distance, slopeElev, slopeMaxDepth, distRatio, nodeMaxDepth, nodeElevation, uElev,
            uMaxDepth, uInitDepth, uSurDepth, uAPonded, uNA, uFevap, dElev, dMaxDepth, dInitDepth, dSurDepth,
            dAPonded, dNA, dFevap As Double

        'STRINGS
        Dim junction(100000), conduit(100000), xsection(100000), losses(100000), storage(100000), outfall(100000), coordinate(100000), evap(100000),
            conduitData(8), xsectionData(6), coordData(3), junData(5), storData(12),
            uCurve1(2), dCurve1(2), uCurve, dCurve,
            disNodeName, uDisNodeName, conduitName, uNode,
            dNode, xsectionShape, geom1, geom2, DxDRatio, minInterval, maxInterval, regI,
            geom3, geom4, barrels, culvert,
            kEntry, kExit, kAvg, flap,
            seepage, dShape, uShape As String
        Dim totalLines() As String = IO.File.ReadAllLines(fileDirectory)

        'BOOLEAN
        Dim outfallCheck As Boolean

        '####################################################
        '###### GET DATA AND ADJUST AUXILIAR VARIABLES ######
        '####################################################

        'Show Retriving Data Form
        retrievingData.Show()
        retrievingData.Refresh()
        retrievingData.ProgressBar2.Maximum = 8

        'Get type of discretization
        If configIF.JunMH.Checked Then ManholeType = 0
        If configIF.SuMH.Checked Then ManholeType = 1
        If configIF.JunDis.Checked Then DiscType = 0
        If configIF.SuDis.Checked Then DiscType = 1

        'Get Discretization Data
        If type = 1 Then regI = configRI.RegI.Text()
        If type = 2 Then
            minInterval = configIF.MinI.Text()
            maxInterval = configIF.MaxI.Text()
        End If
        If type = 3 Then DxDRatio = configDxD.DxDRatio.Text()

        'Adjust MNSA
        Mnsa = configDxD.Mnsa.Text()
        totalLines(32) = "MIN_SURFAREA" & vbTab & Mnsa.ToString

        'Auxiliar variables
        outfallCheck = False
        numberOfDisNodesAccum = 0

        'Get data

        'CONDUITS
        retrievingData.LabelObject.Text = "[CONDUITS]"
        retrievingData.ProgressBar2.Value += 1
        retrievingData.Refresh()
        conduitStartLine = inpData.getStartLine(fileDirectory, "[CONDUITS]")
        conduitEndLine = inpData.getEndLine(fileDirectory, conduitStartLine)
        conduit = inpData.getData(fileDirectory, conduitStartLine)
        conduitCounter = inpData.getElementNumber(conduitStartLine, conduitEndLine)

        'XSECTIONS
        retrievingData.LabelObject.Text = "[XSECTIONS]"
        retrievingData.ProgressBar2.Value += 1
        retrievingData.Refresh()
        xsectionStartLine = inpData.getStartLine(fileDirectory, "[XSECTIONS]")
        xsectionEndLine = inpData.getEndLine(fileDirectory, xsectionStartLine)
        xsection = inpData.getData(fileDirectory, xsectionStartLine)
        xsectionCounter = inpData.getElementNumber(xsectionStartLine, xsectionEndLine)

        'LOSSES
        retrievingData.LabelObject.Text = "[LOSSES]"
        retrievingData.ProgressBar2.Value += 1
        retrievingData.Refresh()
        lossesStartLine = inpData.getStartLine(fileDirectory, "[LOSSES]")
        lossesEndLine = inpData.getEndLine(fileDirectory, lossesStartLine)
        losses = inpData.getData(fileDirectory, lossesStartLine)
        lossesCounter = inpData.getElementNumber(lossesStartLine, lossesEndLine)

        'STORAGE UNIT
        retrievingData.LabelObject.Text = "[STORAGE]"
        retrievingData.ProgressBar2.Value += 1
        retrievingData.Refresh()
        storageStartLine = inpData.getStartLine(fileDirectory, "[STORAGE]")
        If storageStartLine = 0 Then
            storageEndLine = 0
            storageCounter = 0
        Else
            storageEndLine = inpData.getEndLine(fileDirectory, storageStartLine)
            storage = inpData.getData(fileDirectory, storageStartLine)
            storageCounter = inpData.getElementNumber(storageStartLine, storageEndLine)
        End If

        'OUTFALLS
        retrievingData.LabelObject.Text = "[OUTFALLS]"
        retrievingData.ProgressBar2.Value += 1
        retrievingData.Refresh()
        outfallStartLine = inpData.getStartLine(fileDirectory, "[OUTFALLS]")
        outfallEndLine = inpData.getEndLine(fileDirectory, outfallStartLine)
        outfall = inpData.getData(fileDirectory, outfallStartLine)
        outfallCounter = inpData.getElementNumber(outfallStartLine, outfallEndLine)

        'COORDINATES
        retrievingData.LabelObject.Text = "[COORDINATES]"
        retrievingData.ProgressBar2.Value += 1
        retrievingData.Refresh()
        coordinateStartLine = inpData.getStartLine(fileDirectory, "[COORDINATES]")
        coordinateEndLine = inpData.getEndLine(fileDirectory, coordinateStartLine)
        coordinate = inpData.getData(fileDirectory, coordinateStartLine)
        coordinateCounter = inpData.getElementNumber(coordinateStartLine, coordinateEndLine)

        'JUNCTIONS
        retrievingData.LabelObject.Text = "[JUNCTIONS]"
        retrievingData.ProgressBar2.Value += 1
        retrievingData.Refresh()
        junctionStartLine = inpData.getStartLine(fileDirectory, "[JUNCTIONS]")
        If junctionStartLine = 0 Then
            junctionEndLine = 0
            junctionCounter = 0
        Else
            junctionEndLine = inpData.getEndLine(fileDirectory, junctionStartLine)
            junction = inpData.getData(fileDirectory, junctionStartLine)
            junctionCounter = inpData.getElementNumber(junctionStartLine, junctionEndLine)
        End If

        'EVAPORATION
        retrievingData.LabelObject.Text = "[EVAPORATION]"
        retrievingData.ProgressBar2.Value += 1
        retrievingData.Refresh()
        evapStartLine = inpData.getStartLine(fileDirectory, "[EVAPORATION]")
        evapEndLine = inpData.getEndLine(fileDirectory, evapStartLine)
        evap = inpData.getData(fileDirectory, evapStartLine)
        evapCounter = inpData.getElementNumber(evapStartLine, evapEndLine)

        'Dim dependent variables
        Dim disLengthList(conduitCounter - 1) As Double

        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        'TRANSFORMAR JUNCOES EXISTENTES EM STORAGE UNIT E VICE VERSA!
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        'Adjust Progress bar
        main.pbAnalyze.Maximum = conduitCounter - 1
        retrievingData.Close()

        For i = 0 To conduitCounter - 1

            'Clear Variables
            uElev = Nothing
            uMaxDepth = Nothing
            dElev = Nothing
            dMaxDepth = Nothing

            'Get conduit data
            conduitData = conduit(i).Split(vbTab)
            conduitName = conduitData(0).Replace(" ", "")
            uNode = conduitData(1).Replace(" ", "")
            dNode = conduitData(2).Replace(" ", "")
            conduitLength = conduitData(3)
            conduitRoughness = conduitData(4)
            inOffset = conduitData(5)
            outOffset = conduitData(6)

            'Get xsection data
            xsectionData = xsection(i).Split(vbTab)
            xsectionShape = xsectionData(1).Replace(" ", "")
            geom1 = xsectionData(2).Replace(" ", "")
            geom2 = xsectionData(3).Replace(" ", "")
            geom3 = xsectionData(4).Replace(" ", "")
            geom4 = xsectionData(5).Replace(" ", "")
            barrels = xsectionData(6)
            culvert = xsectionData(7)

            'Get losses data for the conduit
            For Each loss In losses
                If loss = Nothing Then
                    Exit For
                Else
                    If loss.Split(vbTab)(0).Replace(" ", "") = conduitName Then
                        kEntry = loss.Split(vbTab)(1)
                        kExit = loss.Split(vbTab)(2)
                        kAvg = loss.Split(vbTab)(3)
                        flap = loss.Split(vbTab)(4)
                        seepage = loss.Split(vbTab)(5)
                    End If
                End If
            Next

            'Adjust conduit shape
            If xsectionShape = "IRREGULAR" Then
                MsgBox("IRREGULAR SHAPE NOT WORKING")
                Exit Function
            Else
                'REGULAR INTERVAL
                If type = 1 Then
                    numberOfDisNodes = regI
                    disLength = conduitLength / (numberOfDisNodes + 1)
                End If
                'FIXED INTERVAL
                If type = 2 Then
                    If conduitLength Mod minInterval = 0 Then
                        'numberOfDisNodes is the number of discretization nodes
                        'All nodes inside a conduit is numberOfDisNodes + 2
                        numberOfDisNodes = (conduitLength / minInterval) - 1
                        disLength = minInterval
                    Else
                        'numberOfDisNodes and distLenght are being used in
                        'this loop as auxiliar variables
                        numberOfDisNodes = conduitLength / minInterval
                        If numberOfDisNodes < 1 Then
                            numberOfDisNodes = numberOfDisNodes
                        Else
                            'Create discretization when there is not remainder
                            While Math.Abs(Math.Round(numberOfDisNodes, 0) - numberOfDisNodes) >= 0.0001
                                'Milimiter precision
                                minInterval += 0.0001
                                numberOfDisNodes = conduitLength / minInterval
                            End While
                            disLength = minInterval
                            numberOfDisNodes = numberOfDisNodes - 1
                            'Verify the intervals
                            If disLength > maxInterval Then
                                MsgBox("Please, increase your interval range")
                                main.pbAnalyze.Value = 0
                                Exit Function
                            End If
                        End If
                    End If
                End If
                'DxD BASED INTERVAL
                If type = 3 Then
                    numberOfDisNodes = Math.Round(conduitLength / (DxDRatio * geom1)) - 1
                    disLength = conduitLength / (numberOfDisNodes + 1)
                End If
            End If

            'Print the min and max discretization distance
            disLengthList(i) = disLength

            'Verify if discretization in this conduit is needed and if there is less than 1 node exit for
            If numberOfDisNodes < 1 Or conduitLength <= disLength Then
                'CONDUITS
                functionsAux.InsertArrayElement(totalLines, conduitEndLine,
                                                functionsAux.conduitLineException(conduitName, uNode, dNode,
                                                conduitLength, conduitRoughness, inOffset, outOffset, 0, 0))
                functionsAux.RemoveAt(totalLines, conduitStartLine)
                'XSECTIONS
                functionsAux.InsertArrayElement(totalLines, xsectionEndLine,
                                                functionsAux.xsectionLineException(conduitName, xsectionShape, geom1, geom2, geom3,
                                                geom4, barrels, culvert))
                functionsAux.RemoveAt(totalLines, xsectionStartLine)
                'LOSSES
                If kEntry = "NONE" Or kEntry = Nothing Then
                    functionsAux.InsertArrayElement(totalLines, lossesEndLine,
                                 functionsAux.lossesLineException(conduitName, 0, 0, 0, "NO", 0))

                Else
                    functionsAux.InsertArrayElement(totalLines, lossesEndLine,
                                                 functionsAux.lossesLineException(conduitName, kEntry, kExit, kAvg, flap, seepage))
                End If

                main.pbAnalyze.Increment(1)
                main.pbAnalyze.Refresh()

                Continue For
            End If

            '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            'AJEITAR LOSSES E PARA COLOCAR STORAGE UNIT NO LUGAR DE JUNCTIONS DAI ARRUMAR OS RESULTADOS E MANDAR PRO GOES

            '#########################################################
            '###### JUNCTIONS/STORAGE/CONDUITS/XSECTIONS/LOSSES ######
            '#########################################################

            'Append Junctions right after evaporation
            If junctionStartLine = 0 Then
                functionsAux.InsertArrayElement(totalLines, evapEndLine + 1, "[JUNCTIONS]")
                functionsAux.InsertArrayElement(totalLines, evapEndLine + 2, ";;Name          " &
                                                vbTab & "Elevation " & vbTab & "MaxDepth  " & vbTab &
                                                "InitDepth " & vbTab & "SurDepth  " & vbTab & "Aponded   ")
                functionsAux.InsertArrayElement(totalLines, evapEndLine + 3, ";;--------------" &
                                                vbTab & "----------" & vbTab & "----------" & vbTab &
                                                "----------" & vbTab & "----------" & vbTab & "----------")
                functionsAux.InsertArrayElement(totalLines, evapEndLine + 4, "")
                junctionEndLine = evapEndLine + 4
                junctionStartLine = junctionEndLine
                If storageEndLine <> 3 Then storageEndLine = storageEndLine + 4
                If storageStartLine <> 0 Then storageStartLine = storageStartLine + 4
                If coordinateEndLine <> 3 Then coordinateEndLine = coordinateEndLine + 4
                If coordinateStartLine <> 0 Then coordinateStartLine = coordinateStartLine + 4
                If outfallEndLine <> 3 Then outfallEndLine = outfallEndLine + 4
                If outfallStartLine <> 0 Then outfallStartLine = outfallStartLine + 4
                If conduitEndLine <> 3 Then conduitEndLine = conduitEndLine + 4
                If conduitStartLine <> 0 Then conduitStartLine = conduitStartLine + 4
                If xsectionStartLine <> 0 Then xsectionStartLine = xsectionStartLine + 4
                If xsectionEndLine <> 3 Then xsectionEndLine = xsectionEndLine + 4
                If lossesStartLine <> 0 Then lossesStartLine = lossesStartLine + 4
                If lossesEndLine <> 3 Then lossesEndLine = lossesEndLine + 4

            End If

            'Append Storage Units right after outfalls
            If storageStartLine = 0 Then
                functionsAux.InsertArrayElement(totalLines, outfallEndLine + 1, "[STORAGE]")
                functionsAux.InsertArrayElement(totalLines, outfallEndLine + 2, ";;Name          " &
                                                vbTab & "Elev.   " & vbTab & "MaxDepth  " & vbTab &
                                                "InitDepth  " & vbTab & "Shape     " & vbTab & "Curve Name/Params           " &
                                                vbTab & "N/A     " & vbTab & "Fevap   " & vbTab & "Psi     " &
                                                vbTab & "Ksat    " & vbTab & "IMD     ")
                functionsAux.InsertArrayElement(totalLines, outfallEndLine + 3, ";;--------------" &
                                                vbTab & "--------" & vbTab & "----------" & vbTab & "-----------" &
                                                vbTab & "----------" & vbTab & "----------------------------" &
                                                vbTab & "--------" & vbTab & "--------" & vbTab & "        " & vbTab &
                                                "--------" & vbTab & "--------")
                functionsAux.InsertArrayElement(totalLines, outfallEndLine + 4, "")
                storageEndLine = outfallEndLine + 4
                storageStartLine = storageEndLine
                If conduitEndLine <> 3 Then conduitEndLine = conduitEndLine + 4
                If conduitStartLine <> 0 Then conduitStartLine = conduitStartLine + 4
                If coordinateEndLine <> 3 Then coordinateEndLine = coordinateEndLine + 4
                If coordinateStartLine <> 0 Then coordinateStartLine = coordinateStartLine + 4
                If xsectionStartLine <> 0 Then xsectionStartLine = xsectionStartLine + 4
                If xsectionEndLine <> 3 Then xsectionEndLine = xsectionEndLine + 4
                If lossesStartLine <> 0 Then lossesStartLine = lossesStartLine + 4
                If lossesEndLine <> 3 Then lossesEndLine = lossesEndLine + 4
            End If

            'Append Losses right after xsections
            If lossesStartLine = 0 Then

                functionsAux.InsertArrayElement(totalLines, xsectionEndLine + 1, "[LOSSES]")
                functionsAux.InsertArrayElement(totalLines, xsectionEndLine + 2, ";;Link          " &
                                                vbTab & "Kentry    " & vbTab & "Kexit     " & vbTab &
                                                "Kavg      " & vbTab & "Flap Gate " & vbTab & "Seepage   ")
                functionsAux.InsertArrayElement(totalLines, xsectionEndLine + 3, ";;--------------" &
                                                vbTab & "----------" & vbTab & "----------" & vbTab & "----------" &
                                                vbTab & "----------" & vbTab & "----------")
                functionsAux.InsertArrayElement(totalLines, xsectionEndLine + 4, "")
                lossesEndLine = xsectionEndLine + 4
                lossesStartLine = lossesEndLine
                If coordinateEndLine <> 3 Then coordinateEndLine = coordinateEndLine + 4
                If coordinateStartLine <> 0 Then coordinateStartLine = coordinateStartLine + 4

            End If

            'Verify if upstream or downstream nodes are outfalls and adjust elevation
            For t = 0 To outfallCounter - 1
                If uNode = outfall(t).Split(vbTab)(0).Replace(" ", "") Then
                    uElev = outfall(t).Split(vbTab)(1).Replace(" ", "")
                    uMaxDepth = geom1
                    outfallCheck = True
                End If
                If dNode = outfall(t).Split(vbTab)(0).Replace(" ", "") Then
                    dElev = outfall(t).Split(vbTab)(1).Replace(" ", "")
                    dMaxDepth = geom1
                    outfallCheck = True
                End If
            Next

            'Get Upstream and Downstream Junction Data
            For jun = 0 To junctionCounter - 1
                junData = junction(jun).Split(vbTab)
                If junData(0).Replace(" ", "") = uNode Then
                    uElev = junData(1)
                    uMaxDepth = junData(2)
                    uInitDepth = junData(3)
                    uSurDepth = junData(4)
                    uAPonded = junData(5)
                End If
                If junData(0).Replace(" ", "") = dNode Then
                    dElev = junData(1)
                    dMaxDepth = junData(2)
                    dInitDepth = junData(3)
                    dSurDepth = junData(4)
                    dAPonded = junData(5)
                End If
            Next

            'Verify if there are Storage Units instead of junctions
            If uElev = Nothing Or uMaxDepth = Nothing Or dElev = Nothing Or dMaxDepth = Nothing Then
                For stor = 0 To storageCounter - 1
                    storData = storage(stor).Split(vbTab)
                    If storData(0).Replace(" ", "") = uNode Then
                        uElev = storData(1)
                        uMaxDepth = storData(2)
                        uInitDepth = storData(3)
                        uShape = storData(4)
                        uCurve = storData(5)
                        uNA = storData(6)
                        uFevap = storData(7)
                    End If
                    If storData(0).Replace(" ", "") = dNode Then
                        dElev = storData(1)
                        dMaxDepth = storData(2)
                        dInitDepth = storData(3)
                        dShape = storData(4)
                        dCurve = storData(5)
                        dNA = storData(6)
                        dFevap = storData(7)
                    End If
                Next
            End If

            'Adjust Discretization Length Accumulate variable
            disLengthAccum = disLength

            'Adjust elevations with the offsets
            If inOffset > 0 Then
                uElev = uElev + inOffset
                uMaxDepth = uMaxDepth - inOffset
            End If
            If outOffset > 0 Then
                dElev = dElev + outOffset
                dMaxDepth = dMaxDepth - outOffset
            End If

            For node = 0 To Math.Round(numberOfDisNodes, 2)
                'Verify upstream and downstream nodes elevations, maxdepth and conduits offsets

                If uElev > dElev Then
                    slopeElev = (uElev - dElev) / conduitLength
                    slopeMaxDepth = (uMaxDepth - dMaxDepth) / conduitLength
                    nodeElevation = Math.Round(uElev - disLengthAccum * slopeElev, 4)
                    nodeMaxDepth = Math.Round(uMaxDepth - disLengthAccum * slopeMaxDepth, 4)
                Else
                    slopeElev = (dElev - uElev) / conduitLength
                    slopeMaxDepth = (dMaxDepth - uMaxDepth) / conduitLength
                    nodeElevation = Math.Round(uElev + disLengthAccum * slopeElev, 4)
                    nodeMaxDepth = Math.Round(uMaxDepth + disLengthAccum * slopeMaxDepth, 4)
                End If
                disNodeName = uNode & "_" & dNode & "_" & (node + 1).ToString & "     "

                'Junctions as Discretization nodes
                If DiscType = 0 Then
                    If node <= Math.Round(numberOfDisNodes, 2) - 1 Then

                        '#####################
                        '### UPSTREAM NODE ###
                        '#####################

                        If node = 0 Then

                            'Manhole as Junction
                            If ManholeType = 0 Then

                                'JUNCTIONS
                                functionsAux.InsertArrayElement(totalLines, junctionEndLine,
                                                                functionsAux.junctionLine(uNode, dNode,
                                                                node, nodeElevation, nodeMaxDepth, 0, 0, 0))
                                junctionEndLine += 1
                                outfallStartLine += 1
                                outfallEndLine += 1
                                storageStartLine += 1
                                storageEndLine += 1
                                conduitStartLine += 1
                                conduitEndLine += 1
                                xsectionStartLine += 1
                                xsectionEndLine += 1
                                lossesStartLine += 1
                                lossesEndLine += 1
                                coordinateStartLine += 1
                                coordinateEndLine += 1
                                'CONDUITS 
                                If inOffset = 0 Then
                                    functionsAux.InsertArrayElement(totalLines, conduitEndLine,
                                                                    functionsAux.conduitLine(conduitName, node, uNode,
                                                                    disNodeName, disLength, conduitRoughness, 0, 0, 0, 0))
                                Else
                                    functionsAux.InsertArrayElement(totalLines, conduitEndLine,
                                                                    functionsAux.conduitLine(conduitName, node, uNode,
                                                                    disNodeName, disLength, conduitRoughness, inOffset, 0, 0, 0))
                                End If

                                conduitEndLine += 1
                                xsectionStartLine += 1
                                xsectionEndLine += 1
                                lossesStartLine += 1
                                lossesEndLine += 1
                                coordinateStartLine += 1
                                coordinateEndLine += 1
                                'LOSSES
                                If kEntry = "NONE" Or kEntry = Nothing Then
                                    functionsAux.InsertArrayElement(totalLines, lossesEndLine,
                                                                functionsAux.lossesLine(conduitName, node, 0, 0, 0, "NO", 0))
                                Else
                                    functionsAux.InsertArrayElement(totalLines, lossesEndLine,
                                                                functionsAux.lossesLine(conduitName, node, kEntry, 0, kAvg, flap, seepage))
                                End If
                                'Manhole as Storage Unit
                            Else

                                '!!!!!!!!!!!!!!!!!!
                                'NÃO TA FUNCIONANDO
                                'PAREI AQUI
                                '!!!!!!!!!!!!!!!!!!

                                'STORAGE UNIT
                                functionsAux.InsertArrayElement(totalLines, storageEndLine,
                                                                functionsAux.storageLine(uNode, dNode, node, uElev, uMaxDepth,
                                                                                         uInitDepth, uShape, uCurve, uNA, uFevap))
                                conduitStartLine += 1
                                conduitEndLine += 1
                                xsectionStartLine += 1
                                xsectionEndLine += 1
                                lossesStartLine += 1
                                lossesEndLine += 1
                                coordinateStartLine += 1
                                coordinateEndLine += 1
                                'CONDUITS 
                                functionsAux.InsertArrayElement(totalLines, conduitEndLine,
                                                                    functionsAux.conduitLine(conduitName, node, uNode,
                                                                    disNodeName, disLength, conduitRoughness, 0, 0, 0, 0))
                                conduitEndLine += 1
                                xsectionStartLine += 1
                                xsectionEndLine += 1
                                lossesStartLine += 1
                                lossesEndLine += 1
                                coordinateStartLine += 1
                                coordinateEndLine += 1
                                'LOSSES
                                If kEntry = "NONE" Then
                                    functionsAux.InsertArrayElement(totalLines, lossesEndLine,
                                                                functionsAux.lossesLine(conduitName, node, 0, 0, 0, "NO", 0))
                                Else
                                    functionsAux.InsertArrayElement(totalLines, lossesEndLine,
                                                                functionsAux.lossesLine(conduitName, node, kEntry, 0, kAvg, flap, seepage))
                                End If
                            End If


                            '#######################
                            '### DOWNSTREAM NODE ###
                            '#######################

                        ElseIf node = Math.Round(numberOfDisNodes, 2) - 1 Then
                            'JUNCTIONS
                            functionsAux.InsertArrayElement(totalLines, junctionEndLine,
                                                            functionsAux.junctionLine(uNode, dNode,
                                                            node, nodeElevation, nodeMaxDepth, dInitDepth, 0, 0))
                            junctionEndLine += 1
                            outfallStartLine += 1
                            outfallEndLine += 1
                            storageStartLine += 1
                            storageEndLine += 1
                            conduitStartLine += 1
                            conduitEndLine += 1
                            xsectionStartLine += 1
                            xsectionEndLine += 1
                            lossesStartLine += 1
                            lossesEndLine += 1
                            coordinateStartLine += 1
                            coordinateEndLine += 1
                            'CONDUIT
                            functionsAux.InsertArrayElement(totalLines, conduitEndLine,
                                                            functionsAux.conduitLine(conduitName, node, uDisNodeName,
                                                            disNodeName, disLength, conduitRoughness, 0, 0, 0, 0))

                            conduitEndLine += 1
                            xsectionStartLine += 1
                            xsectionEndLine += 1
                            lossesStartLine += 1
                            lossesEndLine += 1
                            coordinateStartLine += 1
                            coordinateEndLine += 1

                            'LOSSES
                            If kEntry = "NONE" Or kEntry = Nothing Then
                                functionsAux.InsertArrayElement(totalLines, lossesEndLine,
                                                            functionsAux.lossesLine(conduitName, node, 0, 0, 0, "NO", 0))
                            Else
                                functionsAux.InsertArrayElement(totalLines, lossesEndLine,
                                                            functionsAux.lossesLine(conduitName, node, 0, 0, kAvg, "NO", seepage))
                            End If
                        Else
                            'JUNCTIONS
                            functionsAux.InsertArrayElement(totalLines, junctionEndLine,
                                                            functionsAux.junctionLine(uNode, dNode,
                                                            node, nodeElevation, nodeMaxDepth, 0, 0, 0))
                            junctionEndLine += 1
                            outfallStartLine += 1
                            outfallEndLine += 1
                            storageStartLine += 1
                            storageEndLine += 1
                            conduitStartLine += 1
                            conduitEndLine += 1
                            xsectionStartLine += 1
                            xsectionEndLine += 1
                            lossesStartLine += 1
                            lossesEndLine += 1
                            coordinateStartLine += 1
                            coordinateEndLine += 1
                            'CONDUIT
                            functionsAux.InsertArrayElement(totalLines, conduitEndLine,
                                                            functionsAux.conduitLine(conduitName, node, uDisNodeName,
                                                            disNodeName, disLength, conduitRoughness, 0, 0, 0, 0))
                            conduitEndLine += 1
                            xsectionStartLine += 1
                            xsectionEndLine += 1
                            lossesStartLine += 1
                            lossesEndLine += 1
                            coordinateStartLine += 1
                            coordinateEndLine += 1
                            'LOSSES
                            If kEntry = "NONE" Or kEntry = Nothing Then
                                functionsAux.InsertArrayElement(totalLines, lossesEndLine,
                                                            functionsAux.lossesLine(conduitName, node, 0, 0, 0, "NO", 0))

                            Else
                                functionsAux.InsertArrayElement(totalLines, lossesEndLine,
                                                            functionsAux.lossesLine(conduitName, node, 0, 0, kAvg, "NO", seepage))
                            End If
                        End If
                        'XSECTIONS
                        functionsAux.InsertArrayElement(totalLines, xsectionEndLine,
                                                        functionsAux.xsectionLine(conduitName, node, xsectionShape, geom1,
                                                        geom2, geom3, geom4, barrels, culvert))
                        xsectionEndLine += 1
                        lossesStartLine += 1
                        lossesEndLine += 2
                        coordinateStartLine += 2
                        coordinateEndLine += 2


                        '######################
                        '### INTERIOR NODES ###
                        '######################

                    Else
                        'CONDUIT
                        If outOffset = 0 Then
                            functionsAux.InsertArrayElement(totalLines, conduitEndLine,
                                                            functionsAux.conduitLine(conduitName, node, uDisNodeName, dNode,
                                                            disLength, conduitRoughness, 0, 0, 0, 0))
                        Else
                            functionsAux.InsertArrayElement(totalLines, conduitEndLine,
                                                            functionsAux.conduitLine(conduitName, node, uDisNodeName, dNode,
                                                            disLength, conduitRoughness, 0, outOffset, 0, 0))
                        End If

                        conduitEndLine += 1
                        xsectionStartLine += 1
                        xsectionEndLine += 1
                        lossesStartLine += 1
                        lossesEndLine += 1
                        coordinateStartLine += 1
                        coordinateEndLine += 1
                        'XSECTIONS
                        functionsAux.InsertArrayElement(totalLines, xsectionEndLine,
                                                        functionsAux.xsectionLine(conduitName, node, xsectionShape, geom1,
                                                        geom2, geom3, geom4, barrels, culvert))
                        xsectionEndLine += 1
                        lossesStartLine += 1
                        lossesEndLine += 1
                        coordinateStartLine += 1
                        coordinateEndLine += 1
                        'LOSSES
                        If kEntry = "NONE" Or kEntry = Nothing Then
                            functionsAux.InsertArrayElement(totalLines, lossesEndLine,
                                                        functionsAux.lossesLine(conduitName, node, 0, 0, 0, "NO", 0))
                        Else
                            functionsAux.InsertArrayElement(totalLines, lossesEndLine,
                                                        functionsAux.lossesLine(conduitName, node, 0, kExit, kAvg, flap, seepage))
                        End If
                        lossesEndLine += 1
                        coordinateStartLine += 1
                        coordinateEndLine += 1
                    End If

                    'Name of conduit added to be used in the next iteration
                    uDisNodeName = uNode & "_" & dNode & "_" & (node + 1).ToString & "     "

                    '!!!!!!!!!!!!!!!!!
                    'ARRUMAR ISSO AQUI
                    'Storage Unit as Discretization nodes
                Else
                    If node <= Math.Round(numberOfDisNodes, 2) - 1 Then
                        '#####################
                        '### UPSTREAM NODE ###
                        '#####################
                        If node = 0 Then
                            'STORAGE
                            'discretization into the totalLines variable
                            functionsAux.InsertArrayElement(totalLines, storageEndLine,
                                                            functionsAux.storageLine(uNode, dNode,
                                                            node, nodeElevation, nodeMaxDepth, uInitDepth, uShape, uCurve, uNA, uFevap))
                            conduitStartLine += 1
                            conduitEndLine += 1
                            xsectionStartLine += 1
                            xsectionEndLine += 1
                            lossesStartLine += 1
                            lossesEndLine += 1
                            coordinateStartLine += 1
                            coordinateEndLine += 1
                            'CONDUITS 
                            'name adjusted for first conduit   
                            functionsAux.InsertArrayElement(totalLines, conduitEndLine,
                                                                functionsAux.conduitLine(conduitName, node, uNode,
                                                                disNodeName, disLength, conduitRoughness, 0, 0, 0, 0))
                            conduitEndLine += 1
                            xsectionStartLine += 1
                            xsectionEndLine += 1
                            lossesStartLine += 1
                            lossesEndLine += 1
                            coordinateStartLine += 1
                            coordinateEndLine += 1
                            'LOSSES
                            'losses adjusted for first conduit
                            If kEntry = "NONE" Then
                                functionsAux.InsertArrayElement(totalLines, lossesEndLine,
                                                            functionsAux.lossesLine(conduitName, node, 0, 0, 0, "NO", 0))
                            Else
                                functionsAux.InsertArrayElement(totalLines, lossesEndLine,
                                                            functionsAux.lossesLine(conduitName, node, kEntry, 0, kAvg, flap, seepage))
                            End If
                            '#######################
                            '### DOWNSTREAM NODE ###
                            '#######################

                            'STORAGE UNIT
                            'discretization into the totalLines variable
                            'auxFunctions.InsertArrayElement(totalLines, storageEndLine,
                            'auxFunctions.storageLine(uNode, dNode, node, nodeElevation, nodeMaxDepth,))
                            conduitStartLine += 1
                            conduitEndLine += 1
                            xsectionStartLine += 1
                            xsectionEndLine += 1
                            lossesStartLine += 1
                            lossesEndLine += 1
                            coordinateStartLine += 1
                            coordinateEndLine += 1

                        End If

                    End If

                End If
                disLengthAccum += disLength
            Next

            '#######################
            '##### COORDINATES #####
            '#######################

            'Get the coordinates
            For j = 0 To coordinateCounter - 1
                coordData = coordinate(j).Split(vbTab)
                If coordData(0).Replace(" ", "") = uNode Then
                    x1 = coordData(1)
                    y1 = coordData(2)
                End If
                If coordData(0).Replace(" ", "") = dNode Then
                    x2 = coordData(1)
                    y2 = coordData(2)
                End If
            Next

            'Place the discretization coordinates
            For k = 0 To Math.Round(numberOfDisNodes, 2) - 1
                'Without outfall
                If outfallCheck = False Then
                    'Calculate the new coords and add to the totalLines array
                    distance = Math.Sqrt(((x2 - x1) ^ 2) + ((y2 - y1) ^ 2))
                    distRatio = disLength / distance
                    x1 = Math.Round(((1 - distRatio) * x1 + distRatio * x2), 3)
                    y1 = Math.Round(((1 - distRatio) * y1 + distRatio * y2), 3)

                    'Set the Junctions used for discretization into the exportData variable
                    functionsAux.InsertArrayElement(totalLines, coordinateEndLine, functionsAux.coordinatesLine(uNode, dNode, k, x1, y1))
                    'With outfall
                Else
                    'Calculate the new coords and add to the totalLines array
                    distance = Math.Sqrt(((x2 - x1) ^ 2) + ((y2 - y1) ^ 2))
                    distRatio = disLength / distance
                    x1 = Math.Round(((1 - distRatio) * x1 + distRatio * x2), 3)
                    y1 = Math.Round(((1 - distRatio) * y1 + distRatio * y2), 3)

                    If k = Math.Round(numberOfDisNodes, 2) Then
                        Continue For

                    Else
                        'Set the Junctions used for discretization into the exportData variable
                        functionsAux.InsertArrayElement(totalLines, coordinateEndLine, functionsAux.coordinatesLine(uNode, dNode, k, x1, y1))
                    End If
                End If
            Next

            '##########################################
            '##### ADJUSTMENTS FOR NEXT ITERATION #####
            '##########################################

            'Delete the exiting conduit and xsextions
            functionsAux.RemoveAt(totalLines, conduitStartLine)
            functionsAux.RemoveAt(totalLines, xsectionStartLine - 1)
            If kEntry <> "NONE" Then
                functionsAux.RemoveAt(totalLines, lossesStartLine - 2)
                lossesStartLine -= 2
                lossesEndLine -= 3
                coordinateEndLine -= 3
                coordinateStartLine -= 3
                outfallStartLine -= 3
            Else
                lossesStartLine -= 2
                lossesEndLine -= 2
                coordinateEndLine -= 2
                coordinateStartLine -= 2
                outfallStartLine -= 2
            End If

            'Adjust Lines
            conduitEndLine -= 1
            xsectionStartLine -= 1
            xsectionEndLine -= 2

            'Set no losses when there is no losses in the input file
            kEntry = "NONE"

            'Reset outfall boolean
            outfallCheck = False

            'Reset the minInterval
            minInterval = configIF.MinI.Text()

            'Progress bar
            main.pbAnalyze.Increment(1)
            main.pbAnalyze.Refresh()


        Next

        'Set text in the text box
        main.tbAnalyzeInput.AppendText(Environment.NewLine & "---")
        main.tbAnalyzeInput.AppendText(Environment.NewLine & "Max Discretization Length: " + Math.Round(disLengthList.Max(), 2).ToString)
        main.tbAnalyzeInput.AppendText(Environment.NewLine & "Min Discretization Length: " + Math.Round(disLengthList.Min(), 2).ToString)

        'Export File
        Dim file, exportFile As String
        file = fileDirectory
        Dim extension As String = Path.GetExtension(fileDirectory)
        If extension = ".inp" Or extension = ".INP" Then
            exportFile = file.Remove(file.Length - 4) + "_Disc.inp"
        Else
            exportFile = file
        End If

        Dim DiscProject As String = exportFile
        IO.File.WriteAllLines(exportFile, totalLines)
        main.pbAnalyze.Value = 0
        MsgBox("Discretization Successful!")


    End Function

End Module
