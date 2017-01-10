'----------------------------------------------------------------------
'Class Name:    cAwardAssignment 
'Author:        Keith Moore     
'Date:          November 2016 
'Purpose:       This object provides data services for the Award Assignment table 
'               in the Yellow Alliance Web Application
'-----------------------------------------------------------------------
Public Class cAwardAssignment
    ' Locale Variables 
    Private m_EventID As String
    Private m_AwardID As String
    Private m_TeamID As String
    Private m_ReceiveName As String

    '-------------------------------------------------------------------
    'Properties 
    '-------------------------------------------------------------------
    Public Property EventID As String
        Get
            Return m_EventID
        End Get
        Set(value As String)
            m_EventID = value
        End Set
    End Property

    Public Property AwardID As String
        Get
            Return m_AwardID
        End Get
        Set(value As String)
            m_AwardID = value
        End Set
    End Property
    Public Property TeamID As String
        Get
            Return m_TeamID
        End Get
        Set(value As String)
            m_TeamID = value
        End Set
    End Property
    Public Property ReceiveName As String
        Get
            Return m_ReceiveName
        End Get
        Set(value As String)
            m_ReceiveName = value
        End Set
    End Property

End Class
