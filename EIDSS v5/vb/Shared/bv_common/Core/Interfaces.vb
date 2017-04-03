
''' -----------------------------------------------------------------------------
''' <summary>
''' Provides interface methods and properties for the control that can be used 
''' as search panel for the <i>BaseListForm</i> descendant classes. It is assumed that 
''' this control will be linked with some data grid and should provide the capability 
''' to create search condition, apply it to the linked data grid and refresh its contents. 
''' ''' 
''' </summary>
''' <remarks>
''' By default <i>bvwin_common</i> assembly contains 2 controls (SearchPanel and XtraSearchPanel) 
''' that implement this interface. <i>XtraSearchPanel</i> control is used by all <i>BasePagedXtraListForm</i> 
''' forms by default.
''' If advanced search functionality is needed the custom controls that implements this 
''' interface should be developed.
''' </remarks>
''' <history>
''' 	[Mike]	30.03.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Interface ISearchForm
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' <i>Search</i> event should be fired by control that implements <i>ISearchForm</i> interface
    ''' when search condition is formed and should be applied to the linked data grid.
    ''' </summary>
    ''' <param name="FilterCondition">
    ''' search expression that should be added to the default WHERE expression of default SQL query 
    ''' applied to the data grid DataSource using AND operator.
    ''' </param>
    ''' <param name="FromCondition">
    ''' search expression that should be added to the default FROM expression of default SQL query 
    ''' applied to the data grid DataSource. Use <i>FromCondition</i> to create complex search query that 
    ''' will filter data using joins with other tables.
    ''' </param>
    ''' <remarks>
    ''' No additional checks is performed by for <i>FilterCondition</i> validation. Search control 
    ''' should validate the user input and provide correct search expression that will be just 
    ''' substituted to the default SQL query.
    ''' </remarks>
    ''' <example>
    ''' Let's consider how the search expressions formed by search panel will affect to the default SQL query.
    ''' For example we have the simple default query
    ''' <code>
    ''' SELECT Author.LastName, Author.FirstName FROM Author WHERE Author BirthDate>'1/1/1950'
    ''' </code>
    ''' 
    ''' Let's assume that we want to find all authors that are older then 30 years and have books 
    ''' with titles starting from 'B' letter.  
    ''' 
    ''' Our resulting query should look like this:
    ''' <code>
    ''' SELECT Author.LastName, Author.FirstName 
    ''' FROM Author 
    ''' INNER JOIN Author_Book ON
    '''     Author.AuthorID=Author_Book.AuthorID
    ''' INNER JOIN Book ON
    '''     Author_Book.BookID=Author_Book..BookID
    ''' WHERE 
    '''     Author.BirthDate>'1/1/1950'
    '''     AND (Author.BirthDate&lt;'1/1/1976' AND Book.Title LIKE 'B%')
    ''' </code>
    ''' 
    ''' To provide such query the search panel should fire the <i>Search</i> event 
    ''' with the next <i>FilterCondition</i> and <i>FromCondition</i> parameters:
    ''' <code>
    ''' FilterCondition = "(Author.BirthDate&lt;'1/1/1976' AND Book.Title LIKE 'B%')"
    ''' FromCondition = "INNER JOIN Author_Book ON Author.AuthorID=Author_Book.AuthorID INNER JOIN Book ON Author_Book.BookID=Author_Book..BookID"
    ''' </code>    
    ''' </example>
    ''' <history>
    ''' 	[Mike]	03.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Event Search(ByVal FilterCondition As String, ByVal FromCondition As String)
    Event SearchUsingProcedure(ByVal SearchParameters As Collections.Generic.Dictionary(Of String, Object))
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Initializes the search panel with parent grid control
    ''' </summary>
    ''' <param name="Grid">
    ''' the grid control related that should be linked to the search panel
    ''' </param>
    ''' <remarks>
    ''' This method should link search panel with specific grid control.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	03.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Sub Init(ByVal Grid As Object)
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Returns the search expression that should be added to the default WHERE expression of default SQL query 
    ''' applied to the data grid DataSource using AND operator.
    ''' </summary>
    ''' <remarks>
    ''' This property should return the filter currently defined by search panel.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	03.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    ReadOnly Property FilterCondition() As String
    ReadOnly Property FromCondition() As String
    ReadOnly Property SearchParameters() As Collections.Generic.Dictionary(Of String, Object)
    Sub SetStartupParameters(ByVal parameters As Hashtable)
End Interface

''' -----------------------------------------------------------------------------
''' <summary>
''' This interface should be implemented by classes that provide the resource translation capabilities.
''' </summary>
''' <remarks>
''' Currently this interface is used by <i>MenuAction</i> class to translate menu items.
''' By default it uses <i>StringStorage</i> class as translator and reads translations from 
''' <i>bv_common.Messages.res</i> file. The application that use bv_common assembly can implement 
''' its own translation class and put menu items translations to its own resource file.
''' To do this application should initialize shared <i>MenuAction.ItemsStorage</i> property 
''' with other <i>IStringStorage</i> implementation.
''' </remarks>
''' <history>
''' 	[Mike]	03.04.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Interface IStringStorage
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Returns translated string using resource file related with current instance 
    ''' of class that implements <i>IStringStorage</i> interface.
    ''' </summary>
    ''' <param name="stringName">
    ''' the resource string key name 
    ''' </param>
    ''' <param name="stringValue">
    ''' the resource string default value, if it is not passed <i>stringName</i> is used as <i>stringValue</i>.
    ''' </param>
    ''' <param name="CultureName">
    ''' the culture ID (defined by ClobalSettings.lngXXX properties) that defines target translation language.
    ''' </param>
    ''' <returns>
    ''' translated string if the <i>stringName</i> is found in localized resource file or default <i>stringValue</i> in other case. 
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	03.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function GetString(ByVal stringName As String, Optional ByVal stringValue As String = Nothing, Optional ByVal CultureName As String = Nothing) As String
End Interface

Public Interface ISearchable
    Sub LoadSearchPanel()
    Sub EnableSearchPanel()
End Interface

Public Interface IMainForm
    Sub RefreshLayout()
End Interface