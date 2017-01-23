Imports System.Data.Odbc
Imports System.Threading.Tasks

'   Class Name:      cTYAServer 
'   Author:          Keith Moore     
'   Date:            November 2016 
'   Description:     The object provides database services for The Yellow Alliance Website     
'   Change history:

Public Class cTYAServer
    'Public Shared logger As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Private sServerName As String = "cTYAServer"

    Public Function GetEvents() As List(Of cEvent)
        '---------------------------------------------------------------------------------------
        'Function:	GetEvents
        'Purpose:	return list of events        
        'Input:     nothing 
        'Returns:   Returns list of cEvent objects 
        '----------------------------------------------------------------------------------- ---> 	
        Dim strSQL As String = ""
        Dim dr As OdbcDataReader
        Dim details As New List(Of cEvent)
        Dim m_cTYADB As New cTYADB

        strSQL = "select eventid, eventdescription,venue,startdate from Events " &
                 " order by startdate"

        'Execute SQL Command 
        Try
            dr = m_cTYADB.ExecDRQuery(strSQL)
            While dr.Read()

                Dim EventRow As New cEvent
                With EventRow
                    .EventID = TestNullLong(dr, 0)
                    .EventDescription = TestNullString(dr, 1)
                    .Venue = TestNullString(dr, 2)
                    .StartDate = TestNullDate(dr, 3)
                End With
                details.Add(EventRow)
            End While

            dr.Close()

        Catch ex As Exception

            Dim strErr As String = BuildErrorMsg("GetNewsItemList", ex.Message.ToString)
            Throw New Exception(strErr)

        Finally
            m_cTYADB.cmd.Dispose()
            m_cTYADB.CloseDataReader()
            m_cTYADB.CloseConnection()
        End Try

        m_cTYADB = Nothing

        Return details
    End Function
    Public Function GetEventbyID(ByVal EventID As Long) As List(Of cEvent)
        '---------------------------------------------------------------------------------------
        'Function:	GetEventbyID
        'Purpose:	return event information for a given event         
        'Input:     Event ID  
        'Returns:   Returns list of cEvent objects 
        '----------------------------------------------------------------------------------- ---> 	
        Dim strSQL As String = ""
        Dim dr As OdbcDataReader
        Dim details As New List(Of cEvent)
        Dim m_cTYADB As New cTYADB

        strSQL = "SELECT E.eventid, E.eventdescription, et.descriptiontext, E.venue, E.startdate" &
                 ", E.enddate, E.city, StateProvTypes.DescriptionText, Countrys.DescriptionText " &
                 " FROM ((Events AS E LEFT JOIN EventTypes AS et ON E.eventtypeid = et.eventtypeid) " &
                 " INNER JOIN StateProvTypes ON E.StateProv = StateProvTypes.StateProvID) " &
                 " INNER JOIN Countrys ON E.Country = Countrys.CountryID " &
                 " Where E.eventid = " & EventID.ToString

        'Execute SQL Command 
        Try
            dr = m_cTYADB.ExecDRQuery(strSQL)
            While dr.Read()

                Dim EventRow As New cEvent
                With EventRow
                    .EventID = TestNullLong(dr, 0)
                    .EventDescription = TestNullString(dr, 1)
                    .EventTypeDescription = TestNullString(dr, 2)
                    .Venue = TestNullString(dr, 3)
                    .StartDate = TestNullDate(dr, 4)
                    .EndDate = TestNullDate(dr, 5)
                    .City = TestNullString(dr, 6)
                    .State = TestNullString(dr, 7)
                    .Country = TestNullString(dr, 8)

                End With
                details.Add(EventRow)
            End While

            dr.Close()

        Catch ex As Exception

            Dim strErr As String = BuildErrorMsg("GetEventbyID", ex.Message.ToString)
            Throw New Exception(strErr)

        Finally
            m_cTYADB.cmd.Dispose()
            m_cTYADB.CloseDataReader()
            m_cTYADB.CloseConnection()
        End Try

        m_cTYADB = Nothing

        Return details
    End Function

    Public Function GetTeams() As List(Of cTeam)
        '---------------------------------------------------------------------------------------
        'Function:	GetTeams
        'Purpose:	return list of teams        
        'Input:     nothing 
        'Returns:   Returns list of cTeam objects 
        '----------------------------------------------------------------------------------- ---> 	
        Dim strSQL As String = ""
        Dim dr As OdbcDataReader
        Dim details As New List(Of cTeam)
        Dim m_cTYADB As New cTYADB

        strSQL = "SELECT T.TeamID,T.TeamNumber,T.TeamNameLong,T.TeamNameShort,T.City,T.StateProv,ST.DescriptionText,T.LeagueID,T.RegionID,T.SchoolName " &
                 " FROM Teams T, StateProvTypes ST " &
                 " order by T.teamnumber "

        'Execute SQL Command 
        Try
            dr = m_cTYADB.ExecDRQuery(strSQL)
            While dr.Read()

                Dim TeamRow As New cTeam
                With TeamRow
                    .TeamID = TestNullLong(dr, 0)
                    .TeamNumber = TestNullLong(dr, 1)
                    .TeamNameLong = TestNullString(dr, 2)
                    .TeamNameShort = TestNullString(dr, 3)
                    .City = TestNullString(dr, 4)
                    .StateProvID = TestNullLong(dr, 5)
                    .StateProv = TestNullString(dr, 6)
                    .LeagueID = TestNullLong(dr, 7)
                    .RegionID = TestNullLong(dr, 8)
                    .SchoolName = TestNullString(dr, 9)

                End With
                details.Add(TeamRow)
            End While

            dr.Close()

        Catch ex As Exception

            Dim strErr As String = BuildErrorMsg("GetTeams", ex.Message.ToString)
            Throw New Exception(strErr)

        Finally
            m_cTYADB.cmd.Dispose()
            m_cTYADB.CloseDataReader()
            m_cTYADB.CloseConnection()
        End Try

        m_cTYADB = Nothing

        Return details
    End Function

    Public Function GetMatchList(ByVal EventID As Long) As List(Of cMatchSchedule)
        '---------------------------------------------------------------------------------------
        'Function:	GetMatchList
        'Purpose:	return list of Matches for a given event        
        'Input:     nothing 
        'Returns:   Returns list of cMatchSchedule objects 
        '----------------------------------------------------------------------------------- ---> 	
        Dim strSQL As String = ""
        Dim dr As OdbcDataReader
        Dim details As New List(Of cMatchSchedule)
        Dim m_cTYADB As New cTYADB
        Dim lSaveMatchID As Long = 0
        Dim bMatchReady As Boolean = False

        Dim wrkEventID As Long
        Dim wrkMatchID As Long
        Dim wrkMatchName As String
        Dim wrkScheduleTime As Date
        Dim wrkRedScore As Long
        Dim wrkBlueScore As Long
        Dim wrkAllianceType As Long
        Dim wrkRedTeamID As Long
        Dim wrkBlueTeamID As Long

        Dim savEventID As Long
        Dim savMatchID As Long = 0
        Dim savMatchName As String = ""
        Dim savScheduleTime As Date
        Dim savRedScore As Long
        Dim savBlueScore As Long
        Dim savRedTeamID1 As Long
        Dim savRedTeamID2 As Long
        Dim savRedTeamID3 As Long
        Dim savBlueTeamID1 As Long
        Dim savBlueTeamID2 As Long
        Dim savBlueTeamID3 As Long

        strSQL = "SELECT M.EventID, M.MatchID, M.MatchName, M.ScheduleTime, M.Redauto+M.redDriver+M.redEndGame+M.redPen AS RedScore, M.Blueauto+M.BlueDriver+M.BlueEndGame+M.BluePen AS BlueScore, S.AllianceType, AllianceTypes.DescriptionText as Alliance_Type, S.TeamID " &
                 " FROM ([Match] AS M LEFT JOIN ScheduleStation AS S ON (M.MatchID = S.MatchID) AND (M.EventID = S.EventID)) LEFT JOIN AllianceTypes ON S.AllianceType = AllianceTypes.AllianceType " &
                 " WHERE M.EventID = " & EventID.ToString &
                 " Order by M.EventID, M.MatchID, M.ScheduleTime,S.AllianceType"

        'Execute SQL Command 
        Try
            dr = m_cTYADB.ExecDRQuery(strSQL)
            While dr.Read()
                'Read in a row from the database and put into MatchRow 
                wrkEventID = TestNullLong(dr, 0)
                wrkMatchID = TestNullLong(dr, 1)
                wrkMatchName = TestNullString(dr, 2)
                wrkScheduleTime = TestNullDate(dr, 3)
                wrkRedScore = TestNullLong(dr, 4)
                wrkBlueScore = TestNullLong(dr, 5)
                wrkAllianceType = TestNullLong(dr, 6)
                If wrkAllianceType = 1 Then
                    wrkRedTeamID = TestNullLong(dr, 8)
                Else
                    wrkBlueTeamID = TestNullLong(dr, 8)
                End If

                'Now process the Matchrow we just loaded 
                'Is this the same record as last time through??
                If wrkMatchID <> savMatchID Then
                    'do we have a stored object to write out ?? 
                    If bMatchReady = True Then
                        'yes - spit out the stored record
                        Dim MatchRow As New cMatchSchedule
                        With MatchRow
                            .EventID = savEventID
                            .MatchID = savMatchID
                            .MatchName = savMatchName
                            .ScheduleTime = savScheduleTime
                            .RedScore = savRedScore
                            .BlueScore = savBlueScore
                            .AllianceType = 0
                            .RedTeamID1 = savRedTeamID1
                            .RedTeamID2 = savRedTeamID2
                            .RedTeamID3 = savRedTeamID3
                            .BlueTeamID1 = savBlueTeamID1
                            .BlueTeamID2 = savBlueTeamID2
                            .BlueTeamID3 = savBlueTeamID3
                        End With
                        details.Add(MatchRow)
                        bMatchReady = False
                    End If

                    'initalize a new object and move MatchRow into it
                    savEventID = wrkEventID
                    savMatchID = wrkMatchID
                    savMatchName = wrkMatchName
                    savScheduleTime = wrkScheduleTime
                    savRedScore = wrkRedScore
                    savBlueScore = wrkBlueScore
                    If wrkAllianceType = 1 Then
                        savRedTeamID1 = wrkRedTeamID
                        savRedTeamID2 = 0
                        savRedTeamID3 = 0
                        savBlueTeamID1 = 0
                        savBlueTeamID2 = 0
                        savBlueTeamID3 = 0
                    Else
                        savBlueTeamID1 = wrkBlueTeamID
                        savBlueTeamID2 = 0
                        savBlueTeamID3 = 0
                        savRedTeamID1 = 0
                        savRedTeamID2 = 0
                        savRedTeamID3 = 0
                    End If
                    bMatchReady = True

                Else
                    'This is the same match as last time through-just add the team ID to it 
                    If wrkAllianceType = 1 Then
                        'must be a red alliance
                        If savRedTeamID1 = 0 Then
                            savRedTeamID1 = wrkRedTeamID
                        Else
                            If savRedTeamID2 = 0 Then
                                savRedTeamID2 = wrkRedTeamID
                            Else
                                savRedTeamID3 = wrkRedTeamID
                        End If
                    End If

                    Else
                        'mustbe a blue alliance 
                        If savBlueTeamID1 = 0 Then
                            savBlueTeamID1 = wrkBlueTeamID
                        Else
                            If savBlueTeamID2 = 0 Then
                                savBlueTeamID2 = wrkBlueTeamID
                            Else
                                savBlueTeamID3 = wrkBlueTeamID
                            End If
                        End If
                    End If
                End If
            End While
            'check to ensure that the last saved record has been written out 
            'do we have a stored object to write out ?? 
            If bMatchReady = True Then
                'yes - spit out the stored record
                Dim MatchRow As New cMatchSchedule
                With MatchRow
                    .EventID = savEventID
                    .MatchID = savMatchID
                    .MatchName = savMatchName
                    .ScheduleTime = savScheduleTime
                    .RedScore = savRedScore
                    .BlueScore = savBlueScore
                    .AllianceType = 0
                    .RedTeamID1 = savRedTeamID1
                    .RedTeamID2 = savRedTeamID2
                    .RedTeamID3 = savRedTeamID3
                    .BlueTeamID1 = savBlueTeamID1
                    .BlueTeamID2 = savBlueTeamID2
                    .BlueTeamID3 = savBlueTeamID3
                End With
                details.Add(MatchRow)
                bMatchReady = False
            End If


            dr.Close()

        Catch ex As Exception
            Dim strErr As String = BuildErrorMsg("Get MatchList", ex.Message.ToString)
            Throw New Exception(strErr)
        Finally
            m_cTYADB.cmd.Dispose()
            m_cTYADB.CloseDataReader()
            m_cTYADB.CloseConnection()
        End Try

        m_cTYADB = Nothing

        Return details
    End Function
    Public Function GetRankingList(ByVal EventID As Long) As List(Of cRankings)
        '---------------------------------------------------------------------------------------
        'Function:	GetRankingList
        'Purpose:	return ranking list         
        'Input:     Event ID 
        'Returns:   Returns list of cRanking objects 
        '----------------------------------------------------------------------------------- ---> 	
        Dim strSQL As String = ""
        Dim dr As OdbcDataReader
        Dim details As New List(Of cRankings)
        Dim m_cTYADB As New cTYADB

        strSQL = "select tr.rank, t.teamnumber,t.teamnamelong,tr.qualifyingpoints, tr.rankingpoints, tr.highscore,tr.matches " &
                 " From teamranking tr " &
                 " left join teams T on tr.teamid = t.teamid " &
                 " where tr.eventid = " & EventID.ToString &
                 " order by tr.rank "

        'Execute SQL Command 
        Try
            dr = m_cTYADB.ExecDRQuery(strSQL)
            While dr.Read()

                Dim RankingRow As New cRankings
                With RankingRow
                    .RankID = TestNullLong(dr, 0)
                    .TeamNumber = TestNullLong(dr, 1)
                    .TeamName = TestNullString(dr, 2)
                    .QualificationPoints = TestNullLong(dr, 3)
                    .RankingPoints = TestNullLong(dr, 4)
                    .Highestpoints = TestNullLong(dr, 5)
                    .MatchCount = TestNullLong(dr, 6)
                End With
                details.Add(RankingRow)
            End While

            dr.Close()

        Catch ex As Exception

            Dim strErr As String = BuildErrorMsg("GetRankings", ex.Message.ToString)
            Throw New Exception(strErr)

        Finally
            m_cTYADB.cmd.Dispose()
            m_cTYADB.CloseDataReader()
            m_cTYADB.CloseConnection()
        End Try

        m_cTYADB = Nothing

        Return details
    End Function

    Public Function GetTeambyTeamNumber(TeamNumber As Long) As List(Of cTeam)
        '---------------------------------------------------------------------------------------
        'Function:	GetTeambyTeamNumber 
        'Purpose:	Get information about a specific team         
        'Input:     nothing 
        'Returns:   Returns list of cTeam objects 
        '----------------------------------------------------------------------------------- ---> 	
        Dim strSQL As String = ""
        Dim dr As OdbcDataReader
        Dim details As New List(Of cTeam)
        Dim m_cTYADB As New cTYADB

        strSQL = "SELECT T.TeamID,T.TeamNumber,T.TeamNameLong,T.TeamNameShort,T.City,T.StateProv,ST.DescriptionText,T.LeagueID,T.RegionID,T.SchoolName " &
                 " FROM Teams T, StateProvTypes ST " &
                 " where T.TeamNumber = " & TeamNumber.ToString

        'Execute SQL Command 
        Try
            dr = m_cTYADB.ExecDRQuery(strSQL)
            While dr.Read()

                Dim TeamRow As New cTeam
                With TeamRow
                    .TeamID = TestNullLong(dr, 0)
                    .TeamNumber = TestNullLong(dr, 1)
                    .TeamNameLong = TestNullString(dr, 2)
                    .TeamNameShort = TestNullString(dr, 3)
                    .City = TestNullString(dr, 4)
                    .StateProvID = TestNullLong(dr, 5)
                    .StateProv = TestNullString(dr, 6)
                    .LeagueID = TestNullLong(dr, 7)
                    .RegionID = TestNullLong(dr, 8)
                    .SchoolName = TestNullString(dr, 9)

                End With
                details.Add(TeamRow)
            End While

            dr.Close()

        Catch ex As Exception

            Dim strErr As String = BuildErrorMsg("GetTeam", ex.Message.ToString)
            Throw New Exception(strErr)

        Finally
            m_cTYADB.cmd.Dispose()
            m_cTYADB.CloseDataReader()
            m_cTYADB.CloseConnection()
        End Try

        m_cTYADB = Nothing

        Return details
    End Function

    Public Function GetMatchHistory(ByVal TeamNumber As Long) As List(Of cMatchSchedule)
        '---------------------------------------------------------------------------------------
        'Function:	GetMatchHistory
        'Purpose:	return list of Matches that a given team participated in         
        'Input:     nothing 
        'Returns:   Returns list of cMatchSchedule objects 
        '----------------------------------------------------------------------------------- ---> 	
        Dim strSQL As String = ""
        Dim dr As OdbcDataReader
        Dim details As New List(Of cMatchSchedule)
        Dim m_cTYADB As New cTYADB
        Dim lSaveMatchID As Long = 0
        Dim bMatchReady As Boolean = False

        Dim wrkEventID As Long
        Dim wrkEventName As String
        Dim wrkMatchID As Long
        Dim wrkMatchName As String
        Dim wrkScheduleTime As Date
        Dim wrkRedScore As Long
        Dim wrkBlueScore As Long
        Dim wrkAllianceType As Long
        Dim wrkRedTeamID As Long
        Dim wrkBlueTeamID As Long

        Dim savEventID As Long
        Dim savEventName As String = ""
        Dim savMatchID As Long = 0
        Dim savMatchName As String = ""
        Dim savScheduleTime As Date
        Dim savRedScore As Long
        Dim savBlueScore As Long
        Dim savRedTeamID1 As Long
        Dim savRedTeamID2 As Long
        Dim savRedTeamID3 As Long
        Dim savBlueTeamID1 As Long
        Dim savBlueTeamID2 As Long
        Dim savBlueTeamID3 As Long

        strSQL = "SELECT M.EventID, Events.EventDescription, M.MatchID, M.MatchName, M.ScheduleTime, M.Redauto+M.redDriver+M.redEndGame+M.redPen AS RedScore" &
                 ", M.Blueauto+M.BlueDriver+M.BlueEndGame+M.BluePen AS BlueScore, S.AllianceType" &
                 ", AllianceTypes.DescriptionText AS Alliance_Type, S.TeamID " &
                 " FROM (([Match] AS M LEFT JOIN ScheduleStation AS S ON (M.EventID = S.EventID) AND (M.MatchID = S.MatchID)) " &
                 " LEFT JOIN AllianceTypes ON S.AllianceType = AllianceTypes.AllianceType) " &
                 " INNER JOIN Events ON M.EventID = Events.EventID " &
                 " WHERE M.MatchID In " &
                 "   (select matchid from schedulestation where teamid = " & TeamNumber.ToString & ")" &
                 " ORDER BY Events.startdate, M.EventID, M.MatchID, M.ScheduleTime, S.AllianceType"


        'Execute SQL Command 
        Try
            dr = m_cTYADB.ExecDRQuery(strSQL)
            While dr.Read()
                'Read in a row from the database and put into MatchRow 
                wrkEventID = TestNullLong(dr, 0)
                wrkEventName = TestNullString(dr, 1)
                wrkMatchID = TestNullLong(dr, 2)
                wrkMatchName = TestNullString(dr, 3)
                wrkScheduleTime = TestNullDate(dr, 4)
                wrkRedScore = TestNullLong(dr, 5)
                wrkBlueScore = TestNullLong(dr, 6)
                wrkAllianceType = TestNullLong(dr, 7)
                If wrkAllianceType = 1 Then
                    wrkRedTeamID = TestNullLong(dr, 9)
                Else
                    wrkBlueTeamID = TestNullLong(dr, 9)
                End If

                'Now process the Matchrow we just loaded 
                'Is this the same record as last time through??
                If wrkMatchID <> savMatchID Then
                    'do we have a stored object to write out ?? 
                    If bMatchReady = True Then
                        'yes - spit out the stored record
                        Dim MatchRow As New cMatchSchedule
                        With MatchRow
                            .EventID = savEventID
                            .EventName = savEventName
                            .MatchID = savMatchID
                            .MatchName = savMatchName
                            .ScheduleTime = savScheduleTime
                            .RedScore = savRedScore
                            .BlueScore = savBlueScore
                            .AllianceType = 0
                            .RedTeamID1 = savRedTeamID1
                            .RedTeamID2 = savRedTeamID2
                            .RedTeamID3 = savRedTeamID3
                            .BlueTeamID1 = savBlueTeamID1
                            .BlueTeamID2 = savBlueTeamID2
                            .BlueTeamID3 = savBlueTeamID3
                        End With
                        details.Add(MatchRow)
                        bMatchReady = False
                    End If

                    'initalize a new object and move MatchRow into it
                    savEventID = wrkEventID
                    savEventName = wrkEventName
                    savMatchID = wrkMatchID
                    savMatchName = wrkMatchName
                    savScheduleTime = wrkScheduleTime
                    savRedScore = wrkRedScore
                    savBlueScore = wrkBlueScore
                    If wrkAllianceType = 1 Then
                        savRedTeamID1 = wrkRedTeamID
                        savRedTeamID2 = 0
                        savRedTeamID3 = 0
                        savBlueTeamID1 = 0
                        savBlueTeamID2 = 0
                        savBlueTeamID3 = 0
                    Else
                        savBlueTeamID1 = wrkBlueTeamID
                        savBlueTeamID2 = 0
                        savBlueTeamID3 = 0
                        savRedTeamID1 = 0
                        savRedTeamID2 = 0
                        savRedTeamID3 = 0
                    End If
                    bMatchReady = True

                Else
                    'This is the same match as last time through-just add the team ID to it 
                    If wrkAllianceType = 1 Then
                        'must be a red alliance
                        If savRedTeamID1 = 0 Then
                            savRedTeamID1 = wrkRedTeamID
                        Else
                            If savRedTeamID2 = 0 Then
                                savRedTeamID2 = wrkRedTeamID
                            Else
                                savRedTeamID3 = wrkRedTeamID
                            End If
                        End If

                    Else
                        'mustbe a blue alliance 
                        If savBlueTeamID1 = 0 Then
                            savBlueTeamID1 = wrkBlueTeamID
                        Else
                            If savBlueTeamID2 = 0 Then
                                savBlueTeamID2 = wrkBlueTeamID
                            Else
                                savBlueTeamID3 = wrkBlueTeamID
                            End If
                        End If
                    End If
                End If
            End While
            'check to ensure that the last saved record has been written out 
            'do we have a stored object to write out ?? 
            If bMatchReady = True Then
                'yes - spit out the stored record
                Dim MatchRow As New cMatchSchedule
                With MatchRow
                    .EventID = savEventID
                    .EventName = savEventName
                    .MatchID = savMatchID
                    .MatchName = savMatchName
                    .ScheduleTime = savScheduleTime
                    .RedScore = savRedScore
                    .BlueScore = savBlueScore
                    .AllianceType = 0
                    .RedTeamID1 = savRedTeamID1
                    .RedTeamID2 = savRedTeamID2
                    .RedTeamID3 = savRedTeamID3
                    .BlueTeamID1 = savBlueTeamID1
                    .BlueTeamID2 = savBlueTeamID2
                    .BlueTeamID3 = savBlueTeamID3
                End With
                details.Add(MatchRow)
                bMatchReady = False
            End If

            dr.Close()

        Catch ex As Exception
            Dim strErr As String = BuildErrorMsg("Get MatchHistory", ex.Message.ToString)
            Throw New Exception(strErr)
        Finally
            m_cTYADB.cmd.Dispose()
            m_cTYADB.CloseDataReader()
            m_cTYADB.CloseConnection()
        End Try

        m_cTYADB = Nothing

        Return details
    End Function
    Public Function GetTeamsAtEvent(ByVal EventID As Long) As List(Of cTeam)
        '---------------------------------------------------------------------------------------
        'Function:	GetTeamsAtEvent
        'Purpose:	return list of teams attending a particular event         
        'Input:     Event ID  
        'Returns:   Returns list of cTeam objects 
        '----------------------------------------------------------------------------------- ---> 	
        Dim strSQL As String = ""
        Dim dr As OdbcDataReader
        Dim details As New List(Of cTeam)
        Dim m_cTYADB As New cTYADB

        strSQL = "SELECT T.TeamID,T.TeamNumber,T.TeamNameLong,T.TeamNameShort,T.City,T.StateProv,ST.DescriptionText,T.LeagueID,T.RegionID,T.SchoolName " &
                 " FROM Teams T, StateProvTypes ST, EventTeams ET " &
                 " where ET.eventID = " & EventID.ToString &
                 " and t.teamID = et.TeamID " &
                 " order by T.teamnumber "

        'Execute SQL Command 
        Try
            dr = m_cTYADB.ExecDRQuery(strSQL)
            While dr.Read()

                Dim TeamRow As New cTeam
                With TeamRow
                    .TeamID = TestNullLong(dr, 0)
                    .TeamNumber = TestNullLong(dr, 1)
                    .TeamNameLong = TestNullString(dr, 2)
                    .TeamNameShort = TestNullString(dr, 3)
                    .City = TestNullString(dr, 4)
                    .StateProvID = TestNullLong(dr, 5)
                    .StateProv = TestNullString(dr, 6)
                    .LeagueID = TestNullLong(dr, 7)
                    .RegionID = TestNullLong(dr, 8)
                    .SchoolName = TestNullString(dr, 9)

                End With
                details.Add(TeamRow)
            End While

            dr.Close()

        Catch ex As Exception

            Dim strErr As String = BuildErrorMsg("GetTeamsAtEvent", ex.Message.ToString)
            Throw New Exception(strErr)

        Finally
            m_cTYADB.cmd.Dispose()
            m_cTYADB.CloseDataReader()
            m_cTYADB.CloseConnection()
        End Try

        m_cTYADB = Nothing

        Return details
    End Function





    '---------------------------------------------------------------------------------------------------
    '  Private Functions 
    '---------------------------------------------------------------------------------------------------
    Private Function BuildErrorMsg(ByVal strFunctionName As String, strThrownError As String) As String
        '---------------------------------------------------------------------------------------
        'Function:	BuildErrorMsg
        'Purpose:	Combine error details into a single message string containg server name, 
        '           Function throwing() Error And Error message text 
        'Input:     function anme and thrown error text   
        'Returns:   Returns string with combined error text 
        '----------------------------------------------------------------------------------- ---> 	
        Dim strErrMsg As String
        strErrMsg = sServerName & ":" & strFunctionName & " failed! Return Code: " & strThrownError

        '  logger.Error(strErrMsg)

        Return strErrMsg
    End Function

End Class
