using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.openapi.bll.Exceptions
{
    /// <summary>Error codes</summary>
    public enum OpenApiErrorCode
    {
        // general errors
        /// <summary>General error</summary>
        G0001,

        // authorization section section
        /// <summary>User login can't be empty</summary>
        A0001,
        /// <summary>User with such login/password is not found</summary>
        A0002,
        /// <summary>The database version is absent or in incorrect format</summary>
        A0003,
        /// <summary>Login is locked</summary>
        A0004,
        /// <summary>Password is expired</summary>
        A0005,
        /// <summary>Language is not supported</summary>
        A0006,
        /// <summary>External system is not supported</summary>
        A0007,
        /// <summary>Login is failed (general login error)</summary>
        A0008,
        /// <summary>Login is required</summary>
        A0009,
        /// <summary>Access is denied</summary>
        A0010,

        // model section
        /// <summary>Validation</summary>
        M0001,
        /// <summary>Reference is not found</summary>
        M0002,
        /// <summary>Object is not found</summary>
        M0003,
        /// <summary>An attempt to set a readonly field was occured</summary>
        M0004,  
        
        // data section
        /// <summary>Wrong format</summary>
        D0001, 
    }
}
