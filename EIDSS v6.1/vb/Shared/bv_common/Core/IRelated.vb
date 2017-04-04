Imports System.Collections.Generic
Namespace Core
    Public Interface IRelated
        Sub RegisterChild(ByVal child As IRelated, Optional ByVal childPostingType As RelatedPostOrder = RelatedPostOrder.PostFirst)
        Sub UnRegisterChild(ByVal child As IRelated)
        Property ParentRelated() As IRelated
        ReadOnly Property Items() As List(Of IRelated)
        Property PostOrder() As RelatedPostOrder
    End Interface
End Namespace

