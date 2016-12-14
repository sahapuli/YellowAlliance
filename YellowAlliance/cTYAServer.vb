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

        strSQL = "select eventid, eventdescription,venue,startdate from tya_core.Events " &
                 " order by startdate"

        'Execute SQL Command 
        Try
            dr = m_cTYADB.ExecDRQuery(strSQL)
            While dr.Read()

                Dim EventRow As New cEvent
                With EventRow
                    .EventID = TestNullString(dr, 0)
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

        strSQL = "SELECT TeamID,TeamNumber,TeamNameLong,TeamNameShort,City,StateProv,LeagueID,RegionID " &
                 " FROM tya_core.Teams " &
                 " order by teamnumber "

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
                    .StateProv = TestNullString(dr, 5)
                    .LeagueID = TestNullLong(dr, 6)
                    .RegionID = TestNullString(dr, 7)
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

    Public Function GetMatchList(ByVal MatchID As String) As List(Of cMatchSchedule)
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

        strSQL = "select eventid,matchid,redscore,bluescore,redteamid1,redteamid2,redteamid3,blueteamid1,blueteamid2,blueteamid3 " &
                 " from tya_core.MatchSchedule " &
                 " where eventid = " & strQuote & MatchID & strQuote &
                 " order by eventid, matchid"

        'Execute SQL Command 
        Try
            dr = m_cTYADB.ExecDRQuery(strSQL)
            While dr.Read()

                Dim MatchRow As New cMatchSchedule
                With MatchRow
                    .EventID = TestNullString(dr, 0)
                    .MatchID = TestNullString(dr, 1)
                    .RedScore = TestNullLong(dr, 2)
                    .BlueScore = TestNullLong(dr, 3)
                    .RedTeamID1 = TestNullLong(dr, 4)
                    .RedTeamID2 = TestNullLong(dr, 5)
                    .RedTeamID3 = TestNullLong(dr, 6)
                    .BlueTeamID1 = TestNullLong(dr, 7)
                    .BlueTeamID2 = TestNullLong(dr, 8)
                    .BlueTeamID3 = TestNullLong(dr, 9)
                End With
                details.Add(MatchRow)
            End While

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
