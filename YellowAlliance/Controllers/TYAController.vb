Imports System.Net
Imports System.Web.Http

Public Class TYAController
        Inherits ApiController

        Public Function GetEventList() As IHttpActionResult
            '---------------------------------------------------------------
            'Function:  GetEventList 
            'Purpose:   Get list of events from TYA database 
            'Input:     None 
            'Output:    Returns ActionResult object containing list of cEvent objects 
            '---------------------------------------------------------------
            Dim m_cTYAServer As New cTYAServer
            Dim EventList As New List(Of cEvent)

            Try
                EventList = m_cTYAServer.GetEvents()
            Catch ex As Exception
                Dim errmsg = "api/TYA/" & "GetEvents failed! Return Code: " & ex.Message.ToString
                Return Content(HttpStatusCode.InternalServerError, errmsg)
            End Try

            Return Ok(EventList)
        End Function

    Public Function xxx() As IHttpActionResult
        Dim m_cTYAServer As New cTYAServer
        Dim Teamlist As List(Of cTeam)

        Try
            Teamlist = m_cTYAServer.GetTeams()
        Catch ex As Exception
            Dim errmsg = "api/TYA/" & "GetEvents failed! Return Code: " & ex.Message.ToString
            Return Content(HttpStatusCode.InternalServerError, errmsg)
        End Try

        Return Ok(Teamlist)

    End Function

End Class