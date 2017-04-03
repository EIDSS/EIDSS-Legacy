Imports System.Windows.Forms
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Imports bv.common.Objects

Public Class CategoryComparer
    Implements IComparer

    ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
       Implements IComparer.Compare
        If TypeOf (x) Is MenuCategory AndAlso TypeOf (y) Is MenuCategory Then
            Return CType(x, MenuCategory).Order - CType(y, MenuCategory).Order
        End If
        Throw New ArgumentException("object is not a MenuCategory")
    End Function 'IComparer.Compare

End Class 'CategoryComparer

Public Class MenuActionComparer
    Implements IComparer

    ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
       Implements IComparer.Compare
        If TypeOf (x) Is MenuAction AndAlso TypeOf (y) Is MenuAction Then
            Return CType(x, MenuAction).Order - CType(y, MenuAction).Order
        End If
        Throw New ArgumentException("object is not a MenuAction")
    End Function 'IComparer.Compare

End Class 'CategoryComparer

Public Class MenuCategory
    Public Caption As String
    Public Order As Integer
    Public Items As ArrayList
    Public ImageIndex As Integer
    Public BigImageIndex As Integer
    Public ShowInToolbar As Boolean
    Public BeginGroup As Boolean
    Sub New(ByVal aName As String, Optional ByVal aOrder As Integer = 10000, Optional ByVal aImageIndex As Integer = -1)
        Caption = aName
        Order = aOrder
        ImageIndex = aImageIndex
        Items = New ArrayList
        m_AssemblyName = MenuActionManager.LoadingAssembly

    End Sub
    Private m_AssemblyName As String
    Public ReadOnly Property AssemblyName() As String
        Get
            Return m_AssemblyName
        End Get
    End Property

End Class
Public Class MenuActionManager
    Private Shared m_MenuCategories As New ArrayList
    'Private Shared m_Toolbar As New ToolBar
    Private Shared m_MainForm As Form
    'Private Shared m_MainMenu As MainMenu
    Private Shared m_BarManager As DevExpress.XtraBars.BarManager
    Private Shared m_Bar As DevExpress.XtraBars.Bar
    Public Shared SubCategoies As New Hashtable
#Region "Public methods"
    Private Shared m_ShowButtonCaption As Boolean = False
    'Public Shared Sub Init(ByVal mainForm As Form, ByVal menu As MainMenu, ByVal tb As ToolBar)
    '    m_MainForm = mainForm
    '    m_MainMenu = menu
    '    m_Toolbar = tb
    '    m_BarManager = Nothing
    '    m_Bar = Nothing
    '    AddHandler m_Toolbar.ButtonClick, AddressOf Toolbar_Click
    '    Clear()
    'End Sub

    Public Shared Sub Init(ByVal mainForm As Form, ByVal aBarManager As DevExpress.XtraBars.BarManager, ByVal aBar As DevExpress.XtraBars.Bar)
        m_BarManager = aBarManager
        m_Bar = aBar
        m_MainForm = mainForm
        'm_MainMenu = Nothing
        'm_Toolbar = Nothing
        Clear()
    End Sub

    Shared m_itemOrder As Integer = 1
    Public Shared Function RegisterAction(ByVal a As MenuAction) As MenuAction
        Dim c As MenuCategory = GetCategory(a.Category)
        If a.Order = 0 Then
            m_itemOrder += 1
            a.Order = m_itemOrder
        Else
            m_itemOrder = a.Order
        End If
        c.Items.Add(a)
        Return a
    End Function

    Public Shared Function RegisterAction(ByVal Parent As String, ByVal a As MenuAction) As MenuAction
        Dim parentAction As MenuAction
        parentAction = MenuActionManager.GetSubCategory(Parent, a.Category)
        If (parentAction Is Nothing) Then
            Throw New ApplicationException(String.Format("Undefine {0} menu item", Parent))
        End If
        parentAction.Items.Add(a)
        Return a
    End Function
    Public Shared LoadingAssembly As String = Nothing
    Public Shared Sub LoadAssemblyActions(ByVal AssmblyName As String)
        Try
            Dim a As [Assembly] = [Assembly].LoadFrom(AssmblyName)
            LoadingAssembly = a.GetName.Name
            Dim mytypes As Type() = a.GetTypes()
            Dim flags As BindingFlags = BindingFlags.Public Or BindingFlags.Static Or _
                BindingFlags.Instance Or BindingFlags.DeclaredOnly

            Dim t As Type
            Dim ShowWorkingFormsOnly As Boolean = False
            If Config.GetSetting("ShowWorkingFormsOnly") = "True" Then
                ShowWorkingFormsOnly = True
            End If
            For Each t In mytypes
                Dim m As MethodInfo = t.GetMethod("Register", flags)
                If Not m Is Nothing Then
                    Dim RegisterAction As Boolean = True
                    If ShowWorkingFormsOnly Then
                        Dim pi As PropertyInfo = t.GetProperty("Status")
                        If Not pi Is Nothing Then
                            Dim bf As Object = Nothing
                            Try
                                bf = ClassLoader.LoadClass(t.Name)
                            Catch ex As Exception
                                RegisterAction = False
                            End Try
                            If Not bf Is Nothing AndAlso TypeOf (bf) Is BaseForm AndAlso pi.GetValue(bf, Nothing).ToString = "Demo" Then RegisterAction = False
                        End If
                    End If
                    If RegisterAction Then
                        Dim Params() As Object = {m_MainForm}
                        Try
                            m.Invoke(Nothing, Params)
                        Catch ex As Exception
                            Trace.WriteLine(ex)
                            If Not ex.InnerException Is Nothing Then
                                Trace.WriteLine(ex.InnerException)
                            End If
                        End Try
                    End If
                End If

            Next t

        Catch ex As Exception
            Dbg.Debug("error during loading assembly {0}", AssmblyName)
        Finally
            LoadingAssembly = Nothing
        End Try
    End Sub
    Private Shared Sub SortActions(ByVal actions As ArrayList)
        actions.Sort(New MenuActionComparer)
        For Each a As MenuAction In actions
            If Not a.Items Is Nothing AndAlso a.Items.Count > 0 Then
                SortActions(a.Items)
            End If
        Next

    End Sub

    Public Shared Sub DisplayActions()
        m_MenuCategories.Sort(New CategoryComparer)
        CatNum = 1
        For Each c As MenuCategory In m_MenuCategories
            Dim cat As Object = AddCategory(c)
            SortActions(c.Items)
            For Each a As MenuAction In c.Items
                AddAction(cat, a)
            Next
            If TypeOf (cat) Is MenuItem Then
                Dim mi As MenuItem = CType(cat, MenuItem)
                If mi.MenuItems.Count = 0 Then
                    mi.Dispose()
                End If
            ElseIf TypeOf (cat) Is DevExpress.XtraBars.BarSubItem Then
                If Not ClearEmptyItems(CType(cat, DevExpress.XtraBars.BarSubItem)) Is Nothing Then
                    m_BarManager.MainMenu.AddItem(CType(cat, DevExpress.XtraBars.BarSubItem))
                End If
            End If
            If Not m_Bar Is Nothing Then
                For i As Integer = m_Bar.ItemLinks.Count - 1 To 0 Step -1
                    Dim li As DevExpress.XtraBars.BarItemLink = m_Bar.ItemLinks(i)
                    If TypeOf (li.Item) Is DevExpress.XtraBars.BarLargeButtonItem _
                    AndAlso CType(li.Item, DevExpress.XtraBars.BarLargeButtonItem).ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown _
                    AndAlso (CType(li.Item, DevExpress.XtraBars.BarLargeButtonItem).DropDownControl Is Nothing _
                    OrElse CType(CType(li.Item, DevExpress.XtraBars.BarLargeButtonItem).DropDownControl, DevExpress.XtraBars.PopupMenu).ItemLinks.Count = 0) Then
                        m_Bar.ItemLinks(i).Dispose()
                    End If

                Next
            End If
        Next
    End Sub

    Shared Function ClearEmptyItems(ByVal cat As DevExpress.XtraBars.BarSubItem) As DevExpress.XtraBars.BarSubItem
        For i As Integer = cat.ItemLinks.Count - 1 To 0 Step -1
            Dim li As DevExpress.XtraBars.BarItemLink = cat.ItemLinks(i)
            If TypeOf (li.Item) Is DevExpress.XtraBars.BarSubItem Then
                ClearEmptyItems(CType(li.Item, DevExpress.XtraBars.BarSubItem))
            End If
        Next
        If cat.ItemLinks.Count = 0 Then
            cat.Dispose()
            Return Nothing
        End If
        Return cat

    End Function
    Shared m_ActionsLocked As Boolean
    Public Shared Function LockActions() As Boolean
        If m_ActionsLocked Then Return False
        m_ActionsLocked = True
        Return True
    End Function
    Public Shared Sub UnlockActions()
        m_ActionsLocked = False
    End Sub

    Public Shared Sub Restrict(ByVal arrActions As String())
        Dim find As Boolean
        Dim nIndexA As Integer
        Dim nIndexC As Integer
        Dim a As MenuAction
        Dim c As MenuCategory

        For nIndexC = m_MenuCategories.Count - 1 To 0 Step -1
            c = CType(m_MenuCategories(nIndexC), MenuCategory)
            For nIndexA = c.Items.Count - 1 To 0 Step -1
                a = CType(c.Items(nIndexA), MenuAction)
                find = RestrictAction(arrActions, a)
                If find = False Then
                    c.Items.RemoveAt(nIndexA)
                End If
            Next
            If c.Items.Count = 0 Then
                'm_MenuCategories.RemoveAt(nIndexC)
            End If
        Next
    End Sub

    Protected Shared Function RestrictAction(ByVal arrActions As String(), ByVal action As MenuAction) As Boolean
        Dim find As Boolean
        Dim findSubaction As Boolean
        Dim nIndex As Integer
        Dim subAction As MenuAction

        find = False

        For Each actionName As String In arrActions
            If (actionName.CompareTo(action.Caption) = 0) Then
                find = True
                Exit For
            End If
        Next

        '>>>> Added by Andrey 25-Sep-2007
        If action.Name.IndexOf(".rpt") <> -1 Then
            find = True
        End If
        '<<<< Added by Andrey 25-Sep-2007


        If (find = True) AndAlso (Not action.Items Is Nothing) AndAlso (action.Items.Count > 0) Then
            For nIndex = action.Items.Count - 1 To 0 Step -1
                subAction = CType(action.Items(nIndex), MenuAction)
                findSubaction = RestrictAction(arrActions, subAction)
                If findSubaction = False Then
                    action.Items.RemoveAt(nIndex)
                End If
            Next
        End If
        Return (find)
    End Function
#End Region

#Region "Private methods"
    Public Shared Function GetCategory(ByVal CategoryName As String) As MenuCategory
        Dim c As MenuCategory
        For Each c In m_MenuCategories
            If CategoryName = c.Caption Then Return c
        Next
        c = New MenuCategory(CategoryName, 10000)
        m_MenuCategories.Add(c)
        Return c
    End Function

    Private Shared Sub Toolbar_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
        If Not e.Button.Tag Is Nothing Then
            CType(e.Button.Tag, EventHandler).Invoke(e.Button, EventArgs.Empty)
        End If
    End Sub
    Private Shared Sub Clear()
        m_MenuCategories.Clear()
        m_MenuCategories.Add(New MenuCategory("MenuFile", 1))
        m_MenuCategories.Add(New MenuCategory("MenuEdit", 100))
        m_MenuCategories.Add(New MenuCategory("MenuView", 200))
        m_MenuCategories.Add(New MenuCategory("MenuCatalogs", 300))
        m_MenuCategories.Add(New MenuCategory("MenuOperations", 400))
        m_MenuCategories.Add(New MenuCategory("MenuCreate", 450))
        m_MenuCategories.Add(New MenuCategory("MenuSearch", 500))
        m_MenuCategories.Add(New MenuCategory("MenuReports", 600))
        m_MenuCategories.Add(New MenuCategory("MenuMaps", 650))

        m_MenuCategories.Add(New MenuCategory("MenuDocuments", 700))
        m_MenuCategories.Add(New MenuCategory("MenuOptions", 800))
        m_MenuCategories.Add(New MenuCategory("MenuSystem", 900))
        m_MenuCategories.Add(New MenuCategory("MenuSecurity", 1000))
        m_MenuCategories.Add(New MenuCategory("MenuWindow", 999900))
        m_MenuCategories.Add(New MenuCategory("MenuHelp", 1000000))
        SubCategoies.Clear()
        Dim s As String = Utils.Str(Config.GetSetting("ShowCaptionOnToolbar")).ToLower(Globalization.CultureInfo.InvariantCulture)
        If s = "true" Then
            m_ShowButtonCaption = True
        Else
            m_ShowButtonCaption = False
        End If
        'If Not m_Toolbar Is Nothing Then m_Toolbar.Buttons.Clear()
        'If Not m_MainMenu Is Nothing Then m_MainMenu.MenuItems.Clear()
        If Not m_BarManager Is Nothing Then
            Dim i As Integer
            For i = m_BarManager.Items.Count - 1 To 0 Step -1
                If Not (m_BarManager.Items(i).Links.Count > 0 AndAlso TypeOf (m_BarManager.Items(i).Links(0).LinkedObject) Is DevExpress.XtraBars.Bar _
                    AndAlso CType(m_BarManager.Items(i).Links(0).LinkedObject, DevExpress.XtraBars.Bar).IsStatusBar) Then
                    m_BarManager.Items(i).Dispose()
                End If
            Next
            'm_BarManager.Items.Clear()
        End If
        'If Not m_Bar Is Nothing Then m_Bar.ClearLinks()
    End Sub
    Private Shared m_ItemStorage As IStringStorage = New StringsStorage
    Public Shared Property ItemsStorage() As IStringStorage
        Get
            Return m_ItemStorage
        End Get
        Set(ByVal Value As IStringStorage)
            m_ItemStorage = Value
        End Set
    End Property
    Private Shared m_AdditionalItemsStorage As New Dictionary(Of String, IStringStorage)

    Public Shared ReadOnly Property AdditionalItemsStorage() As Dictionary(Of String, IStringStorage)
        Get
            Return m_AdditionalItemsStorage
        End Get
    End Property
    Private Shared Function GetString(ByVal Item As MenuAction) As String
        If Utils.Str(Item.TranslatedCaption) <> "" Then
            Return Item.TranslatedCaption
        ElseIf Not Item.ItemsStorage Is Nothing Then
            Return Item.ItemsStorage.GetString(Item.Caption)
        ElseIf Not Item.AssemblyName Is Nothing AndAlso m_AdditionalItemsStorage.ContainsKey(Item.AssemblyName) Then
            Dim s As String = m_AdditionalItemsStorage(Item.AssemblyName).GetString(Item.Caption)
            If Not Utils.IsEmpty(s) Then
                Return s
            End If
        End If
        Return m_ItemStorage.GetString(Item.Caption)
    End Function

    Private Shared Function GetString(ByVal Item As MenuCategory) As String
        Dim s As String
        If Not Item.AssemblyName Is Nothing AndAlso m_AdditionalItemsStorage.ContainsKey(Item.AssemblyName) Then
            s = m_AdditionalItemsStorage(Item.AssemblyName).GetString(Item.Caption)
            If Not Utils.IsEmpty(s) Then
                Return s
            End If
        End If
        Return m_ItemStorage.GetString(Item.Caption)
    End Function

    Public Shared Function GetSubCategory(ByVal SubCategoryName As String, ByVal CategoryName As String, Optional ByVal aOrder As Integer = 10000000) As MenuAction
        If SubCategoies.ContainsKey(SubCategoryName) Then Return CType(SubCategoies(SubCategoryName), MenuAction)
        Dim ma As New MenuAction(CategoryName, SubCategoryName, Nothing)
        ma.Items = New ArrayList
        ma.Order = aOrder
        SubCategoies(SubCategoryName) = ma
        RegisterAction(ma)
        Return ma
    End Function
    Private Shared CatNum As Integer
    Private Shared AppRegEx As New Regex("&(?!&)")
    Private Shared Function GetToolTipText(ByVal caption As String) As String
        Return AppRegEx.Replace(caption, "")
    End Function

    Private Shared Function AddCategory(ByVal c As MenuCategory) As Object
        If Not m_BarManager Is Nothing Then
            Dim cat As New DevExpress.XtraBars.BarSubItem
            cat.Caption = GetString(c)
            cat.ImageIndex = c.ImageIndex
            'cat.CategoryGuid = Guid.NewGuid()
            'cat.Id = CatNum
            'CatNum += 1
            'cat.Name = c.Caption
            m_BarManager.Items.Add(cat)
            If c.ShowInToolbar Then
                Dim cat1 As New DevExpress.XtraBars.BarLargeButtonItem(m_BarManager, GetString(c))
                cat1.Hint = GetToolTipText(cat1.Caption)
                cat1.ImageIndex = c.ImageIndex
                cat1.LargeImageIndex = c.ImageIndex
                cat1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
                cat1.DropDownControl = New DevExpress.XtraBars.PopupMenu
                cat1.ShowCaptionOnBar = m_ShowButtonCaption
                'cat1.ActAsDropDown = True
                cat1.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Bottom
                cat1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu
                cat.Tag = cat1
                Dim bl As DevExpress.XtraBars.BarItemLink = m_Bar.AddItem(cat1)
                If IsGroup OrElse c.BeginGroup Then bl.BeginGroup = True

            End If
            Return cat
            'ElseIf Not m_MainMenu Is Nothing Then
            '    Return m_MainMenu.MenuItems.Add(GetString(c))
        End If
        Return Nothing
    End Function
    Shared IsGroup As Boolean
    Private Shared Sub AddAction(ByVal parentItem As Object, ByVal a As MenuAction)
        If a.MenuAccessRights.CanSelect() = False Then Exit Sub
        Dim btn As DevExpress.XtraBars.BarItem = Nothing
        If Not parentItem Is Nothing Then
            'If Not m_MainMenu Is Nothing Then
            '    Dim mi As MenuItem = CType(parentItem, MenuItem)
            '    If Utils.Str(a.TranslatedCaption) <> "" Then
            '        mi = mi.MenuItems.Add(a.TranslatedCaption, a.Click)
            '    Else
            '        mi = mi.MenuItems.Add(GetString(a), a.Click)
            '    End If
            'Else
            If Not m_BarManager Is Nothing Then
                Dim cat As DevExpress.XtraBars.BarSubItem = CType(parentItem, DevExpress.XtraBars.BarSubItem)
                If a.Caption = "MenuSeparator" Then
                    IsGroup = True
                    Return
                End If
                If Not a.Items Is Nothing AndAlso a.Items.Count > 0 Then
                    btn = New DevExpress.XtraBars.BarSubItem(m_BarManager, GetString(a))
                Else
                    If a.Caption = "MenuWindows" Then
                        btn = New DevExpress.XtraBars.BarMdiChildrenListItem
                        IsGroup = True
                    Else
                        btn = New DevExpress.XtraBars.BarLargeButtonItem(m_BarManager, GetString(a))
                        CType(btn, DevExpress.XtraBars.BarLargeButtonItem).LargeImageIndex = a.BigIconIndex
                        CType(btn, DevExpress.XtraBars.BarLargeButtonItem).ImageIndex = a.SmallIconIndex
                        CType(btn, DevExpress.XtraBars.BarLargeButtonItem).ShowCaptionOnBar = m_ShowButtonCaption
                        If btn.Width > 100 Then btn.Width = 100
                        AddHandler btn.ItemClick, a.BarClick
                    End If
                End If
                btn.ImageIndex = a.SmallIconIndex
                btn.Description = btn.Caption
                btn.Hint = GetToolTipText(btn.Caption)
                Dim bl As DevExpress.XtraBars.BarItemLink
                If a.ShowInMenu = True Then
                    m_BarManager.Items.Add(btn)
                    a.MenuItem = btn
                    bl = cat.AddItem(btn)
                    If Not cat.Tag Is Nothing Then
                        Dim cat1 As DevExpress.XtraBars.BarLargeButtonItem = CType(cat.Tag, DevExpress.XtraBars.BarLargeButtonItem)
                        Dim bl1 As DevExpress.XtraBars.BarItemLink = CType(cat1.DropDownControl, DevExpress.XtraBars.PopupMenu).ItemLinks.Add(btn)
                        If IsGroup Then bl1.BeginGroup = True
                    End If
                    If IsGroup OrElse a.BeginGroup Then bl.BeginGroup = True
                End If
                If a.ShowInToolbar AndAlso Not m_Bar Is Nothing Then
                    'm_Bar.LinksPersistInfo.Add(New DevExpress.XtraBars.LinkPersistInfo(btn))
                    If TypeOf (btn) Is DevExpress.XtraBars.BarSubItem Then
                        Dim btn1 As New DevExpress.XtraBars.BarLargeButtonItem(m_BarManager, GetString(a))
                        btn1.Hint = GetToolTipText(btn1.Caption)
                        btn1.ImageIndex = a.SmallIconIndex
                        btn1.LargeImageIndex = a.BigIconIndex
                        btn1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
                        btn1.DropDownControl = New DevExpress.XtraBars.PopupMenu
                        btn1.ShowCaptionOnBar = m_ShowButtonCaption
                        'btn1.ActAsDropDown = True
                        btn1.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Bottom
                        btn.Tag = btn1
                        bl = m_Bar.AddItem(btn1)
                        a.ToolbarItem = btn1
                        If IsGroup OrElse a.BeginGroup Then bl.BeginGroup = True
                    Else
                        bl = m_Bar.AddItem(btn)
                        If IsGroup OrElse a.BeginGroup Then bl.BeginGroup = True
                    End If
                End If
                IsGroup = False
            End If
            If Not a.Items Is Nothing AndAlso a.Items.Count > 0 Then
                For Each a1 As MenuAction In a.Items
                    AddAction(btn, a1)
                Next
            End If
        End If
        'If Not m_Toolbar Is Nothing AndAlso a.ShowInToolbar Then
        '    Dim btn1 As New ToolBarButton(GetString(a))
        '    btn1.Tag = a.Click
        '    m_Toolbar.Buttons.Add(btn1)
        '    If Not a.Items Is Nothing AndAlso a.Items.Count > 0 Then
        '        btn1.Style = ToolBarButtonStyle.DropDownButton
        '        Dim m As New ContextMenu
        '        For Each a1 As MenuAction In a.Items
        '            m.MenuItems.Add(GetString(a1), a1.Click)
        '        Next
        '        btn1.DropDownMenu = m
        '    End If
        'End If
    End Sub
#End Region



End Class
Public Class MenuAction
    Public Caption As String
    Public Shortcut As String
    Public Name As String
    Public SmallIconIndex As Integer
    Public BigIconIndex As Integer
    Public ShowInToolbar As Boolean
    Public Category As String
    Public Order As Integer = 0
    Public MenuAccessRights As IAccessPermission = New DefaultAccessPermissions
    Public Items As ArrayList
    Public BeginGroup As Boolean
    Public ShowInMenu As Boolean = True
    Public Delegate Sub Handler()
    Public Delegate Sub ActionHandler(ByVal action As MenuAction)
    Public TranslatedCaption As String
    Public MenuItem As DevExpress.XtraBars.BarItem
    Public ToolbarItem As DevExpress.XtraBars.BarLargeButtonItem
    Private m_AssemblyName As String
    Public ReadOnly Property AssemblyName() As String
        Get
            Return m_AssemblyName
        End Get
    End Property
    Private m_ItemStorage As IStringStorage = Nothing
    Public Property ItemsStorage() As IStringStorage
        Get
            Return m_ItemStorage
        End Get
        Set(ByVal Value As IStringStorage)
            m_ItemStorage = Value
        End Set
    End Property

    Private Class ActionProxy
        Public realHandler As Handler
        Public realActionHandler As ActionHandler
        Protected Friend m_Action As MenuAction
        Public Sub Handle(ByVal sender As Object, ByVal args As EventArgs)
            If Not realHandler Is Nothing AndAlso MenuActionManager.LockActions() Then
                Try
                    realHandler()
                Finally
                    MenuActionManager.UnlockActions()
                End Try
            ElseIf Not realActionHandler Is Nothing AndAlso MenuActionManager.LockActions() Then
                Try
                    realActionHandler(m_Action)
                Finally
                    MenuActionManager.UnlockActions()
                End Try

            End If
        End Sub
        Public Sub ItemClickHandler(ByVal sender As Object, ByVal args As DevExpress.XtraBars.ItemClickEventArgs)
            If Not realHandler Is Nothing AndAlso MenuActionManager.LockActions() Then
                Try
                    realHandler()
                Finally
                    MenuActionManager.UnlockActions()
                End Try
            ElseIf Not realActionHandler Is Nothing AndAlso MenuActionManager.LockActions() Then
                Try
                    realActionHandler(m_Action)
                Finally
                    MenuActionManager.UnlockActions()
                End Try
            End If
        End Sub
    End Class
    Dim m_Proxy As New ActionProxy

    Public ReadOnly Property Click() As EventHandler
        Get
            Return AddressOf m_Proxy.Handle
        End Get
    End Property
    Public ReadOnly Property BarClick() As DevExpress.XtraBars.ItemClickEventHandler
        Get
            Return AddressOf m_Proxy.ItemClickHandler
        End Get
    End Property

    Public Property Activate() As Handler
        Get
            Return m_Proxy.realHandler
        End Get
        Set(ByVal Value As Handler)
            m_Proxy.realHandler = Value
        End Set
    End Property
    Public Property ActivateAction() As ActionHandler
        Get
            Return m_Proxy.realActionHandler
        End Get
        Set(ByVal Value As ActionHandler)
            m_Proxy.realActionHandler = Value
        End Set
    End Property
    Private Sub BaseInit(ByVal aCategory As String, ByVal aName As String, Optional ByVal m_Order As Integer = 0, Optional ByVal aShowInToolbar As Boolean = False, Optional ByVal aSmallImageIndex As Integer = -1, Optional ByVal aBigImageIndex As Integer = -1)
        Name = aName
        Caption = aName
        Category = aCategory
        SmallIconIndex = aSmallImageIndex
        m_Proxy.m_Action = Me
        BigIconIndex = aBigImageIndex
        ShowInToolbar = aShowInToolbar
        Order = m_Order
        m_AssemblyName = MenuActionManager.LoadingAssembly
    End Sub
    Public Sub New(ByVal aCategory As String, ByVal aName As String, ByVal actionHandler As Handler, Optional ByVal m_Order As Integer = 0, Optional ByVal aShowInToolbar As Boolean = False, Optional ByVal aSmallImageIndex As Integer = -1, Optional ByVal aBigImageIndex As Integer = -1)
        BaseInit(aCategory, aName, m_Order, aShowInToolbar, aSmallImageIndex, aBigImageIndex)
        Activate = actionHandler
    End Sub
    Public Sub New(ByVal actionHandler As ActionHandler, ByVal aCategory As String, ByVal aName As String, Optional ByVal m_Order As Integer = 0, Optional ByVal aShowInToolbar As Boolean = False, Optional ByVal aSmallImageIndex As Integer = -1, Optional ByVal aBigImageIndex As Integer = -1)
        BaseInit(aCategory, aName, m_Order, aShowInToolbar, aSmallImageIndex, aBigImageIndex)
        ActivateAction = ActionHandler
    End Sub

End Class
