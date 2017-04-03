Imports System.Collections.Generic
Public Interface IRelatedObject
    Sub RegisterChildObject(ByVal child As IRelatedObject, Optional ByVal childPostingType As RelatedPostOrder = RelatedPostOrder.PostFirst)
    Sub UnRegisterChildObject(ByVal child As IRelatedObject)
    Function HasChanges() As Boolean
    Function ValidateData() As Boolean
    Function LoadData(ByRef id As Object) As Boolean
    Function GetChildKey(ByVal child As IRelatedObject) As Object
    Property DBService() As db.BaseDbService
    Property ParentObject() As IRelatedObject
    Property baseDataSet() As DataSet
    Property [ReadOnly]() As Boolean
    ReadOnly Property Children() As List(Of IRelatedObject)
End Interface

