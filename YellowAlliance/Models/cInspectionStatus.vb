'----------------------------------------------------------------------
'Class Name:    cInspectionStatus 
'Author:        Keith Moore     
'Date:          November 2016 
'Purpose:       This object provides data services for the Inspection Status table 
'               in the Yellow Alliance Web Application
'-----------------------------------------------------------------------
Public Class cInspectionStatus
    ' Locale Variables 
    Private m_InspectionStatusKey As String
    Private m_EventID As String
    Private m_TeamID As String
    Private m_Hardware As Integer
    Private m_Field As Integer
    Private m_Completed As Integer

    '-------------------------------------------------------------------
    'Properties 
    '-------------------------------------------------------------------
    Public Property InspectionStatusKey As String
        Get
            Return m_InspectionStatusKey
        End Get
        Set(value As String)
            m_InspectionStatusKey = value
        End Set
    End Property
    Public Property EventID As String
        Get
            Return m_EventID
        End Get
        Set(value As String)
            m_EventID = value
        End Set
    End Property

    Public Property Hardware As Integer
        Get
            Return m_Hardware
        End Get
        Set(value As Integer)
            m_Hardware = value
        End Set
    End Property
    Public Property Field As Integer
        Get
            Return m_Field
        End Get
        Set(value As Integer)
            m_Field = value
        End Set
    End Property
    Public Property Completed As Integer
        Get
            Return m_Completed
        End Get
        Set(value As Integer)
            m_Completed = value
        End Set
    End Property

End Class
